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
            modelBuilder.Entity<CollectionCard>()
                .HasKey(cc => new { cc.CardName, cc.CollectionId});
            modelBuilder.Entity<CollectionCard>()
                .HasOne(cc => cc.Card)
                .WithMany(c => c.CollectionCards)
                .HasForeignKey(cc => cc.CardName);
            modelBuilder.Entity<CollectionCard>()
                .HasOne(cc => cc.Collection)
                .WithMany(c => c.Cards)
                .HasForeignKey(cc => cc.CollectionId);
            modelBuilder.Entity<Collection>()
                .HasMany<Deck>(c => c.Decks)
                .WithOne(d => d.Collection);
            modelBuilder.Entity<Deck>()
                .HasOne<Collection>(d => d.Collection)
                .WithMany(c => c.Decks);
            modelBuilder.Entity<Deck>()
                .HasMany<DeckBoard>(d => d.DeckList)
                .WithOne(db => db.Deck);
            modelBuilder.Entity<DeckBoardCard>()
                .HasKey(dbc => new { dbc.CardName, dbc.DeckBoardId});
            modelBuilder.Entity<DeckBoardCard>()
                .HasOne(dbc => dbc.Card)
                .WithMany(c => c.DeckBoardCards)
                .HasForeignKey(dbc => dbc.CardName);
            modelBuilder.Entity<DeckBoardCard>()
                .HasOne(dbc => dbc.DeckBoard)
                .WithMany(db => db.Cards)
                .HasForeignKey(dbc => dbc.DeckBoardId);
        }
    }
}
