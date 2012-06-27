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
    public class MNode : IList<MNode>
    {
        private string _title;
        private Color? _color;
        private Point _point;
        private IList<MNode> _list = new List<MNode>();
        private NodeState _state;



        #region Constructors
        public MNode(string Title, Point Point)
            : this(Title, Point, null) { }
        public MNode(string Title, Point Point, Color? Color)
        {
            this.Title = Title;
            this.Color = Color;
            this.Point = Point;
        }
        #endregion

        #region Properties
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public Color? Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public Point Point
        {
            get { return _point; }
            set { _point = value; }
        }
        public NodeState State
        {
            get { return _state; }
            set { _state = value; }
        }
        #endregion

        #region IList<MNode>
        public int IndexOf(MNode item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, MNode item)
        {
            _list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        public MNode this[int index]
        {
            get
            {
                return _list[index];
            }
            set
            {
                _list[index] = value;
            }
        }

        public void Add(MNode item)
        {
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(MNode item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(MNode[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _list.Count; }
        }

        public bool IsReadOnly
        {
            get { return _list.IsReadOnly; }
        }

        public bool Remove(MNode item)
        {
            return Remove(item);
        }

        public IEnumerator<MNode> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
