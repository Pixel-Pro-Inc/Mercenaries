using Assets.Scripts.Interface.CardInterfaces.ICombatant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Assets.Scripts.Entities.Character
{
    public class MageTemplate : Persona, IMageWarrior
    {
        public static MageTemplate Instance;
        public MageTemplate()
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

        private double _sppedd = 0;
        public override double Speed
        {
            get { return _sppedd; }
            set
            {
                _sppedd = value;
                if (Speed < 0) _sppedd = 0;
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

        private int _shield = 0;
        public override int shield
        {
            get { return _shield; }
            set
            {
                _shield = value;
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

        private bool _foe = false;
        public override bool Foe { get { return _foe; } set { _foe = value; } }
        public bool PassiveWarriorTraits { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int HitCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool PassiveMageTraits { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private bool _supportMage=false;
        public bool SupportMage { get { return _supportMage; } set { _supportMage = value; } }//{ get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
            #region Passive option 2 Mage

            //Mana regen every 5 seconds

            // Create a timer
            Timer myTimer2;
            myTimer2 = new Timer();
            myTimer2 = new System.Timers.Timer();
            // Tell the timer what to do when it elapses
           // myTimer2.Elapsed += new ElapsedEventHandler(myEvent);
            // Set it to go off every five seconds
            myTimer2.Interval = 5000;
            // And start it        
            myTimer2.Enabled = true;

            // Implement a call with the right signature for events going off
            //void myEvent(object source, ElapsedEventArgs e) { Mana++; }
            #endregion
        }
        //Experince methods
        public override void LevelIncrease()
        {
            Instance.ExperienceLevel++;
            #region If Support variables Increase logic 
            if (Foe == false)
            {

                if (SupportMage == false)
                {
                    Instance.Health += 5 * Instance.ExperienceLevel;
                    Instance.dodge += 5 * Instance.ExperienceLevel;
                    Instance.Speed += 1 * Instance.ExperienceLevel;
                    Instance.CritC += 1 * Instance.ExperienceLevel;
                    Instance.MagicRes += 3 * (Instance.ExperienceLevel - 2);
                    Instance.Armour += 1 * (Instance.ExperienceLevel - 2);
                    #region Damage
                    Instance.LowDamage = true;
                    if (LowDamage == true)
                    { Instance.Damage += 5 * Instance.ExperienceLevel; Instance.LowDamage = false; }
                    if (LowDamage == false)
                    {
                        Instance.Damage += 4 * Instance.ExperienceLevel;
                    }
                    #endregion
                }
                else
                {
                    Instance.Health += 5 * Instance.ExperienceLevel;
                    Instance.dodge += 5 * Instance.ExperienceLevel;
                    Instance.Speed += 6 * Instance.ExperienceLevel;
                    Instance.CritC += 1 * Instance.ExperienceLevel;
                    Instance.MagicRes += 1 * Instance.ExperienceLevel;
                    Instance.Armour += 1 * Instance.ExperienceLevel;
                    Instance.LowDamage = true;
                    if (LowDamage == true)
                    { Instance.Damage += 3 * Instance.ExperienceLevel; Instance.LowDamage= false; }
                    if (LowDamage== false)
                    {
                        Instance.Damage += 4 * Instance.ExperienceLevel;
                    }
                }
                //fire levelIncrease animation
            }
            else
            {
                Instance.Health += 1 * Instance.ExperienceLevel;
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
                    Instance.Damage += 5 * Instance.ExperienceLevel;
                }
            }
            #endregion
            //fire levelIncrease animation
        }
        public override int DamageGiven()
        {
            int damageGiven = 0;
            if (Foe == false)
            {
                Random r = new Random();
                damageGiven = r.Next(5, 26);
            }
            else
            {
                Random r = new Random();
                damageGiven = r.Next(5, 11);
            }
            return damageGiven;
        }
        public void InitiationMethod()
        {
            #region health
            
            if (Foe == false)
            {
                if (SupportMage == false)
                {
                    _health = 55;
                }
                else
                {
                    _health = 26;
                }

            }
            else
            {
                _health = 6;
            }
            #endregion
            #region dodge

            if (Foe == false)
            {
                if (SupportMage == false)
                {
                    _dodge = 5;
                }
                else
                {
                    _dodge = 10;
                }
            }
            else
            {
                _dodge = 10;
            }

            #endregion
            #region Speed
            if (Foe == false)
            {
                if (SupportMage == false)
                {
                    _sppedd = 1;
                }
                else
                {
                    _sppedd = 10;
                }
            }
            else
            {
                _sppedd = 1;
            }
            #endregion
            #region CritC
            if (Foe == false)
            {
                if (SupportMage == false)
                {
                    _Critc = 2;
                }
                else
                {
                    _Critc = 1;
                }
            }
            else
            {
                _Critc = 1;
            }

            #endregion
            #region Damage
            if (Foe == false)
            {
                if (SupportMage == false)
                {
                    if (LowDamage == true)
                    {
                        _Damage = 5;
                    }
                    else
                    {
                        _Damage = 25;
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
            }
            else
            {
                if (LowDamage == true)
                {
                    _Damage = 1;
                }
                else
                {
                    _Damage = 20;
                }
            }
            #endregion
            #region Accuracy
            if (Foe == false)
            {
                _Accuaracy = 85;
            }
            else
            {
                _Accuaracy = 0;
            }
            #endregion
            #region MagicalResistance
            if (Foe == false)
            {
                if (SupportMage == false)
                {
                    _MAgres = 2;
                }
                else
                {
                    _MAgres = 1;
                }
            }
            else
            {
                _MAgres = 0;
            }
            #endregion
            #region Armour
            if (Foe == false)
            {
                if (SupportMage == false)
                {
                    _Armour = 2;
                }
                else
                {
                    _Armour = 1;
                }
            }
            else
            {
                _Armour = 0;
            }
            #endregion
            #region Shield
            if (Foe == false)
            {
                if (SupportMage == false)
                {
                    _shield = 2;
                }
                else
                {
                    _shield = 1;
                }
            }
            else
            {
                _shield = 0;
            }
            #endregion
        }
        #endregion
    }
}
