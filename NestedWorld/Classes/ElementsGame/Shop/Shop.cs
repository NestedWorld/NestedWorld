using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Storage.Streams;

namespace NestedWorld.Classes.ElementsGame.Shop
{
    public class Shop
    {
        public List<Model.ItemGroup> list { get; set; }

        public ObservableCollection<Model.ItemGroup> content
        {
            get
            {
                return new ObservableCollection<Model.ItemGroup>(list);
            }
            set
            {
                int i = 0; i++;
            }
        }

        public Shop()
        {
            list = new List<Model.ItemGroup>();
            init();
        }

        public async void init()
        {
            try
            {
                IRandomAccessStream data = await Utils.IO.GetDataAsStream("DataModel", "ShopData.xml");


                XDocument doc = XDocument.Load(data.AsStream());

                Debug.WriteLine(doc);

                Model.ItemGroup groupetmp;
                foreach (XElement element in doc.Element("Root").Elements("Groupe"))
                {
                    groupetmp = new Model.ItemGroup((string)element.Attribute("name"), (string)element.Attribute("image"));
                    groupetmp.Load(element);
                    list.Add(groupetmp);
                }

                foreach (var groupe in list)
                {
                    Debug.WriteLine(groupe.Name + " : " + groupe.Image);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

        }
    }
}
