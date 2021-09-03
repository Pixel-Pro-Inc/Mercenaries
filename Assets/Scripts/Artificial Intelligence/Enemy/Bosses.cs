using Assets.Scripts.Entities.Character;
using Assets.Scripts.Helpers;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosses:MonoBehaviour
{
    #region Tendencies
    //Play Style
    public float blindAttack; //Chance of attacking without thinking
    public float defenseBiasedAttack; //Priotization of defense
    public float strategicAttack;//Looks at opponents health, debuff, stats

    //Type of Attack
    public float debuffLikelyHood;//Chance of debuffing
    public float bruteForce;//Chance of giving physical damage
    public float magicalForce;//Chance of giving magical damage
    public float trueForce;//Chance of giving true damage

    //Type of Defense
    public float buffLikelyHood;//Chance of buffing
    #endregion

    #region Thresholds
    public double healthThreshold; // Percentage
    #endregion

    Persona myStats;
    public static Bosses Instance;
    List<Persona> opponents = new List<Persona>();
    EnemyActions enemyActions = new EnemyActions();

    public Bosses(Persona _MyStats, List<Persona> _Opponents)
    {
        Instance = this;
        myStats = _MyStats;
        opponents.AddRange(_Opponents);
        enemyActions.PassiveEnemyAbility();
    }
    public void Decision() //Play Style Decision
    {
        int k = 0;
        int count = 0; 
        while (k == 0)
        {
            count = Random.Range(1, 101);
            bool fired = false;
            if (count % 2 == 0) //Searches for even
                fired = SlotMachine(blindAttack);

            if (count % 3 == 0) //Searches for odd since od is just even +1
                fired = SlotMachine(defenseBiasedAttack);

            if (count % 2 != 0&& count % 3 != 0) //Searches for prime including multiples of 5
                fired = SlotMachine(strategicAttack);

            if (fired)
            {
                if (count % 2 == 0) // blind attack
                    BlindAttack();

                if (count % 3 == 0) // defense Biased Attack
                    DefenseBiasedAttack();

                if (count % 2 != 0 && count % 3 != 0) // strategic Attack
                    StrategicAttack();
                k++;
            }

        }        
    }
    void BlindAttack()
    {
        int r = Random.Range(0, 4);

        switch (r)
        {
            case 0:
                enemyActions.MagicalAttacks(opponents.Any());
                break;
            case 1:
                enemyActions.PhysicalAttacks(opponents.Any());
                break;
            case 2:
                enemyActions.TrueDamageAttacks(opponents.Any());
                break;
            case 3:
                enemyActions.Debuffs(opponents.Any());
                break;
        }
    }
    void DefenseBiasedAttack()
    {
        if ((myStats.Health / myStats.Life) < healthThreshold)
        {
            //BUff involves healing, cause it is not always possible to heal
            enemyActions.Buff(myStats);
        }
        else
        {
            Decision(); //Try another strategy
        }
    }
    void StrategicAttack()
    {
        bool fired = false;

        if (!fired)
        {
            for (int i = 0; i < opponents.Count; i++)
            {
                if (opponents[i].Health < (opponents[i].Life * .8f))
                {
                    enemyActions.PhysicalAttacks(opponents[i]);

                    fired = true;
                    i = opponents.Count; //You could have just had a break statement here but i guess this also works
                }
            }
        }

        if (!fired)
        {
            for (int i = 0; i < opponents.Count; i++)
            {
                if (opponents[i].Health < (opponents[i].Life * .6f))
                {
                    enemyActions.MagicalAttacks(opponents[i]);

                    fired = true;
                    i = opponents.Count;
                }
            }
        }

        if (!fired)
        {
            for (int i = 0; i < opponents.Count; i++)
            {
                if (opponents[i].Health < (opponents[i].Life * .4f))
                {
                    enemyActions.TrueDamageAttacks(opponents[i]);

                    fired = true;
                    i = opponents.Count;
                }
            }
        }

        if (!fired)
        {
            for (int i = 0; i < opponents.Count; i++)
            {
                if (opponents[i].GetDebuffs().Count == 0)
                {
                    enemyActions.Debuffs(opponents[i]);

                    fired = true;
                    i = opponents.Count;
                }
            }
        }

        if (!fired)
        {
            //enemyActions.Buffs(); This isnt really necessary cause we already have something to meet this end in DefenceBAisedStrategy
        }
        if (!fired)
        {
            Decision(); //Try another strategy. !! This is necessary cause there should be no such thing as inaction, it has to keep trying to do something until something fires cause sometimes a boss might not have some of these mehods
            fired = true;
        }
    }
    bool SlotMachine(float chance)
    {
        int max = (int)(1f / chance);
        int n = Random.Range(1, max + 1); //I changed this to one cause say the percentage is 100%, n will have to be within 1 and 2, which will be it will choose only 1

        if (n == 1)
        {
            return true;
        }

        return false;
    }

}