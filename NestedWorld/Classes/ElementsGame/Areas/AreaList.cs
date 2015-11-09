using NestedWorld.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls.Maps;

namespace NestedWorld.Classes.ElementsGame.Areas
{
    public class AreaList
    {
        public List<Area> areaList { get; set; }
        public MapControl map { get; set; }

        Random r = new Random(DateTime.Now.Millisecond);
        public AreaList()
        {
            areaList = new List<Area>();
        }

        public void Show()
        {
            try
            {
                foreach (Area a in areaList)
                {
                    var shape = a.getPolygon(); 
                    shape.AddData(a);
                    map.MapElements.Add(shape);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        public void Genearate()
        {

            var area = map.GetViewArea();

            for (int i = 0; i < 10; i++)
            {
                Area newArea = new Area(getRandAreaType(), getRandType());
                newArea.geopointList = Area.GetRandomPoints(new Geopoint(area.NorthwestCorner), new Geopoint(area.SoutheastCorner), 3);
                Add(newArea);
            }
            Debug.WriteLine("Generate");
        }

        private TypeEnum getRandType()
        {
            int num = r.Next(0, 5);

            switch (num)
            {
                case (0):
                    return TypeEnum.FIRE;
                case (1):
                    return TypeEnum.ELEC;
                case (2):
                    return TypeEnum.GRASS;
                case (3):
                    return TypeEnum.WATHER;
                case (4):
                    return TypeEnum.DIRT;
            }
            return TypeEnum.GRASS;

        }


        private AreaType getRandAreaType()
        {
            int num = r.Next(0, 4);

            switch(num)
            {
                case (0):
                    return AreaType.YOU;
                case (1):
                    return AreaType.OTHER;
                case (2):
                    return AreaType.ALLY;
                case (4):
                    return AreaType.FREE;
            }
            return AreaType.FREE;
        }

        public void Add(Area newArea)
        {
            areaList.Add(newArea);
        }
    }
}
