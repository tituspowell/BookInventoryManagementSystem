using BookInventoryManagementSystem.Application.Services.Books;
using BookInventoryManagementSystem.Application.Services.Reviews;
using BookInventoryManagementSystem.Application.Services.Users;
using BookInventoryManagementSystem.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookInventoryManagementSystem.Web.Controllers;

public class ReviewsController(ApplicationDbContext _context,
    IUserService _userService,
    IBooksService _booksService,
    IReviewsService _reviewsService) : Controller
{
    // GET: Reviews
    [HttpGet]
    [Authorize(Roles = "Librarian,Administrator")]
    public async Task<IActionResult> Index()
    {
        var reviews = await _reviewsService.GetAllReviewViewModelsAsync();
        return View(reviews);
    }

    // GET: Reviews/Create
    [HttpGet]
    [Authorize(Roles = "Librarian,Administrator,Reader")]
    public async Task<IActionResult> Create(int bookId)
    {
        var userId = await _userService.GetIdOfLoggedInUserAsync();

        if (userId == null)
        {
            // Don't let them create a review if they're not logged in
            // TODO: better error handling
            return NotFound();
        }

        // Only allow one review per book for each user, so if one
        // exists then redirect to the Edit page
        if (await _reviewsService.ReviewExistsByUserForBookAsync(bookId, userId))
        {
            return RedirectToAction("Edit", new { id = bookId });
        }

        var book = await _booksService.GetBookAsync(bookId);

        if (book == null)
        {
            return NotFound();
        }

        // TODO: This is the fourth await this function - it must be possible to optimise...
        var reviewerName = await _userService.GetFullNameAsync(userId);

        // TODO: And we're not using AutoMapper because...?
        var reviewVM = new ReviewViewModelWithBookInfo() {
            BookId = bookId,
            ReviewerId = userId,
            RatingOutOfFive = 5,
            ReviewText = "",
            BookTitle = book.Title,
            BookAuthor = book.Author,
            ReviewerName = reviewerName,
            ReviewIsByLoggedInUser = true,
        };

        return View(reviewVM);
    }

    // POST: Reviews/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Librarian,Administrator,Reader")]
    public async Task<IActionResult> Create(ReviewViewModel reviewVM)
    {
        if (ModelState.IsValid)
        {
            await _reviewsService.CreateAsync(reviewVM);
            return RedirectToAction("Details", "Books", new { id = reviewVM.BookId });
        }

        return View(reviewVM);
    }

    // GET: Reviews/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        // Verify that either they are a librarian or admin, or it's their own review
        var allowedToEditReview = await _reviewsService.AllowedToEditReview(id.Value);
        if (!allowedToEditReview)
        {
            // TODO: better error handling
            return NotFound();
        }

        var reviewVM = await _reviewsService.GetReviewViewModelAsync(id.Value);
        if (reviewVM == null)
        {
            return NotFound();
        }

        return View(reviewVM);
    }

    // POST: Reviews/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Librarian,Administrator,Reader")]
    public async Task<IActionResult> Edit(ReviewViewModelWithBookInfoAndId reviewVM)
    {
        if (!ModelState.IsValid)
        {
            return View(reviewVM);
        }

        try
        {
            await _reviewsService.EditAsync(reviewVM);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ReviewExists(reviewVM.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToAction("Details", "Books", new { id = reviewVM.BookId });
    }

    // GET: Reviews/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        // Verify that either they are a librarian or admin, or it's their own review
        var allowedToEditReview = await _reviewsService.AllowedToEditReview(id.Value);
        if (!allowedToEditReview)
        {
            // TODO: better error handling
            return NotFound();
        }

        var reviewVM = await _reviewsService.GetReviewViewModelAsync(id.Value);
        if (reviewVM == null)
        {
            return NotFound();
        }

        return View(reviewVM);
    }

    // POST: Reviews/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        // Verify that either they are a librarian or admin, or it's their own review
        var allowedToEditReview = await _reviewsService.AllowedToEditReview(id);
        if (!allowedToEditReview)
        {
            // TODO: better error handling
            return NotFound();
        }

        await _reviewsService.DeleteAsync(id);

        return RedirectToAction("Index", "Books");
    }

    private bool ReviewExists(int id)
    {
        return _context.Reviews.Any(e => e.Id == id);
    }
}
