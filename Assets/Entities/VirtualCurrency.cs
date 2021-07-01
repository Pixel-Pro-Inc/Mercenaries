using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Entities
{
    class VirtualCurrency
    {
        //This is the class that defines all the properties of the virtual currency usedin the game. Sometimes RPG games can consist of many types of tradeable 
        //items that are somewhat a form of virtual currency eg, coins, gems, Mystical Bones, gold. They cant be items cause they are in larger
        //numbers and can be traded.
        #region Trading tender

        //Here are the actual currencies
        public class Gems
        {
            public int Currentgems { get; set; }
            public int Totalgemsaccumulated { get; set; }
        }

        public class Coins
        {
            public int CurrentCoins { get; set; }
            public int TotalCoins { get; set; }
        }
        public class MysticalBones
        {
            public int CurrentMysticalBones { get; set; }
            public int TotalMysticalBones { get; set; }
        }

        #endregion
        #region Exchange Rates

        //here are the exchange rates for each currency. Im declaring them virtual cause I believe different places might have their exchange rates at 
        //different values


        #endregion

    }
}
