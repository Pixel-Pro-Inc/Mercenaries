using Assets.Scripts.Entities.Character;
using Assets.Scripts.Models;
using Assets.Scripts.MonoBehaviours;
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

        // Youll notice yewo that i added these defencePbjects that you didnt make. But they were necessary for the Gods Mechanism
        //!!            !!!                 !!!


        public void Armour(bool state, int amount)
        {
            amount = (int)(amount * (1f + (float)target.defenceArmourPercentage));
            target.ToggleMagicRes(state, amount);

            DefendObject defendObject = new DefendObject()
            {
                state = true,
                type = Enums.DefenceType.Armour,
                amount = amount
            };
            if (target.Foe == false)
            {
                GameManager.Instance.TeamDefence.Add(defendObject);
            }
        }
        public void MagicalResistance(bool state, int amount)
        {
            amount = (int)(amount * (1f + (float)target.defenceMagresPercentage));
            target.ToggleMagicRes(state, amount);

            DefendObject defendObject = new DefendObject()
            {
                state = true,
                type = Enums.DefenceType.MagicalResistance,
                amount = amount
            };
            if (target.Foe == false)
            {
                GameManager.Instance.TeamDefence.Add(defendObject);
            }
        }
        public void Shield(bool state, int amount)
        {
            amount = (int)(amount * (1f + (float)target.defenceSheildPercentage));
            target.ToggleShield(state, amount);
            DefendObject defendObject = new DefendObject()
            {
                state = true,
                type = Enums.DefenceType.Shield,
                amount = amount
            };
            if (target.Foe == false)
            {
                GameManager.Instance.TeamDefence.Add(defendObject);
            }
        }
        public void Purified(bool state)
        {
            target.TogglePurified(state);
            DefendObject defendObject = new DefendObject()
            {
                state = true,
                type = Enums.DefenceType.Purified
            };
            if (target.Foe == false)
            {
                GameManager.Instance.TeamDefence.Add(defendObject);
            }
        }
        public void Block(bool state)
        {
            target.ToggleBlock(state);
            DefendObject defendObject = new DefendObject()
            {
                state = true,
                type = Enums.DefenceType.Block,
            };
            if (target.Foe == false)
            {
                GameManager.Instance.TeamDefence.Add(defendObject);
            }
        }
        public void Immune(bool state)
        {
            target.ToggleImmune(state);
            DefendObject defendObject = new DefendObject()
            {
                state = true,
                type = Enums.DefenceType.Immune,
            };
            if (target.Foe == false)
            {
                GameManager.Instance.TeamDefence.Add(defendObject);
            }
        }
    }
}
