using Assets.Scripts.Entities.Character;
using Assets.Scripts.Helpers;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosses
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
            bool fired = false;
            if (count % 2 == 0)
                fired = SlotMachine(blindAttack);

            if (count % 3 == 0)
                fired = SlotMachine(defenseBiasedAttack);

            if (count % 4 == 0)
                fired = SlotMachine(strategicAttack);

            if (fired)
            {
                if (count % 2 == 0) // blind attack
                    BlindAttack();

                if (count % 3 == 0) // defense Biased Attack
                    DefenseBiasedAttack();

                if (count % 4 == 0) // strategic Attack
                    StrategicAttack();
            }

            count++;
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
            enemyActions.Buff(opponents.Any());
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
                    enemyActions.PhysicalAttacks(opponents.Any());

                    fired = true;
                    i = opponents.Count;
                }
            }
        }

        if (!fired)
        {
            for (int i = 0; i < opponents.Count; i++)
            {
                if (opponents[i].Health < (opponents[i].Life * .6f))
                {
                    enemyActions.MagicalAttacks(opponents.Any());

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
                    enemyActions.TrueDamageAttacks(opponents.Any());

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
                    enemyActions.Debuffs(opponents.Any());

                    fired = true;
                    i = opponents.Count;
                }
            }
        }

        if (!fired)
        {
            //enemyActions.Buffs();
        }
    }
    bool SlotMachine(float chance)
    {
        int max = (int)(1f / chance);
        int n = Random.Range(0, max + 1);

        if (n == 0)
        {
            return true;
        }

        return false;
    }

}