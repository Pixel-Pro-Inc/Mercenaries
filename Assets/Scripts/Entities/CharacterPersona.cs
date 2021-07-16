using Assets.Scripts.TraitInterface;
using Assets.TraitInterface;
using Assets.TraitInterface.CombantantType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Assets.Entities
{
    class CharacterPersona: Cards, ICombatAction
    {

        /*
         This CharacterPersona is the bluprint for all characters, friend and foe. The properties listed below are all the properties that each character shares
        that does not need to be given a unique default value for that character. Its also the place for variables that arent used often and don't need to be 
        defined. The 'must have' properties are defined in ICharacterTraits. In ICHaractertraits each property will be unique per character and is important and 
        must be implemented and defined.

        Below I planned on defining each unique character and all their traits and abilities (methods).
        In my mind each one will be of Type 'Class' and so this will just be used as a reference for their combat types.
         */
        public enum MasterCharacterList
        {
            //Here a list of every individual character will be defined.Then they will be accessed with their indexes as needed in below lists eg List<>Allies
            #region Heros
            Peter, Mister_Glubglub, Mister_Froggo, Mister_Salaboned, Mister_Lizzacorn, Mister_Liodin, Mister_Lacrox, Mister_Birbarcher
            #endregion
            #region Foes

            #endregion
        }


        //Be sure to define the passive traits!!!!!!!!!
        //and the costs if there are any!!!!!!!!


        #region GivenCharacterTraits


        public enum Kingdom { FarWest, MiddleEarth, DarkSyde };
        
        public List<string> Master { get; set; }
        public List<string> Allies { get; set; }
        public List<string> Enemies { get; set; }
        public enum SpeciesType
        {
            Lion,
            Crocodile,
            Fish,
            Salamander,
            Frog,
            Triton,
            Unknown
        };
        internal int ExperienceLevel { get { return ExperienceLevel;  } set { if (ExperienceLevel < 0) ExperienceLevel = 0; } }
        int shield { get; set; } //We are defining (not ICharacterTraits here cause it isn't used by everyone often but can be, and its null for everyone starting off
        #endregion
        #region Combat Action

        #region Unique Traits

        public void UniqueSkill(object CharacterInstance)
        {
            #region Unique template logic

            string name = "";
            if (CharacterInstance.GetType() == typeof(CharacterPersona.WarriorTemplate))
            {
                CharacterPersona.WarriorTemplate starter = (CharacterPersona.WarriorTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(CharacterPersona.TankWarriorTemplate))
            {
                CharacterPersona.TankWarriorTemplate starter = (CharacterPersona.TankWarriorTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(CharacterPersona.RangeTemplate))
            {
                CharacterPersona.RangeTemplate starter = (CharacterPersona.RangeTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(CharacterPersona.MageTemplate))
            {
                CharacterPersona.MageTemplate starter = (CharacterPersona.MageTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(CharacterPersona.ControllerTemplate))
            {
                CharacterPersona.ControllerTemplate starter = (CharacterPersona.ControllerTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(CharacterPersona.AssasinTemplate))
            {
                CharacterPersona.AssasinTemplate starter = (CharacterPersona.AssasinTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            #endregion
            #region Unique Character logic

            switch (name)
            {
                case "Peter":
                    break;
                case "Mister GlubGlub":
                    break;
                case "Mister froggo":
                    break;
                case "Mister Salaboned":
                    break;
                case "Mister Lizzacorn":
                    break;
                case "Mister Liodin":
                    break;
                case "Mister Lacrox":
                    break;
                case "Mister Birbarcher":
                    break;
            }

            #endregion
        }
        public void UniqueActiveBuff(object CharacterInstance)
        {
            #region Unique template logic

            string name = "";
            if (CharacterInstance.GetType() == typeof(CharacterPersona.WarriorTemplate))
            {
                CharacterPersona.WarriorTemplate starter = (CharacterPersona.WarriorTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(CharacterPersona.TankWarriorTemplate))
            {
                CharacterPersona.TankWarriorTemplate starter = (CharacterPersona.TankWarriorTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(CharacterPersona.RangeTemplate))
            {
                CharacterPersona.RangeTemplate starter = (CharacterPersona.RangeTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(CharacterPersona.MageTemplate))
            {
                CharacterPersona.MageTemplate starter = (CharacterPersona.MageTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(CharacterPersona.ControllerTemplate))
            {
                CharacterPersona.ControllerTemplate starter = (CharacterPersona.ControllerTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(CharacterPersona.AssasinTemplate))
            {
                CharacterPersona.AssasinTemplate starter = (CharacterPersona.AssasinTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            #endregion
            #region Unique Character logic

            switch (name)
            {
                case "Peter":
                    break;
                case "Mister GlubGlub":
                    break;
                case "Mister froggo":
                    break;
                case "Mister Salaboned":
                    break;
                case "Mister Lizzacorn":
                    break;
                case "Mister Liodin":
                    break;
                case "Mister Lacrox":
                    break;
                case "Mister Birbarcher":
                    break;
            }

            #endregion
        }

        public void UniqueActiveDeBuff(object CharacterInstance)
        {
            #region Unique template logic

            string name = "";
            if (CharacterInstance.GetType() == typeof(CharacterPersona.WarriorTemplate))
            {
                CharacterPersona.WarriorTemplate starter = (CharacterPersona.WarriorTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(CharacterPersona.TankWarriorTemplate))
            {
                CharacterPersona.TankWarriorTemplate starter = (CharacterPersona.TankWarriorTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(CharacterPersona.RangeTemplate))
            {
                CharacterPersona.RangeTemplate starter = (CharacterPersona.RangeTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(CharacterPersona.MageTemplate))
            {
                CharacterPersona.MageTemplate starter = (CharacterPersona.MageTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(CharacterPersona.ControllerTemplate))
            {
                CharacterPersona.ControllerTemplate starter = (CharacterPersona.ControllerTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(CharacterPersona.AssasinTemplate))
            {
                CharacterPersona.AssasinTemplate starter = (CharacterPersona.AssasinTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            #endregion
            #region Unique Character logic

            switch (name)
            {
                case "Peter":
                    break;
                case "Mister GlubGlub":
                    break;
                case "Mister froggo":
                    break;
                case "Mister Salaboned":
                    break;
                case "Mister Lizzacorn":
                    break;
                case "Mister Liodin":
                    break;
                case "Mister Lacrox":
                    break;
                case "Mister Birbarcher":
                    break;
            }

            #endregion
        }

        #endregion


        #region Attack

        public bool TrueDamage(object CharacterInstance)
        {
            throw new NotImplementedException();
        }
        public bool PhysicalDamage(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool MagicalDamage(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool Drain(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool Ignite(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool Bleed(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool Blight(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool BalancedDamage(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool Curse(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool Feign(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Defend

        public bool PutArmour(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool IncreaseMagicalResistance(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool ShieldUp(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool Purified(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool Block(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool Immune(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Buff

        public bool Agile(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool PolishWeapon(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool Chosen(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool Aware(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool OnGuard(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool Provoking(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool Protector(object OwnerInstance, object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool Protected(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool Revigorate(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool GodsBlessing(object CharacterInstance)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Debuff

        public bool Slow(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool Rooted(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool WeakGrip(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool Exiled(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool Marked(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool Calm(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool BrokenGuard(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool Burnt(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool Stun(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool Freeze(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool Cold(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool Blinded(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool Tainted(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool Sleep(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool Hungry(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool Unhealthy(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool GodsAnger(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #region Items 

        Items.HolyCrossTemplate HolyCrossItem = new Items.HolyCrossTemplate();
        Items.Nth_Metal Nth_Metal_Item = new Items.Nth_Metal();
        Items.GaiaShieldTemplate GaiaShieldTemplate = new Items.GaiaShieldTemplate();

        public void EquipItem(object item, object CharacterInstance)
        {
            if (item.GetType() == typeof(Items.HolyCrossTemplate))
            {
                HolyCrossItem.ActivationRequireMent(CharacterInstance);
            }
            if (item.GetType() == typeof(Items.Nth_Metal))
            {
                Nth_Metal_Item.ActivationRequireMent(CharacterInstance);
            }
            if (item.GetType() == typeof(Items.GaiaShieldTemplate))
            {
                GaiaShieldTemplate.ActivationRequireMent(CharacterInstance);
            }
        }

        #endregion


        #region WarriorCharacter Template
        public class WarriorTemplate : CharacterPersona, ICardTraits, ICharacterTraits, IWarriorTraits
        {
            public static WarriorTemplate Instance { get; set; }
            public WarriorTemplate()
            {
                Instance = this;
            }
            #region Character variables
            public string CharacterName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
            public string BriefDescription { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

            public bool DefaultValue { get { return DefaultValue; } set { DefaultValue = true; } }
            public int Health 
            { 
                get { return Health; }
                set
                {
                    if (Health < 0) Health = 0;
                    if (DefaultValue==true)
                    {

                        if (Foe == false)
                        {
                            Health = 70;
                        }
                        else
                        {
                            Health = 15;
                        }
                    }
                }
            }
            public int dodge
            { 
                get { return dodge; } 
                set 
                {
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            dodge = 6;
                        }
                        else
                        {
                            dodge = 0;
                        }
                    }
                    if (dodge < 0) dodge = 0;
                   
                } 
            }
            public int Speed
            {
                get { return Speed; }
                set
                {
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            Speed = 10;
                        }
                        else
                        {
                            Speed = 1;
                        }
                    }
                    if (Speed < 0) Speed = 0;
                    
                }
            }
            public double CritC
            {
                get { return CritC; }
                set
                {
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            CritC = 6;
                        }
                        else
                        {
                            CritC = 1;
                        }
                    }
                    if (CritC < 0) CritC = 0;
                    
                }
            }
            public int MagicRes
            {
                get { return MagicRes; }
                set
                {
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            MagicRes = 2;
                        }
                        else
                        {
                            MagicRes = 0;
                        }
                    }
                    if (MagicRes < 0) MagicRes = 0;
                    
                }
            }
            public int Armour
            {
                get { return Armour; }
                set
                {
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            Armour = 2;
                        }
                        else
                        {
                            Armour = 0;
                        }
                    }
                    if (Armour < 0) Armour = 0;
                    
                }
            }
            public int Damage 
            {
                get { return Damage; }
                set 
                {
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            if (LowDamageWarrior == true)
                            {
                                Damage = 14;
                            }
                            else
                            {
                                Damage = 19;
                            }
                        }
                        else
                        {
                            if (LowDamageWarrior == true)
                            {
                                Damage = 3;
                            }
                            else
                            {
                                Damage = 6;
                            }
                        }
                    }
                    if (Damage < 0) Damage = 0;
                    
                }
            }
            public int Accuracy 
            { 
                get { return Accuracy; }
                set 
                {
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            Accuracy = 95;
                        }
                        else
                        {
                            Accuracy = 0;
                        }
                    }
                    if (Accuracy < 0) Accuracy = 0;
                } 
            }


            public int Mana { get { return Mana; } set { if (DefaultValue == true){if (Mana > 100) Mana = 100; if (Mana < 0) Mana = 0;} }}
            public int Stamina { get { return Stamina; } set { if (DefaultValue == true) { if (Stamina > 100) Stamina = 100; if (Stamina < 0) Stamina = 0;} }

            }
            public string CharacterDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public List<string> NaturalAllies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public List<string> NaturalEnemies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool Foe { get { return Foe; } set { Foe = false; } }
            public bool PassiveWarriorTraits { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool LowDamageWarrior { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public int ExpPoints
            {
                get { return ExpPoints; }
                set
                {
                    if (ExpPoints < 0) ExpPoints = 0;
                    if (true/*sessionStarted?*/)
                    {
                        Instance.ExpPoints += NewEarnedXp;
                    }
                    if (Instance.ExpPoints > 1000)
                    {
                        Instance.LevelIncrease();
                        Instance.ExpPoints -= 1000;
                    }
                }
            }
            public int NewEarnedXp
            {
                get { return NewEarnedXp; }
                set
                {
                    if (NewEarnedXp < 0) NewEarnedXp = 0;
                    if (EarnedXp == true)
                    {
                        Instance.NewEarnedXp = NewEarnedXp;
                    }
                    else
                    {
                        Instance.NewEarnedXp = 0;
                    }
                }
            }
            public bool EarnedXp
            {
                get { return EarnedXp; }
                set
                {
                    if (true)
                    {
                        //SessionOver?EarnedXp=false;
                    }
                }
            } //This bool is made true when XPIncrease is fired and should be made of when sessionOver is true

            public int MagicalDamageTaken { get => throw new NotImplementedException(); set => throw new NotImplementedException(); /*if (MagicalDama < 0) MagicalDa = 0;*/}
            public int PhysicalDamageTaken { get => throw new NotImplementedException(); set => throw new NotImplementedException(); /*if (PhysicalDama < 0) PhyscialDama = 0;*/}
            public int HitCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }



            #endregion
            #region Character Methods

            //Here are the passive traits of the card themselves
            public void passiveTraits()
            {
                //Instance.EquipItem(HolyCrossItem, Instance); I dont expect this to be used at all here. It would be clled some place else, I wrrote it here to see if it would work
                Instance.ActiveBuff(); 
            }

            //string CitizenOf = (string)WarriorTemplate.Kingdom.DarkSyde; // Here I was just experimenting to see how the citizenship can be set
            //After We figure out how to set the respective variables to the specific enum value I want to use peter as a reference for other characters so we
            //forget to include the correct and necesary info


            
            

            //Default Methods of Character Combantant type
            public void ActiveBuff()
            {
                #region Passive option 2 Warrior StackSpeed

                //Passive 2 - Stacks atack speed up to 5 times (5% each)

                int CacheSpeed = 0;
                int StackCount = 5;
                if (StackCount > 0&&HitCount<5)
                {
                    Instance.Speed += (int)(Instance.Speed * 0.05);
                    CacheSpeed += (int)(Instance.Speed * 0.05);
                    StackCount--;
                }
                else
                {
                    //Print " cannot stack any more" or "Stack limit reached"
                }
                if (true/*GameOver==true*/)
                {
                    Instance.Speed -= CacheSpeed;
                    CacheSpeed = 0;
                    StackCount = 5;
                }
                #endregion
            }
            public void ActiveDeBuff()
            {
                throw new System.NotImplementedException();
            }
            //Experince methods
            public void LevelIncrease()
            {
                Instance.ExperienceLevel++;
                if (Foe == false)
                {
                    Instance.Health += 20 *Instance.ExperienceLevel;
                    Instance.dodge += 2 * Instance.ExperienceLevel;
                    Instance.Speed += 2 * Instance.ExperienceLevel;
                    Instance.CritC += 1 * Instance.ExperienceLevel;
                    Instance.MagicRes += 1 * Instance.ExperienceLevel;
                    Instance.Armour += 3 * Instance.ExperienceLevel;
                    if (LowDamageWarrior == true) Instance.Damage += 3 * Instance.ExperienceLevel;
                    else
                    {
                        Instance.Damage += 2 * Instance.ExperienceLevel;
                    }
                }
                else
                {
                    Instance.Health += 5 * Instance.ExperienceLevel;
                    Instance.dodge += 2 * Instance.ExperienceLevel;
                    Instance.Speed += 1 * Instance.ExperienceLevel;
                    Instance.CritC += 1 * Instance.ExperienceLevel;
                    Instance.MagicRes += 0;
                    Instance.Armour += 0;
                    if (LowDamageWarrior == true) Instance.Damage += 1 * Instance.ExperienceLevel;
                    else
                    {
                        Instance.Damage += 2 * Instance.ExperienceLevel;
                    }
                }
                //fire levelIncrease animation
            }
            public void XPIncrease(bool earnXp, int newEarnedXp)
            {
                EarnedXp = earnXp;
                NewEarnedXp = newEarnedXp;
            }

            public void TraitLevelUpActivation(int experienceLevel, List<Items> Items)
            {
                throw new NotImplementedException();
            }


            public int DamageGiven(object CharacterInstance)
            {
                int damageGiven = 0;
                if (Foe == false)
                {
                    Random r = new Random();
                    damageGiven = r.Next(14, 20);
                }
                else
                {
                    Random r = new Random();
                    damageGiven = r.Next(3, 7);
                }

                #region template logic
                
                 
                if (CharacterInstance.GetType() == typeof(CharacterPersona.WarriorTemplate))
                {
                    CharacterPersona.WarriorTemplate starter = (CharacterPersona.WarriorTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.TankWarriorTemplate))
                {
                    CharacterPersona.TankWarriorTemplate starter = (CharacterPersona.TankWarriorTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.RangeTemplate))
                {
                    CharacterPersona.RangeTemplate starter = (CharacterPersona.RangeTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.MageTemplate))
                {
                    CharacterPersona.MageTemplate starter = (CharacterPersona.MageTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.ControllerTemplate))
                {
                    CharacterPersona.ControllerTemplate starter = (CharacterPersona.ControllerTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.AssasinTemplate))
                {
                    CharacterPersona.AssasinTemplate starter = (CharacterPersona.AssasinTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                #endregion

                return damageGiven;

            }

            public int HealthLoss(int damageGiven)
            {
                /*I think that the types of attacks logic will be made here. It will be easier to set how the health and armour and Magres wil be affected
                 allin the same place. There will be if statement for all types of attacks. I am Also thinking of making bool statements in Characterpersona
                so that instances can have their bool eg drain for example, to be set true. And if that happens the logic iin healthloss(damageGiven) is fired.
                */
                Instance.PhysicalDamageTaken = (int)(damageGiven * 0.4);
                Instance.MagicalDamageTaken = (int)(damageGiven * 0.6);
                Instance.PhysicalDamageTaken -= Instance.Armour;
                Instance.MagicalDamageTaken -= Instance.MagicRes;
                int damageTaken = Instance.MagicalDamageTaken + Instance.PhysicalDamageTaken;
                Instance.Health -= damageTaken;
                return damageTaken;
            }


            #endregion

        }
        #endregion
        #region TankWarriorCharacter Template

        public class TankWarriorTemplate : CharacterPersona, ICardTraits, ICharacterTraits, ITankWarriorTraits
        {
            public static TankWarriorTemplate Instance { get; set; }
            public TankWarriorTemplate()
            {
                Instance = this;
            }


            #region Character variables
            public string CharacterName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public string CharacterDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


            public bool DefaultValue { get { return DefaultValue; } set { DefaultValue = true; } }
            public int Health
            {
                get { return Health; }
                set
                {
                    if (Health < 0) Health = 0;
                    if (DefaultValue==true)
                    {

                        if (Foe == false)
                        {
                            Health = 120; 
                        }
                        else
                        {
                            Health = 25; 
                        }
                    }
                }
            }
            public int dodge
            {
                get { return dodge; }
                set
                {
                    if (dodge < 0) dodge = 0;
                    if (DefaultValue==true)
                    {
                        if (Foe == false)
                        {
                            dodge = 1;
                        }
                        else
                        {
                            dodge = 0;
                        }
                    }
                }
            }
            public int Speed
            {
                get { return Speed; }
                set
                {
                    if (Speed < 0) Speed = 0;
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            Speed = 1;
                        }
                        else
                        {
                            Speed = 1;
                        }

                    }
                }
            }
            public double CritC
            {
                get { return CritC; }
                set
                {
                    if (CritC < 0) CritC = 0;
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            CritC = 3;
                        }
                        else
                        {
                            CritC = 1;
                        }
                    }
                }
            }
            public int MagicRes
            {
                get { return MagicRes; }
                set
                {
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            MagicRes = 5;
                        }
                        else
                        {
                            MagicRes = 5;
                        }
                    }
                }
            }
            public int Armour
            {
                get { return Armour; }
                set
                {
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            Armour = 3;
                        }
                        else
                        {
                            Armour = 5;
                        }

                    }
                }
            }
            public int Damage
            {
                get { return Damage; }
                set
                {
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            if (LowDamageTankWarrior == true)
                            {
                                Damage = 8;
                            }
                            else
                            {
                                Damage = 13;
                            }
                        }
                        else
                        {
                            if (LowDamageTankWarrior == true)
                            {
                                Damage = 2;
                            }
                            else
                            {
                                Damage = 4;
                            }
                        }

                    }
                }
            }
            public int Accuracy
            {
                get { return Accuracy; }
                set
                {
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            Accuracy = 80;
                        }
                        else
                        {
                            Accuracy = 0;
                        }
                    }
                    if (Accuracy < 0) Accuracy = 0;
                }
            }
            public int Mana { get => throw new NotImplementedException(); set => throw new NotImplementedException();/*if(DefaultValue==true){  }*/}
            public int Stamina { get => throw new NotImplementedException(); set => throw new NotImplementedException();/*if(DefaultValue==true){  }*/ }
            public int ExpPoints
            {
                get { return ExpPoints; }
                set
                {
                    if (true/*sessionStarted?*/)
                    {
                        Instance.ExpPoints += NewEarnedXp;
                    }
                    if (Instance.ExpPoints > 1000)
                    {
                        Instance.LevelIncrease();
                        Instance.ExpPoints -= 1000;
                    }
                }
            }
            public int NewEarnedXp
            {
                get { return NewEarnedXp; }
                set
                {
                    if (EarnedXp == true)
                    {
                        Instance.NewEarnedXp = NewEarnedXp;
                    }
                    else
                    {
                        Instance.NewEarnedXp = 0;
                    }
                }
            }
            public bool EarnedXp
            {
                get { return EarnedXp; }
                set
                {
                    if (true)
                    {
                        //SessionOver?EarnedXp=false;
                    }
                }
            } //This bool is made true when XPIncrease is fired and should be made of when sessionOver is true
            public string BriefDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public List<string> NaturalAllies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public List<string> NaturalEnemies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool Foe { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool PassiveTankTraits { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool LowDamageTankWarrior { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public int MagicalDamageTaken { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public int PhysicalDamageTaken { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public int HitCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


            #endregion
            #region Character Methods

            public void passiveTraits()
            {
                
            }

            public void LevelIncrease()
            {
                Instance.ExperienceLevel++;
                if (Foe == false)
                {

                    Instance.Health += 40 * Instance.ExperienceLevel;
                    Instance.dodge += 1 * Instance.ExperienceLevel;
                    Instance.Speed += 1 * Instance.ExperienceLevel;
                    Instance.CritC += 1 * Instance.ExperienceLevel;
                    Instance.MagicRes += 1 * Instance.ExperienceLevel;
                    Instance.Armour += 2 * Instance.ExperienceLevel;
                    if (LowDamageTankWarrior == true) Instance.Damage += 2 * Instance.ExperienceLevel;
                    else
                    {
                        Instance.Damage += 2 * Instance.ExperienceLevel;
                    }
                }
                else
                {
                    Instance.Health += 8 * Instance.ExperienceLevel;
                    Instance.dodge += 0 * Instance.ExperienceLevel;
                    Instance.Speed += 1 * Instance.ExperienceLevel;
                    Instance.CritC += 1 * Instance.ExperienceLevel;
                    Instance.MagicRes += 1 * Instance.ExperienceLevel;
                    Instance.Armour += 2 * Instance.ExperienceLevel;
                    if (LowDamageTankWarrior == true) Instance.Damage += 1 * Instance.ExperienceLevel;
                    else
                    {
                        Instance.Damage += 1 * Instance.ExperienceLevel;
                    }
                }
                //fire levelIncrease animation
            }

            public void XPIncrease(bool earnXp, int newEarnedXp)
            {
                EarnedXp = earnXp;
                NewEarnedXp = newEarnedXp;
            }

            public void ActiveBuff()
            {
                #region Passive option 1 Tank

                /*
                 Passive 1 - each 1% of health lost, you gain 2% more armor and magic resistance

                int percentageHealthLoss =(Instance.HealthLoss(TankWarriorTemplate.Instance.DamageGiven(TankWarriorTemplate.Instance))/ Health);
                //This line above doesn't make sense. damageGiven needs to be passed through ActiveBuff for it to work. We cant use the above parameter in HealthLoss it has to be something past into the activeBuff()
                int CacheArmour = 0;
                int CacheMagicalresistance = 0;
                for (int per = 0; per < percentageHealthLoss; per++)
                {
                    Instance.Armour += (int)(Instance.Armour * 0.02);
                    CacheArmour += (int)(Instance.Armour * 0.02);
                    Instance.MagicRes += (int)(Instance.MagicRes * 0.02);
                    CacheMagicalresistance += (int)(Instance.MagicRes * 0.02);
                }
                if (GameOver==true)
                {
                    Instance.Armour -= CacheArmour;
                    Instance.MagicRes -= CacheMagicalresistance;
                    CacheArmour = 0;
                    CacheMagicalresistance = 0;
                }

                */
                
                #endregion
            }

            public void ActiveDeBuff()
            {
                throw new NotImplementedException();
            }

            public void TraitLevelUpActivation(int experienceLevel, List<Items> Items)
            {
                throw new NotImplementedException();
            }

            public int DamageGiven(object CharacterInstance)
            {
                int damageGiven = 0;
                if (Foe == false)
                {
                    Random r = new Random();
                    damageGiven = r.Next(8, 14);
                }
                else
                {
                    Random r = new Random();
                    damageGiven = r.Next(2, 5);
                }

                #region template logic


                if (CharacterInstance.GetType() == typeof(CharacterPersona.WarriorTemplate))
                {
                    CharacterPersona.WarriorTemplate starter = (CharacterPersona.WarriorTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.TankWarriorTemplate))
                {
                    CharacterPersona.TankWarriorTemplate starter = (CharacterPersona.TankWarriorTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.RangeTemplate))
                {
                    CharacterPersona.RangeTemplate starter = (CharacterPersona.RangeTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.MageTemplate))
                {
                    CharacterPersona.MageTemplate starter = (CharacterPersona.MageTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.ControllerTemplate))
                {
                    CharacterPersona.ControllerTemplate starter = (CharacterPersona.ControllerTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.AssasinTemplate))
                {
                    CharacterPersona.AssasinTemplate starter = (CharacterPersona.AssasinTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                #endregion

                return damageGiven;
            }
            public int HealthLoss(int damageGiven)
            {
                Instance.PhysicalDamageTaken = (int)(damageGiven * 0.4);
                Instance.MagicalDamageTaken = (int)(damageGiven * 0.6);
                Instance.PhysicalDamageTaken -= Instance.Armour;
                Instance.MagicalDamageTaken -= Instance.MagicRes;
                int damageTaken = Instance.MagicalDamageTaken + Instance.PhysicalDamageTaken;
                Instance.Health -= damageTaken;

                return damageTaken;
            }

            #endregion
        }
        #endregion
        #region RangeCharacter Template

        public class RangeTemplate: CharacterPersona, ICardTraits, ICharacterTraits, IRangeTraits
        {
            public static RangeTemplate Instance { get; set; }
            public RangeTemplate()
            {
                Instance = this;
            }
           

            #region Character variables
            public string CharacterName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public string CharacterDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public bool DefaultValue { get { return DefaultValue; } set { DefaultValue = true; } }
            public int Health
            {
                get { return Health; }
                set
                {
                    if (Health < 0) Health = 0;
                    if (DefaultValue==true)
                    {
                        if (Foe == false)
                        {
                            Health = 58; 
                        }
                        else
                        {
                            Health = 8; 
                        }
                    }
                }
            }
            public int dodge
            {
                get { return dodge; }
                set
                {
                    if (dodge < 0) dodge = 0;
                    if (DefaultValue == true)
                    {

                    }
                    if (Foe == false)
                    {
                        dodge = 8;
                    }
                    else
                    {
                        dodge = 5;
                    }
                }
            }
            public int Speed
            {
                get { return Speed; }
                set
                {
                    if (Speed < 0) Speed = 0;
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            Speed = 6;
                        }
                        else
                        {
                            Speed = 7;
                        }

                    }
                }
            }
            public double CritC
            {
                get { return CritC; }
                set
                {
                    if (CritC < 0) CritC = 0;
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            CritC = 6;
                        }
                        else
                        {
                            CritC = 2;
                        }

                    }
                }
            }
            public int MagicRes
            {
                get { return MagicRes; }
                set
                {
                    if (MagicRes < 0) MagicRes = 0;
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            MagicRes = 1;
                        }
                        else
                        {
                            MagicRes = 0;
                        }

                    }
                }
            }
            public int Armour
            {
                get { return Armour; }
                set
                {
                    if (Armour < 0) Armour = 0;
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            Armour = 3;
                        }
                        else
                        {
                            Armour = 0;
                        }

                    }
                }
            }
            public int Damage
            {
                get { return Damage; }
                set
                {
                    if (Damage < 0) Damage = 0;
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            if (LowDamageRange == true)
                            {
                                Damage = 4;
                            }
                            else
                            {
                                Damage = 16;
                            }
                        }
                        else
                        {
                            if (LowDamageRange == true)
                            {
                                Damage = 2;
                            }
                            else
                            {
                                Damage = 6;
                            }
                        }

                    }
                }
            }
            public int Accuracy
            {
                get { return Accuracy; }
                set
                {
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            Accuracy = 95;
                        }
                        else
                        {
                            Accuracy = 0;
                        }
                    }
                    if (Accuracy < 0) Accuracy = 0;
                }
            }


            public int Mana { get { return Mana; } set { if (Mana > 100) Mana = 100; if (Mana < 0) Mana = 0; } }
            public int Stamina { get { return Stamina; } set { if (Stamina > 100) Stamina = 100; if (Stamina < 0) Stamina = 0; } }
            public int ExpPoints
            {
                get { return ExpPoints; }
                set
                {
                    if (true/*sessionStarted?*/)
                    {
                        Instance.ExpPoints += NewEarnedXp;
                    }
                    if (Instance.ExpPoints > 1000)
                    {
                        Instance.LevelIncrease();
                        Instance.ExpPoints -= 1000;
                    }
                }
            }
            public int NewEarnedXp
            {
                get { return NewEarnedXp; }
                set
                {
                    if (EarnedXp == true)
                    {
                        Instance.NewEarnedXp = NewEarnedXp;
                    }
                    else
                    {
                        Instance.NewEarnedXp = 0;
                    }
                }
            }
            public bool EarnedXp
            {
                get { return EarnedXp; }
                set
                {
                    if (true)
                    {
                        //SessionOver?EarnedXp=false;
                    }
                }
            } //This bool is made true when XPIncrease is fired and should be made of when sessionOver is true
            public string BriefDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public List<string> NaturalAllies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public List<string> NaturalEnemies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool Foe { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool PassiveRangeTraits { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool LowDamageRange { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public int MagicalDamageTaken { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public int PhysicalDamageTaken { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public int HitCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            #endregion
            #region Character Methods

            public void passiveTraits()
            {
                throw new NotImplementedException();
            }
            public void LevelIncrease()
            {
                Instance.ExperienceLevel++;
                if (Foe == false)
                {
                    
                Instance.Health += 11 * Instance.ExperienceLevel;
                Instance.dodge += 4 * Instance.ExperienceLevel;
                Instance.Speed += 4 * Instance.ExperienceLevel;
                Instance.CritC += 2 * Instance.ExperienceLevel;
                Instance.MagicRes += 2 * (Instance.ExperienceLevel-2);
                Instance.Armour += 2 * (Instance.ExperienceLevel-2);
                if (LowDamageRange == true) Instance.Damage += 2 * Instance.ExperienceLevel;
                else
                {
                    Instance.Damage += 4 * Instance.ExperienceLevel;
                }
                //fire levelIncrease animation
                }
                else
                {
                    Instance.Health += 3 * Instance.ExperienceLevel;
                    Instance.dodge += 1 * Instance.ExperienceLevel;
                    Instance.Speed += 4 * Instance.ExperienceLevel;
                    Instance.CritC += 2 * Instance.ExperienceLevel;
                    Instance.MagicRes += 0 * (Instance.ExperienceLevel - 2);
                    Instance.Armour += 0 * (Instance.ExperienceLevel - 2);
                    if (LowDamageRange == true) Instance.Damage += 1 * Instance.ExperienceLevel;
                    else
                    {
                        Instance.Damage += 2 * Instance.ExperienceLevel;
                    }
                }
                //fire levelIncrease animation
            }

            public void XPIncrease(bool earnXp, int newEarnedXp)
            {
                EarnedXp = earnXp;
                NewEarnedXp = newEarnedXp;
            }

            public void ActiveBuff()
            {
                throw new NotImplementedException();
            }

            public void ActiveDeBuff()
            {
                throw new NotImplementedException();
            }

            public void TraitLevelUpActivation(int experienceLevel, List<Items> Items)
            {
                throw new NotImplementedException();
            }

            public int DamageGiven(object CharacterInstance)
            {
                int damageGiven = 0;
                if (Foe == false)
                {
                    Random r = new Random();
                    damageGiven = r.Next(4, 17);
                }
                else
                {
                    Random r = new Random();
                    damageGiven = r.Next(2, 7);
                }

                #region template logic


                if (CharacterInstance.GetType() == typeof(CharacterPersona.WarriorTemplate))
                {
                    CharacterPersona.WarriorTemplate starter = (CharacterPersona.WarriorTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.TankWarriorTemplate))
                {
                    CharacterPersona.TankWarriorTemplate starter = (CharacterPersona.TankWarriorTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.RangeTemplate))
                {
                    CharacterPersona.RangeTemplate starter = (CharacterPersona.RangeTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.MageTemplate))
                {
                    CharacterPersona.MageTemplate starter = (CharacterPersona.MageTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.ControllerTemplate))
                {
                    CharacterPersona.ControllerTemplate starter = (CharacterPersona.ControllerTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.AssasinTemplate))
                {
                    CharacterPersona.AssasinTemplate starter = (CharacterPersona.AssasinTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                #endregion

                return damageGiven;
            }

            public int HealthLoss(int damageGiven)
            {
                Instance.PhysicalDamageTaken = (int)(damageGiven * 0.4);
                Instance.MagicalDamageTaken = (int)(damageGiven * 0.6);
                Instance.PhysicalDamageTaken -= Instance.Armour;
                Instance.MagicalDamageTaken -= Instance.MagicRes;
                int damageTaken = Instance.MagicalDamageTaken + Instance.PhysicalDamageTaken;
                Instance.Health -= damageTaken;
                return damageTaken;
            }


            #endregion
        }
        #endregion
        #region MageCharacter Template

        public class MageTemplate: CharacterPersona, ICardTraits, ICharacterTraits, IMageTraits
        {
            private Timer myTimer;

            public static MageTemplate Instance { get; set; }
            public MageTemplate()
            {
                Instance = this;
            }


            #region Character Variables

            public string CharacterName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public string CharacterDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public bool DefaultValue { get { return DefaultValue; } set { DefaultValue = true; } }
            public int Health
            {
                get { return Health; }
                set
                {
                    if (DefaultValue==true)
                    {
                        if (Foe == false)
                        {
                            if (SupportMage == false)
                            {
                                Health = 55;
                            }
                            else
                            {
                                Health = 26;
                            }
                        }
                        else
                        {
                            Health = 6;
                        }
                    }
                    if (Health < 0) Health = 0;
                    
                }
            }
            public int dodge
            {
                get { return dodge; }
                set
                {
                    if (dodge < 0) dodge = 0;
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            if (SupportMage == false)
                            {
                                dodge = 5;
                            }
                            else
                            {
                                dodge = 10;
                            }
                        }
                        else
                        {
                            dodge = 10;
                        }

                    }
                }
            }
            public int Speed
            {
                get { return Speed; }
                set
                {
                    if (Speed < 0) Speed = 0;
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            if (SupportMage == false)
                            {
                                Speed = 1;
                            }
                            else
                            {
                                Speed = 10;
                            }
                        }
                        else
                        {
                            Speed = 1;
                        }

                    }
                }
            }
            public double CritC
            {
                get { return CritC; }
                set
                {
                    if (CritC < 0) CritC = 0;
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            if (SupportMage == false)
                            {
                                CritC = 2;
                            }
                            else
                            {
                                CritC = 1;
                            }
                        }
                        else
                        {
                            CritC = 1;
                        }

                    }
                }
            }
            public int MagicRes
            {
                get { return MagicRes; }
                set
                {
                    if (MagicRes < 0) MagicRes = 0;
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            if (SupportMage == false)
                            {
                                MagicRes = 2;
                            }
                            else
                            {
                                MagicRes = 1;
                            }
                        }
                        else
                        {
                            MagicRes = 0;
                        }

                    }
                }
            }
            public int Armour
            {
                get { return Armour; }
                set
                {
                    if (Armour < 0) Armour = 0;
                    if (DefaultValue==true)
                    {
                        if (Foe == false)
                        {
                            if (SupportMage == false)
                            {
                                Armour = 2;
                            }
                            else
                            {
                                Armour = 1;
                            }
                        }
                        else
                        {
                            Armour = 0;
                        }

                    }
                }
            }
            public int Damage
            {
                get { return Damage; }
                set
                {
                    if (Damage < 0) Damage = 0;
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            if (SupportMage == false)
                            {
                                if (LowDamageMage == true)
                                {
                                    Damage = 5;
                                }
                                else
                                {
                                    Damage = 25;
                                }
                            }
                            else
                            {
                                if (LowDamageMage == true)
                                {
                                    Damage = 1;
                                }
                                else
                                {
                                    Damage = 10;
                                }
                            }
                        }
                        else
                        {
                            if (LowDamageMage == true)
                            {
                                Damage = 1;
                            }
                            else
                            {
                                Damage = 20;
                            }
                        }
                    }
                }
            }
            public int Accuracy
            {
                get { return Accuracy; }
                set
                {
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            Accuracy = 85;
                        }
                        else
                        {
                            Accuracy = 0;
                        }
                    }
                    if (Accuracy < 0) Accuracy = 0;
                }
            }
            public int Mana { get { return Mana; } set { if (Mana > 100) Mana = 100; if (Mana < 0) Mana = 0; } }
            public int Stamina { get { return Stamina; } set { if (Stamina > 100) Stamina = 100; if (Stamina < 0) Stamina = 0; } }
            public int ExpPoints
            {
                get { return ExpPoints; }
                set
                {
                    if (true/*sessionStarted?*/)
                    {
                        Instance.ExpPoints += NewEarnedXp;
                    }
                    if (Instance.ExpPoints > 1000)
                    {
                        Instance.LevelIncrease();
                        Instance.ExpPoints -= 1000;
                    }
                }
            }
            public int NewEarnedXp
            {
                get { return NewEarnedXp; }
                set
                {
                    if (EarnedXp == true)
                    {
                        Instance.NewEarnedXp = NewEarnedXp;
                    }
                    else
                    {
                        Instance.NewEarnedXp = 0;
                    }
                }
            }
            public bool EarnedXp
            {
                get { return EarnedXp; }
                set
                {
                    if (true)
                    {
                        //SessionOver?EarnedXp=false;
                    }
                }
            } //This bool is made true when XPIncrease is fired and should be made of when sessionOver is true
            public string BriefDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public List<string> NaturalAllies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public List<string> NaturalEnemies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool Foe { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool PassiveMageTraits { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool LowDamageMage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool SupportMage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public int MagicalDamageTaken { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public int PhysicalDamageTaken { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public int HitCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            #endregion
            #region Character Methods

            public void passiveTraits()
            {
               
            }

            public void LevelIncrease()
            {
                Instance.ExperienceLevel++;
                #region If Support variables Increase logic 
                if (Foe == false)
                {

                    if (SupportMage == false)
                    {
                        Instance.Health += 5 * Instance.ExperienceLevel;
                        Instance.dodge += 5 * Instance.ExperienceLevel;
                        Instance.Speed += 1 * Instance.ExperienceLevel;
                        Instance.CritC += 1 * Instance.ExperienceLevel;
                        Instance.MagicRes += 3 * (Instance.ExperienceLevel - 2);
                        Instance.Armour += 1 * (Instance.ExperienceLevel - 2);
                        #region Damage
                        if (LowDamageMage == true) Instance.Damage += 5 * Instance.ExperienceLevel;
                        else
                        {
                            Instance.Damage += 4 * Instance.ExperienceLevel;
                        }
                        #endregion
                    }
                    else
                    {
                        Instance.Health += 5 * Instance.ExperienceLevel;
                        Instance.dodge += 5 * Instance.ExperienceLevel;
                        Instance.Speed += 6 * Instance.ExperienceLevel;
                        Instance.CritC += 1 * Instance.ExperienceLevel;
                        Instance.MagicRes += 1 * Instance.ExperienceLevel;
                        Instance.Armour += 1 * Instance.ExperienceLevel;
                        if (LowDamageMage == true) Instance.Damage += 3 * Instance.ExperienceLevel;
                        else
                        {
                            Instance.Damage += 4 * Instance.ExperienceLevel;
                        }
                    }
                    //fire levelIncrease animation
                }
                else
                {
                    Instance.Health += 1 * Instance.ExperienceLevel;
                    Instance.dodge += 2 * Instance.ExperienceLevel;
                    Instance.Speed += 1 * Instance.ExperienceLevel;
                    Instance.CritC += 1 * Instance.ExperienceLevel;
                    Instance.MagicRes += 0 * Instance.ExperienceLevel;
                    Instance.Armour += 0 * Instance.ExperienceLevel;
                    if (LowDamageMage == true) Instance.Damage += 1 * Instance.ExperienceLevel;
                    else
                    {
                        Instance.Damage += 5 * Instance.ExperienceLevel;
                    }
                }
                #endregion
                //fire levelIncrease animation

            }

            public void XPIncrease(bool earnXp, int newEarnedXp)
            {
                EarnedXp = earnXp;
                NewEarnedXp = newEarnedXp;
            }

            public void ActiveBuff()
            {
                #region Passive option 2 Mage

                //Mana regen every 5 seconds

                // Create a timer
                myTimer = new System.Timers.Timer();
                // Tell the timer what to do when it elapses
                myTimer.Elapsed += new ElapsedEventHandler(myEvent);
                // Set it to go off every five seconds
                myTimer.Interval = 5000;
                // And start it        
                myTimer.Enabled = true;

                // Implement a call with the right signature for events going off
                void myEvent(object source, ElapsedEventArgs e) { Mana++; }
                #endregion

            }

            public void ActiveDeBuff()
            {
                throw new NotImplementedException();
            }

            public void TraitLevelUpActivation(int experienceLevel, List<Items> Items)
            {
                throw new NotImplementedException();
            }

            public int DamageGiven(object CharacterInstance)
            {
                int damageGiven = 0;
                if (Foe == false)
                {
                    Random r = new Random();
                    damageGiven = r.Next(5, 26);
                }
                else
                {
                    Random r = new Random();
                    damageGiven = r.Next(5, 11);
                }

                #region template logic


                if (CharacterInstance.GetType() == typeof(CharacterPersona.WarriorTemplate))
                {
                    CharacterPersona.WarriorTemplate starter = (CharacterPersona.WarriorTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.TankWarriorTemplate))
                {
                    CharacterPersona.TankWarriorTemplate starter = (CharacterPersona.TankWarriorTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.RangeTemplate))
                {
                    CharacterPersona.RangeTemplate starter = (CharacterPersona.RangeTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.MageTemplate))
                {
                    CharacterPersona.MageTemplate starter = (CharacterPersona.MageTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.ControllerTemplate))
                {
                    CharacterPersona.ControllerTemplate starter = (CharacterPersona.ControllerTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.AssasinTemplate))
                {
                    CharacterPersona.AssasinTemplate starter = (CharacterPersona.AssasinTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                #endregion

                return damageGiven;
            }
            public int HealthLoss(int damageGiven)
            {
                Instance.PhysicalDamageTaken = (int)(damageGiven * 0.4);
                Instance.MagicalDamageTaken = (int)(damageGiven * 0.6);
                Instance.PhysicalDamageTaken -= Instance.Armour;
                Instance.MagicalDamageTaken -= Instance.MagicRes;
                int damageTaken = Instance.MagicalDamageTaken + Instance.PhysicalDamageTaken;
                Instance.Health -= damageTaken;
                return damageTaken;
            }


            #endregion
        }
        #endregion
        #region ControllerCharacter Template

        public class ControllerTemplate: CharacterPersona, ICardTraits, ICharacterTraits, IControllerTraits
        {
            public static ControllerTemplate Instance { get; set; }
            public ControllerTemplate()
            {
                Instance = this;
            }


            #region Character Variables
            public string CharacterName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public string CharacterDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public bool DefaultValue { get { return DefaultValue; } set { DefaultValue = true; } }
            public int Health
            {
                get { return Health; }
                set
                {
                    if (Health < 0) Health = 0;
                    if (DefaultValue==true)
                    {

                    }
                    if (Foe == false)
                    {
                        Health = 68; 
                    }
                    else
                    {
                        Health = 10;
                    }
                }
            }
            public int dodge
            {
                get { return dodge; }
                set
                {
                    if (dodge < 0) dodge = 0;
                    if (DefaultValue==true)
                    {
                        if (Foe == false)
                        {
                            dodge = 10;
                        }
                        else
                        {
                            dodge = 5;
                        }

                    }
                }
            }
            public int Speed
            {
                get { return Speed; }
                set
                {
                    if (Speed < 0) Speed = 0;
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            Speed = 10;
                        }
                        else
                        {
                            Speed = 6;
                        }

                    }
                }
            }
            public double CritC
            {
                get { return CritC; }
                set
                {
                    if (CritC < 0) CritC = 0;
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            CritC = 1;
                        }
                        else
                        {
                            CritC = 0;
                        }

                    }
                }
            }
            public int MagicRes
            {
                get { return MagicRes; }
                set
                {
                    if (MagicRes < 0) MagicRes = 0;
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            MagicRes = 1;
                        }
                        else
                        {
                            MagicRes = 3;
                        }
                    }
                }
            }
            public int Armour
            {
                get { return Armour; }
                set
                {
                    if (Armour < 0) Armour = 0;
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            Armour = 1;
                        }
                        else
                        {
                            Armour = 3;
                        }

                    }
                }
            }
            public int Damage
            {
                get { return Damage; }
                set
                {
                    if (Damage < 0) Damage = 0;
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            if (LowDamageController == true)
                            {
                                Damage = 5;
                            }
                            else
                            {
                                Damage = 10;
                            }
                        }
                        else
                        {
                            if (LowDamageController == true)
                            {
                                Damage = 1;
                            }
                            else
                            {
                                Damage = 2;
                            }
                        }

                    }
                }
            }
            public int Accuracy
            {
                get { return Accuracy; }
                set
                {
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            Accuracy = 90;
                        }
                        else
                        {
                            Accuracy = 0;
                        }
                    }
                    if (Accuracy < 0) Accuracy = 0;
                }
            }
            public int Mana { get { return Mana; } set { if (Mana > 100) Mana = 100; if (Mana < 0) Mana = 0; } }
            public int Stamina { get { return Stamina; } set { if (Stamina > 100) Stamina = 100; if (Stamina < 0) Stamina = 0; } }
            public int ExpPoints
            {
                get { return ExpPoints; }
                set
                {
                    if (true/*sessionStarted?*/)
                    {
                        Instance.ExpPoints += NewEarnedXp;
                    }
                    if (Instance.ExpPoints > 1000)
                    {
                        Instance.LevelIncrease();
                        Instance.ExpPoints -= 1000;
                    }
                }
            }
            public int NewEarnedXp
            {
                get { return NewEarnedXp; }
                set
                {
                    if (EarnedXp == true)
                    {
                        Instance.NewEarnedXp = NewEarnedXp;
                    }
                    else
                    {
                        Instance.NewEarnedXp = 0;
                    }
                }
            }
            public bool EarnedXp
            {
                get { return EarnedXp; }
                set
                {
                    if (true)
                    {
                        //SessionOver?EarnedXp=false;
                    }
                }
            } //This bool is made true when XPIncrease is fired and should be made of when sessionOver is true
            public string BriefDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public List<string> NaturalAllies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public List<string> NaturalEnemies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool Foe { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool PassiveControllerTraits { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool LowDamageController { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public int MagicalDamageTaken { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public int PhysicalDamageTaken { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public int HitCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            #endregion
            #region Character Methods

            public void passiveTraits()
            {
                throw new NotImplementedException();
            }

            public void LevelIncrease()
            {
                Instance.ExperienceLevel++;
                if (Foe == false)
                {
                    Instance.Health += 15 * Instance.ExperienceLevel;
                    Instance.dodge += 5 * Instance.ExperienceLevel;
                    Instance.Speed += 6 * Instance.ExperienceLevel;
                    Instance.CritC += 1 * Instance.ExperienceLevel;
                    Instance.MagicRes += 1 * Instance.ExperienceLevel;
                    Instance.Armour += 1 * Instance.ExperienceLevel;
                    if (LowDamageController == true) Instance.Damage += 3 * Instance.ExperienceLevel;
                    else
                    {
                        Instance.Damage += 4 * Instance.ExperienceLevel;
                    }
                    //fire levelIncrease animation
                }
                else
                {
                    Instance.Health += 3;
                    Instance.dodge += 5;
                    Instance.Speed += 3;
                    Instance.CritC += 1; 
                    if (ExperienceLevel > 3)
                    {
                        Instance.MagicRes += 1;
                        Instance.Armour += 1;
                    }
                    if (LowDamageController == true) Instance.Damage += 1;
                    else
                    {
                        Instance.Damage += 2;
                    }
                    //fire levelIncrease animation
                }
            }


            public void XPIncrease(bool earnXp, int newEarnedXp)
            {
                EarnedXp = earnXp;
                NewEarnedXp = newEarnedXp;
            }

            public void ActiveBuff()
            {
                throw new NotImplementedException();
            }

            public void ActiveDeBuff()
            {
                throw new NotImplementedException();
            }

            public void TraitLevelUpActivation(int experienceLevel, List<Items> Items)
            {
                throw new NotImplementedException();
            }

            public int DamageGiven(object CharacterInstance)
            {
                int damageGiven = 0;
                if (Foe == false)
                {
                    Random r = new Random();
                    damageGiven = r.Next(5, 11);
                }
                else
                {
                    Random r = new Random();
                    damageGiven = r.Next(1, 3);
                }

                #region template logic


                if (CharacterInstance.GetType() == typeof(CharacterPersona.WarriorTemplate))
                {
                    CharacterPersona.WarriorTemplate starter = (CharacterPersona.WarriorTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.TankWarriorTemplate))
                {
                    CharacterPersona.TankWarriorTemplate starter = (CharacterPersona.TankWarriorTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.RangeTemplate))
                {
                    CharacterPersona.RangeTemplate starter = (CharacterPersona.RangeTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.MageTemplate))
                {
                    CharacterPersona.MageTemplate starter = (CharacterPersona.MageTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.ControllerTemplate))
                {
                    CharacterPersona.ControllerTemplate starter = (CharacterPersona.ControllerTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.AssasinTemplate))
                {
                    CharacterPersona.AssasinTemplate starter = (CharacterPersona.AssasinTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                #endregion

                return damageGiven;
            }

            public int HealthLoss(int damageGiven)
            {
                Instance.PhysicalDamageTaken = (int)(damageGiven * 0.4);
                Instance.MagicalDamageTaken = (int)(damageGiven * 0.6);
                Instance.PhysicalDamageTaken -= Instance.Armour;
                Instance.MagicalDamageTaken -= Instance.MagicRes;
                int damageTaken = Instance.MagicalDamageTaken + Instance.PhysicalDamageTaken;
                Instance.Health -= damageTaken;
                return damageTaken;
            }

            #endregion
        }
        #endregion
        #region AssasinCharacter Template

        public class AssasinTemplate: CharacterPersona, ICardTraits, ICharacterTraits, IAssasinTraits
        {
            public static AssasinTemplate Instance { get; set; }
            public AssasinTemplate()
            {
                Instance = this;
            }


            #region Character Variables

            public string CharacterName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public string CharacterDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public bool DefaultValue { get { return DefaultValue; } set { DefaultValue = true; } }
            public int Health
            {
                get { return Health; }
                set
                {
                    if (Health < 0) Health = 0;
                    if (DefaultValue==true)
                    {
                        if (Foe == false)
                        {
                            Health = 50;
                        }
                        else
                        {
                            Health = 15;
                        }

                    }
                }
            }
            public int dodge
            {
                get { return dodge; }
                set
                {
                    if (dodge < 0) dodge = 0;
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            dodge = 15;
                        }
                        else
                        {
                            dodge = 5;
                        }

                    }
                }
            }
            public int Speed
            {
                get { return Speed; }
                set
                {
                    if (Speed < 0) Speed = 0;
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            Speed = 6;
                        }
                        else
                        {
                            Speed = 5;
                        }

                    }
                }
            }
            public double CritC
            {
                get { return CritC; }
                set
                {
                    if (CritC < 0) CritC = 0;
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            CritC = 10;
                        }
                        else
                        {
                            CritC = 5;
                        }

                    }
                }
            }
            public int MagicRes
            {
                get { return MagicRes; }
                set
                {
                    if (MagicRes < 0) MagicRes = 0;
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            MagicRes = 3;
                        }
                        else
                        {
                            MagicRes = 5;
                        }

                    }
                }
            }
            public int Armour
            {
                get { return Armour; }
                set
                {
                    if (Armour < 0) Armour = 0;
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            Armour = 3;
                        }
                        else
                        {
                            Armour = 5;
                        }

                    }
                }
            }
            public int Damage
            {
                get { return Damage; }
                set
                {
                    if (Damage < 0) Damage = 0;
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            if (LowDamageAssasin == true)
                            {
                                Damage = 10;
                            }
                            else
                            {
                                Damage = 10;
                            }
                        }
                        else
                        {
                            if (LowDamageAssasin == true)
                            {
                                Damage = 1;
                            }
                            else
                            {
                                Damage = 10;
                            }
                        }

                    }
                }
            }
            public int Accuracy
            {
                get { return Accuracy; }
                set
                {
                    if (DefaultValue == true)
                    {
                        if (Foe == false)
                        {
                            Accuracy = 100;
                        }
                        else
                        {
                            Accuracy = 0;
                        }
                    }
                    if (Accuracy < 0) Accuracy = 0;
                }
            }
            public int Mana { get { return Mana; } set { if (Mana > 100) Mana = 100; if (Mana < 0) Mana = 0; } }
            public int Stamina { get { return Stamina; } set { if (Stamina > 100) Stamina = 100; if (Stamina < 0) Stamina = 0; } }
            public int ExpPoints
            {
                get { return ExpPoints; }
                set
                {
                    if (true/*sessionStarted?*/)
                    {
                        Instance.ExpPoints += NewEarnedXp;
                    }
                    if (Instance.ExpPoints > 1000)
                    {
                        Instance.LevelIncrease();
                        Instance.ExpPoints -= 1000;
                    }
                }
            }
            public int NewEarnedXp
            {
                get { return NewEarnedXp; }
                set
                {
                    if (EarnedXp == true)
                    {
                        Instance.NewEarnedXp = NewEarnedXp;
                    }
                    else
                    {
                        Instance.NewEarnedXp = 0;
                    }
                }
            }
            public bool EarnedXp
            {
                get { return EarnedXp; }
                set
                {
                    if (true)
                    {
                        //SessionOver?EarnedXp=false;
                    }
                }
            } //This bool is made true when XPIncrease is fired and should be made of when sessionOver is true

            public string BriefDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public List<string> NaturalAllies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public List<string> NaturalEnemies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool Foe { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool PassiveAssasinTraits { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool LowDamageAssasin { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public int MagicalDamageTaken { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public int PhysicalDamageTaken { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public int HitCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            #endregion
            #region Character Methods


            public void passiveTraits()
            {
                throw new NotImplementedException();
            }

            public void LevelIncrease()
            {
                Instance.ExperienceLevel++;
                if (Foe == false)
                {
                    Instance.Health += 12 * Instance.ExperienceLevel;
                    Instance.dodge += 6 * Instance.ExperienceLevel;
                    Instance.Speed += 3 * Instance.ExperienceLevel;
                    Instance.CritC += 3 * Instance.ExperienceLevel;
                    Instance.MagicRes += 2 * (Instance.ExperienceLevel - 2);
                    Instance.Armour += 2 * (Instance.ExperienceLevel - 2);
                    if (LowDamageAssasin == true) Instance.Damage += 6 * Instance.ExperienceLevel;
                    else
                    {
                        Instance.Damage += 7 * Instance.ExperienceLevel;
                    }
                    //fire levelIncrease animation
                }
                else
                {
                    Instance.Health += 5 * Instance.ExperienceLevel;
                    Instance.dodge += 2 * Instance.ExperienceLevel;
                    Instance.Speed += 1 * Instance.ExperienceLevel;
                    Instance.CritC += 1 * Instance.ExperienceLevel;
                    Instance.MagicRes += 0 * Instance.ExperienceLevel;
                    Instance.Armour += 0 * Instance.ExperienceLevel;
                    if (LowDamageAssasin == true) Instance.Damage += 1 * Instance.ExperienceLevel;
                    else
                    {
                        Instance.Damage += 2 * Instance.ExperienceLevel;
                    }
                    //fire levelIncrease animation
                }
            }

            public void XPIncrease(bool earnXp, int newEarnedXp)
            {
                EarnedXp = earnXp;
                NewEarnedXp = newEarnedXp;
            }

            public void ActiveBuff()
            {
                throw new NotImplementedException();
            }

            public void ActiveDeBuff()
            {
                throw new NotImplementedException();
            }

            public void TraitLevelUpActivation(int experienceLevel, List<Items> Items)
            {
                throw new NotImplementedException();
            }

            public int DamageGiven(object CharacterInstance)
            {
                int damageGiven = 0;
                if (Foe == false)
                {
                    Random r = new Random();
                    damageGiven = r.Next(10, 11);
                }
                else
                {
                    Random r = new Random();
                    damageGiven = r.Next(1, 11);
                }

                #region template logic


                if (CharacterInstance.GetType() == typeof(CharacterPersona.WarriorTemplate))
                {
                    CharacterPersona.WarriorTemplate starter = (CharacterPersona.WarriorTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.TankWarriorTemplate))
                {
                    CharacterPersona.TankWarriorTemplate starter = (CharacterPersona.TankWarriorTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.RangeTemplate))
                {
                    CharacterPersona.RangeTemplate starter = (CharacterPersona.RangeTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.MageTemplate))
                {
                    CharacterPersona.MageTemplate starter = (CharacterPersona.MageTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.ControllerTemplate))
                {
                    CharacterPersona.ControllerTemplate starter = (CharacterPersona.ControllerTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                if (CharacterInstance.GetType() == typeof(CharacterPersona.AssasinTemplate))
                {
                    CharacterPersona.AssasinTemplate starter = (CharacterPersona.AssasinTemplate)CharacterInstance;
                    starter.HealthLoss(damageGiven);
                }
                #endregion

                return damageGiven;
            }

            public int HealthLoss(int damageGiven)
            {
                Instance.PhysicalDamageTaken = (int)(damageGiven * 0.4);
                Instance.MagicalDamageTaken = (int)(damageGiven * 0.6);
                Instance.PhysicalDamageTaken -= Instance.Armour;
                Instance.MagicalDamageTaken -= Instance.MagicRes;
                int damageTaken = Instance.MagicalDamageTaken + Instance.PhysicalDamageTaken;
                Instance.Health -= damageTaken;
                return damageTaken;
            }

            #endregion
        }
        #endregion


    }
}
