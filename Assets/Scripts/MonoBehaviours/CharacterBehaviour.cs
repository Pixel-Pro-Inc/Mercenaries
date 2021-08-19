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

namespace Assets.Scripts.MonoBehaviours
{
    public class CharacterBehaviour : MonoBehaviour
    {
        public Vector3[] positions = { new Vector3(-7.0f, -1.6f, 1.0f), new Vector3(-5.0f, -1.6f, 1.0f), new Vector3(-3.0f, -1.6f, 1.0f), new Vector3(-1.0f, -1.6f, 1.0f) };
        public GameObject parent;
        public Vector3 Goto;
        public SpeciesType species;
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
                    break;
                case MasterCharacterList.Mister_Glubglub:
                    WarriorTemplate MisterGlub = new WarriorTemplate();
                    MisterGlub.CharacterName = "Mister_Glubglub";
                    MisterGlub.CharacterDescription = "He is a fish. What did you expect?";

                    List<object> allied = new List<object> { GameManager.Instance.playerCharacters };
                    MisterGlub.Allies.AddRange(allied);
                    List<object> Enemied = new List<object> { GameManager.Instance.enemyCharacters };
                    MisterGlub.Enemies.AddRange(Enemied);

                    //Right now below these have been set to be species affinities but they seem to be originaliy invisioned to be COmbat classes
                    List<SpeciesType> NaturalAllied = new List<SpeciesType> { SpeciesType.Frog, SpeciesType.Fish };
                    MisterGlub.NaturalAllies.AddRange(NaturalAllied);
                    List<SpeciesType> Naturalenemied = new List<SpeciesType> { SpeciesType.Crocodile, SpeciesType.Lion };
                    MisterGlub.NaturalEnemies.AddRange(Naturalenemied);

                    MisterGlub.Foe = false;

                    person = MisterGlub;//gameObject.AddComponent<Persona>();
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
            if (species == SpeciesType.Enemy)
            {
                MageTemplate mageTemplate = new MageTemplate();
                person = mageTemplate;//gameObject.AddComponent<Persona>();
            }
            else
            {
                WarriorTemplate warriorTemplate = new WarriorTemplate();
                person = warriorTemplate;//gameObject.AddComponent<Persona>();
            }

        }
        public void OnMouseDown()
        {
            if (!turnUsed)
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

        #region EnemyCode
        public void EnemyAttack()
        {
            CardBehaviour cardBehaviour = new CardBehaviour();

            cardName[] array = (cardName[])(cardName.GetValues(typeof(cardName)));
            cardBehaviour.cardname = array[Random.Range(0, array.Length)];
            cardBehaviour.species = SpeciesType.Enemy;

            cardBehaviour.OnAction(GameManager.Instance.activeCharacter.person);

            turnUsed = true;
            GameManager.Instance.CheckRoundDone();
        }

        public void Flee(List<object> Targets)
        {

        }
        #endregion
    }
}
