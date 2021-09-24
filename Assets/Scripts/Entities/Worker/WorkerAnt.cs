using Assets.Scripts.Entities.Item;
using Assets.Scripts.Entities.Item.Food;
using Assets.Scripts.Entities.Item.Tools;
using Assets.Scripts.Interface;
using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using Assets.Scripts.MonoBehaviours;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using static Assets.Scripts.Models.Enums;
using Assets.Scripts.Entities.Item.Material;
using Assets.Scripts.MonoBehaviours.ReGroup;

namespace Assets.Scripts.Entities.Worker
{
    public class WorkerAnt : Individual, IWorkerAntTraits
    {

        #region Traits

        public enum SpeciesType
        {
            Lion,
            Crocodile,
            Fish,
            Salamander,
            Frog,
            Triton,
            Bird,
            Parrot,
            Insect,
            Hippo,
            Boar,
            Deer,
            Sloth
        }

        //WorkerAnts dont need a name, just their Individual id is more than enough

        internal int _Life = 0;
        public virtual int Life { get; set; }
        internal int _health = 0;
        public virtual int Health
        {
            get { return _health; }
            set
            {
                if (Health < 0) _health = 0;
                _health = value;
            }
        }
        internal int _armour = 0;
        public virtual int Armour
        {
            get { return _armour; }
            set
            {
                _armour = value;
                if (Armour < 0) _armour = 0;

            }
        }
        public virtual bool ArmourState { get; private set; }

        internal int _handSkill = 0; //This will be used in place of Damage
        public virtual int HandSkill
        {
            get { return _handSkill; }
            set
            {
                _handSkill = value;
                if (_handSkill < 0) _handSkill = 0;

            }
        }

        internal int _expPoints = 0;
        public int ExpPoints
        {
            get { return _expPoints; }
            set
            {
                if (RoundInfo.RoundDone == true/*This means characters can level up durning battle*/)
                {
                    _expPoints += NewEarnedXp;
                }
                if (ExpPoints > 1000)
                {
                    LevelIncrease();
                    _expPoints -= 1000;
                }
            }
        }

        internal int _NewExpoint = 0;
        public int NewEarnedXp
        {
            get { return _NewExpoint; }
            set
            {
                if (NewEarnedXp < 0) _NewExpoint = 0;
                if (EarnedXp == true)
                {
                    _NewExpoint = value;
                }
                else
                {
                    _NewExpoint = 0;
                }
            }
        }

        internal bool _EarnedXp = false;
        public bool EarnedXp
        {
            get { return _EarnedXp; }
            set
            {
                _EarnedXp = value;
            }
        } //This bool is made true when XPIncrease is fired and should be made of when sessionOver is true

        internal int ExperienceLevel { get { return ExperienceLevel; } set { if (ExperienceLevel < 0) ExperienceLevel = 0; } }

        #region Food system traits that I dont trust
        internal int _Mana = 0;
        public virtual int Mana
        {
            get; set;
        }
        internal int _Stamina = 0;
        public virtual int Stamina { get; set; }//I assume the hunger method will affect this trait
        internal int _sustainance = 0;
        public virtual int Sustainance
        {
            get; set;
        }
        internal int _vitality = 0;
        public virtual int Vitality { get; set; }

        #endregion

        #endregion

        #region Methods

        public void Craft()
        {
            TavernBar.CraftingCount++;
            throw new NotImplementedException();
        }

        public void Farm()
        {
            TavernBar.FarmingCount++;
            throw new NotImplementedException();
        }

