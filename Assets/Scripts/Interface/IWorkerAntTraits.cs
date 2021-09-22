using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interface
{
    interface IWorkerAntTraits
    {
        public void Farm();
        public void Mine();
        public void Smith();
        public void Craft();
        public void Forage();

    }
}
