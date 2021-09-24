using Assets.Scripts.Entities.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Assets.Scripts.Models.Enums;

namespace Assets.Scripts.Entities.Item.Relics
{
    public class RelicClass : ItemTemplate
    {
        public override string ItemName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string ItemDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override Persona Owner { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override bool Relic { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override bool BeingUsed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        static int InstantiatedCardNumber;

        internal int healthICache=0; internal int manaICache = 0; internal int staminaICache = 0; internal int dodgeICache = 0; internal int speedICache = 0;
        internal int critCICache = 0; internal int magresICache = 0; internal int armourICache = 0; internal int damageICache = 0; internal int accuracyICache = 0;

        public List<object> Vault = new List<object>();
        public void CreateRelic(RelicType relic)
        {
            switch (relic)
            {
                case RelicType.NthMetal:
                    NthMetalTemplate Nth_Metal_Item = new NthMetalTemplate();
                    Nth_Metal_Item.CardId = $"{(int)CardIdReference.RelicCards}.0{(int)RelicType.NthMetal}.00{InstantiatedCardNumber}"; InstantiatedCardNumber++;
                    Vault.Add(Nth_Metal_Item);
                    break;
                case RelicType.HolyCross:
                    HolyCrossTemplate HolyCrossItem = new HolyCrossTemplate();
                    HolyCrossItem.CardId = $"{(int)CardIdReference.RelicCards}.0{(int)RelicType.HolyCross}.00{InstantiatedCardNumber}"; InstantiatedCardNumber++;
                    Vault.Add(HolyCrossItem);
                    break;
                case RelicType.GaiaShield:
                    GaiaShieldTemplate GaiaShieldTemplate = new GaiaShieldTemplate();
                    GaiaShieldTemplate.CardId = $"{(int)CardIdReference.RelicCards}.0{(int)RelicType.GaiaShield}.00{InstantiatedCardNumber}"; InstantiatedCardNumber++;
                    Vault.Add(GaiaShieldTemplate);
                    break;
                default:
                    break;
            }
        }

        #region Item Action

        public override bool ActivationRequireMent(object CharacterInstance)
        {
            Owner = (Persona)CharacterInstance;
            if (WorthyorNot(Owner))
            {
                Equip();
            }
            return BeingUsed;
        }

        public override void Equip()
        {
            BeingUsed = true;// This has to be first otherwise the values wont change
            passiveTraits();
            Activate(Owner);
        }
        public override void Remove()
        {
            Deactivate(Owner);
            BeingUsed = false;
        }

        //The UniqueBuffs below will be called on purpose, not randomly when first made
        public virtual void UniqueActiveBuff()
        {
            throw new NotImplementedException();
        }
        public virtual void UniqueActiveDeBuff()
        {
            throw new NotImplementedException();
        }


        #endregion

        public virtual void Activate(object CharacterInstance)
        {
            //Within the food, Here the effects will be coded
            Debug.Log("You didn't put the logic to put the effects");
        }
        public virtual void Deactivate(object CharacterInstance)
        {
            //Within the food, Here the effects will be removed
            Debug.Log("You didn't put the logic to remove the effects");
        }
        public virtual bool WorthyorNot(object CharacterInstance)
        {
            //Here in the food the character is checked to see if they qualify
            Debug.Log("You didn't put the logic to check if that person can equip the item");
            return false;
        }

    }
}
