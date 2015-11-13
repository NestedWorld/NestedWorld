using NestedWorld.Classes.ElementsGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace NestedWorld.Classes.Garden
{
    public class GardenElement
    {
        public string Name { get; private set; }
        public DateTime Time { get; private set; }
        public string Effect { get; private set; }
        public string imageSource { get; private set; }
        public TypeEnum Type { get; private set; }
        public Color color { get { return (Utils.ColorUtils.GetColorFromHex(Utils.ColorUtils.GetTypeColor(Type))); } set { int i = 0; i++; } }


        public GardenElement(string name, string effect, string imagesource, TypeEnum type)
        {
            Name = name;
            Effect = effect;
            imageSource = imagesource;
            Type = type;
        }

    }
}
