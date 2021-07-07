using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.TraitInterface
{
    interface IWarriorTraits
    {
        /*
         Here we declare all the traits expected of anything (Anyone) that can be described as a warrior (For both playable and NPC)
         */
        string BriefDescription { get; set; }
        List<string> NaturalAllies { get; set; }
        List<string> NaturalEnemies { get; set; }
        bool PassiveWarriorTraits { get; set; }
        bool LowDamageWarrior { get; set; }

        #region PassiveWarriorTraits
        void ActiveBuff();
        void ActiveDeBuff();
        #endregion
    }
}
