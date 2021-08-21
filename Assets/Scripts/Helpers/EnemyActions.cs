using Assets.Scripts.Entities.Character;
using Assets.Scripts.Interface;
using System.Timers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.MonoBehaviours;
using Assets.Scripts.Models;

namespace Assets.Scripts.Helpers
{
    class EnemyActions: Persona,IEnemyAction
    {
        MasterCharacterList EnemyNames;
        public void PassiveEnemyAbility(object CharacterInstance)
        {
            Persona Character= (Persona)CharacterInstance;
            switch (EnemyNames)
            {
                case MasterCharacterList.HammerHead:

                    while (Character.Health <= (int)(Character.Life * 0.25))
                    {
                        int fordo = RoundInfo.RoundsPassed;
                        Character.PowerBuffPercent   = 2;
                        if (RoundInfo.RoundsPassed>fordo)
                        {
                            Character.PolishWeapon(Character);
                        }
                    }
                    while ((Character.Health <= (int)(Character.Life * 0.5)) && (Character.Health > (int)(Character.Life * 0.25)))
                    {
                        //here im thinking it checks if the stun in the list of debuffs and if true, with a 50% chance it will reverse the effect. But im not sure how yewo intends to reverse effects
                    }
                    while (Character.Health >(int)(Character.Life * 0.5))
                    {
                        Character.AgileBUffPercent = 0.5;
                        Character.Agile(Character, true);
                    }
                    break;
                case MasterCharacterList.GreatWhite:
                    break;
                case MasterCharacterList.SpiderCrustacean:
                    break;
                case MasterCharacterList.NecroBoar:
                    break;
                case MasterCharacterList.ElderStag:
                    break;
                case MasterCharacterList.DevilBird:
                    break;
                case MasterCharacterList.DragonSloth:
                    break;
                default:
                    break;
            }
        }

        public void Attack1(object CharacterInstance, object TargetInstance)
        {
            Persona Character = (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            DamageObject damageobj = new DamageObject();

            switch (EnemyNames)
            {
                case MasterCharacterList.HammerHead:
                    foreach (object item in Character.Enemies)
                    {
                        PhysicalDamage(Character, item);
                        Tainted(Character, item);
                    }
                    break;
                case MasterCharacterList.GreatWhite:
                    break;
                case MasterCharacterList.SpiderCrustacean:
                    break;
                case MasterCharacterList.NecroBoar:
                    break;
                case MasterCharacterList.ElderStag:
                    break;
                case MasterCharacterList.DevilBird:
                    break;
                case MasterCharacterList.DragonSloth:
                    break;
                default:
                    break;
            }
        }
        public void Attack2(object CharacterInstance, object TargetInstance)
        {
            Persona Character = (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            DamageObject damageobj = new DamageObject();

            switch (EnemyNames)
            {
                case MasterCharacterList.HammerHead:
                    int speedCount = 0;
                    foreach (object item in Character.Enemies)
                    {
                        Character.Stun(Character, item);
                        Persona hero = (Persona)item;
                        foreach (DebuffObject debuff in hero.GetDebuffs())
                        {
                            if (debuff.type==Enums.debuffType.Stun)
                            {
                                speedCount++;
                                break;// so it stops checking for more stun Debuffs
                            }
                        }
                    }
                    Character.Speed += (int)(Character.Speed * 0.1 * speedCount);

                    break;
                case MasterCharacterList.GreatWhite:
                    break;
                case MasterCharacterList.SpiderCrustacean:
                    break;
                case MasterCharacterList.NecroBoar:
                    break;
                case MasterCharacterList.ElderStag:
                    break;
                case MasterCharacterList.DevilBird:
                    break;
                case MasterCharacterList.DragonSloth:
                    break;
                default:
                    break;
            }
        }
        public void Attack3(object CharacterInstance, object TargetInstance)
        {
            Persona Character = (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            DamageObject damageobj = new DamageObject();
            switch (EnemyNames)
            {
                case MasterCharacterList.HammerHead:
                    int theDama = Character.DamageGiven();
                    damageobj.DamageValue = (int)(theDama * 0.3);
                    foreach (object item in Character.Enemies)
                    {
                        Character.TrueDamage(Character, item, damageobj);
                        damageobj.DamageValue = (int)(theDama * 0.35);
                        Character.Bleed(Character, item, damageobj);
                    }
                    
                    break;
                case MasterCharacterList.GreatWhite:
                    break;
                case MasterCharacterList.SpiderCrustacean:
                    break;
                case MasterCharacterList.NecroBoar:
                    break;
                case MasterCharacterList.ElderStag:
                    break;
                case MasterCharacterList.DevilBird:
                    break;
                case MasterCharacterList.DragonSloth:
                    break;
                default:
                    break;
            }
        }
    }
}
