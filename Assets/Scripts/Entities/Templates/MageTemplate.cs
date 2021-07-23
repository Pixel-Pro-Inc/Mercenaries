﻿using Assets.Entities;
using Assets.Scripts.TraitInterface;
using Assets.TraitInterface;
using Assets.TraitInterface.CombantantType;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using static Enums;
using Random = System.Random;

public class MageTemplate : CharacterPersona, ICardTraits, IMageTraits
{
    private Timer myTimer;// this is used for a passive mage trait
    public static MageTemplate Instance { get; set; }
    public MageTemplate()
    {
        Instance = this;
    }
    #region Character Variables
    public string CharacterName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string CharacterDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public bool DefaultValue { get { return DefaultValue; } set { DefaultValue = true; } }
    public int Health
    {
        get { return Health; }
        set
        {
            if (DefaultValue == true)
            {
                if (Foe == false)
                {
                    if (SupportMage == false)
                    {
                        Health = 55;
                    }
                    else
                    {
                        Health = 26;
                    }
                }
                else
                {
                    Health = 6;
                }
            }
            if (Health < 0) Health = 0;

        }
    }
    public int dodge
    {
        get { return dodge; }
        set
        {
            if (dodge < 0) dodge = 0;
            if (DefaultValue == true)
            {
                if (Foe == false)
                {
                    if (SupportMage == false)
                    {
                        dodge = 5;
                    }
                    else
                    {
                        dodge = 10;
                    }
                }
                else
                {
                    dodge = 10;
                }

            }
        }
    }
    public int Speed
    {
        get { return Speed; }
        set
        {
            if (Speed < 0) Speed = 0;
            if (DefaultValue == true)
            {
                if (Foe == false)
                {
                    if (SupportMage == false)
                    {
                        Speed = 1;
                    }
                    else
                    {
                        Speed = 10;
                    }
                }
                else
                {
                    Speed = 1;
                }

            }
        }
    }
    public double CritC
    {
        get { return CritC; }
        set
        {
            if (CritC < 0) CritC = 0;
            if (DefaultValue == true)
            {
                if (Foe == false)
                {
                    if (SupportMage == false)
                    {
                        CritC = 2;
                    }
                    else
                    {
                        CritC = 1;
                    }
                }
                else
                {
                    CritC = 1;
                }

            }
        }
    }    
    public int Damage
    {
        get { return Damage; }
        set
        {
            if (Damage < 0) Damage = 0;
            if (DefaultValue == true)
            {
                if (Foe == false)
                {
                    if (SupportMage == false)
                    {
                        if (LowDamageMage == true)
                        {
                            Damage = 5;
                        }
                        else
                        {
                            Damage = 25;
                        }
                    }
                    else
                    {
                        if (LowDamageMage == true)
                        {
                            Damage = 1;
                        }
                        else
                        {
                            Damage = 10;
                        }
                    }
                }
                else
                {
                    if (LowDamageMage == true)
                    {
                        Damage = 1;
                    }
                    else
                    {
                        Damage = 20;
                    }
                }
            }
        }
    }
    public int Accuracy
    {
        get { return Accuracy; }
        set
        {
            if (DefaultValue == true)
            {
                if (Foe == false)
                {
                    Accuracy = 85;
                }
                else
                {
                    Accuracy = 0;
                }
            }
            if (Accuracy < 0) Accuracy = 0;
        }
    }
    public int Mana { get { return Mana; } set { if (Mana > 100) Mana = 100; if (Mana < 0) Mana = 0; } }
    public int Stamina { get { return Stamina; } set { if (Stamina > 100) Stamina = 100; if (Stamina < 0) Stamina = 0; } }
    public int ExpPoints
    {
        get { return ExpPoints; }
        set
        {
            if (BattleCalculate == true/*This means characters can level up durning battle*/)
            {
                Instance.ExpPoints += NewEarnedXp;
            }
            if (Instance.ExpPoints > 1000)
            {
                Instance.LevelIncrease();
                Instance.ExpPoints -= 1000;
            }
        }
    }
    public int NewEarnedXp
    {
        get { return NewEarnedXp; }
        set
        {
            if (EarnedXp == true/*this is set true in XPIncrease()*/)
            {
                Instance.NewEarnedXp = NewEarnedXp;
            }
            else
            {
                Instance.NewEarnedXp = 0;
            }
        }
    }
    public bool EarnedXp
    {
        get { return EarnedXp; }
        set
        {
            if (BattleCalculate == false/*This means characters can level up durning battle*/)
            {
                EarnedXp = false;
            }
        }
    } //This bool is made true when XPIncrease is fired and should be made of when sessionOver is true
    public string BriefDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public List<string> NaturalAllies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public List<string> NaturalEnemies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public bool Foe { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public bool PassiveMageTraits { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public bool LowDamageMage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public bool SupportMage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public int MagicalDamageTaken { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int PhysicalDamageTaken { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int HitCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public double PowerBuffPercent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }    

    #endregion
    #region Character Methods

    public void passiveTraits()
    {

    }

    public void LevelIncrease()
    {
        Instance.ExperienceLevel++;
        #region If Support variables Increase logic 
        if (Foe == false)
        {

            if (SupportMage == false)
            {
                Instance.Health += 5 * Instance.ExperienceLevel;
                Instance.dodge += 5 * Instance.ExperienceLevel;
                Instance.Speed += 1 * Instance.ExperienceLevel;
                Instance.CritC += 1 * Instance.ExperienceLevel;
                Instance.MagicRes += 3 * (Instance.ExperienceLevel - 2);
                Instance.Armour += 1 * (Instance.ExperienceLevel - 2);
                #region Damage
                if (LowDamageMage == true) Instance.Damage += 5 * Instance.ExperienceLevel;
                else
                {
                    Instance.Damage += 4 * Instance.ExperienceLevel;
                }
                #endregion
            }
            else
            {
                Instance.Health += 5 * Instance.ExperienceLevel;
                Instance.dodge += 5 * Instance.ExperienceLevel;
                Instance.Speed += 6 * Instance.ExperienceLevel;
                Instance.CritC += 1 * Instance.ExperienceLevel;
                Instance.MagicRes += 1 * Instance.ExperienceLevel;
                Instance.Armour += 1 * Instance.ExperienceLevel;
                if (LowDamageMage == true) Instance.Damage += 3 * Instance.ExperienceLevel;
                else
                {
                    Instance.Damage += 4 * Instance.ExperienceLevel;
                }
            }
            //fire levelIncrease animation
        }
        else
        {
            Instance.Health += 1 * Instance.ExperienceLevel;
            Instance.dodge += 2 * Instance.ExperienceLevel;
            Instance.Speed += 1 * Instance.ExperienceLevel;
            Instance.CritC += 1 * Instance.ExperienceLevel;
            Instance.MagicRes += 0 * Instance.ExperienceLevel;
            Instance.Armour += 0 * Instance.ExperienceLevel;
            if (LowDamageMage == true) Instance.Damage += 1 * Instance.ExperienceLevel;
            else
            {
                Instance.Damage += 5 * Instance.ExperienceLevel;
            }
        }
        #endregion
        //fire levelIncrease animation

    }

    public void XPIncrease(bool earnXp, int newEarnedXp)
    {
        EarnedXp = earnXp;
        NewEarnedXp = newEarnedXp;
    }

    public void ActiveBuff()
    {
        #region Passive option 2 Mage

        //Mana regen every 5 seconds

        // Create a timer
        myTimer = new System.Timers.Timer();
        // Tell the timer what to do when it elapses
        myTimer.Elapsed += new ElapsedEventHandler(myEvent);
        // Set it to go off every five seconds
        myTimer.Interval = 5000;
        // And start it        
        myTimer.Enabled = true;

        // Implement a call with the right signature for events going off
        void myEvent(object source, ElapsedEventArgs e) { Mana++; }
        #endregion

    }

    public void ActiveDeBuff()
    {
        throw new NotImplementedException();
    }

    public DebuffObject GetDebuff()
    {
        return new DebuffObject()
        {
            state = (PurifiedState || ImmuneState)? false : DebuffState,
            type = _debuffType,
            amount = Debuff
        };        
    }

    public void TraitLevelUpActivation(int experienceLevel, List<Items> Items)
    {
        throw new NotImplementedException();
    }

    public int DamageGiven(object CharacterInstance, damageType source)
    {
        int damageGiven = 0;
        if (Foe == false)
        {
            Random r = new Random();
            damageGiven = r.Next(5, 26);
        }
        else
        {
            Random r = new Random();
            damageGiven = r.Next(5, 11);
        }

        if (Instance.Chosen() == true) damageGiven = (int)(damageGiven * Instance.PowerBuffPercent);// this is to work the Chosen buff Controllers dont get a physical buff


        if (BattleCalculate == true)
        {
            return damageGiven; //This was put here so that it escapes the method all together if an action is still in calculation
        }

        //My Implementation of Armour
        if (ArmourState && source == damageType.Physical)
        {
            if (damageGiven >= Armour)
            {
                damageGiven -= Armour;
            }
            else
            {
                damageGiven = 0;
            }
        }        

        //My Implementation of Magical Damage Resistance
        if (MagicResState && source == damageType.Magical)
        {
            if (damageGiven >= MagicRes)
            {
                damageGiven -= MagicRes;
            }
            else
            {
                damageGiven = 0;
            }
        }

        //My Implementation of Shield
        if (ShieldState && source == damageType.Physical)
        {
            if (damageGiven >= Shield)
            {
                damageGiven -= Shield;
            }
            else
            {
                damageGiven = 0;
            }
        }

        //My Implementation of Block
        if (BlockState && source == damageType.Physical)
        {
            damageGiven = 0;
        }

        if (ImmuneState)
        {
            damageGiven = 0;
        }

        #region template logic


        if (CharacterInstance.GetType() == typeof(WarriorTemplate))
        {
            WarriorTemplate starter = (WarriorTemplate)CharacterInstance;
            starter.HealthLoss(damageGiven);
        }
        if (CharacterInstance.GetType() == typeof(TankWarriorTemplate))
        {
            TankWarriorTemplate starter = (TankWarriorTemplate)CharacterInstance;
            starter.HealthLoss(damageGiven);
        }
        if (CharacterInstance.GetType() == typeof(RangeTemplate))
        {
            RangeTemplate starter = (RangeTemplate)CharacterInstance;
            starter.HealthLoss(damageGiven);
        }
        if (CharacterInstance.GetType() == typeof(MageTemplate))
        {
            MageTemplate starter = (MageTemplate)CharacterInstance;
            starter.HealthLoss(damageGiven);
        }
        if (CharacterInstance.GetType() == typeof(ControllerTemplate))
        {
            ControllerTemplate starter = (ControllerTemplate)CharacterInstance;
            starter.HealthLoss(damageGiven);
        }
        if (CharacterInstance.GetType() == typeof(AssasinTemplate))
        {
            AssasinTemplate starter = (AssasinTemplate)CharacterInstance;
            starter.HealthLoss(damageGiven);
        }
        #endregion

        return damageGiven;
    }
    public int HealthLoss(int damageGiven)
    {
        Instance.PhysicalDamageTaken -= Instance.Armour;
        Instance.MagicalDamageTaken -= Instance.MagicRes;
        int damageTaken = Instance.MagicalDamageTaken + Instance.PhysicalDamageTaken;
        Instance.Health -= damageTaken;
        return damageTaken;
    }
    #region Toggles
    #region variables
    public int Armour
    {
        get { return Armour; }
        set
        {
            if (Armour < 0) Armour = 0;
            if (DefaultValue == true)
            {
                if (Foe == false)
                {
                    if (SupportMage == false)
                    {
                        Armour = 2;
                    }
                    else
                    {
                        Armour = 1;
                    }
                }
                else
                {
                    Armour = 0;
                }

            }
        }
    }
    public int MagicRes
    {
        get { return MagicRes; }
        set
        {
            if (MagicRes < 0) MagicRes = 0;
            if (DefaultValue == true)
            {
                if (Foe == false)
                {
                    if (SupportMage == false)
                    {
                        MagicRes = 2;
                    }
                    else
                    {
                        MagicRes = 1;
                    }
                }
                else
                {
                    MagicRes = 0;
                }

            }
        }
    }
    public int Shield {
        get { return Shield; }
        set
        {
            if (Shield < 0) Shield = 0;
            if (DefaultValue == true)
            {
                if (Foe == false)
                {
                    if (SupportMage == false)
                    {
                        Shield = 2;
                    }
                    else
                    {
                        Shield = 1;
                    }
                }
                else
                {
                    Shield = 0;
                }

            }
        }
    }
    public int Debuff
    {
        get { return Debuff; }
        set
        {
            if (Debuff < 0) Debuff = 0;
            if (DefaultValue == true)
            {
                if (Foe == false)
                {
                    if (SupportMage == false)
                    {
                        Debuff = 2;
                    }
                    else
                    {
                        Debuff = 1;
                    }
                }
                else
                {
                    Debuff = 0;
                }

            }
        }
    }

    public debuffType _debuffType { get; set; }
    public bool DebuffState { get; set; }
    public bool ArmourState { get; private set; }
    public bool MagicResState { get; private set; }
    public bool ShieldState { get; private set; }
    public bool PurifiedState { get; private set; }
    public bool BlockState { get; private set; }
    public bool ImmuneState { get; private set; }
    #endregion
    public void ToggleArmour(bool state, int amount)
    {
        ArmourState = state;
        Armour = amount;
    }
    public void ToggleMagicRes(bool state, int amount)
    {
        MagicResState = state;
        MagicRes = amount;
    }
    public void ToggleShield(bool state, int amount)
    {
        ShieldState = state;
        Shield = amount;
    }
    public void TogglePurified(bool state)
    {
        PurifiedState = state;
    }
    public void ToggleBlock(bool state)
    {
        BlockState = state;
    }
    public void ToggleImmune(bool state)
    {
        ImmuneState = state;
    }
    #endregion
    #endregion
}