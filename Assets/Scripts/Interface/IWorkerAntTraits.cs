using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assets.Scripts.Models.Enums;

namespace Assets.Scripts.Interface
{
    interface IWorkerAntTraits
    {
        void Farm();
        void Mine();
        void Smith(ToolType tooltype);
        void Craft();
        void Forage();

    }
}
