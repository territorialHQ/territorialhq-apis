using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<TokenClient> TokenClients { get; set; }
        public DbSet<JournalArticle> JournalArticles { get; set; }
    }
}
