using NestedWorld.View;
using NestedWorld.View.MapPoint;
using NestedWorld.View.MapViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Core;
using System.Diagnostics;
using NestedWorld.Classes.ElementsGame.GameCore;
using NestedWorld.Classes.ElementsGame.Users;

#pragma warning disable CS0618

namespace NestedWorld.Classes.ElementsGame.Maps
{
    public class MapCore
    {
        public MapControl mapControl
        {
            get { return _mapControl; }
            set
            {
                _mapControl = value;
                if (_mapControl != null)
                {
                    _mapControl.Children.Add(pmp);
                    ShowUserLocation();
                }
            }
        }

        public MapView mapView;

        private Geoposition _userPos;
        public Geoposition UserPos
        {
            get
            {
                return _userPos;
            }

            set
            {
                _userPos = value;
                var location = new Geopoint(new BasicGeoposition()
                {
                    Latitude = value.Coordinate.Latitude,
                    Longitude = value.Coordinate.Longitude
                });

                Debug.WriteLine(location.ToString());

                MapControl.SetLocation(pmp, location);
            }
        }

        private MapControl _mapControl;

        private Geolocator geolocator;

        public PlayerMapPoint pmp;
        private CoreDispatcher dispatcher;

        public Geopoint geoPoint
        {
            get
            {
                if (UserPos != null)
                {
                    return new Geopoint(new BasicGeoposition
                    {
                        Latitude = UserPos.Coordinate.Latitude,
                        Longitude = UserPos.Coordinate.Longitude
                    });
                }
                else
                    return new Geopoint(new BasicGeoposition
                    {
                        Latitude = 0,
                        Longitude = 0
                    });
            }
        }

        public MapCore(UserInfo user)
        {
            geolocator = new Geolocator();

            pmp = new PlayerMapPoint();
            pmp.DataContext = user;

            geolocator.MovementThreshold = 3;
            geolocator.DesiredAccuracy = PositionAccuracy.Default;
            geolocator.PositionChanged += Geolocator_PositionChanged;

            dispatcher = Window.Current.Dispatcher;

        }

        private async void Geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            try
            {

                await dispatcher.RunAsync(CoreDispatcherPriority.Low, new DispatchedHandler(
                   () =>
                   {
                       UserPos = args.Position;
                   }));


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public async Task<Geoposition> GetUserPosition()
        {
            Geoposition geoposition = await geolocator.GetGeopositionAsync(maximumAge: TimeSpan.FromMinutes(5), timeout: TimeSpan.FromSeconds(10));
            return geoposition;
        }

        public void MapControl_MapElementClick(Windows.UI.Xaml.Controls.Maps.MapControl sender, Windows.UI.Xaml.Controls.Maps.MapElementClickEventArgs args)
        {
            var tappedGeoPosition = args.Location.Position;
            string status = "MapTapped at \nLatitude:" + tappedGeoPosition.Latitude + "\nLongitude: " + tappedGeoPosition.Longitude;
            Debug.WriteLine(status);

            var area = App.core.areaList.GetAreaTaped(tappedGeoPosition);

            if (area != null)
            {
                Debug.WriteLine(area.Name);
                mapView.PopupMain.Child = new AreaInfoView(area);
                mapView.PopupMain.Height = Window.Current.Bounds.Height * (2/3);
                mapView.PopupMain.Width = Window.Current.Bounds.Width * 0.5;
                mapView.PopupMain.IsOpen = true;
            }
            else
                Debug.WriteLine("NONE");

        
        }

        public async void ShowUserLocation(MapControl mapControl)
        {
            UserPos = await GetUserPosition();
            await mapControl.TrySetViewAsync(geoPoint, mapControl.ZoomLevel, 0, 0, MapAnimationKind.Linear);
        }

        public void ShowUserLocation()
        {
            ShowUserLocation(_mapControl);
        }

        public void ShowAllyLocation(MapControl mapControl)
        {
            Random rand = new Random();
            foreach (User user in App.core.userList.userList)
            {

                MapControl.SetLocation(user.ump,
                    new Windows.Devices.Geolocation.Geopoint(
                        new Windows.Devices.Geolocation.BasicGeoposition
                        {
                            Latitude = rand.Next(-89, 89),
                            Longitude = rand.Next(-89, 89)
                        }));
                mapControl.Children.Add(user.ump);
            }
        }

        public void ColapseAllyLocation(MapControl mapControl)
        {
            foreach (User user in App.core.userList.userList)
            {
                mapControl.Children.Remove(user.ump);
            }
        }

        public void ColapseAllyLocation()
        {
            ColapseAllyLocation(_mapControl);
        }

        public void ShowMonsterLocation(MapControl mapControl)
        {
            Random rand = new Random();
            foreach (User user in App.core.userList.userList)
            {

                MapControl.SetLocation(user.ump,
                    new Windows.Devices.Geolocation.Geopoint(
                        new Windows.Devices.Geolocation.BasicGeoposition
                        {
                            Latitude = rand.Next(-89, 89),
                            Longitude = rand.Next(-89, 89)
                        }));
                mapControl.Children.Add(user.ump);
            }
        }

        public void ShowMonsterLocation()
        {
            ShowMonsterLocation(_mapControl);
        }

        public void ShowAllyLocation()
        {
            ShowAllyLocation(_mapControl);
        }
    }
}
