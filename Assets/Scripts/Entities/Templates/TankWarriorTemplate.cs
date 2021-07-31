using Assets.Entities;
using Assets.Scripts.TraitInterface;
using Assets.TraitInterface;
using Assets.TraitInterface.CombantantType;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enums;
using Random = System.Random;

public class TankWarriorTemplate : CharacterPersona, ICardTraits,ICharacterTraits , ITankWarriorTraits
{
    public static TankWarriorTemplate Instance { get; set; }
    public TankWarriorTemplate()
    {
        Instance = this;
    }


    #region Character variables
    public string CharacterName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string CharacterDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


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
                    Health = 120;
                }
                else
                {
                    Health = 25;
                }
            }
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
                    dodge = 1;
                }
                else
                {
                    dodge = 0;
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
                    Speed = 1;
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
                    CritC = 3;
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
            if (DefaultValue == true)
            {
                if (Foe == false)
                {
                    if (LowDamageTankWarrior == true)
                    {
                        Damage = 8;
                    }
                    else
                    {
                        Damage = 13;
                    }
                }
                else
                {
                    if (LowDamageTankWarrior == true)
                    {
                        Damage = 2;
                    }
                    else
                    {
                        Damage = 4;
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
                    Accuracy = 80;
                }
                else
                {
                    Accuracy = 0;
                }
            }
            if (Accuracy < 0) Accuracy = 0;
        }
    }
    public int Mana { get => throw new NotImplementedException(); set => throw new NotImplementedException();/*if(DefaultValue==true){  }*/}
    public int Stamina { get => throw new NotImplementedException(); set => throw new NotImplementedException();/*if(DefaultValue==true){  }*/ }
    public int ExpPoints
    {
        get { return ExpPoints; }
        set
        {
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
            if (RoundOver == false)
            {
                EarnedXp = false;
            }
        }
    } //This bool is made true when XPIncrease is fired and should be made of when sessionOver is true
    public string BriefDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public List<string> NaturalAllies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public List<string> NaturalEnemies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public bool Foe { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public bool PassiveTankTraits { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public bool LowDamageTankWarrior { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
        if (Foe == false)
        {

            Instance.Health += 40 * Instance.ExperienceLevel;
            Instance.dodge += 1 * Instance.ExperienceLevel;
            Instance.Speed += 1 * Instance.ExperienceLevel;
            Instance.CritC += 1 * Instance.ExperienceLevel;
            Instance.MagicRes += 1 * Instance.ExperienceLevel;
            Instance.Armour += 2 * Instance.ExperienceLevel;
            Instance.LowDamageTankWarrior = true;
            if (LowDamageTankWarrior == true)
            { Instance.Damage += 2 * Instance.ExperienceLevel; Instance.LowDamageTankWarrior = false; }
            if (LowDamageTankWarrior == false)
            {
                Instance.Damage += 2 * Instance.ExperienceLevel;
            }
        }
        else
        {
            Instance.Health += 8 * Instance.ExperienceLevel;
            Instance.dodge += 0 * Instance.ExperienceLevel;
            Instance.Speed += 1 * Instance.ExperienceLevel;
            Instance.CritC += 1 * Instance.ExperienceLevel;
            Instance.MagicRes += 1 * Instance.ExperienceLevel;
            Instance.Armour += 2 * Instance.ExperienceLevel;
            Instance.LowDamageTankWarrior = true;
            if (LowDamageTankWarrior == true)
            { Instance.Damage += 1 * Instance.ExperienceLevel; Instance.LowDamageTankWarrior = false; }
            if (LowDamageTankWarrior == false)
            {
                Instance.Damage += 1 * Instance.ExperienceLevel;
            }
        }
        //fire levelIncrease animation
    }

    public void XPIncrease(bool earnXp, int newEarnedXp)
    {
        EarnedXp = earnXp;
        NewEarnedXp = newEarnedXp;
    }
    public void TraitLevelUpActivation(int experienceLevel, List<Items> Items)
    {
        throw new NotImplementedException();
    }
    public void ActiveBuff()
    {
        #region Passive option 1 Tank

        /*
         Passive 1 - each 1% of health lost, you gain 2% more armor and magic resistance

        int percentageHealthLoss =(Instance.HealthLoss(TankWarriorTemplate.Instance.DamageGiven(TankWarriorTemplate.Instance))/ Health);
        //This line above doesn't make sense. damageGiven needs to be passed through ActiveBuff for it to work. We cant use the above parameter in HealthLoss it has to be something past into the activeBuff()
        int CacheArmour = 0;
        int CacheMagicalresistance = 0;
        for (int per = 0; per < percentageHealthLoss; per++)
        {
            Instance.Armour += (int)(Instance.Armour * 0.02);
            CacheArmour += (int)(Instance.Armour * 0.02);
            Instance.MagicRes += (int)(Instance.MagicRes * 0.02);
            CacheMagicalresistance += (int)(Instance.MagicRes * 0.02);
        }
        if (GameOver==true)
        {
            Instance.Armour -= CacheArmour;
            Instance.MagicRes -= CacheMagicalresistance;
            CacheArmour = 0;
            CacheMagicalresistance = 0;
        }

        */

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
            state = (PurifiedState || ImmuneState) ? false : DebuffState,
            type = _debuffType,
            amount = Debuff
        };
    }

    public int DamageGiven(object CharacterInstance, damageType source)
    {
        int damageGiven = 0;
        if (Foe == false)
        {
            Random r = new Random();
            damageGiven = r.Next(8, 14);
        }
        else
        {
            Random r = new Random();
            damageGiven = r.Next(2, 5);
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
                    MagicRes = 5;
                }
                else
                {
                    MagicRes = 5;
                }
            }
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
                    Armour = 3;
                }
                else
                {
                    Armour = 5;
                }

            }
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
