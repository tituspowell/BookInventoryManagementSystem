using BookInventoryManagementSystem.Application.Services.Books;
using Microsoft.EntityFrameworkCore;

namespace BookInventoryManagementSystem.Web.Controllers
{
    public class BooksController(IBooksService _booksService) : Controller
    {

        // GET: Books
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["TitleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["AuthorSortParm"] = sortOrder == "Author" ? "author_desc" : "Author";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            var books = from book in await _booksService.GetAllAsync()
                        select book;

            switch (sortOrder)
            {
                case "title_desc":
                    books = books.OrderByDescending(b => b.Title);
                    break;
                case "Author":
                    books = books.OrderBy(b => b.Author);
                    break;
                case "author_desc":
                    books = books.OrderByDescending(b => b.Author);
                    break;
                case "Date":
                    books = books.OrderBy(b => b.PublicationYear);
                    break;
                case "date_desc":
                    books = books.OrderByDescending(b => b.PublicationYear);
                    break;
                default:
                    books = books.OrderBy(b => b.Title);
                    break;
            }

            return View(books.ToList());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _booksService.GetBookAsync<BookViewModelWithId>(id.Value);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _booksService.GetBookAsync<BookViewModelWithId>(id.Value);

            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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
                    if (!BookExists(bookVM.Id))
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _booksService.GetBookAsync<BookViewModelWithId>(id.Value);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _booksService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _booksService.BookExists(id);
        }
    }
}
