using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interface
{
    interface IEnemyAction
    {
        void PassiveEnemyAbility(object CharacterInstance);
        void Attack1(object CharacterInstance, object TargetInstance);
        void Attack2(object CharacterInstance, object TargetInstance);
        void Attack3(object CharacterInstance, object TargetInstance);
    }
}
