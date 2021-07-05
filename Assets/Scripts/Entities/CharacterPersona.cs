using Assets.Scripts.TraitInterface;
using Assets.TraitInterface;
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
            public int Health { get { return Health; } set { if (Health > 100)Health = 100; if (Health < 0) Health = 0; } }
            public int Mana { get { return Mana; } set { if (Mana > 100) Mana = 100; if (Mana < 0) Mana = 0; } }
            public int Stamina { get { return Stamina; } set { if (Stamina > 100) Stamina = 100; if (Stamina < 0) Stamina = 0; } }
            public string CharacterDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public List<string> NaturalAllies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public List<string> NaturalEnemies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool PassiveWarriorTraits { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
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
            public void passiveTraits()
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
                //The only place ExperienceLevel is defined is in the CharacterPersona class and its used only here so far
                Instance.ExperienceLevel++;
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
    }
}
