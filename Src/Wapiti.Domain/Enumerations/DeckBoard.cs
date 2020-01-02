using Wapiti.Domain.Infrastructure;

namespace Wapiti.Domain.Enumerations
{
    public class DeckBoard : Enumeration
    {
        public static DeckBoard Mainboard = new DeckBoard(1,"Mainboard");
        public static DeckBoard Sideboard = new DeckBoard(2,"Sideboard");
        public DeckBoard(int id, string name) : base(id, name)
        {

        }
    }
}
