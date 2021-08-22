using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assets.Scripts.Entities.Character.Persona;

namespace Assets.Scripts.Interface.CardInterfaces.ICombatant
{
    interface IWarriorTraits
    {
        string BriefDescription { get; set; }
        List<SpeciesType> NaturalAllies { get; set; }
        List<SpeciesType> NaturalEnemies { get; set; }
        bool PassiveWarriorTraits { get; set; }
    }
}
