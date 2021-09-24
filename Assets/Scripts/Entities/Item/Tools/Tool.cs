using Assets.Scripts.Entities.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Assets.Scripts.Models.Enums;

namespace Assets.Scripts.Entities.Item.Tools
{
    class Tool : ItemTemplate
    {
        public override string ItemName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string ItemDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override Persona Owner { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override bool Relic { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override bool BeingUsed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Tool> Artillery = new List<Tool>();
        static int InstantiatedCardNumber;
        public void CreateTool(ToolType tool)
        {
            switch (tool)
            {
                case ToolType.PickAxe:
                    PickAxe pickAxe = new PickAxe();
                    pickAxe.CardId = $"{(int)CardIdReference.ToolCards}.0{(int)ToolType.PickAxe}.00{InstantiatedCardNumber}"; InstantiatedCardNumber++;
                    Artillery.Add(pickAxe);
                    break;
                case ToolType.Sickle:
                    break;
                case ToolType.Hoe:
                    break;
                case ToolType.Bow:
                    break;
                case ToolType.Anvil:
                    break;
                case ToolType.Stove:
                    break;
                case ToolType.Fabricator:
                    break;
                default:
                    break;
            }
        }

        #region Item Action

        public override bool ActivationRequireMent(object Worker)
        {
            Owner = (Persona)Worker; //WOrkerAnt and Persona share alot of simpliar methods so We just have to remeber that we shouldn't call any properties that WorkerAnt doesnt have
            if (HeavyorNot(Owner))
            {
                Equip();
            }
            return BeingUsed;
        }
        public override void Equip()
        {
            BeingUsed = true;// This has to be first otherwise the values wont change
            passiveTraits();
            Act(Owner);
        }
        public override void Remove()
        {
            Stop(Owner);
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

        public virtual void Act(object CharacterInstance)
        {
            //Within the food, Here the effects will be coded
            Debug.Log("You didn't put the logic to put the effects");
        }
        public virtual void Stop(object CharacterInstance)
        {
            //Within the food, Here the effects will be removed
            Debug.Log("You didn't put the logic to remove the effects");
        }
        public virtual bool HeavyorNot(object CharacterInstance)
        {
            //Here in the food the character is checked to see if they qualify
            Debug.Log("You didn't put the logic to check if that person can equip the item");
            return false;
        }
    }
}
