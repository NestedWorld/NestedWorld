using NestedWorld.View.GardenViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedWorld.Classes.Garden
{
    public class GardenElementList
    {
        public List<GardenElement> list { get; private set; }

        public GardenElementList()
        {
            list = new List<GardenElement>();
        }

        public void Add(GardenElement element)
        {
            list?.Add(element);
        }

        public List<GardenItem> getGadenItem()
        {
            List<GardenItem> retList = new List<GardenItem>();
            foreach (GardenElement element in list)
            {
                GardenItem tmp = new GardenItem();
                tmp.element = element;
                retList.Add(tmp);
            }
            return retList;
        }
    }
}
