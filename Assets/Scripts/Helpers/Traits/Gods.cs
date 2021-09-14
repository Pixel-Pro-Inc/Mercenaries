using Assets.Scripts.Entities.Character;
using Assets.Scripts.Models;
using Assets.Scripts.MonoBehaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Assets.Scripts.Models.Enums;

namespace Assets.Scripts.Helpers.Traits
{
    public class Gods: GameManager
    {
        //These below are objects cause some gods like Keeper use different Combat actions
        List<object> AbsoluteKeepersLivingScroll = new List<object>
        {
           new DefendObject { type=DefenceType.Shield },
           new DefendObject { type=DefenceType.MagicalResistance },
           new DefendObject { type=DefenceType.Armour },

           new BuffObject { type=buffType.OnGuard },
           new BuffObject { type=buffType.Protected }, //We use protected here cause its fired as protected in Buff()
           new BuffObject { type=buffType.Aware },
        };
        List<object> KeepersLivingScroll = new List<object>
        {
           new DefendObject { type=DefenceType.Shield },
           new DefendObject { type=DefenceType.MagicalResistance },
           new DefendObject { type=DefenceType.Armour },

           new BuffObject { type=buffType.OnGuard },
           new BuffObject { type=buffType.Protected }, //We use protected here cause its fired as protected in Buff()
           new BuffObject { type=buffType.Aware },
        };
        List<object> AbsoluteKeepersDeathNotte = new List<object>
        {
           new DebuffObject { type=debuffType.Hungry },
           new DebuffObject { type=debuffType.BrokenGaurd },
           new DebuffObject { type=debuffType.Rooted},
           new DebuffObject { type=debuffType.Freeze }
        };
        List<object> KeepersDeathNotte = new List<object>
        {
           new DebuffObject { type=debuffType.Hungry },
           new DebuffObject { type=debuffType.BrokenGaurd },
           new DebuffObject { type=debuffType.Rooted},
           new DebuffObject { type=debuffType.Freeze }
        };

        List<object> AbsoluteDevotionsLivingScroll = new List<object>
        {
           new DefendObject { type=DefenceType.Immune },

           new BuffObject { type=buffType.HealVictim },
           new BuffObject { type=buffType.Revigorate },
           new BuffObject { type=buffType.Agile },
        };
        List<object> DevotionsLivingScroll = new List<object>
        {
           new DefendObject { type=DefenceType.Immune },

           new BuffObject { type=buffType.HealVictim },
           new BuffObject { type=buffType.Revigorate }, 
           new BuffObject { type=buffType.Agile },
        };
        List<object> AbsoluteDevotionsDeathNotte = new List<object>
        {
           new AttackObject { type=AttackType.Bleed },
           new AttackObject { type=AttackType.Blight },
           new AttackObject { type=AttackType.Ignite },
           new AttackObject { type=AttackType.Curse },

           new DebuffObject { type=debuffType.Marked},
           new DebuffObject { type=debuffType.Slow},
           new DebuffObject { type=debuffType.Cold},
        };
        List<object> DevotionsDeathNotte = new List<object>
        {
           new AttackObject { type=AttackType.Bleed },
           new AttackObject { type=AttackType.Blight },
           new AttackObject { type=AttackType.Ignite },
           new AttackObject { type=AttackType.Curse },

           new DebuffObject { type=debuffType.Marked},
           new DebuffObject { type=debuffType.Slow},
           new DebuffObject { type=debuffType.Cold},
        };

