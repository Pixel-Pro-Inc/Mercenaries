using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assets.Scripts.Entities.Character.Persona;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Entities.Character;
using Random = UnityEngine.Random;
using static Assets.Scripts.Models.Enums;
using Assets.Scripts.Helpers;
using System.Collections;

namespace Assets.Scripts.MonoBehaviours
{
    public class CharacterBehaviour : MonoBehaviour
    {
        public Vector3[] positions = { new Vector3(-7.0f, -1.6f, 1.0f), new Vector3(-5.0f, -1.6f, 1.0f), new Vector3(-3.0f, -1.6f, 1.0f), new Vector3(-1.0f, -1.6f, 1.0f) };
        public GameObject parent;
        public Vector3 Goto;
        public Vector3 origin;

        public Deity Norgami=Deity.Atheos;
        public SpeciesType species; //dont like this ode at all, but he put us too deep to manage
        public MasterCharacterList Everyone;

        public Image Deck;
        public bool turnUsed;

        public Vector3 attackOffset = new Vector3(1, 0, 0);


        public Persona person;

        public List<Persona> enemies = new List<Persona>();

        void Awake()
        {
            parent = transform.parent.gameObject;
            Goto = transform.position;
            Deck = GameObject.Find("Deck").GetComponent<Image>();
        }
        private void Start()
        {
            origin = transform.position;

            List<Persona> heroCharacters = new List<Persona>();
            for (int i = 0; i < GameManager.Instance.playerCharacters.Count; i++)
            {
                heroCharacters.Add(GameManager.Instance.playerCharacters[i].GetComponentInChildren<Persona>());
            }
            switch (Everyone)
            {
                case MasterCharacterList.Peter:                    
                    //
                    break;
                case MasterCharacterList.Mister_Glubglub:
                    WarriorTemplate MisterGlub = gameObject.AddComponent<WarriorTemplate>();
                    MisterGlub.CharacterName = "Mister_Glubglub";
                    MisterGlub.CharacterDescription = "He is a fish. What did you expect?";
                    MisterGlub.CharacterSpecies = SpeciesType.Fish;
                    MisterGlub.PersonName = Everyone;

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedGlub = new List<SpeciesType> { SpeciesType.Frog, SpeciesType.Fish };
                    MisterGlub.NaturalAllies = NaturalAlliedGlub;
                    List<SpeciesType> NaturalenemiedGlub = new List<SpeciesType> { SpeciesType.Crocodile, SpeciesType.Lion };
                    MisterGlub.NaturalEnemies = NaturalenemiedGlub;

                    MisterGlub.Foe = false;                   

                    person = (Persona)MisterGlub;//gameObject.AddComponent<Persona>();
                    person.Life = 70;

                    person.maxShield = new WarriorTemplate().shield;
                    break;
                case MasterCharacterList.Mister_Froggo:
                    MageTemplate MisterFroggo = gameObject.AddComponent<MageTemplate>();
                    MisterFroggo.CharacterName = "Mister_Froggo";
                    MisterFroggo.CharacterDescription = "Ribbit, ribbit, Keroo, Ribbit";
                    MisterFroggo.CharacterSpecies = SpeciesType.Frog;
                    MisterFroggo.PersonName = Everyone;

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedFroggo = new List<SpeciesType> { SpeciesType.Frog, SpeciesType.Fish };
                    MisterFroggo.NaturalAllies = NaturalAlliedFroggo;
                    List<SpeciesType> NaturalenemiedFroggo = new List<SpeciesType> { SpeciesType.Crocodile, SpeciesType.Salamander };
                    MisterFroggo.NaturalEnemies = NaturalenemiedFroggo;

                    MisterFroggo.Foe = false;

                    person = MisterFroggo;//gameObject.AddComponent<Persona>();
                    person.Life = 55;

                    person.maxShield = new MageTemplate().shield;
                    break;
                case MasterCharacterList.Mister_Salaboned:
                    TankWarriorTemplate MisterSalaboned = gameObject.AddComponent<TankWarriorTemplate>();
                    MisterSalaboned.CharacterName = "Mister_Salaboned";
                    MisterSalaboned.CharacterDescription = "A man plagued by demonic shadows. After discovering forbiden gray magic, he uses his skill to reach his deepest desire, no matter the cost";
                    MisterSalaboned.CharacterSpecies = SpeciesType.Salamander;
                    MisterSalaboned.PersonName = Everyone;

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedSala = new List<SpeciesType> { SpeciesType.Triton };
                    MisterSalaboned.NaturalAllies = NaturalAlliedSala;
                    List<SpeciesType> NaturalenemiedSala = new List<SpeciesType> { SpeciesType.Lion };
                    MisterSalaboned.NaturalEnemies = NaturalenemiedSala;

                    MisterSalaboned.Foe = false;

                    person = MisterSalaboned;//gameObject.AddComponent<Persona>();
                    person.Life = 120;

                    person.maxShield = new TankWarriorTemplate().shield;
                    break;
                case MasterCharacterList.Mister_Lizzacorn:
                    WarriorTemplate MisterLizzacorn = gameObject.AddComponent<WarriorTemplate>();
                    MisterLizzacorn.CharacterName = "Mister_Lizzacorn";
                    MisterLizzacorn.CharacterDescription = "I'm not being defensive, you are!";
                    MisterLizzacorn.CharacterSpecies = SpeciesType.Triton;
                    MisterLizzacorn.PersonName = Everyone;

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedLizza = new List<SpeciesType> { SpeciesType.Salamander, SpeciesType.Triton };
                    MisterLizzacorn.NaturalAllies = NaturalAlliedLizza;
                    List<SpeciesType> NaturalenemiedLizza = new List<SpeciesType> { SpeciesType.Crocodile };
                    MisterLizzacorn.NaturalEnemies = NaturalenemiedLizza;

                    MisterLizzacorn.Foe = false;

                    person = MisterLizzacorn;//gameObject.AddComponent<Persona>();
                    person.Life = 70;

                    person.maxShield = new WarriorTemplate().shield;
                    break;
                case MasterCharacterList.Mister_Liodin:
                    WarriorTemplate MisterLiodin = gameObject.AddComponent<WarriorTemplate>();
                    MisterLiodin.CharacterName = "Mister_Liodin";
                    MisterLiodin.CharacterDescription = "Yes, thats correct. Everything the Light touches";
                    MisterLiodin.CharacterSpecies = SpeciesType.Lion;
                    MisterLiodin.PersonName = Everyone;

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedLiodin = new List<SpeciesType> { SpeciesType.Lion, SpeciesType.Salamander };
                    MisterLiodin.NaturalAllies = NaturalAlliedLiodin;
                    List<SpeciesType> NaturalenemiedLiodin = new List<SpeciesType> { SpeciesType.Triton, SpeciesType.Crocodile };
                    MisterLiodin.NaturalEnemies = NaturalenemiedLiodin;

                    MisterLiodin.Foe = false;

                    person = MisterLiodin;//gameObject.AddComponent<Persona>();
                    person.Life = 70;

                    person.maxShield = new WarriorTemplate().shield;
                    break;
                case MasterCharacterList.Mister_Lacrox:
                    WarriorTemplate MisterLacrox = gameObject.AddComponent<WarriorTemplate>();
                    MisterLacrox.CharacterName = "Mister_Lacrox";
                    MisterLacrox.CharacterDescription = "Nani?!Kotowaru!";
                    MisterLacrox.CharacterSpecies = SpeciesType.Crocodile;
                    MisterLacrox.PersonName = Everyone;

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedLacrox = new List<SpeciesType> { };
                    MisterLacrox.NaturalAllies = NaturalAlliedLacrox;
                    List<SpeciesType> NaturalenemiedLAcrox = new List<SpeciesType> { SpeciesType.Salamander, SpeciesType.Lion };
                    MisterLacrox.NaturalEnemies = NaturalenemiedLAcrox;

                    MisterLacrox.Foe = false;

                    person = MisterLacrox;//gameObject.AddComponent<Persona>();
                    person.Life = 70;

                    person.maxShield = new WarriorTemplate().shield;
                    break;
                case MasterCharacterList.Mister_Birbarcher:
                    RangeTemplate MisterBirbarcher = gameObject.AddComponent<RangeTemplate>();
                    MisterBirbarcher.CharacterName = "Mister_Birbarcher";
                    MisterBirbarcher.CharacterDescription = "Has anyone seen any female elves here? Nevermind.....";
                    MisterBirbarcher.CharacterSpecies = SpeciesType.Fish;
                    MisterBirbarcher.PersonName = Everyone;

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedBircher = new List<SpeciesType> { SpeciesType.Frog, SpeciesType.Fish };
                    MisterBirbarcher.NaturalAllies = NaturalAlliedBircher;
                    List<SpeciesType> NaturalenemiedBircher = new List<SpeciesType> { SpeciesType.Crocodile, SpeciesType.Lion };
                    MisterBirbarcher.NaturalEnemies = NaturalenemiedBircher;

                    MisterBirbarcher.Foe = false;

                    person = MisterBirbarcher;//gameObject.AddComponent<Persona>();
                    person.Life = 58;

                    person.maxShield = new RangeTemplate().shield;
                    break;
                case MasterCharacterList.Mister_PirateParrot:
                    ControllerTemplate MisterPirateParrot = gameObject.AddComponent<ControllerTemplate>();
                    MisterPirateParrot.CharacterName = "Mister_PirateParrot";
                    MisterPirateParrot.CharacterDescription = "Say cracker one more time, I dare ya.....";
                    MisterPirateParrot.CharacterSpecies = SpeciesType.Parrot;
                    MisterPirateParrot.PersonName = Everyone;

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedPirate = new List<SpeciesType> { SpeciesType.Frog, SpeciesType.Fish };
                    MisterPirateParrot.NaturalAllies = NaturalAlliedPirate;
                    List<SpeciesType> NaturalenemiedPirate = new List<SpeciesType> { SpeciesType.Crocodile, SpeciesType.Lion };
                    MisterPirateParrot.NaturalEnemies = NaturalenemiedPirate;

                    MisterPirateParrot.Foe = false;

                    person = MisterPirateParrot;//gameObject.AddComponent<Persona>();
                    person.Life = 68;

                    person.maxShield = new ControllerTemplate().shield;
                    break;
                case MasterCharacterList.Mister_SilverSkull:
                    WarriorTemplate MisterSilverSkull = gameObject.AddComponent<WarriorTemplate>();
                    MisterSilverSkull.CharacterName = "Mister_SilverSkull";
                    MisterSilverSkull.CharacterDescription = "Oh where am I from? Earth...";
                    MisterSilverSkull.CharacterSpecies = SpeciesType.Triton;
                    MisterSilverSkull.PersonName = Everyone;

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedSkull = new List<SpeciesType> { SpeciesType.Salamander, SpeciesType.Triton };
                    MisterSilverSkull.NaturalAllies.AddRange(NaturalAlliedSkull);
                    List<SpeciesType> NaturalenemiedSkul = new List<SpeciesType> { SpeciesType.Crocodile };
                    MisterSilverSkull.NaturalEnemies = NaturalenemiedSkul;

                    MisterSilverSkull.Foe = false;

                    person = MisterSilverSkull;//gameObject.AddComponent<Persona>();
                    person.Life = 70;

                    person.maxShield = new WarriorTemplate().shield;
                    break;
                case MasterCharacterList.Mister_Mantis:
                    WarriorTemplate MisterMantis = gameObject.AddComponent<WarriorTemplate>();
                    MisterMantis.CharacterName = "Mister_Mantis";
                    MisterMantis.CharacterDescription = "No youre thinking of my cousin, Mantis. He is the REAL dragon warrior. Obviously....";
                    MisterMantis.CharacterSpecies = SpeciesType.Insect;
                    MisterMantis.PersonName = Everyone;


                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedMAntis = new List<SpeciesType> { SpeciesType.Frog, SpeciesType.Fish };
                    MisterMantis.NaturalAllies = NaturalAlliedMAntis;
                    List<SpeciesType> NaturalenemiedMAntis = new List<SpeciesType> { SpeciesType.Crocodile, SpeciesType.Lion };
                    MisterMantis.NaturalEnemies = NaturalenemiedMAntis;

                    MisterMantis.Foe = false;

                    person = MisterMantis;//gameObject.AddComponent<Persona>();
                    person.Life = 70;

                    person.maxShield = new WarriorTemplate().shield;
                    break;
                case MasterCharacterList.Mister_Hippo:
                    WarriorTemplate MisterHippo = gameObject.AddComponent<WarriorTemplate>();
                    MisterHippo.CharacterName = "Mister_Hippo";
                    MisterHippo.CharacterDescription = "Is it hot in here? I some space. *huffing* No stop seriously, give me room. *Huffing intensifies* I'm not kidding get aWAY FR";
                    MisterHippo.CharacterSpecies = SpeciesType.Hippo;
                    MisterHippo.PersonName = Everyone;

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedHippo = new List<SpeciesType> { SpeciesType.Frog, SpeciesType.Fish };
                    MisterHippo.NaturalAllies = NaturalAlliedHippo;
                    List<SpeciesType> NaturalenemiedHippo = new List<SpeciesType> { SpeciesType.Crocodile, SpeciesType.Lion };
                    MisterHippo.NaturalEnemies = NaturalenemiedHippo;

                    MisterHippo.Foe = false;

                    person = MisterHippo;//gameObject.AddComponent<Persona>();
                    person.Life = 70;

                    person.maxShield = new WarriorTemplate().shield;
                    break;
                case MasterCharacterList.HammerHead:
                    WarriorTemplate HammerHead = gameObject.AddComponent<WarriorTemplate>();
                    HammerHead.CharacterName = "HammerHead";
                    HammerHead.CharacterDescription = "Look me in the eye and say that again";
                    HammerHead.CharacterSpecies = SpeciesType.Fish;
                    HammerHead.EnemyType = enemyType.Boss;
                    HammerHead.PersonName = Everyone;

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedHammerHead = new List<SpeciesType> { SpeciesType.Frog, SpeciesType.Fish };
                    HammerHead.NaturalAllies = NaturalAlliedHammerHead;
                    List<SpeciesType> NaturalenemiedHammerHead = new List<SpeciesType> { SpeciesType.Crocodile, SpeciesType.Lion };
                    HammerHead.NaturalEnemies = NaturalenemiedHammerHead;

                    HammerHead.Foe = true;

                    person = HammerHead;//gameObject.AddComponent<Persona>();                
                    person.Life = 70;

                    person.maxShield = new WarriorTemplate().shield;
                    break;
                case MasterCharacterList.GreatWhite:
                    WarriorTemplate GreatWhite = gameObject.AddComponent<WarriorTemplate>();
                    GreatWhite.CharacterName = "GreatWhite";
                    GreatWhite.CharacterDescription = "Oh my god, my teeth are killing me";
                    GreatWhite.CharacterSpecies = SpeciesType.Fish;
                    GreatWhite.EnemyType = enemyType.Boss;
                    GreatWhite.PersonName = Everyone;

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedGreatWhite = new List<SpeciesType> { SpeciesType.Frog, SpeciesType.Fish };
                    GreatWhite.NaturalAllies = NaturalAlliedGreatWhite;
                    List<SpeciesType> NaturalenemiedGreatWhite = new List<SpeciesType> { SpeciesType.Crocodile, SpeciesType.Lion };
                    GreatWhite.NaturalEnemies = NaturalAlliedGreatWhite;

                    GreatWhite.Foe = true;

                    person = GreatWhite;//gameObject.AddComponent<Persona>();
                    person.Life = 70;

                    person.maxShield = new WarriorTemplate().shield;
                    break;
                case MasterCharacterList.SpiderCrustacean:
                    WarriorTemplate SpiderCrustacean = gameObject.AddComponent<WarriorTemplate>();
                    SpiderCrustacean.CharacterName = "SpiderCrustacean";
                    SpiderCrustacean.CharacterDescription = "......";
                    SpiderCrustacean.CharacterSpecies = SpeciesType.Fish;
                    SpiderCrustacean.EnemyType = enemyType.Boss;
                    SpiderCrustacean.PersonName = Everyone;

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedSpiderCrustacean = new List<SpeciesType> { SpeciesType.Frog, SpeciesType.Fish };
                    SpiderCrustacean.NaturalAllies = NaturalAlliedSpiderCrustacean;
                    List<SpeciesType> NaturalenemiedSpiderCrustacean = new List<SpeciesType> { SpeciesType.Crocodile, SpeciesType.Lion };
                    SpiderCrustacean.NaturalEnemies = NaturalenemiedSpiderCrustacean;

                    SpiderCrustacean.Foe = true;

                    person = SpiderCrustacean;//gameObject.AddComponent<Persona>();
                    person.Life = 70;

                    person.maxShield = new WarriorTemplate().shield;
                    break;
                case MasterCharacterList.NecroBoar:
                    WarriorTemplate NecroBoar = gameObject.AddComponent<WarriorTemplate>();
                    NecroBoar.CharacterName = "NecroBoar";
                    NecroBoar.CharacterDescription = "Call me atheist, but I dont believe in the Last Supper";
                    NecroBoar.CharacterSpecies = SpeciesType.Boar;
                    NecroBoar.EnemyType = enemyType.Boss;
                    NecroBoar.PersonName = Everyone;

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedNecroBoar = new List<SpeciesType> { SpeciesType.Frog, SpeciesType.Fish };
                    NecroBoar.NaturalAllies = NaturalAlliedNecroBoar;
                    List<SpeciesType> NaturalenemiedNecroBoar = new List<SpeciesType> { SpeciesType.Crocodile, SpeciesType.Lion };
                    NecroBoar.NaturalEnemies = NaturalenemiedNecroBoar;

                    NecroBoar.Foe = true;

                    person = NecroBoar;//gameObject.AddComponent<Persona>();
                    person.Life = 70;

                    person.maxShield = new WarriorTemplate().shield;
                    break;
                case MasterCharacterList.ElderStag:
                    MageTemplate ElderStag = gameObject.AddComponent<MageTemplate>();
                    ElderStag.CharacterName = "ElderStag";
                    ElderStag.CharacterDescription = "My Eternal core spews cold hatred and pure darkness......(just like mothers words *sadness*)";
                    ElderStag.CharacterSpecies = SpeciesType.Deer;
                    ElderStag.EnemyType = enemyType.Boss;
                    ElderStag.PersonName = Everyone;

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedElderStag = new List<SpeciesType> { SpeciesType.Frog, SpeciesType.Fish };
                    ElderStag.NaturalAllies = NaturalAlliedElderStag;
                    List<SpeciesType> NaturalenemiedElderStag = new List<SpeciesType> { SpeciesType.Crocodile, SpeciesType.Lion };
                    ElderStag.NaturalEnemies = NaturalenemiedElderStag;

                    ElderStag.Foe = true;

                    person = ElderStag;//gameObject.AddComponent<Persona>();
                    person.Life = 55;

                    person.maxShield = new MageTemplate().shield;

                    break;
                case MasterCharacterList.DevilBird:
                    MageTemplate DevilBird = gameObject.AddComponent<MageTemplate>();
                    DevilBird.CharacterName = "DevilBird";
                    DevilBird.CharacterDescription = "SQUUACCK!";
                    DevilBird.CharacterSpecies = SpeciesType.Bird;
                    DevilBird.EnemyType = enemyType.Boss;
                    DevilBird.PersonName = Everyone;

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedDevilBird = new List<SpeciesType> { SpeciesType.Frog, SpeciesType.Fish };
                    DevilBird.NaturalAllies = NaturalAlliedDevilBird;
                    List<SpeciesType> NaturalenemiedDevilBird = new List<SpeciesType> { SpeciesType.Crocodile, SpeciesType.Lion };
                    DevilBird.NaturalEnemies = NaturalenemiedDevilBird;

                    DevilBird.Foe = true;

                    person = DevilBird;//gameObject.AddComponent<Persona>();
                    person.Life = 55;

                    person.maxShield = new MageTemplate().shield;
                    break;
                case MasterCharacterList.DragonSloth:
                    ControllerTemplate DragonSloth = gameObject.AddComponent<ControllerTemplate>();
                    DragonSloth.CharacterName = "DragonSloth";
                    DragonSloth.CharacterDescription = "W..a..i..t....u....p..y...o...u....g....u";
                    DragonSloth.CharacterSpecies = SpeciesType.Sloth;
                    DragonSloth.EnemyType = enemyType.Boss;
                    DragonSloth.PersonName = Everyone;

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedDragonSloth = new List<SpeciesType> { SpeciesType.Frog, SpeciesType.Fish };
                    DragonSloth.NaturalAllies = NaturalAlliedDragonSloth;
                    List<SpeciesType> NaturalenemiedDragonSloth = new List<SpeciesType> { SpeciesType.Crocodile, SpeciesType.Lion };
                    DragonSloth.NaturalEnemies = NaturalenemiedDragonSloth;

                    DragonSloth.Foe = true;

                    person = DragonSloth;//gameObject.AddComponent<Persona>();
                    person.Life = 68;

                    person.maxShield = new ControllerTemplate().shield;
                    break;
                default:
                    break;
            }
            Invoke("SetAlliesEnemies", .1f);

            ApplySavedStats(person);

            //new SerializedObjectManager().SaveData(person, new SerializedObjectManager().paths[2] + person.CharacterName);

            person.characterBehaviour = this;
        }
        public void OnMouseDown()
        {

            if (GameManager.Instance.cardSelected)
            {
                GameManager.Instance.selectedCard.OnAction(person);

                GameManager.Instance.selectedCard = null;
                GameManager.Instance.cardSelected = false;
                
                //Remove Outlines
            }                
            //On Click On Player
        }
        bool startAnimTimer;
        float timer;
        public void AttackAnimation()
        {
            Goto = transform.position.x < 0 ? Goto + attackOffset: Goto - attackOffset;
            startAnimTimer = true;
        }
        public void SetAsActiveCharacter()
        {
            turnUsed = false;

            //Set Indicator
            for (int i = 0; i < GameManager.Instance.playerCharacters.Count; i++)
            {
                GameObject x = GameManager.Instance.playerCharacters[i].GetComponentInChildren<CharacterBehaviour>().gameObject;
                x.transform.Find("Indicator").gameObject.SetActive(false);
            }
            for (int i = 0; i < GameManager.Instance.enemyCharacters.Count; i++)
            {
                GameObject x = GameManager.Instance.enemyCharacters[i].GetComponentInChildren<CharacterBehaviour>().gameObject;
                x.transform.Find("Indicator").gameObject.SetActive(false);
            }

            transform.Find("Indicator").gameObject.SetActive(true);

            if (!turnUsed && !CardDescriptionManager.Instance.cardDetailsView.activeSelf)
                if (species != SpeciesType.Enemy)
                {
                    SpeciesType[] array = (SpeciesType[])(SpeciesType.GetValues(typeof(SpeciesType)));
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] == species)
                            Deck.sprite = DeckPopulate.Instance.cardsBack[i];

