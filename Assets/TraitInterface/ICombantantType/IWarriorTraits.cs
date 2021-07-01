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
        public string BriefDescription { get; set; }
        public List<string> NaturalAllies { get; set; }
        public List<string> NaturalEnemies { get; set; }
        public bool PassiveWarriorTraits { get; set; }

        #region PassiveWarriorTraits
        public void ActiveBuff();
        public void ActiveDeBuff();

        #endregion
    }
}
