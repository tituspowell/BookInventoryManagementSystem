using BookInventoryManagementSystem.Application.Services.Books;
using BookInventoryManagementSystem.Application.Services.BooksReviewsSharedService;
using Microsoft.EntityFrameworkCore;

namespace BookInventoryManagementSystem.Web.Controllers
{
    public class BooksController(IBooksService _booksService, IBooksReviewsSharedService _booksReviewsSharedService) : Controller
    {
        // GET: Books
        [HttpGet]
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["TitleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["AuthorSortParm"] = sortOrder == "Author" ? "author_desc" : "Author";
            ViewData["RatingSortParm"] = sortOrder == "Rating" ? "rating_desc" : "Rating";
            ViewData["ReviewSortParm"] = sortOrder == "Reviews" ? "reviews_desc" : "Reviews";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            var books = from book in await _booksReviewsSharedService.GetAllBookViewModelsAsync()
                        select book;

            books = sortOrder switch
            {
                "title_desc" => books.OrderByDescending(b => b.Title),
                "Author" => books.OrderBy(b => b.Author),
                "author_desc" => books.OrderByDescending(b => b.Author),
                "Rating" => books.OrderBy(b => b.AverageRating),
                "rating_desc" => books.OrderByDescending(b => b.AverageRating),
                "Reviews" => books.OrderBy(b => b.NumberOfReviews),
                "reviews_desc" => books.OrderByDescending(b => b.NumberOfReviews),
                "Date" => books.OrderBy(b => b.PublicationYear),
                "date_desc" => books.OrderByDescending(b => b.PublicationYear),
                _ => books.OrderBy(b => b.Title),
            };
            return View(books.ToList());
        }

        // GET: Books/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _booksReviewsSharedService.GetBookViewModelWithIdAndReviewsAsync(id.Value);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        [HttpGet]
        [Authorize(Roles = "Librarian,Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Librarian,Administrator")]
        public async Task<IActionResult> Create(BookViewModelWithoutId bookVM)
        {
            // QQ Debugging
            //Console.WriteLine($"Received UnparsedAuthors: {bookVM.UnparsedAuthors}");

            if (ModelState.IsValid)
            {
                await _booksService.CreateAsync(bookVM);
                return RedirectToAction(nameof(Index));
            }
            return View(bookVM);
        }

        // GET: Books/Edit/5
        [HttpGet]
        [Authorize(Roles = "Librarian,Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookVM = await _booksReviewsSharedService.GetBookViewModelWithIdAndReviewsAsync(id.Value);

            if (bookVM == null)
            {
                return NotFound();
            }

            return View(bookVM);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Librarian,Administrator")]
        public async Task<IActionResult> Edit(int id, BookViewModelWithId bookVM)
        {
            if (id != bookVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _booksService.EditAsync(bookVM);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_booksService.BookExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bookVM);
        }

        // GET: Books/Delete/5
        [HttpGet]
        [Authorize(Roles = "Librarian,Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _booksReviewsSharedService.GetBookViewModelWithIdAndReviewsAsync(id.Value);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Librarian,Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _booksService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
