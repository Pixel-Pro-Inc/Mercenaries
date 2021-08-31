using Assets.Scripts.Entities.Character;
using Assets.Scripts.Interface;
using System.Timers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.MonoBehaviours;
using Assets.Scripts.Models;
using UnityEngine;
using static Assets.Scripts.Models.Enums;
using System.Threading;

namespace Assets.Scripts.Helpers
{
    class EnemyActions: Persona, IEnemyAction
    {
        MasterCharacterList EnemyNames;
        Persona CharacterInstance = null;
        public void PassiveEnemyAbility()
        {
            if (GameManager.Instance.activeEnemy != null && GameManager.Instance.roundInfo.inControl == WhoseInControl.CPU)
            { CharacterInstance = GameManager.Instance.activeEnemy.person; }
            Persona Character= CharacterInstance;
            switch (EnemyNames)
            {
                case MasterCharacterList.HammerHead:
                    //I'm using threads here cause it seems like the program stalls when one of theseis not met. So im utilizing parrallelization
                    void passive1()
                    {
                        while (Character.Health > (int)(Character.Life * 0.5))
                        {
                            Character.AgileBUffPercent = 0.5;
                            Character.Agile(Character, true);
                        }
                    }
                    void passive2()
                    {
                        while ((Character.Health <= (int)(Character.Life * 0.5)) && (Character.Health > (int)(Character.Life * 0.25)))
                        {
                            //here im thinking it checks if the stun in the list of debuffs and if true, with a 50% chance it will reverse the effect. But im not sure how yewo intends to reverse effects
                            Debug.Log("Yewo, you need to create the reverse deuff method for this to work");
                        }
                    }
                    void passive3()
                    {
                        while (Character.Health <= (int)(Character.Life * 0.25))
                        {
                            int fordo = RoundInfo.RoundsPassed;
                            Character.PowerBuffPercent = 2;
                            if (RoundInfo.RoundsPassed > fordo)
                            {
                                Character.PolishWeapon(Character);
                            }
                        }
                    }

                    ThreadStart passiveEffect1 = new ThreadStart(passive1);
                    Thread childThread1 = new Thread(passiveEffect1);
                    childThread1.Start();
                    childThread1.Abort(); //i have abort call immeditaly after cause it want to remove the thread so we dont have the mutliple threads at the same time
                    //i just want a sinlge adjusent thread at a time, for performance sake

                    ThreadStart passiveEffect2 = new ThreadStart(passive2);
                    Thread childThread2 = new Thread(passiveEffect1);
                    childThread2.Start();
                    childThread2.Abort();

                    ThreadStart passiveEffect3 = new ThreadStart(passive3);
                    Thread childThread3 = new Thread(passiveEffect3);
                    childThread3.Start();
                    childThread3.Abort();

                    break;
                case MasterCharacterList.GreatWhite:
                    int healdamage = new int();
                    int[] ycount = new int[Character.Enemies.Count];// these store the initial values of health of enemies
                    int[] Zcount = new int[Character.Enemies.Count];// these store the new values of health enemies
                    for (int i = 0; i < Character.Enemies.Count; i++) //this is to store the health of each enemy
                    {
                        Persona indiv = (Persona)Character.Enemies[i];
                        ycount[i] = indiv.Health;
                        Zcount[i] = ycount[i];
                    }
                    void GreatWhitepassive1()
                    {
                        while (Character.Health > (int)(Character.Life * 0.5))
                        {
                            Character.AgileBUffPercent = 0.5;
                            Character.Agile(Character, true);
                        }
                    }
                    void GreatWhitepassive2()
                    {
                        while ((Character.Health <= (int)(Character.Life * 0.5)) && (Character.Health > (int)(Character.Life * 0.25)))
                        {
                            //here im thinking it checks if the stun in the list of debuffs and if true, with a 50% chance it will reverse the effect. But im not sure how yewo intends to reverse effects
                            Debug.Log("Yewo, you need to create the reverse deuff method for this to work");
                        }
                    }
                    void GreatWhitepassive3()
                    {
                        while (Character.Health <= (int)(Character.Life * 0.15))
                        {
                            for (int i = 0; i < Character.Enemies.Count; i++) //this here is meant to constantly check the health values
                            {
                                Persona ego = (Persona)Character.Enemies[i];
                                Zcount[i] = ego.Health;
                            }
                            for (int i = 0; i < Character.Enemies.Count; i++)//this is meant to actually do the logic
                            {
                                Persona tribe = (Persona)Character.Enemies[i]; //this is cause we need each enemies attacksponser info to see if it matches
                                if ((ycount[i] != Zcount[i]) && ((Persona)tribe.AttackSponser == Character))// checks health and attack sponser
                                {
                                    healdamage += ycount[i] - Zcount[i];
                                }
                                if (ycount[i] != Zcount[i])
                                {
                                    ycount[i] = Zcount[i]; //this is so if someone else affected their heal, it will change the health array appropriatly
                                }
                            }
                            Character.HealVictim(Character, healdamage);
                        }
                    }

                    ThreadStart GreatWhitepassiveEffect1 = new ThreadStart(GreatWhitepassive1);
                    Thread GreatWhitechildThread1 = new Thread(GreatWhitepassiveEffect1);
                    GreatWhitechildThread1.Start();
                    GreatWhitechildThread1.Abort(); //i have abort call immeditaly after cause it want to remove the thread so we dont have the mutliple threads at the same time
                    //i just want a sinlge adjusent thread at a time, for performance sake

                    ThreadStart GreatWhitepassiveEffect2 = new ThreadStart(GreatWhitepassive2);
                    Thread GreatWhitechildThread2 = new Thread(GreatWhitepassiveEffect1);
                    GreatWhitechildThread2.Start();
                    GreatWhitechildThread2.Abort();

                    ThreadStart GreatWhitepassiveEffect3 = new ThreadStart(GreatWhitepassive3);
                    Thread GreatWhitechildThread3 = new Thread(GreatWhitepassiveEffect3);
                    GreatWhitechildThread3.Start();
                    GreatWhitechildThread3.Abort();

                    break;
                case MasterCharacterList.SpiderCrustacean:
                    int storedhealth = Character.Health;
                    int dmaGi=0;
                    foreach (object item in Character.Allies)
                    {
                        Persona friend = (Persona)item;
                        if (friend.Health!=0)
                        {
                            Character.defenceArmourPercentage += 0.1;
                            Character.defenceMagresPercentage += 0.1;
                        }
                    }

                    void SpiderCrustaceanpassive1()
                    {
                        while (RoundInfo.GameInSession == true)
                        {
                            if (storedhealth != Character.Health)
                            {
                                dmaGi = (int)((Character.Health - storedhealth) * 0.1);
                                DamageObject errand = new DamageObject { DamageValue = dmaGi };
                                Character.TrueDamage(Character, Character.AttackSponser, errand);
                                storedhealth = Character.Health;
                            }
                        }
                    }
                    ThreadStart SpiderCrustaceanpassiveEffect3 = new ThreadStart(SpiderCrustaceanpassive1);
                    Thread SpiderCrustaceanchildThread3 = new Thread(SpiderCrustaceanpassiveEffect3);
                    SpiderCrustaceanchildThread3.Start();
                    SpiderCrustaceanchildThread3.Abort();

                    break;
                case MasterCharacterList.NecroBoar:
                    int[] storedalliedHealth = new int[Character.Allies.Count];
                    int bleedCount = new int();
                    for (int i = 0; i < Character.Allies.Count; i++)
                    {
                        Persona villian = (Persona)Character.Allies[i];
                        storedalliedHealth[i]= villian.Health;
                    }
                    int[] CollectedalliedHealth = storedalliedHealth;
                    foreach (object item in Character.Enemies)
                    {
                        Persona heros = (Persona)item;
                        foreach (AttackObject attack in heros.GetAttack(heros))
                        {
                            if ((attack.type == Enums.AttackType.Bleed) && (attack.Victim == (object)Character)&&(attack.state==true)) //this basically asks if someone is bleeding by the hand of a villian
                            {
                                bleedCount++;
                            }
                        }
                    }
                    System.Timers.Timer Boom; Boom = new System.Timers.Timer(); Boom.Elapsed += new ElapsedEventHandler(Punch);  Boom.Interval = 1000; Boom.Enabled = true;
                    void Punch(object source2, ElapsedEventArgs e)
                    {
                        for (int i = 0; i < Character.Allies.Count; i++)
                        {
                            Persona villian = (Persona)Character.Allies[i];
                            CollectedalliedHealth[i] = villian.Health;

                            if (storedalliedHealth[i]!=CollectedalliedHealth[i])
                            {
                                storedalliedHealth[i] = CollectedalliedHealth[i];
                                if ((CollectedalliedHealth[i] == 0)&&(bleedCount%2==0))
                                {
                                    Character.UniqueSkill(Character, villian);
                                    //this is supposed to revive the object. I though im not sure how plan to handle death.
                                    //As i stands the uniqueSkill of NecroBoar is to Revive Allies
                                    bleedCount -= 2;
                                }
                                foreach (object item in Character.Enemies)
                                {
                                    Persona heros = (Persona)item;
                                    foreach (AttackObject attack in heros.GetAttack(heros))
                                    {
                                        if ((attack.type == Enums.AttackType.Bleed) &&  (attack.state == true)) //this basically asks if someone is bleeding by the hand of a villian
                                        {
                                            attack.state =false;
                                        }
                                    }
                                }

                            }
                        }

                        if (RoundInfo.GameInSession == false) Boom.Close();
                    }

                    break;
                case MasterCharacterList.ElderStag:
                    for (int i = 0; i < GameManager.Instance.enemyCharacters.Count; i++)
                    {
                        if (GameManager.Instance.enemyCharacters[i].GetComponentInChildren<CharacterBehaviour>().turnUsed == false)
                        {
                            System.Timers.Timer Siccsa; Siccsa = new System.Timers.Timer(); Siccsa.Elapsed += new ElapsedEventHandler(Gitar); Siccsa.Interval = 1000; Siccsa.Enabled = true;
                            void Gitar(object source2, ElapsedEventArgs e)
                            {
                                if (GameManager.Instance.enemyCharacters[i].GetComponentInChildren<CharacterBehaviour>().turnUsed == true)
                                {
                                    GameManager.Instance.enemyCharacters[i].GetComponentInChildren<Persona>().Health += (int)(GameManager.Instance.enemyCharacters[i].GetComponentInChildren<Persona>().Life * 0.1);
                                }
                            }
                            //this is a passive trait so the timer should't close
                        }
                    }
                    break;
                case MasterCharacterList.DevilBird:
                    double collectMagic = 0; int cout = 0;
                    System.Timers.Timer Jesu; Jesu = new System.Timers.Timer(); Jesu.Elapsed += new ElapsedEventHandler(Komm); Jesu.Interval = 1000; Jesu.Enabled = true;
                    void Komm(object source2, ElapsedEventArgs e)
                    {
                        for (int i = 0; i < GameManager.Instance.enemyCharacters.Count; i++)
                        {
                            if ((GameManager.Instance.enemyCharacters[i].GetComponentInChildren<CharacterBehaviour>().turnUsed == false) && (Character == GameManager.Instance.enemyCharacters[i])&&cout==0)
                            {
                                Character.MagiBuffPercent += 0.05; collectMagic += 0.05;
                                Character.Chosen(Character);
                                cout++; // this is so it only performs the above statements once per turn
                                if (collectMagic%0.15==0)
                                {
                                    Character.Curse(Character, Character.Enemies[UnityEngine.Random.Range(0, Character.Enemies.Count)]);
                                    Character.Curse(Character, Character.Enemies[UnityEngine.Random.Range(0, Character.Enemies.Count)]);
                                }
                            }
                            if ((GameManager.Instance.enemyCharacters[i].GetComponentInChildren<CharacterBehaviour>().turnUsed == true) && (Character == GameManager.Instance.enemyCharacters[i]) && cout == 1)
                            {
                                cout--;// this is so it goes back to inital state
                            }
                        }
                    }
                    //this is a passive trait so the timer should't close
                    
                    break;
                case MasterCharacterList.DragonSloth:
                    Vector3[] herpositions = new Vector3[GameManager.Instance.playerCharacters.Count];
                    for (int i = 0; i < GameManager.Instance.playerCharacters.Count; i++)
                    {
                        herpositions=GameManager.Instance.playerCharacters[i].GetComponentInChildren<CharacterBehaviour>().positions;
                    }
                    herpositions.Reverse(); // here is how they switch positions or rather the fucntion that makes it possible
                    for (int i = 0; i < GameManager.Instance.playerCharacters.Count; i++)
                    {
                        GameManager.Instance.playerCharacters[i].GetComponentInChildren<CharacterBehaviour>().positions[i] = herpositions[i];
                    }
                    foreach (var item in Character.Enemies)
                    {
                        Persona hero = (Persona)item;
                        hero.dodge -= (int)(hero.dodge*0.1);
                    }
                    break;
                default:
                    break;
            }
        }
        #region Unused code
        /*
         public void Attack1(object TargetInstance)
        {
            if (GameManager.Instance.activeEnemy != null && GameManager.Instance.roundInfo.inControl == WhoseInControl.CPU)
            { CharacterInstance = GameManager.Instance.activeEnemy.person; }
            Persona Character = CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            DamageObject damageobj = new DamageObject();

            switch (EnemyNames)
            {
                case MasterCharacterList.HammerHead:
                    foreach (object item in Character.Enemies)
                    {
                        PhysicalDamage(Character, item);
                        Tainted(Character, item, 1);
                    }
                    break;
                case MasterCharacterList.GreatWhite:
                    int enemyindexCount = Character.Enemies.Count;
                    damageobj.DamageValue = Character.DamageGiven();
                    int tea = UnityEngine.Random.Range(0, enemyindexCount);
                    Character.TrueDamage(CharacterInstance, Character.Enemies[tea], damageobj);
                    break;
                case MasterCharacterList.SpiderCrustacean:
                    Character.PhysicalDamage(Character, Target);
                    Character.CalmDeBuffPercent = 0.2;
                    Character.Calm(Character, Target, 1);
                    break;
                case MasterCharacterList.NecroBoar:
                    int RoundsDone = new int(); RoundsDone = RoundInfo.RoundsPassed; int count = 0;
                    Timer myr2; myr2 = new Timer(); myr2.Elapsed += new ElapsedEventHandler(myEt); myr2.Interval = 1000; myr2.Enabled = true;
                    void myEt(object source2, ElapsedEventArgs e)
                    {
                        if (RoundsDone != RoundInfo.RoundsPassed && count < 3)
                        {
                            RoundsDone = RoundInfo.RoundsPassed;
                            Character.Bleed(Character, Target);
                            count++;
                        }
                        if (count == 3) myr2.Close();
                    }
                    break;
                case MasterCharacterList.ElderStag:
                    int ElderFist = (int)(Character.DamageGiven() * 0.4);
                    Persona Face = (Persona)Character.Enemies[UnityEngine.Random.Range(0, Character.Enemies.Count)];
                    Persona Face2 = (Persona)Character.Enemies[UnityEngine.Random.Range(0, Character.Enemies.Count)];
                    Persona Face3 = (Persona)Character.Enemies[UnityEngine.Random.Range(0, Character.Enemies.Count)];
                    List<Persona> Faces = new List<Persona> { Face, Face2, Face3 };
                    foreach (var item in Faces)
                    {
                        Character.MagicalDamage(Character, item, ElderFist);
                    }
                    foreach (var item in Character.Allies)
                    {
                        Persona fRIEND = (Persona)item;
                        fRIEND.Speed += (int)(fRIEND.Speed * 0.1);
                    }
                    break;
                case MasterCharacterList.DevilBird:
                    object fVictim = Character.Enemies[UnityEngine.Random.Range(0, Character.Enemies.Count)];
                    object SVictim = Character.Enemies[UnityEngine.Random.Range(0, Character.Enemies.Count)];
                    int roundsbaby = RoundInfo.RoundsPassed;
                    Character.Rooted(Character, fVictim, 1); Character.Burnt(Character, fVictim);
                    Character.Rooted(Character, SVictim, 1); Character.Burnt(Character, SVictim);

                    Timer summer; summer = new Timer(); summer.Elapsed += new ElapsedEventHandler(vivaldiiii); summer.Interval = 1000; summer.Enabled = true;
                    void vivaldiiii(object source2, ElapsedEventArgs e)
                    {
                        if (roundsbaby + 1 == RoundInfo.RoundsPassed)
                        {
                            Character.Burnt(Character, fVictim);
                            Character.Burnt(Character, SVictim);
                            summer.Close();
                        }
                    }

                    break;
                case MasterCharacterList.DragonSloth:
                    Persona Deictim = (Persona)Character.Enemies[UnityEngine.Random.Range(0, Character.Enemies.Count)];
                    Character.PhysicalDamage(Character, Deictim);
                    Deictim.dodge -= 5;
                    break;
                default:
                    break;
            }
        }
        public void Attack2(object TargetInstance)
        {
            if (GameManager.Instance.activeEnemy != null && GameManager.Instance.roundInfo.inControl == WhoseInControl.CPU)
            { CharacterInstance = GameManager.Instance.activeEnemy.person; }
            Persona Character = CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            DamageObject damageobj = new DamageObject();

            switch (EnemyNames)
            {
                case MasterCharacterList.HammerHead:
                    int speedCount = 0;
                    foreach (object item in Character.Enemies)
                    {
                        Character.Stun(Character, item, 1);
                        Persona hero = (Persona)item;
                        foreach (DebuffObject debuff in hero.GetDebuffs())
                        {
                            if (debuff.type == Enums.debuffType.Stun)
                            {
                                speedCount++;
                                break;// so it stops checking for more stun Debuffs
                            }
                        }
                    }
                    Character.Speed += (int)(Character.Speed * 0.1 * speedCount);

                    break;
                case MasterCharacterList.GreatWhite:

                    foreach (object item in Character.Allies)
                    {
                        Persona villian = (Persona)item;
                        foreach (AttackObject attack in villian.GetAttack(villian))
                        {
                            if ((attack.type == Enums.AttackType.Bleed) && (attack.Victim == (object)villian)) //this basically asks if someone is bleeding by the hand of a villian
                            {
                                Character.CriticalChance = true; Character.PhysicalDamage(Character, Target);
                                Target.Armour -= (int)(Target.Armour * 0.5);
                                break;// so it stops checking for more bleeding attackObjects with this villan
                            }
                        }
                    }
                    foreach (object item in Character.Enemies) //I put this here cause i think the shark will attack anyone it smells having bleeding. Even itself and friends
                    {
                        Persona hero = (Persona)item;
                        foreach (AttackObject attack in hero.GetAttack(hero))
                        {
                            if ((attack.type == Enums.AttackType.Bleed) && (attack.Victim == (object)hero)) //this basically asks if someone is bleeding by the hand of a hero
                            {
                                Character.CriticalChance = true; Character.PhysicalDamage(Character, Target);
                                Target.Armour -= (int)(Target.Armour * 0.5);
                                break;// so it stops checking for more bleeding attackObjects with this hero
                            }
                        }
                    }
                    break;
                case MasterCharacterList.SpiderCrustacean:
                    Character.BrokenGaurdDeBuffPercent = 0.2;
                    Character.BrokenGuard(Character, Target, 1);
                    break;
                case MasterCharacterList.NecroBoar:
                    foreach (AttackObject attack in Target.GetAttack(Target))
                    {
                        if ((attack.type == Enums.AttackType.Bleed) && (attack.state == true)) //this basically asks if someone is bleeding 
                        {
                            Character.PowerBuffPercent = 0.5;
                            Character.PhysicalDamage(Character, Target);
                            foreach (var item in Character.Enemies)
                            {
                                Persona victim = (Persona)item;
                                if (victim != Target) Character.Bleed(Character, victim);
                            }
                            break;
                        }
                        else { Character.PhysicalDamage(Character, Target); }
                    }
                    break;
                case MasterCharacterList.ElderStag:
                    int storedhealth = new int(); int count = 0; int lowest = new int();
                    for (int i = 0; i < Character.Allies.Count; i++)
                    {
                        Persona friend = (Persona)Character.Allies[i];
                        if (count == 0)
                        { storedhealth = friend.Health; count++; }
                        else
                        if (storedhealth > friend.Health)
                        {
                            lowest = i; storedhealth = friend.Health;
                        }
                    }
                    Persona weak = (Persona)Character.Allies[lowest];
                    weak.Health += weak.Health;
                    break;
                case MasterCharacterList.DevilBird:
                    Character.UniqueSkill(Character, Target); Character.Sleep(Character, Target);
                    break;
                case MasterCharacterList.DragonSloth:
                    if (Target.dodge == 0)
                    {
                        damageobj.DamageValue = (int)(Character.DamageGiven() * 0.25);
                        Character.PhysicalDamage(Character, Target, damageobj);
                        if (UnityEngine.Random.Range(1, 100) < 50)
                        {
                            Character.PhysicalDamage(Character, Target);
                        }
                    }

                    break;
                default:
                    break;
            }
        }
        public void Attack3(object TargetInstance)
        {
            if (GameManager.Instance.activeEnemy != null && GameManager.Instance.roundInfo.inControl == WhoseInControl.CPU)
            { CharacterInstance = GameManager.Instance.activeEnemy.person; }
            Persona Character = CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            DamageObject damageobj = new DamageObject();
            switch (EnemyNames)
            {
                case MasterCharacterList.HammerHead:
                    int theDama = Character.DamageGiven();
                    damageobj.DamageValue = (int)(theDama * 0.3);
                    foreach (object item in Character.Enemies)
                    {
                        Character.TrueDamage(Character, item, damageobj);
                        damageobj.DamageValue = (int)(theDama * 0.35);
                        Character.Bleed(Character, item, damageobj);
                    }

                    break;
                case MasterCharacterList.GreatWhite:
                    damageobj.DamageValue = (int)(Character.DamageGiven() * 0.2);
                    foreach (object item in Character.Enemies)
                    {
                        Persona hero = (Persona)item;
                        Character.PhysicalDamage(Character, hero, damageobj);
                        hero.Speed *= 0.5;
                        Character.BreakArmour(hero, (int)(hero.Armour * 0.5));
                    }
                    Character.PowerBuffPercent = 0.1;
                    break;
                case MasterCharacterList.SpiderCrustacean:
                    //go in the shell animation
                    Character.PutArmour(Character, true, (int)(Character.Armour * 0.8));
                    int rou = RoundInfo.RoundsPassed;

                    int[] ycount2 = new int[Character.Enemies.Count]; int[] Zcount2 = new int[Character.Enemies.Count];
                    int[] Acount2 = new int[Character.Enemies.Count]; int[] Bcount2 = new int[Character.Enemies.Count]; int[] Ccount2 = new int[Character.Enemies.Count];
                    int[] Dcount2 = new int[Character.Enemies.Count]; int[] Ecount2 = new int[Character.Enemies.Count]; int[] Fcount2 = new int[Character.Enemies.Count];
                    for (int i = 0; i < Character.Enemies.Count; i++)
                    {
                        Persona indiv2 = (Persona)Character.Enemies[i];
                        ycount2[i] = indiv2.Health;
                        Zcount2[i] = (int)indiv2.dodge;
                        Acount2[i] = (int)indiv2.Speed;
                        Bcount2[i] = (int)indiv2.CritC;
                        Ccount2[i] = indiv2.MagicRes;
                        Dcount2[i] = indiv2.Armour;
                        Ecount2[i] = indiv2.shield;
                        Fcount2[i] = (int)indiv2.Accuracy;
                    }
                    while (RoundInfo.RoundsPassed <= rou + 1)
                    {
                        for (int i = 0; i < Character.Enemies.Count; i++) //this here is meant to constantly check the health values
                        {
                            Persona ego = (Persona)Character.Enemies[i];
                            ego.Health = ycount2[i]; ego.dodge = Zcount2[i];
                            ego.Speed = Acount2[i]; ego.CritC = Bcount2[i];
                            ego.MagicRes = Ccount2[i]; ego.Armour = Dcount2[i];
                            ego.shield = Ecount2[i]; ego.Accuracy = Fcount2[i];
                        }
                    }
                    break;
                case MasterCharacterList.NecroBoar:
                    DamageObject damdamda = new DamageObject { DamageValue = Character.DamageGiven() };
                    Character.PhysicalDamage(Character, Target, damdamda);
                    int woisbleeding = 0;
                    foreach (object item in Character.Enemies) //I put this here cause i think the shark will attack anyone it smells having bleeding. Even itself and friends
                    {
                        Persona hero = (Persona)item;
                        foreach (AttackObject attack in hero.GetAttack(hero))
                        {
                            if ((attack.type == Enums.AttackType.Bleed) && attack.state == true)
                            {
                                woisbleeding++;
                                break;
                            }
                        }
                    }
                    if (woisbleeding == Character.Enemies.Count)
                    {
                        foreach (var item in Character.Enemies)
                        {
                            Character.Ignite(Character, item, damdamda.DamageValue);
                        }
                    }
                    break;
                case MasterCharacterList.ElderStag:
                    int mAch = RoundInfo.RoundsPassed; int count = 0;
                    Timer oboe; oboe = new Timer(); oboe.Elapsed += new ElapsedEventHandler(violin); oboe.Interval = 1000; oboe.Enabled = true;
                    void violin(object source2, ElapsedEventArgs e)
                    {
                        if (mAch < RoundInfo.RoundsPassed && count <= 2)
                        {
                            mAch = RoundInfo.RoundsPassed;
                            foreach (var item in Character.Allies)
                            {
                                Persona villian = (Persona)item;
                                villian.Speed += (int)(villian.Speed * 0.2);
                            }
                        }
                        if (mAch < RoundInfo.RoundsPassed && count <= 1)
                        {
                            mAch = RoundInfo.RoundsPassed;
                            foreach (var item in Character.Allies)
                            {
                                Persona villian = (Persona)item;
                                villian.PowerBuffPercent = 0.5; villian.MagiBuffPercent = 0.5;
                                villian.PolishWeapon(villian); villian.Chosen(villian);
                            }
                        }
                        if (RoundInfo.RoundDone == true) count++;
                    }

                    break;
                case MasterCharacterList.DevilBird:
                    object fVictim = Character.Enemies[UnityEngine.Random.Range(0, Character.Enemies.Count)]; object sVictim = Character.Enemies[UnityEngine.Random.Range(0, Character.Enemies.Count)];
                    object fTHIRDVictim = Character.Enemies[UnityEngine.Random.Range(0, Character.Enemies.Count)]; object foutrVictim = Character.Allies[UnityEngine.Random.Range(0, Character.Enemies.Count)];// because he also hurts his friend
                    List<object> heros = new List<object> { fVictim, sVictim, fTHIRDVictim };
                    foreach (var item in heros)
                    {
                        Character.MagicalDamage(Character, item);
                    }
                    Persona Expendable = (Persona)foutrVictim;
                    int storedhealth = Expendable.Health;
                    int damageede = (int)(Character.DamageGiven() * 0.5);
                    Character.MagicalDamage(Character, foutrVictim, damageede);
                    Character.HealVictim(Character, storedhealth - Expendable.Health);

                    break;
                case MasterCharacterList.DragonSloth:
                    Character.PhysicalDamage(Character, Target);
                    Target.dodge -= (int)(Target.dodge * 0.05);
                    if (Target.dodge == 0)
                    {
                        foreach (var item in Character.Enemies)
                        {
                            Character.Stun(Character, item, 1);
                        }
                    }
                    break;
                default:
                    break;
            }
        }
         */
        #endregion

