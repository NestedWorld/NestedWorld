using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NestedWorld.Model;

namespace NestedWorld.Classes.DesignUtilities
{
    public class CircularPresentorItem : CirularPresentor
    {
        public List<Item> ItemList { get; private set; }

        public CircularPresentorItem(string namePresentor, string imagePresentor, List<Model.Item> itemList, double Size, double Top = 0.0f, double Left = 0.0f) 
            : base(namePresentor, imagePresentor, Size, Top, Left, true)
        {
            this.ItemList = itemList;
        }

        public void Init()
        {
            foreach (Model.Item item in ItemList)
            {
                Add(item);
            }
        }

        public void Add(Model.Item item)
        {
            Add(new UI.CircularItem(item));
        }
    }
}
