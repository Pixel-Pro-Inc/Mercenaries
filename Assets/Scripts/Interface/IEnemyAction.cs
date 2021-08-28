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
        #region  Unsused code
        /*
        void Attack1(object TargetInstance);
        void Attack2(object TargetInstance);
        void Attack3(object TargetInstance);
         */
        #endregion

        void MagicalAttacks(object TargetInstance);
        void PhysicalAttacks(object TargetInstance);
        void TrueDamageAttacks(object TargetInstance);
        void Debuffs(object TargetInstance);
        void Buff(object TargetInstance);
    }
}
