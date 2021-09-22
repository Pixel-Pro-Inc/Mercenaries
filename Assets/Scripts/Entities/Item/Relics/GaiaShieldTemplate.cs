using Assets.Scripts.Entities.Item.Relics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Entities.Item
{
    class GaiaShieldTemplate : RelicClass
    {
        public override void Activate(object CharacterInstance)
        {
            int OwnerArmourpercent = (int)(Owner.Armour * 0.1);
            Owner.Armour += OwnerArmourpercent;
            armourICache += OwnerArmourpercent;

            int OwnerMagRespercent= (int)(Owner.MagicRes * 0.1);
            Owner.MagicRes += OwnerMagRespercent;
            magresICache += OwnerMagRespercent;
        }
        public override void Deactivate(object CharacterInstance)
        {
            Owner.Armour -= armourICache;
            Owner.MagicRes -= magresICache;
        }
        public override bool WorthyorNot(object CharacterInstance)
        {
            //Here in the food the character is checked to see if they qualify
            Debug.Log("You didn't put the logic to check if that person can equip the item");
            return false;
        }

    }
}
