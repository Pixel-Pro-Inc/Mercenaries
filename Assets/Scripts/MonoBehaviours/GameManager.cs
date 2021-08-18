using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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
    }
}
