using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Helpers
{
    public class Debuff
    {
        public void Slow(object CharacterInstance, object TargetInstance, int charType, int tarType)
        {
            double debuffPercernt = 0;

            switch (charType)
            {
                case 1:
                    debuffPercernt = (double)((WarriorTemplate)CharacterInstance).RootedDeBuffPercent;
                    break;
                case 2:
                    debuffPercernt = (double)((TankWarriorTemplate)CharacterInstance).RootedDeBuffPercent;
                    break;
                case 3:
                    debuffPercernt = (double)((RangeTemplate)CharacterInstance).RootedDeBuffPercent;
                    break;
                case 4:
                    debuffPercernt = (double)((MageTemplate)CharacterInstance).RootedDeBuffPercent;
                    break;
                case 5:
                    debuffPercernt = (double)((ControllerTemplate)CharacterInstance).RootedDeBuffPercent;
                    break;
                case 6:
                    debuffPercernt = (double)((AssasinTemplate)CharacterInstance).RootedDeBuffPercent;
                    break;
            }

            DebuffObject debuffObject = null;

            switch (tarType)
            {
                case 1:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Slow,
                        amount = debuffPercernt
                    };

                    ((WarriorTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 2:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Slow,
                        amount = debuffPercernt
                    };

                    ((TankWarriorTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 3:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Slow,
                        amount = debuffPercernt
                    };

                    ((RangeTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 4:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Slow,
                        amount = debuffPercernt
                    };

                    ((MageTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 5:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Slow,
                        amount = debuffPercernt
                    };

                    ((ControllerTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 6:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Slow,
                        amount = debuffPercernt
                    };

                    ((AssasinTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
            }
        }
        public void Rooted(object CharacterInstance, object TargetInstance, int charType, int tarType)
        {
            double debuffPercernt = 0;

            switch (charType)
            {
                case 1:
                    debuffPercernt = (double)((WarriorTemplate)CharacterInstance).RootedDeBuffPercent;
                    break;
                case 2:
                    debuffPercernt = (double)((TankWarriorTemplate)CharacterInstance).RootedDeBuffPercent;
                    break;
                case 3:
                    debuffPercernt = (double)((RangeTemplate)CharacterInstance).RootedDeBuffPercent;
                    break;
                case 4:
                    debuffPercernt = (double)((MageTemplate)CharacterInstance).RootedDeBuffPercent;
                    break;
                case 5:
                    debuffPercernt = (double)((ControllerTemplate)CharacterInstance).RootedDeBuffPercent;
                    break;
                case 6:
                    debuffPercernt = (double)((AssasinTemplate)CharacterInstance).RootedDeBuffPercent;
                    break;
            }

            DebuffObject debuffObject = null;

            switch (tarType)
            {
                case 1:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Rooted,
                        amount = debuffPercernt
                    };

                    ((WarriorTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 2:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Rooted,
                        amount = debuffPercernt
                    };

                    ((TankWarriorTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 3:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Rooted,
                        amount = debuffPercernt
                    };

                    ((RangeTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 4:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Rooted,
                        amount = debuffPercernt
                    };

                    ((MageTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 5:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Rooted,
                        amount = debuffPercernt
                    };

                    ((ControllerTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 6:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Rooted,
                        amount = debuffPercernt
                    };

                    ((AssasinTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
            }
        }
        public void WeakGrip(object CharacterInstance, object TargetInstance, int charType, int tarType)
        {
            double debuffPercernt = 0;

            switch (charType)
            {
                case 1:
                    debuffPercernt = (double)((WarriorTemplate)CharacterInstance).WeakGripDeBuffPercent;
                    break;
                case 2:
                    debuffPercernt = (double)((TankWarriorTemplate)CharacterInstance).WeakGripDeBuffPercent;
                    break;
                case 3:
                    debuffPercernt = (double)((RangeTemplate)CharacterInstance).WeakGripDeBuffPercent;
                    break;
                case 4:
                    debuffPercernt = (double)((MageTemplate)CharacterInstance).WeakGripDeBuffPercent;
                    break;
                case 5:
                    debuffPercernt = (double)((ControllerTemplate)CharacterInstance).WeakGripDeBuffPercent;
                    break;
                case 6:
                    debuffPercernt = (double)((AssasinTemplate)CharacterInstance).WeakGripDeBuffPercent;
                    break;
            }

            DebuffObject debuffObject = null;

            switch (tarType)
            {
                case 1:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.WeakGrip,
                        amount = debuffPercernt
                    };

                    ((WarriorTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 2:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.WeakGrip,
                        amount = debuffPercernt
                    };

                    ((TankWarriorTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 3:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.WeakGrip,
                        amount = debuffPercernt
                    };

                    ((RangeTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 4:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.WeakGrip,
                        amount = debuffPercernt
                    };

                    ((MageTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 5:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.WeakGrip,
                        amount = debuffPercernt
                    };

                    ((ControllerTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 6:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.WeakGrip,
                        amount = debuffPercernt
                    };

                    ((AssasinTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
            }
        }
        public void Exiled(object CharacterInstance, object TargetInstance, int charType, int tarType)
        {
            double debuffPercernt = 0;

            switch (charType)
            {
                case 1:
                    debuffPercernt = (double)((WarriorTemplate)CharacterInstance).ExiledDeBuffPercent;
                    break;
                case 2:
                    debuffPercernt = (double)((TankWarriorTemplate)CharacterInstance).ExiledDeBuffPercent;
                    break;
                case 3:
                    debuffPercernt = (double)((RangeTemplate)CharacterInstance).ExiledDeBuffPercent;
                    break;
                case 4:
                    debuffPercernt = (double)((MageTemplate)CharacterInstance).ExiledDeBuffPercent;
                    break;
                case 5:
                    debuffPercernt = (double)((ControllerTemplate)CharacterInstance).ExiledDeBuffPercent;
                    break;
                case 6:
                    debuffPercernt = (double)((AssasinTemplate)CharacterInstance).ExiledDeBuffPercent;
                    break;
            }

            DebuffObject debuffObject = null;

            switch (tarType)
            {
                case 1:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Exiled,
                        amount = debuffPercernt
                    };

                    ((WarriorTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 2:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Exiled,
                        amount = debuffPercernt
                    };

                    ((TankWarriorTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 3:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Exiled,
                        amount = debuffPercernt
                    };

                    ((RangeTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 4:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Exiled,
                        amount = debuffPercernt
                    };

                    ((MageTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 5:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Exiled,
                        amount = debuffPercernt
                    };

                    ((ControllerTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 6:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Exiled,
                        amount = debuffPercernt
                    };

                    ((AssasinTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
            }
        }
        public void Marked(object CharacterInstance, object TargetInstance, int charType, int tarType) // Finish this up
        {
            double debuffPercernt = 0;

            switch (charType)
            {
                case 1:
                    debuffPercernt = (double)((WarriorTemplate)CharacterInstance).ExiledDeBuffPercent;
                    break;
                case 2:
                    debuffPercernt = (double)((TankWarriorTemplate)CharacterInstance).ExiledDeBuffPercent;
                    break;
                case 3:
                    debuffPercernt = (double)((RangeTemplate)CharacterInstance).ExiledDeBuffPercent;
                    break;
                case 4:
                    debuffPercernt = (double)((MageTemplate)CharacterInstance).ExiledDeBuffPercent;
                    break;
                case 5:
                    debuffPercernt = (double)((ControllerTemplate)CharacterInstance).ExiledDeBuffPercent;
                    break;
                case 6:
                    debuffPercernt = (double)((AssasinTemplate)CharacterInstance).ExiledDeBuffPercent;
                    break;
            }

            DebuffObject debuffObject = null;

            switch (tarType)
            {
                case 1:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Exiled,
                        amount = debuffPercernt
                    };

                    ((WarriorTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 2:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Exiled,
                        amount = debuffPercernt
                    };

                    ((TankWarriorTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 3:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Exiled,
                        amount = debuffPercernt
                    };

                    ((RangeTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 4:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Exiled,
                        amount = debuffPercernt
                    };

                    ((MageTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 5:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Exiled,
                        amount = debuffPercernt
                    };

                    ((ControllerTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 6:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Exiled,
                        amount = debuffPercernt
                    };

                    ((AssasinTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
            }
        }
        public void Calm(object CharacterInstance, object TargetInstance, int charType, int tarType)
        {
            double debuffPercernt = 0;

            switch (charType)
            {
                case 1:
                    debuffPercernt = (double)((WarriorTemplate)CharacterInstance).CalmDeBuffPercent;
                    break;
                case 2:
                    debuffPercernt = (double)((TankWarriorTemplate)CharacterInstance).CalmDeBuffPercent;
                    break;
                case 3:
                    debuffPercernt = (double)((RangeTemplate)CharacterInstance).CalmDeBuffPercent;
                    break;
                case 4:
                    debuffPercernt = (double)((MageTemplate)CharacterInstance).CalmDeBuffPercent;
                    break;
                case 5:
                    debuffPercernt = (double)((ControllerTemplate)CharacterInstance).CalmDeBuffPercent;
                    break;
                case 6:
                    debuffPercernt = (double)((AssasinTemplate)CharacterInstance).CalmDeBuffPercent;
                    break;
            }

            DebuffObject debuffObject = null;

            switch (tarType)
            {
                case 1:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Calm,
                        amount = debuffPercernt
                    };

                    ((WarriorTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 2:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Calm,
                        amount = debuffPercernt
                    };

                    ((TankWarriorTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 3:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Calm,
                        amount = debuffPercernt
                    };

                    ((RangeTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 4:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Calm,
                        amount = debuffPercernt
                    };

                    ((MageTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 5:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Calm,
                        amount = debuffPercernt
                    };

                    ((ControllerTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 6:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Calm,
                        amount = debuffPercernt
                    };

                    ((AssasinTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
            }
        }
        public void BrokenGaurd(object CharacterInstance, object TargetInstance, int charType, int tarType)
        {
            double debuffPercernt = 0;

            switch (charType)
            {
                case 1:
                    debuffPercernt = (double)((WarriorTemplate)CharacterInstance).BrokenGaurdDeBuffPercent;
                    break;
                case 2:
                    debuffPercernt = (double)((TankWarriorTemplate)CharacterInstance).BrokenGaurdDeBuffPercent;
                    break;
                case 3:
                    debuffPercernt = (double)((RangeTemplate)CharacterInstance).BrokenGaurdDeBuffPercent;
                    break;
                case 4:
                    debuffPercernt = (double)((MageTemplate)CharacterInstance).BrokenGaurdDeBuffPercent;
                    break;
                case 5:
                    debuffPercernt = (double)((ControllerTemplate)CharacterInstance).BrokenGaurdDeBuffPercent;
                    break;
                case 6:
                    debuffPercernt = (double)((AssasinTemplate)CharacterInstance).BrokenGaurdDeBuffPercent;
                    break;
            }

            DebuffObject debuffObject = null;

            switch (tarType)
            {
                case 1:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.BrokenGaurd,
                        amount = debuffPercernt
                    };

                    ((WarriorTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 2:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.BrokenGaurd,
                        amount = debuffPercernt
                    };

                    ((TankWarriorTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 3:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.BrokenGaurd,
                        amount = debuffPercernt
                    };

                    ((RangeTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 4:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.BrokenGaurd,
                        amount = debuffPercernt
                    };

                    ((MageTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 5:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.BrokenGaurd,
                        amount = debuffPercernt
                    };

                    ((ControllerTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 6:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.BrokenGaurd,
                        amount = debuffPercernt
                    };

                    ((AssasinTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
            }
        }
        public void Stun(object CharacterInstance, object TargetInstance, int charType, int tarType)
        {
            DebuffObject debuffObject = null;
            double debuffPercernt = 0;

            switch (tarType)
            {
                case 1:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Stun,
                        amount = debuffPercernt
                    };

                    ((WarriorTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 2:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Stun,
                        amount = debuffPercernt
                    };

                    ((TankWarriorTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 3:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Stun,
                        amount = debuffPercernt
                    };

                    ((RangeTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 4:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Stun,
                        amount = debuffPercernt
                    };

                    ((MageTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 5:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Stun,
                        amount = debuffPercernt
                    };

                    ((ControllerTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
                case 6:
                    debuffObject = new DebuffObject()
                    {
                        state = true,
                        type = debuffType.Stun,
                        amount = debuffPercernt
                    };

                    ((AssasinTemplate)TargetInstance).AddDebuff(debuffObject);
                    break;
            }
        }
    }
}
