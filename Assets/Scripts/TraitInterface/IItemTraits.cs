﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.TraitInterface
{
    interface IItemTraits
    {
        /*
         Here we declare all the traits expected of anything (Anyone) that can be described as a character (For both playable and NPC)
         */

        string ItemName { get; set; }
        string ItemDescription { get; set; }//A Brief description of what the item does and what its worth in a desired currency
        int Owner { get; set; }

        bool Relic { get; set; } // this will be set true if relic and so will be nonconsumbalable 
        bool BeingUsed { get; set; }

        void Equip();
        void Remove();
        bool ActivationRequireMent(object CharacterInstance); //Returns if you have all the necessary things to activate the item and if true it equips it

        #region Abilities


        void UniqueActiveBuff();
        void UniqueActiveDeBuff();


        #endregion
    }
}
