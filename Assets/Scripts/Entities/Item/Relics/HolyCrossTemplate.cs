using Assets.Scripts.Entities.Item.Relics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Entities.Item
{
    class HolyCrossTemplate : RelicClass
    {
        public static HolyCrossTemplate Instance { get; set; }
        public HolyCrossTemplate()
        {
            Instance = this;
        }

        public override void Activate(object CharacterInstance)
        {
            //Within the food, Here the effects will be coded
            Debug.Log("You didn't put the logic to put the effects");
        }
        public override void Deactivate(object CharacterInstance)
        {
            //Within the food, Here the effects will be removed
            Debug.Log("You didn't put the logic to remove the effects");
        }
        public override bool WorthyorNot(object CharacterInstance)
        {
            //Here in the food the character is checked to see if they qualify
            Debug.Log("You didn't put the logic to check if that person can equip the item");
            return false;
        }

    }
}
