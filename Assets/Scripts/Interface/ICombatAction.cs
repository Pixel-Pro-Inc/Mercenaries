using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interface
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
        void UniqueSkill(object CharacterInstance, object TargetInstance);
        void UniqueActiveBuff(object CharacterInstance, object TargetInstance);
        void UniqueActiveDeBuff(object CharacterInstance, object TargetInstance);

        #endregion

        #region Attack

        void PhysicalDamage(object CharacterInstance, object TargetInstance);
        void PhysicalDamage(object CharacterInstance, object TargetInstance, DamageObject damageObject);
        void MagicalDamage(object CharacterInstance, object TargetInstance);
        void MagicalDamage(object CharacterInstance, object TargetInstance, int amount); //This was given amont because in a few cards the amount actually changes by an specfic number
        void TrueDamage(object CharacterInstance, object TargetInstance, DamageObject DamageObj);
        void Drain(object CharacterInstance, object TargetInstance);
        void Ignite(object CharacterInstance, object TargetInstance, int amount);// Ignite and blight have amount cause the use MAical damage
        void Bleed(object CharacterInstance, object TargetInstance);
        void Bleed(object CharacterInstance, object TargetInstance, DamageObject damageObject);
        void Blight(object CharacterInstance, object TargetInstance,int amountOfRounds, int amountOfDamage);
        void BalancedDamage(object CharacterInstance, object TargetInstance);
        void Curse(object CharacterInstance, object TargetInstance);
        bool Feign(object CharacterInstance, object TargetInstance);

        #endregion

        #region Buff

        void Agile(object CharacterInstance, bool state);
        void PolishWeapon(object CharacterInstance);
        void Chosen(object CharacterInstance);
        bool Aware(object CharacterInstance);
        void OnGuard(object CharacterInstance, object TargetInstance);//only works to be on guard to a specific person
        void Provoking(object CharacterInstance); //this takes the character and uses the protector() method and its list of allies as targets
        void Protector(object OwnerInstance, object TargetInstance); //this asks like a contract. The person who will protectand the protected. eg Protector( instance,Mister Froggo)
        object Protected(object TargetInstance);//If hit, protector will take damage instead. but this isn't really given how damagegiven works. needs to be changed
        void Revigorate(object TargetInstance);
        void HealVictim(object CharacterInstance, object TargetInstance); //this works on anyone, not just allies
        void HealVictim( object TargetInstance, int damageobj); //another overload
        void GodsBlessing(object CharacterInstance);// I left it as allies so that its easier to deal with but really we dont need it as a parameter

        #endregion
    }
}
