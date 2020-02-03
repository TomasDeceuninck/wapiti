using System;
using Wapiti.Domain.Infrastructure;

namespace Wapiti.Domain.Entities
{
    public class Card
    {
        public string Name { get; private set; }

        // Constructor that takes no arguments:
        public Card(string name)
        {
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
