using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedWorld.Classes.ElementsGame.Battle.Paterns
{
    public class AttackPatern : Patern
    {
        public AttackPatern(BattleCore core) : base(core, new List<int> { 1, 4 })
        { }


        public override void Execute()
        {
         //   Core.UserMonster.selectedMonster.Attack(Core.EnemieMonster.selectedMonster);
           // Core.Page.Annimation.Attack();
        }
    }
}
