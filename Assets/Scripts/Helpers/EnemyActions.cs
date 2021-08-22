using Assets.Scripts.Entities.Character;
using Assets.Scripts.Interface;
using System.Timers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.MonoBehaviours;
using Assets.Scripts.Models;

namespace Assets.Scripts.Helpers
{
    class EnemyActions: Persona,IEnemyAction
    {
        MasterCharacterList EnemyNames;
        public void PassiveEnemyAbility(object CharacterInstance)
        {
            Persona Character= (Persona)CharacterInstance;
            switch (EnemyNames)
            {
                case MasterCharacterList.HammerHead:

                    while (Character.Health <= (int)(Character.Life * 0.25))
                    {
                        int fordo = RoundInfo.RoundsPassed;
                        Character.PowerBuffPercent   = 2;
                        if (RoundInfo.RoundsPassed>fordo)
                        {
                            Character.PolishWeapon(Character);
                        }
                    }
                    while ((Character.Health <= (int)(Character.Life * 0.5)) && (Character.Health > (int)(Character.Life * 0.25)))
                    {
                        //here im thinking it checks if the stun in the list of debuffs and if true, with a 50% chance it will reverse the effect. But im not sure how yewo intends to reverse effects
                    }
                    while (Character.Health >(int)(Character.Life * 0.5))
                    {
                        Character.AgileBUffPercent = 0.5;
                        Character.Agile(Character, true);
                    }
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
                    while ((Character.Health <= (int)(Character.Life * 0.5)) && (Character.Health > (int)(Character.Life * 0.25)))
                    {
                        //here im thinking it checks if the stun in the list of debuffs and if true, with a 50% chance it will reverse the effect. But im not sure how yewo intends to reverse effects
                    }
                    while (Character.Health > (int)(Character.Life * 0.5))
                    {
                        Character.AgileBUffPercent = 0.5;
                        Character.Agile(Character, true);
                    }
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
                    while (RoundInfo.GameInSession==true)
                    {
                        if (storedhealth!=Character.Health)
                        {
                            dmaGi=(int)((Character.Health - storedhealth) * 0.1);
                            DamageObject errand = new DamageObject { DamageValue=dmaGi};
                            Character.TrueDamage(Character, Character.AttackSponser, errand);
                            storedhealth = Character.Health;
                        }
                    }
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
                    Timer Boom; Boom = new Timer(); Boom.Elapsed += new ElapsedEventHandler(Punch);  Boom.Interval = 1000; Boom.Enabled = true;
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
                                    Character.UniqueSkill(Character, Character.Allies[i]);
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
                    break;
                case MasterCharacterList.DevilBird:
                    break;
                case MasterCharacterList.DragonSloth:
                    break;
                default:
                    break;
            }
        }

        public void Attack1(object CharacterInstance, object TargetInstance)
        {
            Persona Character = (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            DamageObject damageobj = new DamageObject();

            switch (EnemyNames)
            {
                case MasterCharacterList.HammerHead:
                    foreach (object item in Character.Enemies)
                    {
                        PhysicalDamage(Character, item);
                        Tainted(Character, item);
                    }
                    break;
                case MasterCharacterList.GreatWhite:
                    int enemyindexCount = Character.Enemies.Count;
                    damageobj.DamageValue = Character.DamageGiven();
                    int tea = UnityEngine.Random.Range(1, enemyindexCount);
                    Character.TrueDamage(CharacterInstance, Character.Enemies[tea], damageobj);
                    break;
                case MasterCharacterList.SpiderCrustacean:
                    Character.PhysicalDamage(Character, Target);
                    Character.CalmDeBuffPercent = 0.2;
                    Character.Calm(Character, Target);
                    break;
                case MasterCharacterList.NecroBoar:
                    int RoundsDone = new int(); RoundsDone = RoundInfo.RoundsPassed; int count = 0;
                    Timer myr2; myr2 = new Timer(); myr2.Elapsed += new ElapsedEventHandler(myEt); myr2.Interval = 1000; myr2.Enabled = true;
                    void myEt(object source2, ElapsedEventArgs e)
                    {
                        if (RoundsDone!=RoundInfo.RoundsPassed&& count<3)
                        {
                            RoundsDone = RoundInfo.RoundsPassed;
                            Character.Bleed(Character, Target);
                            count++;
                        }
                    }
                    break;
                case MasterCharacterList.ElderStag:
                    break;
                case MasterCharacterList.DevilBird:
                    break;
                case MasterCharacterList.DragonSloth:
                    break;
                default:
                    break;
            }
        }
        public void Attack2(object CharacterInstance, object TargetInstance)
        {
            Persona Character = (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            DamageObject damageobj = new DamageObject();

            switch (EnemyNames)
            {
                case MasterCharacterList.HammerHead:
                    int speedCount = 0;
                    foreach (object item in Character.Enemies)
                    {
                        Character.Stun(Character, item);
                        Persona hero = (Persona)item;
                        foreach (DebuffObject debuff in hero.GetDebuffs())
                        {
                            if (debuff.type==Enums.debuffType.Stun)
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
                            if ((attack.type == Enums.AttackType.Bleed) &&(attack.Victim==(object)villian)) //this basically asks if someone is bleeding by the hand of a villian
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
                    Character.BrokenGuard(Character,Target);
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
                                if(victim!=Target) Character.Bleed(Character, victim);
                            }
                            break;
                        }
                        else { Character.PhysicalDamage(Character, Target); }
                    }
                    break;
                case MasterCharacterList.ElderStag:
                    break;
                case MasterCharacterList.DevilBird:
                    break;
                case MasterCharacterList.DragonSloth:
                    break;
                default:
                    break;
            }
        }
        public void Attack3(object CharacterInstance, object TargetInstance)
        {
            Persona Character = (Persona)CharacterInstance;
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
                    break;
                case MasterCharacterList.SpiderCrustacean:
                    //go in the shell animation
                    Character.PutArmour(Character, true, (int)(Character.Armour * 0.8));
                    break;
                case MasterCharacterList.NecroBoar:
                    DamageObject damdamda = new DamageObject { DamageValue = Character.DamageGiven()};
                    Character.PhysicalDamage(Character, Target, damdamda);
                    int woisbleeding = 0;
                    foreach (object item in Character.Enemies) //I put this here cause i think the shark will attack anyone it smells having bleeding. Even itself and friends
                    {
                        Persona hero = (Persona)item;
                        foreach (AttackObject attack in hero.GetAttack(hero))
                        {
                            if ((attack.type == Enums.AttackType.Bleed)&& attack.state==true)
                            {
                                woisbleeding++;
                                break;
                            }
                        }
                    }
                    if (woisbleeding==Character.Enemies.Count)
                    {
                        foreach (var item in Character.Enemies)
                        {
                            Character.Ignite(Character, item, damdamda.DamageValue);
                        }
                    }
                    break;
                case MasterCharacterList.ElderStag:
                    break;
                case MasterCharacterList.DevilBird:
                    break;
                case MasterCharacterList.DragonSloth:
                    break;
                default:
                    break;
            }
        }
    }
}
