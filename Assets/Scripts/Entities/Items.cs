using Assets.Scripts.TraitInterface;
using Assets.TraitInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Entities
{
    class Items: Cards
    {
        //Here we will have items of all sorts.
        //Since it already inherts from cards it has passive traits already declared as well as cost.
        //So here One will simple list a bunch of items and  theie unique abilites or prioties or special overides
        public enum MasterItemList
        {
            //Here a list of every individual item will be defined.Then they will be accessed with their indexes as needed in below lists eg List<>Items
        }

        List<string> CacheStringEffect;
        List<int> CacheIntEffect;

        //Here you might want to declare the passivetraits/methods as well

        #region Nth_Metal Template
        public class Nth_Metal : Items, ICardTraits, IItemTraits //this is how all items will be defined
        {
            public static Nth_Metal Instance { get; set; }
            public Nth_Metal()
            {
                Instance = this;
            }

            #region Item Variables

            public string ItemName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public string ItemDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool Relic { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            #endregion
            #region Item Methods

            public bool ActivationRequireMent()
            {
                throw new NotImplementedException();
                //Instance.PassiveTraitsState = true;
            }
            public void passiveTraits()
            {
                if (ActivationRequireMent() == true)
                {

                }
            }
            public void UniqueActiveBuff()
            {
                if (ActivationRequireMent() == true)
                {

                }
            }

            public void UniqueActiveDeBuff()
            {
                if (ActivationRequireMent() == true)
                {

                }
            }

            public void Equip()
            {
                throw new NotImplementedException();
            }

            public void Remove()
            {
                throw new NotImplementedException();
            }

            #endregion
        }
        #endregion
        #region HolyCross Template

        public class HolyCrossTemplate: Items, ICardTraits, IItemTraits
        {
            public static HolyCrossTemplate Instance { get; set; }
            public HolyCrossTemplate()
            {
                Instance = this;
            }

            #region Item Variables

            public string ItemName { get { return ItemName; } set { ItemName="Holy Cross"; } }
            public string ItemDescription { get { return ItemDescription; } set { ItemDescription="+10% on user"; } }
            public bool Relic { get { return Relic; } set { Relic= true; } }

            #endregion
            #region Item Methods

            public void passiveTraits()
            {
                throw new NotImplementedException();
            }

            public bool ActivationRequireMent()
            {
                throw new NotImplementedException();
            }

            public void UniqueActiveBuff()
            {
                CharacterPersona.WarriorTemplate.Instance.Health += (int)(CharacterPersona.WarriorTemplate.Instance.Health * 0.1);
            }

            public void UniqueActiveDeBuff()
            {
                throw new NotImplementedException();
            }

            public void Equip()
            {
                throw new NotImplementedException();
            }

            public void Remove()
            {
                throw new NotImplementedException();
            }
            #endregion

        }
        #endregion


    }
}
