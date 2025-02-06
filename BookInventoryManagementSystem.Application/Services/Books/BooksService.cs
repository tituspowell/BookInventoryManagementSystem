using AutoMapper;
using BookInventoryManagementSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookInventoryManagementSystem.Application.Services.Books;

public class BooksService(ApplicationDbContext _context, IMapper _mapper) : IBooksService
{
    public async Task<List<BookViewModelWithId>> GetAllAsync()
    {
        List<Book> bookList = await _context.Books.ToListAsync();

        var bookVMList = _mapper.Map<List<BookViewModelWithId>>(bookList);
        return bookVMList;
    }

    public async Task<Book?> GetBookAsync(int id)
    {
        return await _context.Books.FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task<BookViewModelWithId> GetBookViewModelWithIdAsync(int id)
    {
        var book = await _context.Books.FirstOrDefaultAsync(q => q.Id == id);

        if (book == null)
        {
            return null;
        }

        var bookVM = _mapper.Map<BookViewModelWithId>(book);
        return bookVM;
    }

    public async Task CreateAsync(BookViewModelWithoutId bookVM)
    {
        var book = _mapper.Map<Book>(bookVM);

        _context.Add(book);
        await _context.SaveChangesAsync();
    }

    public async Task EditAsync(BookViewModelWithId bookVM)
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
