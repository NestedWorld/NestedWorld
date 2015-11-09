using NestedWorld.Classes.ElementsGame.Areas;
using NestedWorld.Classes.ElementsGame.Monsters;
using NestedWorld.Classes.ElementsGame.Users;
using NestedWorld.View.MonsterViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedWorld.Classes.ElementsGame.GameCore
{
    public class Core
    {
        public MonsterFullView mfv { get; set; }
        private UserMonster _monsterSelected;
        public UserMonster monsterSelected {
            get { return _monsterSelected; }
            set {
                _monsterSelected = value;
                mfv.monsterToDisplay = value;
            }
        }
        public MonsterList monsterList { get; set; }
        public MonsterList monsterUserList { get; set; }
        public UserList userList { get; set; }
        public AreaList areaList { get; set; }
        public Core()
        {
            monsterList = new MonsterList();
            monsterList.init();
            monsterUserList = new MonsterList();
            userList = new UserList();
            areaList = new AreaList();
        } 

    }
}
