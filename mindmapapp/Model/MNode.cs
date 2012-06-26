using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;

namespace mindmapapp.Model
{
    public class MNode : ObservableCollection<MNode>
    {
        private string _title;
        private Color _color;
        private Point _point;



        public MNode(string Title, Color Color, Point Point)
        {
            this.Title = Title;
            this.Color = Color;
            this.Point = Point;
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public Point Point
        {
            get { return _point; }
            set { _point = value; }
        }

        
    }
}
