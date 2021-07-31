using Assets.Entities;
using Assets.Scripts.TraitInterface;
using Assets.TraitInterface;
using System;
using System.Collections.Generic;
using UnityEngine;
using static Enums;
using Random = System.Random;

public class WarriorTemplate : CharacterPersona, ICardTraits, ICharacterTraits, IWarriorTraits
{
    public static WarriorTemplate Instance { get; set; }
    public WarriorTemplate()
    {
        Instance = this;
    }

    #region Character variables
    public string CharacterName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public string BriefDescription { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public bool DefaultValue { get { return DefaultValue; } set { DefaultValue = true; } }
    public int Health
    {
        get { return Health; }
        set
        {
            if (Health < 0) Health = 0;
            if (DefaultValue == true)
            {

                if (Foe == false)
                {
                    Health = 70;
                }
                else
                {
                    Health = 15;
                }
            }
        }
    }
    public int dodge
    {
        get { return dodge; }
        set
        {
            if (DefaultValue == true)
            {
                if (Foe == false)
                {
                    dodge = 6;
                }
                else
                {
                    dodge = 0;
                }
            }
            if (dodge < 0) dodge = 0;

        }
    }
    public int Speed
    {
        get { return Speed; }
        set
        {
            if (DefaultValue == true)
            {
                if (Foe == false)
                {
                    Speed = 10;
                }
                else
                {
                    Speed = 1;
                }
            }
            if (Speed < 0) Speed = 0;

        }
    }
    public double CritC
    {
        get { return CritC; }
        set
        {
            if (DefaultValue == true)
            {
                if (Foe == false)
                {
                    CritC = 6;
                }
                else
                {
                    CritC = 1;
                }
            }
            if (CritC < 0) CritC = 0;

        }
    }   
    public int Damage
    {
        get { return Damage; }
        set
        {
            if (DefaultValue == true)
            {
                if (Foe == false)
                {
                    if (LowDamageWarrior == true)
                    {
                        Damage = 14;
                    }
                    else
                    {
                        Damage = 19;
                    }
                }
                else
                {
                    if (LowDamageWarrior == true)
                    {
                        Damage = 3;
                    }
                    else
                    {
                        Damage = 6;
                    }
                }
            }
            if (Damage < 0) Damage = 0;

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
                    Accuracy = 95;
                }
                else
                {
                    Accuracy = 0;
                }
            }
            if (Accuracy < 0) Accuracy = 0;
        }
    }


    public int Mana { get { return Mana; } set { if (DefaultValue == true) { if (Mana > 100) Mana = 100; if (Mana < 0) Mana = 0; } } }
    public int Stamina
    {
        get { return Stamina; }
        set { if (DefaultValue == true) { if (Stamina > 100) Stamina = 100; if (Stamina < 0) Stamina = 0; } }

    }
    public string CharacterDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public List<string> NaturalAllies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public List<string> NaturalEnemies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public bool Foe { get { return Foe; } set { Foe = false; } }
    public bool PassiveWarriorTraits { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public bool LowDamageWarrior { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


    public int ExpPoints
    {
        get { return ExpPoints; }
        set
        {
            if (ExpPoints < 0) ExpPoints = 0;
            if (RoundOver == true/*This means characters can level up durning battle*/)
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
            if (NewEarnedXp < 0) NewEarnedXp = 0;
            if (EarnedXp == true)
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
            if (RoundOver == false/*This means characters can level up durning battle*/)
            {
                EarnedXp = false;
            }
        }
    } //This bool is made true when XPIncrease is fired and should be made of when sessionOver is true

    public int MagicalDamageTaken { get => throw new NotImplementedException(); set => throw new NotImplementedException(); /*if (MagicalDama < 0) MagicalDa = 0;*/}
    public int PhysicalDamageTaken { get => throw new NotImplementedException(); set => throw new NotImplementedException(); /*if (PhysicalDama < 0) PhyscialDama = 0;*/}
    public int HitCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public double PowerBuffPercent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    #endregion
    #region Character Methods

    //Here are the passive traits of the card themselves
    public void passiveTraits()
    {
        //Instance.EquipItem(HolyCrossItem, Instance); I dont expect this to be used at all here. It would be clled some place else, I wrrote it here to see if it would work
        Instance.ActiveBuff();
    }

    //string CitizenOf = (string)WarriorTemplate.Kingdom.DarkSyde; // Here I was just experimenting to see how the citizenship can be set
    //After We figure out how to set the respective variables to the specific enum value I want to use peter as a reference for other characters so we
    //forget to include the correct and necesary info





    //Default Methods of Character Combantant type
    public void ActiveBuff()
    {
        #region Passive option 2 Warrior StackSpeed

        //Passive 2 - Stacks atack speed up to 5 times (5% each)

        int CacheSpeed = 0;
        int StackCount = 5;
        if (StackCount > 0 && HitCount < 5)
        {
            Instance.Speed += (int)(Instance.Speed * 0.05);
            CacheSpeed += (int)(Instance.Speed * 0.05);
            StackCount--;
        }
        else
        {
            //Print " cannot stack any more" or "Stack limit reached"
        }
        if (true/*GameOver==true*/)
        {
            Instance.Speed -= CacheSpeed;
            CacheSpeed = 0;
            StackCount = 5;
        }
        #endregion
    }
    public void ActiveDeBuff()
    {
        throw new System.NotImplementedException();
    }
    public DebuffObject GetDebuff()
    {
        return new DebuffObject()
        {
            state = (PurifiedState || ImmuneState) ? false : DebuffState,
            type = _debuffType,
            amount = Debuff
        };
    }
    //Experince methods
    public void LevelIncrease()
    {
        Instance.ExperienceLevel++;
        if (Foe == false)
        {
            Instance.Health += 20 * Instance.ExperienceLevel;
            Instance.dodge += 2 * Instance.ExperienceLevel;
            Instance.Speed += 2 * Instance.ExperienceLevel;
            Instance.CritC += 1 * Instance.ExperienceLevel;
            Instance.MagicRes += 1 * Instance.ExperienceLevel;
            Instance.Armour += 3 * Instance.ExperienceLevel;
            Instance.LowDamageWarrior = true;
            if (LowDamageWarrior == true)
            { Instance.Damage += 3 * Instance.ExperienceLevel; Instance.LowDamageWarrior = false; }
            if (LowDamageWarrior == false)
            {
                Instance.Damage += 2 * Instance.ExperienceLevel;
            }
        }
        else
        {
            Instance.Health += 5 * Instance.ExperienceLevel;
            Instance.dodge += 2 * Instance.ExperienceLevel;
            Instance.Speed += 1 * Instance.ExperienceLevel;
            Instance.CritC += 1 * Instance.ExperienceLevel;
            Instance.MagicRes += 0;
            Instance.Armour += 0;
            Instance.LowDamageWarrior = true;
            if (LowDamageWarrior == true)
            { Instance.Damage += 1 * Instance.ExperienceLevel; Instance.LowDamageWarrior = false; }
            if (LowDamageWarrior == false)
            {
                Instance.Damage += 2 * Instance.ExperienceLevel;
            }
        }
        //fire levelIncrease animation
    }
    public void TraitLevelUpActivation(int experienceLevel, List<Items> Items)
    {
        throw new NotImplementedException();
    }
    public void XPIncrease(bool earnXp, int newEarnedXp)
    {
        EarnedXp = earnXp;
        NewEarnedXp = newEarnedXp;
    }
    public int DamageGiven(object CharacterInstance, damageType source)
    {
        int damageGiven = 0;
        if (Foe == false)
        {
            Random r = new Random();
            damageGiven = r.Next(14, 20);
        }
        else
        {
            Random r = new Random();
            damageGiven = r.Next(3, 7);
        }
        /*
         Eyy my guy, none of this below makes sense
        But maybe im just dumb
         */

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

        return damageGiven;

    }
    public int HealthLoss(int damageGiven)
    {
        Instance.Health -= damageGiven;
        return damageGiven;
    }

    #region Toggles

    #region variables
    public int MagicRes
    {
        get { return MagicRes; }
        set
        {
            if (DefaultValue == true)
            {
                if (Foe == false)
                {
                    MagicRes = 2;
                }
                else
                {
                    MagicRes = 0;
                }
            }
            if (MagicRes < 0) MagicRes = 0;

        }
    }
    public int Armour
    {
        get { return Armour; }
        set
        {
            if (DefaultValue == true)
            {
                if (Foe == false)
                {
                    Armour = 2;
                }
                else
                {
                    Armour = 0;
                }
            }
            if (Armour < 0) Armour = 0;

        }
    }
    public int Shield
    {
        get { return Shield; }
        set
        {
            if (DefaultValue == true)
            {
                if (Foe == false)
                {
                    Shield = 2;
                }
                else
                {
                    Shield = 0;
                }
            }
            if (Shield < 0) Shield = 0;
        }
    }
    public int Debuff
    {
        get { return Debuff; }
        set
        {
            if (DefaultValue == true)
            {
                if (Foe == false)
                {
                    Debuff = 2;
                }
                else
                {
                    Debuff = 0;
                }
            }
            if (Debuff < 0) Debuff = 0;
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
    public double EvadeBuffPercent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public double AgileBUffPercent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public double HealBuffPercent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public double counterAttackPercent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public object ProtectionSponser { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public double SlowDeBuffPercent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public double RootedDebuffPercent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public double WeakGripDeBuffPercent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public double ExiledDeBuffPercent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public double MarkedDeBuffPerent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public double CalmDeBuffPercent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public double MagiBuffPercent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
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