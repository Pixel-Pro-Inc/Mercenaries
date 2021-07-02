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
            private bool sessionEnd;// this is a placeholder for when one finishes a game and the acquired currencies need to be added

            public int Currentgems { get; set; }
            public int AmountofGemsSelected { get; set; }
            public int gemsAcquired { get; set; }
            public int Totalgemsaccumulated { get; set; }

            void AddingAcquiredGems()
            {
                if (sessionEnd == true) { Currentgems += gemsAcquired; }
            }
        }

        public class Coins
        {
            private bool sessionEnd;// this is a placeholder for when one finishes a game and the acquired currencies need to be added
            public int CurrentCoins { get; set; }
            public int AmountofCoinsSelected { get; set; }
            public int CoinsAcquired { get; set; }
            public int TotalCoins { get; set; }
            void AddingAcquiredGems()
            {
                if (sessionEnd == true) { CurrentCoins += CoinsAcquired; }
            }
        }
        public class MysticalBones
        {
            private bool sessionEnd;// this is a placeholder for when one finishes a game and the acquired currencies need to be added
            public int CurrentMysticalBones { get; set; }
            public int AmountofBonesSelected { get; set; }
            public int BonesAcquired { get; set; }
            public int TotalMysticalBones { get; set; }
            void AddingAcquiredGems()
            {
                if (sessionEnd == true) { CurrentMysticalBones += BonesAcquired; }
            }
        }

        #endregion
        #region Exchange Rates

        //here are the exchange rates for each currency. Im declaring them virtual cause I believe different places might have their exchange rates at 
        //different values
        public void GemsToCoins()
        {
            bool ChangeGemsToCoins;//This will be set true if one wants to change Gems to coins
            bool ChangeCoinsToGems;//This will be set true if one wants to change Coins to Gems


            Gems g = new Gems();
            Coins c = new Coins();

            int GemsInHand = g.Currentgems;
            int amountG = g.AmountofGemsSelected;//Here we might need preset values of exchange so a player might have only % options to choose from
            int resultinGems = g.gemsAcquired;

            int CoinsInHand = c.CurrentCoins;
            int amountC = c.AmountofCoinsSelected;//Here we might need preset values of exchange so a player might have only % options to choose from
            int resultinCoins = c.CoinsAcquired;

            double exRate = 1.53;
            double exValueCoins = amountG * exRate;//this is the value you get if you exchange gems to coins
            double exValueGems = amountC/exRate;//this is the value you get if you exchange coins to gems

            // This is the logic for the exchange in currency to Coins
            if (GemsInHand>(exValueCoins)&&exRate!=0&&(ChangeGemsToCoins=true)) 
            {
                GemsInHand -= amountG;
                resultinCoins += (int)exValueCoins;
                //SavedData+=GemsInHand, resultinCoins;
            }
            else if (exRate==0)
            {
                throw new DivideByZeroException("Exchange rate cannot be Zero");
            }

            // This is the logic for the exchange in currency to Gems
            if (CoinsInHand > (exValueGems)&&exRate!=0&&(ChangeCoinsToGems=true)) 
            {
                CoinsInHand -= amountC;
                resultinGems += (int)exValueGems;
                //SavedData+=GemsInHand, resultinCoins;
            }
            else if (exRate == 0)
            {
                throw new DivideByZeroException("Exchange rate cannot be Zero");
            }

        }
        public void CoinsToBones()
        {

        }
        public void BonesToGems()
        {

        }

        #endregion

    }
}
