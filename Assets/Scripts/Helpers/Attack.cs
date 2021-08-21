using Assets.Scripts.Entities.Character;
using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using static Assets.Scripts.Models.Enums;

namespace Assets.Scripts.Helpers
{
    public class Attack
    {
        public void TrueDamage(object CharacterInstance, object TargetInstance, DamageObject DamageObj)
        {
            Persona Character = (Persona)CharacterInstance;
            Persona target = (Persona)TargetInstance;

            AttackObject attackObject = null;
            attackObject = new AttackObject()
            {
                state = true,
                type = AttackType.TrueDamage,
                amount = DamageObj.DamageValue
            };
            Character.AttacksGiven.Add(attackObject);

            if (target.ImmuneState == true)
            { }
            else { target.HealthLoss(DamageObj); target.HitCount++; }
        }
        public void PhysicalDamage(object CharacterInstance, object TargetInstance)
        {
            int physicalDamage = 0;
            int shieldcache = 0;
            int armourcahe = 0;
            double markedda = 0;

            Persona Character = (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            physicalDamage = Character.DamageGiven();

            DamageObject hitval = new DamageObject();
            hitval.DamageTrait = DamageObject.DamageVersion.Physical;
            hitval.DamageValue = physicalDamage;

            AttackObject attackObject = null;
            attackObject = new AttackObject()
            {
                state = true,
                type = AttackType.PhysicalDamage,
                amount = hitval.DamageValue
            };
            Character.AttacksGiven.Add(attackObject);

            #region Character Logic
            
            markedda = Character.MarkedDeBuffPerent;
            if (Character.CriticalChance == true)
            {
                Random vox = new Random();
                int skylar = vox.Next(1, 101);
                if (skylar < Character.CritC) physicalDamage += physicalDamage;
                Character.CriticalChance = false;
            }
            bool polishM = new bool();
            List<BuffObject> polishmaybe= Character.GetBuff(Character);
            foreach (var item in polishmaybe)
            {
                if (item.type == buffType.PolishedWeapon) polishM = true;
            }
            bool WeakDebuffM = new bool(); bool CalmDebuffM = new bool();
            List<DebuffObject> Debuffmaybe = Character.GetDebuffs();
            foreach (var item in Debuffmaybe)
            {
                if (item.type == debuffType.WeakGrip) WeakDebuffM = true;
                if (item.type == debuffType.Calm) CalmDebuffM = true;
            }
            if (polishM == true) physicalDamage += (int)(physicalDamage * Character.PowerBuffPercent);// this is to work the polish buff
            if (WeakDebuffM == true) physicalDamage -= (int)(physicalDamage * Character.WeakGripDeBuffPercent);
            if (CalmDebuffM == true) physicalDamage -= (int)(physicalDamage * Character.CalmDeBuffPercent);

            #endregion
            #region Target Logic

            bool MArkedDebuffM = new bool();
            List<DebuffObject> DebuffmaybeTar = Target.GetDebuffs();
            foreach (var item in DebuffmaybeTar)
            {
                if (item.type == debuffType.Marked) MArkedDebuffM = true;
            }
            Target.AttackSponser = Character;
            if (Target.ProtectionSponser != null) Target = (Persona)Target.ProtectionSponser;
            if (MArkedDebuffM == true) physicalDamage += (int)(physicalDamage * markedda);
            if (Target.BlockState == true)
            {
                physicalDamage = 0;
                Target.BlockState = false;
                //blocking animation
            }

            Target.HitCount++;
            shieldcache = Target.shield;
            armourcahe = Target.Armour;
            shieldcache -= physicalDamage; Target.shield -= physicalDamage;//this will make shield=0 if the physical damage is too much
            //the code below ensures that the sheild is removed first
            if (shieldcache < 0)//this asks if there is no more sheild left
            {
                armourcahe += shieldcache;// here the negative value adds with the positive- following negative number addition laws i hope
                if (armourcahe < 0)//this asks if there is no more armour left
                {
                    Target.Armour = 0; // this makes sure armour is zero
                    hitval.DamageValue = Math.Abs(armourcahe);
                    Character.TrueDamage(Character,Target, hitval); //This removes the health of the target
                }
                else { Target.Armour = armourcahe; }
            }
            else
            {
                Target.shield = shieldcache;
            }
            Target.ProtectionSponser = null;
            #endregion

        }
        public void PhysicalDamage(object CharacterInstance, object TargetInstance, DamageObject damageObject)
        {
            int physicalDamage = 0;
            int shieldcache = 0;
            int armourcahe = 0;
            double markedda = 0;

            Persona Character = (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            physicalDamage = damageObject.DamageValue;
            damageObject.DamageTrait = DamageObject.DamageVersion.Physical;

            AttackObject attackObject = null;
            attackObject = new AttackObject()
            {
                state = true,
                type = AttackType.PhysicalDamage,
                amount = damageObject.DamageValue
            };
            Character.AttacksGiven.Add(attackObject);

            #region Character Logic

            markedda = Character.MarkedDeBuffPerent;
            if (Character.CriticalChance == true)
            {
                Random vox = new Random();
                int skylar = vox.Next(1, 101);
                if (skylar < Character.CritC) physicalDamage += physicalDamage;
                Character.CriticalChance = false;
            }
            bool polishM = new bool();
            List<BuffObject> polishmaybe = Character.GetBuff(Character);
            foreach (var item in polishmaybe)
            {
                if (item.type == buffType.PolishedWeapon) polishM = true;
            }
            bool WeakDebuffM = new bool(); bool CalmDebuffM = new bool();
            List<DebuffObject> Debuffmaybe = Character.GetDebuffs();
            foreach (var item in Debuffmaybe)
            {
                if (item.type == debuffType.WeakGrip) WeakDebuffM = true;
                if (item.type == debuffType.Calm) CalmDebuffM = true;
            }
            if (polishM == true) physicalDamage += (int)(physicalDamage * Character.PowerBuffPercent);// this is to work the polish buff
            if (WeakDebuffM == true) physicalDamage -= (int)(physicalDamage * Character.WeakGripDeBuffPercent);
            if (CalmDebuffM == true) physicalDamage -= (int)(physicalDamage * Character.CalmDeBuffPercent);

            #endregion
            #region Target Logic

            bool MArkedDebuffM = new bool();
            List<DebuffObject> DebuffmaybeTar = Target.GetDebuffs();
            foreach (var item in DebuffmaybeTar)
            {
                if (item.type == debuffType.Marked) MArkedDebuffM = true;
            }
            Target.AttackSponser = Character;
            if (Target.ProtectionSponser != null) Target = (Persona)Target.ProtectionSponser;
            if (MArkedDebuffM == true) physicalDamage += (int)(physicalDamage * markedda);
            if (Target.BlockState == true)
            {
                physicalDamage = 0;
                Target.BlockState = false;
                //blocking animation
            }

            Target.HitCount++;
            shieldcache = Target.shield;
            armourcahe = Target.Armour;
            shieldcache -= physicalDamage; Target.shield -= physicalDamage;//this will make shield=0 if the physical damage is too much
            //the code below ensures that the sheild is removed first
            if (shieldcache < 0)//this asks if there is no more sheild left
            {
                armourcahe += shieldcache;// here the negative value adds with the positive- following negative number addition laws i hope
                if (armourcahe < 0)//this asks if there is no more armour left
                {
                    Target.Armour = 0; // this makes sure armour is zero
                    damageObject.DamageValue = Math.Abs(armourcahe);
                    Character.TrueDamage(Character, Target, damageObject); //This removes the health of the target
                }
                else { Target.Armour = armourcahe; }
            }
            else
            {
                Target.shield = shieldcache;
            }
            Target.ProtectionSponser = null;
            #endregion

        }// this is so someone can put a tailored value
        public void MagicalDamage(object CharacterInstance, object TargetInstance)
        {
            int magicalDamage = 0;
            int shieldcache = 0;
            int magrescache = 0;
            double markedda = 0;

            Persona Character = (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            magicalDamage = Character.DamageGiven();

            DamageObject hitval = new DamageObject();
            hitval.DamageValue = magicalDamage;
            hitval.DamageTrait = DamageObject.DamageVersion.Magical;

            AttackObject attackObject = null;
            attackObject = new AttackObject()
            {
                state = true,
                type = AttackType.MagicalDamage,
                amount = hitval.DamageValue
            };
            Character.AttacksGiven.Add(attackObject);

            #region Character Logic

            markedda = Character.MarkedDeBuffPerent;
            if (Character.CriticalChance == true)
            {
                Random vox = new Random();
                int skylar = vox.Next(1, 101);
                if (skylar < Character.CritC) magicalDamage += magicalDamage;
                Character.CriticalChance = false;
            }
            bool ChosenhM = new bool();
            List<BuffObject> polishmaybe = Character.GetBuff(Character);
            foreach (var item in polishmaybe)
            {
                if (item.type == buffType.Chosen) ChosenhM = true;
            }
            bool ExiledDebuffM = new bool(); bool CalmDebuffM = new bool();
            List<DebuffObject> Debuffmaybe = Character.GetDebuffs();
            foreach (var item in Debuffmaybe)
            {
                if (item.type == debuffType.Exiled) ExiledDebuffM = true;
                if (item.type == debuffType.Calm) CalmDebuffM = true;
            }
            if (ChosenhM == true) magicalDamage += (int)(magicalDamage * Character.MagiBuffPercent);
            if (ExiledDebuffM == true) magicalDamage -= (int)(magicalDamage * Character.ExiledDeBuffPercent);
            if (CalmDebuffM == true) magicalDamage -= (int)(magicalDamage * Character.CalmDeBuffPercent);
            #endregion
            #region Target Logic

            bool MArkedDebuffM = new bool();
            List<DebuffObject> DebuffmaybeTar = Target.GetDebuffs();
            foreach (var item in DebuffmaybeTar)
            {
                if (item.type == debuffType.Marked) MArkedDebuffM = true;
            }
            Target.AttackSponser = Character; //for Onguard()
            Target.HitCount++;
            shieldcache = Target.shield;
            magrescache = Target.MagicRes;
            if (Target.ImmuneState == true) magicalDamage = 0;
            shieldcache -= magicalDamage; Target.shield -= magicalDamage;
            if (Target.ProtectionSponser != null) Target = (Persona)Target.ProtectionSponser;
            if (MArkedDebuffM == true) magicalDamage += (int)(magicalDamage * markedda);

            if (shieldcache < 0)//this asks if there is no more sheild left
            {
                magrescache += shieldcache;// here the negative value adds with the positive- following negative number addition laws i hope
                if (magrescache < 0)//this asks if there is no more resistance left
                {
                    Target.MagicRes = 0;
                    hitval.DamageValue = Math.Abs(magrescache);
                    Character.TrueDamage(Character, Target, hitval); //This removes the health of the target
                }
                else { Target.MagicRes = magrescache; }
            }
            else
            {
                Target.shield = shieldcache;
            }
            Target.ProtectionSponser = null;
            #endregion

        }
        public void MagicalDamage(object CharacterInstance, object TargetInstance, int amount)
        {
            int magicalDamage = 0;
            int shieldcache = 0;
            int magrescache = 0;
            double markedda = 0;

            Persona Character = (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            DamageObject hitval = new DamageObject();
            hitval.DamageTrait = DamageObject.DamageVersion.Magical;
            magicalDamage = amount;

            AttackObject attackObject = null;
            attackObject = new AttackObject()
            {
                state = true,
                type = AttackType.MagicalDamage,
                amount = hitval.DamageValue
            };
            Character.AttacksGiven.Add(attackObject);

            #region Character Logic
            
            markedda = Character.MarkedDeBuffPerent;
            if (Character.CriticalChance == true)
            {
                Random vox = new Random();
                int skylar = vox.Next(1, 101);
                if (skylar < Character.CritC) magicalDamage += magicalDamage;
                Character.CriticalChance = false;
            }
            bool ChosenhM = new bool();
            List<BuffObject> polishmaybe = Character.GetBuff(Character);
            foreach (var item in polishmaybe)
            {
                if (item.type == buffType.Chosen) ChosenhM = true;
            }
            bool ExiledDebuffM = new bool(); bool CalmDebuffM = new bool();
            List<DebuffObject> Debuffmaybe = Character.GetDebuffs();
            foreach (var item in Debuffmaybe)
            {
                if (item.type == debuffType.Exiled) ExiledDebuffM = true;
                if (item.type == debuffType.Calm) CalmDebuffM = true;
            }
            if (ChosenhM == true) magicalDamage += (int)(magicalDamage * Character.MagiBuffPercent);
            if (ExiledDebuffM == true) magicalDamage -= (int)(magicalDamage * Character.ExiledDeBuffPercent);
            if (CalmDebuffM == true) magicalDamage -= (int)(magicalDamage * Character.CalmDeBuffPercent);
            #endregion
            #region Target Logic

            bool MArkedDebuffM = new bool();
            List<DebuffObject> DebuffmaybeTar = Target.GetDebuffs();
            foreach (var item in DebuffmaybeTar)
            {
                if (item.type == debuffType.Marked) MArkedDebuffM = true;
            }
            Target.AttackSponser = Character; //for Onguard()
            Target.HitCount++;
            shieldcache = Target.shield;
            magrescache = Target.MagicRes;
            if (Target.ImmuneState == true) magicalDamage = 0;
            shieldcache -= magicalDamage; Target.shield -= magicalDamage;
            if (Target.ProtectionSponser != null) Target = (Persona)Target.ProtectionSponser;
            if (MArkedDebuffM == true) magicalDamage += (int)(magicalDamage * markedda);

            if (shieldcache < 0)//this asks if there is no more sheild left
            {
                magrescache += shieldcache;// here the negative value adds with the positive- following negative number addition laws i hope
                if (magrescache < 0)//this asks if there is no more resistance left
                {
                    Target.MagicRes = 0;
                    hitval.DamageValue = Math.Abs(magrescache);
                    Character.TrueDamage(Character, Target, hitval); //This removes the health of the target
                }
                else { Target.MagicRes = magrescache; }
            }
            else
            {
                Target.shield = shieldcache;
            }
            Target.ProtectionSponser = null;
            #endregion

        }
        public void Drain(object CharacterInstance, object TargetInstance)
        {
            Persona Character = (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;

            DamageObject hitval = new DamageObject();
            hitval.DamageValue = Target.Health * Character.DrainPercent;
            hitval.DamageTrait = DamageObject.DamageVersion.True;

            AttackObject attackObject = null;
            attackObject = new AttackObject()
            {
                state = true,
                type = AttackType.Drain,
                amount = hitval.DamageValue
            };
            Character.AttacksGiven.Add(attackObject);

            Target.AttackSponser = Character;
            if (Target.ImmuneState == true)
            { }
            else { Target.HealthLoss(hitval); }

        }
        public void Ignite(object CharacterInstance, object TargetInstance, int amount)
        {
            Persona Character = (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;

            DamageObject hitval = new DamageObject();
            hitval.DamageValue = amount;
            hitval.DamageTrait = DamageObject.DamageVersion.Magical;

            AttackObject attackObject = null;
            attackObject = new AttackObject()
            {
                state = true,
                type = AttackType.Ignite,
                amount = hitval.DamageValue
            };
            Character.AttacksGiven.Add(attackObject);

            bool howmany = RoundInfo.RoundDone;
            int count = 0;
            if (howmany != RoundInfo.RoundDone)
            {
                count++;
                howmany = RoundInfo.RoundDone;
            }
            if (count == 2)
            {
                if (Target.ImmuneState == true)
                { }
                else
                {
                    MagicalDamage(CharacterInstance, TargetInstance, amount);
                }
            }

        }
        public void Bleed(object CharacterInstance, object TargetInstance)
        {
            Persona Character = (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;

            DamageObject hitval = new DamageObject();
            hitval.DamageTrait = DamageObject.DamageVersion.Physical;

            AttackObject attackObject = null;
            attackObject = new AttackObject()
            {
                state = true,
                type = AttackType.Bleed,
            };
            Character.AttacksGiven.Add(attackObject);

            if (Target.ImmuneState == true)
            { }
            else { if (RoundInfo.RoundDone == true) PhysicalDamage(CharacterInstance, TargetInstance); }

        }
        public void Bleed(object CharacterInstance, object TargetInstance, DamageObject damageObject)
        {
            Persona Character = (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;

            DamageObject hitval = new DamageObject();
            hitval.DamageTrait = DamageObject.DamageVersion.Physical;

            AttackObject attackObject = null;
            attackObject = new AttackObject()
            {
                state = true,
                type = AttackType.Bleed,
            };
            Character.AttacksGiven.Add(attackObject);

            if (Target.ImmuneState == true)
            { }
            else { if (RoundInfo.RoundDone == true) PhysicalDamage(CharacterInstance, TargetInstance, damageObject); }

        }// check reference foe explaination
        public void Blight(object CharacterInstance, object TargetInstance, int amountOfRounds, int amountOfDamage)
        {
            Persona Character = (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;

            DamageObject hitval = new DamageObject();
            hitval.DamageTrait = DamageObject.DamageVersion.Magical;

            AttackObject attackObject = null;
            attackObject = new AttackObject()
            {
                state = true,
                type = AttackType.Blight,
                amount = amountOfDamage,
                roundsActive = amountOfRounds
            };
            Character.AttacksGiven.Add(attackObject);

            int countofroundsineffect = 0;
            int Numberroun = RoundInfo.RoundsPassed;

            Timer Choisss;
            Choisss = new Timer();
            // Tell the timer what to do when it elapses
            Choisss.Elapsed += new ElapsedEventHandler(Maaama);
            // Set it to go off every one seconds
            Choisss.Interval = 1000;
            // And start it        
            Choisss.Enabled = true;
            void Maaama(object source2, ElapsedEventArgs e)
            {
                if (RoundInfo.RoundsPassed > Numberroun)
                {

                    Numberroun = RoundInfo.RoundsPassed;
                    countofroundsineffect++;
                    if (Target.ImmuneState == true)
                    { }
                    else
                    {
                        MagicalDamage(CharacterInstance, TargetInstance, amountOfDamage);
                    }
                }
                if (countofroundsineffect >= amountOfRounds) Choisss.Close();
            }
        }
        public void BalancedDamage(object CharacterInstance, object TargetInstance)
        {
            int Dama = 0;
            int shieldcache = 0;
            int armourcahe = 0;
            int magrescache = 0;
            double markedda = 0;

            Persona Character = (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;
            Dama = Character.DamageGiven();

            DamageObject hitval = new DamageObject();
            hitval.DamageTrait = DamageObject.DamageVersion.Balanced;

            AttackObject attackObject = null;
            attackObject = new AttackObject()
            {
                state = true,
                type = AttackType.BalancedDamage,
                amount = Dama
            };
            Character.AttacksGiven.Add(attackObject);

            #region Character Logic

            bool CalmDebuffM = new bool();
            List<DebuffObject> Debuffmaybe = Character.GetDebuffs();
            foreach (var item in Debuffmaybe)
            {
                if (item.type == debuffType.Calm) CalmDebuffM = true;
            }
            if (CalmDebuffM == true) Dama -= (int)(Dama * Character.CalmDeBuffPercent);
            markedda = Character.MarkedDeBuffPerent;
            if (Character.CriticalChance == true)
            {
                Random vox = new Random();
                int skylar = vox.Next(1, 101);
                if (skylar < Character.CritC) Dama += Dama;
                Character.CriticalChance = false;
            }

            #endregion
            #region Target Logic

            bool MArkedDebuffM = new bool();
            List<DebuffObject> DebuffmaybeTar = Target.GetDebuffs();
            foreach (var item in DebuffmaybeTar)
            {
                if (item.type == debuffType.Marked) MArkedDebuffM = true;
            }
            Target.AttackSponser = Character;
            if (Target.ImmuneState == true) Dama = 0;
            if (Target.ProtectionSponser != null) Target = (Persona)Target.ProtectionSponser;
            if (MArkedDebuffM == true) Dama += (int)(Dama * markedda);

            Target.HitCount++;
            shieldcache = Target.shield;
            armourcahe = Target.Armour;
            magrescache = Target.MagicRes;
            shieldcache -= Dama; Target.shield -= Dama;
            //the code below ensures that the sheild is removed first
            if (shieldcache < 0)//this asks if there is no more sheild left
            {
                armourcahe += shieldcache / 2;// here the negative value adds with the positive- following negative number addition laws i hope
                if (armourcahe < 0)//this asks if there is no more armour left
                {
                    Target.Armour = 0; // this makes sure armour is zero
                    hitval.DamageValue = Math.Abs(armourcahe);
                    Character.TrueDamage(Character, Target, hitval); //This removes the health of the target
                }
                else { Target.Armour = armourcahe; }

                magrescache += shieldcache / 2;// here the negative value adds with the positive- following negative number addition laws i hope
                if (magrescache < 0)//this asks if there is no more armour left
                {
                    Target.MagicRes = 0;
                    hitval.DamageValue = Math.Abs(magrescache);
                    Character.TrueDamage(Character, Target, hitval); //This removes the health of the target
                }
                else { Target.MagicRes = magrescache; }
            }
            else
            {
                Target.shield = shieldcache; //this shouldn't be here at all but imleaving it here just in case
            }
            Target.ProtectionSponser = null;
            #endregion

        }
        public void Curse(object CharacterInstance, object TargetInstance)
        {
            int randamage = 0;
            double markedda = 0;

            Persona Character = (Persona)CharacterInstance;
            Persona Target = (Persona)TargetInstance;

            DamageObject hitval = new DamageObject();
            hitval.DamageTrait = DamageObject.DamageVersion.Magical;

            AttackObject CurseattackObject = null; //I called it CurseAttackobject cause it needed a different name so there would be no ambiguity since curse lasts
            CurseattackObject = new AttackObject()
            {
                state = true,
                type = AttackType.Curse
            };
            Character.AttacksGiven.Add(CurseattackObject);

            Target.AttackSponser = Character;// I have doubts that this should be here

            markedda = Character.MarkedDeBuffPerent;
            int roundhaspassed = 0;
            Timer Scar;
            Scar = new Timer();
            // Tell the timer what to do when it elapses
            Scar.Elapsed += new ElapsedEventHandler(Scarer);
            // Set it to go off every one seconds
            Scar.Interval = 1000;
            // And start it        
            Scar.Enabled = true;

            roundhaspassed = RoundInfo.RoundsPassed;
            //this is supposed to add to a list up to 5, of the last person to cause you damage. Its called in the constructor and hopefully runs the whole time. 

           
            void Scarer(object source2, ElapsedEventArgs e)
            {
                if (RoundInfo.RoundsPassed < roundhaspassed + 1)
                {
                    Random r = new Random();
                    if (Target.ProtectionSponser != null) Target = (Persona)Target.ProtectionSponser;
                    randamage = r.Next(1, Character.CursePercent);
                    CurseattackObject.amount = randamage;
                    if (Target.ImmuneState == true)
                    { }
                    else
                    {
                        Character.MagicalDamage(Character, Target, randamage);
                    }
                }
            }
        }

        public bool Feign(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

    }
}
