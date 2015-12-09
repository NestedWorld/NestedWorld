using NestedWorld.Classes.ElementsGame.Monsters;
using NestedWorld.Pages;
using NestedWorld.View.BattleViews;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Input.Inking;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace NestedWorld.Classes.ElementsGame.Battle
{
    public class BattleCore
    {
        public MonsterList UserMonster { get; set; }
        public MonsterList EnemieMonster { get; set; }

        public List<BattleIcon> iconList { get; set; }
        public Canvas canvas { get { return null; } set { Init(value); } }
        public BattlePage Page { get; set; }
        private List<Patern> PaternList { get; set; }

        public BattleCore()
        {
            PaternList = new List<Patern>();
            PaternList.Add(new Paterns.AttackPatern(this));
            PaternList.Add(new Paterns.DefencePatern(this));
            PaternList.Add(new Paterns.UseToolsPatern(this));
            PaternList.Add(new Paterns.AttackSpePatern(this));
            PaternList.Add(new Paterns.DefenceSpePatern(this));

        }

        private void ActiveAll(List<int> patern)
        {
            foreach (int num in patern)
            {
                iconList[num - 1].IsActive = true;
            }
        }

        private void UnActiveAll(List<int> patern)
        {
            foreach (int num in patern)
            {
                iconList[num - 1].IsActive = false;
            }
        }

        public void InkPath(IReadOnlyList<InkPoint> points)
        {
            List<int> patern = new List<int>();
            foreach (InkPoint point in points)
            {
                foreach (var i in iconList)
                {
                    if (i.IsOnIt(point.Position))
                    {
                        if (!patern.Contains(i.number))
                            patern.Add(i.number);
                    }
                }
            }
            foreach (Patern p in PaternList)
            {
                if (p.isThisPatern(patern))
                {
                    ActiveAll(patern);
                    p.Execute();
                    UnActiveAll(patern);
                    break;
                }
            }

        }

        #region Icon
        private void Init(Canvas value)
        {
            iconList = new List<BattleIcon>();
            iconList.Add(new BattleIcon("ms-appx:///Assets/NestedWorldLogo.png", 1));
            iconList.Add(new BattleIcon("ms-appx:///Assets/NestedWorldLogo.png", 2));
            iconList.Add(new BattleIcon("ms-appx:///Assets/NestedWorldLogo.png", 3));
            iconList.Add(new BattleIcon("ms-appx:///Assets/NestedWorldLogo.png", 4));
            iconList.Add(new BattleIcon("ms-appx:///Assets/NestedWorldLogo.png", 5));
            iconList.Add(new BattleIcon("ms-appx:///Assets/NestedWorldLogo.png", 6));

            foreach (BattleIcon b in iconList)
            {
                value.Children.Add(b);
            }

            SetPlacement(Window.Current.Bounds.Height, Window.Current.Bounds.Width);
            Window.Current.SizeChanged += Current_SizeChanged;
        }


        private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            SetPlacement(e.Size.Height, e.Size.Width);
        }

        private void SetPlacement(double height, double width)
        {

            double PidivTwo = (Math.PI / 2);
            double alpha = (2 * Math.PI) / iconList.Count;
            double defautTop = ((height) / 2) - iconList[0].Height;
            double defautLeft = ((width) / 2) - (iconList[0].Width / 2);
            int index = 0;
            foreach (BattleIcon item in iconList)
            {
                item.top = ((Math.Sin(PidivTwo + index * alpha)) * 150) + defautTop;
                item.left = ((Math.Cos(PidivTwo + index * alpha)) * 150) + defautLeft;
                index++;
            }
        }
        #endregion
    }
}
