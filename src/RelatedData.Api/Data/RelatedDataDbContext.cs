using RelatedData.Api.Models;
using RelatedData.Api.Core;
using RelatedData.Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace RelatedData.Api.Data
{
    public class RelatedDataDbContext : DbContext, IRelatedDataDbContext
    {
        public DbSet<Product> Products { get; private set; }
        public DbSet<Category> Categories { get; private set; }
        public RelatedDataDbContext(DbContextOptions options)
            : base(options) { }

    }
}
