using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.TraitInterface
{
    interface IMinionBehaviours
    {
        /*
         Here we declare all the traits expected of anything that can be described as a Minion 
         */
        public string MinionName { get; set; }
        public string MinionDescription { get; set; } //Here the description of the minion will be defined
        public List<string> NaturalAllies { get; set; }
        public List<string> NaturalEnemies { get; set; }
        public bool ActivationRequireMent();

        #region Abilities

        //Here you might want to declare the passivetraits/methods as well


        public void UniqueActiveBuff();
        public void UniqueActiveDeBuff();


        #endregion
        #region Stats

        //I didn't think Minions needed Mana cause not only are they nonplayable charactera but they also cant actually fight by themselves or have combat logic
        //I imagine that a character would simply expend life or mana to summon a number of minions which in turn do actions or simply exists and frolic and then 
        //perform whatever desired action


        //I was having trouble setting the properties of these varibale with limitations. Something about 'targert runtime doesnt support default interface implementation' 
        public int Health
        {
            get; set;
            //get { return Health; }
            //set { if (Health > 100) { Health = 100; } }
        }
        public int Stamina //I assume the hunger method will affect this trait
        {
            get; set;
            // get { return Stamina; }
            //set { if (Stamina > 100) { Stamina = 100; } 
        }
        #endregion
        #region WeirdBehaviours

        //Here i thought of including all the weird dances and jumps and sounds It might make or do

        public void WeirdDance();
        public void WeirdVoice();
        public void WeirdAction();
        #endregion
    }
}
