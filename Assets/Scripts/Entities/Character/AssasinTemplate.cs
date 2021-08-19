using Assets.Scripts.Interface.CardInterfaces.ICombatant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Entities.Character
{
    class AssasinTemplate : Persona, IWarriorTraits
    {
        public AssasinTemplate Instance;
        public AssasinTemplate()
        {
            Instance = this;
            InitiationMethod();
        }

        #region Character variables
        public override string CharacterName { get; set; }
        public override string CharacterDescription { get; set; }
        private string _brief="Assasin";
        public string BriefDescription { get { return _brief; } set { _brief = value; } }

        private int _health = 0;
        public override int Health
        {
            get { return _health; }
            set
            {
                if (Health < 0) _health = 0;
                _health = value;
            }
        }

        private double _doidge = 0;
        public override double dodge
        {
            get { return _doidge; }
            set
            {
                _doidge = value;
                if (dodge < 0) _doidge = 0;

            }
        }

        private double _spped = 0;
        public override double Speed
        {
            get { return _spped; }
            set
            {
                _spped = value;
                if (Speed < 0) _spped = 0;

            }
        }

        private double _Critc = 0;
        public override double CritC
        {
            get { return _Critc; }
            set
            {
                _Critc = value;
                if (CritC < 0) _Critc = 0;

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

        private double _Accuaracy = 0;
        public override double Accuracy
        {
            get { return _Accuaracy; }
            set
            {
                _Accuaracy = value;
                if (Accuracy < 0) _Accuaracy = 0;
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

        private int _shielld = 0;
        public override int shield
        {
            get { return _shielld; }
            set
            {
                _shielld = value;
                if (shield < 0) _shielld = 0;
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


        public List<SpeciesType> NaturalAllies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<SpeciesType> NaturalEnemies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private bool _FOE = false;
        public override bool Foe { get { return _FOE; } set { _FOE = value; } }
        public bool PassiveWarriorTraits { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int HitCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #endregion
        #region Character Methods

        public void InitiationMethod()
        {
            if (CharacterSpecies == SpeciesType.Enemy) _FOE = true;
            #region health

            if (Foe == false)
            {
                _health = 50;
            }
            else
            {
                _health = 15;
            }
            #endregion
            #region dodge

            if (Foe == false)
            {
                _doidge = 15;
            }
            else
            {
                _doidge = 5;
            }

            #endregion
            #region Speed
            if (Foe == false)
            {
                _spped = 6;
            }
            else
            {
                _spped = 5;
            }
            #endregion
            #region CritC
            if (Foe == false)
            {
                _Critc = 10;
            }
            else
            {
                _Critc = 5;
            }

            #endregion
            #region Damage
            if (Foe == false)
            {
                if (LowDamage == true)
                {
                    _Damage = 10;
                }
                else
                {
                    _Damage = 10;
                }
            }
            else
            {
                if (LowDamage == true)
                {
                    _Damage = 1;
                }
                else
                {
                    _Damage = 10;
                }
            }
            #endregion
            #region Accuracy
            if (Foe == false)
            {
                _Accuaracy = 100;
            }
            else
            {
                _Accuaracy = 0;
            }
            #endregion
            #region MagicalResistance
            if (Foe == false)
            {
                _MAgres = 3;
            }
            else
            {
                _MAgres = 5;
            }
            #endregion
            #region Armour
            if (Foe == false)
            {
                _Armour = 3;
            }
            else
            {
                _Armour = 5;
            }
            #endregion
            #region Shield
            if (Foe == false)
            {
                _shielld = 2;
            }
            else
            {
                _shielld = 0;
            }
            #endregion
        }
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
                Instance.Health += 12 * Instance.ExperienceLevel;
                Instance.dodge += 6 * Instance.ExperienceLevel;
                Instance.Speed += 3 * Instance.ExperienceLevel;
                Instance.CritC += 3 * Instance.ExperienceLevel;
                Instance.MagicRes += 2 * (Instance.ExperienceLevel - 2);
                Instance.Armour += 2 * (Instance.ExperienceLevel - 2);
                Instance.LowDamage= true;
                if (LowDamage == true)
                { Instance.Damage += 6 * Instance.ExperienceLevel; Instance.LowDamage = false; }
                if (LowDamage == false)
                {
                    Instance.Damage += 7 * Instance.ExperienceLevel;
                }
                //fire levelIncrease animation
            }
            else
            {
                Instance.Health += 5 * Instance.ExperienceLevel;
                Instance.dodge += 2 * Instance.ExperienceLevel;
                Instance.Speed += 1 * Instance.ExperienceLevel;
                Instance.CritC += 1 * Instance.ExperienceLevel;
                Instance.MagicRes += 0 * Instance.ExperienceLevel;
                Instance.Armour += 0 * Instance.ExperienceLevel;
                Instance.LowDamage = true;
                if (LowDamage == true)
                { Instance.Damage += 1 * Instance.ExperienceLevel; Instance.LowDamage = false; }
                if (LowDamage == false)
                {
                    Instance.Damage += 2 * Instance.ExperienceLevel;
                }
                //fire levelIncrease animation
            }
        }
        public override int DamageGiven()
        {
            int damageGiven = 0;
            if (Foe == false)
            {
                Random r = new Random();
                damageGiven = r.Next(10, 11);
            }
            else
            {
                Random r = new Random();
                damageGiven = r.Next(1, 11);
            }
            return damageGiven;
        }
        #endregion
    }
}
