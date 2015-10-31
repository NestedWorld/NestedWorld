using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace NestedWorld.Classes.ElementsGame.Monsters
{
    public enum AttackTypeEnum
    {
        ATT,
        DEF,
        SPEATT,
        SPEDEF
    }
    public class MonsterAttack
    {
        public string Name { get; private set; }
        public TypeEnum Type { get; private set; }
        public AttackTypeEnum AttackType { get; private set; }
        public string Image { get; private set; }
        public int Effect { get; private set; }

        public Color FillColor
        {
            get { return Utils.ColorUtils.GetColorFromHex(Utils.ColorUtils.GetTypeColor(AttackType)); }
            set { int i = 0; i++; }
        }
        public Color StrokeColor
        {
            get { return Utils.ColorUtils.GetColorFromHex(Utils.ColorUtils.GetTypeColor(Type)); }
            set { int i = 0; i++; }
        }
        public MonsterAttack(string name, string image, int effect, TypeEnum type, AttackTypeEnum attackType)
        {
            Name = name;
            Image = image;
            Effect = effect;
            Type = type;
            AttackType = attackType;
        }


    }
}
