using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Shapes;
using TemplateSolution.Common;
using TemplateSolution.Data.DataReaders;
using System;
using System.Linq;
using System.Windows.Media;

namespace TemplateSolution
{
    public partial class TemplateViewModel : BaseViewModel
    {
        public TemplateViewModel()
        {
            SetupUIElementsContainer();
            ReadUIElements();
            AddUIElementsToPresenter(Paths);
        }

        private void SetupUIElementsContainer()
        {
            Canvas = new System.Windows.Controls.Canvas() { Height = Height, Width = Width };
            Viewbox = new System.Windows.Controls.Viewbox() { Stretch = Stretch.Fill };
        }

        private List<Path> ReadUIElements()
        {
            var data = DataReader.ReadData(new JsonDataReader("..\\..\\Input.json"));
            Paths = data.Select(primitive => primitive.Draw()).ToList();
            return Paths;
        }

        public void AddUIElementsToPresenter(List<Path> paths)
        {
            paths.ForEach(e => { Canvas.Children.Add(e); TransformPosition(e); });
            Viewbox.Child = Canvas;
        }

        public void TransformPosition(Path element)
        {
            double left = Width / 2;
            System.Windows.Controls.Canvas.SetLeft(element, left);

            double top = Height / 2;
            System.Windows.Controls.Canvas.SetTop(element, top);
        }
    }
}

