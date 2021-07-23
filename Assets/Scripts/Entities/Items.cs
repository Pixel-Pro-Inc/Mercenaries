using Assets.Scripts.TraitInterface;
using Assets.TraitInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Entities
{
    public class Items: Cards
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
            public bool Relic { get { return Relic; } set { Relic = true; } }
            public bool BeingUsed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public int Owner { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public object Ownertype { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            #endregion
            #region Item Methods

            public bool ActivationRequireMent(object CharacterInstance)
            {
                #region MakeShift Switch for instances

                if (CharacterInstance.GetType() == typeof(WarriorTemplate))
                {
                    Ownertype= (WarriorTemplate)CharacterInstance;
                    Instance.Owner = 1;
                }
                if (CharacterInstance.GetType() == typeof(TankWarriorTemplate))
                {
                    Instance.Owner = 2;
                }
                if (CharacterInstance.GetType() == typeof(RangeTemplate))
                {
                    Instance.Owner = 3;
                }
                if (CharacterInstance.GetType() == typeof(MageTemplate))
                {
                    Instance.Owner = 4;
                }
                if (CharacterInstance.GetType() == typeof(ControllerTemplate))
                {
                    Instance.Owner = 5;
                }
                if (CharacterInstance.GetType() == typeof(AssasinTemplate))
                {
                    Instance.Owner = 6;
                }
                #endregion


                Instance.Equip();
                return BeingUsed;
            }
            public void passiveTraits()
            {
                
            }
            public void UniqueActiveBuff()
            {
                #region effect on Warrior 

                if (Owner == 1)
                {
                    WarriorTemplate.Instance.Health += (int)(WarriorTemplate.Instance.Health * 0.1);
                    Instance.healthICache += (int)(WarriorTemplate.Instance.Health * 0.1);
                }

                #endregion
                #region Effect on Tank

                if (Owner == 2)
                {
                    TankWarriorTemplate.Instance.Health += (int)(TankWarriorTemplate.Instance.Health * 0.1);
                    Instance.healthICache += (int)(TankWarriorTemplate.Instance.Health * 0.1);
                }
                #endregion
                #region Effect on Range

                if (Owner == 3)
                {
                    RangeTemplate.Instance.Health += (int)(RangeTemplate.Instance.Health * 0.1);
                    Instance.healthICache += (int)(RangeTemplate.Instance.Health * 0.1);
                }

                #endregion
                #region Effect on Mage

                if (Owner == 4)
                {
                    MageTemplate.Instance.Health += (int)(MageTemplate.Instance.Health * 0.1);
                    Instance.healthICache += (int)(MageTemplate.Instance.Health * 0.1);
                }

                #endregion
                #region Effect on Controller

                if (Owner == 5)
                {
                    ControllerTemplate.Instance.Health += (int)(ControllerTemplate.Instance.Health * 0.1);
                    Instance.healthICache += (int)(ControllerTemplate.Instance.Health * 0.1);
                }

                #endregion
                #region Effeecton Assasin

                if (Owner == 6)
                {
                    AssasinTemplate.Instance.Health += (int)(AssasinTemplate.Instance.Health * 0.1);
                    Instance.healthICache += (int)(AssasinTemplate.Instance.Health * 0.1);
                }

                #endregion
            }

            public void UniqueActiveDeBuff()
            {
               
            }

            public void Equip()
            {
                BeingUsed = true;// This has to be first otherwise the values wont change
                Instance.UniqueActiveBuff();
                Instance.UniqueActiveDeBuff();
                Instance.passiveTraits();
            }

            public void Remove()
            {
                if (Owner == 1) WarriorTemplate.Instance.Health -= Instance.healthICache;
                if (Owner == 2) TankWarriorTemplate.Instance.Health -= Instance.healthICache;
                if (Owner == 3) RangeTemplate.Instance.Health -= Instance.healthICache;
                if (Owner == 4) MageTemplate.Instance.Health -= Instance.healthICache;
                if (Owner == 5) ControllerTemplate.Instance.Health -= Instance.healthICache;
                if (Owner == 6) AssasinTemplate.Instance.Health -= Instance.healthICache;


                BeingUsed = false;
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
            public int Owner { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public object Ownertype { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            #endregion
            #region Item Methods

            public void passiveTraits()
            {
               
            }

            public bool ActivationRequireMent(object CharacterInstance)
            {
                //here we put the logic to check if the conditions to use relics are met
                #region MakeShift Switch for instances

                if (CharacterInstance.GetType() == typeof(WarriorTemplate))
                {
                    Ownertype = (WarriorTemplate)CharacterInstance;
                    Instance.Owner = 1;
                }
                if (CharacterInstance.GetType() == typeof(TankWarriorTemplate))
                {
                    Instance.Owner = 2;
                }
                if (CharacterInstance.GetType() == typeof(RangeTemplate))
                {
                    Instance.Owner = 3;
                }
                if (CharacterInstance.GetType() == typeof(MageTemplate))
                {
                    Instance.Owner = 4;
                }
                if (CharacterInstance.GetType() == typeof(ControllerTemplate))
                {
                    Instance.Owner = 5;
                }
                if (CharacterInstance.GetType() == typeof(AssasinTemplate))
                {
                    Instance.Owner = 6;
                }
                #endregion

                Instance.Equip();
                return BeingUsed;
            }

            public void UniqueActiveBuff()
            {
                #region effect on Warrior 

                if (Owner==1)
                {
                    WarriorTemplate.Instance.Health += (int)(WarriorTemplate.Instance.Health * 0.1);
                    Instance.healthICache += (int)(WarriorTemplate.Instance.Health * 0.1);
                }

                #endregion
                #region Effect on Tank

                if (Owner==2)
                {
                    TankWarriorTemplate.Instance.Health += (int)(TankWarriorTemplate.Instance.Health * 0.1);
                    Instance.healthICache += (int)(TankWarriorTemplate.Instance.Health * 0.1);
                }
                #endregion
                #region Effect on Range

                if (Owner==3)
                {
                    RangeTemplate.Instance.Health += (int)(RangeTemplate.Instance.Health * 0.1);
                    Instance.healthICache += (int)(RangeTemplate.Instance.Health * 0.1);
                }

                #endregion
                #region Effect on Mage

                if (Owner==4)
                {
                    MageTemplate.Instance.Health += (int)(MageTemplate.Instance.Health * 0.1);
                    Instance.healthICache += (int)(MageTemplate.Instance.Health * 0.1);
                }

                #endregion
                #region Effect on Controller

                if (Owner==5)
                {
                    ControllerTemplate.Instance.Health += (int)(ControllerTemplate.Instance.Health * 0.1);
                    Instance.healthICache += (int)(ControllerTemplate.Instance.Health * 0.1);
                }

                #endregion
                #region Effeecton Assasin

                if (Owner==6)
                {
                    AssasinTemplate.Instance.Health += (int)(AssasinTemplate.Instance.Health * 0.1);
                    Instance.healthICache += (int)(AssasinTemplate.Instance.Health * 0.1);
                }
               
                #endregion
            }

            public void UniqueActiveDeBuff()
            {
                
            }

            public void Equip()
            {
                BeingUsed = true;// This has to be first otherwise the values wont change
                Instance.UniqueActiveBuff();
                Instance.UniqueActiveDeBuff();
                Instance.passiveTraits();
            }

            public void Remove()
            {
                if (Owner==1) WarriorTemplate.Instance.Health -= Instance.healthICache;
                if (Owner==2)TankWarriorTemplate.Instance.Health -= Instance.healthICache;
                if (Owner==3)RangeTemplate.Instance.Health -= Instance.healthICache;
                if (Owner==4)MageTemplate.Instance.Health -= Instance.healthICache;
                if (Owner==5)ControllerTemplate.Instance.Health -= Instance.healthICache;
                if (Owner==6)AssasinTemplate.Instance.Health -= Instance.healthICache;


                BeingUsed = false;
            }

            
            #endregion

        }
        #endregion
        #region GaiaShield template

        public class GaiaShieldTemplate:Items, ICardTraits,IItemTraits
        {
            public static GaiaShieldTemplate Instance { get; set; }
            public GaiaShieldTemplate()
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

            public string ItemName { get { return ItemName; } set { ItemName = "Gaia's Shield"; } }
            public string ItemDescription { get { return ItemDescription; } set { ItemDescription = "+10% armour/Magic Resistance on user"; } }
            public int Owner { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public object Ownertype { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public bool Relic { get { return Relic; } set { Relic = true; } }
            public bool BeingUsed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            #endregion
            #region Item Methods

            public void passiveTraits()
            {
                
            }

            public void Equip()
            {
                BeingUsed = true;// This has to be first otherwise the values wont change
                Instance.UniqueActiveBuff();
                Instance.UniqueActiveDeBuff();
                Instance.passiveTraits();
            }

            public void Remove()
            {
                if (Owner == 1) WarriorTemplate.Instance.Health -= Instance.healthICache;
                if (Owner == 2) TankWarriorTemplate.Instance.Health -= Instance.healthICache;
                if (Owner == 3) RangeTemplate.Instance.Health -= Instance.healthICache;
                if (Owner == 4) MageTemplate.Instance.Health -= Instance.healthICache;
                if (Owner == 5) ControllerTemplate.Instance.Health -= Instance.healthICache;
                if (Owner == 6) AssasinTemplate.Instance.Health -= Instance.healthICache;


                BeingUsed = false;
            }

            public bool ActivationRequireMent(object CharacterInstance)
            {
                //here we put the logic to check if the conditions to use relics are met
                #region MakeShift Switch for instances

                if (CharacterInstance.GetType() == typeof(WarriorTemplate))
                {
                    Ownertype = (WarriorTemplate)CharacterInstance;
                    Instance.Owner = 1;
                }
                if (CharacterInstance.GetType() == typeof(TankWarriorTemplate))
                {
                    Instance.Owner = 2;
                }
                if (CharacterInstance.GetType() == typeof(RangeTemplate))
                {
                    Instance.Owner = 3;
                }
                if (CharacterInstance.GetType() == typeof(MageTemplate))
                {
                    Instance.Owner = 4;
                }
                if (CharacterInstance.GetType() == typeof(ControllerTemplate))
                {
                    Instance.Owner = 5;
                }
                if (CharacterInstance.GetType() == typeof(AssasinTemplate))
                {
                    Instance.Owner = 6;
                }
                #endregion

                Instance.Equip();
                return BeingUsed;
            }

            public void UniqueActiveBuff()
            {
                #region effect on Warrior 

                if (Owner == 1)
                {
                    WarriorTemplate.Instance.Armour+= (int)(WarriorTemplate.Instance.Armour * 0.1);
                    Instance.armourICache += (int)(WarriorTemplate.Instance.Armour * 0.1);

                    WarriorTemplate.Instance.MagicRes += (int)(WarriorTemplate.Instance.MagicRes * 0.1);
                    Instance.magresICache += (int)(WarriorTemplate.Instance.MagicRes * 0.1);
                }

                #endregion
                #region Effect on Tank

                if (Owner == 2)
                {
                    TankWarriorTemplate.Instance.Armour += (int)(TankWarriorTemplate.Instance.Armour * 0.1);
                    Instance.armourICache += (int)(TankWarriorTemplate.Instance.Armour * 0.1);

                    TankWarriorTemplate.Instance.MagicRes += (int)(TankWarriorTemplate.Instance.MagicRes * 0.1);
                    Instance.magresICache += (int)(TankWarriorTemplate.Instance.MagicRes * 0.1);
                }
                #endregion
                #region Effect on Range

                if (Owner == 3)
                {
                    RangeTemplate.Instance.Armour += (int)(RangeTemplate.Instance.Armour * 0.1);
                    Instance.armourICache += (int)(RangeTemplate.Instance.Armour * 0.1);

                    RangeTemplate.Instance.MagicRes += (int)(RangeTemplate.Instance.MagicRes * 0.1);
                    Instance.magresICache += (int)(RangeTemplate.Instance.MagicRes * 0.1);
                }

                #endregion
                #region Effect on Mage

                if (Owner == 4)
                {
                    MageTemplate.Instance.Armour += (int)(MageTemplate.Instance.Armour * 0.1);
                    Instance.armourICache += (int)(MageTemplate.Instance.Armour * 0.1);

                    MageTemplate.Instance.MagicRes += (int)(MageTemplate.Instance.MagicRes * 0.1);
                    Instance.magresICache += (int)(MageTemplate.Instance.MagicRes * 0.1);
                }

                #endregion
                #region Effect on Controller

                if (Owner == 5)
                {
                    ControllerTemplate.Instance.Armour += (int)(ControllerTemplate.Instance.Armour * 0.1);
                    Instance.armourICache += (int)(ControllerTemplate.Instance.Armour * 0.1);

                    ControllerTemplate.Instance.MagicRes += (int)(ControllerTemplate.Instance.MagicRes * 0.1);
                    Instance.magresICache += (int)(ControllerTemplate.Instance.MagicRes * 0.1);
                }

                #endregion
                #region Effect on Assasin

                if (Owner == 6)
                {
                    AssasinTemplate.Instance.Armour += (int)(AssasinTemplate.Instance.Armour * 0.1);
                    Instance.armourICache += (int)(AssasinTemplate.Instance.Armour * 0.1);

                    AssasinTemplate.Instance.MagicRes += (int)(AssasinTemplate.Instance.MagicRes * 0.1);
                    Instance.magresICache += (int)(AssasinTemplate.Instance.MagicRes * 0.1);
                }

                #endregion
            }

            public void UniqueActiveDeBuff()
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        #endregion


    }
}
