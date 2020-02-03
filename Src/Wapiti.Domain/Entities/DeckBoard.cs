using System;
using System.Collections.Generic;

namespace Wapiti.Domain.Entities
{
    public class DeckBoard
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public Guid DeckId { get; set; }
        public Deck Deck { get; set; }
        public List<DeckBoardCard> Cards { get; set; }

        public string DisplayName {
            get
            {
                string displayName = this.Name + "(" + this.Cards.Count + ")";
                return displayName;
            }
        }

        // Constructor that takes one argument:
        public DeckBoard(Guid deckId, string name)
        {
            this.Id = Guid.NewGuid();
            this.DeckId = deckId;
            this.Name = name;
            this.Cards = new List<DeckBoardCard>();
        }

        // Method that overrides the base class (System.Object) implementation.
        public override string ToString()
        {
            return this.DisplayName;
        }
    }
}
