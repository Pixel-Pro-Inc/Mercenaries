using System.Collections;
using System.Collections.Generic;
using static Assets.Scripts.Entities.Character.Persona;
using UnityEngine;
using System.Threading.Tasks;
using static Assets.Scripts.Models.Enums;
using Assets.Scripts.MonoBehaviours;
using Assets.Scripts.Entities.Character;
using System.Timers;
using Assets.Scripts.Models;
using System;

public class CardBehaviour : Card
{
    public SpeciesType species;
    public cardName cardname;

    public Vector3 GoTo;
    public bool moving;
    public Vector3 initial;

    //Create Card Interact with Target Script
    //Shouldn't we get cardname to equal to the sprite name?

    private void Start()
    {
        //GoTo = transform.position;
        initial = GoTo;
    }
    private void Update()
    {
        if (!moving)
            transform.position = Vector3.Lerp(transform.position, GoTo, .125f);
    }
    public void OnAction(object TargetInstance)
    {
        Persona CharacterInstance = null;
        Persona Target = (Persona)TargetInstance;
        //MageTemplate Target = (MageTemplate)TargetInstance;

        DamageObject damageObject = new DamageObject();
        if (GameManager.Instance.activeCharacter != null && GameManager.Instance.roundInfo.inControl == WhoseInControl.Human) CharacterInstance = GameManager.Instance.activeCharacter.person;

        if (GameManager.Instance.activeEnemy != null && GameManager.Instance.roundInfo.inControl == WhoseInControl.CPU) CharacterInstance = GameManager.Instance.activeEnemy.person;

        for (int i = 0; i < ((Persona)TargetInstance).GetDebuffs().Count; i++)
        {
            if(((Persona)TargetInstance).GetDebuffs()[i].type == debuffType.Sleep)
            {
                ((Persona)TargetInstance).RemoveDebuff(((Persona)CharacterInstance).GetDebuffs()[i]);
                foreach (var item in ((Persona)TargetInstance).GetDebuffs())
                {
                    if(item.type == debuffType.Stun)
                        ((Persona)TargetInstance).RemoveDebuff(item);
                }                
            }
        }

        switch (cardname)
        {
            case cardName.lionFirstCard:
                int lionBalls = Target.Health;
                CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                if (Target.Health < lionBalls) lionBalls -= Target.Health;
                CharacterInstance.ShieldUp(CharacterInstance, true, (int)(lionBalls * 0.3));
                foreach (var item in CharacterInstance.Allies)
                {
                    CharacterInstance.ShieldUp(item, true, (int)(lionBalls * 0.05));
                }
                break;
            case cardName.lionSecondCard:
                CharacterInstance.PhysicalDamage(CharacterInstance, Target); CharacterInstance.PowerBuffPercent = 0.3;
                CharacterInstance.PolishWeapon(CharacterInstance);
                break;
            case cardName.lionThirdCard:
                int lionBalls2 = Target.Health;
                CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                if (Target.Health < lionBalls2) lionBalls2 -= Target.Health;
                CharacterInstance.MagicRes += (int)(lionBalls2 * 0.1); CharacterInstance.Armour+= (int)(lionBalls2 * 0.1);
                break;
            case cardName.lionFourthCard:
                CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                bool done = false; int heaCache=0; int dog=0; int spit = 0; int crrr = 0; int Maga = 0; int Love = 0; int bass = 0; int acc = 0;

                Timer Nexttime;
                Nexttime = new Timer();
                // Tell the timer what to do when it elapses
                Nexttime.Elapsed += new ElapsedEventHandler(totaldramaIsland);
                // Set it to go off every one seconds
                Nexttime.Interval = 1000;
                // And start it        
                Nexttime.Enabled = true;
                foreach (var item in CharacterInstance.Allies)
                {
                    Persona fried = (Persona)item;
                    heaCache = (int)(fried.Health * 0.05); fried.Health += heaCache;
                    fried.dodge += dog=(int)(fried.dodge * 0.05);
                    fried.Speed += spit=(int)(fried.Speed * 0.05);
                    fried.CritC += crrr=(int)(fried.CritC * 0.05);
                    fried.MagicRes += Maga=(int)(fried.MagicRes * 0.05);
                    fried.Armour += Love=(int)(fried.Armour * 0.05);
                    fried.shield += bass=(int)(fried.shield * 0.05);
                    fried.Accuracy += acc=(int)(fried.Accuracy * 0.05);
                }
                void totaldramaIsland(object source2, ElapsedEventArgs e)
                {
                    if (RoundInfo.RoundDone == true)
                    { done = true;  Nexttime.Close(); }
                    if(done==true)
                    {
                        foreach (var item in CharacterInstance.Allies)
                        {
                            Persona fried = (Persona)item;
                            fried.Health -= heaCache;
                            fried.dodge -= dog;
                            fried.Speed -= spit;
                            fried.CritC -= crrr;
                            fried.MagicRes -= Maga;
                            fried.Armour -= Love;
                            fried.shield -= bass;
                            fried.Accuracy -= acc;
                        }
                    }
                }
                break;
            case cardName.lionFifthCard:
                Persona LionCHaracter = CharacterInstance;
                Timer Boom;
                Boom = new Timer();
                // Tell the timer what to do when it elapses
                Boom.Elapsed += new ElapsedEventHandler(Punch);
                // Set it to go off every one seconds
                Boom.Interval = 1000;
                // And start it        
                Boom.Enabled = true;

                void Punch(object source2, ElapsedEventArgs e)
                {
                    if (((Persona)Target.AttackSponser == LionCHaracter) &&(Target.Health==0))
                    {
                        int chin = UnityEngine.Random.Range(1, 101);
                        List<object> flea = new List<object>();

                        if (chin<=50)
                        {
                            foreach (var item in LionCHaracter.Enemies)
                            {
                                Persona ads = (Persona)item;
                                if (ads.Health< ads.Life * 0.3) flea.Add(item);
                            }
                            GameManager.Instance.activeCharacter.Flee(flea);
                        }
                        Boom.Close();
                    }
                     
                }
                break;
            case cardName.lionSixthCard: //apparently i shouldn't have done this cause it will work on a different system
                CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                int stunnedNumber = 0;
                if ((Target.Health / CharacterInstance.Health) < 0.80) CharacterInstance.Stun(CharacterInstance, Target,1);
                if((Target.Health / CharacterInstance.Health) < 0.5)
                {
                    foreach (var item in GameManager.Instance.enemyCharacters)
                    {
                        CharacterInstance.Stun(CharacterInstance, item,1);
                        Persona villian = item.GetComponent<CharacterBehaviour>().person;
                        foreach (var debuff in villian.GetDebuffs())
                        {
                            if (debuff.type==debuffType.Stun&& debuff.state==true)
                            {
                                stunnedNumber++;
                                break;
                            }
                        }
                    }
                    CharacterInstance.shield += (int)(CharacterInstance.shield * 0.1 * stunnedNumber);
                }
                break;
            case cardName.lionSeventhCard:
                int heaCache2 = 0; int dog2 = 0; int spit2= 0; int crrr2 = 0; int Maga2 = 0; int Lov2e = 0; int bass2 = 0; int acc2 = 0;
                foreach (var item in GameManager.Instance.enemyCharacters)
                {
                    Persona fried = item.GetComponentInChildren<CharacterBehaviour>().person;
                    fried.Health -= heaCache2= (int)(fried.Health * 0.05);
                    fried.dodge -= dog2 = (int)(fried.dodge * 0.05);
                    fried.Speed -= spit2 = (int)(fried.Speed * 0.05);
                    fried.CritC -= crrr2 = (int)(fried.CritC * 0.05);
                    fried.MagicRes -= Maga2 = (int)(fried.MagicRes * 0.05);
                    fried.Armour -= Lov2e = (int)(fried.Armour * 0.05);
                    fried.shield -= bass2 = (int)(fried.shield * 0.05);
                    fried.Accuracy -= acc2 = (int)(fried.Accuracy * 0.05);
                    CharacterInstance.PowerBuffPercent = 0.1;
                    CharacterInstance.PolishWeapon(CharacterInstance);
                }
                break;
            case cardName.lionEighthCard:
                CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                int gotit = RoundInfo.RoundsPassed;
                Timer Boom2;
                Boom2 = new Timer();
                // Tell the timer what to do when it elapses
                Boom2.Elapsed += new ElapsedEventHandler(Rebodouche);
                // Set it to go off every one seconds
                Boom2.Interval = 1000;
                // And start it        
                Boom2.Enabled = true;
                
                void Rebodouche(object source2, ElapsedEventArgs e)
                {
                    CharacterInstance.CriticalChance = true;
                    if (RoundInfo.RoundsPassed >= (gotit + 2))
                    {
                        Boom2.Close();
                    }
                }
                break;
            case cardName.lionNinthCard:
                int Armourbuffcount = new int();
                foreach (var item in CharacterInstance.Allies)
                {
                    Persona Bach = (Persona)item;
                    Armourbuffcount += Bach.GetBuff(Bach).Count;
                    Armourbuffcount += Bach.shield;
                }
                int increaseValueforArmour = (int)(CharacterInstance.Armour * 0.05 * Armourbuffcount);
                int increaseValueforMagi = (int)(CharacterInstance.MagicRes * 0.05 * Armourbuffcount);
                CharacterInstance.PutArmour(CharacterInstance,true, increaseValueforArmour);
                CharacterInstance.IncreaseMagicalResistance(CharacterInstance, true,increaseValueforMagi);
                break;
            case cardName.crocodileFirstCard:
                int ver = Target.Health; damageObject.DamageValue = CharacterInstance.DamageGiven();
                CharacterInstance.TrueDamage(CharacterInstance, Target, damageObject);
                int beryt = ver - Target.Health;
                if (beryt > 0 && Target.Health==0) CharacterInstance.Health += beryt;
                break;
            case cardName.crocodileSecondCard:
                int enemyindexCount = GameManager.Instance.enemyCharacters.Count;
                damageObject.DamageValue = CharacterInstance.DamageGiven();
                int tea = UnityEngine.Random.Range(0, enemyindexCount);
                int butter = UnityEngine.Random.Range(0, enemyindexCount);
                Persona first = GameManager.Instance.enemyCharacters[tea].GetComponentInChildren<CharacterBehaviour>().person;
                Persona second = GameManager.Instance.enemyCharacters[butter].GetComponentInChildren<CharacterBehaviour>().person;
                if (enemyindexCount==1)
                {
                    CharacterInstance.TrueDamage(CharacterInstance, first, damageObject);
                }
                else
                {
                    CharacterInstance.TrueDamage(CharacterInstance, first, damageObject);
                    damageObject.DamageValue = CharacterInstance.DamageGiven();
                    CharacterInstance.TrueDamage(CharacterInstance, second, damageObject);
                }
                break;
            case cardName.crocodileThirdCard:
                CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                CharacterInstance.BreakArmour(Target, (int)(Target.Armour* 0.5));
                break;
            case cardName.crocodileFourthCard:
                damageObject.DamageValue = CharacterInstance.DamageGiven();
                CharacterInstance.TrueDamage(CharacterInstance, Target, damageObject);
                break;
            case cardName.crocodileFifthCard:
                int roundcout = RoundInfo.RoundsPassed;
                int[] ycount = new int[GameManager.Instance.enemyCharacters.Count];// these store the initial values of health of enemies
                int[] Zcount = new int[GameManager.Instance.enemyCharacters.Count];// these store the new values of health enemies

                for (int i = 0; i < GameManager.Instance.enemyCharacters.Count; i++) //this is to store the health of each enemy
                {
                    Persona indiv = GameManager.Instance.enemyCharacters[i].GetComponentInChildren<CharacterBehaviour>().person;
                    ycount[i] = indiv.Health;
                }

                void CrodocidleFith()
                {
                    while (RoundInfo.RoundsPassed <= roundcout + 2)//basically polishes for this and the next turn, so this round+enemyround+nextroundafter
                    {
                        CharacterInstance.PolishWeapon(CharacterInstance);
                    }
                }
                System.Threading.ThreadStart CrodocidleFithThread = new System.Threading.ThreadStart(CrodocidleFith);
                System.Threading.Thread CrodocidleFithchildThread3 = new System.Threading.Thread(CrodocidleFithThread);

                Timer Bethoven;
                Bethoven = new Timer();
                // Tell the timer what to do when it elapses
                Bethoven.Elapsed += new ElapsedEventHandler(fifth);
                // Set it to go off every one seconds
                Bethoven.Interval = 1000;
                // And start it        
                Bethoven.Enabled = true;

                void fifth(object source2, ElapsedEventArgs e)
                {
                    for (int i = 0; i < GameManager.Instance.enemyCharacters.Count; i++) //this here is meant to only populate the z array without finding anything new
                    {
                        Persona ego = GameManager.Instance.enemyCharacters[i].GetComponentInChildren<CharacterBehaviour>().person;
                        Zcount[i] = ego.Health;
                    }
                    for (int i = 0; i < GameManager.Instance.enemyCharacters.Count; i++)//this is meant to actually do the logic
                    {
                        Persona tribe = GameManager.Instance.enemyCharacters[i].GetComponentInChildren<CharacterBehaviour>().person; //this is cause we need each enemies attacksponser info to see if it matches
                        if ((ycount[i] != Zcount[i]) && ((Persona)tribe.AttackSponser == CharacterInstance))// checks health and attack sponser
                        {
                            CrodocidleFithchildThread3.Start();
                            
                        }
                    }
                    if (RoundInfo.RoundsPassed == roundcout + 2)
                    {
                        Bethoven.Close();
                        CrodocidleFithchildThread3.Abort();
                    }
                }
                break;
            case cardName.crocodileSixthCard:
                CharacterInstance.Bleed(CharacterInstance, Target);
                break;
            case cardName.crocodileSeventhCard:
                CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                if(Target.Health==0)
                {
                    int enemyindexCount2 = GameManager.Instance.enemyCharacters.Count;
                    int bread = UnityEngine.Random.Range(0, enemyindexCount2);
                    CharacterInstance.Bleed(CharacterInstance, GameManager.Instance.enemyCharacters[bread]);
                }
                break;
            case cardName.crocodileEighthCard:
                damageObject.DamageValue = (int)(CharacterInstance.DamageGiven() * 0.4);
                int heCache = 0;
                foreach (var item in GameManager.Instance.enemyCharacters)
                {
                    CharacterInstance.TrueDamage(CharacterInstance, item.GetComponentInChildren<CharacterBehaviour>().person, damageObject);
                    heCache += damageObject.DamageValue;
                }
                CharacterInstance.Health += heCache;
                break;
            case cardName.crocodileNinthCard:
                double slight= CharacterInstance.Speed;
                CharacterInstance.Speed += slight;
                Timer Chpin; Chpin = new Timer();Chpin.Elapsed += new ElapsedEventHandler(impro); Chpin.Interval = 1000; Chpin.Enabled = true;
                void impro(object source2, ElapsedEventArgs e)
                {
                    if (RoundInfo.RoundDone == true) CharacterInstance.Speed -= slight; Chpin.Close();
                }
                
                break;
            case cardName.fishFirstCard:

                Vector3 TargetPosition=new Vector3();
                Vector3 Mozarttt = new Vector3(); //Meant to be the position behind the target

                GameObject Aim = (GameObject)TargetInstance;
                GameObject Fire=new GameObject(); //supposed to be the instance of the next target

                Persona Bullseye;// what we will actually use to work on the target

                for (int i = 0; i < GameManager.Instance.enemyCharacters.Count; i++) //checks through the list of characters to see which one is the targets position
                {
                    if (GameManager.Instance.enemyCharacters[i].transform.GetChild(0).localPosition == Aim.transform.position)
                    {
                        TargetPosition = GameManager.Instance.enemyCharacters[i].transform.GetChild(0).localPosition;
                        Mozarttt = TargetPosition - new Vector3(2.0f, 0.0f, 0.0f);// the position behind the target, the different positions are separated by 2 on x axis
                    }
                }
                for (int i = 0; i < GameManager.Instance.enemyCharacters.Count; i++) //This is so i can make sure it waits to get the position of the target first
                {
                    if (GameManager.Instance.enemyCharacters[i].transform.GetChild(0).localPosition == Mozarttt)
                    {
                        Fire = GameManager.Instance.enemyCharacters[i];
                    }
                }
                Bullseye = Fire.GetComponent<Persona>();
                CharacterInstance.CriticalChance = true;
                CharacterInstance.PhysicalDamage(CharacterInstance, Bullseye);
                
                break;
            case cardName.fishSecondCard:
                CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                break;
            case cardName.fishThirdCard:
                if ((Target.Health/ CharacterInstance.Health) <=0.85)
                {
                    int stored = Target.Health;
                    CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                    int final = (stored - Target.Health); if (final <=0) final = 0;
                    CharacterInstance.Health += 2 * final;
                }
                break;
            case cardName.fishFourthCard:
                CharacterInstance.PolishWeapon(CharacterInstance);
                if (CharacterInstance.Health == 100) CharacterInstance.BreakArmour(Target, 20);
                break;
            case cardName.fishFifthCard:
                CharacterInstance.PhysicalDamage(CharacterInstance, Target); int getem = RoundInfo.RoundsPassed + 1;
                Timer mytocon;
                mytocon = new Timer();
                // Tell the timer what to do when it elapses
                mytocon.Elapsed += new ElapsedEventHandler(dria);
                // Set it to go off every one seconds
                mytocon.Interval = 1000;
                // And start it        
                mytocon.Enabled = true;

                void dria(object source2, ElapsedEventArgs e)
                {
                    if (RoundInfo.RoundsPassed == getem)
                    { 
                        CharacterInstance.GetComponent<CharacterBehaviour>().DrawExtraCard(2);
                        mytocon.Close();
                    }
                }
                break;
            case cardName.fishSixthCard:
                if(Target.Health==100)
                {
                    CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                    CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                }
                if(Target.Health<50)
                {
                    int guut= CharacterInstance.DamageGiven()/2;
                    damageObject.DamageValue = guut;
                    CharacterInstance.PhysicalDamage(CharacterInstance, Target, damageObject);
                }
                if (Target.Health<100&&Target.Health>50)
                {
                    CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                }
                break;
            case cardName.fishSeventhCard:
                
                int buffCount= Target.GetDebuffs().Count;
                damageObject.DamageValue = CharacterInstance.DamageGiven()*5;
                if(buffCount != 0)
                {
                    CharacterInstance.PhysicalDamage(CharacterInstance, Target, damageObject);
                    CharacterInstance.Sleep(CharacterInstance, CharacterInstance);
                }
                 
                break;
            case cardName.fishEighthCard:
                CharacterInstance.AgileBUffPercent = 0.2; CharacterInstance.Agile(CharacterInstance,true);
                break;
            case cardName.fishNinthCard:
                CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                float egg= UnityEngine.Random.Range(1, 101);
                if(egg>=50) CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                break;
            case cardName.salamanderFirstCard:
                Debug.Log("Not done or special card");
                break;
            case cardName.salamanderSecondCard:
                int eggplant = UnityEngine.Random.Range(0, CharacterInstance.Enemies.Count); int peach = UnityEngine.Random.Range(0, CharacterInstance.Enemies.Count);
                if (CharacterInstance.Enemies.Count==1)
                {
                    CharacterInstance.PhysicalDamage(CharacterInstance, CharacterInstance.Enemies[eggplant]);
                }
                else
                {
                    CharacterInstance.PhysicalDamage(CharacterInstance, CharacterInstance.Enemies[eggplant]); CharacterInstance.PhysicalDamage(CharacterInstance, CharacterInstance.Enemies[peach]);
                }
                int saint = RoundInfo.RoundsPassed;
                Timer Crazy;
                Crazy = new Timer();
                // Tell the timer what to do when it elapses
                Crazy.Elapsed += new ElapsedEventHandler(Midnight);
                //Set it to go off every one seconds
                Crazy.Interval = 1000;
                // And start it        
                Crazy.Enabled = true;

                void Midnight(object source2, ElapsedEventArgs e)
                {
                    if (RoundInfo.RoundsPassed == saint + 1)
                    {
                        CharacterInstance.GetComponent<CharacterBehaviour>().DrawExtraCard(2);
                    }
                }
                int pathogen= (int)(0.95 * CharacterInstance.Life);
                CharacterInstance.Life-= pathogen;
                CharacterInstance.Health -= pathogen;
                break;
            case cardName.salamanderThirdCard:
                CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                CharacterInstance.PowerBuffPercent = 0.3;
                CharacterInstance.PolishWeapon(CharacterInstance);
                break;
            case cardName.salamanderFourthCard:
                int enemyindexCount3 = GameManager.Instance.enemyCharacters.Count;
                int breadTRA = UnityEngine.Random.Range(0, enemyindexCount3); int cond = UnityEngine.Random.Range(0, enemyindexCount3);
                object fiaas = GameManager.Instance.enemyCharacters[breadTRA].GetComponentInChildren<CharacterBehaviour>().person;
                object aallss = GameManager.Instance.enemyCharacters[cond].GetComponentInChildren<CharacterBehaviour>().person;

                if (enemyindexCount3==1)
                {
                    CharacterInstance.PhysicalDamage(CharacterInstance, fiaas); CharacterInstance.WeakGrip(CharacterInstance, fiaas, 1);
                }
                else
                {
                    CharacterInstance.PhysicalDamage(CharacterInstance, fiaas); CharacterInstance.WeakGrip(CharacterInstance, fiaas, 1);
                    CharacterInstance.PhysicalDamage(CharacterInstance, aallss); CharacterInstance.WeakGrip(CharacterInstance, aallss, 1);
                }
                CharacterInstance.Health -= (int)(CharacterInstance.Life * 0.05); //cause apparently it costs 5% of the max health which i assume is the health of a warrior

                break;
            case cardName.salamanderFifthCard:
                Debug.Log("Not done or special card");
                break;
            case cardName.salamanderSixthCard:
                Debug.Log("Not done or special card");

                /*
                 * CharacterInstance.PhysicalDamage(CharacterInstance, Target); CharacterInstance.Stun(CharacterInstance, Target,1);
                 */
                break;
            case cardName.salamanderSeventhCard:
                int roundcount = RoundInfo.RoundsPassed; int healthdrain = (int)(CharacterInstance.Health * 0.1);
                CharacterInstance.Health -= healthdrain;
                CharacterInstance.Armour += healthdrain * 2;

                Timer my;
                my = new Timer();
                // Tell the timer what to do when it elapses
                my.Elapsed += new ElapsedEventHandler(myEvent12);
                // Set it to go off every one seconds
                my.Interval = 1000;
                // And start it        
                my.Enabled = true;
               
                void myEvent12(object source2, ElapsedEventArgs e)
                {
                    if (RoundInfo.RoundsPassed ==roundcount+1)
                    {
                        CharacterInstance.Health -= healthdrain;
                        CharacterInstance.Armour += healthdrain * 2; 
                        my.Close();
                    }
                }
                break;
            case cardName.salamanderEighthCard:
                int enemyCount = GameManager.Instance.enemyCharacters.Count;
                damageObject.DamageValue = CharacterInstance.DamageGiven();
                int puuley = UnityEngine.Random.Range(0, enemyCount);
                int levvrr = UnityEngine.Random.Range(0, enemyCount);
                if (GameManager.Instance.enemyCharacters.Count>1)
                {
                    Persona firstone = GameManager.Instance.enemyCharacters[puuley].GetComponentInChildren<CharacterBehaviour>().person;
                    Persona secondone = GameManager.Instance.enemyCharacters[levvrr].GetComponentInChildren<CharacterBehaviour>().person;
                    CharacterInstance.TrueDamage(CharacterInstance, firstone, damageObject);
                    damageObject.DamageValue = CharacterInstance.DamageGiven();
                    CharacterInstance.TrueDamage(CharacterInstance, secondone, damageObject);
                }
                Persona firstone2 = GameManager.Instance.enemyCharacters[puuley].GetComponentInChildren<CharacterBehaviour>().person;
                damageObject.DamageValue = CharacterInstance.DamageGiven();
                CharacterInstance.TrueDamage(CharacterInstance, firstone2, damageObject);
                
                 int numberofDebuff= new int();
                 foreach (var item in GameManager.Instance.enemyCharacters)
                 {
                    Persona judas= item.GetComponent<CharacterBehaviour>().person;
                    numberofDebuff+=judas.GetDebuffs().Count;
                 }
                CharacterInstance.Health+= (int)(CharacterInstance.Life*0.02*numberofDebuff);
                 
                break;
            case cardName.salamanderNinthCard:
                damageObject.DamageValue = CharacterInstance.DamageGiven() / 2;
                int eCount3 = GameManager.Instance.enemyCharacters.Count;
                int digaoogaoo = UnityEngine.Random.Range(0, eCount3); int diguyy = UnityEngine.Random.Range(0, eCount3); //random index of the enemy
                object firthealth = GameManager.Instance.enemyCharacters[digaoogaoo].GetComponentInChildren<CharacterBehaviour>().person; object sechealths = GameManager.Instance.enemyCharacters[diguyy].GetComponentInChildren<CharacterBehaviour>().person;

                if (GameManager.Instance.enemyCharacters.Count > 1)
                {
                    CharacterInstance.PhysicalDamage(CharacterInstance, firthealth, damageObject); CharacterInstance.PhysicalDamage(CharacterInstance, sechealths, damageObject);
                    CharacterInstance.WeakGrip(CharacterInstance, firthealth, 1); CharacterInstance.WeakGrip(CharacterInstance, sechealths, 1);
                }
                CharacterInstance.PhysicalDamage(CharacterInstance, firthealth, damageObject); CharacterInstance.WeakGrip(CharacterInstance, firthealth, 1);
                break;
            case cardName.frogFirstCard:
                float bacon = UnityEngine.Random.Range(1, 101);
                if (bacon >= 50) CharacterInstance.ProtectionSponser = Target;
                break;
            case cardName.frogSecondCard:
                CharacterInstance.AgileBUffPercent = 0.5;
                Target.AgileBUffPercent = 0.5;
                CharacterInstance.Agile(CharacterInstance,true);Target.Agile(Target,true);
                break;
            case cardName.frogThirdCard:
                int stored1 = Target.Health;
                int final1 = 0;
                Timer myTimer2;
                myTimer2 = new Timer();
                // Tell the timer what to do when it elapses
                myTimer2.Elapsed += new ElapsedEventHandler(myEvent);
                // Set it to go off every one seconds
                myTimer2.Interval = 1000;
                // And start it        
                myTimer2.Enabled = true;

                //this is supposed to add to a list up to 5, of the last person to cause you damage. Its called in the constructor and hopefully runs the whole time. 

                void myEvent(object source2, ElapsedEventArgs e)
                {
                    if (final1 == 0)
                    {
                        if (Target.Health <= stored1)
                        {
                            final1 = (stored1 - Target.Health);
                            CharacterInstance.HealBuffPercent = (double)0.2 * final1;
                            CharacterInstance.HealVictim(CharacterInstance, Target);
                            stored1 = Target.Health;
                            myTimer2.Close();
                        }
                    }
                }
                break;
            case cardName.frogFourthCard:
                CharacterInstance.Blight(CharacterInstance, TargetInstance, 4, CharacterInstance.DamageGiven());
                break;
            case cardName.frogFifthCard:
                int ene=CharacterInstance.RevengeDa.Count;
                if (ene>1)
                {
                    object firstgrudge = CharacterInstance.RevengeDa.IndexOf(ene - 1);
                    object Secondgrudge = CharacterInstance.RevengeDa.IndexOf(ene-2);
                    CharacterInstance.Stun(CharacterInstance, firstgrudge, 1); CharacterInstance.MagicalDamage(CharacterInstance, firstgrudge, 1);
                    CharacterInstance.Stun(CharacterInstance, Secondgrudge, 1); CharacterInstance.MagicalDamage(CharacterInstance, Secondgrudge, 1);

                }
                else
                {
                    object firstgrudge = CharacterInstance.RevengeDa.IndexOf(ene - 1);
                    CharacterInstance.Stun(CharacterInstance, firstgrudge, 1); CharacterInstance.MagicalDamage(CharacterInstance, firstgrudge, 1);
                }
                break;
            case cardName.frogSixthCard:
                Debug.Log("Not done or special card");
                CharacterInstance.GetComponent<CharacterBehaviour>().DrawExtraCard(2);
                break;
            case cardName.frogSeventhCard:
                int enee3 = CharacterInstance.RevengeDa.Count;
                object fgrudge2 = CharacterInstance.RevengeDa.IndexOf(0);
                object Sgrudge2 = CharacterInstance.RevengeDa.IndexOf(1);
                if (enee3 > 1)
                {
                    CharacterInstance.Stun(CharacterInstance, fgrudge2, 1);
                    CharacterInstance.Stun(CharacterInstance, Sgrudge2, 1);
                    CharacterInstance.PutArmour(CharacterInstance, true, (int)(CharacterInstance.Armour * 0.1));
                    CharacterInstance.Blight(CharacterInstance, fgrudge2, 2, CharacterInstance.DamageGiven());
                    CharacterInstance.Blight(CharacterInstance, Sgrudge2, 2, CharacterInstance.DamageGiven());
                }
                else
                {
                    CharacterInstance.Stun(CharacterInstance, fgrudge2, 1);
                    CharacterInstance.PutArmour(CharacterInstance, true, (int)(CharacterInstance.Armour * 0.1));
                    CharacterInstance.Blight(CharacterInstance, Sgrudge2, 2, CharacterInstance.DamageGiven());
                }
                break;
            case cardName.frogEighthCard:
                int damageDealt = CharacterInstance.DamageGiven(); //needed later in this switch case
                damageObject.DamageValue = damageDealt;
                CharacterInstance.PhysicalDamage(CharacterInstance, Target, damageObject);
                bool didyougethim = false;
                foreach (var Individual in CharacterInstance.Allies)
                {
                    Persona goodietwoshoes = (Persona)Individual;
                    foreach (AttackObject item in goodietwoshoes.GetAttack(goodietwoshoes))
                    {
                        if (item.type == AttackType.Blight && item.state == true/*this is important cause we only want active blight*/ && (object)item.Victim == Target)
                        {
                            didyougethim = true;
                            foreach (DebuffObject serves in Target.GetDebuffs())
                            {
                                switch (serves.type)
                                {
                                    case debuffType.Slow:
                                        CharacterInstance.Slow(CharacterInstance, Target, 1);
                                        break;
                                    case debuffType.Rooted:
                                        CharacterInstance.Rooted(CharacterInstance, Target, 1);
                                        break;
                                    case debuffType.WeakGrip:
                                        CharacterInstance.WeakGrip(CharacterInstance, Target, 1);
                                        break;
                                    case debuffType.Exiled:
                                        CharacterInstance.Exiled(CharacterInstance, Target, 1);
                                        break;
                                    case debuffType.Marked:
                                        CharacterInstance.Marked(CharacterInstance, Target, 1);
                                        break;
                                    case debuffType.Calm:
                                        CharacterInstance.Calm(CharacterInstance, Target, 1);
                                        break;
                                    case debuffType.BrokenGaurd:
                                        CharacterInstance.BrokenGuard(CharacterInstance, Target, 1);
                                        break;
                                    case debuffType.Burnt:
                                        CharacterInstance.Burnt(CharacterInstance, Target, 1);
                                        break;
                                    case debuffType.Stun:
                                        CharacterInstance.Stun(CharacterInstance, Target, 1);
                                        break;
                                    case debuffType.Freeze:
                                        CharacterInstance.Freeze(CharacterInstance, Target, 1);
                                        break;
                                    case debuffType.Cold:
                                        CharacterInstance.Cold(CharacterInstance, Target, 1);
                                        break;
                                    case debuffType.Blinded:
                                        CharacterInstance.Blinded(CharacterInstance, Target, 1);
                                        break;
                                    case debuffType.Tainted:
                                        CharacterInstance.Tainted(CharacterInstance, Target, 1);
                                        break;
                                    case debuffType.Sleep:
                                        CharacterInstance.Sleep(CharacterInstance, Target);
                                        break;
                                    case debuffType.Hungry:
                                        CharacterInstance.Hungry(CharacterInstance, Target);
                                        break;
                                    case debuffType.UnHealthy:
                                        CharacterInstance.Unhealthy(CharacterInstance, Target);
                                        break;
                                    case debuffType.GodsAnger:
                                        CharacterInstance.GodsAnger(CharacterInstance, Target.Allies);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            break; //so it stops check the rest of attacks for that hero
                        }
                    }
                    if (didyougethim == true) break; //so it stops checking the rest of the heros
                }
                if (didyougethim == false)// basically if blighted isnt currently active on target
                {
                    CharacterInstance.Blight(CharacterInstance, Target, 5, damageDealt);
                    CharacterInstance.HealVictim(CharacterInstance, (int)(damageDealt * 0.5));
                    foreach (var item in CharacterInstance.Allies)
                    {
                        CharacterInstance.HealVictim(item, (int)(damageDealt * 0.25));
                    }
                }

                break;
            case cardName.frogNinthCard:
                int totalEnemyHealth = 0;
                int indienemyhealth;
                int count = 0;
                Persona lowestenemy = new Persona();
                foreach (var item in GameManager.Instance.enemyCharacters)
                {
                    Persona enemy= item.GetComponentInChildren<CharacterBehaviour>().person;
                    indienemyhealth = enemy.Health;
                    if(count==0)lowestenemy = enemy;  count++; //Necessary since lowestenemy hasn't been set yet
                    if (indienemyhealth < lowestenemy.Health) lowestenemy = enemy;
                    totalEnemyHealth += enemy.Health;
                }
                totalEnemyHealth = (int)(totalEnemyHealth * 0.1);
                CharacterInstance.Blight(CharacterInstance, lowestenemy, 3,totalEnemyHealth);
                break;
            case cardName.tritonFirstCard:
                int war=0;
                foreach (var item in CharacterInstance.Allies) 
                {
                    if ((item.GetType() == typeof(WarriorTemplate)) || (item.GetType() == typeof(TankWarriorTemplate))) war++;
                }
                foreach (var item in GameManager.Instance.enemyCharacters) 
                {
                    if ((item.GetType() == typeof(WarriorTemplate)) || (item.GetType() == typeof(TankWarriorTemplate))) war++;
                }
                CharacterInstance.ShieldUp(CharacterInstance, true, (int)(CharacterInstance.shield*0.1)*war);
                break;
            case cardName.tritonSecondCard:
                int gethee = (int)(CharacterInstance.Life * 0.1);
                foreach (var item in CharacterInstance.Allies) CharacterInstance.ShieldUp(item, true, gethee);
                break;
            case cardName.tritonThirdCard:
                if (CharacterInstance.shield > 0)
                {
                    CharacterInstance.PowerBuffPercent = 1; CharacterInstance.PolishWeapon(CharacterInstance);
                    CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                }
                else { CharacterInstance.PhysicalDamage(CharacterInstance, Target); }
                break;
            case cardName.tritonFourthCard:
                CharacterInstance.ShieldUp(CharacterInstance, true, CharacterInstance.shield * 2);
                CharacterInstance.Provoking(CharacterInstance);
                break;
            case cardName.tritonFifthCard:
                if (CharacterInstance.shield <= 0) CharacterInstance.ShieldUp(CharacterInstance, true, (int)(CharacterInstance.Health*0.15));
                else { CharacterInstance.PhysicalDamage(CharacterInstance, Target); }
                break;
            case cardName.tritonSixthCard:
                CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                if (CharacterInstance.shield > 0) CharacterInstance.BreakArmour(Target, CharacterInstance.DamageGiven());
                break;
            case cardName.tritonSeventhCard:
                int nextRoundmaybe = 0; nextRoundmaybe = RoundInfo.RoundsPassed;
                int collectiveesscence = 0; collectiveesscence = CharacterInstance.Health + CharacterInstance.shield + CharacterInstance.Armour;

                Timer myr2;
                myr2 = new Timer();
                // Tell the timer what to do when it elapses
                myr2.Elapsed += new ElapsedEventHandler(myEt);
                // Set it to go off every one seconds
                myr2.Interval = 1000;
                // And start it        
                myr2.Enabled = true;
                void myEt(object source2, ElapsedEventArgs e)
                {
                    if (RoundInfo.RoundsPassed == (nextRoundmaybe + 1))//basically checks if the round has passed
                    {
                        collectiveesscence -= CharacterInstance.Health + CharacterInstance.shield + CharacterInstance.Armour;
                        damageObject.DamageValue = collectiveesscence;
                        CharacterInstance.PhysicalDamage(CharacterInstance, CharacterInstance.AttackSponser, damageObject);
                        myr2.Close();
                    }
                    else { }
                }
               
                break;
            case cardName.tritonEighthCard:
                TankWarriorTemplate trr = new TankWarriorTemplate(); Debug.Log("This card throws a waring cause we use new Tankwarrior to get an initial shield value. Unity doesn't actually like that");
                if (CharacterInstance.shield <= 0) CharacterInstance.ShieldUp(CharacterInstance, true,(int)(trr.shield * 0.2));
                if(CharacterInstance.shield >0)
                {
                    int geeer = CharacterInstance.shield;
                    CharacterInstance.shield -= geeer; //removes all shield
                    damageObject.DamageValue = geeer+CharacterInstance.DamageGiven();
                    CharacterInstance.PhysicalDamage(CharacterInstance, Target, damageObject);
                }
                break;
            case cardName.tritonNinthCard:
                CharacterInstance.shield += CharacterInstance.shield;
                int enemycount = 0;
                foreach (var item in GameManager.Instance.enemyCharacters)
                {
                    Persona i = item.GetComponentInChildren<CharacterBehaviour>().person;
                    if (i.Health > 0) enemycount++;
                }
                CharacterInstance.shield += (int)(CharacterInstance.shield*0.1*enemycount);
                break;
            default:
                break;
        }

        //turn played
        if (GameManager.Instance.roundInfo.inControl == WhoseInControl.Human)
        {
            if (GameManager.Instance.activeCharacter.consecutiveTurns != 0 && GameManager.Instance.activeCharacter.extraTurn)
            {
                GameManager.Instance.activeCharacter.consecutiveTurns--;
                Destroy(gameObject);
                return;
            }

            GameManager.Instance.activeCharacter.turnUsed = true;

            DeckPopulate.Instance.HideDeck();
            GameManager.Instance.CheckRoundDone();

            Destroy(gameObject);
        }        
    }
    public void OnMouseDown()
    {
        
    }
    float tapTimer = 0;
    public void OnMouseUp()
    {
        if (!CardDescriptionManager.Instance.cardDetailsView.activeSelf)
        {
            if(tapTimer < .3f)
                if (!CardDescriptionManager.Instance.cardDetailsView.activeSelf)
                    CardDescriptionManager.Instance.CardDetailsShow(GetComponent<SpriteRenderer>().sprite);

            tapTimer = 0;

            GameObject obj = GetClosestCharacter();
            float distance = DistanceToCard(obj.transform.GetChild(0).position, transform.position);

            CharacterBehaviour characterBehaviour = obj.transform.GetChild(0).GetComponentInChildren<CharacterBehaviour>();

            if (distance < 0.89f)
            {
                OnAction(characterBehaviour.person);
            }

            moving = false;

            GoTo = initial;
        }            
    }
    public void OnMouseDrag()
    {
        if (!CardDescriptionManager.Instance.cardDetailsView.activeSelf)
        {
            tapTimer += Time.deltaTime;

            moving = true;

            Vector3 camPos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, transform.position.z);

            transform.position = camPos;

            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);

            GameObject obj = GetClosestCharacter();
            float distance = DistanceToCard(obj.transform.GetChild(0).position, transform.position);

            if (distance < 0.89f)
            {
                obj.transform.GetChild(0).GetComponentInChildren<CharacterBehaviour>().SetColor(new Color(255, 235, 162, 255));
            }
            else
            {
                obj.transform.GetChild(0).GetComponentInChildren<CharacterBehaviour>().SetColor(new Color(255, 255, 255, 255));
            }
        }            
    }
    public List<float> playerDistances = new List<float>();
    public List<float> enemyDistances = new List<float>();
    public GameObject GetClosestCharacter()
    {
        #region Calculate Closest Character
        List<GameObject> playerCharacters = GameManager.Instance.playerCharacters;
        List<GameObject> enemyCharacters = GameManager.Instance.enemyCharacters;

        /*List<float>*/playerDistances = new List<float>();
        /*List<float>*/enemyDistances = new List<float>();

        for (int i = 0; i < playerCharacters.Count; i++)
        {
            playerDistances.Add(DistanceToCard(playerCharacters[i].transform.GetChild(0).position, transform.position));
        }
        for (int i = 0; i < enemyCharacters.Count; i++)
        {
            enemyDistances.Add(DistanceToCard(enemyCharacters[i].transform.GetChild(0).position, transform.position));
        }

        int shortestDistPlayer = 0;
        int shortestDistEnemy = 0;

        float n = 0;
        int index = 0;

        if (playerDistances.Count > 1)
        {
            n = Mathf.Min(playerDistances.ToArray());
            index = playerDistances.IndexOf(n);
        }        

        shortestDistPlayer = index;

        n = 0;
        index = 0;

        if(enemyDistances.Count > 1)
        {
            n = Mathf.Min(enemyDistances.ToArray());
            index = enemyDistances.IndexOf(n);
        }        

        shortestDistEnemy = index;

        float x = Mathf.Min(playerDistances[shortestDistPlayer], enemyDistances[shortestDistEnemy]);

        GameObject closestObject = null;

        if (x == playerDistances[shortestDistPlayer])
        {
            closestObject = playerCharacters[shortestDistPlayer];
        }
        else
        {
            closestObject = enemyCharacters[shortestDistEnemy];
        }

        return closestObject;

        #endregion
    }
    public float DistanceToCard(Vector2 character, Vector2 card)
    {
        return Math.Abs(Vector2.Distance(character, card));
    }
}