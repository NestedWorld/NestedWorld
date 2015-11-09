using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls.Maps;

namespace NestedWorld.Classes.ElementsGame.Areas
{

    public enum AreaType
    {
        YOU,
        ALLY,
        OTHER,
        FREE
    }
    public class Area
    {
        public List<BasicGeoposition> geopointList { get; set; }
        public AreaType areaType { get; set; }

        public TypeEnum type { get; set; }

        public Area(AreaType atype, TypeEnum type)
        {
            geopointList = new List<BasicGeoposition>();
            this.areaType = atype;
            this.type = type;
        }

        public MapPolygon getPolygon()
        {
            return new MapPolygon
            {
                StrokeThickness = 3,
                StrokeDashed = true,
                ZIndex = 1,
                FillColor = Utils.ColorUtils.GetColorFromHex(Utils.ColorUtils.GetTypeColor(type, true)),
                StrokeColor = Utils.ColorUtils.GetColorFromHex(Utils.ColorUtils.GetTypeColor(type)),
                Path = new Geopath(geopointList)
            };
        }

        internal static List<BasicGeoposition> GetRandomPoints(Geopoint point1, Geopoint point2, int nrOfPoints)
        {
            var result = new List<BasicGeoposition>();
            var p1 = new BasicGeoposition
            {
                Latitude = Math.Min(point1.Position.Latitude, point2.Position.Latitude),
                Longitude = Math.Min(point1.Position.Longitude, point2.Position.Longitude)
            };
            var p2 = new BasicGeoposition
            {
                Latitude = Math.Max(point1.Position.Latitude, point2.Position.Latitude),
                Longitude = Math.Max(point1.Position.Longitude, point2.Position.Longitude)
            };

            var dLat = p2.Latitude - p1.Latitude;
            var dLon = p2.Longitude - p1.Longitude;

            var r = new Random(DateTime.Now.Millisecond);
            for (var i = 0; i < nrOfPoints; i++)
            {
              
                result.Add(   new BasicGeoposition
                  {
                      Latitude = p1.Latitude + (r.NextDouble() * dLat),
                      Longitude = p1.Longitude + (r.NextDouble() * dLon),
                      Altitude = 1000 * r.NextDouble()
                  });
                
            }
            return result;
        }

    }
}
