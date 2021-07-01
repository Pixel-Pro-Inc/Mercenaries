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

        public string ItemName { get; set; }
        public string ItemDescription { get; set; }//A Brief description of what the item does and what its worth in a desired currency
        public bool ActivationRequireMent();
        #region Abilities


        public void UniqueActiveBuff();
        public void UniqueActiveDeBuff();


        #endregion
    }
}
