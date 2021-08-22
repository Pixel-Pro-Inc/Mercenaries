using Assets.Scripts.Entities.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Helpers
{
    public class Defend
    {
        private Persona target;
        public Defend(Persona _target)
        {
            target = _target;
        }
        public void Armour(bool state, int amount)
        {
            amount = (int)(amount * target.defenceArmourPercentage);
            target.ToggleMagicRes(state, amount);
        }
        public void MagicalResistance(bool state, int amount)
        {
            amount = (int)(amount * target.defenceMagresPercentage);
            target.ToggleMagicRes(state, amount);
        }
        public void Shield(bool state, int amount)
        {
            amount = (int)(amount * target.defenceSheildPercentage);
            target.ToggleShield(state, amount);
        }
        public void Purified(bool state)
        {
            target.TogglePurified(state);
        }
        public void Block(bool state)
        {
            target.ToggleBlock(state);
        }
        public void Immune(bool state)
        {
            target.ToggleImmune(state);
        }
    }
}