        List<object> AbsoluteEdgesLivingScroll = new List<object>
        {
           new AttackObject { type=AttackType.Bleed },
           new AttackObject { type=AttackType.Blight },
           new AttackObject { type=AttackType.Ignite },
           new AttackObject { type=AttackType.Curse },

           new BuffObject { type=buffType.Chosen },
           new BuffObject { type=buffType.PolishedWeapon },
        };
        List<object> EdgesLivingScroll = new List<object>
        {
           new AttackObject { type=AttackType.Bleed },
           new AttackObject { type=AttackType.Blight },
           new AttackObject { type=AttackType.Ignite },
           new AttackObject { type=AttackType.Curse },

           new BuffObject { type=buffType.Chosen },
           new BuffObject { type=buffType.PolishedWeapon },
        };
        List<object> AbsoluteEdgesDeathNotte = new List<object>
        {
          new DebuffObject { type=debuffType.Calm },
          new DebuffObject { type=debuffType.WeakGrip },
          new DebuffObject { type=debuffType.Exiled },
          new DebuffObject { type=debuffType.Blinded },
          new DebuffObject { type=debuffType.Sleep },

          new AttackObject { type=AttackType.MagicalDamage }
        };
        List<object> EdgesDeathNotte = new List<object>
        {
          new DebuffObject { type=debuffType.Calm },
          new DebuffObject { type=debuffType.WeakGrip },
          new DebuffObject { type=debuffType.Exiled },
          new DebuffObject { type=debuffType.Blinded },
          new DebuffObject { type=debuffType.Sleep },

          new AttackObject { type=AttackType.MagicalDamage }
        };

       
        public void GodsHand(Deity deity, Persona Character)
        {
            switch (deity)
            {
                case Deity.Keeper:
                    KeepersMiracle();
                    break;
                case Deity.Devotion:
                    DevotionsMiracle();
                    break;
                case Deity.Edge:
                    EdgesMiracle();
                    break;
                default:
                    break;
            }
            if ((KeepersLivingScroll.Count==0)|| (DevotionsLivingScroll.Count == 0)|| (EdgesLivingScroll.Count == 0))
            {
                Character.GodsBlessing(Character);
                KeepersLivingScroll = AbsoluteKeepersLivingScroll;
                DevotionsLivingScroll = AbsoluteDevotionsLivingScroll;
                EdgesLivingScroll = AbsoluteEdgesLivingScroll;
            }
            else if((KeepersDeathNotte.Count == 0)|| (DevotionsDeathNotte.Count == 0)|| (EdgesDeathNotte.Count == 0))
            {
                Character.GodsAnger(Character);
                KeepersDeathNotte = AbsoluteKeepersDeathNotte;
                DevotionsDeathNotte = AbsoluteDevotionsDeathNotte;
                EdgesDeathNotte = AbsoluteEdgesDeathNotte;
            }
        }

