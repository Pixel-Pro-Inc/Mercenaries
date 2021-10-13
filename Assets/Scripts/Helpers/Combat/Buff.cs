
using Assets.Scripts.Entities.Character;
using Assets.Scripts.Models;
using Assets.Scripts.MonoBehaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using static Assets.Scripts.Models.Enums;

namespace Assets.Scripts.Helpers
{
    public class Buff
    {
        public void Agile(object CharacterInstance, bool state)
        {
            Persona Character = (Persona)CharacterInstance;
            int agileCache = 0;
            agileCache = (int)(Character.dodge * Character.AgileBUffPercent);
            Character.dodge += agileCache;
            agileCache = -agileCache;
            double buffamout = Character.AgileBUffPercent;
            BuffObject buffObject = null;
            buffObject = new BuffObject()
            {
                state = state,
                type = buffType.Agile,
                amount = buffamout
            };
            Character.AddBuff(buffObject);
            if (Character.Foe == false)
            {
                GameManager.Instance.TeamBuffs.Add(buffObject);
            }

            Timer BuffTimer = new Timer();
            BuffTimer.Elapsed += new ElapsedEventHandler(AgileWait);
            // Set it to go off every one seconds
            BuffTimer.Interval = 1000;
            // And start it        
            BuffTimer.Enabled = true;
            void AgileWait(object source2, ElapsedEventArgs e)
            {
                if (RoundInfo.RoundDone == true)
                {
                    Character.dodge += agileCache;
                    BuffTimer.Close();
                }
            }
           
        }
        public void PolishWeapon(object CharacterInstance)
        {
            Persona Character = (Persona)CharacterInstance;
            bool polishWeapon = true;
            BuffObject buffObject = null;
            buffObject = new BuffObject()
            {
                state = polishWeapon,
                type = buffType.PolishedWeapon,
            };
            Character.AddBuff(buffObject);
            if (Character.Foe == false)
            {
                GameManager.Instance.TeamBuffs.Add(buffObject);
            }

            Timer BuffTimer = new Timer();
            BuffTimer.Elapsed += new ElapsedEventHandler(PolishWait);
            // Set it to go off every one seconds
            BuffTimer.Interval = 1000;
            // And start it        
            BuffTimer.Enabled = true;
            void PolishWait(object source2, ElapsedEventArgs e)
            {
                if (RoundInfo.RoundDone == true)
                {
                    polishWeapon = false;
                    BuffTimer.Close();
                }
            }
        }
        public void Chosen(object CharacterInstance)
        {
            Persona Character = (Persona)CharacterInstance;
            bool chosen=true;
            BuffObject buffObject = null;
            buffObject = new BuffObject()
            {
                state = chosen,
                type = buffType.Chosen,
            };
            Character.AddBuff(buffObject);
            if (Character.Foe == false)
            {
                GameManager.Instance.TeamBuffs.Add(buffObject);
            }

            Timer BuffTimer = new Timer();
            BuffTimer.Elapsed += new ElapsedEventHandler(ChosenWait);
            // Set it to go off every one seconds
            BuffTimer.Interval = 1000;
            // And start it        
            BuffTimer.Enabled = true;
            void ChosenWait(object source2, ElapsedEventArgs e)
            {
                if (RoundInfo.RoundDone == true)
                {
                    chosen = false;
                    BuffTimer.Close();
                }
            }

            EffectType effectType = EffectType.Chosen;//Ranged?

            GameManager.Instance.InstantiateEffect(effectType, ((Persona)CharacterInstance).characterBehaviour);

        }
        public bool Aware(object CharacterInstance)
        {
            Persona Character = (Persona)CharacterInstance;
            bool Aware=true;
            BuffObject buffObject = null;
            buffObject = new BuffObject()
            {
                state = Aware,
                type = buffType.Aware,
            };
            Character.AddBuff(buffObject);
            if (Character.Foe == false)
            {
                GameManager.Instance.TeamBuffs.Add(buffObject);
            }

            Timer BuffTimer = new Timer();
            BuffTimer.Elapsed += new ElapsedEventHandler(AwareWait);
            // Set it to go off every one seconds
            BuffTimer.Interval = 1000;
            // And start it        
            BuffTimer.Enabled = true;
            void AwareWait(object source2, ElapsedEventArgs e)
            {
                if (RoundInfo.RoundDone == true)
                {
                    Aware= false;
                    BuffTimer.Close();
                }
            }

            return Aware;
        }
        public void OnGuard(object CharacterInstance, object TargetInstance)
        {
            int standbyhealth = 0;
            int storedhealth = 0;
            int count = 0;
            bool onGuard = true;

            Persona Character = (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            int damage1 = 0;

            BuffObject buffObject = null;
            buffObject = new BuffObject()
            {
                state = onGuard,
                type = buffType.OnGuard,
            };
            Character.AddBuff(buffObject);
            if (Character.Foe == false)
            {
                GameManager.Instance.TeamBuffs.Add(buffObject);
            }

            Timer BuffTimer = new Timer();
            BuffTimer.Elapsed += new ElapsedEventHandler(OnGuardWait);
            // Set it to go off every one seconds
            BuffTimer.Interval = 1000;
            // And start it        
            BuffTimer.Enabled = true;
            void OnGuardWait(object source2, ElapsedEventArgs e)
            {
                while (RoundInfo.RoundDone == false)
                {
                    standbyhealth = Character.Health;
                }
                if (count == 0)//this is to store the initial health
                {
                    storedhealth = standbyhealth;
                    count++;
                }
                else
                {
                    if ((storedhealth != standbyhealth) && (RoundInfo.RoundDone = true)) //if the health changes and the round finished
                    {
                        DamageObject sayless = new DamageObject();
                        sayless.DamageValue = damage1;
                        Character.PhysicalDamage(Character, Target, sayless); //This is to attack the person who hit him
                        count = 0;
                    }

                }
                if (RoundInfo.RoundDone == true)
                {
                    onGuard = false;
                    BuffTimer.Close();
                }
            }
        }
        public void Provoking(object CharacterInstance)
        {
            Persona Character = (Persona)CharacterInstance;
            bool Provoke = true;
            BuffObject buffObject = null;
            buffObject = new BuffObject()
            {
                state = Provoke,
                type = buffType.Provoking,
            };
            Character.AddBuff(buffObject);
            if (Character.Foe == false)
            {
                GameManager.Instance.TeamBuffs.Add(buffObject);
            }

            object scapegoat = Character;
            scapegoat = Character.Allies[UnityEngine.Random.Range(0, Character.Allies.Count)];
            Random r = new Random();
            double chanceDa = r.Next(1, 101);
            if (chanceDa <= Character.ProvokingBuffPercent)
            {
                Protector(CharacterInstance, scapegoat);
            }

            Timer BuffTimer = new Timer();
            BuffTimer.Elapsed += new ElapsedEventHandler(ProvokeWait);
            // Set it to go off every one seconds
            BuffTimer.Interval = 1000;
            // And start it        
            BuffTimer.Enabled = true;
            void ProvokeWait(object source2, ElapsedEventArgs e)
            {
                if (RoundInfo.RoundDone == true)
                {
                    Provoke = false;
                    BuffTimer.Close();
                }
            }
        }
        public void Protector(object OwnerInstance, object TargetInstance)//i am honestly debating on whether Protector is even a Buff especially since its called by Provoking as well
        {

            Persona Character = (Persona)OwnerInstance;
            Persona Target = (Persona)TargetInstance;

            Target.ProtectionSponser = Character;
            /*
             bool protector = true;
            BuffObject buffObject = null;
            buffObject = new BuffObject()
            {
                state = protector,
                type = buffType.Protector,
            };
            Character.AddBuff(buffObject);

             */

            //This here below is so that the target can get the buffobject protected and not everytime the Protected method is called
            bool protectoed = true;
            BuffObject buffObject = null;
            buffObject = new BuffObject()
            {
                state = protectoed,
                type = buffType.Protected,
            };
            Target.AddBuff(buffObject);
            if (Character.Foe == false)
            {
                GameManager.Instance.TeamBuffs.Add(buffObject);
            }

            Timer BuffTimer = new Timer();
            BuffTimer.Elapsed += new ElapsedEventHandler(protectorWait);
            // Set it to go off every one seconds
            BuffTimer.Interval = 1000;
            // And start it        
            BuffTimer.Enabled = true;
            void protectorWait(object source2, ElapsedEventArgs e)
            {
                if (RoundInfo.RoundDone == true)
                {
                    // protector = false;
                    protectoed = false;
                    Target.ProtectionSponser = null;
                    BuffTimer.Close();
                }
            }
            
        }
        public object Protected(object TargetInstance)// this is to return the protector
        {
            Persona Target = (Persona)TargetInstance;
            object sponser = Target;
            sponser = Target.ProtectionSponser;

            //This here below was removed cause it is already called in Protector so that whenever this method is called there is no issue of unnecessary new objects
            /*
              bool protectoed= true;
            BuffObject buffObject = null;
            buffObject = new BuffObject()
            {
                state = protectoed,
                type = buffType.Protected,
            };
            Target.AddBuff(buffObject);
             */


            Timer BuffTimer = new Timer();
            BuffTimer.Elapsed += new ElapsedEventHandler(protectoedWait);
            // Set it to go off every one seconds
            BuffTimer.Interval = 1000;
            // And start it        
            BuffTimer.Enabled = true;
            void protectoedWait(object source2, ElapsedEventArgs e)
            {
                if (RoundInfo.RoundDone == true)
                {
                    Target.ProtectionSponser = null;
                    BuffTimer.Close();
                }
            }
            return sponser;
        }
        public void Revigorate(object TargetInstance)// i gave it a Buffobject for teamBuff but its is NOT SUPPOSED to be added to the character bufflist
        {
            Persona Target = (Persona)TargetInstance;
            Target.RemoveDebuffEffects = true;

            BuffObject buffObject = null;
            buffObject = new BuffObject()
            {
                state = true, 
                type = buffType.Revigorate,
            };
            if (Target.Foe == false)
            {
                GameManager.Instance.TeamBuffs.Add(buffObject);
            }
            //in every Debuff there will be a removeBuff==false, but of course it will ask first if it equals true
        }
        public void HealVictim(object CharacterInstance, object TargetInstance)// i gave it a Buffobject for teamBuff but its is NOT SUPPOSED to be added to the character bufflist
        {
            int HealingCache = 0;
            Persona Character = (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            HealingCache = (int)(Target.Health * Character.HealBuffPercent);

            BuffObject buffObject = null;
            buffObject = new BuffObject()
            {
                state = true,
                type = buffType.HealVictim,
                target=Target
            };
            buffObject.amount = HealingCache;
            if (Character.Foe == false)
            {
                GameManager.Instance.TeamBuffs.Add(buffObject);
            }
            for (int i = 0; i < ((Persona)TargetInstance).GetDebuffs().Count; i++)
            {
                if(((Persona)TargetInstance).GetDebuffs()[i].type == debuffType.Burnt)
                    HealingCache = (int)((double)HealingCache * ((Persona)TargetInstance).GetDebuffs()[i].amount);
            }

            Target.Health += HealingCache;
        }
        public void HealVictim(object TargetInstance, int damageobj)
        {
            Persona Target = (Persona)TargetInstance;
            Target.Health += damageobj;

            BuffObject buffObject = null;
            buffObject = new BuffObject()
            {
                state = true,
                type = buffType.HealVictim,
                target = Target
            };
            buffObject.amount = damageobj;
            if (Target.Foe == false)
            {
                GameManager.Instance.TeamBuffs.Add(buffObject);
            }
        }
        public void GodsBlessing(object CharacterInstance)
        {
            Persona Character = (Persona)CharacterInstance;
            object TargetInstance = Character.Allies[UnityEngine.Random.Range(0, Character.Allies.Count)];
            int r = UnityEngine.Random.Range(0, 5);

            switch (r)
            {
                case 0:
                    Character.HealVictim(CharacterInstance, TargetInstance);
                    break;
                case 1:
                    Character.PolishWeapon(TargetInstance);
                    break;
                case 2:
                    Character.Revigorate(TargetInstance);
                    break;
                case 3:
                    Character.OnGuard(CharacterInstance, TargetInstance);
                    break;
                case 4:
                    Character.Aware(CharacterInstance);
                    break;
            }
            //GameManager.Instance.BattleWon();
        }

    }
}
