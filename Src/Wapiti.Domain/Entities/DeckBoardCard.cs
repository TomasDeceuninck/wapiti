using System;

namespace Wapiti.Domain.Entities
{
    public class DeckBoardCard
    {
        public string CardName { get; set; }
        public Card Card { get; set; }
        public Guid DeckBoardId { get; set; }
        public DeckBoard DeckBoard { get; set; }
    }
}
