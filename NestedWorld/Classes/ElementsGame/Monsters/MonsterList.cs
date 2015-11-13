using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedWorld.Classes.ElementsGame.Monsters
{
    public class MonsterList
    {
        public List<UserMonster> monsterList { get; set; }

        public MonsterList()
        {
            monsterList = new List<UserMonster>();
        }

        public MonsterList(JObject obj)
        {

        }

        public void init()
        {
            Add(new UserMonster(new Monster("monsterOne", TypeEnum.DIRT, "ms-appx:///Assets/iconTest.png", 1), 5));
            Add(new UserMonster(new Monster("Shark Sword", TypeEnum.WATHER, "ms-appx:///Assets/monsterTest/test.png", 2), 5));
            Add(new UserMonster(new Monster("monsterOne", TypeEnum.FIRE, "ms-appx:///Assets/iconTest.png", 3), 10));
            Add(new UserMonster(new Monster("monsterOne", TypeEnum.DIRT, "ms-appx:///Assets/iconTest.png", 4), 8));
            Add(new UserMonster(new Monster("monsterOne", TypeEnum.ELEC, "ms-appx:///Assets/iconTest.png", 5), 3));
            Add(new UserMonster(new Monster("monsterOne", TypeEnum.GRASS, "ms-appx:///Assets/iconTest.png", 6), 2));
            Add(new UserMonster(new Monster("monsterOne", TypeEnum.DIRT, "ms-appx:///Assets/iconTest.png", 1), 5));
            Add(new UserMonster(new Monster("monsterOne", TypeEnum.WATHER, "ms-appx:///Assets/monsterTest/test.png", 2), 2));
            Add(new UserMonster(new Monster("monsterOne", TypeEnum.FIRE, "ms-appx:///Assets/iconTest.png", 3), 1));
            Add(new UserMonster(new Monster("monsterOne", TypeEnum.DIRT, "ms-appx:///Assets/iconTest.png", 4), 3));
            Add(new UserMonster(new Monster("monsterOne", TypeEnum.ELEC, "ms-appx:///Assets/iconTest.png", 5), 4));
            Add(new UserMonster(new Monster("monsterOne", TypeEnum.GRASS, "ms-appx:///Assets/iconTest.png", 6), 9));
        }
        public void Add(UserMonster newMonster)
        {
            monsterList?.Add(newMonster);
        }
    }
}
