using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedWorld.Classes.ElementsGame.Battle.Paterns
{
    public class UseToolsPatern : Patern
    {
        public UseToolsPatern(BattleCore core) : base(core, new List<int> { 3, 5, 2, 6 })
        { }


        public override void Execute()
        {
            Debug.WriteLine("tool");
        }
    }
}