        //the code below doesnt have all the names cause sometime the Boss simply doesnt have that ability so decision is called to try again as a default
        public void MagicalAttacks(object TargetInstance)
        {
            if (GameManager.Instance.activeEnemy != null && GameManager.Instance.roundInfo.inControl == WhoseInControl.CPU)
            { CharacterInstance = GameManager.Instance.activeEnemy.person; }
            Persona Character = CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            DamageObject damageobj = new DamageObject();

            switch (EnemyNames)
            {
                case MasterCharacterList.ElderStag:
                    //Attack 1
                    int ElderFist = (int)(Character.DamageGiven() * 0.4);
                    Persona Face = (Persona)Character.Enemies[UnityEngine.Random.Range(0, Character.Enemies.Count)];
                    Persona Face2 = (Persona)Character.Enemies[UnityEngine.Random.Range(0, Character.Enemies.Count)];
                    Persona Face3 = (Persona)Character.Enemies[UnityEngine.Random.Range(0, Character.Enemies.Count)];
                    List<Persona> Faces = new List<Persona> { Face, Face2, Face3 };
                    foreach (var item in Faces)
                    {
                        Character.MagicalDamage(Character, item, ElderFist);
                    }
                    foreach (var item in Character.Allies)
                    {
                        Persona fRIEND = (Persona)item;
                        fRIEND.Speed += (int)(fRIEND.Speed * 0.1);
                    }
                    break;
                case MasterCharacterList.DevilBird:
                    //Attack 2
                    Character.UniqueSkill(Character, Target); Character.Sleep(Character, Target);
                    break;
                default:
                    Bosses.Instance.Decision();
                    break;
            }
        }
        public void PhysicalAttacks(object TargetInstance)
        {
            if (GameManager.Instance.activeEnemy != null && GameManager.Instance.roundInfo.inControl == WhoseInControl.CPU)
            { CharacterInstance = GameManager.Instance.activeEnemy.person; }
            Persona Character = CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            DamageObject damageobj = new DamageObject();
            switch (EnemyNames)
            {

                case MasterCharacterList.HammerHead:
                    //Attack 1
                    foreach (object item in Character.Enemies)
                    {
                        PhysicalDamage(Character, item);
                        Tainted(Character, item, 1);
                    }
                    break;
                case MasterCharacterList.GreatWhite:
                    //Attack 2
                    foreach (object item in Character.Allies)
                    {
                        Persona villian = (Persona)item;
                        foreach (AttackObject attack in villian.GetAttack(villian))
                        {
                            if ((attack.type == Enums.AttackType.Bleed) && (attack.Victim == (object)villian)) //this basically asks if someone is bleeding by the hand of a villian
                            {
                                Character.CriticalChance = true; Character.PhysicalDamage(Character, Target);
                                Target.Armour -= (int)(Target.Armour * 0.5);
                                break;// so it stops checking for more bleeding attackObjects with this villan
                            }
                        }
                    }
                    foreach (object item in Character.Enemies) //I put this here cause i think the shark will attack anyone it smells having bleeding. Even itself and friends
                    {
                        Persona hero = (Persona)item;
                        foreach (AttackObject attack in hero.GetAttack(hero))
                        {
                            if ((attack.type == Enums.AttackType.Bleed) && (attack.Victim == (object)hero)) //this basically asks if someone is bleeding by the hand of a hero
                            {
                                Character.CriticalChance = true; Character.PhysicalDamage(Character, Target);
                                Target.Armour -= (int)(Target.Armour * 0.5);
                                break;// so it stops checking for more bleeding attackObjects with this hero
                            }
                        }
                    }
                    break;
                case MasterCharacterList.SpiderCrustacean:
                    int canceDa = UnityEngine.Random.Range(0, 101);
                    if (canceDa>50)
                    {
                        //Attack 2
                        Character.BrokenGaurdDeBuffPercent = 0.2;
                        Character.BrokenGuard(Character, Target, 1);
                    }
                    else
                    {
                        //Attack 1
                        Character.PhysicalDamage(Character, Target);
                        Character.CalmDeBuffPercent = 0.2;
                        Character.Calm(Character, Target, 1);
                    }
                    
                    break;
                case MasterCharacterList.NecroBoar:
                    //Attack 1
                    int RoundsDone = new int(); RoundsDone = RoundInfo.RoundsPassed; int count = 0;
                    System.Timers.Timer  myr2; myr2 = new System.Timers.Timer (); myr2.Elapsed += new ElapsedEventHandler(myEt); myr2.Interval = 1000; myr2.Enabled = true;
                    void myEt(object source2, ElapsedEventArgs e)
                    {
                        if (RoundsDone != RoundInfo.RoundsPassed && count < 3)
                        {
                            RoundsDone = RoundInfo.RoundsPassed;
                            Character.Bleed(Character, Target);
                            count++;
                        }
                        if (count == 3) myr2.Close();
                    }
                    break;
                case MasterCharacterList.DragonSloth:
                    //Attack 1
                    Persona Deictim = (Persona)Character.Enemies[UnityEngine.Random.Range(0, Character.Enemies.Count)];
                    Character.PhysicalDamage(Character, Deictim);
                    Deictim.dodge -= 5;
                    break;
                default:
                    Bosses.Instance.Decision();
                    break;
            }
        }
        public void TrueDamageAttacks(object TargetInstance)
        {
            if (GameManager.Instance.activeEnemy != null && GameManager.Instance.roundInfo.inControl == WhoseInControl.CPU)
            { CharacterInstance = GameManager.Instance.activeEnemy.person; }
            Persona Character = CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            DamageObject damageobj = new DamageObject();
            switch (EnemyNames)
            {
                case MasterCharacterList.HammerHead:
                    //Attack 3
                    int theDama = Character.DamageGiven();
                    damageobj.DamageValue = (int)(theDama * 0.3);
                    foreach (object item in Character.Enemies)
                    {
                        Character.TrueDamage(Character, item, damageobj);
                        damageobj.DamageValue = (int)(theDama * 0.35);
                        Character.Bleed(Character, item, damageobj);
                    }
                    break;
                case MasterCharacterList.GreatWhite:
                    //Attack 1
                    int enemyindexCount = Character.Enemies.Count;
                    damageobj.DamageValue = Character.DamageGiven();
                    int tea = UnityEngine.Random.Range(0, enemyindexCount);
                    Character.TrueDamage(CharacterInstance, Character.Enemies[tea], damageobj);
                    break;
                default:
                    Bosses.Instance.Decision();
                    break;
            }
        }
        public void Debuffs(object TargetInstance)
        {
            if (GameManager.Instance.activeEnemy != null && GameManager.Instance.roundInfo.inControl == WhoseInControl.CPU)
            { CharacterInstance = GameManager.Instance.activeEnemy.person; }
            Persona Character = CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            DamageObject damageobj = new DamageObject();
            switch (EnemyNames)
            {
                case MasterCharacterList.HammerHead:
                    //Attack 1
                    foreach (object item in Character.Enemies)
                    {
                        PhysicalDamage(Character, item);
                        Tainted(Character, item, 1);
                    }
                    break;
                case MasterCharacterList.GreatWhite:
                    //Attack 3
                    damageobj.DamageValue = (int)(Character.DamageGiven() * 0.2);
                    foreach (object item in Character.Enemies)
                    {
                        Persona hero = (Persona)item;
                        Character.PhysicalDamage(Character, hero, damageobj);
                        hero.Speed *= 0.5;
                        Character.BreakArmour(hero, (int)(hero.Armour * 0.5));
                    }
                    Character.PowerBuffPercent = 0.1;
                    break;
                case MasterCharacterList.SpiderCrustacean:
                    //go in the shell animation
                    Character.PutArmour(Character, true, (int)(Character.Armour * 0.8));
                    int rou = RoundInfo.RoundsPassed;

                    int[] ycount2 = new int[Character.Enemies.Count]; int[] Zcount2 = new int[Character.Enemies.Count]; 
                    int[] Acount2 = new int[Character.Enemies.Count]; int[] Bcount2 = new int[Character.Enemies.Count]; int[] Ccount2 = new int[Character.Enemies.Count];
                    int[] Dcount2 = new int[Character.Enemies.Count]; int[] Ecount2 = new int[Character.Enemies.Count]; int[] Fcount2 = new int[Character.Enemies.Count];
                    for (int i = 0; i < Character.Enemies.Count; i++)
                    {
                        Persona indiv2 = (Persona)Character.Enemies[i];
                        ycount2[i] = indiv2.Health;
                        Zcount2[i] = (int)indiv2.dodge;
                        Acount2[i] = (int)indiv2.Speed;
                        Bcount2[i] = (int)indiv2.CritC;
                        Ccount2[i] = indiv2.MagicRes;
                        Dcount2[i] = indiv2.Armour;
                        Ecount2[i] = indiv2.shield;
                        Fcount2[i] = (int)indiv2.Accuracy;
                    }
                    void SpiderCrustaceanDebuff1()
                    {
                        while (RoundInfo.RoundsPassed <= rou + 1)
                        {
                            for (int i = 0; i < Character.Enemies.Count; i++) //this here is meant to constantly check the health values
                            {
                                Persona ego = (Persona)Character.Enemies[i];
                                ego.Health = ycount2[i]; ego.dodge = Zcount2[i];
                                ego.Speed = Acount2[i]; ego.CritC = Bcount2[i];
                                ego.MagicRes = Ccount2[i]; ego.Armour = Dcount2[i];
                                ego.shield = Ecount2[i]; ego.Accuracy = Fcount2[i];
                            }
                        }
                    }
                    ThreadStart SpiderCrustaceanDebuffEffect1 = new ThreadStart(SpiderCrustaceanDebuff1);
                    Thread SpiderCrustaceanchildThread1 = new Thread(SpiderCrustaceanDebuffEffect1);
                    SpiderCrustaceanchildThread1.Start();
                    SpiderCrustaceanchildThread1.Abort();
                    
                    break;
                case MasterCharacterList.NecroBoar:
                    //Attack 3
                    DamageObject damdamda = new DamageObject { DamageValue = Character.DamageGiven() };
                    Character.PhysicalDamage(Character, Target, damdamda);
                    int woisbleeding = 0;
                    foreach (object item in Character.Enemies) //I put this here cause i think the shark will attack anyone it smells having bleeding. Even itself and friends
                    {
                        Persona hero = (Persona)item;
                        foreach (AttackObject attack in hero.GetAttack(hero))
                        {
                            if ((attack.type == Enums.AttackType.Bleed) && attack.state == true)
                            {
                                woisbleeding++;
                                break;
                            }
                        }
                    }
                    if (woisbleeding == Character.Enemies.Count)
                    {
                        foreach (var item in Character.Enemies)
                        {
                            Character.Ignite(Character, item, damdamda.DamageValue);
                        }
                    }
                    break;
                case MasterCharacterList.DevilBird:
                    //Attack 1
                    object fVictim = Character.Enemies[UnityEngine.Random.Range(0, Character.Enemies.Count)];
                    object SVictim = Character.Enemies[UnityEngine.Random.Range(0, Character.Enemies.Count)];
                    int roundsbaby = RoundInfo.RoundsPassed;
                    Character.Rooted(Character, fVictim, 1); Character.Burnt(Character, fVictim);
                    Character.Rooted(Character, SVictim, 1); Character.Burnt(Character, SVictim);

                    System.Timers.Timer  summer; summer = new System.Timers.Timer (); summer.Elapsed += new ElapsedEventHandler(vivaldiiii); summer.Interval = 1000; summer.Enabled = true;
                    void vivaldiiii(object source2, ElapsedEventArgs e)
                    {
                        if (roundsbaby + 1 == RoundInfo.RoundsPassed)
                        {
                            Character.Burnt(Character, fVictim);
                            Character.Burnt(Character, SVictim);
                            summer.Close();
                        }
                    }
                    break;
                case MasterCharacterList.DragonSloth:
                    //Attack 3
                    Character.PhysicalDamage(Character, Target);
                    Target.dodge -= (int)(Target.dodge * 0.05);
                    if (Target.dodge == 0)
                    {
                        foreach (var item in Character.Enemies)
                        {
                            Character.Stun(Character, item, 1);
                        }
                    }
                    break;
                default:
                    Bosses.Instance.Decision();
                    break;
            }
        }
        public void Buff(object TargetInstance)
        {
            if (GameManager.Instance.activeEnemy != null && GameManager.Instance.roundInfo.inControl == WhoseInControl.CPU)
            { CharacterInstance = GameManager.Instance.activeEnemy.person; }
            Persona Character = CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            DamageObject damageobj = new DamageObject();
            switch (EnemyNames)
            {
                case MasterCharacterList.HammerHead:
                    //Attack 2
                    int speedCount = 0;
                    foreach (object item in Character.Enemies)
                    {
                        Character.Stun(Character, item, 1);
                        Persona hero = (Persona)item;
                        foreach (DebuffObject debuff in hero.GetDebuffs())
                        {
                            if (debuff.type == Enums.debuffType.Stun)
                            {
                                speedCount++;
                                break;// so it stops checking for more stun Debuffs
                            }
                        }
                    }
                    Character.Speed += (int)(Character.Speed * 0.1 * speedCount);

                    break;
                case MasterCharacterList.NecroBoar:
                    //Attack 2
                    foreach (AttackObject attack in Target.GetAttack(Target))
                    {
                        if ((attack.type == Enums.AttackType.Bleed) && (attack.state == true)) //this basically asks if someone is bleeding 
                        {
                            Character.PowerBuffPercent = 0.5;
                            Character.PhysicalDamage(Character, Target);
                            foreach (var item in Character.Enemies)
                            {
                                Persona victim = (Persona)item;
                                if (victim != Target) Character.Bleed(Character, victim);
                            }
                            break;
                        }
                        else { Character.PhysicalDamage(Character, Target); }
                    }
                    break;
                case MasterCharacterList.ElderStag:
                    int canceDa3 = UnityEngine.Random.Range(1, 101);
                    if (canceDa3 > 50)
                    {
                        //Attack 2
                        int storedhealth = new int(); int count = 0; int lowest = new int();
                        for (int i = 0; i < Character.Allies.Count; i++)
                        {
                            Persona friend = (Persona)Character.Allies[i];
                            if (count == 0)
                            { storedhealth = friend.Health; count++; }
                            else
                            if (storedhealth > friend.Health)
                            {
                                lowest = i; storedhealth = friend.Health;
                            }
                        }
                        Persona weak = (Persona)Character.Allies[lowest];
                        weak.Health += weak.Health;
                    }
                    else
                    {
                        //Attack 3
                        int mAch = RoundInfo.RoundsPassed; int count = 0;
                        System.Timers.Timer  oboe; oboe = new System.Timers.Timer (); oboe.Elapsed += new ElapsedEventHandler(violin); oboe.Interval = 1000; oboe.Enabled = true;
                        void violin(object source2, ElapsedEventArgs e)
                        {
                            if (mAch < RoundInfo.RoundsPassed && count <= 2)
                            {
                                mAch = RoundInfo.RoundsPassed;
                                foreach (var item in Character.Allies)
                                {
                                    Persona villian = (Persona)item;
                                    villian.Speed += (int)(villian.Speed * 0.2);
                                }
                            }
                            if (mAch < RoundInfo.RoundsPassed && count <= 1)
                            {
                                mAch = RoundInfo.RoundsPassed;
                                foreach (var item in Character.Allies)
                                {
                                    Persona villian = (Persona)item;
                                    villian.PowerBuffPercent = 0.5; villian.MagiBuffPercent = 0.5;
                                    villian.PolishWeapon(villian); villian.Chosen(villian);
                                }
                            }
                            if (RoundInfo.RoundDone == true) count++;
                        }
                    }
                    break;
                case MasterCharacterList.DevilBird:
                    //Attack 3
                    object fVictim = Character.Enemies[UnityEngine.Random.Range(0, Character.Enemies.Count)]; object sVictim = Character.Enemies[UnityEngine.Random.Range(0, Character.Enemies.Count)];
                    object fTHIRDVictim = Character.Enemies[UnityEngine.Random.Range(0, Character.Enemies.Count)]; object foutrVictim = Character.Allies[UnityEngine.Random.Range(0, Character.Enemies.Count)];// because he also hurts his friend
                    List<object> heros = new List<object> { fVictim, sVictim, fTHIRDVictim };
                    foreach (var item in heros)
                    {
                        Character.MagicalDamage(Character, item);
                    }
                    Persona Expendable = (Persona)foutrVictim;
                    int storedhealth2 = Expendable.Health;
                    int damageede = (int)(Character.DamageGiven() * 0.5);
                    Character.MagicalDamage(Character, foutrVictim, damageede);
                    Character.HealVictim(Character, storedhealth2 - Expendable.Health);
                    break;
                case MasterCharacterList.DragonSloth:
                    //Attack 2
                    if (Target.dodge == 0)
                    {
                        damageobj.DamageValue = (int)(Character.DamageGiven() * 0.25);
                        Character.PhysicalDamage(Character, Target, damageobj);
                        if (UnityEngine.Random.Range(1, 100) < 50)
                        {
                            Character.PhysicalDamage(Character, Target);
                        }
                    }
                    break;
                default:
                    Bosses.Instance.Decision();
                    break;
            }
        }
    }
}
