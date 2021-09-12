using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assets.Scripts.Models.Enums;

namespace Assets.Scripts.Models
{
    public class DefendObject
    {
        public DefenceType type { get; set; }
        public double amount { get; set; }
        public bool state { get; set; }
    }
}
