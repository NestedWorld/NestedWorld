using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Input.Inking;

namespace NestedWorld.Utils
{
    public enum ShapeType
    {
        Elipse,
        Rectangle,
        HoriLine,
        VertLine,
        Triangle,
        None
    }

    public class Line
    {
        public InkPoint Start;
        public InkPoint End;
    }

    public class InkAnnalyse
    {
        internal static ShapeType GetShape(IReadOnlyList<InkPoint> points)
        {
            List<Line> lineList = new List<Line>();
            bool newLine = true;

            Line tmp;

            for (int i = 0; i < points.Count; i++)
            {
                if (newLine)
                {
                    tmp = new Line();
                    tmp.Start = points[i];
                    newLine = false;
                }


            }

            switch (lineList.Count)
            {
                case (0):
                    //none
                    break;
                case (1):
                    //line
                    break;
                case (2):
                    //none
                    break;
                case (3):
                    //triangle;
                    break;
                case (4):
                    //rectangle
                    break;
                default:
                    //cicle
                    break;
            }

            return ShapeType.None;
        }
    }
}
