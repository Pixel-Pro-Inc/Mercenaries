using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.TraitInterface.CombantantType
{
    interface IMageTraits
    {
        /*
         Here we declare all the traits expected of anything (Anyone) that can be described as a Mage (For both playable and NPC)
         */
        string BriefDescription { get; set; }
        List<string> NaturalAllies { get; set; }
        List<string> NaturalEnemies { get; set; }
        public bool Foe { get; set; }
        bool PassiveMageTraits { get; set; }
        bool LowDamageMage { get; set; }
        bool SupportMage { get; set; }

        #region PassiveMageTraits
        void ActiveBuff();
        void ActiveDeBuff();

        #endregion
    }
}
