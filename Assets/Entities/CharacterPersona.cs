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
        In my mind each one will be of Type 'Class' but I am open to debate on whats the better choice. Cause it is a little unclear how the information
        is going to be handled and manipulated in the ObjectModels class
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


        //Over here im thinking of just having  a enum of all the characters and when you want to get the enemies and allies and masters, you just use the index
        //as a way of acessing the names
        
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
        #endregion
        //below is an example of how peter is going to be defined
        public class Peter : CharacterPersona, ICharacterTraits, IWarriorTraits
        {
            public string CharacterName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
            public string BriefDescription { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
            public int Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
            public int Mana { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
            public int Stamina { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
            public string CharacterDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public List<string> NaturalAllies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public List<string> NaturalEnemies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool PassiveWarriorTraits { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            //Here you might want to declare the passivetraits/methods as well


            //string CitizenOf = (string)Peter.Kingdom.DarkSyde; // Here I was just experimenting to see how the citizenship can be set
            //After We figure out how to set the respective variables to the specific enum value I want to use peter as a reference for other characters so we
            //forget to include the correct and necesary info

            public void ActiveBuff()
            {
                throw new System.NotImplementedException();
               // this.Mana++;  I just put this up so that I know to change the stats and other variables on command
            }

            public void ActiveDeBuff()
            {
                throw new System.NotImplementedException();
            }

            public void UniqueActiveBuff()
            {
                throw new System.NotImplementedException("UniqueActiveBuff was not set");
            }

            public void UniqueActiveDeBuff()
            {
                throw new System.NotImplementedException("UniqueActiveDeBuff was not set");
            }
        }

    }
}
