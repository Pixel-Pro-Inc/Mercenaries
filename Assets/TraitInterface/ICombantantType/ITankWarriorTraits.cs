using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.TraitInterface.CombantantType
{
    interface ITankWarriorTraits
    {
        /*
         Here we declare all the traits expected of anything (Anyone) that can be described as a Tank Warrior (For both playable and NPC)
         */
        public string BriefDescription { get; set; }
        public List<string> NaturalAllies { get; set; }
        public List<string> NaturalEnemies { get; set; }
        public bool PassiveTankTraits { get; set; }

        #region PassiveTankTraits
        public void ActiveBuff();
        public void ActiveDeBuff();

        #endregion
    }
}
