using BookStream.Core.Entities;
using BookStream.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookStream.Infrastructure.Persistence.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BookStreamDbContext _context;
    public BookRepository(BookStreamDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddAsync(Book book, CancellationToken cancellationToken)
    {
        await _context.Books.AddAsync(book, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return book.Id;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Books.AnyAsync(b => b.Id == id, cancellationToken);
    }

    public async Task<bool> ExistsForTitleAsync(string title, CancellationToken cancellationToken)
    {
        return await _context.Books.AnyAsync(b => b.Title == title, cancellationToken);
    }

    public async Task<List<Book>> GetAllAsync(CancellationToken cancellationToken)
    {
        var books = await _context.Books
                        .Include(b => b.Genre)
                        .Include(b=> b.AgeRating)
                        .Where(b => !b.IsDeleted)
                        .ToListAsync(cancellationToken);

        return books;
    }

    public async Task<Book?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Books.SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task UpdateAsync(Book book, CancellationToken cancellationToken)
    {
         _context.Books.Update(book);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
