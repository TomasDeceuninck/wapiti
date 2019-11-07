using System;

namespace td.wapiti.domain
{
    public class CollectionDeck
    {
        public Deck Deck { get; set; }
        public bool IsConstructed { get; set; } = false;
        public string DisplayName {
            get
            {
                string displayName = this.Deck.ToString();
                if(this.IsConstructed){
                    displayName = displayName + " [Constructed]";
                }
                return displayName;
            }
        }

        // Constructor that takes no arguments:
        public CollectionDeck(Deck deck)
        {
            this.Deck = deck;
        }

        // Method that overrides the base class (System.Object) implementation.
        public override string ToString()
        {
            return this.DisplayName;
        }
    }
}
