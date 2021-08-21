using Assets.Scripts.Entities.Item;
using Assets.Scripts.Helpers;
using Assets.Scripts.Interface;
using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using UnityEngine;
using static Assets.Scripts.Models.Enums;
using Random = System.Random;

namespace Assets.Scripts.Entities.Character
{
    public class Persona: Individual, IPersona, ICombatAction
    {
        //We aren't making persona abstract cause we need to use it as a template in some logic
        //Anything here thats not virtual will be the same for all characters
        public Persona()
        {
            if(RoundInfo.GameInSession==true) BlackList();// this is to make a sequence of enemies who last hit you up to five
        }

        #region GivenCharacterTraits

        public enum Kingdom { FarWest, MiddleEarth, DarkSyde };

        public enum MasterCharacterList
        {
            //Here a list of strings of every individual character will be defined.Then they will be accessed with their indexes as needed in below lists eg List<>Allies
            #region Heros
            Peter, Mister_Glubglub, Mister_Froggo, Mister_Salaboned, Mister_Lizzacorn, Mister_Liodin, Mister_Lacrox, Mister_Birbarcher, Mister_PirateParrot,
            Mister_SilverSkull, Mister_Mantis, Mister_Hippo,
            #endregion
            #region Foes
            HammerHead, GreatWhite, SpiderCrustacean, NecroBoar, ElderStag, DevilBird, DragonSloth
            #endregion
        }
        public List<object> Master { get; set; }
        public List<object> Allies { get; set; }
        public List<object> Enemies { get; set; }

        #region Combat Object Lists

        public List<AttackObject> AttacksGiven { get; set; }
        public List<DefendObject> DefenceSet { get; set; }
        public List<BuffObject> BuffsInEffect { get; set; }
        public List<DebuffObject> DebuffsInEffect { get; set; }

        #endregion

        public enum SpeciesType
        {
            Lion,
            Crocodile,
            Fish,
            Salamander,
            Frog,
            Triton,
            Bird,
            Parrot,
            Insect,
            Hippo,
            Boar,
            Deer,
            Sloth,
            Enemy// thiis here is actually used so we might as well change foe using this
        };
        public bool RemoveDebuffEffects { get; set; }

        #endregion
        #region Character Traits
        #region Stats
        public virtual string CharacterName { get { return CharacterName; } set { CharacterName = "UnKnown"; } }
        public virtual string CharacterDescription { get { return CharacterDescription; } set { CharacterDescription = "UnKnown"; } } //Here the personality and backstory of a unique character will be defined
        public SpeciesType CharacterSpecies { get; set; }

        private bool _foe { get; set; }
        public virtual bool Foe { get { return _foe; } set { _foe = value; } }

        private int _Life = 0;
        public virtual int Life
        {
            get { return _Life; }
            set
            {
                if (Life < 0) _Life = 0;
                _Life = value;
                _Life = Health;
            }
        }

        private int _health = 0;
        public virtual int Health
        {
            get { return _health; }
            set
            {
                if (Health < 0) Health = 0;
                if (Foe == false)
                {
                    _health = 0;
                }
                else
                {
                    _health = 0;
                }
            }
        }

        private double _dodge = 0;
        public virtual double dodge
        {
            get { return _dodge; }
            set
            {
                if (Foe == false)
                {
                    _dodge = 0;
                }
                else
                {
                    _dodge = 0;
                }
                if (dodge < 0) _dodge = 0;

            }
        }

        private double _speed = 0;
        public virtual double Speed
        {
            get { return _speed; }
            set
            {
                if (Foe == false)
                {
                    _speed = 0;
                }
                else
                {
                    _speed = 0;
                }
                if (Speed < 0) _speed = 0;

            }
        }

        private double _CritC = 0;
        public virtual double CritC
        {
            get { return _CritC; }
            set
            {
                if (Foe == false)
                {
                    _CritC = 0;
                }
                else
                {
                    _CritC = 0;
                }
                if (CritC < 0) _CritC = 0;

            }
        }

        private int _magicRes = 0;
        public virtual int MagicRes
        {
            get { return _magicRes; }
            set
            {
                if (Foe == false)
                {
                    _magicRes = 0;
                }
                else
                {
                    _magicRes = 0;
                }
                if (MagicRes < 0) _magicRes = 0;

            }
        }

        private int _armour = 0;
        public virtual int Armour
        {
            get { return _armour; }
            set
            {
                if (Foe == false)
                {
                    _armour = 0;
                }
                else
                {
                    _armour = 0;
                }
                if (Armour < 0) _armour = 0;

            }
        }

