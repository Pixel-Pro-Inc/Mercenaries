﻿using Assets.TraitInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Entities
{
    class Items: Cards
    {
        //Here we will have items of all sorts.
        //Since it already inherts from cards it has passive traits already declared as well as cost.
        //So here One will simple list a bunch of items and  theie unique abilites or prioties or special overides


        //Here you might want to declare the passivetraits/methods as well

        public class Nth_Metal : Items, IItemTraits //this is how all items will be defined
        {
            public static Nth_Metal instance { get; set; }
            public Nth_Metal()
            {
                instance = this;
            }
            //Nth_Metal Nth = new Nth_Metal(); This is supposed to be aa geberal instance, not a specific one
            public string ItemName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public string ItemDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public bool ActivationRequireMent()
            {
                throw new NotImplementedException();
                instance.PassiveTraitsState = true;
            }

            public void UniqueActiveBuff()
            {
                throw new NotImplementedException();
            }

            public void UniqueActiveDeBuff()
            {
                throw new NotImplementedException();
            }
        }


    }
}
