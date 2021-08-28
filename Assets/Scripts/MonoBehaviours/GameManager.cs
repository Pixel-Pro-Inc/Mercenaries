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

        public GameObject[] debuffs;

        private void Awake()
        {
            Instance = this;
            roundInfo = new RoundInfo()
            {
                inControl = Enums.WhoseInControl.Human
            };
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
        }

        public void InstantiateEffect(debuffType type, CharacterBehaviour target)
        {
            switch (type)
            {
                case debuffType.Slow:
                    break;
                case debuffType.Rooted:
                    SpawnEffect(target.gameObject.transform, debuffs[15]);
                    break;
                case debuffType.WeakGrip:
                    SpawnEffect(target.gameObject.transform, debuffs[17]);
                    break;
                case debuffType.Exiled:
                    SpawnEffect(target.gameObject.transform, debuffs[13]);
                    break;
                case debuffType.Marked:                    
                    break;
                case debuffType.Calm:
                    SpawnEffect(target.gameObject.transform, debuffs[5]);
                    break;
                case debuffType.BrokenGaurd:
                    SpawnEffect(target.gameObject.transform, debuffs[14]);
                    break;
                case debuffType.Burnt:
                    SpawnEffect(target.gameObject.transform, debuffs[4]);
                    break;
                case debuffType.Stun:
                    SpawnEffect(target.gameObject.transform, debuffs[16]);
                    break;
                case debuffType.Freeze:
                    SpawnEffect(target.gameObject.transform, debuffs[12]);
                    break;
                case debuffType.Cold:
                    SpawnEffect(target.gameObject.transform, debuffs[8]);
                    break;
                case debuffType.Blinded:
                    SpawnEffect(target.gameObject.transform, debuffs[3]);
                    break;
                case debuffType.Tainted:
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
        int blockEffect = 0;
        void SpawnEffect(Transform character, GameObject effect)
        {
            if(blockEffect == 0)
            {
                Vector3 location = new Vector3(character.position.x, effect.transform.position.y, -1f);

                GameObject x = Instantiate(effect, location, Quaternion.identity);
                x.transform.SetParent(character);

                blockEffect = 1;
            }            
        }
    }
}
