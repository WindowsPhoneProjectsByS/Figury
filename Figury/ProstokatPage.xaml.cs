using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Figury
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProstokatPage : Page
    {
        public ProstokatPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            e.Handled = true;
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CountFieldAndCircuit();
        }

        private async void CountFieldAndCircuit()
        {
            if (IsProperValuesForCount())
            {
                double bok1 = Double.Parse(Bok1.Text);
                double bok2 = Double.Parse(Bok2.Text);
                double field = bok1 * bok2;
                double circuit = 2 * bok1 + 2 * bok2;

                PoleResult.Text = String.Format("{0:N2}", field);
                ObwodResult.Text = String.Format("{0:N2}", circuit);

            }
            else
            {
                MessageDialog mg = new MessageDialog("Niepoprawne wartości do obliczeń.");
                await mg.ShowAsync();
            }
        }


        private bool IsProperValuesForCount()
        {
            bool condition = true;

            if (String.IsNullOrEmpty(Bok1.Text) || Bok1.Text.Contains("-"))
            {
                condition = false;
            }
            else if (String.IsNullOrEmpty(Bok2.Text) || Bok2.Text.Contains("-"))
            {
                condition = false;
            }

            return condition;
        }

        private void InformationButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ProstokatPageInfo));
        }
    }
}
