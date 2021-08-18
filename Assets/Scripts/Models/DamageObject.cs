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
        public int damageGiven { get; set; }
        public damageType type { get; set; }
    }
}
