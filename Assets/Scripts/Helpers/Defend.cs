using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Helpers
{
    public class Defend
    {
        CharacterPersona _characterPersona;
        public Defend(CharacterPersona characterPersona)
        {
            _characterPersona = characterPersona;
        }
        public void Armour(bool state, int armourAmount, int type)
        {
            switch (type)
            {
                case 1:
                    _characterPersona.WarriorCBase.Armour += armourAmount;
                    break;
                case 2:
                    _characterPersona.TankCBase.Armour += armourAmount;
                    break;
                case 3:
                    _characterPersona.RangeCBase.Armour += armourAmount;
                    break;
                case 4:
                    _characterPersona.MageCBase.Armour += armourAmount;
                    break;
                case 5:
                    _characterPersona.ControllerCBase.Armour += armourAmount;
                    break;
                case 6:
                    _characterPersona.AssasinCBase.Armour += armourAmount;
                    break;
            }
        }
        public void MagicalResistance(bool state, int amount, int type)
        {
            switch (type)
            {
                case 1:
                    _characterPersona.WarriorCBase.ToggleMagicRes(state, amount);
                    break;
                case 2:
                    _characterPersona.TankCBase.ToggleMagicRes(state, amount);
                    break;
                case 3:
                    _characterPersona.RangeCBase.ToggleMagicRes(state, amount);
                    break;
                case 4:
                    _characterPersona.MageCBase.ToggleMagicRes(state, amount);
                    break;
                case 5:
                    _characterPersona.ControllerCBase.ToggleMagicRes(state, amount);
                    break;
                case 6:
                    _characterPersona.AssasinCBase.ToggleMagicRes(state, amount);
                    break;
            }
        }
        public void Shield(bool state, int amount, int type)
        {
            switch (type)
            {
                case 1:
                    _characterPersona.WarriorCBase.ToggleShield(state, amount);
                    break;
                case 2:
                    _characterPersona.TankCBase.ToggleShield(state, amount);
                    break;
                case 3:
                    _characterPersona.RangeCBase.ToggleShield(state, amount);
                    break;
                case 4:
                    _characterPersona.MageCBase.ToggleShield(state, amount);
                    break;
                case 5:
                    _characterPersona.ControllerCBase.ToggleShield(state, amount);
                    break;
                case 6:
                    _characterPersona.AssasinCBase.ToggleShield(state, amount);
                    break;
            }
        }
        public void Purified(bool state, int type)
        {
            switch (type)
            {
                case 1:
                    _characterPersona.WarriorCBase.TogglePurified(state);
                    break;
                case 2:
                    _characterPersona.TankCBase.TogglePurified(state);
                    break;
                case 3:
                    _characterPersona.RangeCBase.TogglePurified(state);
                    break;
                case 4:
                    _characterPersona.MageCBase.TogglePurified(state);
                    break;
                case 5:
                    _characterPersona.ControllerCBase.TogglePurified(state);
                    break;
                case 6:
                    _characterPersona.AssasinCBase.TogglePurified(state);
                    break;
            }
        }
        public void Block(bool state, int type)
        {
            switch (type)
            {
                case 1:
                    _characterPersona.WarriorCBase.ToggleBlock(state);
                    break;
                case 2:
                    _characterPersona.TankCBase.ToggleBlock(state);
                    break;
                case 3:
                    _characterPersona.RangeCBase.ToggleBlock(state);
                    break;
                case 4:
                    _characterPersona.MageCBase.ToggleBlock(state);
                    break;
                case 5:
                    _characterPersona.ControllerCBase.ToggleBlock(state);
                    break;
                case 6:
                    _characterPersona.AssasinCBase.ToggleBlock(state);
                    break;
            }
        }
        public void Immune(bool state, int type)
        {
            switch (type)
            {
                case 1:
                    _characterPersona.WarriorCBase.ToggleImmune(state);
                    break;
                case 2:
                    _characterPersona.TankCBase.ToggleImmune(state);
                    break;
                case 3:
                    _characterPersona.RangeCBase.ToggleImmune(state);
                    break;
                case 4:
                    _characterPersona.MageCBase.ToggleImmune(state);
                    break;
                case 5:
                    _characterPersona.ControllerCBase.ToggleImmune(state);
                    break;
                case 6:
                    _characterPersona.AssasinCBase.ToggleImmune(state);
                    break;
            }
        }
    }
}
