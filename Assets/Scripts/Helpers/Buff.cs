
using Assets.Scripts.Entities.Character;
using Assets.Scripts.Models;
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

            object scapegoat = Character;
            scapegoat = Character.Allies.Any();
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
            bool protector = true;
            BuffObject buffObject = null;
            buffObject = new BuffObject()
            {
                state = protector,
                type = buffType.Protector,
            };
            Character.AddBuff(buffObject);

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
                    protector = false;
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

            bool protectoed= true;
            BuffObject buffObject = null;
            buffObject = new BuffObject()
            {
                state = protectoed,
                type = buffType.Protected,
            };
            Target.AddBuff(buffObject);

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
                    protectoed = false;
                    Target.ProtectionSponser = null;
                    BuffTimer.Close();
                }
            }
            return sponser;
        }
        public void Revigorate(object TargetInstance)// i didn't even give this a BuffObject, cause really its a once off method
        {
            Persona Target = (Persona)TargetInstance;
            Target.RemoveDebuffEffects = true;
            //in every Debuff there will be a removeBuff==false, but of course it will ask first if it equals true
        }
        public void HealVictim(object CharacterInstance, object TargetInstance)// i didn't even give this a BuffObject, cause really its a once off method
        {
            int HealingCache = 0;
            Persona Character = (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            HealingCache = (int)(Target.Health * Character.HealBuffPercent);
            Target.Health += HealingCache;
        }
        public void GodsBlessing(object CharacterInstance, List<string> Allies)
        {
            throw new NotImplementedException();
        }

    }
}
