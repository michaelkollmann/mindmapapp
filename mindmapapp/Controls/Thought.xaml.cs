using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace mindmapapp.Controls
{
    public sealed partial class Thought : UserControl
    {
        public new object DataContext
        {
            get
            {
                return base.DataContext;
            }
            set
            {
                base.DataContext = value;
                switch ((this.DataContext as ViewModel.VMNode).State)
                {
                    case mindmapapp.Model.NodeState.Master:
                        grdBackground.Style = grdBackgroundMasterStyle;
                        txblTitle.Style = txblMasterStyle;
                        break;
                    default:
                        grdBackground.Style = grdBackgroundBaseStyle;
                        txblTitle.Style = txblStyle;
                        break;
                }
            }
        }
        public Thought()
        {
            this.InitializeComponent();
        }
    }
}
