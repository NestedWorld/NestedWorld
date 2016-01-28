using NestedWorld.Classes.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls.Maps;

namespace NestedWorld.Classes.ElementsGame.Maps
{
    public class Area
    {
        public List<BasicGeoposition> PositionList { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }



        public List<Model.Item> ItemList { get; set; }
        public List<Monsters.UserMonster> MonsterList { get; set; }

        public UserEnum UserEnum { get; set; }


        public Area(string name, string image)
        {
            Name = name;
            Image = image;
        }

        public Area(string name, string image, List<BasicGeoposition> positionList)
            : this(name, image)
        {
            PositionList = new List<BasicGeoposition>(positionList);
        }

        public Area(string name, string image, List<BasicGeoposition> positionList, List<Model.Item> itemList)
            : this(name, image, positionList)
        {
            ItemList = new List<Model.Item>(itemList);
        }

        public Area(string name, string image, List<BasicGeoposition> positionList, List<Model.Item> itemList, List<Monsters.UserMonster> monsterList)
            : this(name, image, positionList, itemList)
        {
            MonsterList = new List<Monsters.UserMonster>(monsterList);
        }

        public MapPolygon getPolygon()
        {
            MapPolygon ret = new MapPolygon
            {
                StrokeThickness = 3,
                StrokeDashed = true,
                ZIndex = 1,
                FillColor = Utils.ColorUtils.GetColorFromHex("#99424242"),
                StrokeColor = Utils.ColorUtils.GetColorFromHex("#FF424242"),
                Path = new Geopath(PositionList)
            };
            return ret;
        }

        public bool PointOnIt(BasicGeoposition pos)
        {
            return true;
        }
    }
}
