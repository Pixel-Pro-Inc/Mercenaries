using Assets.Scripts.Entities.Character;
using Assets.Scripts.Helpers.Traits;
using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using static Assets.Scripts.Models.Enums;

namespace Assets.Scripts.MonoBehaviours
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; set; }

        public List<GameObject> playerCharacters = new List<GameObject>();
        public List<GameObject> enemyCharacters = new List<GameObject>();

        public RoundInfo roundInfo;
        public CharacterBehaviour activeCharacter;
        public CharacterBehaviour activeEnemy;

        public GameObject[] effects;

        //The list below work for the Gods Mechanism
        public List<object> TeamAttacks = new List<object>(); //These are the Attacks actually sent out by the character
        public List<object> TeamDefence = new List<object>();
        public List<object> TeamBuffs = new List<object>();
        public List<object> TeamDeBuffs = new List<object>(); //These are the Debuffs actually experienced by the character
        Gods GodsMechanism;

        public CardBehaviour selectedCard;
        public bool cardSelected;

        public Material outlineMat;
        public Material defaultSprite;

        public GameObject gameOverScreen;

        public bool gameIsOver;

        private void Awake()
        {
            Instance = this;
            roundInfo = new RoundInfo()
            {
                inControl = Enums.WhoseInControl.Human
            };

            
        }
        private void Start()
        {
            Invoke("SceneReady", 0.1f);
        }
        public void SceneReady()
        {
            SwitchActiveCharacter(); //Call after Scene is Ready Once
        }

        public void Update()
        {
            GodsMechanism = activeCharacter.GetComponentInChildren<Gods>();
            if (activeCharacter.Norgami != Deity.Atheos)
                GodsMechanism.GodsHand(activeCharacter.Norgami, activeCharacter.GetComponentInChildren<Persona>());
        }
        public void CheckRoundDone()
        {
            if (!gameIsOver)
            {
                switch (roundInfo.inControl)
                {
                    case Enums.WhoseInControl.Human:
                        roundInfo.inControl = Enums.WhoseInControl.CPU;

                        for (int i = 0; i < playerCharacters.Count; i++)
                        {
                            if (!playerCharacters[i].GetComponentInChildren<CharacterBehaviour>().turnUsed)
                                roundInfo.inControl = Enums.WhoseInControl.Human;
                        }

                        if (roundInfo.inControl == Enums.WhoseInControl.CPU)
                        {
                            for (int i = 0; i < enemyCharacters.Count; i++)
                            {
                                enemyCharacters[i].GetComponentInChildren<CharacterBehaviour>().turnUsed = false;
                            }
                        }
                        break;
                    case Enums.WhoseInControl.CPU:
                        roundInfo.inControl = Enums.WhoseInControl.Human;
                        for (int i = 0; i < enemyCharacters.Count; i++)
                        {
                            if (!enemyCharacters[i].GetComponentInChildren<CharacterBehaviour>().turnUsed)
                                roundInfo.inControl = Enums.WhoseInControl.CPU;
                        }

                        if (roundInfo.inControl == Enums.WhoseInControl.Human)
                        {
                            for (int i = 0; i < playerCharacters.Count; i++)
                            {
                                playerCharacters[i].GetComponentInChildren<CharacterBehaviour>().turnUsed = false;
                            }

                            DeckPopulate.Instance.DeleteCards();
                        }
                        break;

                }

                List<Persona> personas = new List<Persona>();

                //Hungry Debuff Implementation
                for (int i = 0; i < playerCharacters.Count; i++)
                {
                    personas.Add(playerCharacters[i].GetComponentInChildren<CharacterBehaviour>().person);
                }
                for (int i = 0; i < enemyCharacters.Count; i++)
                {
                    personas.Add(enemyCharacters[i].GetComponentInChildren<CharacterBehaviour>().person);
                }

                for (int i = 0; i < personas.Count; i++)
                {
                    List<DebuffObject> debuffs = new List<DebuffObject>();
                    debuffs.AddRange(personas[i].GetDebuffs());
                    if (debuffs.Count != 0)
                        foreach (var item in debuffs)
                        {
                            if (item.type == debuffType.Hungry)
                                personas[i].Health -= (int)((float)personas[i].Life * (float)item.amount);
                        }
                }
                //Remove Debuffs
                for (int i = 0; i < playerCharacters.Count; i++)
                {
                    personas.Add(playerCharacters[i].GetComponentInChildren<CharacterBehaviour>().person);
                }
                for (int i = 0; i < enemyCharacters.Count; i++)
                {
                    personas.Add(enemyCharacters[i].GetComponentInChildren<CharacterBehaviour>().person);
                }

                for (int i = 0; i < personas.Count; i++)
                {
                    List<DebuffObject> debuffs = new List<DebuffObject>();
                    debuffs.AddRange(personas[i].GetDebuffs());
                    if (debuffs.Count != 0)
                        foreach (var item in debuffs)
                        {
                            if (item.roundsActive >= item.lifeTime)
                            {
                                personas[i].RemoveDebuff(item);//remove effect
                            }

                            item.roundsActive++;
                        }
                }

                CheckBattleOver();
                SwitchActiveCharacter();
            }            
        }
        public void SwitchActiveCharacter()
        {
            //Switch Active Character (Character with highest speed attacks first)
            if (roundInfo.inControl == WhoseInControl.Human)
                ActiveCharacterLogic(playerCharacters, enemyCharacters);

            if (roundInfo.inControl == WhoseInControl.CPU)
                ActiveCharacterLogic(enemyCharacters, playerCharacters);
        }
        void ActiveCharacterLogic(List<GameObject> objects, List<GameObject> opps)
        {
            List<Persona> p = new List<Persona>();
            for (int i = 0; i < objects.Count; i++)
            {
                p.Add(objects[i].transform.GetComponentInChildren<CharacterBehaviour>().person);
            }

            List<float> speeds = new List<float>();
            for (int i = 0; i < p.Count; i++)
            {
                speeds.Add((float)p[i].Speed);
            }

            float val = Mathf.Max(speeds.ToArray());

            int ndex = speeds.IndexOf(val);

            objects[ndex].transform.GetComponentInChildren<CharacterBehaviour>().SetAsActiveCharacter();
            p[ndex].Speed *= .75f;

            for (int i = 0; i < opps.Count; i++)
            {
                opps[i].GetComponentInChildren<CharacterBehaviour>().person.Speed /= .75f; //= opps[i].GetComponentInChildren<CharacterBehaviour>().GetDefaultValues().Speed;
            }
        }

        public void InstantiateEffect(EffectType type, CharacterBehaviour target)
        {
            SpawnEffect(target.gameObject.transform, effects[GetIndexOfEffect(type)]);
        }
        int blockEffect = 0;

        int GetIndexOfEffect(EffectType type)
        {
            string id = type.ToString();
            id = id.Replace('_', ' ');

            for (int i = 0; i < effects.Length; i++)
            {
                if (effects[i].name == id)
                    return i;
            }

            return 0;
        }
        void SpawnEffect(Transform character, GameObject effect)
        {
            if(blockEffect == 0)
            {
                Vector3 location = new Vector3(character.position.x, effect.transform.position.y, -1f);

                GameObject x = Instantiate(effect, location, Quaternion.identity);
                x.transform.SetParent(character);

                x.transform.localPosition = location;

                //blockEffect = 1;
            }            
        }
        public void CheckBattleOver()
        {
            int totalHealth = 0;
            for (int i = 0; i < playerCharacters.Count; i++)
            {
                totalHealth += playerCharacters[i].transform.GetComponentInChildren<CharacterBehaviour>().person.Health;
            }

            if (totalHealth <= 0)
            {
                BattleLost();
                gameIsOver = true;
                return;
            }

            totalHealth = 0;
            for (int i = 0; i < enemyCharacters.Count; i++)
            {
                totalHealth += enemyCharacters[i].transform.GetComponentInChildren<CharacterBehaviour>().person.Health;
            }

            if (totalHealth <= 0)
            {
                BattleWon();
                gameIsOver = true;
                return;
            }
        }
        public void BattleWon()
        {
            gameOverScreen.SetActive(true);
            Text t = gameOverScreen.transform.GetChild(0).gameObject.GetComponent<Text>();
            t.text = "You Won!!!";
            Debug.Log("Yeah here should be the battle won animation, and call the Gamefinished() logic. We might have to do this together? What you think");
        }
        public void BattleLost()
        {
            gameOverScreen.SetActive(true);
            Text t = gameOverScreen.transform.GetChild(0).gameObject.GetComponent<Text>();
            t.text = "You Lost!!!";
            Debug.Log("Battle lost animation and Game over logic");
        }
    }
}
