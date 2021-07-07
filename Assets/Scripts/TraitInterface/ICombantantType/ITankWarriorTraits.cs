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
        string BriefDescription { get; set; }
        List<string> NaturalAllies { get; set; }
        List<string> NaturalEnemies { get; set; }
        bool PassiveTankTraits { get; set; }
        bool LowDamageTankWarrior { get; set; }

        #region PassiveTankTraits
        void ActiveBuff();
        void ActiveDeBuff();

        #endregion
    }
}
