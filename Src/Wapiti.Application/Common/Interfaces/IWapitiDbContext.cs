using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Wapiti.Domain.Entities;

namespace Wapiti.Application.Common.Interfaces
{
    public interface IWapitiDbContext
    {
        DbSet<Collection> Collections { get; set; }
		DbSet<Card> Cards { get; set; }
		DbSet<Deck> Decks { get; set; }
        DbSet<DeckCard> DeckCards { get; set; }
        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
