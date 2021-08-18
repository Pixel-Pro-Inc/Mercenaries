using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assets.Scripts.Models.Enums;

namespace Assets.Scripts.Models
{
    public class RoundInfo
    {
        public static bool GameInSession;
        public static bool RoundDone;
        public static int RoundsPassed;

        public WhoseInControl inControl;
    }
}
