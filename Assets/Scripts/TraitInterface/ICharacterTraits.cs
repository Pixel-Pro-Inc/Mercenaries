using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.TraitInterface
{
    interface ICharacterTraits
    {
        /*
         Here we declare all the traits expected of anything (Anyone) that can be described as a character (For both playable and NPC)
         */
        string CharacterName { get; set; }
        string CharacterDescription { get; set; } //Here the personality and backstory of a unique character will be defined
       
        #region Abilities

        void UniqueActiveBuff();
        void UniqueActiveDeBuff();


        #endregion
        #region Stats

        //I was having trouble setting the properties of these varibale with limitations. Something about 'targert runtime doesnt support default interface implementation' 
        int Health
        {
            get; set;
            //get { return Health; }
            //set { if (Health > 100) { Health = 100; } }
        }
        int Mana
        {
            get; set;
            // get { return Mana; }
            //set { if (Mana > 100) { Mana = 100; } 

            // We never discussed if Mana was going to be used so I just put it cause, I mean RPG right, we have to nerf the characters somehow right.
            //Pluss in my head the cards that a character will be able to use from the many cards on deck will be dependant on the amount of mana the individual 
            //character has currently
        }
        int Stamina //I assume the hunger method will affect this trait
        {
            get; set;
            // get { return Stamina; }
            //set { if (Stamina > 100) { Stamina = 100; } 
        }
        int ExpPoints { get; set; }//set=> if(expPoints>1000){instance.ExperinceLevel.Index++; expPoints=0;}
        #endregion

    }
}
