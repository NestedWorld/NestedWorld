using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedWorld.Classes.ElementsGame.Battle.Paterns
{
    public class AttackSpePatern : Patern
    {
        public AttackSpePatern(BattleCore core) : base(core, new List<int> { 1, 2, 3, 4, 5, 6 })
        { }


        public override void Execute()
        {
            System.Diagnostics.Debug.WriteLine("AttackSpe");
        }
    }
}
