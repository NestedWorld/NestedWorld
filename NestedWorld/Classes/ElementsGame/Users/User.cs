using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace NestedWorld.Classes.ElementsGame.Users
{
    public class User
    {
        public string Name { get; private set; }
        public string Image { get; private set; }
        public int Level { get; private set; }
        public bool IsOnline { get; private set; }
        public Color color
        {
            get
            {
                if (IsOnline)
                    return Utils.ColorUtils.GetColorFromHex("#FFB3E5FC");
                return Utils.ColorUtils.GetColorFromHex("#FFFFFFFF");
            }
            set { int i = 0; i++; }
        }

        public User(User user)
        {
            this.Name = user.Name;
            this.Image = user.Image;
            this.IsOnline = user.IsOnline;
            this.Level = user.Level;
        }

        public User(string name, string image, bool isOnline, int level)
        {
            this.Name = name;
            this.Image = image;
            this.IsOnline = isOnline;
            this.Level = level;
        }
    }
}
