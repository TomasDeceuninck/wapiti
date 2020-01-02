using System;
using System.Collections.Generic;

namespace Wapiti.Domain.Entities
{
    public class Collection
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public List<Card> Cards { get; set; }
        public List<Deck> Decks { get; set; }

        // Constructor that takes no arguments:
        public Collection(string name)
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
