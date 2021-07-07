using Assets.Scripts.TraitInterface;
using Assets.TraitInterface;
using Assets.TraitInterface.CombantantType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Entities
{
    class CharacterPersona: Cards
    {
        /*
         Here I planned on defining each unique character and all their traits and abilities (methods).
        In my mind each one will be of Type 'Class' and so this will just be used as a reference for their names.
        When you want to get the names of enemies and allies and masters, you 
        just use the index to get the unique string that will be passed to access the class instance with the name desired.
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
            Triton,
            Unknown
        };
        internal int ExperienceLevel;
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
            public int Health { get { return Health; } set { Health = 33; if (Health > 100)Health = 100; if (Health < 0) Health = 0; } }
            public int dodge { get => throw new NotImplementedException(); set { dodge = 6; } }
            public int Speed { get => throw new NotImplementedException(); set { Speed = 1; } }
            public double CritC { get => throw new NotImplementedException(); set { CritC = 6; } }
            public int MagicRes { get => throw new NotImplementedException(); set { MagicRes = 2; } }
            public int Armour { get => throw new NotImplementedException(); set { Armour = 2; } }
            public int Damage 
            {
                get { return Damage; }
                set 
                {
                    if (LowDamageWarrior==true)
                    {
                        Damage = 8;
                    }
                    else
                    {
                        Damage = 13;
                    }
                } 
            }


            public int Mana { get { return Mana; } set { if (Mana > 100) Mana = 100; if (Mana < 0) Mana = 0; } }
            public int Stamina { get { return Stamina; } set { if (Stamina > 100) Stamina = 100; if (Stamina < 0) Stamina = 0; } }
            public string CharacterDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public List<string> NaturalAllies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public List<string> NaturalEnemies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool PassiveWarriorTraits { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool LowDamageWarrior { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
            

            #endregion
            #region Character Methods

            //Here are the passive traits of the card themselves
            public new void passiveTraits()
            {
                throw new NotImplementedException();
            }

            //string CitizenOf = (string)WarriorTemplate.Kingdom.DarkSyde; // Here I was just experimenting to see how the citizenship can be set
            //After We figure out how to set the respective variables to the specific enum value I want to use peter as a reference for other characters so we
            //forget to include the correct and necesary info



            //Default Methods of Character Combantant type
            public void ActiveBuff()
            {
                throw new System.NotImplementedException();
                // this.Mana++;  I just put this up so that I know to change the stats and other variables on command
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
                Instance.Health += 10;
                Instance.dodge += 2;
                Instance.Speed += 2;
                Instance.CritC += 1;
                Instance.MagicRes += 1;
                Instance.Armour += 1;
                if (LowDamageWarrior == true) Instance.Damage += 3;
                else
                {
                    Instance.Damage += 2;
                }
                //fire levelIncrease animation
            }
            public void XPIncrease(bool earnXp, int newEarnedXp)
            {
                EarnedXp = earnXp;
                NewEarnedXp = newEarnedXp;
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
            public int Health { get { return Health; } set { Health = 35; if (Health > 100) Health = 100; if (Health < 0) Health = 0; } }
            public int dodge { get { return dodge; } set { dodge = 1; } }
            public int Speed { get { return Speed; } set { Speed = 1; } }
            public double CritC { get { return CritC; } set { CritC = 8; } }
            public int MagicRes { get { return MagicRes; } set { MagicRes = 5; } }
            public int Armour { get { return Armour; } set { Armour = 3; } }
            public int Damage
            {
                get { return Damage; }
                set
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
            }
            public int Mana { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public int Stamina { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
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
            public bool PassiveTankTraits { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool LowDamageTankWarrior { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
                Instance.Health += 12;
                Instance.dodge += 1;
                Instance.Speed += 1;
                Instance.CritC += 1;
                Instance.MagicRes += 1;
                Instance.Armour += 2;
                if (LowDamageTankWarrior == true) Instance.Damage += 2;
                else
                {
                    Instance.Damage += 2;
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
            public int Health { get { return Health; } set { Health = 28; if (Health > 100) Health = 100; if (Health < 0) Health = 0; } }
            public int dodge { get { return dodge; } set { dodge = 8; } }
            public int Speed { get { return Speed; } set { Speed = 6; } }
            public double CritC { get { return CritC; } set { CritC = 6; } }
            public int MagicRes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public int Armour { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public int Damage
            {
                get { return Damage; }
                set
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
            public bool PassiveRangeTraits { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool LowDamageRange { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
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
                Instance.Health += 8;
                Instance.dodge += 4;
                Instance.Speed += 4;
                Instance.CritC += 2;
                if (ExperienceLevel>3)
                {
                    Instance.MagicRes += 1;
                    Instance.Armour += 1;
                }
                if (LowDamageRange == true) Instance.Damage += 2;
                else
                {
                    Instance.Damage += 3;
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
           
            #endregion
        }
        #endregion


    }
}
