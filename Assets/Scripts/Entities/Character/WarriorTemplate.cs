﻿using Assets.Scripts.Interface.CardInterfaces.ICombatant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Entities.Character
{
    class WarriorTemplate:Persona,IWarriorTraits
    {
        new public static WarriorTemplate Instance;
        public WarriorTemplate()
        {
            Instance = this;
        }

        #region Character variables
        public override string CharacterName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public override string CharacterDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string BriefDescription { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public override int Health
        {
            get { return Health; }
            set
            {
                if (Health < 0) Health = 0;
                if (Foe == false)
                {
                    Health = 70;
                }
                else
                {
                    Health = 15;
                }
            }
        }
        public override int dodge
        {
            get { return dodge; }
            set
            {
                if (Foe == false)
                {
                    dodge = 6;
                }
                else
                {
                    dodge = 0;
                }
                if (dodge < 0) dodge = 0;

            }
        }
        public override int Speed
        {
            get { return Speed; }
            set
            {
                if (Foe == false)
                {
                    Speed = 10;
                }
                else
                {
                    Speed = 1;
                }
                if (Speed < 0) Speed = 0;

            }
        }
        public override double CritC
        {
            get { return CritC; }
            set
            {
                if (Foe == false)
                {
                    CritC = 6;
                }
                else
                {
                    CritC = 1;
                }
                if (CritC < 0) CritC = 0;

            }
        }
        public override int Damage
        {
            get { return Damage; }
            set
            {
                if (Foe == false)
                {
                    if (LowDamage == true)
                    {
                        Damage = 14;
                    }
                    else
                    {
                        Damage = 19;
                    }
                }
                else
                {
                    if (LowDamage == true)
                    {
                        Damage = 3;
                    }
                    else
                    {
                        Damage = 6;
                    }
                }
                if (Damage < 0) Damage = 0;

            }
        }
        public override int Accuracy
        {
            get { return Accuracy; }
            set
            {
                if (Foe == false)
                {
                    Accuracy = 95;
                }
                else
                {
                    Accuracy = 0;
                }
                if (Accuracy < 0) Accuracy = 0;
            }
        }
        public override int MagicRes
        {
            get { return MagicRes; }
            set
            {
                if (Foe == false)
                {
                    MagicRes = 2;
                }
                else
                {
                    MagicRes = 0;
                }
                if (MagicRes < 0) MagicRes = 0;

            }
        }
        public override int Armour
        {
            get { return Armour; }
            set
            {
                if (Foe == false)
                {
                    Armour = 2;
                }
                else
                {
                    Armour = 0;
                }
                if (Armour < 0) Armour = 0;

            }
        }
        public override int shield
        {
            get { return shield; }
            set
            {
                if (Foe == false)
                {
                    shield = 2;
                }
                else
                {
                    shield = 0;
                }
                if (shield < 0) shield = 0;
            }
        }

        /* Mana & Stamina
         public int Mana { get { return Mana; } set { if (DefaultValue == true) { if (Mana > 100) Mana = 100; if (Mana < 0) Mana = 0; } } }
        public int Stamina
        {
            get { return Stamina; }
            set { if (DefaultValue == true) { if (Stamina > 100) Stamina = 100; if (Stamina < 0) Stamina = 0; } }

        }
         */


        public List<string> NaturalAllies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<string> NaturalEnemies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override bool Foe { get { return Foe; } set { Foe = false; } }
        public bool PassiveWarriorTraits { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int HitCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #endregion
        #region Character Methods

        //Here are the passive traits of the card themselves
        new public void passiveTraits()
        {
            //Instance.EquipItem(HolyCrossItem, Instance); I dont expect this to be used at all here. It would be clled some place else, I wrrote it here to see if it would work
            Instance.ActiveBuff();
        }

        //string CitizenOf = (string)WarriorTemplate.Kingdom.DarkSyde; // Here I was just experimenting to see how the citizenship can be set
        //After We figure out how to set the respective variables to the specific enum value I want to use peter as a reference for other characters so we
        //forget to include the correct and necesary info

        public void ActiveBuff()
        {
            #region Passive option 2 Warrior StackSpeed

            //Passive 2 - Stacks atack speed up to 5 times (5% each)

            int CacheSpeed = 0;
            int StackCount = 5;
            if (StackCount > 0 && HitCount < 5)
            {
                Instance.Speed += (int)(Instance.Speed * 0.05);
                CacheSpeed += (int)(Instance.Speed * 0.05);
                StackCount--;
            }
            else
            {
                //Print " cannot stack any more" or "Stack limit reached"
            }
            if (true/*GameOver==true*/)
            {
                Instance.Speed -= CacheSpeed;
                CacheSpeed = 0;
                StackCount = 5;
            }
            #endregion
        }
        public void ActiveDeBuff()
        {
            throw new System.NotImplementedException();
        }
        //Experince methods
        public override void LevelIncrease()
        {
            Instance.ExperienceLevel++;
            if (Foe == false)
            {
                Instance.Health += 20 * Instance.ExperienceLevel;
                Instance.dodge += 2 * Instance.ExperienceLevel;
                Instance.Speed += 2 * Instance.ExperienceLevel;
                Instance.CritC += 1 * Instance.ExperienceLevel;
                Instance.MagicRes += 1 * Instance.ExperienceLevel;
                Instance.Armour += 3 * Instance.ExperienceLevel;
                Instance.LowDamage = true;
                if (LowDamage == true)
                { Instance.Damage += 3 * Instance.ExperienceLevel;  Instance.LowDamage = false; }
                else
                {
                    Instance.Damage += 2 * Instance.ExperienceLevel;
                }
            }
            else
            {
                Instance.Health += 5 * Instance.ExperienceLevel;
                Instance.dodge += 2 * Instance.ExperienceLevel;
                Instance.Speed += 1 * Instance.ExperienceLevel;
                Instance.CritC += 1 * Instance.ExperienceLevel;
                Instance.MagicRes += 0;
                Instance.Armour += 0;
                Instance.LowDamage = true;
                if (LowDamage == true)
                { Instance.Damage += 1 * Instance.ExperienceLevel; Instance.LowDamage = false; } 
                else
                {
                    Instance.Damage += 2 * Instance.ExperienceLevel;
                }
            }
            //fire levelIncrease animation
        }
        public override int DamageGiven()
        {
            int damageGiven = 0;
            if (Foe == false)
            {
                Random r = new Random();
                damageGiven = r.Next(14, 20);
            }
            else
            {
                Random r = new Random();
                damageGiven = r.Next(3, 7);
            }
            return damageGiven;
        }
        public override int HealthLoss(int damageGiven)
        {
            Instance.Health -= damageGiven;
            return damageGiven;
        }


        #endregion
    }
}
