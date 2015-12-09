using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedWorld.Classes.ElementsGame.Battle
{
    public abstract class Patern
    {
        protected List<int> patern { get; set; }

        protected BattleCore Core { get; set; }

        public Patern(BattleCore core, List<int> patern)
        {
            this.patern = patern;
            Core = core;
        }

        public bool isThisPatern(List<int> paternCompart)
        {
            if (patern.Count != paternCompart.Count)
                return false;
            for (int i = 0; i < patern.Count; i++)
            {

                if (paternCompart[i] != patern[i])
                    return false;
            }
            return true;
        }

        public abstract void Execute();
    }
}
