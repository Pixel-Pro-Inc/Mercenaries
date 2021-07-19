using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.TraitInterface.CombantantType
{
    interface IAssasinTraits
    {
        /*
         Here we declare all the traits expected of anything (Anyone) that can be described as a Archer (For both playable and NPC)
         */
        string BriefDescription { get; set; }
        List<string> NaturalAllies { get; set; }
        List<string> NaturalEnemies { get; set; }
        bool Foe { get; set; }
        bool PassiveAssasinTraits { get; set; }
        bool LowDamageAssasin { get; set; }

        #region PassiveAssasinTraits
        void ActiveBuff();
        void ActiveDeBuff();

        #endregion
    }
}
