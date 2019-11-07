using System;

namespace td.wapiti.domain
{
    public class Card
    {
        public string Name { get; private set; }
        public Set Set { get; set; }
        public string DisplayName {
            get
            {
                string displayName = this.Name;
                if(this.Set != null){
                    displayName = displayName + " (" + this.Set + ")";
                }
                return displayName;
            }
        }

        // Constructor that takes no arguments:
        public Card(string name)
        {
            this.Name = name;
        }

        // Constructor that takes one argument:
        public Card(string name, Set set)
        {
            this.Name = name;
            this.Set = set;
        }

        // Method that overrides the base class (System.Object) implementation.
        public override string ToString()
        {
            return this.DisplayName;
        }
    }
}
