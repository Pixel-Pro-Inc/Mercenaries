﻿using Assets.Scripts.Interface.CardInterfaces.ICombatant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Entities.Character
{
    class RangeTemplate : Persona, IWarriorTraits
    {
        public RangeTemplate Instance;
        public RangeTemplate()
        {
            Instance = this;
        }

        #region Character variables
        public override string CharacterName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public override string CharacterDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string BriefDescription { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        private int _health = 0;
        public override int Health
        {
            get { return _health; }
            set
            {
                if (Health < 0) _health = 0;
                if (Foe == false)
                {
                    _health = 58;
                }
                else
                {
                    _health = 8;
                }
            }
        }

        private double _dodge = 0;
        public override double dodge
        {
            get { return _dodge; }
            set
            {
                if (Foe == false)
                {
                    _dodge = 8;
                }
                else
                {
                    _dodge = 5;
                }
                if (dodge < 0) _dodge = 0;

            }
        }

        private double _Speed = 0;
        public override double Speed
        {
            get { return _Speed; }
            set
            {
                if (Foe == false)
                {
                    _Speed = 6;
                }
                else
                {
                    _Speed = 7;
                }
                if (Speed < 0) _Speed = 0;

            }
        }

        private double _CRITc = 0;
        public override double CritC
        {
            get { return _CRITc; }
            set
            {
                if (Foe == false)
                {
                    _CRITc = 6;
                }
                else
                {
                    _CRITc = 2;
                }
                if (CritC < 0) _CRITc = 0;

            }
        }

        private int _dAMAGE = 0;
        public override int Damage
        {
            get { return _dAMAGE; }
            set
            {
                if (Foe == false)
                {
                    if (LowDamage == true)
                    {
                        _dAMAGE = 4;
                    }
                    else
                    {
                        _dAMAGE = 16;
                    }
                }
                else
                {
                    if (LowDamage == true)
                    {
                        _dAMAGE = 2;
                    }
                    else
                    {
                        _dAMAGE = 6;
                    }
                }
                if (Damage < 0) _dAMAGE = 0;

            }
        }

        private double _Accuracy = 0;
        public override double Accuracy
        {
            get { return _Accuracy; }
            set
            {
                if (Foe == false)
                {
                    _Accuracy = 95;
                }
                else
                {
                    _Accuracy = 0;
                }
                if (Accuracy < 0) _Accuracy = 0;
            }
        }

        private int _MAgres = 0;
        public override int MagicRes
        {
            get { return _MAgres; }
            set
            {
                if (Foe == false)
                {
                    _MAgres = 1;
                }
                else
                {
                    _MAgres = 0;
                }
                if (MagicRes < 0) _MAgres = 0;

            }
        }

        private int _Armour = 0;
        public override int Armour
        {
            get { return _Armour; }
            set
            {
                if (Foe == false)
                {
                    _Armour = 3;
                }
                else
                {
                    _Armour = 0;
                }
                if (Armour < 0) _Armour = 0;

            }
        }

        private int _shield = 0;
        public override int shield
        {
            get { return _shield; }
            set
            {
                if (Foe == false)
                {
                    _shield = 2;
                }
                else
                {
                    _shield = 0;
                }
                if (shield < 0) _shield = 0;
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
            throw new System.NotImplementedException();
        }
        //Experince methods
        public override void LevelIncrease()
        {
            Instance.ExperienceLevel++;
            if (Foe == false)
            {

                Instance.Health += 11 * Instance.ExperienceLevel;
                Instance.dodge += 4 * Instance.ExperienceLevel;
                Instance.Speed += 4 * Instance.ExperienceLevel;
                Instance.CritC += 2 * Instance.ExperienceLevel;
                Instance.MagicRes += 2 * (Instance.ExperienceLevel - 2);
                Instance.Armour += 2 * (Instance.ExperienceLevel - 2);
                Instance.LowDamage = true;
                if (LowDamage== true)
                { Instance.Damage += 2 * Instance.ExperienceLevel; Instance.LowDamage = false; }
                if (LowDamage == false)
                {
                    Instance.Damage += 4 * Instance.ExperienceLevel;
                }
                //fire levelIncrease animation
            }
            else
            {
                Instance.Health += 3 * Instance.ExperienceLevel;
                Instance.dodge += 1 * Instance.ExperienceLevel;
                Instance.Speed += 4 * Instance.ExperienceLevel;
                Instance.CritC += 2 * Instance.ExperienceLevel;
                Instance.MagicRes += 0 * (Instance.ExperienceLevel - 2);
                Instance.Armour += 0 * (Instance.ExperienceLevel - 2);
                Instance.LowDamage = true;
                if (LowDamage == true)
                { Instance.Damage += 1 * Instance.ExperienceLevel; Instance.LowDamage = false; }
                if (LowDamage == false)
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
                Random r = new System.Random();
                damageGiven = r.Next(4, 17);
            }
            else
            {
                Random r = new Random();
                damageGiven = r.Next(2, 7);
            }
            return damageGiven;
        }
        #endregion
        
    }
}