        private int _shield = 0;
        public virtual int shield
        {
            get { return _shield; }
            set
            {
                if (Foe == false)
                {
                    _shield = 0;
                }
                else
                {
                    _shield = 0;
                }
                if (shield < 0) _shield = 0;
            }
        }

        public virtual int Damage { get; set; }
        public virtual int HitCount { get; set; }
        public virtual double Accuracy { get; set; }
        public bool LowDamage { get; set; }

        private int _expPoints = 0;
        public int ExpPoints
        {
            get { return _expPoints; }
            set
            {
                if (RoundInfo.RoundDone == true/*This means characters can level up durning battle*/)
                {
                    _expPoints += NewEarnedXp;
                }
                if (ExpPoints > 1000)
                {
                    LevelIncrease();
                    _expPoints -= 1000;
                }
            }
        }

        private int _NewExpoint = 0;
        public int NewEarnedXp
        {
            get { return _NewExpoint; }
            set
            {
                if (NewEarnedXp < 0) NewEarnedXp = 0;
                if (EarnedXp == true)
                {
                    _NewExpoint = NewEarnedXp;
                }
                else
                {
                    _NewExpoint = 0;
                }
            }
        }

        private bool _EarnedXp = false;
        public bool EarnedXp
        {
            get { return _EarnedXp; }
            set
            {
                if (RoundInfo.RoundDone == false/*This means characters can level up durning battle*/)
                {
                    _EarnedXp = false;
                }
            }
        } //This bool is made true when XPIncrease is fired and should be made of when sessionOver is true

        internal int ExperienceLevel { get { return ExperienceLevel; } set { if (ExperienceLevel < 0) ExperienceLevel = 0; } }

        /*
          int Mana
        {
            get; set;
            // We never discussed if Mana was going to be used so I just put it cause, I mean RPG right, we have to nerf the characters somehow right.
            //Pluss in my head the cards that a character will be able to use from the many cards on deck will be dependant on the amount of mana the individual 
            //character has currently
        }
        int Stamina { get; set; }//I assume the hunger method will affect this trait
         */
        //Above is the mana and stamina int

        #endregion
        #region Attack Percent

        //These below have to be int cause they are used as in the Random method Random.Next()
        public int DrainPercent { get; set; }
        public int CursePercent { get; set; }
        public bool CriticalChance { get; set; }

        #endregion
        #region Defend Percent

        public bool ImmuneState { get; set; }
        public bool BlockState { get; set; }
        public virtual bool ArmourState { get; private set; }
        public virtual bool MagicResState { get; private set; }
        public virtual bool shieldState { get; private set; }
        public virtual bool PurifiedState { get; private set; }
        public double defenceArmourPercentage { get; set; } //this is made cause there were tailored values that are used
        public double defenceMagresPercentage { get; set; }
        public double defenceSheildPercentage { get; set; }
        #endregion
        #region Buff Percent

        public double PowerBuffPercent { get; set; }
        public double EvadeBuffPercent { get; set; }
        public double AgileBUffPercent { get; set; }
        public double HealBuffPercent { get; set; }
        public double counterAttackPercent { get; set; }
        public double MagiBuffPercent { get; set; }
        public double ProvokingBuffPercent { get; set; }
        public object ProtectionSponser { get; set; }
        public object AttackSponser { get; set; } // This is to store who last attacked a character

        #endregion
        #region DeBuff Percent

        public double SlowDeBuffPercent { get; set; }
        public double RootedDeBuffPercent { get; set; }
        public double WeakGripDeBuffPercent { get; set; }
        public double ExiledDeBuffPercent { get; set; }
        public double MarkedDeBuffPerent { get; set; }
        public double CalmDeBuffPercent { get; set; }
        public virtual bool stunState { get; set; }
        public virtual bool freezeState { get; set; }

        //Yewo's Variables