        public void Forage() //For getting food, eg meat and fruits
        {
            TavernBar.HunterGathringCount++;
            void Forging()
            {
                DateTime startime = DateTime.Now;
                TimeSpan pacer = new TimeSpan(UnityEngine.Random.Range(1, 300000)); //A random time within 5 minutes
                while (TavernBar.OutOnExpedition == true)
                {
                    if (DateTime.Now == startime + pacer)
                    {
                        CollectFood((FoodType)UnityEngine.Random.Range(0, 4)); //Collects Random food
                        startime= DateTime.Now;
                        pacer = new TimeSpan(UnityEngine.Random.Range(1, 300000)); //A random time within 5 minutes
                    }
                }
            }
            ThreadStart BeginForaging = new ThreadStart(Forging); //this is a declaration of what happens at commencement
            Thread Forage = new Thread(BeginForaging);//this is the actual thread
            Forage.Priority = System.Threading.ThreadPriority.BelowNormal;

            Debug.Log("Im told that this has to be trial and error to figure out the number that doesn't crash");
            Forage.Start(); Debug.Log("I am a bit anxious about the number of workers and therefore the number of threads that can be used");
            
            Forage.Abort();
        }
        public void Mine()//For getting material, eg ore and wood and stone
        {
            TavernBar.MiningCount++;
            void Mining()
            {
                DateTime startime = DateTime.Now;
                TimeSpan pacer = new TimeSpan(UnityEngine.Random.Range(1, 300000)); //A random time within 5 minutes
                while (TavernBar.OutOnExpedition == true)
                {
                    if (DateTime.Now == startime + pacer)
                    {
                        CollectMaterial((MaterialType)UnityEngine.Random.Range(0, 4)); //Collects Random Material
                        startime = DateTime.Now;
                        pacer = new TimeSpan(UnityEngine.Random.Range(1, 300000)); //A random time within 5 minutes
                    }
                }
            }
            ThreadStart BeginMining = new ThreadStart(Mining); //this is a declaration of what happens at commencement
            Thread Mine = new Thread(BeginMining);//this is the actual thread
            Mine.Priority = System.Threading.ThreadPriority.BelowNormal;

            Debug.Log("Im told that this has to be trial and error to figure out the number that doesn't crash");
            Mine.Start(); Debug.Log("I am a bit anxious about the number of workers and therefore the number of threads that can be used");

            Mine.Abort();
        }
        public void Smith(ToolType tooltype)
        {
            TavernBar.SmithingCount++;
            void Smithing()
            {
                DateTime startime = DateTime.Now;
                TimeSpan pacer = new TimeSpan(UnityEngine.Random.Range(1, 300000)); //A random time within 5 minutes
                while (TavernBar.OutOnExpedition == true)
                {
                    if (DateTime.Now == startime + pacer)
                    {
                        AcquireTool(tooltype); //Collects Tool type given in the parameter
                        startime = DateTime.Now;
                        pacer = new TimeSpan(UnityEngine.Random.Range(1, 300000)); //A random time within 5 minutes
                    }
                }
            }
            ThreadStart BeginSmithing = new ThreadStart(Smithing); //this is a declaration of what happens at commencement
            Thread Smith = new Thread(BeginSmithing);//this is the actual thread
            Smith.Priority = System.Threading.ThreadPriority.BelowNormal;

            Debug.Log("Im told that this has to be trial and error to figure out the number that doesn't crash");
            Smith.Start(); Debug.Log("I am a bit anxious about the number of workers and therefore the number of threads that can be used");

            Smith.Abort();
        }

        public void Eat(object edible) //This has to get the meal from the bag
        {
            FoodClass food = (FoodClass)edible;
            food.ActivationRequireMent(this);
        }
        public void Rest()
        {
            throw new NotImplementedException();
        }

        #region Items

        FoodClass Bag = new FoodClass();
        Tool Belt = new Tool();
        MaterialClass Chest = new MaterialClass();

        public void CollectFood( object enumtype)
        {
            if (enumtype.GetType() == typeof(FoodType))
            {
                FoodType food = (FoodType)enumtype;
                Bag.CreateFood(food);
            }
            else
            {
                Debug.Log("The item has to be the enum type  foodType ");
            }
        }
        public void AcquireTool(object enumtypeTool) //The item has to be the enum type eg toolType
        {
            //I am unsure of whether making tools falls under smithing , i think it does. Then crafting will be clothes and trinkets and shit
            if (enumtypeTool.GetType() == typeof(ToolType))
            {
                ToolType tool = (ToolType)enumtypeTool;
                Belt.CreateTool(tool);
            }
            else
            {
                Debug.Log("The item has to be the enum type tooltype");
            }
        }
        public void CollectMaterial(object enumtype)
        {
            if (enumtype.GetType() == typeof(MaterialType))
            {
                MaterialType material = (MaterialType)enumtype;
                Chest.CreateMaterial(material);
            }
            else
            {
                Debug.Log("The item has to be the enum type  MaterialType ");
            }
        }

        public void UseTool(object item) //this is supposed to get an Item from Belt
        {
            if (item.GetType() == typeof(Tool))
            {
                Tool tool = (Tool)item; //You dont need to put logic to check what tool it is cause using virtual methods it finnesses and does as it should respectively
                tool.ActivationRequireMent(this);
            }
            else
            {
                Debug.Log("The item has to be a Tool");
            }
        }

        public override List<object> RetrieveItemsAtDisposal()
        {
            List<object> Items = new List<object>();
            Items.Add(Bag.Silo);
            Items.Add(Belt.Artillery);
            Items.Add(Chest.Shed);
            return Items;
        }

        #endregion

        public virtual void LevelIncrease()
        {
            ExperienceLevel++;
            Health += 1 * ExperienceLevel;
            Armour += 1 * ExperienceLevel;
            //fire levelIncrease animation
            new SerializedObjectManager().SaveData(this, new SerializedObjectManager().paths[0] + IndividualId); //We use IndividualId here insteaad of name
        }
        public void TraitLevelUpActivation(int experienceLevel, List<ItemTemplate> Items)
        {
            throw new NotImplementedException();
        }
        public void XPIncrease(bool earnXp, int newEarnedXp)
        {
            EarnedXp = earnXp;
            NewEarnedXp = newEarnedXp;
        }
        public void ToggleArmour(bool state, int amount)
        {
            ArmourState = state;
            Armour = amount;
        }

        #endregion

    }
}
