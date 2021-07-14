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
    public class CharacterPersona: Cards
    {
        /*
         Here I planned on defining each unique character and all their traits and abilities (methods).
        In my mind each one will be of Type 'Class' and so this will just be used as a reference for their names.
        When you want to get the names of enemies and allies and masters, you 
        just use the index to get the unique string that will be passed to access the class Instance with the name desired.
         */
        public enum MasterCharacterList
        {
            //Here a list of every individual character will be defined.Then they will be accessed with their indexes as needed in below lists eg List<>Allies
        }


        //Be sure to define the passive traits!!!!!!!!!
        //and the costs if there are any!!!!!!!!


        #region GivenCharacterTraits

        //I wasn't able to implement these enums with the respective interfaces, so i simply made the class have the atrributes, so that the subclass
        //(Unique individuals) inhert those traits
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
            Triton
        };
        internal int ExperienceLevel { get { return ExperienceLevel;  } set { if (ExperienceLevel < 0) ExperienceLevel = 0; } }

        #endregion
        #region Items 

        Items.HolyCrossTemplate HolyCrossItem = new Items.HolyCrossTemplate();
        Items.Nth_Metal Nth_Metal_Item = new Items.Nth_Metal();


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



            #endregion
            #region Character Methods

            //Here are the passive traits of the card themselves
            void ICardTraits.passiveTraits()
            {
                
            }

            //string CitizenOf = (string)WarriorTemplate.Kingdom.DarkSyde; // Here I was just experimenting to see how the citizenship can be set
            //After We figure out how to set the respective variables to the specific enum value I want to use peter as a reference for other characters so we
            //forget to include the correct and necesary info


            
            

            //Default Methods of Character Combantant type
            public void ActiveBuff()
            {
                #region Passive option 2 Warrior

                //Passive 2 - Stacks atack speed up to 5 times (5% each)

                int CacheSpeed = 0;
                int StackCount = 5;
                int StackSpeed()
                {
                    if (StackCount > 0)
                    {
                        Instance.Speed += (int)(Instance.Speed * 0.05);
                        CacheSpeed += (int)(Instance.Speed * 0.05);
                        StackCount--;
                    }
                    else
                    {
                        //Print " cannot stack any more" or "Stack limit reached"
                    }
                    return Instance.Speed;
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

            //Unique Methods to Character
            public void UniqueActiveBuff()
            {
                throw new System.NotImplementedException("UniqueActiveBuff was not set");
            }
            public void UniqueActiveDeBuff()
            {
                throw new System.NotImplementedException("UniqueActiveDeBuff was not set");
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

            public int HealthLoss()
            {
                Instance.PhysicalDamageTaken -= Instance.Armour;
                Instance.MagicalDamageTaken -= Instance.MagicRes;
                int damageTaken = Instance.MagicalDamageTaken + Instance.PhysicalDamageTaken;
                return damageTaken;
            }

            public void TraitLevelUpActivation(int experienceLevel, List<Items> Items)
            {
                throw new NotImplementedException();
            }

            public int DamageGiven()
            {
                int damageGiven = 0;
                if (Foe==false)
                {
                    Random r = new Random();
                    damageGiven = r.Next(14, 20);
                }
                else
                {
                    Random r = new Random();
                    damageGiven = r.Next(3, 7);
                }

                return damageGiven;
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
            

            #endregion
            #region Character Methods

            void ICardTraits.passiveTraits()
            {
                
            }

            public void UniqueActiveBuff()
            {
                throw new NotImplementedException();
            }

            public void UniqueActiveDeBuff()
            {
                throw new NotImplementedException();
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
                 */
                int percentageHealthLoss = (int)(HealthLoss() / Health);
                int CacheArmour = 0;
                int CacheMagicalresistance = 0;
                for (int per = 0; per < percentageHealthLoss; per++)
                {
                    Instance.Armour += (int)(Instance.Armour * 0.02);
                    CacheArmour += (int)(Instance.Armour * 0.02);
                    Instance.MagicRes += (int)(Instance.MagicRes * 0.02);
                    CacheMagicalresistance += (int)(Instance.MagicRes * 0.02);
                }
                if (true/*GameOver==true*/)
                {
                    Instance.Armour -= CacheArmour;
                    Instance.MagicRes -= CacheMagicalresistance;
                    CacheArmour = 0;
                    CacheMagicalresistance = 0;
                }
                #endregion
            }

            public void ActiveDeBuff()
            {
                throw new NotImplementedException();
            }

            public int HealthLoss()
            {
                Instance.PhysicalDamageTaken -= Instance.Armour;
                Instance.MagicalDamageTaken -= Instance.MagicRes;
                int damageTaken = Instance.MagicalDamageTaken + Instance.PhysicalDamageTaken;
                return damageTaken;
            }

            public void TraitLevelUpActivation(int experienceLevel, List<Items> Items)
            {
                throw new NotImplementedException();
            }

            public int DamageGiven()
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

                return damageGiven;
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
            
            #endregion
            #region Character Methods

            void ICardTraits.passiveTraits()
            {
                throw new NotImplementedException();
            }
            public void UniqueActiveBuff()
            {
                throw new NotImplementedException();
            }

            public void UniqueActiveDeBuff()
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

            public int HealthLoss()
            {
                Instance.PhysicalDamageTaken -= Instance.Armour;
                Instance.MagicalDamageTaken -= Instance.MagicRes;
                int damageTaken = Instance.MagicalDamageTaken + Instance.PhysicalDamageTaken;
                return damageTaken;
            }

            public void TraitLevelUpActivation(int experienceLevel, List<Items> Items)
            {
                throw new NotImplementedException();
            }

            public int DamageGiven()
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
                return damageGiven;
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
           
            #endregion
            #region Character Methods

            void ICardTraits.passiveTraits()
            {
               
            }

            public void UniqueActiveBuff()
            {
                throw new NotImplementedException();
            }

            public void UniqueActiveDeBuff()
            {
                throw new NotImplementedException();
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

            public int HealthLoss()
            {
                Instance.PhysicalDamageTaken -= Instance.Armour;
                Instance.MagicalDamageTaken -= Instance.MagicRes;
                int damageTaken = Instance.MagicalDamageTaken + Instance.PhysicalDamageTaken;
                return damageTaken;
            }

            public void TraitLevelUpActivation(int experienceLevel, List<Items> Items)
            {
                throw new NotImplementedException();
            }

            public int DamageGiven()
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
                return damageGiven;
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
           
            #endregion
            #region Character Methods

            void ICardTraits.passiveTraits()
            {
                throw new NotImplementedException();
            }

            public void UniqueActiveBuff()
            {
                throw new NotImplementedException();
            }

            public void UniqueActiveDeBuff()
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

            public int HealthLoss()
            {
                Instance.PhysicalDamageTaken -= Instance.Armour;
                Instance.MagicalDamageTaken -= Instance.MagicRes;
                int damageTaken = Instance.MagicalDamageTaken + Instance.PhysicalDamageTaken;
                return damageTaken;
            }

            public void TraitLevelUpActivation(int experienceLevel, List<Items> Items)
            {
                throw new NotImplementedException();
            }

            public int DamageGiven()
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
                return damageGiven;
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
            #endregion
            #region Character Methods


            void ICardTraits.passiveTraits()
            {
                throw new NotImplementedException();
            }

            public void UniqueActiveBuff()
            {
                throw new NotImplementedException();
            }

            public void UniqueActiveDeBuff()
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

            public int HealthLoss()
            {
                Instance.PhysicalDamageTaken -= Instance.Armour;
                Instance.MagicalDamageTaken -= Instance.MagicRes;
                int damageTaken = Instance.MagicalDamageTaken + Instance.PhysicalDamageTaken;
                return damageTaken;
            }

            public void TraitLevelUpActivation(int experienceLevel, List<Items> Items)
            {
                throw new NotImplementedException();
            }

            public int DamageGiven()
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
                return damageGiven;
            }

            #endregion
        }
        #endregion


    }
}