        //I could have used a switch expression below here but i was tired of fighting
        void KeepersMiracle()
        {
            DefendObject Amy; BuffObject Mia; DebuffObject Michelle;
            foreach (var item in KeepersLivingScroll)
            {

                foreach (DefendObject DefenceAction in TeamDefence)
                {
                    if (item.GetType() == typeof(DefendObject))
                    {
                        Amy = (DefendObject)item;
                        if (Amy.type == GetDefenceType(DefenceAction))
                        {
                            KeepersLivingScroll.Remove(Amy);
                        }
                    }
                }

                foreach (BuffObject BuffAction in TeamBuffs)
                {
                    if (item.GetType() == typeof(BuffObject))
                    {
                        Mia = (BuffObject)item;
                        if (Mia.type == GetBuffType(BuffAction))
                        {
                            KeepersLivingScroll.Remove(Mia);
                        }
                    }
                }
            }
            foreach (var item in KeepersDeathNotte)
            {
                foreach (DebuffObject debuff in TeamDeBuffs) //Gets the debuffs experienced by character
                {
                    if (debuff.GetType() == typeof(DebuffObject))
                    {
                        Michelle = (DebuffObject)item;
                        if (Michelle.type == GetDebuffType(debuff))
                        {
                            KeepersDeathNotte.Remove(Michelle);
                        }
                    }
                }
            }

        }
        void DevotionsMiracle()
        {
            DefendObject Amy; BuffObject Mia; AttackObject Abel; DebuffObject Michelle;
            foreach (var item in DevotionsLivingScroll)
            {

                foreach (DefendObject DefenceAction in TeamDefence)
                {
                    if (item.GetType() == typeof(DefendObject))
                    {
                        Amy = (DefendObject)item;
                        if (Amy.type == GetDefenceType(DefenceAction))
                        {
                            DevotionsLivingScroll.Remove(Amy);
                        }
                    }
                }

                foreach (BuffObject BuffAction in TeamBuffs)
                {
                    if (item.GetType() == typeof(BuffObject))
                    {
                        Mia = (BuffObject)item;
                        if (Mia.type == GetBuffType(BuffAction))
                        {
                            DevotionsLivingScroll.Remove(Mia);
                        }
                    }
                }
            }
            foreach (var item in DevotionsDeathNotte)
            {
                foreach (DebuffObject debuff in TeamDeBuffs)
                {
                    if (item.GetType() == typeof(DebuffObject))
                    {
                        Michelle = (DebuffObject)item;
                        if (Michelle.type == GetDebuffType(debuff))
                        {
                            DevotionsDeathNotte.Remove(Michelle);
                        }
                    }
                }
                foreach (var villian in enemyCharacters) //This is to ask if somone else Attacked the character and fire, eg bleed or blight
                {
                    foreach (AttackObject AttackAction in villian.GetComponentInChildren<Persona>().GetAttack(villian.GetComponentInChildren<Persona>()))
                    {
                        if (item.GetType() == typeof(AttackObject))
                        {
                            Abel = (AttackObject)item;
                            if (Abel.type == GetAttackType(AttackAction))
                            {
                                DevotionsDeathNotte.Remove(Abel);
                            }
                        }
                    }
                }
            }
        }
        void EdgesMiracle()
        {
            BuffObject Mia; AttackObject Abel; DebuffObject Michelle;
            foreach (var item in EdgesLivingScroll)
            {

                foreach (AttackObject AttackAction in TeamAttacks)
                {
                    if (item.GetType() == typeof(AttackObject))
                    {
                        Abel = (AttackObject)item;
                        if (Abel.type == GetAttackType(AttackAction))
                        {
                            EdgesLivingScroll.Remove(Abel);
                        }
                    }
                }

                foreach (BuffObject BuffAction in TeamBuffs)
                {
                    if (item.GetType() == typeof(BuffObject))
                    {
                        Mia = (BuffObject)item;
                        if (Mia.type == GetBuffType(BuffAction))
                        {
                            EdgesLivingScroll.Remove(Mia);
                        }
                    }
                }
            }
            foreach (var item in EdgesDeathNotte)
            {

                foreach (var villian in enemyCharacters) //This is to ask if somone else Attacked the character and fire, eg bleed or blight
                {
                    foreach (AttackObject AttackAction in villian.GetComponentInChildren<Persona>().GetAttack(villian.GetComponentInChildren<Persona>()))
                    {
                        if (item.GetType() == typeof(AttackObject))
                        {
                            Abel = (AttackObject)item;
                            if (Abel.type == GetAttackType(AttackAction))
                            {
                                EdgesDeathNotte.Remove(Abel);
                            }
                        }
                    }
                }

                foreach (DebuffObject DeBuffAction in TeamDeBuffs)
                {
                    if (item.GetType() == typeof(DebuffObject))
                    {
                        Michelle = (DebuffObject)item;
                        if (Michelle.type == GetDebuffType(DeBuffAction))
                        {
                            EdgesDeathNotte.Remove(Michelle);
                        }
                    }
                }
            }
        }

