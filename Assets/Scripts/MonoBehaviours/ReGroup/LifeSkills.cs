using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.MonoBehaviours.ReGroup
{
    public class LifeSkills
    {
        //Even if several instances of LifeSkills are created, eg for different Teams and bands, the Owner of the game will have these translate into all of them
        public static int FarmingLevel { get; set; }
        public static int MiningLevel { get; set; }
        public static int SmithingLevel { get; set; }
        public static int CraftingLevel { get; set; }
        public static int HunterGatheringLevel { get; set; }
    }
}
