using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedWorld.Classes.ElementsGame.Monsters
{
    public class MonsterAttckList
    {
        public List<MonsterAttack> monsterAttackList { get; set; }

        public MonsterAttckList()
        {
            monsterAttackList = new List<MonsterAttack>();
            Add(new MonsterAttack("attack1", "ms-appx:///Assets/NestedWorldLogo.png", 5, TypeEnum.FIRE, AttackTypeEnum.ATT));
            Add(new MonsterAttack("attack2", "ms-appx:///Assets/NestedWorldLogo.png", 1, TypeEnum.DIRT, AttackTypeEnum.DEF));
            Add(new MonsterAttack("attack3", "ms-appx:///Assets/NestedWorldLogo.png", 6, TypeEnum.GRASS, AttackTypeEnum.SPEATT));
            Add(new MonsterAttack("attack4", "ms-appx:///Assets/NestedWorldLogo.png", 2, TypeEnum.WATHER, AttackTypeEnum.SPEDEF));
            //Add(new MonsterAttack("attack5", "ms-appx:///Assets/NestedWorldLogo.png", 4, TypeEnum.FIRE, AttackTypeEnum.ATT));
        }

        public void Add(MonsterAttack newAttack)
        {
            monsterAttackList.Add(newAttack);
        }
    }
}
