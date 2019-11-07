using System;
using System.Collections.Generic;

namespace td.wapiti.domain
{
    public class Deck
    {
        public string Name { get; set; }
        public List<Card> Mainboard { get; set; }
        public List<Card> Sideboard { get; set; }

        // Constructor that takes no arguments:
        public Deck(string name)
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
