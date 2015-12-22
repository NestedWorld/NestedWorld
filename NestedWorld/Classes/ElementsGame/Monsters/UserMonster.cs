using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedWorld.Classes.ElementsGame.Monsters
{
    public class UserMonster : Monster
    {
        public UserMonster This { get; private set; }
        public int Level { get; private set; }
        public bool IsOnList { get; set; }

        public int Life { get; private set; }
        public int Exp { get; private set; }

        public void Attack(UserMonster selectedMonster)
        {
            selectedMonster.reciveAttack(-10);
        }

        private void reciveAttack(int v)
        {
            Life += v;
        }

        public UserMonster(Monster monsterBase, int level)
            : base(monsterBase)
        {
            this.Level = level;
            IsOnList = false;
            This = this;
            Life = 100;
            Exp = 10;
        }

      }
}
