using Assets.Scripts.Interface.CardInterfaces.ICombatant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Entities.Character
{
    class TankWarriorTemplate:Persona, IWarriorTraits
    {
        public TankWarriorTemplate Instance;
        public TankWarriorTemplate()
        {
            Instance = this;
            InitiationMethod();
        }

        #region Character variables
        public override string CharacterName { get; set; }
        public override string CharacterDescription { get; set; }
        private string _brief="Tank";
        public string BriefDescription { get { return _brief; } set { _brief = value; } }
        public override string ToString() => $"{CharacterName} is a ${BriefDescription}. Look further and you'll find ${CharacterDescription}";


        //private int _health = 0;
        public override int Health
        {
            get { return _health; }
            set
            {
                if (Health < 0) _health = 0;
                _health = value;
            }
        }

        //private double _dodge = 0;
        public override double dodge
        {
            get { return _dodge; }
            set
            {
                if (dodge < 0) _dodge = 0;
                _dodge = value;
            }
        }

        //private double _Speed = 0;
        public override double Speed
        {
            get { return _speed; }
            set
            {
                if (Speed < 0) _speed = 0;
                _speed = value;
            }
        }

        //private double _CritC = 0;
        public override double CritC
        {
            get { return _CritC; }
            set
            {
                if (CritC < 0) _CritC = 0;
                _CritC = value;
            }
        }

        //private int _Damage = 0;
        public override int Damage
        {
            get { return _Damage; }
            set
            {
                _Damage = value;

            }
        }

        //private double _Accuracy = 0;
        public override double Accuracy
        {
            get { return _Accuracy; }
            set
            {
                _Accuracy = value;
                if (Accuracy < 0) _Accuracy = 0;
            }
        }

        //private int _magicRes = 0;
        public override int MagicRes
        {
            get { return _magicRes; }
            set
            {
                _magicRes = value;

            }
        }

        //private int _Armour = 0;
        public override int Armour
        {
            get { return _armour; }
            set
            {
                _armour = value;
            }
        }

        //private int _Shield = 0;
        public override int shield
        {
            get { return _shield; }
            set
            {
                _shield = value;
                if (shield < 0) _shield = 0;
            }
        }


        //private bool _foe = false;
        public override bool Foe { get { return _foe; } set { _foe = value; } }
        public List<SpeciesType> NaturalAllies { get; set; }
        public List<SpeciesType> NaturalEnemies { get; set; }
        public bool PassiveTankTraits { get; set; }
        public override int HitCount
        {
            get { return _HitCount; }
            set
            {
                _HitCount = value;
                if (_HitCount < 0) _HitCount = 0;
            }
        }
        public bool PassiveWarriorTraits { get; set; }


        #endregion
        #region Character Methods

        public void InitiationMethod()
        {
            if (CharacterSpecies == SpeciesType.Enemy) _foe = true;
            #region health

            if (Foe == false)
            {
                _health = 120;
            }
            else
            {
                _health = 25;
            }
            #endregion
            #region dodge

            if (Foe == false)
            {
                _dodge = 1;
            }
            else
            {
                _dodge = 0;
            }

            #endregion
            #region Speed
            if (Foe == false)
            {
                _speed = 1;
            }
            else
            {
                _speed = 1;
            }
            #endregion
            #region CritC
            if (Foe == false)
            {
                _CritC = 3;
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
                    _Damage = 8;
                }
                else
                {
                    _Damage = 13;
                }
            }
            else
            {
                if (LowDamage == true)
                {
                    _Damage = 2;
                }
                else
                {
                    _Damage = 4;
                }
            }
            #endregion
            #region Accuracy
            if (Foe == false)
            {
                _Accuracy = 80;
            }
            else
            {
                _Accuracy = 0;
            }
            #endregion
            #region MagicalResistance
            if (Foe == false)
            {
                _magicRes = 5;
            }
            else
            {
                _magicRes = 5;
            }
            #endregion
            #region Armour
            if (Foe == false)
            {
                _armour = 3;
            }
            else
            {
                _armour = 5;
            }
            #endregion
            #region Shield
            if (Foe == false)
            {
                _shield = 2;
            }
            else
            {
                _shield = 0;
            }
            #endregion
        }
        public void ActiveBuff()
        {
            #region Passive option 1 Tank

            /*
             Passive 1 - each 1% of health lost, you gain 2% more armor and magic resistance

            int percentageHealthLoss =(Instance.HealthLoss(TankWarriorTemplate.Instance.DamageGiven(TankWarriorTemplate.Instance))/ Health);
            //This line above doesn't make sense. damageGiven needs to be passed through ActiveBuff for it to work. We cant use the above parameter in HealthLoss it has to be something past into the activeBuff()
            int CacheArmour = 0;
            int CacheMagicalresistance = 0;
            for (int per = 0; per < percentageHealthLoss; per++)
            {
                Instance.Armour += (int)(Instance.Armour * 0.02);
                CacheArmour += (int)(Instance.Armour * 0.02);
                Instance.MagicRes += (int)(Instance.MagicRes * 0.02);
                CacheMagicalresistance += (int)(Instance.MagicRes * 0.02);
            }
            if (GameOver==true)
            {
                Instance.Armour -= CacheArmour;
                Instance.MagicRes -= CacheMagicalresistance;
                CacheArmour = 0;
                CacheMagicalresistance = 0;
            }

            */

            #endregion
        }
        public override void LevelIncrease()
        {
            Instance.ExperienceLevel++;
            if (Foe == false)
            {

                Instance.Health += 40 * Instance.ExperienceLevel;
                Instance.dodge += 1 * Instance.ExperienceLevel;
                Instance.Speed += 1 * Instance.ExperienceLevel;
                Instance.CritC += 1 * Instance.ExperienceLevel;
                Instance.MagicRes += 1 * Instance.ExperienceLevel;
                Instance.Armour += 2 * Instance.ExperienceLevel;
                Instance.LowDamage = true;
                if (LowDamage == true)
                { Instance.Damage += 2 * Instance.ExperienceLevel; Instance.LowDamage = false; }
                else
                {
                    Instance.Damage += 2 * Instance.ExperienceLevel;
                }
            }
            else
            {
                Instance.Health += 8 * Instance.ExperienceLevel;
                Instance.dodge += 0 * Instance.ExperienceLevel;
                Instance.Speed += 1 * Instance.ExperienceLevel;
                Instance.CritC += 1 * Instance.ExperienceLevel;
                Instance.MagicRes += 1 * Instance.ExperienceLevel;
                Instance.Armour += 2 * Instance.ExperienceLevel;
                Instance.LowDamage = true;
                if (LowDamage == true)
                { Instance.Damage += 1 * Instance.ExperienceLevel; Instance.LowDamage = false; }
                else
                {
                    Instance.Damage += 1 * Instance.ExperienceLevel;
                }
            }
            //fire levelIncrease animation
            new SerializedObjectManager().SaveData(this, new SerializedObjectManager().paths[0] + CharacterName);
        }
        public override int DamageGiven()
        {
            int damageGiven = 0;
            if (Foe == false)
            {
                Random r = new Random();
                damageGiven = r.Next(8, 14);
            }
            else
            {
                Random r = new Random();
                damageGiven = r.Next(2, 5);
            }

            return damageGiven;
        }
        #endregion
    }
}
