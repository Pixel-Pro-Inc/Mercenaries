using Assets.Scripts.Entities.Character;
using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
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

        private void Awake()
        {
            Instance = this;
            roundInfo = new RoundInfo()
            {
                inControl = Enums.WhoseInControl.Human
            };
        }

        public void CheckGameOver()
        {
            //Something
        }
        public void CheckRoundDone()
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
                        //Attack
                        GameManager.Instance.activeEnemy = enemyCharacters[0].GetComponentInChildren<CharacterBehaviour>();

                        enemyCharacters[0].GetComponentInChildren<CharacterBehaviour>().EnemyAttack();
                    }
                    break;
                case Enums.WhoseInControl.CPU:
                    roundInfo.inControl = Enums.WhoseInControl.Human;
                    for (int i = 0; i < enemyCharacters.Count; i++)
                    {
                        if (!enemyCharacters[i].GetComponentInChildren<CharacterBehaviour>().turnUsed)
                            roundInfo.inControl = Enums.WhoseInControl.CPU;
                    }

                    if(roundInfo.inControl == Enums.WhoseInControl.Human)
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

                blockEffect = 1;
            }            
        }
    }
}
