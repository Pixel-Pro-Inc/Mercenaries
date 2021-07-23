using Assets.Scripts.TraitInterface;
using Assets.TraitInterface;
using Assets.TraitInterface.CombantantType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Assets.Entities
{
    public class CharacterPersona: Cards
    {
        /*
         This CharacterPersona is the bluprint for all characters, friend and foe. The properties listed below are all the properties that each character shares
        that does not need to be given a unique default value for that character. Its also the place for variables that arent used often and don't need to be 
        defined. The 'must have' properties are defined in ICharacterTraits. In ICHaractertraits each property will be unique per character and is important and 
        must be implemented and defined.

        Below I planned on defining each unique character and all their traits and abilities (methods).
        In my mind each one will be of Type 'Class' and so this will just be used as a reference for their combat types.
         */
        public enum MasterCharacterList
        {
            //Here a list of every individual character will be defined.Then they will be accessed with their indexes as needed in below lists eg List<>Allies
            #region Heros
            Peter, Mister_Glubglub, Mister_Froggo, Mister_Salaboned, Mister_Lizzacorn, Mister_Liodin, Mister_Lacrox, Mister_Birbarcher, Mister_PirateParrot,
            Mister_SilverSkull, Mister_Mantis, Mister_Hippo,
            #endregion
            #region Foes
            HammerHead,GreatWhite, SpiderCrustacean, NecroBoar, ElderStag, DevilBird, DragonSloth
            #endregion
        }

        
        //Be sure to define the passive traits!!!!!!!!!
        //and the costs if there are any!!!!!!!!
        #region GivenCharacterTraits


        public enum Kingdom { FarWest, MiddleEarth, DarkSyde };
        
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
        internal int ExperienceLevel { get { return ExperienceLevel;  } set { if (ExperienceLevel < 0) ExperienceLevel = 0; } }
        int shield { get { return shield; } set { if (shield < 0) shield = 0; shield = 0; } } //We are defining it (not ICharacterTraits) here cause it isn't used by everyone often but can be, and its 0 for everyone starting off
        public static bool RoundOver { get; set; }
        bool RemoveDebuffEffects { get; set; }

        #region Template Logic
        //The code below was created because i was tired of writting the template code over and over. Itworks much more effeciently. Make sure these arent set 
        //as static cause any methods might be using them at the same time.
        public WarriorTemplate WarriorCBase;
        public WarriorTemplate WarriorTarBase;
        public TankWarriorTemplate TankCBase;
        public TankWarriorTemplate TankTarBase;
        public RangeTemplate RangeCBase;
        public RangeTemplate RangeTarBase;
        public MageTemplate MageCBase;
        public MageTemplate MageTarBase;

        public ControllerTemplate ControllerCBase;
        public ControllerTemplate ControllerTarBase;
        public AssasinTemplate AssasinCBase;
        public AssasinTemplate AssasinTarBase;
        public int TemplateCharacter(object CharacterInstance)
        {
            int TempCharNumber = 0;
            if (CharacterInstance.GetType() == typeof(WarriorTemplate))
            {
                WarriorCBase = (WarriorTemplate)CharacterInstance;
                TempCharNumber = 1;
            }
            if (CharacterInstance.GetType() == typeof(TankWarriorTemplate))
            {
                TankCBase = (TankWarriorTemplate)CharacterInstance;
                TempCharNumber = 2;
            }
            if (CharacterInstance.GetType() == typeof(RangeTemplate))
            {
                RangeCBase = (RangeTemplate)CharacterInstance;
                TempCharNumber = 3;
            }
            if (CharacterInstance.GetType() == typeof(MageTemplate))
            {
                MageCBase = (MageTemplate)CharacterInstance;
                TempCharNumber = 4;
            }
            if (CharacterInstance.GetType() == typeof(ControllerTemplate))
            {
                ControllerCBase = (ControllerTemplate)CharacterInstance;
                TempCharNumber = 5;
            }
            if (CharacterInstance.GetType() == typeof(AssasinTemplate))
            {
                AssasinCBase = (AssasinTemplate)CharacterInstance;
                TempCharNumber = 6;
            }
            return TempCharNumber;
        }
        public string TemplateTarget(object TargetInstance)
        {
            string TempTargetChar="";
            if (TargetInstance.GetType() == typeof(WarriorTemplate))
            {
                WarriorTarBase = (WarriorTemplate)TargetInstance;
                TempTargetChar = "a";
            }
            if (TargetInstance.GetType() == typeof(TankWarriorTemplate))
            {
                TankTarBase = (TankWarriorTemplate)TargetInstance;
                TempTargetChar = "b";
            }
            if (TargetInstance.GetType() == typeof(RangeTemplate))
            {
                RangeTarBase = (RangeTemplate)TargetInstance;
                TempTargetChar = "c";
            }
            if (TargetInstance.GetType() == typeof(MageTemplate))
            {
                MageTarBase = (MageTemplate)TargetInstance;
                TempTargetChar = "d";
            }
            if (TargetInstance.GetType() == typeof(ControllerTemplate))
            {
                ControllerTarBase = (ControllerTemplate)TargetInstance;
                TempTargetChar = "e";
            }
            if (TargetInstance.GetType() == typeof(AssasinTemplate))
            {
                AssasinTarBase = (AssasinTemplate)TargetInstance;
                TempTargetChar = "f";
            }
            return TempTargetChar;
        }
        #endregion


        #endregion
        #region Combat Action

        #region Unique Traits

        public void UniqueSkill(object CharacterInstance, object TargetInstance)
        {
            #region Unique Character template logic

            string Charactername = "";
            if (CharacterInstance.GetType() == typeof(WarriorTemplate))
            {
                WarriorTemplate starter = (WarriorTemplate)CharacterInstance;
                Charactername = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(TankWarriorTemplate))
            {
                TankWarriorTemplate starter = (TankWarriorTemplate)CharacterInstance;
                Charactername = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(RangeTemplate))
            {
                RangeTemplate starter = (RangeTemplate)CharacterInstance;
                Charactername = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(MageTemplate))
            {
                MageTemplate starter = (MageTemplate)CharacterInstance;
                Charactername = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(ControllerTemplate))
            {
                ControllerTemplate starter = (ControllerTemplate)CharacterInstance;
                Charactername = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(AssasinTemplate))
            {
                AssasinTemplate starter = (AssasinTemplate)CharacterInstance;
                Charactername = starter.CharacterName;
            }
            #endregion
            #region Unique Character logic

            switch (Charactername)
            {
                case "Peter":  //here a function will be defined on a object eg, firebreathing(obj target){ breathfire(target);}
                    break;
                case "Mister GlubGlub":
                    break;
                case "Mister froggo":
                    break;
                case "Mister Salaboned":
                    break;
                case "Mister Lizzacorn":
                    break;
                case "Mister Liodin":
                    break;
                case "Mister Lacrox":
                    break;
                case "Mister Birbarcher":
                    break;
                case "Mister PirateParrot":
                    break;
                case "Mister SilverSkull":
                    break;
                case "Mister Mantis":
                    break;
                case "Mister Hippo":
                    break;
                case "HammerHead":
                    break;
                case "GreatWhite":
                    break;
                case "SpiderCrustacean":
                    break;
                case "NecroBoar":
                    break;
                case "ElderStag":
                    break;
                case "DevilBird":
                    break;
                case "DragonSloth":
                    break;

            }

            #endregion
            #region TargetInstance template logic

            string TargetLetter = TemplateTarget(TargetInstance);
            string Targetname = "";
            if (TargetLetter == "a") Targetname = WarriorTarBase.CharacterName; //here after, the actual value change (unquiskilol function method) will happen here on the target 
            if (TargetLetter == "b") Targetname = TankTarBase.CharacterName;
            if (TargetLetter == "c") Targetname = RangeTarBase.CharacterName;
            if (TargetLetter == "d") Targetname = MageTarBase.CharacterName;
            if (TargetLetter == "e") Targetname = ControllerTarBase.CharacterName;
            if (TargetLetter == "f") Targetname = AssasinTarBase.CharacterName;
            #endregion
        }
        public void UniqueActiveBuff(object CharacterInstance, object TargetInstance)
        {
            #region Unique template logic

            string name = "";
            if (CharacterInstance.GetType() == typeof(WarriorTemplate))
            {
                WarriorTemplate starter = (WarriorTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(TankWarriorTemplate))
            {
                TankWarriorTemplate starter = (TankWarriorTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(RangeTemplate))
            {
                RangeTemplate starter = (RangeTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(MageTemplate))
            {
                MageTemplate starter = (MageTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(ControllerTemplate))
            {
                ControllerTemplate starter = (ControllerTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(AssasinTemplate))
            {
                AssasinTemplate starter = (AssasinTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            #endregion
            #region Unique Character logic

            switch (name)
            {
                case "Peter":
                    break;
                case "Mister GlubGlub":
                    break;
                case "Mister froggo":
                    break;
                case "Mister Salaboned":
                    break;
                case "Mister Lizzacorn":
                    break;
                case "Mister Liodin":
                    break;
                case "Mister Lacrox":
                    break;
                case "Mister Birbarcher":
                    break;
                case "Mister PirateParrot":
                    break;
                case "Mister SilverSkull":
                    break;
                case "Mister Mantis":
                    break;
                case "Mister Hippo":
                    break;
                case "HammerHead":
                    break;
                case "GreatWhite":
                    break;
                case "SpiderCrustacean":
                    break;
                case "NecroBoar":
                    break;
                case "ElderStag":
                    break;
                case "DevilBird":
                    break;
                case "DragonSloth":
                    break;

            }

            #endregion
        }

        public void UniqueActiveDeBuff(object CharacterInstance, object TargetInstance)
        {
            #region Unique template logic

            string name = "";
            if (CharacterInstance.GetType() == typeof(WarriorTemplate))
            {
                WarriorTemplate starter = (WarriorTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(TankWarriorTemplate))
            {
                TankWarriorTemplate starter = (TankWarriorTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(RangeTemplate))
            {
                RangeTemplate starter = (RangeTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(MageTemplate))
            {
                MageTemplate starter = (MageTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(ControllerTemplate))
            {
                ControllerTemplate starter = (ControllerTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            if (CharacterInstance.GetType() == typeof(AssasinTemplate))
            {
                AssasinTemplate starter = (AssasinTemplate)CharacterInstance;
                name = starter.CharacterName;
            }
            #endregion
            #region Unique Character logic

            switch (name)
            {
                case "Peter":
                    break;
                case "Mister GlubGlub":
                    break;
                case "Mister froggo":
                    break;
                case "Mister Salaboned":
                    break;
                case "Mister Lizzacorn":
                    break;
                case "Mister Liodin":
                    break;
                case "Mister Lacrox":
                    break;
                case "Mister Birbarcher":
                    break;
                case "Mister PirateParrot":
                    break;
                case "Mister SilverSkull":
                    break;
                case "Mister Mantis":
                    break;
                case "Mister Hippo":
                    break;
                case "HammerHead":
                    break;
                case "GreatWhite":
                    break;
                case "SpiderCrustacean":
                    break;
                case "NecroBoar":
                    break;
                case "ElderStag":
                    break;
                case "DevilBird":
                    break;
                case "DragonSloth":
                    break;

            }

            #endregion
        }

        #endregion


        #region Attack

        public void TrueDamage(object CharacterInstance, object TargetInstance)
        {
            int Damage=0;
            //Note that battleCalculate is never set true here

            #region CharacterInstance template logic giving Damage

            //battleCalculate has to remain false or null.
            int characterNumber = TemplateCharacter(CharacterInstance);
            if (characterNumber == 1)
            {
                Damage = WarriorCBase.DamageGiven();
                if (WarriorCBase.PolishWeapon() == true) Damage = (int)(Damage * WarriorCBase.PowerBuffPercent);// this is to work the polish buff
            }
            if (characterNumber == 2)
            {
                Damage=TankCBase.DamageGiven();
                if (TankCBase.PolishWeapon() == true) Damage = (int)(Damage * TankCBase.PowerBuffPercent);// this is to work the polish buff
            }
            if (characterNumber == 3)
            {
                Damage=RangeCBase.DamageGiven();
                if (RangeCBase.PolishWeapon() == true) Damage = (int)(Damage * RangeCBase.PowerBuffPercent);// this is to work the polish buff
            }
            if (characterNumber == 4)
            {
                Damage=MageCBase.DamageGiven();
                if (MageCBase.PolishWeapon() == true) Damage = (int)(Damage * MageCBase.PowerBuffPercent);// this is to work the polish buff
            }
            if (characterNumber == 5)
            {
                Damage=ControllerCBase.DamageGiven();
                if (ControllerCBase.PolishWeapon() == true) Damage = (int)(Damage * ControllerCBase.PowerBuffPercent);// this is to work the polish buff
            }
            if (characterNumber == 6)
            {
                Damage=AssasinCBase.DamageGiven();
                if (AssasinCBase.PolishWeapon() == true) Damage = (int)(Damage * AssasinCBase.PowerBuffPercent);// this is to work the polish buff
            }
            #endregion
            #region template logic
            object finisher = WarriorTarBase;

            if (TargetInstance.GetType() == typeof(CharacterPersona.WarriorTemplate))
            {
                CharacterPersona.WarriorTemplate starter = (CharacterPersona.WarriorTemplate)TargetInstance;
                if (starter.ProtectionSponser != null) finisher = starter.ProtectionSponser;
                else starter.HealthLoss(Damage);
                TargetInstance = starter;
            }
            if (TargetInstance.GetType() == typeof(CharacterPersona.TankWarriorTemplate))
            {
                CharacterPersona.TankWarriorTemplate starter = (CharacterPersona.TankWarriorTemplate)TargetInstance;
                if (starter.ProtectionSponser != null) finisher = starter.ProtectionSponser;
                else starter.HealthLoss(Damage);
                TargetInstance = starter;
            }
            if (TargetInstance.GetType() == typeof(CharacterPersona.RangeTemplate))
            {
                CharacterPersona.RangeTemplate starter = (CharacterPersona.RangeTemplate)TargetInstance;
                if (starter.ProtectionSponser != null) finisher = starter.ProtectionSponser;
                else starter.HealthLoss(Damage);
                TargetInstance = starter;
            }
            if (TargetInstance.GetType() == typeof(CharacterPersona.MageTemplate))
            {
                CharacterPersona.MageTemplate starter = (CharacterPersona.MageTemplate)TargetInstance;
                if (starter.ProtectionSponser != null) finisher = starter.ProtectionSponser;
                else starter.HealthLoss(Damage);
                TargetInstance = starter;
            }
            if (TargetInstance.GetType() == typeof(CharacterPersona.ControllerTemplate))
            {
                CharacterPersona.ControllerTemplate starter = (CharacterPersona.ControllerTemplate)TargetInstance;
                if (starter.ProtectionSponser != null) finisher = starter.ProtectionSponser;
                else starter.HealthLoss(Damage);
                TargetInstance = starter;
            }
            if (TargetInstance.GetType() == typeof(CharacterPersona.AssasinTemplate))
            {
                CharacterPersona.AssasinTemplate starter = (CharacterPersona.AssasinTemplate)TargetInstance;
                if (starter.ProtectionSponser != null) finisher = starter.ProtectionSponser;
                else starter.HealthLoss(Damage);
                TargetInstance = starter;
            }
            #endregion
            #region TargetInstance template logic

            string TargetLetter = TemplateTarget(finisher);
            if (TargetLetter == "a")
            {
                WarriorTarBase.HealthLoss(Damage);
                TargetInstance = WarriorTarBase;
            }
            if (TargetLetter == "b")
            {
                TankTarBase.HealthLoss(Damage);
                TargetInstance = TankTarBase;
            }
            if (TargetLetter == "c")
            {
                RangeTarBase.HealthLoss(Damage);
                TargetInstance = RangeTarBase;
            }
            if (TargetLetter == "d")
            {
                MageTarBase.HealthLoss(Damage);
                TargetInstance = MageTarBase;
            }
            if (TargetLetter == "e")
            {
                ControllerTarBase.HealthLoss(Damage);
                TargetInstance = ControllerTarBase;
            }
            if (TargetLetter == "f")
            {
                AssasinTarBase.HealthLoss(Damage);
                TargetInstance = AssasinTarBase;
            }
            #endregion

            #region Clean base templates //This is unnecessary cause the templates are changed everytime you use them
            WarriorTarBase = null; 
            TankTarBase = null;
            RangeTarBase = null;
            MageTarBase = null;
            ControllerTarBase = null;
            AssasinTarBase = null;
            #endregion
        }
        public void PhysicalDamage(object CharacterInstance, object TargetInstance)
        {

            int physicalDamage = 0;
            int shieldcache=0;
            int armourcahe=0;
            #region CharacterInstance template logic

            int characterNumber = TemplateCharacter(CharacterInstance);
            //the method DamageGiven needs to be done but the value also needs to be stored. I don't do them separate cause healthlos will still get fired
            if (characterNumber == 1)
            {
                physicalDamage = WarriorCBase.DamageGiven();
            }
            if (characterNumber == 2)
            {
                physicalDamage = TankCBase.DamageGiven();
            }
            if (characterNumber == 3)
            {
                physicalDamage = RangeCBase.DamageGiven();
            }
            if (characterNumber == 4)
            {
                physicalDamage = MageCBase.DamageGiven();
            }
            if (characterNumber == 5)
            {
                physicalDamage = ControllerCBase.DamageGiven();
            }
            if (characterNumber == 6)
            {
                physicalDamage = AssasinCBase.DamageGiven();
            }
            #endregion
            #region TargetInstance template logic

            
            string TargetLetter = TemplateTarget(TargetInstance);
            if (TargetLetter == "a")
            {
                shieldcache = WarriorTarBase.shield;
                armourcahe = WarriorTarBase.Armour;
                shieldcache -= physicalDamage; WarriorTarBase.shield -= physicalDamage;

                if (WarriorTarBase.ProtectionSponser != null) WarriorTarBase = (WarriorTemplate)WarriorTarBase.ProtectionSponser;
                //The above code is just an arbituary convertion. I didnt want to make a third template since its just one value thats changing

                //the code below ensures that the sheild is removed first
                if (shieldcache < 0)//this asks if there is no more sheild left
                { 
                    armourcahe += shieldcache;// here the negative value adds with the positive- following negative number addition laws i hope
                    if (armourcahe<0)//this asks if there is no more armour left
                    {
                        WarriorTarBase.Armour = 0; // this makes sure armour is zero
                        WarriorTarBase.HealthLoss(Math.Abs(armourcahe)); //This removes the health of the target
                    }
                    else { WarriorTarBase.Armour = armourcahe; }
                }
                else
                {
                    WarriorTarBase.shield = shieldcache;
                }
                TargetInstance = WarriorTarBase;
               
            }
            if (TargetLetter == "b")
            {
                shieldcache = TankTarBase.shield;
                armourcahe = TankTarBase.Armour;
                shieldcache -= physicalDamage; TankTarBase.shield -= physicalDamage;

                if (TankTarBase.ProtectionSponser != null) TankTarBase = (TankWarriorTemplate)TankTarBase.ProtectionSponser;

                if (shieldcache < 0)//this asks if there is no more sheild left
                {
                    armourcahe += shieldcache;// here the negative value adds with the positive- following negative number addition laws i hope
                    if (armourcahe < 0)//this asks if there is no more armour left
                    {
                        TankTarBase.Armour = 0;
                        TankTarBase.HealthLoss(Math.Abs(armourcahe)); //This removes the health of the target
                    }
                    else { TankTarBase.Armour = armourcahe; }
                }
                else
                {
                    TankTarBase.shield = shieldcache;
                }
                TargetInstance = TankTarBase;
            }
            if (TargetLetter == "c")
            {
                shieldcache = RangeTarBase.shield;
                armourcahe = RangeTarBase.Armour;
                shieldcache -= physicalDamage; RangeTarBase.shield -= physicalDamage;

                if (RangeTarBase.ProtectionSponser != null) RangeTarBase = (RangeTemplate)RangeTarBase.ProtectionSponser;

                if (shieldcache < 0)//this asks if there is no more sheild left
                {
                    armourcahe += shieldcache;// here the negative value adds with the positive- following negative number addition laws i hope
                    if (armourcahe < 0)//this asks if there is no more armour left
                    {
                        RangeTarBase.Armour = 0;
                        RangeTarBase.HealthLoss(Math.Abs(armourcahe)); //This removes the health of the target
                    }
                    else { RangeTarBase.Armour = armourcahe; }
                }
                else
                {
                    RangeTarBase.shield = shieldcache;
                }
                TargetInstance = RangeTarBase;
            }
            if (TargetLetter == "d")
            {
                shieldcache = MageTarBase.shield;
                armourcahe = MageTarBase.Armour;
                shieldcache -= physicalDamage; MageTarBase.shield -= physicalDamage;

                if (MageTarBase.ProtectionSponser != null) MageTarBase = (MageTemplate)MageTarBase.ProtectionSponser;

                if (shieldcache < 0)//this asks if there is no more sheild left
                {
                    armourcahe += shieldcache;// here the negative value adds with the positive- following negative number addition laws i hope
                    if (armourcahe < 0)//this asks if there is no more armour left
                    {
                        MageTarBase.Armour = 0;
                        MageTarBase.HealthLoss(Math.Abs(armourcahe)); //This removes the health of the target
                    }
                    else { MageTarBase.Armour = armourcahe; }
                }
                else
                {
                    MageTarBase.shield = shieldcache;
                }
                TargetInstance = MageTarBase;
            }
            if (TargetLetter == "e")
            {
                shieldcache = ControllerTarBase.shield;
                armourcahe = ControllerTarBase.Armour;
                shieldcache -= physicalDamage; ControllerTarBase.shield -= physicalDamage;

                if (ControllerTarBase.ProtectionSponser != null) ControllerTarBase = (ControllerTemplate)ControllerTarBase.ProtectionSponser;

                if (shieldcache < 0)//this asks if there is no more sheild left
                {
                    armourcahe += shieldcache;// here the negative value adds with the positive- following negative number addition laws i hope
                    if (armourcahe < 0)//this asks if there is no more armour left
                    {
                        ControllerTarBase.Armour = 0;
                        ControllerTarBase.HealthLoss(Math.Abs(armourcahe)); //This removes the health of the target
                    }
                    else { ControllerTarBase.Armour = armourcahe; }
                }
                else
                {
                    ControllerTarBase.shield = shieldcache;
                }
                TargetInstance = ControllerTarBase;
            }
            if (TargetLetter == "f")
            {
                shieldcache = AssasinTarBase.shield;
                armourcahe = AssasinTarBase.Armour;
                shieldcache -= physicalDamage; AssasinTarBase.shield -= physicalDamage;

                if (AssasinTarBase.ProtectionSponser != null) AssasinTarBase = (AssasinTemplate)AssasinTarBase.ProtectionSponser;

                if (shieldcache < 0)//this asks if there is no more sheild left
                {
                    armourcahe += shieldcache;// here the negative value adds with the positive- following negative number addition laws i hope
                    if (armourcahe < 0)//this asks if there is no more armour left
                    {
                        AssasinTarBase.Armour = 0;
                        AssasinTarBase.HealthLoss(Math.Abs(armourcahe)); //This removes the health of the target
                    }
                    else { AssasinTarBase.Armour = armourcahe; }
                }
                else
                {
                    AssasinTarBase.shield = shieldcache;
                }
                TargetInstance = AssasinTarBase;
            }
            #endregion

        }
        public void MagicalDamage(object CharacterInstance, object TargetInstance)
        {
            int magicalDamage = 0;
            int shieldcache = 0;
            int magrescache = 0;
            #region CharacterInstance template logic

            int characterNumber = TemplateCharacter(CharacterInstance);
            //the method DamageGiven needs to be done but the value also needs to be stored. I don't do them separate cause healthlos will still get fired
            if (characterNumber == 1)
            {
                magicalDamage = WarriorCBase.DamageGiven();
            }
            if (characterNumber == 2)
            {
                magicalDamage = TankCBase.DamageGiven();
            }
            if (characterNumber == 3)
            {
                magicalDamage = RangeCBase.DamageGiven();
            }
            if (characterNumber == 4)
            {
                magicalDamage = MageCBase.DamageGiven();
            }
            if (characterNumber == 5)
            {
                magicalDamage = ControllerCBase.DamageGiven();
            }
            if (characterNumber == 6)
            {
                magicalDamage = AssasinCBase.DamageGiven();
            }
            #endregion
            #region TargetInstance template logic

            string TargetLetter = TemplateTarget(TargetInstance);
            if (TargetLetter == "a")
            {
                shieldcache = WarriorTarBase.shield;
                magrescache = WarriorTarBase.MagicRes;
                shieldcache -= magicalDamage; WarriorTarBase.shield -= magicalDamage;
                if (shieldcache < 0)//this asks if there is no more sheild left
                {
                    magrescache += shieldcache;// here the negative value adds with the positive- following negative number addition laws i hope
                    if (magrescache < 0)//this asks if there is no more armour left
                    {
                        WarriorTarBase.MagicRes = 0;
                        WarriorTarBase.HealthLoss(Math.Abs(magrescache)); //This removes the health of the target
                    }
                    else { WarriorTarBase.MagicRes = magrescache; }
                }
                else
                {
                    WarriorTarBase.shield = shieldcache;
                }
                TargetInstance = WarriorTarBase;
            }
            if (TargetLetter == "b")
            {
                shieldcache = TankTarBase.shield;
                magrescache = TankTarBase.MagicRes;
                shieldcache -= magicalDamage; TankTarBase.shield -= magicalDamage;
                if (shieldcache < 0)//this asks if there is no more sheild left
                {
                    magrescache += shieldcache;// here the negative value adds with the positive- following negative number addition laws i hope
                    if (magrescache < 0)//this asks if there is no more armour left
                    {
                        TankTarBase.MagicRes = 0;
                        TankTarBase.HealthLoss(Math.Abs(magrescache)); //This removes the health of the target
                    }
                    else { TankTarBase.MagicRes = magrescache; }
                }
                else
                {
                    TankTarBase.shield = shieldcache;
                }
                TargetInstance = TankTarBase;
            }
            if (TargetLetter == "c")
            {
                shieldcache = RangeTarBase.shield;
                magrescache = RangeTarBase.MagicRes;
                shieldcache -= magicalDamage; RangeTarBase.shield -= magicalDamage;
                if (shieldcache < 0)//this asks if there is no more sheild left
                {
                    magrescache += shieldcache;// here the negative value adds with the positive- following negative number addition laws i hope
                    if (magrescache < 0)//this asks if there is no more armour left
                    {
                        RangeTarBase.MagicRes = 0;
                        RangeTarBase.HealthLoss(Math.Abs(magrescache)); //This removes the health of the target
                    }
                    else { RangeTarBase.MagicRes = magrescache; }
                }
                else
                {
                    RangeTarBase.shield = shieldcache;
                }
                TargetInstance = RangeTarBase;
            }
            if (TargetLetter == "d")
            {
                shieldcache = MageTarBase.shield;
                magrescache = MageTarBase.MagicRes;
                shieldcache -= magicalDamage; MageTarBase.shield -= magicalDamage;
                if (shieldcache < 0)//this asks if there is no more sheild left
                {
                    magrescache += shieldcache;// here the negative value adds with the positive- following negative number addition laws i hope
                    if (magrescache < 0)//this asks if there is no more armour left
                    {
                        MageTarBase.MagicRes = 0;
                        MageTarBase.HealthLoss(Math.Abs(magrescache)); //This removes the health of the target
                    }
                    else { MageTarBase.MagicRes = magrescache; }
                }
                else
                {
                    MageTarBase.shield = shieldcache;
                }
                TargetInstance = MageTarBase;
            }
            if (TargetLetter == "e")
            {
                shieldcache = ControllerTarBase.shield;
                magrescache = ControllerTarBase.MagicRes;
                shieldcache -= magicalDamage; ControllerTarBase.shield -= magicalDamage;
                if (shieldcache < 0)//this asks if there is no more sheild left
                {
                    magrescache += shieldcache;// here the negative value adds with the positive- following negative number addition laws i hope
                    if (magrescache < 0)//this asks if there is no more armour left
                    {
                        ControllerTarBase.MagicRes = 0;
                        ControllerTarBase.HealthLoss(Math.Abs(magrescache)); //This removes the health of the target
                    }
                    else { ControllerTarBase.MagicRes = magrescache; }
                }
                else
                {
                    ControllerTarBase.shield = shieldcache;
                }
                TargetInstance = ControllerTarBase;
            }
            if (TargetLetter == "f")
            {
                shieldcache = AssasinTarBase.shield;
                magrescache = AssasinTarBase.MagicRes;
                shieldcache -= magicalDamage; AssasinTarBase.shield -= magicalDamage;
                if (shieldcache < 0)//this asks if there is no more sheild left
                {
                    magrescache += shieldcache;// here the negative value adds with the positive- following negative number addition laws i hope
                    if (magrescache < 0)//this asks if there is no more armour left
                    {
                        AssasinTarBase.MagicRes = 0;
                        AssasinTarBase.HealthLoss(Math.Abs(magrescache)); //This removes the health of the target
                    }
                    else { AssasinTarBase.MagicRes = magrescache; }
                }
                else
                {
                    AssasinTarBase.shield = shieldcache;
                }
                TargetInstance = AssasinTarBase;
            }
            #endregion

        }
        public void Drain(object CharacterInstance, object TargetInstance)
        {
            float drainPercent = 0; // I have set this to be a random % instead of a damage per instance as asked by Alex
            Random r = new Random();
            drainPercent=(r.Next(1, 26)/100); //Maximum it willtake only a quarter
            #region TargetInstance template logic

            string TargetLetter = TemplateTarget(TargetInstance);
            if (TargetLetter == "a")
            {
                WarriorTarBase.HealthLoss((int)(WarriorTarBase.Health * drainPercent));
                TargetInstance = WarriorTarBase; //This is so tthe actual instance gets changed instead of the lueprint base only.
            }
            if (TargetLetter == "b")
            {
                TankTarBase.HealthLoss((int)(TankTarBase.Health * drainPercent));
                TargetInstance = TankTarBase;
            }
            if (TargetLetter == "c")
            {
                RangeTarBase.HealthLoss((int)(RangeTarBase.Health * drainPercent));
                TargetInstance = RangeTarBase;
            }
            if (TargetLetter == "d")
            {
                MageTarBase.HealthLoss((int)(MageTarBase.Health * drainPercent));
                TargetInstance = MageTarBase;
            }
            if (TargetLetter == "e")
            {
                ControllerTarBase.HealthLoss((int)(ControllerTarBase.Health * drainPercent));
                TargetInstance = ControllerTarBase;
            }
            if (TargetLetter == "f")
            {
                AssasinTarBase.HealthLoss((int)(AssasinTarBase.Health * drainPercent));
                TargetInstance = AssasinTarBase;
            }
            #endregion

        }
        public void Ignite(object CharacterInstance, object TargetInstance)
        {
            bool howmany = RoundOver;
            int count=0;
            if (howmany != RoundOver) count++; howmany = RoundOver;
            if (count == 2) MagicalDamage(CharacterInstance, TargetInstance);
        }
        public void Bleed(object CharacterInstance, object TargetInstance)
        {
            if (RoundOver == true) PhysicalDamage(CharacterInstance, TargetInstance);
        }
        public void Blight(object CharacterInstance, object TargetInstance)
        {
            int count = 1;
            if (RoundOver==false)
            {
                while (count==1)
                {
                    MagicalDamage(CharacterInstance, TargetInstance);
                }
                count--;
            }
            else count++;
        }
        public void BalancedDamage(object CharacterInstance, object TargetInstance)
        {
            int physicalDamage = 0;
            int shieldcache = 0;
            int armourcahe = 0;
            int magrescache = 0;
            #region CharacterInstance template logic

            int characterNumber = TemplateCharacter(CharacterInstance);
            //the method DamageGiven needs to be done but the value also needs to be stored. I don't do them separate cause healthlos will still get fired
            if (characterNumber == 1)
            {
                physicalDamage = WarriorCBase.DamageGiven();
            }
            if (characterNumber == 2)
            {
                physicalDamage = TankCBase.DamageGiven();
            }
            if (characterNumber == 3)
            {
                physicalDamage = RangeCBase.DamageGiven();
            }
            if (characterNumber == 4)
            {
                physicalDamage = MageCBase.DamageGiven();
            }
            if (characterNumber == 5)
            {
                physicalDamage = ControllerCBase.DamageGiven();
            }
            if (characterNumber == 6)
            {
                physicalDamage = AssasinCBase.DamageGiven();
            }
            #endregion
            #region TargetInstance template logic

            string TargetLetter = TemplateTarget(TargetInstance);
            if (TargetLetter == "a")
            {
                shieldcache = WarriorTarBase.shield;
                armourcahe = WarriorTarBase.Armour;
                magrescache = WarriorTarBase.MagicRes;
                shieldcache -= physicalDamage; WarriorTarBase.shield -= physicalDamage;
                //the code below ensures that the sheild is removed first
                if (shieldcache < 0)//this asks if there is no more sheild left
                {
                    armourcahe += shieldcache/2;// here the negative value adds with the positive- following negative number addition laws i hope
                    if (armourcahe < 0)//this asks if there is no more armour left
                    {
                        WarriorTarBase.Armour = 0; // this makes sure armour is zero
                        WarriorTarBase.HealthLoss(Math.Abs(armourcahe)); //This removes the health of the target
                    }
                    else { WarriorTarBase.Armour = armourcahe; }

                    magrescache += shieldcache/2;// here the negative value adds with the positive- following negative number addition laws i hope
                    if (magrescache < 0)//this asks if there is no more armour left
                    {
                        WarriorTarBase.MagicRes = 0;
                        WarriorTarBase.HealthLoss(Math.Abs(magrescache)); //This removes the health of the target
                    }
                    else { WarriorTarBase.MagicRes = magrescache; }
                }
                else
                {
                    WarriorTarBase.shield = shieldcache; //this shouldn't be here at all but imleaving it here just in case
                }
                TargetInstance = WarriorTarBase; //This is so tthe actual instance gets changed instead of the lueprint base only.
            }
            if (TargetLetter == "b")
            {
                shieldcache = TankTarBase.shield;
                armourcahe = TankTarBase.Armour;
                magrescache = TankTarBase.MagicRes;
                shieldcache -= physicalDamage; TankTarBase.shield -= physicalDamage;
                if (shieldcache < 0)//this asks if there is no more sheild left
                {
                    armourcahe += shieldcache/2;// here the negative value adds with the positive- following negative number addition laws i hope
                    if (armourcahe < 0)//this asks if there is no more armour left
                    {
                        TankTarBase.Armour = 0;
                        TankTarBase.HealthLoss(Math.Abs(armourcahe)); //This removes the health of the target
                    }
                    else { TankTarBase.Armour = armourcahe; }

                    magrescache += shieldcache / 2;// here the negative value adds with the positive- following negative number addition laws i hope
                    if (magrescache < 0)//this asks if there is no more armour left
                    {
                        TankTarBase.MagicRes = 0;
                        TankTarBase.HealthLoss(Math.Abs(magrescache)); //This removes the health of the target
                    }
                    else { TankTarBase.MagicRes = magrescache; }
                }
                else
                {
                    TankTarBase.shield = shieldcache;
                }
                TargetInstance = TankTarBase;
            }
            if (TargetLetter == "c")
            {
                shieldcache = RangeTarBase.shield;
                armourcahe = RangeTarBase.Armour;
                magrescache = RangeTarBase.MagicRes;
                shieldcache -= physicalDamage; RangeTarBase.shield -= physicalDamage;
                if (shieldcache < 0)//this asks if there is no more sheild left
                {
                    armourcahe += shieldcache / 2;// here the negative value adds with the positive- following negative number addition laws i hope
                    if (armourcahe < 0)//this asks if there is no more armour left
                    {
                        RangeTarBase.Armour = 0;
                        RangeTarBase.HealthLoss(Math.Abs(armourcahe)); //This removes the health of the target
                    }
                    else { RangeTarBase.Armour = armourcahe; }

                    magrescache += shieldcache / 2;// here the negative value adds with the positive- following negative number addition laws i hope
                    if (magrescache < 0)//this asks if there is no more armour left
                    {
                        RangeTarBase.MagicRes = 0;
                        RangeTarBase.HealthLoss(Math.Abs(magrescache)); //This removes the health of the target
                    }
                    else { RangeTarBase.MagicRes = magrescache; }
                }
                else
                {
                    RangeTarBase.shield = shieldcache;
                }
                TargetInstance = RangeTarBase;
            }
            if (TargetLetter == "d")
            {
                shieldcache = MageTarBase.shield;
                armourcahe = MageTarBase.Armour;
                magrescache = MageTarBase.MagicRes;
                shieldcache -= physicalDamage; MageTarBase.shield -= physicalDamage;
                if (shieldcache < 0)//this asks if there is no more sheild left
                {
                    armourcahe += shieldcache / 2;// here the negative value adds with the positive- following negative number addition laws i hope
                    if (armourcahe < 0)//this asks if there is no more armour left
                    {
                        MageTarBase.Armour = 0;
                        MageTarBase.HealthLoss(Math.Abs(armourcahe)); //This removes the health of the target
                    }
                    else { MageTarBase.Armour = armourcahe; }

                    magrescache += shieldcache / 2;// here the negative value adds with the positive- following negative number addition laws i hope
                    if (magrescache < 0)//this asks if there is no more armour left
                    {
                        MageTarBase.MagicRes = 0;
                        MageTarBase.HealthLoss(Math.Abs(magrescache)); //This removes the health of the target
                    }
                    else { MageTarBase.MagicRes = magrescache; }
                }
                else
                {
                    MageTarBase.shield = shieldcache;
                }
                TargetInstance = MageTarBase;
            }
            if (TargetLetter == "e")
            {
                shieldcache = ControllerTarBase.shield;
                armourcahe = ControllerTarBase.Armour;
                magrescache = MageTarBase.MagicRes;
                shieldcache -= physicalDamage; ControllerTarBase.shield -= physicalDamage;
                if (shieldcache < 0)//this asks if there is no more sheild left
                {
                    armourcahe += shieldcache / 2;// here the negative value adds with the positive- following negative number addition laws i hope
                    if (armourcahe < 0)//this asks if there is no more armour left
                    {
                        ControllerTarBase.Armour = 0;
                        ControllerTarBase.HealthLoss(Math.Abs(armourcahe)); //This removes the health of the target
                    }
                    else { ControllerTarBase.Armour = armourcahe; }

                    magrescache += shieldcache / 2;// here the negative value adds with the positive- following negative number addition laws i hope
                    if (magrescache < 0)//this asks if there is no more armour left
                    {
                        ControllerTarBase.MagicRes = 0;
                        ControllerTarBase.HealthLoss(Math.Abs(magrescache)); //This removes the health of the target
                    }
                    else { ControllerTarBase.MagicRes = magrescache; }
                }
                else
                {
                    ControllerTarBase.shield = shieldcache;
                }
                TargetInstance = ControllerTarBase;
            }
            if (TargetLetter == "f")
            {
                shieldcache = AssasinTarBase.shield;
                armourcahe = AssasinTarBase.Armour;
                magrescache = AssasinTarBase.MagicRes;
                shieldcache -= physicalDamage; AssasinTarBase.shield -= physicalDamage;
                if (shieldcache < 0)//this asks if there is no more sheild left
                {
                    armourcahe += shieldcache / 2;// here the negative value adds with the positive- following negative number addition laws i hope
                    if (armourcahe < 0)//this asks if there is no more armour left
                    {
                        AssasinTarBase.Armour = 0;
                        AssasinTarBase.HealthLoss(Math.Abs(armourcahe)); //This removes the health of the target
                    }
                    else { AssasinTarBase.Armour = armourcahe; }

                    magrescache += shieldcache / 2;// here the negative value adds with the positive- following negative number addition laws i hope
                    if (magrescache < 0)//this asks if there is no more armour left
                    {
                        AssasinTarBase.MagicRes = 0;
                        AssasinTarBase.HealthLoss(Math.Abs(magrescache)); //This removes the health of the target
                    }
                    else { AssasinTarBase.MagicRes = magrescache; }
                }
                else
                {
                    AssasinTarBase.shield = shieldcache;
                }
                TargetInstance = AssasinTarBase;
            }
            #endregion
        }
        public void Curse(object CharacterInstance, object TargetInstance)
        {
            int randamage = 0;
           
            int count = 1;
            if (RoundOver == false)
            {
                while (count == 1)
                {
                    Random r = new Random();
                    randamage = r.Next(1, 20);
                    #region TargetInstance template logic


                    string TargetLetter = TemplateTarget(TargetInstance);
                    if (TargetLetter == "a")
                    {
                        WarriorTarBase.HealthLoss(randamage);
                        TargetInstance = WarriorTarBase;

                    }
                    if (TargetLetter == "b")
                    {
                        TankTarBase.HealthLoss(randamage);
                        TargetInstance = TankTarBase;
                    }
                    if (TargetLetter == "c")
                    {
                        RangeTarBase.HealthLoss(randamage);
                        TargetInstance = RangeTarBase;
                    }
                    if (TargetLetter == "d")
                    {
                        MageTarBase.HealthLoss(randamage);
                        TargetInstance = MageTarBase;
                    }
                    if (TargetLetter == "e")
                    {
                        ControllerTarBase.HealthLoss(randamage);
                        TargetInstance = ControllerTarBase;
                    }
                    if (TargetLetter == "f")
                    {
                        AssasinTarBase.HealthLoss(randamage);
                        TargetInstance = AssasinTarBase;
                    }
                    #endregion
                }
                count--;
            }
            else count++;
        }

        public bool Feign(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
            //hitcount will go up but the health and armour and sheild wont be touched
        }

        #endregion
        #region Defend

        public void PutArmour(object CharacterInstance, bool state, int amount) => new Defend(this).Armour(state, amount, TemplateCharacter(CharacterInstance));

        public void IncreaseMagicalResistance(object CharacterInstance, bool state, int amount) => new Defend(this).MagicalResistance(state, amount, TemplateCharacter(CharacterInstance));

        public void ShieldUp(object CharacterInstance, bool state, int amount) => new Defend(this).Shield(state, amount, TemplateCharacter(CharacterInstance));

        public void Purified(object CharacterInstance, bool state) => new Defend(this).Purified(state, TemplateCharacter(CharacterInstance));

        public void Block(object CharacterInstance, bool state) => new Defend(this).Block(state, TemplateCharacter(CharacterInstance));

        public void Immune(object CharacterInstance, bool state) => new Defend(this).Immune(state, TemplateCharacter(CharacterInstance));

        #endregion

        #region Buff

        public void Agile(object CharacterInstance)
        {
            int agileCache=0;
            #region CharacterInstance template logic

            //battleCalculate has to remain false or null.
            int characterNumber = TemplateCharacter(CharacterInstance);
            if (characterNumber == 1)
            {
                agileCache = (int)(WarriorCBase.dodge * WarriorCBase.AgileBUffPercent);
                WarriorCBase.dodge += agileCache;
                CharacterInstance = WarriorCBase;
            }
            if (characterNumber == 2)
            {
                agileCache = (int)(TankCBase.dodge * TankCBase.AgileBUffPercent);
                TankCBase.dodge += agileCache;
                CharacterInstance = TankCBase;
            }
            if (characterNumber == 3)
            {
                agileCache = (int)(RangeCBase.dodge * RangeCBase.AgileBUffPercent);
                RangeCBase.dodge += agileCache;
                CharacterInstance = RangeCBase;
            }
            if (characterNumber == 4)
            {
                agileCache = (int)(MageCBase.dodge * MageCBase.AgileBUffPercent);
                MageCBase.dodge += agileCache;
                CharacterInstance = MageCBase;
            }
            if (characterNumber == 5)
            {
                agileCache = (int)(ControllerCBase.dodge * ControllerCBase.AgileBUffPercent);
                ControllerCBase.dodge += agileCache;
                CharacterInstance = ControllerCBase;
            }
            if (characterNumber == 6)
            {
                agileCache = (int)(AssasinCBase.dodge * AssasinCBase.AgileBUffPercent);
                AssasinCBase.dodge += agileCache;
                CharacterInstance = AssasinCBase;
            }
            #endregion
            if (RoundOver==true)
            { 
                agileCache = -agileCache; //this reverses the sign so that it simply undoes the added value
                if (characterNumber == 1)
                {
                    WarriorCBase.dodge += agileCache;
                    CharacterInstance = WarriorCBase;
                }
                if (characterNumber == 2)
                {
                    TankCBase.dodge += agileCache;
                    CharacterInstance = TankCBase;
                }
                if (characterNumber == 3)
                {
                    RangeCBase.dodge += agileCache;
                    CharacterInstance = RangeCBase;
                }
                if (characterNumber == 4)
                {
                    MageCBase.dodge += agileCache;
                    CharacterInstance = MageCBase;
                }
                if (characterNumber == 5)
                {
                    ControllerCBase.dodge += agileCache;
                    CharacterInstance = ControllerCBase;
                }
                if (characterNumber == 6)
                {
                    AssasinCBase.dodge += agileCache;
                    CharacterInstance = AssasinCBase;
                }
            }
        }
        public bool PolishWeapon()
        {
            bool polishWeapon;
            if (RoundOver== true) polishWeapon= false; 
            else { polishWeapon = true; }

            return polishWeapon;
        }
        public bool Chosen()
        {
            bool chosen;
            if (RoundOver == true) chosen = false;
            else { chosen = true; }

            return chosen;
        }
        public bool Aware()
        {
            bool Aware;
            if (RoundOver == true) Aware = false;
            else { Aware = true; }

            return Aware;
        }
        public void OnGuard(object CharacterInstance, object TargetInstance)
        {
            int standbyhealth=0;
            int storedhealth = 0;
            int count = 0;

            int damage1 = 0;
            Timer myTimer2;
            myTimer2 = new System.Timers.Timer();
            // Tell the timer what to do when it elapses
            myTimer2.Elapsed += new ElapsedEventHandler(myEvent);
            // Set it to go off every five seconds
            myTimer2.Interval = 5000;
            // And start it        
            myTimer2.Enabled = true;

            // Implement a call with the right signature for events going off
            void myEvent(object source, ElapsedEventArgs e) //this checks if the characterInstance.health changes
            {
                while (RoundOver == false)
                {
                    #region CharacterInstance template logic

                    int characterNumber = TemplateCharacter(CharacterInstance);
                    if (characterNumber == 1)
                    {
                        standbyhealth = WarriorCBase.Health;
                        damage1 = (int)(WarriorCBase.DamageGiven() * WarriorCBase.counterAttackPercent);
                    }
                    if (characterNumber == 2)
                    {
                        standbyhealth = TankCBase.Health;
                        damage1 = (int)(TankCBase.DamageGiven() * TankCBase.counterAttackPercent);
                    }
                    if (characterNumber == 3)
                    {
                        standbyhealth = RangeCBase.Health;
                        damage1 = (int)(RangeCBase.DamageGiven() * RangeCBase.counterAttackPercent);
                    }
                    if (characterNumber == 4)
                    {
                        standbyhealth = MageCBase.Health;
                        damage1 = (int)(MageCBase.DamageGiven() * MageCBase.counterAttackPercent);
                    }
                    if (characterNumber == 5)
                    {
                        standbyhealth = ControllerCBase.Health;
                        damage1 = (int)(ControllerCBase.DamageGiven() * ControllerCBase.counterAttackPercent);
                    }
                    if (characterNumber == 6)
                    {
                        standbyhealth = AssasinCBase.Health;
                        damage1 = (int)(AssasinCBase.DamageGiven() * AssasinCBase.counterAttackPercent);
                    }
                    #endregion
                }
            }
            

            if (count == 0)//this is to store the initial health
            {
                storedhealth = standbyhealth;
                count++;
            }
            else
            {
                if ((storedhealth != standbyhealth)&&(RoundOver=true)) //if the health changes and the round finished
                {
                    WarriorTarBase.HealthLoss(damage1);
                    TankTarBase.HealthLoss(damage1);
                    RangeTarBase.HealthLoss(damage1);
                    MageTarBase.HealthLoss(damage1);
                    ControllerTarBase.HealthLoss(damage1);
                    AssasinTarBase.HealthLoss(damage1);

                    #region TargetInstance template logic to hange the characterinstance

                    string TargetLetter = TemplateTarget(TargetInstance);
                    if (TargetLetter == "a") TargetInstance = WarriorTarBase;
                    if (TargetLetter == "b") TargetInstance = TankTarBase;
                    if (TargetLetter == "c") TargetInstance = RangeTarBase;
                    if (TargetLetter == "d") TargetInstance = MageTarBase;
                    if (TargetLetter == "e") TargetInstance = ControllerTarBase;
                    if (TargetLetter == "f") TargetInstance = AssasinTarBase;
                    #endregion
                }

            } 
        }
        public void Provoking(object CharacterInstance)
        {
            object scapegoat = WarriorCBase;
            #region CharacterInstance template logic

            int characterNumber = TemplateCharacter(CharacterInstance);
            if (characterNumber == 1)
            {
                scapegoat= WarriorCBase.Allies.Any();
            }
            if (characterNumber == 2)
            {
                scapegoat= TankCBase.Allies.Any();
            }
            if (characterNumber == 3)
            {
                scapegoat= RangeCBase.Allies.Any();
            }
            if (characterNumber == 4)
            {
                scapegoat= MageCBase.Allies.Any();
            }
            if (characterNumber == 5)
            {
                scapegoat= ControllerCBase.Allies.Any();
            }
            if (characterNumber == 6)
            {
                scapegoat= AssasinCBase.Allies.Any();
            }
            #endregion
            Random r = new Random();
            double chanceDa = r.Next(1, 101)/100;
            if (chanceDa>=50)
            {
                Protector(CharacterInstance, scapegoat);
            }
        }
        public void Protector(object OwnerInstance, object TargetInstance)
        {
            //this must assign themselves as the targets protector
            #region TargetInstance template logic

            string TargetLetter = TemplateTarget(TargetInstance);
            if (TargetLetter == "a")
            {
                WarriorTarBase.ProtectionSponser= OwnerInstance;
            }
            if (TargetLetter == "b")
            {
                TankTarBase.ProtectionSponser = OwnerInstance; ;
            }
            if (TargetLetter == "c")
            {
               RangeTarBase.ProtectionSponser = OwnerInstance; ;
            }
            if (TargetLetter == "d")
            {
                MageTarBase.ProtectionSponser = OwnerInstance; ;
            }
            if (TargetLetter == "e")
            {
                ControllerTarBase.ProtectionSponser = OwnerInstance; ;
            }
            if (TargetLetter == "f")
            {
                AssasinTarBase.ProtectionSponser = OwnerInstance; ;
            }
            #endregion
            if (RoundOver == true)
            {
                if (TargetLetter == "a")
                {
                    WarriorTarBase.ProtectionSponser = null;
                }
                if (TargetLetter == "b")
                {
                    TankTarBase.ProtectionSponser = null; 
                }
                if (TargetLetter == "c")
                {
                    RangeTarBase.ProtectionSponser = null; 
                }
                if (TargetLetter == "d")
                {
                    MageTarBase.ProtectionSponser = null; 
                }
                if (TargetLetter == "e")
                {
                    ControllerTarBase.ProtectionSponser = null;
                }
                if (TargetLetter == "f")
                {
                    AssasinTarBase.ProtectionSponser = null;
                }
            }
        }
        public object Protected(object TargetInstance) //this must return the protector
        {
            object sponser=WarriorTarBase;
            //here logic must ask who is the persons proctector
            #region TargetInstance template logic

            string TargetLetter = TemplateTarget(TargetInstance);
            if (TargetLetter == "a")
            {
                sponser = WarriorTarBase.ProtectionSponser;
            }
            if (TargetLetter == "b")
            {
                sponser = TankTarBase.ProtectionSponser;
            }
            if (TargetLetter == "c")
            {
                sponser = RangeTarBase.ProtectionSponser;
            }
            if (TargetLetter == "d")
            {
                sponser = MageTarBase.ProtectionSponser;
            }
            if (TargetLetter == "e")
            {
                sponser = ControllerTarBase.ProtectionSponser;
            }
            if (TargetLetter == "f")
            {
                sponser = AssasinTarBase.ProtectionSponser;
            }
            #endregion
            return sponser;
        }
        public void Revigorate(object CharacterInstance, object TargetInstance)
        {
            #region TargetInstance template logic

            string TargetLetter = TemplateTarget(TargetInstance);
            if (TargetLetter == "a")
            {
                WarriorTarBase.RemoveDebuffEffects=true;
                TargetInstance = WarriorTarBase;
            }
            if (TargetLetter == "b")
            {
                TankTarBase.RemoveDebuffEffects=true;
                TargetInstance = TankTarBase;
            }
            if (TargetLetter == "c")
            {
                RangeTarBase.RemoveDebuffEffects=true;
                TargetInstance = RangeTarBase;
            }
            if (TargetLetter == "d")
            {
                MageTarBase.RemoveDebuffEffects=true;
                TargetInstance = MageTarBase;
            }
            if (TargetLetter == "e")
            {
                ControllerTarBase.RemoveDebuffEffects=true;
                TargetInstance = ControllerTarBase;
            }
            if (TargetLetter == "f")
            {
                AssasinTarBase.RemoveDebuffEffects=true;
                TargetInstance = AssasinTarBase;
            }
            #endregion
        }
        public void HealVictim(object TargetInstance)
        {
            int HealingCache = 0;
            #region CharacterInstance template logic

            //battleCalculate has to remain false or null.
            int characterNumber = TemplateCharacter(TargetInstance);
            if (characterNumber == 1)
            {
                HealingCache = (int)(WarriorCBase.Health * WarriorCBase.HealBuffPercent);
                WarriorCBase.Health += HealingCache;
                TargetInstance = WarriorCBase;
            }
            if (characterNumber == 2)
            {
                HealingCache = (int)(TankCBase.Health * TankCBase.HealBuffPercent);
                TankCBase.Health += HealingCache;
                TargetInstance = TankCBase;
            }
            if (characterNumber == 3)
            {
                HealingCache = (int)(RangeCBase.Health * RangeCBase.HealBuffPercent);
                RangeCBase.Health += HealingCache;
                TargetInstance = RangeCBase;
            }
            if (characterNumber == 4)
            {
                HealingCache = (int)(MageCBase.Health * MageCBase.HealBuffPercent);
                MageCBase.Health += HealingCache;
                TargetInstance = MageCBase;
            }
            if (characterNumber == 5)
            {
                HealingCache = (int)(ControllerCBase.Health * ControllerCBase.HealBuffPercent);
                ControllerCBase.Health += HealingCache;
                TargetInstance = ControllerCBase;
            }
            if (characterNumber == 6)
            {
                HealingCache = (int)(AssasinCBase.Health * AssasinCBase.HealBuffPercent);
                AssasinCBase.Health += HealingCache;
                TargetInstance = AssasinCBase;
            }
            #endregion

            if (true/*Round over*/)
            {
                HealingCache = -HealingCache; //this reverses the sign so that it simply undoes the added value
                if (characterNumber == 1)
                {
                    WarriorCBase.Health += HealingCache;
                }
                if (characterNumber == 2)
                {
                    TankCBase.Health += HealingCache;
                }
                if (characterNumber == 3)
                {
                    RangeCBase.Health += HealingCache;
                }
                if (characterNumber == 4)
                {
                    MageCBase.Health += HealingCache;
                }
                if (characterNumber == 5)
                {
                    ControllerCBase.Health += HealingCache;
                }
                if (characterNumber == 6)
                {
                    AssasinCBase.Health += HealingCache;
                }
            }
        }
        public void GodsBlessing(object CharacterInstance, List<string> Allies)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Debuff

        public bool Slow(object CharacterInstance, object TargetInstance)
        {
            #region CharacterInstance template logic

            int characterNumber = TemplateCharacter(CharacterInstance);
            //the method DamageGiven needs to be done but the value also needs to be stored. I don't do them separate cause healthlos will still get fired
            if (characterNumber == 1)
            {
                WarriorCBase.Slow(CharacterInstance, TargetInstance);
            }
            if (characterNumber == 2)
            {
                TankCBase.Slow(CharacterInstance, TargetInstance);
            }
            if (characterNumber == 3)
            {
                RangeCBase.Slow(CharacterInstance, TargetInstance);
            }
            if (characterNumber == 4)
            {
                MageCBase.Slow(CharacterInstance, TargetInstance);
            }
            if (characterNumber == 5)
            {
                ControllerCBase.Slow(CharacterInstance, TargetInstance);
            }
            if (characterNumber == 6)
            {
                AssasinCBase.Slow(CharacterInstance, TargetInstance);
            }
            #endregion         
            return true;
        }

        public bool Rooted(object CharacterInstance, object TargetInstance)
        {
            #region CharacterInstance template logic

            int characterNumber = TemplateCharacter(CharacterInstance);
            //the method DamageGiven needs to be done but the value also needs to be stored. I don't do them separate cause healthlos will still get fired
            if (characterNumber == 1)
            {
                WarriorCBase.Rooted(CharacterInstance, TargetInstance);
            }
            if (characterNumber == 2)
            {
                TankCBase.Rooted(CharacterInstance, TargetInstance);
            }
            if (characterNumber == 3)
            {
                RangeCBase.Rooted(CharacterInstance, TargetInstance);
            }
            if (characterNumber == 4)
            {
                MageCBase.Rooted(CharacterInstance, TargetInstance);
            }
            if (characterNumber == 5)
            {
                ControllerCBase.Rooted(CharacterInstance, TargetInstance);
            }
            if (characterNumber == 6)
            {
                AssasinCBase.Rooted(CharacterInstance, TargetInstance);
            }
            #endregion         
            return true;
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

        #endregion

        #region Items 

        Items.HolyCrossTemplate HolyCrossItem = new Items.HolyCrossTemplate();
        Items.Nth_Metal Nth_Metal_Item = new Items.Nth_Metal();
        Items.GaiaShieldTemplate GaiaShieldTemplate = new Items.GaiaShieldTemplate();

        public void EquipItem(object item, object CharacterInstance)
        {
            if (item.GetType() == typeof(Items.HolyCrossTemplate))
            {
                HolyCrossItem.ActivationRequireMent(CharacterInstance);
            }
            if (item.GetType() == typeof(Items.Nth_Metal))
            {
                Nth_Metal_Item.ActivationRequireMent(CharacterInstance);
            }
            if (item.GetType() == typeof(Items.GaiaShieldTemplate))
            {
                GaiaShieldTemplate.ActivationRequireMent(CharacterInstance);
            }
        }
        

        #endregion
    }
}
