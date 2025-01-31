using AutoMapper;
using BookInventoryManagementSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookInventoryManagementSystem.Application.Services;

public class BooksService(ApplicationDbContext _context, IMapper _mapper) : IBooksService
{
    public async Task<List<BookIndexViewModel>> GetAllAsync()
    {
        List<Book> bookList = await _context.Books.ToListAsync();

        var bookVMList = _mapper.Map<List<BookIndexViewModel>>(bookList);
        return bookVMList;
    }

    public async Task<T?> GetBookAsync<T>(int id) where T : class
    {
        var book = await _context.Books.FirstOrDefaultAsync(q => q.Id == id);

        if (book == null)
        {
            return null;
        }

        var bookVM = _mapper.Map<T>(book);
        return bookVM;
    }

    public async Task CreateAsync(BookCreateViewModel bookVM)
    {
        var book = _mapper.Map<Book>(bookVM);
     
        // Convert the authors input string, which has newlines separating the authors, into a list, which is how we store them in the database
        var parsedListOfAuthors = bookVM.AuthorsUnparsed.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        book.Authors = parsedListOfAuthors;

        _context.Add(book);
        await _context.SaveChangesAsync();
    }

    public async Task EditAsync(BookEditViewModel bookVM)
    {
        var book = _mapper.Map<Book>(bookVM);
        _context.Update(book);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var book = await _context.Books.FirstOrDefaultAsync(q => q.Id == id);

        if (book == null)
        {
            return;
        }

        _context.Remove(book);
        await _context.SaveChangesAsync();
    }

    public bool BookExists(int id)
    {
        return _context.Books.Any(q => q.Id == id);
    }

}
