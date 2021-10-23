using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ColorConverter = TemplateSolution.Converters.ColorConverter;
using PointConverter = TemplateSolution.Converters.PointConverter;
using System.Windows.Shapes;
using System.Windows.Media;
using TemplateSolution.Data.Helpers;

namespace TemplateSolution.Data.Models
{
    /// There was requirement to represent Point as a pair of floats. 
    /// I will skip this req as it not seems very important just to use builded type.
    /// In case of more primitives on screen it can take 2x memory usage. 

    ///Json converter adnotation are related to data inconsistency not to JSON reading itself,
    ///assuming every other source would have same input it will be needed for all of them. 
    ///Reader that is only relateed to JSON reading is PrimitiveItemConverter

    /// <summary>
    /// To expand Primitive by type. Modify PrimitiveType enum and all Readers. 
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum PrimitiveType
    {
        Line,
        Circle,
        Triangle,
    }

    public class PrimitiveHelper
    { 
        [JsonConverter(typeof(StringEnumConverter))]
        public PrimitiveType Type { get; set; }
        public bool Filled { get; set; }

        [JsonConverter(typeof(ColorConverter))]
        public Color Color { get; set; }
    }

    public abstract class Primitive : PrimitiveHelper
    {
        public abstract Path Draw();
    }

    class Line : Primitive
    {
        [JsonConverter(typeof(PointConverter))]
        public System.Windows.Point A { get; set; }
        [JsonConverter(typeof(PointConverter))]
        public System.Windows.Point B { get; set; }

        public override Path Draw()
        {
            return PathFactory.NewPath(Color, Filled, new LineGeometry { StartPoint = A, EndPoint = B });
        }
    }

    class Circle : Primitive
    {
        [JsonConverter(typeof(PointConverter))]
        public System.Windows.Point center { get; set; }
        public float radius { get; set; }

        public override Path Draw()
        {
            return PathFactory.NewPath(Color, Filled, new EllipseGeometry()
            {
                Center = center,
                RadiusX = radius,
                RadiusY = radius,
            });
        }
    }

    public class Triangle : Primitive
    {
        [JsonConverter(typeof(PointConverter))]
        public System.Windows.Point A { get; set; }
        [JsonConverter(typeof(PointConverter))]
        public System.Windows.Point B { get; set; }
        [JsonConverter(typeof(PointConverter))]
        public System.Windows.Point C { get; set; }

        public override Path Draw()
        {
            return PathFactory.NewPath(Color, Filled, new PathGeometry 
            { 
                Figures = new PathFigureCollection()
                {
                    new PathFigure
                    {
                        IsClosed = true,
                        IsFilled = Filled,
                        StartPoint = A,
                        Segments = new PathSegmentCollection()
                        {
                            new LineSegment(){Point = B},
                            new LineSegment(){Point = C}
                        }
                    }
                }
            });
        }
    }
}
