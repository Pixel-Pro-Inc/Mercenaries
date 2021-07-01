using Assets.TraitInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Entities
{
    class Minions: Cards
    {
        //here I made a different class for minions cause I didn't think they will work the same as characters. 
        //All they would have in my mind is the passive traits defined and their unique behaviours. 
        //I also think that minions will be a consumable card Unlike characters that can be played againand again

        //Here you might want to declare the passivetraits/methods as well
        public enum MasterCharacterList
        {
            //Here a list of every individual character will be defined.Then they will be accessed with their indexes as needed in below lists eg List<>Allies
        }


        #region GivenMinionTraits

        //Over here im thinking of just having  a enum of all the characters and when you want to get the enemies and allies and masters, you just use the index
        //as a way of acessing the names

        public List<string> Master { get; set; }
        public List<string> Allies { get; set; }
        public List<string> Enemies { get; set; }
        public enum Species
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

        public class GlowBuddy : Minions, IMinionBehaviours
        {
            public int Health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public int Stamina { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public string MinionName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public string MinionDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public List<string> NaturalAllies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public List<string> NaturalEnemies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public bool ActivationRequireMent()
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

            public void WeirdAction()
            {
                throw new NotImplementedException();
            }

            public void WeirdDance()
            {
                throw new NotImplementedException();
            }

            public void WeirdVoice()
            {
                throw new NotImplementedException();
            }
        }
        public class DevilCritter : Minions, IMinionBehaviours
        {
            public int Health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public int Stamina { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public string MinionName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public string MinionDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public void UniqueActiveBuff()
            {
                throw new NotImplementedException();
            }

            public void UniqueActiveDeBuff()
            {
                throw new NotImplementedException();
            }

            public void WeirdAction()
            {
                throw new NotImplementedException();
            }

            public void WeirdDance()
            {
                throw new NotImplementedException();
            }

            public void WeirdVoice()
            {
                throw new NotImplementedException();
            }
        }
    }
}
