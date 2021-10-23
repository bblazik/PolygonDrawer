using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace TemplateSolution
{
    public partial class TemplateViewModel
    {
        private double height = 600;
        public double Height
        {
            get => height;
            set
            {
                height = value;
                OnPropertyChanged();
            }
        }

        private double width = 600;
        public double Width
        {
            get => width;
            set
            {
                width = value;
                OnPropertyChanged();
            }
        }

        private List<Path> paths = new List<Path>();
        public List<Path> Paths
        {
            get => paths;
            set
            {
                paths = value;
                OnPropertyChanged();
            }
        }

        private Viewbox viewbox;
        public Viewbox Viewbox
        {
            get => viewbox;
            set
            {
                viewbox = value;
                OnPropertyChanged();
            }
        }

        private Canvas canvas;
        public Canvas Canvas
        {
            get => canvas;
            set
            {
                canvas = value;
                OnPropertyChanged();
            }
        }
    }
}
