using Assets.Scripts.Entities.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assets.Scripts.Helpers
{
    class BalanceManager
    {
        Persona Individual;
        bool AdminPower;

        (string _LcharacterName, int _Llife, int _Lhealth, double _Ldodge, double _Lspeed, double _Lcritc, int _Lmagres, int _Larmour, int _Lshield, double _Laccuracy) Stats;
        (int _LDrainpercent, int _LCurseMaxint) AttackMultipler;
        (double _Larmourpercentage, double _Lmagrespercentage, double _LshieldPercentage) DefenceMultipler;
        (double _LpowerBuffPercent, double _LevadeBuffPercent, double _LagileBuffPercent, double _LhealbuffPercent, double _LmagicBuffPercent) BuffMultipler;
        (double _LslowDebuffpercent, double _LrootedDeuffPercent, double _LweakGripPercent, double _Lexiledpercent, double _LMarkedpercent, double _Lcalmdebuffpercent) DebuffMultipler;

        #region Collection Functions
        //Method is called CollectStats
        public (string _LcharacterName, int _Llife, int _Lhealth, double _Ldodge, double _Lspeed, double _Lcritc, int _Lmagres, int _Larmour, int _Lshield, double _Laccuracy) CollectStats(object CharacterIntance)
        {
            Persona Character = (Persona)CharacterIntance;
            return (Character.CharacterName, Character.Life, Character.Health, Character.dodge, Character.Speed, Character.CritC, Character.MagicRes, Character.Armour, Character.shield, Character.Accuracy);
        }

        //Method is called CollectAttackMultipler
        public (int _LDrainpercent, int _LCurseMaxint) CollectAttackMultipler(object CharacterInstance)
        {
            Persona Character = (Persona)CharacterInstance;
            return (Character.DrainPercent, Character.CurseMaxint);
        }

        //Method is called CollectStatsDefenceMultipler
        public (double _Larmourpercentage, double _Lmagrespercentage, double _LshieldPercentage) CollectDefenceMultipler(object CharacterInstance)
        {
            Persona Character = (Persona)CharacterInstance;
            return (Character.defenceArmourPercentage, Character.defenceMagresPercentage, Character.defenceSheildPercentage);
        }

        //Method is called CollectBuffMultipler
        public (double _LpowerBuffPercent, double _LevadeBuffPercent, double _LagileBuffPercent, double _LhealbuffPercent, double _LmagicBuffPercent) CollectBuffMultipler(object CharacterInstance)
        {
            Persona Character = (Persona)CharacterInstance;
            return (Character.PowerBuffPercent, Character.EvadeBuffPercent, Character.AgileBUffPercent, Character.HealBuffPercent, Character.MagiBuffPercent);
        }

        //Method is called CollectDebuffMultipler
        public (double _LslowDebuffpercent, double _LrootedDeuffPercent, double _LweakGripPercent, double _Lexiledpercent, double _LMarkedpercent, double _Lcalmdebuffpercent) CollectDebuffMultipler(object CharacterInstance)
        {
            Persona Character = (Persona)CharacterInstance;
            return (Character.SlowDeBuffPercent, Character.RootedDeBuffPercent, Character.WeakGripDeBuffPercent, Character.ExiledDeBuffPercent, Character.MarkedDeBuffPerent, Character.CalmDeBuffPercent);
        }

        void Syncro()
        {
            while (AdminPower == true)
            {
                Stats = CollectStats(Individual);
                AttackMultipler = CollectAttackMultipler(Individual);
                DefenceMultipler = CollectDefenceMultipler(Individual);
                BuffMultipler = CollectBuffMultipler(Individual);
                DebuffMultipler = CollectDebuffMultipler(Individual);

                Individual.Life = Stats._Llife; Individual.Health = Stats._Lhealth; Individual.dodge = Stats._Ldodge; Individual.Speed = Stats._Lspeed;
                Individual.CritC = Stats._Lcritc; Individual.MagicRes = Stats._Lmagres; Individual.Armour = Stats._Larmour; Individual.shield = Stats._Lshield; Individual.Accuracy=Stats._Laccuracy;

                Individual.DrainPercent = AttackMultipler._LDrainpercent; Individual.CurseMaxint = AttackMultipler._LCurseMaxint;

                Individual.defenceArmourPercentage = DefenceMultipler._Larmourpercentage; Individual.defenceMagresPercentage = DefenceMultipler._Lmagrespercentage;
                Individual.defenceSheildPercentage = DefenceMultipler._LshieldPercentage;

                Individual.PowerBuffPercent = BuffMultipler._LpowerBuffPercent; Individual.EvadeBuffPercent = BuffMultipler._LevadeBuffPercent; 
                Individual.AgileBUffPercent = BuffMultipler._LagileBuffPercent;
                Individual.HealBuffPercent = BuffMultipler._LhealbuffPercent; Individual.MagiBuffPercent = BuffMultipler._LmagicBuffPercent;

                Individual.SlowDeBuffPercent = DebuffMultipler._LslowDebuffpercent; Individual.RootedDeBuffPercent = DebuffMultipler._LrootedDeuffPercent;
                Individual.WeakGripDeBuffPercent = DebuffMultipler._LweakGripPercent; Individual.ExiledDeBuffPercent = DebuffMultipler._Lexiledpercent;
                Individual.MarkedDeBuffPerent = DebuffMultipler._LMarkedpercent; Individual.CalmDeBuffPercent = DebuffMultipler._Lcalmdebuffpercent;
            }
        }
        #endregion

        public void LiveCharacterValues(object CharacterInstance)
        {
            Individual = (Persona)CharacterInstance;
            
            ThreadStart LiveCharacterstats = new ThreadStart(Syncro);
            Thread LiveThread = new Thread(LiveCharacterstats);
            LiveThread.Start();

            if (AdminPower == false) LiveThread.Abort();
        }
    }
}
