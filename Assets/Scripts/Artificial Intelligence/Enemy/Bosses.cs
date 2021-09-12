using Assets.Scripts.Entities.Character;
using Assets.Scripts.Helpers;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosses: MonoBehaviour
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

    public Persona myStats;
    public List<Persona> opponents = new List<Persona>();
    EnemyActions enemyActions = new EnemyActions();

    public void SetBosses(Persona _MyStats, List<Persona> _Opponents)
    {
        myStats = _MyStats;
        opponents.AddRange(_Opponents);

        enemyActions.PassiveEnemyAbility();

        enemyActions.bossesScript = this; //this doesnt make sense
    }
    public void Decision() //Play Style Decision
    {
        int k = 0;
        int count = 0;
        Debug.Log(count);

        while (k == 0)
        {
            count = Random.Range(0, 3);
            Debug.Log(count);

            k = 1;
            bool fired = false;
            if (count == 0)
                fired = SlotMachine(blindAttack);

            if (count == 1)
                fired = SlotMachine(defenseBiasedAttack);

            if (count == 2)
                fired = SlotMachine(strategicAttack);

            if (fired)
            {
                if (count == 0) // blind attack
                    BlindAttack();

                if (count == 1) // defense Biased Attack
                    DefenseBiasedAttack();

                if (count == 2) // strategic Attack
                    StrategicAttack();

                k = 1;
            }
        }
    }
    void BlindAttack()
    {
        int r = Random.Range(0, 4);

        switch (r)
        {
            case 0:
                enemyActions.MagicalAttacks(opponents[Random.Range(0, opponents.Count)]);
                break;
            case 1:
                enemyActions.PhysicalAttacks(opponents[Random.Range(0, opponents.Count)]);
                break;
            case 2:
                enemyActions.TrueDamageAttacks(opponents[Random.Range(0, opponents.Count)]);
                break;
            case 3:
                enemyActions.Debuffs(opponents[Random.Range(0, opponents.Count)]);
                break;
        }
    }
    void DefenseBiasedAttack()
    {
        if (((float)myStats.Health / (float)myStats.Life) < (float)healthThreshold) //Persona.Life is not set
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
            Decision(); //Try another strategy. !! This is necessary cause there should be no such thing as inaction, it has to keep trying to do something until something fires cause sometimes a boss might not have some of these mehods
            fired = true;
        }
    }
    bool SlotMachine(float chance)
    {
        int max = (int)(1f / chance);
        int n = Random.Range(0, max);

        Debug.Log(max);

        if (n == 0)
        {
            return true;
        }

        return false;
    }

}