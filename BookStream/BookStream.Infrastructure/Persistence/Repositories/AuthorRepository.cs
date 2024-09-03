using BookStream.Core.Entities;
using BookStream.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookStream.Infrastructure.Persistence.Repositories;
public class AuthorRepository : IAuthorRepository
{
    private readonly BookStreamDbContext _context;
    public AuthorRepository(BookStreamDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddAsync(Author author, CancellationToken cancellationToken)
    {
        await _context.Authors.AddAsync(author, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return author.Id;
    }

    public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Authors.AnyAsync(a => a.Id == id, cancellationToken);
    }

    public async Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await _context.Authors.AnyAsync(a => a.Name == name, cancellationToken);
    }

    public async Task<List<Author>> GetAllAsync(CancellationToken cancellationToken)
    {
        var authors = await _context.Authors
                        .Include(b => b.Books)
                        .Where(b => !b.IsDeleted)
                        .ToListAsync(cancellationToken);

        return authors;
    }

    public async Task<Author?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Authors
            .Include(b => b.Books)
            .SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
    }
}
