﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.TraitInterface.CombantantType
{
    interface IArcherTraits
    {
        /*
         Here we declare all the traits expected of anything (Anyone) that can be described as a Archer (For both playable and NPC)
         */
        string BriefDescription { get; set; }
        List<string> NaturalAllies { get; set; }
        List<string> NaturalEnemies { get; set; }
        bool PassiveArcherTraits { get; set; }
        bool LowDamageArcher { get; set; }

        #region PassiveArcherTraits
        void ActiveBuff();
        void ActiveDeBuff();

        #endregion
    }
}
