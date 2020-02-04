using System;
using System.Collections.Generic;
using Wapiti.Domain.Infrastructure;

namespace Wapiti.Domain.Entities
{
    public class Card
    {
        // public string Id { get; private set; }
        public string Name { get; private set; }
        public List<CollectionCard> CollectionCards { get; set; }
        public List<DeckCard> DeckCards { get; set; }


        // Constructor that takes no arguments:
        public Card(string name)
        {
            // this.Id = Hasher.GetHashString(name);
            this.Name = name;
        }

        // Constructor that takes one argument:

        // Method that overrides the base class (System.Object) implementation.
        public override string ToString()
        {
            return this.Name;
        }
    }
}
