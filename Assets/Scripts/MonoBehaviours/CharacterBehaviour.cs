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

namespace Assets.Scripts.MonoBehaviours
{
    public class CharacterBehaviour : MonoBehaviour
    {
        public Vector3[] positions = { new Vector3(-7.0f, -1.6f, 1.0f), new Vector3(-5.0f, -1.6f, 1.0f), new Vector3(-3.0f, -1.6f, 1.0f), new Vector3(-1.0f, -1.6f, 1.0f) };
        public GameObject parent;
        public Vector3 Goto;
        public SpeciesType species; //dont like this ode at all, but he put us too deep to manage
        public MasterCharacterList Everyone;
        public Image Deck;
        public bool turnUsed;

        //public Persona person;
        public Persona person;

        void Awake()
        {
            parent = transform.parent.gameObject;
            Goto = transform.position;
            Deck = GameObject.Find("Deck").GetComponent<Image>();

            /*for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = GameManager.Instance.playerCharacters[i].transform.GetChild(0).position;
            }*/

            /*GameManager.Instance = GameObject.Find("GameManager").GetComponent<GameManager>();
            if (species != SpeciesType.Enemy)
            {
                GameManager.Instance.playerCharacters.Add(gameObject);
            }
            else
            {
                GameManager.Instance.enemyCharacters.Add(gameObject);
            }*/

        }
        private void Start()
        {            
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

                    MisterGlub.Allies.AddRange(GameManager.Instance.playerCharacters);
                    MisterGlub.Enemies.AddRange(GameManager.Instance.enemyCharacters);

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedGlub = new List<SpeciesType> { SpeciesType.Frog, SpeciesType.Fish };
                    MisterGlub.NaturalAllies = NaturalAlliedGlub;
                    List<SpeciesType> NaturalenemiedGlub = new List<SpeciesType> { SpeciesType.Crocodile, SpeciesType.Lion };
                    MisterGlub.NaturalEnemies = NaturalenemiedGlub;

                    MisterGlub.Foe = false;

                    person = (Persona)MisterGlub;//gameObject.AddComponent<Persona>();
                    break;
                case MasterCharacterList.Mister_Froggo:
                    MageTemplate MisterFroggo = gameObject.AddComponent<MageTemplate>();
                    MisterFroggo.CharacterName = "Mister_Froggo";
                    MisterFroggo.CharacterDescription = "Ribbit, ribbit, Keroo, Ribbit";
                    MisterFroggo.CharacterSpecies = SpeciesType.Frog;

                    MisterFroggo.Allies.AddRange(GameManager.Instance.playerCharacters);
                    MisterFroggo.Enemies.AddRange(GameManager.Instance.enemyCharacters);

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedFroggo = new List<SpeciesType> { SpeciesType.Frog, SpeciesType.Fish };
                    MisterFroggo.NaturalAllies = NaturalAlliedFroggo;
                    List<SpeciesType> NaturalenemiedFroggo = new List<SpeciesType> { SpeciesType.Crocodile, SpeciesType.Salamander };
                    MisterFroggo.NaturalEnemies = NaturalenemiedFroggo;

                    MisterFroggo.Foe = false;

                    person = MisterFroggo;//gameObject.AddComponent<Persona>();
                    break;
                case MasterCharacterList.Mister_Salaboned:
                    TankWarriorTemplate MisterSalaboned = gameObject.AddComponent<TankWarriorTemplate>();
                    MisterSalaboned.CharacterName = "Mister_Salaboned";
                    MisterSalaboned.CharacterDescription = "A man plagued by demonic shadows. After discovering forbiden gray magic, he uses his skill to reach his deepest desire, no matter the cost";
                    MisterSalaboned.CharacterSpecies = SpeciesType.Salamander;

                    MisterSalaboned.Allies.AddRange(GameManager.Instance.playerCharacters);
                    MisterSalaboned.Enemies.AddRange(GameManager.Instance.enemyCharacters);

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedSala = new List<SpeciesType> { SpeciesType.Triton };
                    MisterSalaboned.NaturalAllies = NaturalAlliedSala;
                    List<SpeciesType> NaturalenemiedSala = new List<SpeciesType> { SpeciesType.Lion };
                    MisterSalaboned.NaturalEnemies = NaturalenemiedSala;

                    MisterSalaboned.Foe = false;

                    person = MisterSalaboned;//gameObject.AddComponent<Persona>();
                    break;
                case MasterCharacterList.Mister_Lizzacorn:
                    WarriorTemplate MisterLizzacorn = gameObject.AddComponent<WarriorTemplate>();
                    MisterLizzacorn.CharacterName = "Mister_Lizzacorn";
                    MisterLizzacorn.CharacterDescription = "I'm not being defensive, you are!";
                    MisterLizzacorn.CharacterSpecies = SpeciesType.Triton;

                    MisterLizzacorn.Allies.AddRange(GameManager.Instance.playerCharacters);
                    MisterLizzacorn.Enemies.AddRange(GameManager.Instance.enemyCharacters);

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedLizza = new List<SpeciesType> { SpeciesType.Salamander, SpeciesType.Triton };
                    MisterLizzacorn.NaturalAllies = NaturalAlliedLizza;
                    List<SpeciesType> NaturalenemiedLizza = new List<SpeciesType> { SpeciesType.Crocodile };
                    MisterLizzacorn.NaturalEnemies = NaturalenemiedLizza;

                    MisterLizzacorn.Foe = false;

                    person = MisterLizzacorn;//gameObject.AddComponent<Persona>();
                    break;
                case MasterCharacterList.Mister_Liodin:
                    WarriorTemplate MisterLiodin = gameObject.AddComponent<WarriorTemplate>();
                    MisterLiodin.CharacterName = "Mister_Liodin";
                    MisterLiodin.CharacterDescription = "Yes, thats correct. Everything the Light touches";
                    MisterLiodin.CharacterSpecies = SpeciesType.Lion;

                    MisterLiodin.Allies.AddRange(GameManager.Instance.playerCharacters);
                    MisterLiodin.Enemies.AddRange(GameManager.Instance.enemyCharacters);

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedLiodin = new List<SpeciesType> { SpeciesType.Lion, SpeciesType.Salamander };
                    MisterLiodin.NaturalAllies = NaturalAlliedLiodin;
                    List<SpeciesType> NaturalenemiedLiodin = new List<SpeciesType> { SpeciesType.Triton, SpeciesType.Crocodile };
                    MisterLiodin.NaturalEnemies = NaturalenemiedLiodin;

                    MisterLiodin.Foe = false;

                    person = MisterLiodin;//gameObject.AddComponent<Persona>();
                    break;
                case MasterCharacterList.Mister_Lacrox:
                    WarriorTemplate MisterLacrox = gameObject.AddComponent<WarriorTemplate>();
                    MisterLacrox.CharacterName = "Mister_Lacrox";
                    MisterLacrox.CharacterDescription = "Nani?!Kotowaru!";
                    MisterLacrox.CharacterSpecies = SpeciesType.Crocodile;

                    MisterLacrox.Allies.AddRange(GameManager.Instance.playerCharacters);
                    MisterLacrox.Enemies.AddRange(GameManager.Instance.enemyCharacters);

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedLacrox = new List<SpeciesType> { };
                    MisterLacrox.NaturalAllies = NaturalAlliedLacrox;
                    List<SpeciesType> NaturalenemiedLAcrox = new List<SpeciesType> { SpeciesType.Salamander, SpeciesType.Lion };
                    MisterLacrox.NaturalEnemies = NaturalenemiedLAcrox;

                    MisterLacrox.Foe = false;

                    person = MisterLacrox;//gameObject.AddComponent<Persona>();
                    break;
                case MasterCharacterList.Mister_Birbarcher:
                    RangeTemplate MisterBirbarcher = gameObject.AddComponent<RangeTemplate>();
                    MisterBirbarcher.CharacterName = "Mister_Birbarcher";
                    MisterBirbarcher.CharacterDescription = "Has anyone seen any female elves here? Nevermind.....";
                    MisterBirbarcher.CharacterSpecies = SpeciesType.Fish;

                    MisterBirbarcher.Allies.AddRange(GameManager.Instance.playerCharacters);
                    MisterBirbarcher.Enemies.AddRange(GameManager.Instance.enemyCharacters);

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedBircher = new List<SpeciesType> { SpeciesType.Frog, SpeciesType.Fish };
                    MisterBirbarcher.NaturalAllies = NaturalAlliedBircher;
                    List<SpeciesType> NaturalenemiedBircher = new List<SpeciesType> { SpeciesType.Crocodile, SpeciesType.Lion };
                    MisterBirbarcher.NaturalEnemies = NaturalenemiedBircher;

                    MisterBirbarcher.Foe = false;

                    person = MisterBirbarcher;//gameObject.AddComponent<Persona>();
                    break;
                case MasterCharacterList.Mister_PirateParrot:
                    ControllerTemplate MisterPirateParrot = gameObject.AddComponent<ControllerTemplate>();
                    MisterPirateParrot.CharacterName = "Mister_PirateParrot";
                    MisterPirateParrot.CharacterDescription = "Say cracker one more time, I dare ya.....";
                    MisterPirateParrot.CharacterSpecies = SpeciesType.Parrot;

                    MisterPirateParrot.Allies.AddRange(GameManager.Instance.playerCharacters);
                    MisterPirateParrot.Enemies.AddRange(GameManager.Instance.enemyCharacters);

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedPirate = new List<SpeciesType> { SpeciesType.Frog, SpeciesType.Fish };
                    MisterPirateParrot.NaturalAllies = NaturalAlliedPirate;
                    List<SpeciesType> NaturalenemiedPirate = new List<SpeciesType> { SpeciesType.Crocodile, SpeciesType.Lion };
                    MisterPirateParrot.NaturalEnemies = NaturalenemiedPirate;

                    MisterPirateParrot.Foe = false;

                    person = MisterPirateParrot;//gameObject.AddComponent<Persona>();
                    break;
                case MasterCharacterList.Mister_SilverSkull:
                    WarriorTemplate MisterSilverSkull = gameObject.AddComponent<WarriorTemplate>();
                    MisterSilverSkull.CharacterName = "Mister_SilverSkull";
                    MisterSilverSkull.CharacterDescription = "Oh where am I from? Earth...";
                    MisterSilverSkull.CharacterSpecies = SpeciesType.Triton;

                    MisterSilverSkull.Allies.AddRange(GameManager.Instance.playerCharacters);
                    MisterSilverSkull.Enemies.AddRange(GameManager.Instance.enemyCharacters);

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedSkull = new List<SpeciesType> { SpeciesType.Salamander, SpeciesType.Triton };
                    MisterSilverSkull.NaturalAllies.AddRange(NaturalAlliedSkull);
                    List<SpeciesType> NaturalenemiedSkul = new List<SpeciesType> { SpeciesType.Crocodile };
                    MisterSilverSkull.NaturalEnemies = NaturalenemiedSkul;

                    MisterSilverSkull.Foe = false;

                    person = MisterSilverSkull;//gameObject.AddComponent<Persona>();
                    break;
                case MasterCharacterList.Mister_Mantis:
                    WarriorTemplate MisterMantis = gameObject.AddComponent<WarriorTemplate>();
                    MisterMantis.CharacterName = "Mister_Mantis";
                    MisterMantis.CharacterDescription = "No youre thinking of my cousin, Mantis. He is the REAL dragon warrior. Obviously....";
                    MisterMantis.CharacterSpecies = SpeciesType.Insect;

                    MisterMantis.Allies.AddRange(GameManager.Instance.playerCharacters);
                    MisterMantis.Enemies.AddRange(GameManager.Instance.enemyCharacters);

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedMAntis = new List<SpeciesType> { SpeciesType.Frog, SpeciesType.Fish };
                    MisterMantis.NaturalAllies = NaturalAlliedMAntis;
                    List<SpeciesType> NaturalenemiedMAntis = new List<SpeciesType> { SpeciesType.Crocodile, SpeciesType.Lion };
                    MisterMantis.NaturalEnemies = NaturalenemiedMAntis;

                    MisterMantis.Foe = false;

                    person = MisterMantis;//gameObject.AddComponent<Persona>();
                    break;
                case MasterCharacterList.Mister_Hippo:
                    WarriorTemplate MisterHippo = gameObject.AddComponent<WarriorTemplate>();
                    MisterHippo.CharacterName = "Mister_Hippo";
                    MisterHippo.CharacterDescription = "Is it hot in here? I some space. *huffing* No stop seriously, give me room. *Huffing intensifies* I'm not kidding get aWAY FR";
                    MisterHippo.CharacterSpecies = SpeciesType.Hippo;

                    MisterHippo.Allies.AddRange(GameManager.Instance.playerCharacters);
                    MisterHippo.Enemies.AddRange(GameManager.Instance.enemyCharacters);

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedHippo = new List<SpeciesType> { SpeciesType.Frog, SpeciesType.Fish };
                    MisterHippo.NaturalAllies = NaturalAlliedHippo;
                    List<SpeciesType> NaturalenemiedHippo = new List<SpeciesType> { SpeciesType.Crocodile, SpeciesType.Lion };
                    MisterHippo.NaturalEnemies = NaturalenemiedHippo;

                    MisterHippo.Foe = false;

                    person = MisterHippo;//gameObject.AddComponent<Persona>();
                    break;
                case MasterCharacterList.HammerHead:
                    WarriorTemplate HammerHead = gameObject.AddComponent<WarriorTemplate>();
                    HammerHead.CharacterName = "HammerHead";
                    HammerHead.CharacterDescription = "Look me in the eye and say that again";
                    HammerHead.CharacterSpecies = SpeciesType.Fish;

                    HammerHead.Allies.AddRange(GameManager.Instance.enemyCharacters);
                    HammerHead.Enemies.AddRange(GameManager.Instance.playerCharacters);

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedHammerHead = new List<SpeciesType> { SpeciesType.Frog, SpeciesType.Fish };
                    HammerHead.NaturalAllies = NaturalAlliedHammerHead;
                    List<SpeciesType> NaturalenemiedHammerHead = new List<SpeciesType> { SpeciesType.Crocodile, SpeciesType.Lion };
                    HammerHead.NaturalEnemies = NaturalenemiedHammerHead;

                    HammerHead.Foe = true;

                    person = HammerHead;//gameObject.AddComponent<Persona>();
                    break;
                case MasterCharacterList.GreatWhite:
                    WarriorTemplate GreatWhite = gameObject.AddComponent<WarriorTemplate>();
                    GreatWhite.CharacterName = "GreatWhite";
                    GreatWhite.CharacterDescription = "Oh my god, my teeth are killing me";
                    GreatWhite.CharacterSpecies = SpeciesType.Fish;

                    GreatWhite.Allies.AddRange(GameManager.Instance.enemyCharacters);
                    GreatWhite.Enemies.AddRange(GameManager.Instance.playerCharacters);

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedGreatWhite = new List<SpeciesType> { SpeciesType.Frog, SpeciesType.Fish };
                    GreatWhite.NaturalAllies = NaturalAlliedGreatWhite;
                    List<SpeciesType> NaturalenemiedGreatWhite = new List<SpeciesType> { SpeciesType.Crocodile, SpeciesType.Lion };
                    GreatWhite.NaturalEnemies = NaturalAlliedGreatWhite;

                    GreatWhite.Foe = true;

                    person = GreatWhite;//gameObject.AddComponent<Persona>();
                    break;
                case MasterCharacterList.SpiderCrustacean:
                    WarriorTemplate SpiderCrustacean = gameObject.AddComponent<WarriorTemplate>();
                    SpiderCrustacean.CharacterName = "SpiderCrustacean";
                    SpiderCrustacean.CharacterDescription = "......";
                    SpiderCrustacean.CharacterSpecies = SpeciesType.Fish;

                    SpiderCrustacean.Allies.AddRange(GameManager.Instance.enemyCharacters);
                    SpiderCrustacean.Enemies.AddRange(GameManager.Instance.playerCharacters);

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedSpiderCrustacean = new List<SpeciesType> { SpeciesType.Frog, SpeciesType.Fish };
                    SpiderCrustacean.NaturalAllies = NaturalAlliedSpiderCrustacean;
                    List<SpeciesType> NaturalenemiedSpiderCrustacean = new List<SpeciesType> { SpeciesType.Crocodile, SpeciesType.Lion };
                    SpiderCrustacean.NaturalEnemies = NaturalenemiedSpiderCrustacean;

                    SpiderCrustacean.Foe = true;

                    person = SpiderCrustacean;//gameObject.AddComponent<Persona>();
                    break;
                case MasterCharacterList.NecroBoar:
                    WarriorTemplate NecroBoar = gameObject.AddComponent<WarriorTemplate>();
                    NecroBoar.CharacterName = "NecroBoar";
                    NecroBoar.CharacterDescription = "Call me atheist, but I dont believe in the Last Supper";
                    NecroBoar.CharacterSpecies = SpeciesType.Boar;

                    NecroBoar.Allies.AddRange(GameManager.Instance.enemyCharacters);
                    NecroBoar.Enemies.AddRange(GameManager.Instance.playerCharacters);

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedNecroBoar = new List<SpeciesType> { SpeciesType.Frog, SpeciesType.Fish };
                    NecroBoar.NaturalAllies = NaturalAlliedNecroBoar;
                    List<SpeciesType> NaturalenemiedNecroBoar = new List<SpeciesType> { SpeciesType.Crocodile, SpeciesType.Lion };
                    NecroBoar.NaturalEnemies = NaturalenemiedNecroBoar;

                    NecroBoar.Foe = true;

                    person = NecroBoar;//gameObject.AddComponent<Persona>();
                    break;
                case MasterCharacterList.ElderStag:
                    MageTemplate ElderStag = gameObject.AddComponent<MageTemplate>();
                    ElderStag.CharacterName = "ElderStag";
                    ElderStag.CharacterDescription = "My Eternal core spews cold hatred and pure darkness......(just like mothers words *sadness*)";
                    ElderStag.CharacterSpecies = SpeciesType.Deer;

                    ElderStag.Allies.AddRange(GameManager.Instance.enemyCharacters);
                    ElderStag.Enemies.AddRange(GameManager.Instance.playerCharacters);

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedElderStag = new List<SpeciesType> { SpeciesType.Frog, SpeciesType.Fish };
                    ElderStag.NaturalAllies = NaturalAlliedElderStag;
                    List<SpeciesType> NaturalenemiedElderStag = new List<SpeciesType> { SpeciesType.Crocodile, SpeciesType.Lion };
                    ElderStag.NaturalEnemies = NaturalenemiedElderStag;

                    ElderStag.Foe = true;

                    person = ElderStag;//gameObject.AddComponent<Persona>();
                    break;
                case MasterCharacterList.DevilBird:
                    MageTemplate DevilBird = gameObject.AddComponent<MageTemplate>();
                    DevilBird.CharacterName = "DevilBird";
                    DevilBird.CharacterDescription = "SQUUACCK!";
                    DevilBird.CharacterSpecies = SpeciesType.Bird;

                    DevilBird.Allies.AddRange(GameManager.Instance.enemyCharacters);
                    DevilBird.Enemies.AddRange(GameManager.Instance.playerCharacters);

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedDevilBird = new List<SpeciesType> { SpeciesType.Frog, SpeciesType.Fish };
                    DevilBird.NaturalAllies = NaturalAlliedDevilBird;
                    List<SpeciesType> NaturalenemiedDevilBird = new List<SpeciesType> { SpeciesType.Crocodile, SpeciesType.Lion };
                    DevilBird.NaturalEnemies = NaturalenemiedDevilBird;

                    DevilBird.Foe = true;

                    person = DevilBird;//gameObject.AddComponent<Persona>();
                    break;
                case MasterCharacterList.DragonSloth:
                    ControllerTemplate DragonSloth = gameObject.AddComponent<ControllerTemplate>();
                    DragonSloth.CharacterName = "DragonSloth";
                    DragonSloth.CharacterDescription = "W..a..i..t....u....p..y...o...u....g....u";
                    DragonSloth.CharacterSpecies = SpeciesType.Sloth;

                    DragonSloth.Allies.AddRange(GameManager.Instance.enemyCharacters);
                    DragonSloth.Enemies.AddRange(GameManager.Instance.playerCharacters);

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAlliedDragonSloth = new List<SpeciesType> { SpeciesType.Frog, SpeciesType.Fish };
                    DragonSloth.NaturalAllies = NaturalAlliedDragonSloth;
                    List<SpeciesType> NaturalenemiedDragonSloth = new List<SpeciesType> { SpeciesType.Crocodile, SpeciesType.Lion };
                    DragonSloth.NaturalEnemies = NaturalenemiedDragonSloth;

                    DragonSloth.Foe = true;

                    person = DragonSloth;//gameObject.AddComponent<Persona>();
                    break;
                default:
                    break;
            }
            person.characterBehaviour = this;
        }
        public void OnMouseDown()
        {
            if (!turnUsed && !CardDescriptionManager.Instance.cardDetailsView.activeSelf)
                if (species != SpeciesType.Enemy)
                {
                    Transform _transform = parent.transform.parent.transform;

                    for (int i = 0; i < _transform.childCount; i++)
                    {
                        if (_transform.GetChild(i).transform.GetChild(0).position.x == positions[3].x)
                        {
                            _transform.GetChild(i).transform.GetChild(0).GetComponent<CharacterBehaviour>().Goto = transform.position;
                            Goto = positions[3];
                        }
                    }

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
        }
        public void Update()
        {
            transform.position = Vector3.Lerp(Goto, transform.position, .125f);

            Image healthSlider = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();

            float health = 0;

            if (species != SpeciesType.Enemy)
                health = (float)(person.Health) / (float)(new MageTemplate().Health);

            if (species == SpeciesType.Enemy)
                health = (float)(person.Health) / (float)(new MageTemplate().Health);

            healthSlider.fillAmount = health;            
        }  
        public void HoverAction()
        {
            //Highlight
        }
        public void SetColor(Color color)
        {
            GetComponent<SpriteRenderer>().color = color;
        }

        #region Enemy Code
        public void EnemyAttack()
        {
            EnemyActions Villiany = new EnemyActions();// since they dont use cards here is where their actions will be found

            /*
             Ai logic would be put here.

            It will call Villiany.PassiveEnemyAbility(Villian); first
            then depending on health of enemies or aallies, health of the boss or all that good good it will fire Villiany.Attack1(), 2 or 3. Whatever makes sense
             */

            /*CardBehaviour cardBehaviour = new CardBehaviour();

            cardName[] array = (cardName[])(cardName.GetValues(typeof(cardName)));
            cardBehaviour.cardname = array[Random.Range(0, array.Length)];
            cardBehaviour.species = SpeciesType.Enemy; 

            cardBehaviour.OnAction(GameManager.Instance.activeCharacter.person);*/

            turnUsed = true;
            GameManager.Instance.CheckRoundDone();
        }


        #endregion
        public void Flee(List<object> Targets)
        {

        }
        public void DrawExtraCard()
        {
            Debug.Log("Yewo, you were to finish this method. Its supposed to give character 1 extra action");
        }
    }
}
