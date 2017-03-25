using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class TrojkatPage : Page
    {
        public TrojkatPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CountField();   
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CountArea();
        }

        private async void CountField()
        {
            if (IsProperValuesForCircuit())
            {
                int bok1 = Int32.Parse(Bok1.Text);
                int bok2 = Int32.Parse(Bok2.Text);
                int bok3 = Int32.Parse(Bok3.Text);

                int obwod = bok1 + bok2 + bok3;

                ObwodResult.Text = obwod.ToString();

            }
            else
            {
                MessageDialog mg = new MessageDialog("Nie prawidłowa wartość pól dla obwodu");
                await mg.ShowAsync();
            } 
        }

        private async void CountArea()
        {
            if (IsProperValuesForArea())
            {
                int height = Int32.Parse(HeightB.Text);
                int basis = Int32.Parse(Basis.Text);

                double pole = height * basis * 0.5;

                PoleResult.Text = String.Format("{0:N2}", pole);
            }
            else
            {
                MessageDialog mg = new MessageDialog("Nie prawidłowa wartość pól dla pola");
                await mg.ShowAsync();
            }
        }

        private bool IsProperValuesForCircuit()
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
            else if (String.IsNullOrEmpty(Bok3.Text) || Bok3.Text.Contains("-"))
            {
                condition = false;
            }

            return condition;
        }

        private bool IsProperValuesForArea()
        {
            bool condition = true;

            if (String.IsNullOrEmpty(HeightB.Text) || HeightB.Text.Contains("-"))
            {
                condition = false;
            }
            else if (String.IsNullOrEmpty(Basis.Text) || Basis.Text.Contains("-"))
            {
                condition = false;
            }
            
            return condition;
        }

        private void InformationButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TrojkatPageInfo));
        }
    }
}
