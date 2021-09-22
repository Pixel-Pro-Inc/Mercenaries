using Assets.Scripts.Entities.Item;
using Assets.Scripts.Entities.Item.Food;
using Assets.Scripts.Entities.Item.Relics;
using Assets.Scripts.Helpers;
using Assets.Scripts.Helpers.Traits;
using Assets.Scripts.Interface;
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

        public virtual CharacterBehaviour characterBehaviour { get; set; }

        
        #region GivenCharacterTraits

        

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
       

        #region Combat Object Lists

        public List<AttackObject> AttacksGiven = new List<AttackObject>();
        public List<DefendObject> DefenceSet = new List<DefendObject>();
        public List<BuffObject> BuffsInEffect = new List<BuffObject>();
        public List<DebuffObject> DebuffsInEffect = new List<DebuffObject>();

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

        public MasterCharacterList PersonName;
        public SpeciesType CharacterSpecies { get; set; }
        internal QuirkColour _qColor { get; set; } public virtual QuirkColour QuirkColour { get { return _qColor; } set{ _qColor = value;}} //This is used in persona when trying to make a quirk character
        public enemyType EnemyType { get; set; }

        internal bool _foe { get; set; }
        public virtual bool Foe { get { return _foe; } set { _foe = value; } }

        internal int _Life = 0;
        public virtual int Life { get; set; }
        public virtual int maxShield { get; set; }

        internal int _health = 0;
        public virtual int Health
        {
            get { return _health; }
            set
            {
                _health = value;
                if (Health < 0) _health = 0;
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

        internal double _dodge = 0;
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

        internal double _speed = 0;
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

        internal double _CritC = 0;
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

        internal int _magicRes = 0;
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

        internal int _armour = 0;
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

        internal int _shield = 0;
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
        internal int _Damage = 0;
        public virtual int Damage { get; set; }

        internal int _HitCount = 0;
        public virtual int HitCount { get; set; }
        internal double _Accuracy = 0;
        public virtual double Accuracy { get; set; }
        public bool LowDamage { get; set; }

        internal int _expPoints = 0;
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

        internal int _NewExpoint = 0;
        public int NewEarnedXp
        {
            get { return _NewExpoint; }
            set
            {
                if (NewEarnedXp < 0) _NewExpoint = 0;
                if (EarnedXp == true)
                {
                    _NewExpoint = value;
                }
                else
                {
                    _NewExpoint = 0;
                }
            }
        }

        internal bool _EarnedXp = false;
        public bool EarnedXp
        {
            get { return _EarnedXp; }
            set
            {
                _EarnedXp = value;
            }
        } //This bool is made true when XPIncrease is fired and should be made of when sessionOver is true

        internal int ExperienceLevel { get { return ExperienceLevel; } set { if (ExperienceLevel < 0) ExperienceLevel = 0; } }

        #region Food system traits that I dont trust
        internal int _Mana = 0;
        public virtual int Mana
        {
            get; set;
        }
        internal int _Stamina = 0;
        public virtual int Stamina { get; set; }//I assume the hunger method will affect this trait
        internal int _sustainance = 0;
        public virtual int Sustainance
        {
            get; set;
        }
        internal int _vitality = 0;
        public virtual int Vitality { get; set; }

        #endregion

        public InnerVoice InnerVoice = new InnerVoice(); //This is used for special actions. Dont remove !!!

        #endregion
        #region Attack Percent

        //These below have to be int cause they are used as in the Random method Random.Next()
        public int DrainPercent { get; set; }
        public int CurseMaxint { get; set; }
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

        public int debuffChance { get; set; }
        public double BrokenGaurdDeBuffPercent { get; set; }
        public double ColdDeBuffPercent { get; set; }
        public double BlindedDeBuffPercent { get; set; }
        public double TaintedDebuffPercent { get; set; }

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
            float damageGiven = (float)damageObject.DamageValue;
            for (int i = 0; i < GetDebuffs().Count; i++)
            {
                Debug.Log("My guy Yewo, i have already done this, check Attack, with any physical damage you'll see markedda set in character logic and checked in target logic if debuff is present");
                /*if (GetDebuffs()[i].type == debuffType.Marked)
                    damageGiven *= (1f + (float)MarkedDeBuffPerent);*/

            }

            //My Implementation of Immune
            if (ImmuneState)
            {
                damageGiven = 0;
            }

            Health -= (int)damageGiven;
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
            new SerializedObjectManager().SaveData(this, new SerializedObjectManager().paths[0] + CharacterName);
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
            RevertDebuff(debuffObject);
            DebuffsInEffect.Remove(debuffObject);
        }
        public void RemoveAllDebuff()
        {
            for (int i = 0; i < DebuffsInEffect.Count; i++)
            {
                RevertDebuff(DebuffsInEffect[i]);
            }           
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
                    characterBehaviour.turnUsed = true;
                    break;
                case debuffType.Freeze:
                    freezeState = true;
                    characterBehaviour.turnUsed = true;
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
                case debuffType.BrokenGaurd:
                    break;
                case debuffType.Burnt:
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
        public void RevertDebuff(DebuffObject debuffObject)
        {
            switch (debuffObject.type)
            {
                case debuffType.Slow:
                    Speed /= debuffObject.amount;
                    break;
                case debuffType.Rooted:
                    dodge /= debuffObject.amount;
                    break;
                case debuffType.WeakGrip:
                    break;
                case debuffType.Exiled:
                    break;
                case debuffType.Calm:
                    break;
                case debuffType.Stun:
                    stunState = false;
                    characterBehaviour.turnUsed = false;
                    break;
                case debuffType.Freeze:
                    freezeState = false;
                    characterBehaviour.turnUsed = false;
                    break;
                case debuffType.Cold:
                    Speed /= debuffObject.amount;
                    dodge /= debuffObject.amount;
                    break;
                case debuffType.Blinded:
                    Accuracy /= debuffObject.amount;
                    break;
                case debuffType.Tainted:
                    debuffChance -= (int)debuffObject.amount;
                    break;
                case debuffType.BrokenGaurd:
                    break;
                case debuffType.Burnt:
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

        #region Extra Methods

        public void CreateQuirkCharacter(QuirkColour quirkColour)=>new Quirks().MyHeroAcademia(quirkColour); //Bassically sets the CHaracter who called it, his quirkcolour


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
        public void ShieldUp(object TargetInstance, bool state, int amount) 
        {
            Debug.Log(TargetInstance.ToString());
            new Defend((Persona)TargetInstance).Shield(state, amount); 
        }
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
        public void GodsBlessing(object CharacterInstance) => new Buff().GodsBlessing(CharacterInstance);

        #endregion
        #region Debuff
        public void Slow(object CharacterInstance, object TargetInstance, int lifeTime) => new Debuff().CreateDebuff(TargetInstance, ((Persona)CharacterInstance).SlowDeBuffPercent, debuffType.Slow, lifeTime);
        public void Rooted(object CharacterInstance, object TargetInstance, int lifeTime) => new Debuff().CreateDebuff(TargetInstance, ((Persona)CharacterInstance).RootedDeBuffPercent, debuffType.Rooted, lifeTime);
        public void WeakGrip(object CharacterInstance, object TargetInstance, int lifeTime) => new Debuff().CreateDebuff(TargetInstance, ((Persona)CharacterInstance).WeakGripDeBuffPercent, debuffType.WeakGrip, lifeTime);
        public void Exiled(object CharacterInstance, object TargetInstance, int lifeTime) => new Debuff().CreateDebuff(TargetInstance, ((Persona)CharacterInstance).ExiledDeBuffPercent, debuffType.Exiled, lifeTime);
        public void Marked(object CharacterInstance, object TargetInstance, int lifeTime) => new Debuff().CreateDebuff(TargetInstance, ((Persona)CharacterInstance).MarkedDeBuffPerent, debuffType.Marked, lifeTime);
        public void Calm(object CharacterInstance, object TargetInstance, int lifeTime) => new Debuff().CreateDebuff(TargetInstance, ((Persona)CharacterInstance).CalmDeBuffPercent, debuffType.Calm, lifeTime);
        public void BrokenGuard(object CharacterInstance, object TargetInstance, int lifeTime) => new Debuff().CreateDebuff(TargetInstance, ((Persona)CharacterInstance).BrokenGaurdDeBuffPercent, debuffType.BrokenGaurd, lifeTime);
        public void Burnt(object CharacterInstance, object TargetInstance, int lifeTime) => new Debuff().CreateDebuff(TargetInstance, 0.5, debuffType.Burnt, lifeTime);
        public void Stun(object CharacterInstance, object TargetInstance, int lifeTime) => new Debuff().CreateDebuff(TargetInstance, 0, debuffType.Stun, lifeTime);
        public void Freeze(object CharacterInstance, object TargetInstance, int lifeTime) => new Debuff().CreateDebuff(TargetInstance, 0, debuffType.Freeze, lifeTime);
        public void Cold(object CharacterInstance, object TargetInstance, int lifeTime) => new Debuff().CreateDebuff(TargetInstance, ((Persona)CharacterInstance).ColdDeBuffPercent, debuffType.Cold, lifeTime);
        public void Blinded(object CharacterInstance, object TargetInstance, int lifeTime) => new Debuff().CreateDebuff(TargetInstance, ((Persona)CharacterInstance).BlindedDeBuffPercent, debuffType.Blinded, lifeTime);
        public void Tainted(object CharacterInstance, object TargetInstance, int lifeTime) => new Debuff().CreateDebuff(TargetInstance, ((Persona)CharacterInstance).TaintedDebuffPercent, debuffType.Tainted, lifeTime);
        public void Sleep(object CharacterInstance, object TargetInstance) 
        { 
            new Debuff().CreateDebuff(TargetInstance, 0, debuffType.Sleep, 0);
            new Debuff().CreateDebuff(TargetInstance, 0, debuffType.Stun, 0);
        }
        public void Hungry(object CharacterInstance, object TargetInstance) => new Debuff().CreateDebuff(TargetInstance, 0.05, debuffType.Hungry, 1);
        public void Unhealthy(object CharacterInstance, object TargetInstance) => new Debuff().CreateDebuff(TargetInstance, 0.25, debuffType.UnHealthy, 1);
        public void GodsAnger(object CharacterInstance)
        {
            Persona Character = (Persona)CharacterInstance;
            object TargetInstance = Allies[UnityEngine.Random.Range(0, Allies.Count)];
            int r = UnityEngine.Random.Range(0, 5);

            switch(r)
            {
                case 0:
                    Blinded(CharacterInstance, TargetInstance, 1);
                    break;
                case 1:
                    Stun(CharacterInstance, TargetInstance, 1);
                    break;
                case 2:
                    Rooted(CharacterInstance, TargetInstance, 1);
                    break;
                case 3:
                    Hungry(CharacterInstance, TargetInstance);
                    break;
                case 4:
                    Unhealthy(CharacterInstance, TargetInstance);
                    break;
            }
            //Character.GetComponent<GameManager>().BattleLost();
        }
        #endregion

        #region UniqueActons
        public virtual void UniqueSkill(object CharacterInstance, object TargetInstance)
        {
            Persona Character= (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            // We might need to remove the UniqueSkills in every template, or rename them to be the unique skill of the template type
            switch (PersonName)
            {
                case MasterCharacterList.Peter:
                    break;
                case MasterCharacterList.Mister_Glubglub:
                    break;
                case MasterCharacterList.Mister_Froggo:
                    break;
                case MasterCharacterList.Mister_Salaboned:
                    break;
                case MasterCharacterList.Mister_Lizzacorn:
                    break;
                case MasterCharacterList.Mister_Liodin:
                    break;
                case MasterCharacterList.Mister_Lacrox:
                    break;
                case MasterCharacterList.Mister_Birbarcher:
                    break;
                case MasterCharacterList.Mister_PirateParrot:
                    break;
                case MasterCharacterList.Mister_SilverSkull:
                    break;
                case MasterCharacterList.Mister_Mantis:
                    break;
                case MasterCharacterList.Mister_Hippo:
                    break;
                case MasterCharacterList.HammerHead:
                    break;
                case MasterCharacterList.GreatWhite:
                    break;
                case MasterCharacterList.SpiderCrustacean:
                    break;
                case MasterCharacterList.NecroBoar:
                    Character.Revive(TargetInstance);
                    break;
                case MasterCharacterList.ElderStag:
                    break;
                case MasterCharacterList.DevilBird:
                    break;
                case MasterCharacterList.DragonSloth:
                    break;
                default:
                    break;
            }
        }

        public virtual void UniqueActiveBuff(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public virtual void UniqueActiveDeBuff(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public void Revive(object TargetInstance) //This should be called by the NecroBoars UniqueSkill
        {
            Persona Target = (Persona)TargetInstance;
            Target.Health = Target.Life;
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
        #region Items 

        RelicClass RelicsInventory = new RelicClass(); //Don't bedecieve this is entire info of Relics the chracter has, including the list of Relics
        FoodClass StoreHouse = new FoodClass();//Don't be decieve this is entire info of food the chracter has, including the list of food

        public void CreateItem(object enumtype) //The item has to be the enum type eg foodType or relic type
        {
            if (enumtype.GetType() == typeof(RelicType))
            {
                RelicType relic = (RelicType)enumtype;
                RelicsInventory.CreateRelic(relic);
            }
            else if (enumtype.GetType() == typeof(FoodType))
            {
                FoodType food = (FoodType)enumtype;
                StoreHouse.CreateFood(food);
            }
            else
            {
                Debug.Log("The item has to be the enum type eg foodType or relic type");
            }
        }
        public void EquipItem(object item) //this is supposed to get an Item from either RelicInventory or StoreHouse
        {
            if (item.GetType() == typeof(RelicClass))
            {
                RelicClass relic = (RelicClass)item;
                relic.ActivationRequireMent(this);
            }
            else if (item.GetType() == typeof(FoodClass))
            {
                FoodClass food = (FoodClass)item;
                food.ActivationRequireMent(this);
            }
            else
            {
                Debug.Log("The item has to be a Type eg FoodClass or RelicClass");
            }
        }

        #endregion
    }
}
