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
