using NestedWorld.Classes.ElementsGame.Monsters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls.Maps;
using NestedWorld.Utils;
using System.Diagnostics;

namespace NestedWorld.Classes.ElementsGame.Maps
{
    public class AreaList
    {
        private List<Area> _list;

        public List<Area> list { get { return _list; } set { _list = value; } }

        public ObservableCollection<Area> content { get { return new ObservableCollection<Area>(list); } set { int i = 0; i++; } }


        public AreaList()
        {
            list = new List<Area>();
        }

        public void Add(Area newArea)
        {
            list.Add(newArea);
        }

        public void Clean()
        {
            list.Clear();
        }

        public Area GetAreaTaped(BasicGeoposition tappedGeoPosition)
        {

            foreach (Area area in list)
            {
                if (area.PointOnIt(tappedGeoPosition))
                    return area;
            }
            return null;
        }

        public void Init()
        {
            Add(new Area("Guadalajara", "http://allaboutguadalajara.com/wp-content/uploads/Guad_Main.jpg",
                GenerateGeoPoint(
                   new BasicGeoposition
                   {
                       Latitude = 20.733433,
                       Longitude = -103.4582296
                   },
                    new BasicGeoposition
                    {
                        Latitude = 20.681559,
                        Longitude = -103.3247552,
                    },
                      new BasicGeoposition
                      {
                          Latitude = 20.6748909,
                          Longitude = -103.3574124,
                      }
                    ),
                GenerateItemList(new Model.Item("flower", 0, "desc", "ms-appx:///Assets/Flower/flowerFire.png", 0, 0, 0, 0), new Model.Item("flower", 0, "desc", "ms-appx:///Assets/Flower/flowerFire.png", 0, 0, 0, 0), new Model.Item("flower", 0, "desc", "ms-appx:///Assets/Flower/flowerFire.png", 0, 0, 0, 0)),
               MonsterList.GetMonsterListFromJson(null)));
        }


        public void Show(MapControl map)
        {
            try
            {
                foreach (Area a in list)
                {
                    var shape = a.getPolygon();
                    shape.AddData(a);
                    map.MapElements.Add(shape);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        internal static List<BasicGeoposition> GenerateGeoPoint(BasicGeoposition point1, BasicGeoposition point2, BasicGeoposition point3)
        {
            List<BasicGeoposition> ret = new List<BasicGeoposition>();
            ret.Add(point1);
            ret.Add(point2);
            ret.Add(point3);

            return ret;
        }

      

        internal static List<Model.Item> GenerateItemList(Model.Item item1, Model.Item item2, Model.Item item3)
        {
            List<Model.Item> ret = new List<Model.Item>();
            ret.Add(item1);
            ret.Add(item2);
            ret.Add(item3);

            return ret;
        }

    }
}