                        if (array[i] == species)
                            Deck.gameObject.GetComponent<SpeciesHolder>().type = array[i];
                    }

                    DeckPopulate.Instance.HideDeck();

                    GameManager.Instance.activeCharacter = this;
                }

            if (species == SpeciesType.Enemy)
                GameManager.Instance.activeEnemy = this;

            if (species == SpeciesType.Enemy)
                StartCoroutine(waitToStrike());
        }
        public void Update()
        {
            transform.position = Vector3.Lerp(Goto, transform.position, .125f);

            if (timer > .33f)
            {
                Goto = origin;

                timer = 0;
                startAnimTimer = false;
            }

            Image healthSlider = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();

            Image shieldSlider = transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>();

            float health = 0;
            float shield = 0;

            health = (float)(person.Health) / (float)(person.Life);

            shield = (float)(person.shield) / (float)(person.maxShield);

            healthSlider.fillAmount = health;
            shieldSlider.fillAmount = shield;

            if (startAnimTimer)
                timer += Time.deltaTime;
        }  
        public void HoverAction()
        {
            //Highlight
        }
        public Persona GetDefaultValues()
        {
            Persona persona = new Persona();
            //object x = new SerializedObjectManager().RetrieveData(new SerializedObjectManager().paths[2] + person.CharacterName);

            //persona = (Persona)x;

            return persona;
        }
        public void SetColor(Color color)
        {
            GetComponent<SpriteRenderer>().color = color;
        }
        void SetAlliesEnemies()
        {
            Persona objects = person;
            if(species != SpeciesType.Enemy)
            {
                for (int i = 0; i < GameManager.Instance.playerCharacters.Count; i++)
                {
                    if (GameManager.Instance.playerCharacters[i].GetComponentInChildren<CharacterBehaviour>() != this)
                        objects.Allies.Add(GameManager.Instance.playerCharacters[i].GetComponentInChildren<CharacterBehaviour>().person);
                }
                for (int i = 0; i < GameManager.Instance.enemyCharacters.Count; i++)
                {
                    objects.Enemies.Add(GameManager.Instance.enemyCharacters[i].GetComponentInChildren<CharacterBehaviour>().person);
                }

                return;
            }

            for (int i = 0; i < GameManager.Instance.playerCharacters.Count; i++)
            {
                objects.Enemies.Add(GameManager.Instance.playerCharacters[i].GetComponentInChildren<CharacterBehaviour>().person);
            }
            for (int i = 0; i < GameManager.Instance.enemyCharacters.Count; i++)
            {
                if (GameManager.Instance.enemyCharacters[i].GetComponentInChildren<CharacterBehaviour>() != this)
                    objects.Allies.Add(GameManager.Instance.enemyCharacters[i].GetComponentInChildren<CharacterBehaviour>().person);
            }

            enemies.AddRange(objects.Enemies);
        }
        void ApplySavedStats(Persona character)
        {
            SerializedObjectManager serializedObjectManager = new SerializedObjectManager();
            Persona savedPersona = (Persona)serializedObjectManager.RetrieveData(serializedObjectManager.paths[0] + person.CharacterName);           

            if(savedPersona != null)
            {
                character = savedPersona;
                character.Health = character.Life;//In case it saves a characters data with below max health
            }            
        }
        #region Enemy Code
        IEnumerator waitToStrike()
        {
            yield return new WaitForSeconds(2f);
            EnemyAttack();
        }
        public void EnemyAttack()
        {
            Bosses bossScript = GetComponent<Bosses>();

            List<Persona> opps = new List<Persona>();
            for (int i = 0; i < GameManager.Instance.playerCharacters.Count; i++)
            {
                opps.Add(GameManager.Instance.playerCharacters[i].GetComponentInChildren<CharacterBehaviour>().person);
            }
            
            bossScript.SetBosses(person, opps);
            bossScript.Decision();

            turnUsed = true;
            GameManager.Instance.CheckRoundDone();
        }

        #endregion
        public void Flee(List<object> Targets)
        {
            //Comment
            for (int i = 0; i < GameManager.Instance.playerCharacters.Count; i++)
            {
                if (GameManager.Instance.playerCharacters[i].name == gameObject.transform.root.gameObject.name)
                    GameManager.Instance.playerCharacters.Remove(GameManager.Instance.playerCharacters[i]);//Abel needs to update all lists that make use of this

                if (GameManager.Instance.playerCharacters[i].name == gameObject.transform.root.gameObject.name)
                    Goto = new Vector3(-10f, transform.position.y, transform.position.z);

                Destroy(transform.root.gameObject, 3);
            }

            for (int i = 0; i < GameManager.Instance.enemyCharacters.Count; i++)
            {
                if (GameManager.Instance.enemyCharacters[i].name == gameObject.transform.root.gameObject.name)
                    GameManager.Instance.enemyCharacters.Remove(GameManager.Instance.enemyCharacters[i]);//Abel needs to update all lists that make use of this

                if (GameManager.Instance.enemyCharacters[i].name == gameObject.transform.root.gameObject.name)
                    Goto = new Vector3(10f, transform.position.y, transform.position.z);

                Destroy(transform.root.gameObject, 3);
            }

            GameManager.Instance.CheckBattleOver();
        }
        public bool extraTurn;
        public int consecutiveTurns;
        public void DrawExtraCard(int extraTurns)
        {
            extraTurn = true;
            consecutiveTurns = extraTurns;
        }        
    }
}
