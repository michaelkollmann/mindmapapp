using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using mindmapapp.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace mindmapapp.Controls
{
    public sealed partial class MindMap : Canvas
    {
        //VMNode _datacontext;
        public MindMap()
        {
            this.InitializeComponent();
        }

        public void SetMaster(VMNode Master)
        {
            MasterNode.DataContext = Master;
            Loaded += delegate
            {
                CenterMaster();
            };
        }
        public void CenterMaster()
        {
            double left = (this.ActualWidth - MasterNode.ActualWidth) / 2;
            Canvas.SetLeft(MasterNode, left);

            double top = (this.ActualHeight - MasterNode.ActualHeight) / 2;
            Canvas.SetTop(MasterNode, top); 
        }

        //void _datacontext_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //public new object DataContext
        //{
        //    get
        //    {
        //        return _datacontext;
        //    }
        //    set
        //    {
        //        if (value.GetType().Equals(typeof(VMNode)))
        //        {
        //            if (_datacontext != null)
        //            {
        //                _datacontext.CollectionChanged -= _datacontext_CollectionChanged;
        //            }
        //            _datacontext = value as VMNode;
        //            _datacontext.CollectionChanged += _datacontext_CollectionChanged;
        //        }
        //    }
        //}
    }
}
