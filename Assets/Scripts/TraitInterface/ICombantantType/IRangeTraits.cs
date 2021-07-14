using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.TraitInterface.CombantantType
{
    interface IRangeTraits
    {
        /*
         Here we declare all the traits expected of anything (Anyone) that can be described as a Range warrior (For both playable and NPC)
         */
        string BriefDescription { get; set; }
        List<string> NaturalAllies { get; set; }
        List<string> NaturalEnemies { get; set; }
        bool Foe { get; set; }
        bool PassiveRangeTraits { get; set; }
        bool LowDamageRange { get; set; }

        #region PassiveRangeTraits
        void ActiveBuff();
        void ActiveDeBuff();

        #endregion
    }
}
