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

        int healthICache; int manaICache; int staminaICache; int dodgeICache; int speedICache; 
        int critCICache; int magresICache; int armourICache; int damageICache; int accuracyICache;

        //Here you might want to declare the passivetraits/methods as well

        #region Nth_Metal Template
        public class Nth_Metal : Items, ICardTraits, IItemTraits //this is how all items will be defined
        {
            public static Nth_Metal Instance { get; set; }
            public Nth_Metal()
            {
                Instance = this;
                if (BeingUsed == false)
                {
                    Instance.healthICache = 0; Instance.manaICache = 0;
                    Instance.staminaICache = 0; Instance.dodgeICache = 0;
                    Instance.speedICache = 0; Instance.critCICache = 0;
                    Instance.magresICache = 0; Instance.armourICache = 0;
                    Instance.damageICache = 0; Instance.accuracyICache = 0;
                }//This here is used to clear the cache of effects if relic is not in use
            }

            #region Item Variables

            public string ItemName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public string ItemDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool Relic { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool BeingUsed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public object Owner { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            #endregion
            #region Item Methods

            public bool ActivationRequireMent(object CharacterInstance)
            {
                throw new NotImplementedException();
            }
            public void passiveTraits()
            {
                
            }
            public void UniqueActiveBuff()
            {
                
            }

            public void UniqueActiveDeBuff()
            {
                
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
                if (BeingUsed== false)
                {
                    Instance.healthICache = 0; Instance.manaICache = 0;
                    Instance.staminaICache = 0; Instance.dodgeICache = 0;
                    Instance.speedICache = 0; Instance.critCICache = 0;
                    Instance.magresICache = 0; Instance.armourICache = 0;
                    Instance.damageICache = 0; Instance.accuracyICache = 0;
                }//This here is used to clear the cache of effects if relic is not in use
            }

            #region Item Variables

            public string ItemName { get { return ItemName; } set { ItemName="Holy Cross"; } }
            public string ItemDescription { get { return ItemDescription; } set { ItemDescription="+10% on user"; } }
            public bool Relic { get { return Relic; } set { Relic= true; } }
            public bool BeingUsed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public object Owner { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            #endregion
            #region Item Methods

            public void passiveTraits()
            {
                throw new NotImplementedException();
            }

            public bool ActivationRequireMent(object CharacterInstance)
            {
                //here we put the logic to check if the conditions to use relics are met
                /*
                 if (CharacterInstance == CharacterPersona.WarriorTemplate.Instance)
                 {
                     Instance.Owner = CharacterPersona.WarriorTemplate.Instance;
                     Owner.Health++;
                 }
                */

                if (true/*Conditions are met*/)
                {
                    Instance.Equip();
                }
                return BeingUsed;
            } //Don't bother lookiing into this. It doesn't work as intended

            public void UniqueActiveBuff()
            {
                #region effect on Warrior 
                CharacterPersona.WarriorTemplate.Instance.Health += (int)(CharacterPersona.WarriorTemplate.Instance.Health * 0.1);
                Instance.healthICache += (int)(CharacterPersona.WarriorTemplate.Instance.Health * 0.1);
                #endregion
                #region Effect on Tank
                CharacterPersona.TankWarriorTemplate.Instance.Health += (int)(CharacterPersona.TankWarriorTemplate.Instance.Health * 0.1);
                Instance.healthICache += (int)(CharacterPersona.TankWarriorTemplate.Instance.Health * 0.1);
                #endregion
                #region Effect on Range
                CharacterPersona.RangeTemplate.Instance.Health += (int)(CharacterPersona.RangeTemplate.Instance.Health * 0.1);
                Instance.healthICache += (int)(CharacterPersona.RangeTemplate.Instance.Health * 0.1);
                #endregion
                #region Effect on Mage
                CharacterPersona.MageTemplate.Instance.Health += (int)(CharacterPersona.MageTemplate.Instance.Health * 0.1);
                Instance.healthICache += (int)(CharacterPersona.MageTemplate.Instance.Health * 0.1);
                #endregion
                #region Effect on Controller
                CharacterPersona.ControllerTemplate.Instance.Health += (int)(CharacterPersona.ControllerTemplate.Instance.Health * 0.1);
                Instance.healthICache += (int)(CharacterPersona.ControllerTemplate.Instance.Health * 0.1);
                #endregion
                #region Effeecton Assasin
                CharacterPersona.AssasinTemplate.Instance.Health += (int)(CharacterPersona.AssasinTemplate.Instance.Health * 0.1);
                Instance.healthICache += (int)(CharacterPersona.AssasinTemplate.Instance.Health * 0.1);
                #endregion
            }

            public void UniqueActiveDeBuff()
            {
                throw new NotImplementedException();
            }

            public void Equip()
            {
                Instance.UniqueActiveBuff();
                Instance.UniqueActiveDeBuff();
                Instance.passiveTraits();
                BeingUsed = true;
            }

            public void Remove()
            {
                CharacterPersona.WarriorTemplate.Instance.Health -= Instance.healthICache;
                CharacterPersona.TankWarriorTemplate.Instance.Health -= Instance.healthICache;
                CharacterPersona.RangeTemplate.Instance.Health -= Instance.healthICache;
                CharacterPersona.MageTemplate.Instance.Health -= Instance.healthICache;
                CharacterPersona.ControllerTemplate.Instance.Health -= Instance.healthICache;
                CharacterPersona.AssasinTemplate.Instance.Health -= Instance.healthICache;


                BeingUsed = false;
            }

            
            #endregion

        }
        #endregion


    }
}
