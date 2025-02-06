using AutoMapper;
using BookInventoryManagementSystem.Application.Services.Books;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInventoryManagementSystem.Application.Services.Reviews;

public class ReviewsService(ApplicationDbContext _context, IBooksService _booksService, IMapper _mapper)
{
    public async Task<float> GetRatingForBook(int id)
    {
        var book = await _booksService.GetBookAsync(id);

        var averageRating = await _context.Reviews
            .Where(r => r.BookId == id)
            .AverageAsync(r => r.RatingOutOfFive);

        return (float)averageRating;
    }

}
