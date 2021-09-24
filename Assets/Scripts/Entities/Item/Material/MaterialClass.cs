using Assets.Scripts.Entities.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Assets.Scripts.Models.Enums;

namespace Assets.Scripts.Entities.Item.Material
{
    class MaterialClass : ItemTemplate
    {
        public override string ItemName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string ItemDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override Persona Owner { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override bool NonConsumable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override bool BeingUsed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public List<MaterialClass> Shed = new List<MaterialClass>();
        static int InstantiatedCardNumber;
        public void CreateMaterial(MaterialType material)
        {
            switch (material)
            {
                case MaterialType.Wood:
                    Wood wood = new Wood();
                    wood.CardId = $"{(int)CardIdReference.MaterialCards}.0{(int)MaterialType.Wood}.00{InstantiatedCardNumber}"; InstantiatedCardNumber++;
                    Shed.Add(wood);
                    break;
                case MaterialType.Water:
                    break;
                case MaterialType.Earth:
                    break;
                case MaterialType.Stone:
                    break;
                case MaterialType.IronOre:
                    break;
                default:
                    break;
            }
        }

        #region Item Action

        public override bool ActivationRequireMent(object Worker)
        {
            Owner = (Persona)Worker; //WOrkerAnt and Persona share alot of simpliar methods so We just have to remeber that we shouldn't call any properties that WorkerAnt doesnt have
            if (QualityorNot(Owner))
            {
                Equip();
            }
            return BeingUsed;
        }
        public override void Equip()
        {
            BeingUsed = true;// This has to be first otherwise the values wont change
            passiveTraits();
            Use(Owner);
        }
        public override void Remove()
        {
            Abandon(Owner);
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

        public virtual void Use(object CharacterInstance)
        {
            //Within the food, Here the effects will be coded
            Debug.Log("You didn't put the logic to put the effects");
        }
        public virtual void Abandon(object CharacterInstance)
        {
            //Within the food, Here the effects will be removed
            Debug.Log("You didn't put the logic to remove the effects");
        }
        public virtual bool QualityorNot(object CharacterInstance)
        {
            //Here in the food the character is checked to see if they qualify
            Debug.Log("You didn't put the logic to check if that person can equip the item");
            return true;
        }

    }
}