        public int debuffChance { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double BrokenGaurdDeBuffPercent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double ColdDeBuffPercent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double BlindedDeBuffPercent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double TaintedDebuffPercent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #endregion

        #endregion
        #region Character Methods

        public virtual int DamageGiven()
        {
            int damageGiven = 0;
            if (Foe == false)
            {
                Random r = new Random();
                damageGiven = r.Next(0, 0);
            }
            else
            {
                Random r = new Random();
                damageGiven = r.Next(0, 0);
            }            

            return damageGiven;
        }
        public virtual void HealthLoss(DamageObject damageObject)
        {
            int damageGiven = damageObject.DamageValue;
            /*
             My guy if you read through my code in Attack you'll find that this was aleady done
             if (ArmourState && source == AttackType.PhysicalDamage)
            {
                if (damageGiven >= Armour)
                {
                    damageGiven -= Armour;
                    Armour = 0;
                }
                else
                {
                    damageGiven = 0;
                    Armour -= damageGiven;
                }
            }


            if (MagicResState && source == AttackType.MagicalDamage)
            {
                if (damageGiven >= MagicRes)
                {
                    damageGiven -= MagicRes;
                    MagicRes = 0;
                }
                else
                {
                    damageGiven = 0;
                    MagicRes -= damageGiven;
                }
            }
            if (shieldState && source == AttackType.PhysicalDamage)
            {
                if (damageGiven >= shield)
                {
                    damageGiven -= shield;
                    shield = 0;
                }
                else
                {
                    damageGiven = 0;
                    shield -= damageGiven;
                }
            }

            //My Implementation of Block
            if (BlockState && source == AttackType.PhysicalDamage)
            {
                damageGiven = 0;
            }

             */

            //My Implementation of Immune
            if (ImmuneState)
            {
                damageGiven = 0;
            }

            Health -= damageGiven;
        }
        public virtual void LevelIncrease()
        {
            ExperienceLevel++;
            if (Foe == false)
            {
                Health += 0 * ExperienceLevel;
                dodge += 0 * ExperienceLevel;
                Speed += 0 * ExperienceLevel;
                CritC += 0 * ExperienceLevel;
                MagicRes += 0 * ExperienceLevel;
                Armour += 0 * ExperienceLevel;
                if (LowDamage == true) Damage += 0 * ExperienceLevel;
                else
                {
                    Damage += 2 * ExperienceLevel;
                }
            }
            else
            {
                Health += 0 * ExperienceLevel;
                dodge += 0 * ExperienceLevel;
                Speed += 0 * ExperienceLevel;
                CritC += 0 * ExperienceLevel;
                MagicRes += 0;
                Armour += 0;
                if (LowDamage == true) Damage += 1 * ExperienceLevel;
                else
                {
                    Damage += 0 * ExperienceLevel;
                }
            }
            //fire levelIncrease animation
        }
        public void TraitLevelUpActivation(int experienceLevel, List<ItemTemplate> Items)
        {
            throw new NotImplementedException();
        }
        public void XPIncrease(bool earnXp, int newEarnedXp)
        {
            EarnedXp = earnXp;
            NewEarnedXp = newEarnedXp;
        }

        #region Attack Logic

        public void AddAttack(AttackObject attack)
        {
            AttacksGiven.Add(attack);
            Timer Attack = new Timer();
            Attack.Elapsed += new ElapsedEventHandler(Attacker);
            // Set it to go off every one seconds
            Attack.Interval = 1000;
            // And start it        
            Attack.Enabled = true;
            void Attacker(object source2, ElapsedEventArgs e)
            {
                if (RoundInfo.RoundDone == true)
                {
                    Attack.Close(); //Not really sure what this was supposed to do
                }
            }

        }
        public List<AttackObject> GetAttack(object CharacterInstance)
        {
            Persona meed = (Persona)CharacterInstance;
            return meed.AttacksGiven;
        }

        #endregion
        #region Buff Logic

        public void AddBuff(BuffObject buff)
        {
            BuffsInEffect.Add(buff);
            Timer Buff = new Timer();
            Buff.Elapsed += new ElapsedEventHandler(Buffer);
            // Set it to go off every one seconds
            Buff.Interval = 1000;
            // And start it        
            Buff.Enabled = true;
            void Buffer(object source2, ElapsedEventArgs e)
            {
                if (RoundInfo.RoundDone == true)
                {
                    Buff.Close();//Not really sure what this was supposed to do
                }
            }

        }
        public List<BuffObject> GetBuff(object CharacterInstance)
        {
            Persona deem = (Persona)CharacterInstance;
            return deem.BuffsInEffect;
        }

        #endregion
        #region Defend Logic


        #endregion
        #region DeBuff Logic

        public void AddDebuff(DebuffObject debuffObject)
        {
            if (!DebuffsInEffect.Contains(debuffObject))
                DebuffsInEffect.Add(debuffObject);

            ApplyDebuff(debuffObject);
        }
        public void RemoveDebuff(DebuffObject debuffObject)
        {
            //Revert First
            DebuffsInEffect.Remove(debuffObject);
        }
        public void RemoveAllDebuff()
        {
            //Revert First
            DebuffsInEffect.Clear();
        }
        public void ActiveDeBuff()
        {
            throw new NotImplementedException();
        }
        public List<DebuffObject> GetDebuffs()
        {
            return DebuffsInEffect;
        }
        public void ApplyDebuff(DebuffObject debuffObject)
        {
            switch (debuffObject.type)
            {
                case debuffType.Slow:
                    break;
                case debuffType.Rooted:
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
        }
        #endregion




        #endregion
        #region Combat Actions

        #region Attack

        public void TrueDamage(object CharacterInstance, object TargetInstance, DamageObject DamageObj) => new Attack().TrueDamage(CharacterInstance,TargetInstance,DamageObj);
        public void PhysicalDamage(object CharacterInstance, object TargetInstance) => new Attack().PhysicalDamage(CharacterInstance,TargetInstance);
        public void PhysicalDamage(object CharacterInstance, object TargetInstance, DamageObject damageObject) => new Attack().PhysicalDamage(CharacterInstance, TargetInstance, damageObject);// this is so someone can put a tailored value
        public void MagicalDamage(object CharacterInstance, object TargetInstance) => new Attack().MagicalDamage(CharacterInstance, TargetInstance);
        public void MagicalDamage(object CharacterInstance, object TargetInstance, int amount) => new Attack().MagicalDamage(CharacterInstance, TargetInstance,amount);
        public void Drain(object CharacterInstance, object TargetInstance) => new Attack().Drain(CharacterInstance, TargetInstance);
        public void Ignite(object CharacterInstance, object TargetInstance, int amount) => new Attack().Ignite(CharacterInstance, TargetInstance, amount);
        public void Bleed(object CharacterInstance, object TargetInstance) => new Attack().Bleed(CharacterInstance, TargetInstance);
        public void Bleed(object CharacterInstance, object TargetInstance, DamageObject damageObject)=> new Attack().Bleed(CharacterInstance, TargetInstance,damageObject); // this is an overload that acts just like physicalDamage overload for a tailors value pulled in
        public void Blight(object CharacterInstance, object TargetInstance, int amountOfRounds, int amountOfDamage) => new Attack().Blight(CharacterInstance, TargetInstance,amountOfRounds,amountOfDamage);
        public void BalancedDamage(object CharacterInstance, object TargetInstance) => new Attack().BalancedDamage(CharacterInstance, TargetInstance);
        public void Curse(object CharacterInstance, object TargetInstance) => new Attack().Curse(CharacterInstance, TargetInstance);
        public bool Feign(object CharacterInstance, object TargetInstance) => new Attack().Feign(CharacterInstance, TargetInstance);

        #endregion
        #region Defend
        public void PutArmour(object TargetInstance, bool state, int amount) => new Defend((Persona)TargetInstance).Armour(state, amount);
        public void IncreaseMagicalResistance(object TargetInstance, bool state, int amount) => new Defend((Persona)TargetInstance).MagicalResistance(state, amount);
        public void ShieldUp(object TargetInstance, bool state, int amount) => new Defend((Persona)TargetInstance).Shield(state, amount);
        public void Purified(object TargetInstance, bool state) => new Defend((Persona)TargetInstance).Purified(state);
        public void Block(object TargetInstance, bool state) => new Defend((Persona)TargetInstance).Block(state);
        public void Immune(object TargetInstance, bool state) => new Defend((Persona)TargetInstance).Immune(state);

        #endregion

        #region Buff

        public void Agile(object CharacterInstance, bool state) => new Buff().Agile( CharacterInstance, state);
        public void PolishWeapon(object CharacterInstance) => new Buff().PolishWeapon(CharacterInstance);
        public void Chosen(object CharacterInstance) => new Buff().Chosen(CharacterInstance);
        public bool Aware(object CharacterInstance) => new Buff().Aware(CharacterInstance);
        public void OnGuard(object CharacterInstance, object TargetInstance) => new Buff().OnGuard(CharacterInstance,TargetInstance);
        public void Provoking(object CharacterInstance) => new Buff().Provoking(CharacterInstance);
        public void Protector(object OwnerInstance, object TargetInstance) => new Buff().Protector(OwnerInstance,TargetInstance);
        public object Protected(object TargetInstance) => new Buff().Protected(TargetInstance);
        public void Revigorate(object TargetInstance) => new Buff().Revigorate(TargetInstance);
        public void HealVictim(object CharacterInstance, object TargetInstance) => new Buff().HealVictim(CharacterInstance,TargetInstance);
        public void HealVictim(object TargetInstance, int damageobj) => new Buff().HealVictim(TargetInstance, damageobj);
        public void GodsBlessing(object CharacterInstance, List<string> Allies) => new Buff().GodsBlessing(CharacterInstance, Allies);

        #endregion
        #region Debuff
        public void Slow(object CharacterInstance, object TargetInstance) => new Debuff().Slow(CharacterInstance, TargetInstance);
        public void Rooted(object CharacterInstance, object TargetInstance) => new Debuff().Rooted(CharacterInstance, TargetInstance);
        public void WeakGrip(object CharacterInstance, object TargetInstance) => new Debuff().WeakGrip(CharacterInstance, TargetInstance);
        public void Exiled(object CharacterInstance, object TargetInstance) => new Debuff().Exiled(CharacterInstance, TargetInstance);
        public void Marked(object CharacterInstance, object TargetInstance) => new Debuff().Marked(CharacterInstance, TargetInstance);
        public void Calm(object CharacterInstance, object TargetInstance) => new Debuff().Calm(CharacterInstance, TargetInstance);
        public void BrokenGuard(object CharacterInstance, object TargetInstance) => new Debuff().BrokenGuard(CharacterInstance, TargetInstance);
        public void Burnt(object CharacterInstance, object TargetInstance) => new Debuff().Burnt(CharacterInstance, TargetInstance);
        public void Stun(object CharacterInstance, object TargetInstance) => new Debuff().Stun(CharacterInstance, TargetInstance);
        public void Freeze(object CharacterInstance, object TargetInstance) => new Debuff().Freeze(CharacterInstance, TargetInstance);
        public void Cold(object CharacterInstance, object TargetInstance) => new Debuff().Cold(CharacterInstance, TargetInstance);
        public void Blinded(object CharacterInstance, object TargetInstance) => new Debuff().Blinded(CharacterInstance, TargetInstance);
        public void Tainted(object CharacterInstance, object TargetInstance) => new Debuff().Tainted(CharacterInstance, TargetInstance);
        public void Sleep(object CharacterInstance, object TargetInstance) => new Debuff().Sleep(CharacterInstance, TargetInstance);
        public void Hungry(object CharacterInstance, object TargetInstance) => new Debuff().Hungry(CharacterInstance, TargetInstance);
        public void Unhealthy(object CharacterInstance, object TargetInstance) => new Debuff().Unhealthy(CharacterInstance, TargetInstance);
        public void GodsAnger(object CharacterInstance, List<string> Allies) => new Debuff().Slow(CharacterInstance, Allies);

        #endregion

        #region UniqueActons
        public virtual void UniqueSkill(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public virtual void UniqueActiveBuff(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public virtual void UniqueActiveDeBuff(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Non-Mentioned Methods

        public void BreakArmour(object TargetInstance, int amount)
        {
            Persona Target = (Persona)TargetInstance;
            Target.Armour -= amount;
        }

        public List<object> RevengeDa = null;// this is for the below method
        public void BlackList()
        {
            object grugde = AttackSponser;
            Timer myTimer2;
            myTimer2 = new Timer();
            // Tell the timer what to do when it elapses
            myTimer2.Elapsed += new ElapsedEventHandler(myEvent);
            // Set it to go off every one seconds
            myTimer2.Interval = 1000;
            // And start it        
            myTimer2.Enabled = true;

            //this is supposed to add to a list up to 5, of the last person to cause you damage. Its called in the constructor and hopefully runs the whole time. 
           
            void myEvent(object source2, ElapsedEventArgs e) 
            {
                if (grugde != AttackSponser)
                {
                    RevengeDa.Add(AttackSponser); grugde = AttackSponser;
                    if (RevengeDa.Count > 5) RevengeDa.Remove(RevengeDa.Last());
                }
            }
        }

        #endregion

        #endregion

        #region Toggles
        public void ToggleArmour(bool state, int amount)
        {
            ArmourState = state;
            Armour = amount;
        }
        public void ToggleMagicRes(bool state, int amount)
        {
            MagicResState = state;
            MagicRes = amount;
        }
        public void ToggleShield(bool state, int amount)
        {
            shieldState = state;
            shield = amount;
        }
        public void TogglePurified(bool state)
        {
            PurifiedState = state;
        }
        public void ToggleBlock(bool state)
        {
            BlockState = state;
        }
        public void ToggleImmune(bool state)
        {
            ImmuneState = state;
        }
        #endregion
    }
}
