using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedWorld.Classes.ElementsGame.Battle.Paterns
{
    public class DefenceSpePatern : Patern
    {
        public DefenceSpePatern(BattleCore core) : base(core, new List<int> { 1, 6, 5, 4, 3, 2 })
        { }


        public override void Execute()
        {
            System.Diagnostics.Debug.WriteLine("DefenceSpe");
        }
    }
}
