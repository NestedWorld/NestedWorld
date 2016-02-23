using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NestedWorld.Classes.ElementsGame;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace NestedWorld.Utils
{
    public class ImageUtils
    {
        internal static ImageBrush UrlToFillSource(string url)
        {
            try
            {
                var bitmapImage = new BitmapImage();
                ImageBrush brush = new ImageBrush();
                bitmapImage.UriSource = new Uri(url);
                brush.ImageSource = bitmapImage;
                return brush;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return UrlToFillSource("ms-appx:///Assets/beer.png");
            }
        }

        internal static async Task<StorageFile> ImageOpenPicker()
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");
            return await openPicker.PickSingleFileAsync();
        }

        internal static string GetImageType(TypeEnum type)
        {
            switch (type)
            {
                case (TypeEnum.FIRE):
                    return "ms-appx:///Assets/Type/fire.png";
                case (TypeEnum.WATHER):
                    return "ms-appx:///Assets/Type/water.png";
                case (TypeEnum.GRASS):
                    return "ms-appx:///Assets/Type/grass.png";
                case (TypeEnum.DIRT):
                    return "ms-appx:///Assets/Type/dirt.png";
                case (TypeEnum.ELEC):
                    return "ms-appx:///Assets/Type/elec.png";

            }
            return "#FFFFFFFF";
        }
    }
}
