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

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<TokenClient> TokenClients { get; set; }
        public DbSet<JournalArticle> JournalArticles { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<ClanUserRelation> ClanUserRelations { get; set; }
        public DbSet<ContentPage> ContentPages { get; set; }
        public DbSet<NavigationEntry> NavigationEntries { get; set; }

    }
}
