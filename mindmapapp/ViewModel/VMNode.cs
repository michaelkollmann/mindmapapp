using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mindmapapp.Model;

namespace mindmapapp.ViewModel
{
    public class VMNode : ICollection<VMNode>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        private MNode _model;
        private readonly ICollection<VMNode> _collection = new Collection<VMNode>();

        #region Constructors
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
            RaiseCollectionChanged(NotifyCollectionChangedAction.Add);
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
            if (CollectionChanged != null)
            {
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(Action));
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