        AttackType GetAttackType(AttackObject attack)
        {
            AttackType Tupac= new AttackType();
            switch (attack.type)
            {
                case AttackType.TrueDamage:
                    Tupac = AttackType.TrueDamage;
                    break;
                case AttackType.PhysicalDamage:
                    Tupac = AttackType.PhysicalDamage;
                    break;
                case AttackType.MagicalDamage:
                    Tupac = AttackType.MagicalDamage;
                    break;
                case AttackType.Drain:
                    Tupac = AttackType.Drain;
                    break;
                case AttackType.Ignite:
                    Tupac = AttackType.Ignite;
                    break;
                case AttackType.Bleed:
                    Tupac = AttackType.Bleed;
                    break;
                case AttackType.Blight:
                    Tupac = AttackType.Blight;
                    break;
                case AttackType.BalancedDamage:
                    Tupac = AttackType.BalancedDamage;
                    break;
                case AttackType.Curse:
                    Tupac = AttackType.Curse;
                    break;
                case AttackType.Feign:
                    Tupac = AttackType.Feign;
                    break;
                default:
                    break;
            }
            return Tupac;
        }
        DefenceType GetDefenceType(DefendObject defend)
        {
            DefenceType Snopp = new DefenceType();
            switch (defend.type)
            {
                case DefenceType.Armour:
                    Snopp = DefenceType.Armour;
                    break;
                case DefenceType.MagicalResistance:
                    Snopp = DefenceType.Armour;
                    break;
                case DefenceType.Shield:
                    Snopp = DefenceType.Armour;
                    break;
                case DefenceType.Purified:
                    Snopp = DefenceType.Armour;
                    break;
                case DefenceType.Block:
                    Snopp = DefenceType.Armour;
                    break;
                case DefenceType.Immune:
                    Snopp = DefenceType.Armour;
                    break;
                default:
                    break;
            }
            return Snopp;
        }
        buffType GetBuffType(BuffObject buff)
        {
            buffType Cole = new buffType();
            switch (buff.type)
            {
                case buffType.Agile:
                    Cole = buffType.Agile;
                    break;
                case buffType.PolishedWeapon:
                    Cole = buffType.PolishedWeapon;
                    break;
                case buffType.Chosen:
                    Cole = buffType.Chosen;
                    break;
                case buffType.Aware:
                    Cole = buffType.Aware;
                    break;
                case buffType.OnGuard:
                    Cole = buffType.OnGuard;
                    break;
                case buffType.Provoking:
                    Cole = buffType.Provoking;
                    break;
                case buffType.Protector:
                    Cole = buffType.Protector;
                    break;
                case buffType.Protected:
                    Cole = buffType.Protected;
                    break;
                case buffType.Revigorate:
                    Cole = buffType.Revigorate;
                    break;
                case buffType.HealVictim:
                    Cole = buffType.HealVictim;
                    break;
                case buffType.GodsBlessing:
                    Cole = buffType.GodsBlessing;
                    break;
                default:
                    break;
            }
            return Cole;
        }
        debuffType GetDebuffType(DebuffObject debuff)
        {
            debuffType Kendrick = new debuffType();
            switch (debuff.type)
            {
                case debuffType.Slow:
                    Kendrick = debuffType.Slow;
                    break;
                case debuffType.Rooted:
                    Kendrick = debuffType.Rooted;
                    break;
                case debuffType.WeakGrip:
                    Kendrick = debuffType.WeakGrip;
                    break;
                case debuffType.Exiled:
                    Kendrick = debuffType.Exiled;
                    break;
                case debuffType.Marked:
                    Kendrick = debuffType.Marked;
                    break;
                case debuffType.Calm:
                    Kendrick = debuffType.Calm;
                    break;
                case debuffType.BrokenGaurd:
                    Kendrick = debuffType.BrokenGaurd;
                    break;
                case debuffType.Burnt:
                    Kendrick = debuffType.Burnt;
                    break;
                case debuffType.Stun:
                    Kendrick = debuffType.Stun;
                    break;
                case debuffType.Freeze:
                    Kendrick = debuffType.Freeze;
                    break;
                case debuffType.Cold:
                    Kendrick = debuffType.Cold;
                    break;
                case debuffType.Blinded:
                    Kendrick = debuffType.Blinded;
                    break;
                case debuffType.Tainted:
                    Kendrick = debuffType.Tainted;
                    break;
                case debuffType.Sleep:
                    Kendrick = debuffType.Sleep;
                    break;
                case debuffType.Hungry:
                    Kendrick = debuffType.Hungry;
                    break;
                case debuffType.Healthy:
                    Kendrick = debuffType.Healthy;
                    break;
                case debuffType.UnHealthy:
                    Kendrick = debuffType.UnHealthy;
                    break;
                case debuffType.GodsAnger:
                    Kendrick = debuffType.GodsAnger;
                    break;
                default:
                    break;
            }
            return Kendrick;
        }
    }
}
