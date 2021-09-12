using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public class Enums
    {
        public enum EffectType
        {
            Bleed,
            Blight,
            Ignite,
            Balanced,
            Rooted,
            Chosen,
            Exhausted,
            Magical_Damage,
            Physical_Damage,
            Ranged_Physical_Damage
        }
        public enum AttackType
        {
            TrueDamage,
            PhysicalDamage,
            MagicalDamage, 
            Drain,
            Ignite,
            Bleed,
            Blight,
            BalancedDamage,
            Curse, 
            Feign
        }
        public enum WhoseInControl
        {
            Human,
            CPU
        }
        public enum debuffType
        {
            Slow,
            Rooted,
            WeakGrip,
            Exiled,
            Marked,
            Calm,
            BrokenGaurd,
            Burnt,
            Stun,
            Freeze,
            Cold,
            Blinded,
            Tainted,
            Sleep,
            Hungry,
            Healthy,
            UnHealthy,
            GodsAnger,
        }
        public enum buffType
        {
            Agile,
            PolishedWeapon,
            Chosen,
            Aware,
            OnGuard,
            Provoking,
            Protector,//i am honestly debating on whether Protector is even a Buff
            Protected,
            Revigorate,// i didn't even give this a BuffObject, cause really its a once off method
            HealVictim,// i didn't even give this a BuffObject, cause really its a once off method
            GodsBlessing
        }
        public enum cardName
        {
            lionFirstCard,
            lionSecondCard,
            lionThirdCard,
            lionFourthCard,
            lionFifthCard,
            lionSixthCard,
            lionSeventhCard,
            lionEighthCard,
            lionNinthCard,
            crocodileFirstCard,
            crocodileSecondCard,
            crocodileThirdCard,
            crocodileFourthCard,
            crocodileFifthCard,
            crocodileSixthCard,
            crocodileSeventhCard,
            crocodileEighthCard,
            crocodileNinthCard,
            fishFirstCard,
            fishSecondCard,
            fishThirdCard,
            fishFourthCard,
            fishFifthCard,
            fishSixthCard,
            fishSeventhCard,
            fishEighthCard,
            fishNinthCard,
            salamanderFirstCard,
            salamanderSecondCard,
            salamanderThirdCard,
            salamanderFourthCard,
            salamanderFifthCard,
            salamanderSixthCard,
            salamanderSeventhCard,
            salamanderEighthCard,
            salamanderNinthCard,
            frogFirstCard,
            frogSecondCard,
            frogThirdCard,
            frogFourthCard,
            frogFifthCard,
            frogSixthCard,
            frogSeventhCard,
            frogEighthCard,
            frogNinthCard,
            tritonFirstCard,
            tritonSecondCard,
            tritonThirdCard,
            tritonFourthCard,
            tritonFifthCard,
            tritonSixthCard,
            tritonSeventhCard,
            tritonEighthCard,
            tritonNinthCard,
        }
        public enum enemyType
        {
            Boss,
            Elite,
            Normal,
            Minion
        }
        public enum PositiveQuirkList
        {
            Masoquist,
            i_can_crit,
            SharpEyesight,
            GoodReflexes,
            Healthy,
            Shaman,
            BreathDeep,
            Wild,
            LastRun,
            Agile,
            StrongBones,
            Blessed,
            Ranger,
            Eagleyes,
            SharpFists,
            SprintBurst,
            GoodGenetics,
            Strong,
        }
        public enum NegativeQuirkList
        {
            Fragile,
            WeakAim,
            SlowReflexes,
            Ill,
            Invalid,
            Desperate,
            Nanism,
            Dehydrated,
            Nerfed,
            WeakBones,
            CursedByTheGods,
            BadVision,
            GrandMa,
            Tendinits,
            Slowed,
            BadGenetics,
            Weakened
        }
    }
}
