using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Entities.Item.Food
{
    class Grain:FoodClass
    {
        public static Grain Instance { get; set; }
        public Grain()
        {
            Instance = this;
        }

        public override void Eat(object CharacterInstance)
        {
            //Within the food, Here the effects will be coded
            Debug.Log("You didn't put the logic to put the effects");
        }
        public override void RemoveEffects(object CharacterInstance)
        {
            //Within the food, Here the effects will be removed
            Debug.Log("You didn't put the logic to remove the effects");
        }
        public override bool CanChew(object CharacterInstance)
        {
            //Here in the food the character is checked to see if they qualify
            Debug.Log("You didn't put the logic to check if that person can equip the item");
            return false;
        }
    }
}
