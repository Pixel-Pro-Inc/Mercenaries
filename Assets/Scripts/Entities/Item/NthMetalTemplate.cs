using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Entities.Item
{
    class NthMetalTemplate : ItemTemplate
    {
        public static NthMetalTemplate Instance { get; set; }
        public NthMetalTemplate()
        {
            Instance = this;
        }
        public override string ItemName { get; set; }
        public override string ItemDescription { get; set; }
        public override int Owner { get; set; }
        public override object Ownertype { get; set; }
        public override bool Relic { get; set; }
        public override bool BeingUsed { get; set; }

        #region ItemActions
        public override bool ActivationRequireMent(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public override void Equip()
        {
            throw new NotImplementedException();
        }

        public override void Remove()
        {
            throw new NotImplementedException();
        }

        public override void UniqueActiveBuff()
        {
            throw new NotImplementedException();
        }

        public override void UniqueActiveDeBuff()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
