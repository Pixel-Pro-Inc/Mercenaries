﻿using Assets.Scripts.Entities.Item;
using Assets.Scripts.Interface;
using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

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

        public enum SpeciesType
        {
            Lion,
            Crocodile,
            Fish,
            Salamander,
            Frog,
            Triton
        };
        bool RemoveDebuffEffects { get; set; }

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
        public virtual int dodge
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
        public virtual int Speed
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
        public virtual int Accuracy { get; set; }
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

        public bool Weakg { get; set; } //these work for each instances weakgrip debuff
        public bool exiledg { get; set; }// these work for each instances exiled debuff
        public bool markedg { get; set; }
        public bool calmState { get; set; }

        #endregion
        #region Attack Percent

        //These below have to be int cause they are used as in the Random method Random.Next()
        public int DrainPercent { get; set; }
        public int CursePercent { get; set; }
        public int BlightAmount { get; set; }

        #endregion
        #region Defend Percent

        public bool ImmuneState { get; set; }
        public bool BlockState { get; set; }

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
        #region DeBUff Percent

        public double SlowDeBuffPercent { get; set; }
        public double RootedDebuffPercent { get; set; }
        public double WeakGripDeBuffPercent { get; set; }
        public double ExiledDeBuffPercent { get; set; }
        public double MarkedDeBuffPerent { get; set; }
        public double CalmDeBuffPercent { get; set; }


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


        #endregion
        #region Combat Actions

        #region Attack

        public void TrueDamage(object TargetInstance, DamageObject DamageObj)
        {
            Persona target = (Persona)TargetInstance;
            if (target.ImmuneState == true)
            { }
            else { target.HealthLoss(DamageObj.DamageValue); }
        }
        public void PhysicalDamage(object CharacterInstance, object TargetInstance)
        {
            int physicalDamage = 0;
            int shieldcache = 0;
            int armourcahe = 0;
            double markedda = 0;

            Persona Character = (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            DamageObject hitval = new DamageObject();
            hitval.DamageTrait = DamageObject.DamageVersion.Physical;

            #region Character Logic

            physicalDamage = Character.DamageGiven();
            markedda = Character.MarkedDeBuffPerent;
            if (Character.PolishWeapon() == true) physicalDamage += (int)(physicalDamage * Character.PowerBuffPercent);// this is to work the polish buff
            if (Character.Weakg == true) physicalDamage -= (int)(physicalDamage * Character.WeakGripDeBuffPercent);
            if (Character.calmState == true) physicalDamage -= (int)(physicalDamage * Character.CalmDeBuffPercent);

            #endregion
            #region Target Logic

            Target.AttackSponser = Character;
            if (Target.ProtectionSponser != null) Target = (Persona)Target.ProtectionSponser;
            if (Target.markedg == true) physicalDamage += (int)(physicalDamage * markedda);
            if (Target.BlockState == true)
            {
                physicalDamage = 0;
                Target.BlockState =false; 
                //blocking animation
            }

            shieldcache = Target.shield;
            armourcahe = Target.Armour;
            shieldcache -= physicalDamage; Target.shield -= physicalDamage;//this will make shield=0 if the physical damage is too much
            //the code below ensures that the sheild is removed first
            if (shieldcache < 0)//this asks if there is no more sheild left
            {
                armourcahe += shieldcache;// here the negative value adds with the positive- following negative number addition laws i hope
                if (armourcahe < 0)//this asks if there is no more armour left
                {
                    Target.Armour = 0; // this makes sure armour is zero
                    hitval.DamageValue = Math.Abs(armourcahe);
                    Character.TrueDamage(Target, hitval); //This removes the health of the target
                }
                else { Target.Armour = armourcahe; }
            }
            else
            {
                Target.shield = shieldcache;
            }
            Target.ProtectionSponser = null;
            #endregion

        }
        public void PhysicalDamage(object CharacterInstance, object TargetInstance, DamageObject damageObject)
        {
            int physicalDamage = 0;
            int shieldcache = 0;
            int armourcahe = 0;
            double markedda = 0;

            Persona Character = (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;

            #region Character Logic

            physicalDamage = damageObject.DamageValue;
            damageObject.DamageTrait= DamageObject.DamageVersion.Physical;
            markedda = Character.MarkedDeBuffPerent;
            if (Character.PolishWeapon() == true) physicalDamage += (int)(physicalDamage * Character.PowerBuffPercent);// this is to work the polish buff
            if (Character.Weakg == true) physicalDamage -= (int)(physicalDamage * Character.WeakGripDeBuffPercent);
            if (Character.calmState == true) physicalDamage -= (int)(physicalDamage * Character.CalmDeBuffPercent);

            #endregion
            #region Target Logic

            Target.AttackSponser = Character;
            if (Target.ProtectionSponser != null) Target = (Persona)Target.ProtectionSponser;
            if (Target.markedg == true) physicalDamage += (int)(physicalDamage * markedda);
            if (Target.BlockState == true)
            {
                physicalDamage = 0;
                Target.BlockState = false;
                //blocking animation
            }

            shieldcache = Target.shield;
            armourcahe = Target.Armour;
            shieldcache -= physicalDamage; Target.shield -= physicalDamage;//this will make shield=0 if the physical damage is too much
            //the code below ensures that the sheild is removed first
            if (shieldcache < 0)//this asks if there is no more sheild left
            {
                armourcahe += shieldcache;// here the negative value adds with the positive- following negative number addition laws i hope
                if (armourcahe < 0)//this asks if there is no more armour left
                {
                    Target.Armour = 0; // this makes sure armour is zero
                    damageObject.DamageValue = Math.Abs(armourcahe);
                    Character.TrueDamage(Target, damageObject); //This removes the health of the target
                }
                else { Target.Armour = armourcahe; }
            }
            else
            {
                Target.shield = shieldcache;
            }
            Target.ProtectionSponser = null;
            #endregion

        }// this is so someone can put a tailored value
        public void MagicalDamage(object CharacterInstance, object TargetInstance)
        {
            int magicalDamage = 0;
            int shieldcache = 0;
            int magrescache = 0;
            double markedda = 0;

            Persona Character = (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            DamageObject hitval = new DamageObject();
            hitval.DamageTrait = DamageObject.DamageVersion.Magical;

            #region Character Logic

            magicalDamage = Character.DamageGiven();
            markedda = Character.MarkedDeBuffPerent;
            if (Character.Chosen() == true) magicalDamage += (int)(magicalDamage * Character.MagiBuffPercent);
            if (Character.exiledg == true) magicalDamage -= (int)(magicalDamage * Character.ExiledDeBuffPercent);
            if (Character.calmState == true) magicalDamage -= (int)(magicalDamage * Character.CalmDeBuffPercent);
            #endregion
            #region Target Logic

            Target.AttackSponser = Character; //for Onguard()
            shieldcache = Target.shield;
            magrescache = Target.MagicRes;
            if (Target.ImmuneState == true) magicalDamage = 0;
            shieldcache -= magicalDamage; Target.shield -= magicalDamage;
            if (Target.ProtectionSponser != null) Target = (Persona)Target.ProtectionSponser;
            if (Target.markedg == true) magicalDamage += (int)(magicalDamage * markedda);

            if (shieldcache < 0)//this asks if there is no more sheild left
            {
                magrescache += shieldcache;// here the negative value adds with the positive- following negative number addition laws i hope
                if (magrescache < 0)//this asks if there is no more resistance left
                {
                    Target.MagicRes = 0;
                    hitval.DamageValue = Math.Abs(magrescache);
                    Character.TrueDamage(Target, hitval); //This removes the health of the target
                }
                else { Target.MagicRes = magrescache; }
            }
            else
            {
                Target.shield = shieldcache;
            }
            Target.ProtectionSponser = null;
            #endregion

        }
        public void MagicalDamage(object CharacterInstance, object TargetInstance, int amount)
        {
            int magicalDamage = 0;
            int shieldcache = 0;
            int magrescache = 0;
            double markedda = 0;

            Persona Character = (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            DamageObject hitval = new DamageObject();
            hitval.DamageTrait = DamageObject.DamageVersion.Magical;

            #region Character Logic

            magicalDamage = amount;
            markedda = Character.MarkedDeBuffPerent;
            if (Character.Chosen() == true) magicalDamage += (int)(magicalDamage * Character.MagiBuffPercent);
            if (Character.exiledg == true) magicalDamage -= (int)(magicalDamage * Character.ExiledDeBuffPercent);
            if (Character.calmState == true) magicalDamage -= (int)(magicalDamage * Character.CalmDeBuffPercent);
            #endregion
            #region Target Logic

            Target.AttackSponser = Character; //for Onguard()
            shieldcache = Target.shield;
            magrescache = Target.MagicRes;
            if (Target.ImmuneState == true) magicalDamage = 0;
            shieldcache -= magicalDamage; Target.shield -= magicalDamage;
            if (Target.ProtectionSponser != null) Target = (Persona)Target.ProtectionSponser;
            if (Target.markedg == true) magicalDamage += (int)(magicalDamage * markedda);

            if (shieldcache < 0)//this asks if there is no more sheild left
            {
                magrescache += shieldcache;// here the negative value adds with the positive- following negative number addition laws i hope
                if (magrescache < 0)//this asks if there is no more resistance left
                {
                    Target.MagicRes = 0;
                    hitval.DamageValue = Math.Abs(magrescache);
                    Character.TrueDamage(Target, hitval); //This removes the health of the target
                }
                else { Target.MagicRes = magrescache; }
            }
            else
            {
                Target.shield = shieldcache;
            }
            Target.ProtectionSponser = null;
            #endregion

        }
        public void Drain(object CharacterInstance, object TargetInstance)
        {
            Persona Character = (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            //DamageObject hitval = new DamageObject();
            //hitval.DamageTrait = DamageObject.DamageVersion.Magical;
            Target.AttackSponser = Character;
            if (Target.ImmuneState == true)
            { }
            else { Target.HealthLoss((int)(Target.Health * Character.DrainPercent)); }
            
        }
        public void Ignite(object CharacterInstance, object TargetInstance, int amount)
        {
            Persona Target = (Persona)TargetInstance;
            bool howmany = RoundInfo.RoundDone;
            int count = 0;
            if (howmany != RoundInfo.RoundDone)
            { 
                count++; 
                howmany = RoundInfo.RoundDone;
            }
            if (count == 2)
            {
                if (Target.ImmuneState == true)
                { }
                else
                {
                    MagicalDamage(CharacterInstance, TargetInstance, amount);
                }
            }
                
        }
        public void Bleed(object CharacterInstance, object TargetInstance)
        {
            Persona Target = (Persona)TargetInstance;
            if (Target.ImmuneState == true)
            { }
            else { if (RoundInfo.RoundDone == true) PhysicalDamage(CharacterInstance, TargetInstance); }
            
        }
        public void Blight(object CharacterInstance, object TargetInstance, int amountOfRounds, int amountOfDamage)
        {
            Persona Character = (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;

            int countofroundsineffect = 0;
            int Numberroun = RoundInfo.RoundsPassed;

            Timer Choisss;
            Choisss = new Timer();
            // Tell the timer what to do when it elapses
            Choisss.Elapsed += new ElapsedEventHandler(Maaama);
            // Set it to go off every one seconds
            Choisss.Interval = 1000;
            // And start it        
            Choisss.Enabled = true;
            void Maaama(object source2, ElapsedEventArgs e)
            {
                if (RoundInfo.RoundsPassed > Numberroun)
                {

                    Numberroun = RoundInfo.RoundsPassed;
                    countofroundsineffect++;
                    if (Target.ImmuneState == true)
                    { }
                    else
                    {
                        MagicalDamage(CharacterInstance, TargetInstance, amountOfDamage);
                    }
                }
                if (countofroundsineffect >= amountOfRounds) Choisss.Close();
            }
        }
        public void BalancedDamage(object CharacterInstance, object TargetInstance)
        {
            int Dama = 0; //this should have just been damage but i guess i failed. it should be
            int shieldcache = 0;
            int armourcahe = 0;
            int magrescache = 0;
            double markedda = 0;

            Persona Character = (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            DamageObject hitval = new DamageObject();
            hitval.DamageTrait = DamageObject.DamageVersion.Balanced;

            #region Character Logic

            Dama = Character.DamageGiven();
            if (Character.calmState == true) Dama -= (int)(Dama * Character.CalmDeBuffPercent);
            markedda = Character.MarkedDeBuffPerent;

            #endregion
            #region Target Logic

            Target.AttackSponser = Character;
            if (Target.ImmuneState == true) Dama = 0;
            if (Target.ProtectionSponser != null) Target = (Persona)Target.ProtectionSponser;
            if (Target.markedg == true) Dama += (int)(Dama * markedda);
            shieldcache = Target.shield;
            armourcahe = Target.Armour;
            magrescache = Target.MagicRes;
            shieldcache -= Dama; Target.shield -= Dama;
            //the code below ensures that the sheild is removed first
            if (shieldcache < 0)//this asks if there is no more sheild left
            {
                armourcahe += shieldcache / 2;// here the negative value adds with the positive- following negative number addition laws i hope
                if (armourcahe < 0)//this asks if there is no more armour left
                {
                    Target.Armour = 0; // this makes sure armour is zero
                    hitval.DamageValue = Math.Abs(armourcahe);
                    Character.TrueDamage(Target, hitval); //This removes the health of the target
                }
                else { Target.Armour = armourcahe; }

                magrescache += shieldcache / 2;// here the negative value adds with the positive- following negative number addition laws i hope
                if (magrescache < 0)//this asks if there is no more armour left
                {
                    Target.MagicRes = 0;
                    hitval.DamageValue = Math.Abs(magrescache);
                    Character.TrueDamage(Target, hitval); //This removes the health of the target
                }
                else { Target.MagicRes = magrescache; }
            }
            else
            {
                Target.shield = shieldcache; //this shouldn't be here at all but imleaving it here just in case
            }
            Target.ProtectionSponser = null;
            #endregion

        }
        public void Curse(object CharacterInstance, object TargetInstance)
        {
            int randamage = 0;
            double markedda = 0;

            Persona Character = (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            DamageObject hitval = new DamageObject();
            hitval.DamageTrait = DamageObject.DamageVersion.Magical;

            Target.AttackSponser = Character;// I have doubts that this should be here

            markedda = Character.MarkedDeBuffPerent;
            int roundhaspassed = 0;
            Timer Scar;
            Scar = new Timer();
            // Tell the timer what to do when it elapses
            Scar.Elapsed += new ElapsedEventHandler(Scarer);
            // Set it to go off every one seconds
            Scar.Interval = 1000;
            // And start it        
            Scar.Enabled = true;
            
            roundhaspassed = RoundInfo.RoundsPassed;
            //this is supposed to add to a list up to 5, of the last person to cause you damage. Its called in the constructor and hopefully runs the whole time. 

            void Scarer(object source2, ElapsedEventArgs e)
            {
                if(RoundInfo.RoundsPassed<roundhaspassed+1)
                {
                    Random r = new Random();
                    if (Target.ProtectionSponser != null) Target = (Persona)Target.ProtectionSponser;
                    randamage = r.Next(1, Character.CursePercent);
                    if (Target.markedg == true) randamage += (int)(randamage * markedda);
                    if (Target.ImmuneState == true)
                    { }
                    else
                    {
                        Character.MagicalDamage(Character, Target, randamage);
                    }
                }
            }
        }

        public bool Feign(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }
       
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

        public void Agile(object CharacterInstance)
        {
            int agileCache = 0;

            Persona Character = (Persona)CharacterInstance;
            agileCache = (int)(Character.dodge * Character.AgileBUffPercent);
            Character.dodge += agileCache;
            agileCache = -agileCache;
            if (RoundInfo.RoundDone == true) Character.dodge += agileCache;
        }
        public bool PolishWeapon()
        {
            bool polishWeapon;
            if (RoundInfo.RoundDone == true) polishWeapon = false;
            else { polishWeapon = true; }

            return polishWeapon;
        }
        public bool Chosen()
        {
            bool chosen;
            if (RoundInfo.RoundDone == true) chosen = false;
            else { chosen = true; }

            return chosen;
        }
        public bool Aware()
        {
            bool Aware;
            if (RoundInfo.RoundDone == true) Aware = false;
            else { Aware = true; }

            return Aware;
        }
        public void OnGuard(object CharacterInstance, object TargetInstance)
        {
            int standbyhealth = 0;
            int storedhealth = 0;
            int count = 0;

            Persona Character = (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            int damage1 = 0;
            Timer myTimer2;
            myTimer2 = new Timer();
            // Tell the timer what to do when it elapses
            myTimer2.Elapsed += new ElapsedEventHandler(myEvent);
            // Set it to go off every five seconds
            myTimer2.Interval = 5000;
            // And start it        
            myTimer2.Enabled = true;

            void myEvent(object source2, ElapsedEventArgs e) //this checks if the characterInstance.health changes
            {
                while (RoundInfo.RoundDone == false)
                {
                    standbyhealth = Character.Health;
                    damage1 = (int)(Character.DamageGiven() * Character.counterAttackPercent);
                }
            }
            if (count == 0)//this is to store the initial health
            {
                storedhealth = standbyhealth;
                count++;
            }
            else
            {
                if ((storedhealth != standbyhealth) && (RoundInfo.RoundDone = true)) //if the health changes and the round finished
                {
                    Target.PhysicalDamage(Target, Target.AttackSponser); //This is to attack the person who hit him
                    Target.AttackSponser = null;
                    Target.HealthLoss(damage1);
                    count = 0;
                }

            }
        }
        public void Provoking(object CharacterInstance)
        {
            Persona Character = (Persona)CharacterInstance;
            object scapegoat = Character;
            scapegoat = Character.Allies.Any();
            Random r = new Random();
            double chanceDa = r.Next(1, 101) ;
            if (chanceDa <= Character.ProvokingBuffPercent)
            {
                Protector(CharacterInstance, scapegoat);
            }
        }
        public void Protector(object OwnerInstance, object TargetInstance)
        {
            Persona Character = (Persona)OwnerInstance;
            Persona Target = (Persona)TargetInstance;

            Target.ProtectionSponser = Character;
            if (RoundInfo.RoundDone == true) Target.ProtectionSponser = null;
        }
        public object Protected(object TargetInstance)// this is to return the protector
        {
            Persona Target = (Persona)TargetInstance;
            object sponser = Target;
            //here logic must ask who is the persons proctector
            sponser = Target.ProtectionSponser;
            return sponser;
        }
        public void Revigorate(object TargetInstance)
        {
            Persona Target = (Persona)TargetInstance;
            Target.RemoveDebuffEffects = true;
            //in every Debuff there will be a removeBuff==false, but of course it will ask first if it equals true
        }
        public void HealVictim(object TargetInstance)
        {
            int HealingCache = 0;
            Persona Target = (Persona)TargetInstance;
            HealingCache = (int)(Target.Health * Target.HealBuffPercent);
            Target.Health += HealingCache;
        }
        public void GodsBlessing(object CharacterInstance, List<string> Allies)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Debuff

        public bool Slow(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool Rooted(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool WeakGrip(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool Exiled(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool Marked(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool Calm(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool BrokenGuard(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool Burnt(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool Stun(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool Freeze(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool Cold(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool Blinded(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool Tainted(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool Sleep(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool Hungry(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool Unhealthy(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool GodsAnger(object CharacterInstance, List<string> Allies)
        {
            throw new NotImplementedException();
        }

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


    }
}
