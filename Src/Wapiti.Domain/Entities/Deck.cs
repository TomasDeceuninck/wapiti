using System;
using System.Collections.Generic;

namespace Wapiti.Domain.Entities
{
    public class Deck
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public List<DeckCard> DeckList { get; set; }

        // Constructor that takes no arguments:
        public Deck(string name)
        {
            this.Name = name;
            this.Id = Guid.NewGuid();
        }

        // Method that overrides the base class (System.Object) implementation.
        public override string ToString()
        {
            return this.Name;
        }
    }
}
