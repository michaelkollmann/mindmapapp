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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace mindmapapp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private bool _isPressed;
        public MainPage()
        {
            this.InitializeComponent();
            _isPressed = false;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }


        //private void Canvas_PointerPressed_1(object sender, PointerRoutedEventArgs e)
        //{
        //    _isPressed = true;
        //}

        //private void Canvas_PointerMoved_1(object sender, PointerRoutedEventArgs e)
        //{
        //    if (_isPressed)
        //    {
        //        cnvs.SetValue(Canvas.LeftProperty, e.GetCurrentPoint(null).Position.X - 20);
        //        cnvs.SetValue(Canvas.TopProperty, e.GetCurrentPoint(null).Position.Y - 20);
        //    }
        //}

        //private void cnvs_PointerCaptureLost_1(object sender, PointerRoutedEventArgs e)
        //{
        //    _isPressed = false;
        //}
    }
}
