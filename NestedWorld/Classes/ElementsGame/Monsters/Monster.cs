using NestedWorld.View.MapPoint;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace NestedWorld.Classes.ElementsGame.Monsters
{
    public class Monster
    {
        public MonsterMapPoint mmp;

        public MonsterAttckList monsterAttackList { get; set; }
        public string Name { get; private set; }
        public TypeEnum Type { get; private set; }
        public Color color { get { return (Utils.ColorUtils.GetColorFromHex(Utils.ColorUtils.GetTypeColor(Type))); } set { int i = 0; i++; } }
        public SolidColorBrush Brush { get { return new SolidColorBrush(color); } set { int i = 0; i++; } }
        public string Image { get; private set; }
        public string ImageBackground { get; private set; }
        public string ImageType { get { return Utils.ImageUtils.GetImageType(Type); } set { int i = 0; i++; } }
        public string Info { get; private set; }

        public bool PlayerMonster { get; set; }
        public int Level { get; private set; }

        public int Life { get; private set; }
        public int Exp { get; private set; }
        public int Attack { get; private set; }
        public int Defence { get; private set; }
        public string Surname { get; private set; }

        public int ID { get; private set; }

        public Monster(string name, TypeEnum type, string image, int id, string info)
        {
            this.Name = name;
            this.Type = type;
            this.Image = image;
            this.ID = id;
            monsterAttackList = new MonsterAttckList();
            mmp = new MonsterMapPoint();
            mmp.DataContext = this;
            Info = info;
            PlayerMonster = false;
            this.ImageBackground = "http://www.intrawallpaper.com/static/images/abstract-mosaic-background.png";
        }

        public Monster(int ID, string name, TypeEnum type, string image, string info,
           int level = 0, int live = 0, int exp = 0, int attack = 0, int def = 0, string surname = null)
            : this(name, type, image, ID, info)
        {
            if (level != 0)
                this.PlayerMonster = true;
            this.Level = level;
            this.Life = live;
            this.Exp = exp;
            this.Attack = attack;
            this.Defence = def;
            this.Surname = surname;
        }


        internal static Monster GetMonster(JObject jObject)
        {
            try
            {
                return new Monster(jObject["id"].ToObject<int>(),
                    jObject["name"].ToObject<string>(),
                    Utils.RandomValue.GetRandValueType(),
                    "ms-appx:///Assets/default_monster.png",
                    "Monster Description");

            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetMonster : " + ex.ToString());
            }
            return null;

        }

        internal static Monster GetUserMonster(JObject jObject)
        {
            try
            {
                return new Monster(jObject["id"].ToObject<int>(),
                    jObject["name"].ToObject<string>(),
                    Utils.RandomValue.GetRandValueType(),
                    "ms-appx:///Assets/default_monster.png",
                    "Monster Description",
                    jObject["level"].ToObject<int>(),
                    jObject["hp"].ToObject<int>(),
                    jObject["experience"].ToObject<int>(),
                    jObject["attack"].ToObject<int>(),
                    jObject["defense"].ToObject<int>(),
                    jObject["surname"].ToObject<string>());
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetMonster : " + ex.ToString());
            }
            return null;
        }

        internal static Monster GetMonster(int ID)
        {
            return new Monster(ID, "Monster " + ID.ToString(), Utils.RandomValue.GetRandValueType(), "ms-appx:///Assets/default_monster.png", "Monster's Info");
        }


        internal static Monster GetUserMonster(int ID)
        {
            return new Monster(ID, "Monster " + ID.ToString(), Utils.RandomValue.GetRandValueType(), "ms-appx:///Assets/default_monster.png", "Monster's Info",
                Utils.RandomValue.GetRandValue(0, 50),
                Utils.RandomValue.GetRandValue(0, 50),
                Utils.RandomValue.GetRandValue(0, 50),
                Utils.RandomValue.GetRandValue(0, 50),
                Utils.RandomValue.GetRandValue(0, 50),
                "Monster " + ID.ToString() + "'s surname");
        }

    }
}
