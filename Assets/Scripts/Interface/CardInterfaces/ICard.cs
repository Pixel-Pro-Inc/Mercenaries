using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interface.CardInterfaces
{
    interface ICard
    {
        void passiveTraits();
        void DragAction();
        void FlipAction();
    }
}
