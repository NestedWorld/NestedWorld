using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace NestedWorld.Classes.ElementsGame.Areas
{
    public class AreaContentPresenter : ContentControl
    {
        public DataTemplate MeTemplate { get; set; }
        public DataTemplate FreeTemplate { get; set; }
        public DataTemplate AllyTemplate { get; set; }
        public DataTemplate OtherTemplate { get; set; }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);
            Area area = newContent as Area;
            switch (area.areaType)
            {
                case AreaType.YOU :
                    ContentTemplate = MeTemplate;
                    break;
                case AreaType.FREE:
                    ContentTemplate = FreeTemplate;
                    break;
                case AreaType.ALLY:
                    ContentTemplate = AllyTemplate;
                    break;
                case AreaType.OTHER:
                    ContentTemplate = OtherTemplate;
                    break;
            }
        }

    }
}
