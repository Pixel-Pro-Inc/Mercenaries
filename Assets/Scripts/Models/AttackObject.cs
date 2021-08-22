using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assets.Scripts.Models.Enums;

namespace Assets.Scripts.Models
{
    public class AttackObject
    {
        public AttackType type { get; set; }
        public double amount { get; set; }
        public bool state { get; set; }
        public int roundsActive { get; set; }
        public int lifeTime { get; set; }
        public object Victim { get; set; }
    }
}
