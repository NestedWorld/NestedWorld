using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace NestedWorld.Classes.ElementsGame.Monsters
{
    public class Monster
    {
        public MonsterAttckList monsterAttackList { get; set; }
        public string Name { get; private set; }
        public TypeEnum Type { get; private set; }
        public Color color { get { return (Utils.ColorUtils.GetColorFromHex(Utils.ColorUtils.GetTypeColor(Type))); } set { int i = 0; i++; } }
        public string Image { get; private set; }

        public int ID { get; private set; }

        public Monster(Monster mbase)
        {
            this.Name = mbase.Name;
            this.Type = mbase.Type;
            this.Image = mbase.Image;
            this.ID = mbase.ID;
            this.monsterAttackList = mbase.monsterAttackList;
        }

        public Monster(string name, TypeEnum type, string image, int id)
        {
            this.Name = name;
            this.Type = type;
            this.Image = image;
            this.ID = id;
            monsterAttackList = new MonsterAttckList();
        }

        public Monster(JObject obj)
        {

        }
    }
}
