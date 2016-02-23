using NestedWorld.Classes.ElementsGame.GameCore;
using NestedWorld.Classes.ElementsGame.Maps;
using NestedWorld.Classes.ElementsGame.Monsters;
using NestedWorld.Classes.ElementsGame.Shop;
using NestedWorld.Classes.ElementsGame.Users;
using NestedWorld.View.MonsterViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using NestedWorld.Pages;

namespace NestedWorld.Classes
{
    public class Core
    {
        public MapCore mapCore { get; set; }
        public Garden.Garden garden { get; set; }

        public MonsterList monsterList { get; set; }
        public MonsterList monsterUserList { get; set; }


        public UserList userList { get; set; }
        public AreaList areaList { get; set; }

        public UserInfo user { get; set; }

        public bool Offline { get; set; }

        public Shop Shop { get; set; }
        public Core()
        {
            Offline = true;
            user = UserInfo.GetYou();
            userList = new UserList();

            monsterList = new MonsterList();
            monsterUserList = new MonsterList();
            userList = new UserList();
            areaList = new AreaList();
            //garden = new Garden.Garden();
            mapCore = new MapCore(user);
            Shop = new Shop();
        }

        public async void ShowError(string ErrorMessage)
        {
            if (ErrorMessage == string.Empty)
                return;
            var messageDialog = new MessageDialog(ErrorMessage);
            await messageDialog.ShowAsync();
        }

        public async Task Init()
        {

            userList.Init();

            var ret = await App.network.GetMonster();
            monsterList = ret.Content as MonsterList;
            ret.ShowError();
            ret = await App.network.GetUserMonster();
            monsterUserList = ret.Content as MonsterList;
            ret.ShowError();
        }

        public void SetValue(HomePage homePage)
        {
            homePage.ShopView.shop = Shop;
        }


    }
}
