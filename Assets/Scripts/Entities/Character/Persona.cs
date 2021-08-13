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
using static Assets.Scripts.Models.Enums;

namespace Assets.Scripts.Entities.Character
{
    public class Persona: Individual, IPersona,ICombatAction
    {
        //We aren't making persona abstract cause we need to use it as a template in some logic
        //Anything here thats not virtual will be the same for all characters

        public Persona Instance;
        public Persona()
        {
            Instance = this;
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
            Triton
        };
        public bool RemoveDebuffEffects { get; set; }

        #endregion
        #region Character Traits

        #region Stats

        public virtual string CharacterName { get { return CharacterName; } set { CharacterName = "UnKnown"; } }
        public virtual string CharacterDescription { get { return CharacterDescription; } set { CharacterDescription = "UnKnown"; } } //Here the personality and backstory of a unique character will be defined
        public virtual bool Foe { get { return Foe; } set { Foe = false; } }
        public virtual int Life
        {
            get { return Life; }
            set
            {
                if (Life < 0) Life = 0;
                Life = value;
                Life = Health;
            }
        }
        public virtual int Health
        {
            get { return Health; }
            set
            {
                if (Health < 0) Health = 0;
                if (Foe == false)
                {
                    Health = 0;
                }
                else
                {
                    Health = 0;
                }
            }
        }
        public virtual double dodge
        {
            get { return dodge; }
            set
            {
                if (Foe == false)
                {
                    dodge = 0;
                }
                else
                {
                    dodge = 0;
                }
                if (dodge < 0) dodge = 0;

            }
        }
        public virtual double Speed
        {
            get { return Speed; }
            set
            {
                if (Foe == false)
                {
                    Speed = 0;
                }
                else
                {
                    Speed = 0;
                }
                if (Speed < 0) Speed = 0;

            }
        }
        public virtual double CritC
        {
            get { return CritC; }
            set
            {
                if (Foe == false)
                {
                    CritC = 0;
                }
                else
                {
                    CritC = 0;
                }
                if (CritC < 0) CritC = 0;

            }
        }
        public virtual int MagicRes
        {
            get { return MagicRes; }
            set
            {
                if (Foe == false)
                {
                    MagicRes = 0;
                }
                else
                {
                    MagicRes = 0;
                }
                if (MagicRes < 0) MagicRes = 0;

            }
        }
        public virtual int Armour
        {
            get { return Armour; }
            set
            {
                if (Foe == false)
                {
                    Armour = 0;
                }
                else
                {
                    Armour = 0;
                }
                if (Armour < 0) Armour = 0;

            }
        }
        public virtual int shield
        {
            get { return shield; }
            set
            {
                if (Foe == false)
                {
                    shield = 0;
                }
                else
                {
                    shield = 0;
                }
                if (shield < 0) shield = 0;
            }
        }
        public virtual int Damage { get; set; }
        public virtual int HitCount { get; set; }
        public virtual double Accuracy { get; set; }
        public bool LowDamage { get; set; }
        public int ExpPoints
        {
            get { return ExpPoints; }
            set
            {
                if (RoundInfo.RoundDone == true/*This means characters can level up durning battle*/)
                {
                    Instance.ExpPoints += NewEarnedXp;
                }
                if (Instance.ExpPoints > 1000)
                {
                    Instance.LevelIncrease();
                    Instance.ExpPoints -= 1000;
                }
            }
        }
        public int NewEarnedXp
        {
            get { return NewEarnedXp; }
            set
            {
                if (NewEarnedXp < 0) NewEarnedXp = 0;
                if (EarnedXp == true)
                {
                    Instance.NewEarnedXp = NewEarnedXp;
                }
                else
                {
                    Instance.NewEarnedXp = 0;
                }
            }
        }
        public bool EarnedXp
        {
            get { return EarnedXp; }
            set
            {
                if (RoundInfo.RoundDone == false/*This means characters can level up durning battle*/)
                {
                    EarnedXp = false;
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
        public double RootedDebuffPercent { get; set; }
        public double WeakGripDeBuffPercent { get; set; }
        public double ExiledDeBuffPercent { get; set; }
        public double MarkedDeBuffPerent { get; set; }
        public double CalmDeBuffPercent { get; set; }
        public virtual int debuffChance { get; set; }
        public virtual double BrokenGaurdDeBuffPercent { get; set; }
        public virtual double ColdDeBuffPercent { get; set; }
        public virtual double BlindedDeBuffPercent { get; set; }
        public virtual double TaintedDebuffPercent { get; set; }
        public virtual bool stunState { get; set; }
        public virtual bool freezeState { get; set; }

        //Yewo's Variables
        
        
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
        public virtual int HealthLoss(int damageGiven)
        {
            Instance.Health -= damageGiven;
            return damageGiven;
        }
        public virtual void LevelIncrease()
        {
            Instance.ExperienceLevel++;
            if (Foe == false)
            {
                Instance.Health += 0 * Instance.ExperienceLevel;
                Instance.dodge += 0 * Instance.ExperienceLevel;
                Instance.Speed += 0 * Instance.ExperienceLevel;
                Instance.CritC += 0 * Instance.ExperienceLevel;
                Instance.MagicRes += 0 * Instance.ExperienceLevel;
                Instance.Armour += 0 * Instance.ExperienceLevel;
                if (LowDamage == true) Instance.Damage += 0 * Instance.ExperienceLevel;
                else
                {
                    Instance.Damage += 2 * Instance.ExperienceLevel;
                }
            }
            else
            {
                Instance.Health += 0 * Instance.ExperienceLevel;
                Instance.dodge += 0 * Instance.ExperienceLevel;
                Instance.Speed += 0 * Instance.ExperienceLevel;
                Instance.CritC += 0 * Instance.ExperienceLevel;
                Instance.MagicRes += 0;
                Instance.Armour += 0;
                if (LowDamage == true) Instance.Damage += 1 * Instance.ExperienceLevel;
                else
                {
                    Instance.Damage += 0 * Instance.ExperienceLevel;
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
                    Speed *= debuffObject.amount;
                    break;
                case debuffType.Rooted:
                    dodge *= debuffObject.amount;
                    break;
                case debuffType.WeakGrip:
                    break;
                case debuffType.Exiled:
                    break;
                case debuffType.Calm:
                    break;
                case debuffType.Stun:
                    stunState = true;
                    //Check to see if this is active before doing anything
                    break;
                case debuffType.Freeze:
                    freezeState = true;
                    //Check to see if this is active before doing anything
                    break;
                case debuffType.Cold:
                    Speed *= debuffObject.amount;
                    dodge *= debuffObject.amount;
                    break;
                case debuffType.Blinded:
                    Accuracy *= debuffObject.amount;
                    break;
                case debuffType.Tainted:
                    debuffChance = (int)debuffObject.amount;
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
        public void Blight(object CharacterInstance, object TargetInstance, int amountOfRounds, int amountOfDamage) => new Attack().Blight(CharacterInstance, TargetInstance,amountOfRounds,amountOfDamage);
        public void BalancedDamage(object CharacterInstance, object TargetInstance) => new Attack().BalancedDamage(CharacterInstance, TargetInstance);
        public void Curse(object CharacterInstance, object TargetInstance) => new Attack().Curse(CharacterInstance, TargetInstance);
        public bool Feign(object CharacterInstance, object TargetInstance) => new Attack().Feign(CharacterInstance, TargetInstance);

        #endregion
        #region Defend

        public void PutArmour(object TargetInstance, int amount)
        {
            Persona Target = (Persona)TargetInstance;
            Target.Armour += amount;
        }
        public void IncreaseMagicalResistance(object TargetInstance, int amount)
        {
            Persona Target = (Persona)TargetInstance;
            Target.MagicRes += amount;
        }
        public void ShieldUp(object TargetInstance, int amount)
        {
            Persona Target = (Persona)TargetInstance;
            Target.shield += amount;
        }
        public void Purified(object TargetInstance)
        {
            Persona Target = (Persona)TargetInstance;
            //After the methodds that do te things
            while (RoundInfo.GameInSession == true)
            {
                Target.RemoveDebuffEffects = true;
            }
        }
        public void Block(object TargetInstance)
        {
            Persona Target = (Persona)TargetInstance;
            Target.BlockState = true;
        }
        public void Immune(object TargetInstance, int amountOfRounds)
        {
            Persona Target = (Persona)TargetInstance;
            int gegege= RoundInfo.RoundsPassed;
            int creep = 0;
            creep = amountOfRounds;
            Target.ImmuneState = false;
            Timer Nivana;
            Nivana = new Timer();
            // Tell the timer what to do when it elapses
            Nivana.Elapsed += new ElapsedEventHandler(HeartShapedBox);
            // Set it to go off every one seconds
            Nivana.Interval = 1000;
            // And start it        
            Nivana.Enabled = true;

            void HeartShapedBox(object source2, ElapsedEventArgs e)
            {
                if (gegege!= RoundInfo.RoundsPassed)
                {
                    gegege = RoundInfo.RoundsPassed;
                    if (creep != 0)
                    {
                        Revigorate(Target);
                        Block(Target);
                        Target.ImmuneState = true;
                        creep--;
                    }
                    else
                    {
                        Nivana.Close();
                    }
                }
            }
        }

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
        public void UniqueSkill(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public void UniqueActiveBuff(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public void UniqueActiveDeBuff(object CharacterInstance, object TargetInstance)
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
