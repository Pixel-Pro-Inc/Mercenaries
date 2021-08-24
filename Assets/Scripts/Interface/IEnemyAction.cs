using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interface
{
    interface IEnemyAction
    {
        void PassiveEnemyAbility();
        void Attack1(object TargetInstance);
        void Attack2(object TargetInstance);
        void Attack3(object TargetInstance);
    }
}
