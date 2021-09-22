using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.MonoBehaviours.ReGroup
{
    class LifeSkills: TavernBar
    {
        public int FarmingLevel { get; set; }
        public int MiningLevel { get; set; }
        public int SmithingLevel { get; set; }
        public int CraftingLevel { get; set; }
        public int HunterGatheringLevel { get; set; }
    }
}
