using System;
using Wapiti.Domain.Enumerations;

namespace Wapiti.Domain.Entities
{
    public class DeckCard
    {
        public Card Card { get; set; }
        public DeckBoard Board { get; set; }

        public string DisplayName {
            get
            {
                string displayName = this.Card.Name;
                if(this.Board != DeckBoard.Mainboard){
                    displayName = this.Board + ": " + displayName;
                }
                return displayName;
            }
        }

        // Constructor that takes one argument:
        public DeckCard(Card card, DeckBoard board)
        {
            this.Card = card;
            this.Board = board;
        }



        // Method that overrides the base class (System.Object) implementation.
        public override string ToString()
        {
            return this.DisplayName;
        }
    }
}
