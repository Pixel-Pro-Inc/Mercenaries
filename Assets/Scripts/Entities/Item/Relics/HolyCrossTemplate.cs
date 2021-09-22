using Assets.Scripts.Entities.Item.Relics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Entities.Item
{
    class HolyCrossTemplate : RelicClass
    {

        public override void Activate(object CharacterInstance)
        {
            int OwnerHealthpercent = (int)(Owner.Health * 0.1);
            Owner.Health += OwnerHealthpercent;
            healthICache += OwnerHealthpercent;
        }

        public override void Deactivate(object CharacterInstance)
        {
            Owner.Health -= healthICache;
        }
        public override bool WorthyorNot(object CharacterInstance)
        {
            //Here in the food the character is checked to see if they qualify
            Debug.Log("You didn't put the logic to check if that person can equip the item");
            return false;
        }

    }
}
