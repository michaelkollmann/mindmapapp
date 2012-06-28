using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mindmapapp.Model;
using Windows.Foundation;

namespace mindmapapp.ViewModel
{
    public class VMNode : ICollection<VMNode>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        private MNode _model;
        private readonly ICollection<VMNode> _collection = new Collection<VMNode>();

        #region Properties
        public string Title
        {
            get
            {
                switch (_model.State)
                {
                    case NodeState.Master: return "." + _model.Title.ToLower();
                    case NodeState.Parent: return _model.Title.ToUpper();
                    case NodeState.Child: return _model.Title;
                    default: goto case NodeState.Child;
                }
            }
            set
            {
                if (_model.Title != value)
                {
                    _model.Title = value;
                    RaisePropertyChanged("Title");
                }
            }
        }
        public NodeState State
        {
            get
            {
                return _model.State;
            }
            set
            {
                if (_model.State != value)
                {
                    _model.State = value;
                    RaisePropertyChanged("State");
                }
            }
        }
        public Point Point
        {
            get
            {
                return _model.Point;
            }
            set
            {
                if (_model.Point != value)
                {
                    _model.Point = value;
                    RaisePropertyChanged("Point");
                }
            }
        }

        #endregion

        #region Constructors
        public VMNode()
            : this(new MNode("Lindmap", new Point(10, 10), NodeState.Master)){ }
        public VMNode(MNode Model)
            : this(Model, Enumerable.Empty<MNode>()) { }
        public VMNode(MNode Model, IEnumerable<MNode> Children)
        {
            _model = Model;
            foreach (MNode item in Children)
            {
                Add(new VMNode(item));
            }
        }
        #endregion

        #region ICollection<VMNode>
        public void Add(VMNode item)
        {
            _collection.Add(item);
            _model.Add(item._model);
            RaiseCollectionChanged(NotifyCollectionChangedAction.Add, item);
        }

        public void Clear()
        {
            _collection.Clear();
            _model.Clear();
            RaiseCollectionChanged(NotifyCollectionChangedAction.Reset);
        }

        public bool Contains(VMNode item)
        {
            return _collection.Contains(item);
        }

        public void CopyTo(VMNode[] array, int arrayIndex)
        {
            _collection.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _collection.Count; }
        }

        public bool IsReadOnly
        {
            get { return _collection.IsReadOnly; }
        }

        public bool Remove(VMNode item)
        {
            bool value = _collection.Remove(item);
            _model.Remove(item._model);
            RaiseCollectionChanged(NotifyCollectionChangedAction.Remove);
            return value;
        }

        public IEnumerator<VMNode> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        #region INotifyCollectionChanged
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private void RaiseCollectionChanged(NotifyCollectionChangedAction Action)
        {
            RaiseCollectionChanged(Action, null);
        }
        private void RaiseCollectionChanged(NotifyCollectionChangedAction Action, Object item)
        {            
            if (CollectionChanged != null)
            {
                switch (Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        CollectionChanged(this, new NotifyCollectionChangedEventArgs(Action, item));
                        break;
                    case NotifyCollectionChangedAction.Move:
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        break;
                    case NotifyCollectionChangedAction.Replace:
                        break;
                    case NotifyCollectionChangedAction.Reset:
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Methods
        public void AddEnumerable(IEnumerable<VMNode> Nodes)
        {
            foreach (VMNode item in Nodes)
            {
                Add(item);
            }
        }
        #endregion
    }
}
