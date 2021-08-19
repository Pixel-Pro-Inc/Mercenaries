using Assets.Scripts.Interface.CardInterfaces.ICombatant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Entities.Character
{
    class WarriorTemplate:Persona,IWarriorTraits
    {
        public WarriorTemplate Instance;
        public WarriorTemplate()
        {
            Instance = this;
            InitiationMethod();
        }

        #region Character variables
        public override string CharacterName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public override string CharacterDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string BriefDescription { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        private int _health;
        public override int Health
        {
            set
            {
                if (Health < 0) _health = 0;
                _health = value;
            }
            get { return _health; }
        }

        private double _dodge = 0;
        public override double dodge
        {
            get { return _dodge; }
            set
            {
                _dodge = value;
                if (dodge < 0) _dodge = 0;

            }
        }

        private double _speed = 0;
        public override double Speed
        {
            get { return _speed; }
            set
            {
                _speed = value;
                if (Speed < 0) _speed = 0;

            }
        }

        private double _CritC = 0;
        public override double CritC
        {
            get { return _CritC; }
            set
            {
                _CritC = value;
                if (CritC < 0) _CritC = 0;

            }
        }

        private int _Damage = 0;
        public override int Damage
        {
            get { return _Damage; }
            set
            {
                _Damage = value;
                if (Damage < 0) _Damage = 0;

            }
        }

        private double _Accuracy = 0;
        public override double Accuracy
        {
            get { return _Accuracy; }
            set
            {
                _Accuracy = value;
                if (Accuracy < 0) _Accuracy = 0;
            }
        }

        private int _MAgres = 0;
        public override int MagicRes
        {
            get { return _MAgres; }
            set
            {
                _MAgres = value;
                if (MagicRes < 0) _MAgres = 0;

            }
        }

        private int _Armour = 0;
        public override int Armour
        {
            get { return _Armour; }
            set
            {
                _Armour = value;
                if (Armour < 0) _Armour = 0;

            }
        }

        private int _Shield = 0;
        public override int shield
        {
            get { return _Shield; }
            set
            {
                _Shield = value;
                if (shield < 0) _Shield = 0;
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
        private bool _foe = false;
        public override bool Foe { get { return _foe; } set { _foe = value; } }
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
        public void InitiationMethod()
        {
            #region health

            if (Foe == false)
            {
                _health = 70;
            }
            else
            {
                _health = 15;
            }
            #endregion
            #region dodge

            if (Foe == false)
            {
                _dodge = 6;
            }
            else
            {
                _dodge = 0;
            }

            #endregion
            #region Speed
            if (Foe == false)
            {
                _speed = 10;
            }
            else
            {
                _speed = 1;
            }
            #endregion
            #region CritC
            if (Foe == false)
            {
                _CritC = 6;
            }
            else
            {
                _CritC = 1;
            }

            #endregion
            #region Damage
            if (Foe == false)
            {
                if (LowDamage == true)
                {
                    _Damage = 14;
                }
                else
                {
                    _Damage = 19;
                }
            }
            else
            {
                if (LowDamage == true)
                {
                    _Damage = 3;
                }
                else
                {
                    _Damage = 6;
                }
            }
            #endregion
            #region Accuracy
            if (Foe == false)
            {
                _Accuracy = 95;
            }
            else
            {
                _Accuracy = 0;
            }
            #endregion
            #region MagicalResistance
            if (Foe == false)
            {
                _MAgres = 2;
            }
            else
            {
                _MAgres = 0;
            }
            #endregion
            #region Armour
            if (Foe == false)
            {
                _Armour = 2;
            }
            else
            {
                _Armour = 0;
            }
            #endregion
            #region Shield
            if (Foe == false)
            {
                _Shield = 2;
            }
            else
            {
                _Shield = 0;
            }
            #endregion
        }
        #endregion
    }
}
