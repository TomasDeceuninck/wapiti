using System;

namespace Wapiti.Domain.Entities
{
    public class Set
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string DisplayName {
            get
            {
                string displayName = this.Code;
                if(!String.IsNullOrEmpty(this.Name)){
                    displayName = this.Name + " [" + displayName + "]";
                }
                return displayName;
            }
        }

        // Constructor that takes no arguments:
        public Set(string code)
        {
            this.Code = code;
        }

        // Constructor that takes one argument:
        public Set(string code, string name)
        {
            this.Code = code;
            this.Name = name;
        }

        // Method that overrides the base class (System.Object) implementation.
        public override string ToString()
        {
            return this.DisplayName;
        }
    }
}
