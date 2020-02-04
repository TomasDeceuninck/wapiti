using Microsoft.EntityFrameworkCore;
using Wapiti.Application.Common.Interfaces;
using Wapiti.Domain.Entities;

namespace Wapiti.Persistence
{
    public class WapitiDbContext : DbContext, IWapitiDbContext
    {
        public WapitiDbContext(DbContextOptions<WapitiDbContext> options) : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<CollectionCard> CollectionCards { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<DeckCard> DeckCards { get; set; }
        public DbSet<Deck> Decks { get; set; }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.ApplyConfigurationsFromAssembly(typeof(WapitiDbContext).Assembly);
        // }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=MTGCollection.db", b => b.MigrationsAssembly("Wapiti.Api"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Card
            modelBuilder.Entity<Card>()
                .HasKey(c => c.Name);
            // CollectionCard
            modelBuilder.Entity<CollectionCard>()
                .HasKey(cc => new { cc.CollectionId, cc.CardName });
            modelBuilder.Entity<CollectionCard>()
                .HasOne(cc => cc.Collection)
                .WithMany(c => c.Cards)
                .HasForeignKey(cc => cc.CollectionId);
            modelBuilder.Entity<CollectionCard>()
                .HasOne(cc => cc.Card)
                .WithMany(c => c.CollectionCards)
                .HasForeignKey(cc => cc.CardName);
            // Collection
            modelBuilder.Entity<Collection>()
                .HasMany<Deck>(c => c.Decks)
                .WithOne(d => d.Collection);
            // DeckCard
            modelBuilder.Entity<DeckCard>()
                .HasKey(dc => new { dc.DeckId, dc.CardName });
            modelBuilder.Entity<DeckCard>()
                .HasOne(dc => dc.Deck)
                .WithMany(d => d.DeckList)
                .HasForeignKey(dc => dc.DeckId);
            modelBuilder.Entity<DeckCard>()
                .HasOne(dc => dc.Card)
                .WithMany(c => c.DeckCards)
                .HasForeignKey(dc => dc.CardName);
        }
    }
}
