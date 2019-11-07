using System;
using System.Collections.Generic;
using td.wapiti.domain;

namespace td.wapiti.application
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Card> cardList = new List<Card>();
            cardList.Add(new Card("Lightning Bolt"));
            cardList.Add(new Card("Lightning Bolt", new Set("M10")));
            cardList.Add(new Card("Snapcaster Mage",new Set("ISD","Innistrad")));
            foreach (var card in cardList)
            {
                Console.WriteLine(card);
            }
        }
    }
}
