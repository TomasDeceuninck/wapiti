using System;
using System.Collections.Generic;

namespace Wapiti.Domain.Entities
{
    public class Deck
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string CollectionId { get; set; }
        public List<DeckBoard> DeckList { get; set; }

        public List<Card> CardList {
            get
            {
                List<Card> _cardList = new List<Card>();
                foreach(DeckBoard board in this.DeckList)
                {
                    _cardList.AddRange(board.Cards);
                }
                return _cardList;
            }
        }

        // Constructor that takes no arguments:
        public Deck(string name, string collectionId)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.CollectionId = collectionId;
            this.DeckList = new List<DeckBoard>();
        }

        // Method that overrides the base class (System.Object) implementation.
        public override string ToString()
        {
            return this.Name;
        }
    }
}
