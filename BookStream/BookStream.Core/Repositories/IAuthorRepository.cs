using BookStream.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStream.Core.Repositories;
public interface IAuthorRepository
{
    Task<List<Author>> GetAllAsync(CancellationToken cancellationToken);
    Task<Author?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<bool> ExistsAsync(int id, CancellationToken cancellationToken);
    Task<bool> ExistsByNameAsync(string Name, CancellationToken cancellationToken);
    Task<int> AddAsync(Author author, CancellationToken cancellationToken);
}
