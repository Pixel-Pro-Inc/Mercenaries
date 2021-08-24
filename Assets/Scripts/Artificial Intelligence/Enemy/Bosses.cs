﻿using Assets.Scripts.Entities.Character;
using Assets.Scripts.Helpers;
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
    List<Persona> opponents = new List<Persona>();
    EnemyActions enemyActions = new EnemyActions();
    public Bosses(Persona _MyStats, List<Persona> _Opponents)
    {
        myStats = _MyStats;
        opponents.AddRange(_Opponents);
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
                enemyActions.MagicalAttacks();
                break;
            case 1:
                enemyActions.PhysicalAttacks();
                break;
            case 2:
                enemyActions.TrueDamageAttacks();
                break;
            case 3:
                enemyActions.Debuffs();
                break;
        }
    }

    void DefenseBiasedAttack()
    {
        if ((myStats.Health / myStats.Life) < healthThreshold)
        {
            //Heal
            enemyActions.Heal();
        }
        else
        {
            Decision(); //Try another strategy
        }
    }

    void StrategicAttack()
    {

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