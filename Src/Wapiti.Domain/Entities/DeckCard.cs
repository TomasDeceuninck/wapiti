using System;

namespace Wapiti.Domain.Entities
{
    public class DeckCard
    {
        public string CardName { get; set; }
        public Card Card { get; set; }
        public Guid DeckId { get; set; }
        public Deck Deck { get; set; }
    }
}
