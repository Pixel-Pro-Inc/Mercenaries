using System;
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

        bool Relic { get; set; } // this will be set true if relic and so will be nonconsumbalable 

        void Equip();
        void Remove();
        bool ActivationRequireMent();
        #region Abilities


        void UniqueActiveBuff();
        void UniqueActiveDeBuff();


        #endregion
    }
}
