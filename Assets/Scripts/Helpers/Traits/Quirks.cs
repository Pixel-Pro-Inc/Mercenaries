using Assets.Scripts.Entities.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assets.Scripts.Models.Enums;

namespace Assets.Scripts.Helpers.Traits
{
    public class Quirks : Persona
    {
        public void MyHeroAcademia(QuirkColour quirkColour)
        {
            QuirkColour = quirkColour;

            foreach (PositiveQuirks positive in OneForAll((CharacterName, QuirkColour)))
            {
                PositiveQuirkSet(positive);
            }

            foreach (NegativeQuirks negative in AllForOne((CharacterName, QuirkColour)))
            {
                NegativeQuirkSet(negative);
            }
            
        }

        public PositiveQuirks[] OneForAll((string, QuirkColour) DekuArchives) => DekuArchives switch
        {
           ("Peter",QuirkColour.Red)=> new PositiveQuirks[] {PositiveQuirks.SharpEyesight,PositiveQuirks.StrongBones },
            _ => null
        };

        public NegativeQuirks[] AllForOne((string, QuirkColour) TomuraArchives) => TomuraArchives switch
        {
            ("Peter", QuirkColour.Red) => new NegativeQuirks[] { NegativeQuirks.Fragile,NegativeQuirks.WeakAim },
            _ => null
        };

        //These set the values onto the character
        void PositiveQuirkSet(PositiveQuirks Positive)
        {
            switch (Positive)
            {
                case PositiveQuirks.Masoquist:
                    break;
                case PositiveQuirks.i_can_crit:
                    break;
                case PositiveQuirks.SharpEyesight:
                    break;
                case PositiveQuirks.GoodReflexes:
                    break;
                case PositiveQuirks.Healthy:
                    break;
                case PositiveQuirks.Shaman:
                    break;
                case PositiveQuirks.BreathDeep:
                    break;
                case PositiveQuirks.Wild:
                    break;
                case PositiveQuirks.LastRun:
                    break;
                case PositiveQuirks.Agile:
                    break;
                case PositiveQuirks.StrongBones:
                    break;
                case PositiveQuirks.Blessed:
                    break;
                case PositiveQuirks.Ranger:
                    break;
                case PositiveQuirks.Eagleyes:
                    break;
                case PositiveQuirks.SharpFists:
                    break;
                case PositiveQuirks.SprintBurst:
                    break;
                case PositiveQuirks.GoodGenetics:
                    break;
                case PositiveQuirks.Strong:
                    break;
                default:
                    break;
            }
        }
        void NegativeQuirkSet(NegativeQuirks Negative)
        {
            switch (Negative)
            {
                case NegativeQuirks.Fragile:
                    break;
                case NegativeQuirks.WeakAim:
                    break;
                case NegativeQuirks.SlowReflexes:
                    break;
                case NegativeQuirks.Ill:
                    break;
                case NegativeQuirks.Invalid:
                    break;
                case NegativeQuirks.Desperate:
                    break;
                case NegativeQuirks.Nanism:
                    break;
                case NegativeQuirks.Dehydrated:
                    break;
                case NegativeQuirks.Nerfed:
                    break;
                case NegativeQuirks.WeakBones:
                    break;
                case NegativeQuirks.CursedByTheGods:
                    break;
                case NegativeQuirks.BadVision:
                    break;
                case NegativeQuirks.GrandMa:
                    break;
                case NegativeQuirks.Tendinits:
                    break;
                case NegativeQuirks.Slowed:
                    break;
                case NegativeQuirks.BadGenetics:
                    break;
                case NegativeQuirks.Weakened:
                    break;
                default:
                    break;
            }
        }

    }
}
