using Assets.Scripts.Entities.Character;
using Assets.Scripts.Models;
using Assets.Scripts.MonoBehaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using UnityEngine;
using static Assets.Scripts.Models.Enums;

namespace Assets.Scripts.Helpers.Traits
{
    public class Quirks : Persona
    {
        public void MyHeroAcademia(QuirkColour quirkColour)
        {
            QuirkColour = quirkColour; //Sets the Caller of this methods quirk colour this colour

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
                    Timer Chpin; Chpin = new Timer(); Chpin.Elapsed += new ElapsedEventHandler(impro); Chpin.Interval = 1000; Chpin.Enabled = true;
                    void impro(object source2, ElapsedEventArgs e)
                    {
                        if (Health < 0.5 * Life) CritC *= 1.02;
                    }
                    break;
                case PositiveQuirks.i_can_crit:
                    CritC *= 1.02;
                    break;
                case PositiveQuirks.SharpEyesight:
                    if (this.GetComponent<Persona>().GetType() == typeof(RangeTemplate)) CritC *= 1.02;
                    break;
                case PositiveQuirks.GoodReflexes:
                    dodge += 3;
                    break;
                case PositiveQuirks.Healthy:
                    int BuffCount = this.GetComponent<GameManager>().TeamBuffs.Count;

                    Timer Tino; Tino = new Timer(); Tino.Elapsed += new ElapsedEventHandler(walk); Tino.Interval = 1000; Tino.Enabled = true;
                    void walk(object source2, ElapsedEventArgs e)
                    {
                        if (BuffCount!= this.GetComponent<GameManager>().TeamBuffs.Count)
                        {
                            BuffCount = this.GetComponent<GameManager>().TeamBuffs.Count;
                            foreach (BuffObject item in this.GetComponent<GameManager>().TeamBuffs)
                            {
                                if ((object)item.target == this.GetComponentInChildren<Persona>() && item.type == buffType.HealVictim)
                                {
                                    this.GetComponentInChildren<Persona>().Health += (int)(this.GetComponentInChildren<Persona>().Health * 0.1);
                                }
                            }
                        }
                    }
                   
                    break;
                case PositiveQuirks.Shaman:
                    HealBuffPercent += 0.05;
                    break;
                case PositiveQuirks.BreathDeep:
                    Timer Team; Team = new Timer(); Team.Elapsed += new ElapsedEventHandler(Impala); Team.Interval = 1000; Team.Enabled = true;
                    void Impala(object source2, ElapsedEventArgs e)
                    {
                        if (Health < 0.5 * Life) Speed += 1;
                    }
                    break;
                case PositiveQuirks.Wild:
                    Debug.Log("This one is you Yewo, Hunger is Debuff territory");
                    /*
                      if (hunger<26)
                    {
                       PowerBuffPercent += 0.1;
                    PolishWeapon(this);
                    }
                     */
                    break;
                case PositiveQuirks.LastRun:
                    Debug.Log("This one is you Yewo, Hunger is Debuff territory");
                    /*
                     if (hunger<26)
                   {
                       Speed += 2;
                   }
                    */
                    break;
                case PositiveQuirks.Agile:
                    if (RoundInfo.RoundsPassed==0)
                    {
                        Speed += 4; dodge +=5;
                    }
                    else { Speed -= 4; dodge -= 5; }
                    break;
                case PositiveQuirks.StrongBones:
                    Debug.Log("This one is you Yewo, stun is Debuff territory.Alexs wants Stun resist, Fight him, this is tyranny");
                    break;
                case PositiveQuirks.Blessed:
                    Speed += 2;dodge += 5;
                    break;
                case PositiveQuirks.Ranger:
                    if (this.GetComponent<Persona>().GetType() == typeof(RangeTemplate)) Accuracy += 5;
                    break;
                case PositiveQuirks.Eagleyes:
                    Accuracy += 5;
                    break;
                case PositiveQuirks.SharpFists:
                    if (this.GetComponent<Persona>().GetType() == typeof(WarriorTemplate)||(this.GetComponent<Persona>().GetType() == typeof(TankWarriorTemplate)))
                    { CritC *= 1.03; }
                    break;
                case PositiveQuirks.SprintBurst:
                    if (RoundInfo.RoundsPassed == 0)
                    {
                        Speed += 4; 
                    }
                    else { Speed += 4;}
                    break;
                case PositiveQuirks.GoodGenetics:
                    Life +=(int)( .03*Life); Health +=(int)(.03*Health);
                    break;
                case PositiveQuirks.Strong:
                    //Im not even gonna bother touching this. He keeps adding and making thse up as he goes
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
                    Timer Chpin; Chpin = new Timer(); Chpin.Elapsed += new ElapsedEventHandler(impro); Chpin.Interval = 1000; Chpin.Enabled = true;
                    void impro(object source2, ElapsedEventArgs e)
                    {
                        if (Health < 0.5 * Life) CritC *= 0.95;
                    }
                    break;
                case NegativeQuirks.WeakAim:
                    if (this.GetComponent<Persona>().GetType() == typeof(RangeTemplate)) CritC *= .95;
                    break;
                case NegativeQuirks.SlowReflexes:
                    dodge -= 5;
                    break;
                case NegativeQuirks.i_cant_crit:
                    CritC *= .98;
                    break;
                case NegativeQuirks.Ill:
                    int BuffCount = this.GetComponent<GameManager>().TeamBuffs.Count;

                    Timer Tino; Tino = new Timer(); Tino.Elapsed += new ElapsedEventHandler(walk); Tino.Interval = 1000; Tino.Enabled = true;
                    void walk(object source2, ElapsedEventArgs e)
                    {
                        if (BuffCount != this.GetComponent<GameManager>().TeamBuffs.Count)
                        {
                            BuffCount = this.GetComponent<GameManager>().TeamBuffs.Count;
                            foreach (BuffObject item in this.GetComponent<GameManager>().TeamBuffs)
                            {
                                if ((object)item.target == this.GetComponentInChildren<Persona>() && item.type == buffType.HealVictim)
                                {
                                    this.GetComponentInChildren<Persona>().Health += (int)(this.GetComponentInChildren<Persona>().Health * 0.2);
                                }
                            }
                        }
                    }
                    break;
                case NegativeQuirks.Invalid:
                    HealBuffPercent -= 0.05;
                    break;
                case NegativeQuirks.Desperate:
                    Timer Alex; Alex = new Timer(); Alex.Elapsed += new ElapsedEventHandler(deLion); Alex.Interval = 1000; Alex.Enabled = true;
                    void deLion(object source2, ElapsedEventArgs e)
                    {
                        if (Health < 0.5 * Life)Speed-=1;
                    }
                    break;
                case NegativeQuirks.Nanism:
                    Debug.Log("This one is you Yewo, Hunger is Debuff territory");
                    /*
                      if (hunger<26)
                    {
                       PowerBuffPercent -= 0.1;
                    PolishWeapon(this);
                    }
                     */
                    break;
                case NegativeQuirks.Dehydrated:
                    Debug.Log("This one is you Yewo, Hunger is Debuff territory");
                    /*
                      if (hunger<26)
                    {
                      Speed-=2;
                    }
                     */
                    //what you gonna do?
                    break;
                case NegativeQuirks.Nerfed:
                    if (RoundInfo.RoundsPassed == 0)
                    {
                        Speed -= 4; dodge -= 5;
                    }
                    else { Speed += 4; dodge += 5; }
                    break;
                case NegativeQuirks.WeakBones:
                    Debug.Log("This one is you Yewo, stun is Debuff territory.Alexs wants Stun resist, Fight him, this is tyranny");
                    break;
                case NegativeQuirks.CursedByTheGods:
                    Speed -= 2; dodge -= 5;
                    break;
                case NegativeQuirks.BadVision:
                    if (this.GetComponent<Persona>().GetType() == typeof(RangeTemplate)) Accuracy -= 5;
                    break;
                case NegativeQuirks.GrandMa:
                    Accuracy -= 5;
                    break;
                case NegativeQuirks.Tendinits:
                    if (this.GetComponent<Persona>().GetType() == typeof(WarriorTemplate) || (this.GetComponent<Persona>().GetType() == typeof(TankWarriorTemplate)))
                    { CritC *= .95; }
                    break;
                case NegativeQuirks.Slowed:
                    if (RoundInfo.RoundsPassed == 0)
                    {
                        Speed -= 4; Debug.Log("Alex, this Slowed quirk already done and is a little redundant. Please remove this as an Idea");
                    }
                    else { Speed += 4; }
                    break;
                case NegativeQuirks.BadGenetics:
                    Life -= (int)(.1 * Life); Health -= (int)(.1 * Health);
                    break;
                case NegativeQuirks.Weakened:
                    Life -= (int)(.05 * Life); Health -= (int)(.05 * Health);
                    break;
                default:
                    break;
            }
        }

    }
}
