using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;

namespace TemplateSolution.Data.Helpers
{
    public static class PathFactory
    {
        public static Path NewPath(Color color, bool filled, Geometry gemoetry)
        {
            var path = new Path()
            {
                Stroke = new SolidColorBrush(color),
                StrokeThickness = 4,
                Stretch = Stretch.Fill,
                Data = gemoetry,
            };

            if (filled)
            {
                path.Fill = new SolidColorBrush(color);
            }

            return path;
        }
    }
}
