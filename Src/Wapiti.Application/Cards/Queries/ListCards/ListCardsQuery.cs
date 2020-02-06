using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Wapiti.Application.Common.Interfaces;

namespace Wapiti.Application.Cards.Queries.ListCards
{
    public class ListCardsQuery : IRequest<ListCardsViewModel>
    {
        public class Handler : IRequestHandler<ListCardsQuery, ListCardsViewModel>
        {
            private readonly IWapitiDbContext _wapitiDbContext;

            public Handler(IWapitiDbContext wapitiDbContext)
            {
                _wapitiDbContext = wapitiDbContext;
            }
            public async Task<ListCardsViewModel> Handle(ListCardsQuery request, CancellationToken cancellationToken)
            {
                var cards = _wapitiDbContext.Cards.Select(c => new ListCardsDto()
                {
                    Name = c.Name
                });

                return new ListCardsViewModel()
                {
                    Cards = cards
                };
            }
        }
    }
}
