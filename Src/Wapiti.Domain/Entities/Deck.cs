using System;
using System.Collections.Generic;

namespace Wapiti.Domain.Entities
{
    public class Deck
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public Guid CollectionId { get; set; }
        public Collection Collection { get; set; }
        public List<DeckBoard> DeckList { get; set; }

        // Constructor that takes no arguments:
        public Deck(string name, Guid collectionId)
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
