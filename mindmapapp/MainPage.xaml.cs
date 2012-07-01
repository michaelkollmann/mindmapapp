using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using mindmapapp.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace mindmapapp
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            VMNode master = new VMNode(new Model.MNode("mindmap", new Point(500, 300), Model.NodeState.Master));


            VMNode parent1 = new VMNode(new Model.MNode("design", new Point(400, 400), Model.NodeState.Parent));
            VMNode parent2 = new VMNode(new Model.MNode("funktionalität", new Point(400, 200), Model.NodeState.Parent));
            master.Add(parent1);
            master.Add(parent2);


            VMNode child1 = new VMNode(new Model.MNode("schlicht", new Point(350, 300), Model.NodeState.Child));
            VMNode child2 = new VMNode(new Model.MNode("metro", new Point(300, 400), Model.NodeState.Child));
            VMNode child3 = new VMNode(new Model.MNode("aeon", new Point(350, 500), Model.NodeState.Child));
            parent1.Add(child1);
            parent1.Add(child2);
            parent1.Add(child3);

            tghtMaster.DataContext = master;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Rectangle r = new Rectangle();
            //r.Width = 50;
            //r.Height = 50;
            //r.Fill = new SolidColorBrush(Colors.Blue);

            //Canvas.SetLeft(r, 0);
            //Canvas.SetTop(r, 0);

            //cnvs.Children.Add(r);
        }
    }
}
