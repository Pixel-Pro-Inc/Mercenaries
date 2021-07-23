using Assets.Entities;
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

        The reason we did it here instead of just defining it in CharacterPersona is that each class that will implement this interface will have 
        different values of individual properties
         */
        string CharacterName { get; set; }
        string CharacterDescription { get; set; } //Here the personality and backstory of a unique character will be defined


        #region Stats

        bool DefaultValue { get; set; }

        int Health { get; set; }
        int dodge { get; set; }
        int Speed { get; set; }
        double CritC { get; set; }
        int MagicRes { get; set; }
        int Armour { get; set; }
        int Damage { get; set; }
        int HitCount { get; set; }
        int DamageGiven();
        int HealthLoss(int damageGiven);
        int Accuracy { get; set; }


        int Mana
        {
            get; set;
            // We never discussed if Mana was going to be used so I just put it cause, I mean RPG right, we have to nerf the characters somehow right.
            //Pluss in my head the cards that a character will be able to use from the many cards on deck will be dependant on the amount of mana the individual 
            //character has currently
        }
        int Stamina { get; set; }//I assume the hunger method will affect this trait

        double PowerBuffPercent { get; set; } //Each character has their own percent buff and even this can be improved so yeah
        double EvadeBuffPercent { get; set; } //This is here for aware
        double AgileBUffPercent {get; set;}
        double HealBuffPercent { get; set; }
        object ProtectionSponser { get; set; }

        int MagicalDamageTaken { get; set; }
        int PhysicalDamageTaken { get; set; }


        int ExpPoints { get; set; }
        int NewEarnedXp { get; set; }
        bool EarnedXp {get;set;}

        void LevelIncrease();
        void XPIncrease(bool earnXp, int newEarnedXp);

        void TraitLevelUpActivation( int experienceLevel, List<Items> Items);

        #endregion

    }
}
