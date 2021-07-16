using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.TraitInterface
{
    interface ICombatAction
    {

        /*
         So here how they work. When one wants to attack someone the line will be 'Instance.Drain( enemyInstance)'. the value that will be returnd is
        false. But within the method, for that enemyinstance it will be set true. So there will be a logic that divides whether or not the method will 
        affect yourself  or someone else.


         */
        #region Attack

        bool PhysicalDamage(object CharacterInstance);
        bool MagicalDamage(object CharacterInstance);
        bool TrueDamage(object CharacterInstance);
        bool Drain(object CharacterInstance);
        bool Ignite(object CharacterInstance);
        bool Bleed(object CharacterInstance);
        bool Blight(object CharacterInstance);
        bool BalancedDamage(object CharacterInstance);
        bool Curse(object CharacterInstance);
        bool Feign(object CharacterInstance);

        #endregion
        #region Defend
        bool PutArmour(object CharacterInstance);
        bool IncreaseMagicalResistance(object CharacterInstance);
        bool ShieldUp(object CharacterInstance);
        bool Purified(object CharacterInstance);
        bool Block(object CharacterInstance);
        bool Immune(object CharacterInstance);

        #endregion

        #region Buff

        bool Agile(object CharacterInstance);
        bool PolishWeapon(object CharacterInstance);
        bool Chosen(object CharacterInstance);
        bool Aware(object CharacterInstance);
        bool OnGuard(object CharacterInstance);
        bool Provoking(object CharacterInstance); //this will be difficult
        bool Protector(object OwnerInstance, object CharacterInstance);
        bool Protected(object CharacterInstance);//If hit, protector will take damage instead
        bool Revigorate(object CharacterInstance);
        bool GodsBlessing(object CharacterInstance);

        #endregion
        #region Debuff

        bool Slow(object CharacterInstance);
        bool Rooted(object CharacterInstance);
        bool WeakGrip(object CharacterInstance);
        bool Exiled(object CharacterInstance);
        bool Marked(object CharacterInstance);
        bool Calm(object CharacterInstance);
        bool BrokenGuard(object CharacterInstance);
        bool Burnt(object CharacterInstance);
        bool Stun(object CharacterInstance);
        bool Freeze(object CharacterInstance);//stuns after cold applied twice
        bool Cold(object CharacterInstance);
        bool Blinded(object CharacterInstance);
        bool Tainted(object CharacterInstance);
        bool Sleep(object CharacterInstance);
        bool Hungry(object CharacterInstance);
        bool Unhealthy(object CharacterInstance);
        bool GodsAnger(object CharacterInstance);
        #endregion

    }
}
