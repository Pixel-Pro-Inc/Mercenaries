using Assets.Scripts.Entities.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using UnityEngine;
using static Assets.Scripts.Models.Enums;

namespace Assets.Scripts.Entities.Item.Food
{
    class FoodClass : ItemTemplate
    {
        public override string ItemName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string ItemDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override Persona Owner { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override bool Relic { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override bool BeingUsed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public enum Status
        {
            Well_Fed,
            Neutral,
            peckish,
            Hungry,
            Starved
        }
        public Status CharacterStatus { get; set; }
        #region System variables

        int _systemValue { get; set; } int SystemValue { get { return _systemValue; } set { _systemValue = value; } } //System value goes up to a hundred

        //The rest below have a range from 0 to 25
        int _meatValue { get; set; } int MeatValue { get { return _meatValue; } set { _meatValue = value; if (_meatValue > 25) _meatValue = 25; if (_meatValue < 0) _meatValue = 0; }  }
        int _grainValue { get; set; } int GrainValue { get { return _grainValue; } set { _grainValue = value; if (_grainValue > 25) _grainValue = 25; if (_grainValue < 0) _grainValue = 0; } }
        int _VegValue { get; set; }  int VegatableValue { get { return _VegValue; } set { _VegValue = value; if (_VegValue > 25) _VegValue = 25; if (_VegValue < 0) _VegValue = 0; } }
        int _fruitValue { get; set; }   int FruitValue { get { return _fruitValue; } set { _fruitValue = value; if (_fruitValue > 25) _fruitValue = 25; if (_fruitValue < 0) _fruitValue = 0; } }


        #endregion

        List<FoodClass> Silo = new List<FoodClass>(); //List of the Characters food that it has, Dont be confused, We are not making a list of the food Systems, we are just using the superClass Type


        public void Update()
        {
            Gauge();
            if (CheckStatus(SystemValue) ==Status.Hungry)
            {
                Debug.Log("I have forgotten whats supposed to happen when youre hungry");
            }
        }
        public void CreateFood(FoodType food)
        {
            //Remeber, No Matter what BeingUsed should not be set true here cause it should only fire true when equiped
            switch (food)
            {
                case FoodType.Meat:
                    Meat meat = new Meat();
                    Silo.Add(meat);
                    break;
                case FoodType.Grain:
                    Grain grain = new Grain();
                    Silo.Add(grain);
                    break;
                case FoodType.Vegetables:
                    Vegetables veg = new Vegetables();
                    Silo.Add(veg);
                    break;
                case FoodType.Fruits:
                    Fruits fruit = new Fruits();
                    Silo.Add(fruit);
                    break;
                default: 
                    break;
            }
        }

        #region Item Action

        public override bool ActivationRequireMent(object CharacterInstance)
        {
            Owner = (Persona)CharacterInstance;
            if (CanChew(Owner))
            {
                Equip();
            }
            else
            {
                Debug.Log($"Display: You can't eat {this} yet");
            }
            return BeingUsed;
        }
        public override void Equip()
        {
            BeingUsed = true;// This has to be first otherwise the values wont change
            passiveTraits();
            Eat(Owner);
            Timer Boom;
            Boom = new Timer();
            // Tell the timer what to do when it elapses
            Boom.Elapsed += new ElapsedEventHandler(Punch);
            // Set it to go off every one seconds
            Boom.Interval = 900000;// 15 minutes
            Debug.Log("Yewo here im not sure how its going to be dont but i set it to 15 minutes, i dont know if it will work even when the app is off, How will I use DateTime here");
            // And start it        
            Boom.Enabled = true;

            void Punch(object source2, ElapsedEventArgs e)
            {
                Remove();
                Boom.Close();
            }
        }
        public override void Remove()
        {
            RemoveEffects(Owner);
            BeingUsed = false;
        }

        //The UniqueBuffs below will be called on purpose, not randomly when first made
        public virtual void UniqueActiveBuff()
        {
            Debug.Log("Food isnt supposed to have unique effects, It works the same for everyone. So yeah its redundant to do uniqueActiveBuff");
        }
        public virtual void UniqueActiveDeBuff()
        {
            Debug.Log("Food isnt supposed to have unique effects, It works the same for everyone. So yeah its redundant to do uniqueActiveBuff");
        }

        public virtual void Eat(object CharacterInstance)
        {
            //Within the food, Here the effects will be coded
            Debug.Log("You didn't put the logic to put the effects");
        }
        public virtual void RemoveEffects(object CharacterInstance)
        {
            //Within the food, Here the effects will be removed
            Debug.Log("You didn't put the logic to remove the effects");
        }
        public virtual bool CanChew(object CharacterInstance)
        {
            //Here in the food the character is checked to see if they qualify
            Debug.Log("You didn't put the logic to check if that person can equip the item");
            return false;
        }

        #endregion
        #region Item Methods

        public void Gauge()
        {
            foreach (var edible in Silo)
            {
                //I dont see why i need to set BeingUsed=false but maybe Yewo will
                if (edible.GetType()== typeof(Meat)&&(edible.BeingUsed==true))
                {
                    MeatValue+=5;
                    if (MeatValue == 25) continue;//We use continue here because if we used break we would be pushed out of the loop, but we need it to 'continue' to check the other item
                    Silo.Remove(edible);
                }
                if (edible.GetType() == typeof(Grain) && (edible.BeingUsed == true))
                {
                    GrainValue+=5;
                    if (GrainValue == 25) continue;
                    Silo.Remove(edible);
                }
                if (edible.GetType() == typeof(Vegetables) && (edible.BeingUsed == true))
                {
                    VegatableValue+=5;
                    if (VegatableValue == 25) continue;
                    Silo.Remove(edible);
                }
                if (edible.GetType() == typeof(Fruits) && (edible.BeingUsed == true))
                {
                    FruitValue+=5;
                    if (FruitValue == 25) continue;
                    Silo.Remove(edible);
                }
            }

            SystemValue = MeatValue + GrainValue + VegatableValue + FruitValue;// this should add to a maximum of 100 and min of 100;
            Owner.Mana = (int)(FruitValue * 4); //cause 25 times 4 is 100
            Owner.Stamina = (int)(VegatableValue * 4);
            Owner.Sustainance = (int)(GrainValue * 4);
            Owner.Vitality = (int)(MeatValue * 4);
        }
        public Status CheckStatus(int state)
        {
            if (state <= 100 && state >= 75 )
            {
                return Status.Well_Fed;
            }
            else if(state < 75 && state >= 50)
            {
                return Status.Neutral;
            }
            else if(state< 50 && state >= 0 )
            {
                return Status.Hungry;
            }
            else 
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        #endregion
      
    }
}
