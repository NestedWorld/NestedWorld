using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedWorld.Classes.ElementsGame.Monsters
{
    public class MonsterList
    {
        private UserMonster _selectedMonster;

        public List<UserMonster> monsterList { get; set; }

        public UserMonster selectedMonster
        {
            get
            {
                
                return (_selectedMonster == null) ? monsterList[0] : _selectedMonster;
            }
            set
            {
                _selectedMonster = value;
            }
        }

       

        public MonsterList()
        {
            monsterList = new List<UserMonster>();
        }

        public MonsterList(JObject obj)
        {
            _selectedMonster = null;
        }

        public void init()
        {
            Add(new UserMonster(new Monster("monsterOne", TypeEnum.DIRT, "ms-appx:///Assets/iconTest.png", 1), 5));
            Add(new UserMonster(new Monster("Shark Sword", TypeEnum.WATHER, "ms-appx:///Assets/monsterTest/test.png", 2), 5));
            Add(new UserMonster(new Monster("monsterOne", TypeEnum.FIRE, "ms-appx:///Assets/iconTest.png", 3), 10));
            Add(new UserMonster(new Monster("monsterOne", TypeEnum.DIRT, "ms-appx:///Assets/iconTest.png", 4), 8));
            Add(new UserMonster(new Monster("monsterOne", TypeEnum.ELEC, "ms-appx:///Assets/iconTest.png", 5), 3));
            Add(new UserMonster(new Monster("monsterOne", TypeEnum.GRASS, "ms-appx:///Assets/iconTest.png", 6), 2));
            Add(new UserMonster(new Monster("monsterOne", TypeEnum.DIRT, "ms-appx:///Assets/iconTest.png", 7), 5));
            Add(new UserMonster(new Monster("monsterOne", TypeEnum.WATHER, "ms-appx:///Assets/monsterTest/test.png", 8), 2));
            Add(new UserMonster(new Monster("monsterOne", TypeEnum.FIRE, "ms-appx:///Assets/iconTest.png", 9), 1));
            Add(new UserMonster(new Monster("monsterOne", TypeEnum.DIRT, "ms-appx:///Assets/iconTest.png", 10), 3));
            Add(new UserMonster(new Monster("monsterOne", TypeEnum.ELEC, "ms-appx:///Assets/iconTest.png", 11), 4));
            Add(new UserMonster(new Monster("monsterOne", TypeEnum.GRASS, "ms-appx:///Assets/iconTest.png", 12), 9));
        }
        public void Add(UserMonster newMonster)
        {
            if (newMonster == null)
                return;
            monsterList?.Add(newMonster);
        }

        public UserMonster GetMonsterByID(int ID)
        {
            var querry = from item in monsterList where item.ID == ID select item;

            foreach (UserMonster monster in querry)
            {
                Debug.WriteLine(monster.Name);
            }

            if (querry.Count() != 0)
                return querry.ElementAt(0);
            return null;
        }
    }
}
