using RelatedData.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace RelatedData.Api.Interfaces
{
    public interface IRelatedDataDbContext
    {
        DbSet<Product> Products { get; }
        DbSet<Category> Categories { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
