﻿using BookInventoryManagementSystem.Application.Services.Books;
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
    //public async Task<IActionResult> Index()
    //{
    //    var applicationDbContext = _context.Reviews.Include(r => r.Book).Include(r => r.Reviewer);
    //    return View(await applicationDbContext.ToListAsync());
    //}

    // GET: Reviews/Details/5
    //public async Task<IActionResult> Details(int? id)
    //{
    //    if (id == null)
    //    {
    //        return NotFound();
    //    }

    //    var review = await _context.Reviews
    //        .Include(r => r.Book)
    //        .Include(r => r.Reviewer)
    //        .FirstOrDefaultAsync(m => m.Id == id);
    //    if (review == null)
    //    {
    //        return NotFound();
    //    }

    //    return View(review);
    //}

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

        var reviewVM = new ReviewViewModelWithBookInfo() {
            BookId = bookId,
            ReviewerId = userId,
            RatingOutOfFive = 5,
            ReviewText = "",
            BookTitle = book.Title,
            BookAuthor = book.Author
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

        //ViewData["BookId"] = new SelectList(_context.Books, "Id", "Author", reviewVM.BookId);
        //ViewData["ReviewerId"] = new SelectList(_context.Users, "Id", "Id", reviewVM.ReviewerId);
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

        var review = await _context.Reviews
            .Include(r => r.Book)
            .Include(r => r.Reviewer)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (review == null)
        {
            return NotFound();
        }

        return View(review);
    }

    // POST: Reviews/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var review = await _context.Reviews.FindAsync(id);
        if (review != null)
        {
            _context.Reviews.Remove(review);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ReviewExists(int id)
    {
        return _context.Reviews.Any(e => e.Id == id);
    }
}
