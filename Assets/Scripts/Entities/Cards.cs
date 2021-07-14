using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Entities
{
    //this is the class that defines everything that is a card. Which means all cards must inhert from this class. It will be up to the 
    //situation on whether or not those objects are implemented.
    public class Cards
    {
        internal bool PassiveTraitsState { get; set; }
        internal float Cost { get; set; }
        internal int CardId { get; set; }
        internal string CardType { get; set; }//This describes what kind of card it is eg, Item, character, minion        
    }
}
