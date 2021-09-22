using Assets.Scripts.Entities.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using UnityEngine;
using static Assets.Scripts.Models.Enums;

namespace Assets.Scripts.Entities.Item.Food
{
    class FoodClass : ItemTemplate
    {
        public override string ItemName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string ItemDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override Persona Owner { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override bool Relic { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override bool BeingUsed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        List<object> Silo = new List<object>(); //List of the Characters food that it has

        public void CreateFood(FoodType food)
        {
            switch (food)
            {
                case FoodType.Meat:
                    Meat meat = new Meat();
                    Silo.Add(meat);
                    break;
                case FoodType.Grain:
                    break;
                case FoodType.Vegetables:
                    break;
                default:
                    break;
            }
        }

        #region Item Ation

        public override bool ActivationRequireMent(object CharacterInstance)
        {
            Owner = (Persona)CharacterInstance;
            if (CanChew(Owner))
            {
                Equip();
            }
            return BeingUsed;
        }

        public override void Equip()
        {
            BeingUsed = true;// This has to be first otherwise the values wont change
            passiveTraits();
            Eat(Owner);
            Timer Boom;
            Boom = new Timer();
            // Tell the timer what to do when it elapses
            Boom.Elapsed += new ElapsedEventHandler(Punch);
            // Set it to go off every one seconds
            Boom.Interval = 900000;// 15 minutes
            Debug.Log("Yewo here im not sure how its going to be dont but i set it to 15 minutes, i dont know if it will work even when the app is off, How will I use DateTime here");
            // And start it        
            Boom.Enabled = true;

            void Punch(object source2, ElapsedEventArgs e)
            {
                Remove();
                Boom.Close();
            }
        }
        public override void Remove()
        {
            RemoveEffects(Owner);
            BeingUsed = false;
        }

        //The UniqueBuffs below will be called on purpose, not randomly when first made
        public virtual void UniqueActiveBuff()
        {
            Debug.Log("Food isnt supposed to have unique effects, It works the same for everyone. So yeah its redundant to do uniqueActiveBuff");
        }
        public virtual void UniqueActiveDeBuff()
        {
            Debug.Log("Food isnt supposed to have unique effects, It works the same for everyone. So yeah its redundant to do uniqueActiveBuff");
        }

        #endregion

        public virtual void Eat(object CharacterInstance)
        {
            //Within the food, Here the effects will be coded
            Debug.Log("You didn't put the logic to put the effects");
        }
        public virtual void RemoveEffects(object CharacterInstance)
        {
            //Within the food, Here the effects will be removed
            Debug.Log("You didn't put the logic to remove the effects");
        }
        public virtual bool CanChew(object CharacterInstance)
        {
            //Here in the food the character is checked to see if they qualify
            Debug.Log("You didn't put the logic to check if that person can equip the item");
            return false;
        }

    }
}
