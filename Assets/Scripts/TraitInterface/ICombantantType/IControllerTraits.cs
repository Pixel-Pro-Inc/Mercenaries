using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.TraitInterface.CombantantType
{
    interface IControllerTraits
    {
        /*
         Here we declare all the traits expected of anything (Anyone) that can be described as a Debuffers (For both playable and NPC)
         */
        string BriefDescription { get; set; }
        List<string> NaturalAllies { get; set; }
        List<string> NaturalEnemies { get; set; }
        public bool Foe { get; set; }
        bool PassiveControllerTraits { get; set; }
        bool LowDamageController { get; set; }

        #region PassiveControllerTraits
        void ActiveBuff();
        void ActiveDeBuff();

        #endregion
    }
}
