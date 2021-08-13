using Assets.Scripts.Entities.Character;
using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assets.Scripts.Models.Enums;

namespace Assets.Scripts.Helpers
{
    public class Debuff
    {
        void CreateDebuff(object TargetInstance, double debuffPercent, debuffType type, int lifeTime) //this would prolly be the last thing thats called in the method
        {
            DebuffObject debuffObject = new DebuffObject()
            {
                state = true,
                type = type,
                amount = debuffPercent,
                lifeTime = lifeTime,
                roundsActive = 0
            };

            ((Persona)TargetInstance).AddDebuff(debuffObject);
        }
        
        public void Slow(object CharacterInstance, object TargetInstance)
        {
            CreateDebuff(TargetInstance, 67, debuffType.Slow, 77); //this was just to make sure it works. Yewo is going to have to populate the method above this
        }

        public void Rooted(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }
        public void WeakGrip(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }
        public void Exiled(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }
        public void Marked(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }
        public void Calm(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }
        public void BrokenGuard(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }
        public void Burnt(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }
        public void Stun(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }
        public void Freeze(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }
        public void Cold(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }
        public void Blinded(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }
        public void Tainted(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }
        public void Sleep(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }
        public void Hungry(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }
        public void Unhealthy(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }
        public void GodsAnger(object CharacterInstance, List<string> Allies)
        {
            throw new NotImplementedException();
        }
    }
}
