using Assets.Scripts.Entities.Character;
using Assets.Scripts.Models;
using Assets.Scripts.MonoBehaviours;
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
        public void CreateDebuff(object TargetInstance, double debuffPercent, debuffType type, int lifeTime) //this would prolly be the last thing thats called in the method
        {
            Persona Target = (Persona)TargetInstance;
            DebuffObject debuffObject = new DebuffObject()
            {
                state = true,
                type = type,
                amount = debuffPercent,
                lifeTime = 2,//lifeTime,
                roundsActive = 0
            };
            Target.AddDebuff(debuffObject);
            if (Target.Foe == false)
            {
                Target.GetComponent<GameManager>().TeamDeBuffs.Add(debuffObject);
            }

            EffectType effectType = EffectType.Balanced;

            switch (type)
            {
                case debuffType.Slow:
                    break;
                case debuffType.Rooted:
                    effectType = EffectType.Rooted;
                    break;
                case debuffType.WeakGrip:
                    break;
                case debuffType.Exiled:
                    break;
                case debuffType.Marked:
                    break;
                case debuffType.Calm:
                    break;
                case debuffType.BrokenGaurd:
                    break;
                case debuffType.Burnt:
                    break;
                case debuffType.Stun:
                    break;
                case debuffType.Freeze:
                    break;
                case debuffType.Cold:
                    break;
                case debuffType.Blinded:
                    break;
                case debuffType.Tainted:
                    break;
                case debuffType.Sleep:
                    break;
                case debuffType.Hungry:
                    break;
                case debuffType.Healthy:
                    break;
                case debuffType.UnHealthy:
                    break;
                case debuffType.GodsAnger:
                    break;
                default:
                    break;
            }

            if (!effectType.Equals(EffectType.Balanced))
                GameManager.Instance.InstantiateEffect(effectType, ((Persona)TargetInstance).characterBehaviour);
        }
    }
}
