using Microsoft.EntityFrameworkCore;
using Wapiti.Application.Common.Interfaces;
using Wapiti.Domain.Entities;

namespace Wapiti.Persistence
{
    public class WapitiDbContext:DbContext, IWapitiDbContext
    {
        public WapitiDbContext(DbContextOptions<WapitiDbContext> options) : base(options)
        {
        }
        public DbSet<Collection> Collections { get; set; }
		public DbSet<Card> Cards { get; set; }
		public DbSet<Deck> Decks { get; set; }
        public DbSet<DeckBoard> DeckBoards { get; set; }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.ApplyConfigurationsFromAssembly(typeof(WapitiDbContext).Assembly);
        // }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=MTGCollection.db", b => b.MigrationsAssembly("Wapiti.Api"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>()
                .HasKey(c => c.Name);
            modelBuilder.Entity<Collection>()
                .HasMany<Card>(c => c.Cards);
            modelBuilder.Entity<Collection>()
                .HasMany<Deck>(c => c.Decks);
            modelBuilder.Entity<Deck>()
                .HasMany<DeckBoard>(d => d.DeckList);
        }
    }
}