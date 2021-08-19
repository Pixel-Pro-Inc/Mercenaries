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
        }

        #region Character variables
        public override string CharacterName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string CharacterDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string BriefDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private int _health = 0;
        public override int Health
        {
            get { return Health; }
            set
            {
                if (Health < 0) _health = 0;
                if (Foe == false)
                {
                    _health = 120;
                }
                else
                {
                    _health = 25;
                }
            }
        }

        private double _dodge = 0;
        public override double dodge
        {
            get { return _dodge; }
            set
            {
                if (dodge < 0) _dodge = 0;
                if (Foe == false)
                {
                    _dodge = 1;
                }
                else
                {
                    _dodge = 0;
                }
            }
        }

        private double _Speed = 0;
        public override double Speed
        {
            get { return _Speed; }
            set
            {
                if (Speed < 0) _Speed = 0;
                if (Foe == false)
                {
                    _Speed = 1;
                }
                else
                {
                    _Speed = 1;
                }
            }
        }

        private double _CritC = 0;
        public override double CritC
        {
            get { return _CritC; }
            set
            {
                if (CritC < 0) _CritC = 0;
                if (Foe == false)
                {
                    _CritC = 3;
                }
                else
                {
                    _CritC = 1;
                }
            }
        }

        private int _Damage = 0;
        public override int Damage
        {
            get { return _Damage; }
            set
            {
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
                    _Accuracy = 80;
                }
                else
                {
                    _Accuracy = 0;
                }
                if (Accuracy < 0) _Accuracy = 0;
            }
        }

        private int _MAgicRes = 0;
        public override int MagicRes
        {
            get { return _MAgicRes; }
            set
            {
                if (Foe == false)
                {
                    _MAgicRes = 5;
                }
                else
                {
                    _MAgicRes = 5;
                }
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
                    _Armour = 5;
                }
            }
        }

        private int _Shield = 0;
        public override int shield
        {
            get { return _Shield; }
            set
            {
                if (Foe == false)
                {
                    _Shield = 2;
                }
                else
                {
                    _Shield = 0;
                }
                if (shield < 0) _Shield = 0;
            }
        }

        
        public List<string> NaturalAllies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<string> NaturalEnemies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool PassiveTankTraits { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int HitCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool PassiveWarriorTraits { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        #endregion
        #region Character Methods

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
