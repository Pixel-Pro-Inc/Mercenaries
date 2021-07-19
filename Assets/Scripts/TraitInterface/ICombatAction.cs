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
        #region Unqiue Action

        /*
         Right now these are set to only work on the instance its being used by. But we might need it to be declareed as such:
        UniqueSkill(object CharacterInstance, List<object> CHaracteraffectedInstances);
         */
        public void UniqueSkill(object CharacterInstance, object TargetInstance);
        void UniqueActiveBuff(object CharacterInstance, object TargetInstance);
        void UniqueActiveDeBuff(object CharacterInstance, object TargetInstance);

        #endregion

        #region Attack

        bool PhysicalDamage(object CharacterInstance, object TargetInstance);
        bool MagicalDamage(object CharacterInstance, object TargetInstance);
        bool TrueDamage(object CharacterInstance, object TargetInstance);
        bool Drain(object CharacterInstance, object TargetInstance);
        bool Ignite(object CharacterInstance, object TargetInstance);
        bool Bleed(object CharacterInstance, object TargetInstance);
        bool Blight(object CharacterInstance, object TargetInstance);
        bool BalancedDamage(object CharacterInstance, object TargetInstance);
        bool Curse(object CharacterInstance, object TargetInstance);
        bool Feign(object CharacterInstance, object TargetInstance);

        #endregion
        #region Defend
        bool PutArmour(object CharacterInstance, object TargetInstance);
        bool IncreaseMagicalResistance(object CharacterInstance, object TargetInstance);
        bool ShieldUp(object CharacterInstance, object TargetInstance);
        bool Purified(object CharacterInstance, object TargetInstance);
        bool Block(object CharacterInstance, object TargetInstance);
        bool Immune(object CharacterInstance, object TargetInstance);

        #endregion

        #region Buff

        bool Agile(object CharacterInstance);
        bool PolishWeapon();
        bool Chosen();
        bool Aware();
        bool OnGuard(object CharacterInstance, object TargetInstance);
        bool Provoking(object CharacterInstance, object TargetInstance); //this will be difficult
        bool Protector(object OwnerInstance, object TargetInstance); //this asks like a contract. The person who will protectand the protected. eg Protector( instance,Mister Froggo)
        object Protected(object TargetInstance);//If hit, protector will take damage instead. but this isn't really given how damagegiven works. needs to be changed
        bool Revigorate(object CharacterInstance, object TargetInstance);
        void HealVictim(object TargetInstance); //this works on anyone, not just allies
        bool GodsBlessing(object CharacterInstance, List<string> Allies);// I left it as allies so that its easier to deal with

        #endregion
        #region Debuff

        bool Slow(object CharacterInstance, object TargetInstance);
        bool Rooted(object CharacterInstance, object TargetInstance);
        bool WeakGrip(object CharacterInstance, object TargetInstance);
        bool Exiled(object CharacterInstance, object TargetInstance);
        bool Marked(object CharacterInstance, object TargetInstance);
        bool Calm(object CharacterInstance, object TargetInstance);
        bool BrokenGuard(object CharacterInstance, object TargetInstance);
        bool Burnt(object CharacterInstance, object TargetInstance);
        bool Stun(object CharacterInstance, object TargetInstance);
        bool Freeze(object CharacterInstance, object TargetInstance);//stuns after cold applied twice
        bool Cold(object CharacterInstance, object TargetInstance);
        bool Blinded(object CharacterInstance, object TargetInstance);
        bool Tainted(object CharacterInstance, object TargetInstance);
        bool Sleep(object CharacterInstance, object TargetInstance);
        bool Hungry(object CharacterInstance, object TargetInstance);
        bool Unhealthy(object CharacterInstance, object TargetInstance);
        bool GodsAnger(object CharacterInstance, List<string> Allies);
        #endregion

    }
}
