using Assets.Scripts.Entities.Character;
using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assets.Scripts.Models.Enums;

namespace Assets.Scripts.Helpers
{
    public class Debuff
    {
        public void CreateDebuff(object TargetInstance, double debuffPercent, debuffType type, int lifeTime)
        {
            DebuffObject debuffObject = new DebuffObject()
            {
                state = true,
                type = type,
                amount = debuffPercent,
                lifeTime = lifeTime,
                roundsActive = 0
            };

            ((Persona)TargetInstance).AddDebuff(debuffObject);
        }
    }
}
