using System;
using System.Collections.Generic;

namespace td.wapiti.domain
{
    public class Collection
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; }
        public List<CollectionDeck> Decks { get; set; }

        // Constructor that takes no arguments:
        public Collection(string name)
        {
            this.Name = name;
        }

        // Method that overrides the base class (System.Object) implementation.
        public override string ToString()
        {
            return this.Name;
        }
    }
}
