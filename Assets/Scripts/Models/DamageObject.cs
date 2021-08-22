using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assets.Scripts.Models.Enums;

namespace Assets.Scripts.Models
{
    public class DamageObject
    {
        public AttackType type { get; set; }
        public enum DamageVersion
        {
            True, Physical, Magical, Balanced
        }
        public int DamageValue { get; set; } 
        public DamageVersion DamageTrait;
    }
}
