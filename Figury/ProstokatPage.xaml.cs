using Figury.Common;
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
        private NavigationHelper navigationHelper;

        public ProstokatPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;

            navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            if (e.PageState != null)
            {
                if (e.PageState.ContainsKey("Bok1"))
                {
                    e.PageState.Remove("Bok1");
                }
                if (e.PageState.ContainsKey("Bok2"))
                {
                    e.PageState.Remove("Bok2");
                }
                if (e.PageState.ContainsKey("PoleResult"))
                {
                    e.PageState.Remove("PoleResult");
                }
                if (e.PageState.ContainsKey("ObwodResult"))
                {
                    e.PageState.Remove("ObwodResult");
                }

                e.PageState.Add("Bok1", Bok1.Text);
                e.PageState.Add("Bok2", Bok2.Text);
                e.PageState.Add("PoleResult", PoleResult.Text);
                e.PageState.Add("ObwodResult", ObwodResult.Text);
            }
            
        }

        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            if (e.PageState != null)
            {
                if (e.PageState.ContainsKey("Bok1"))
                {
                    Bok1.Text = e.PageState["Bok1"].ToString();
                    
                }
                if (e.PageState.ContainsKey("Bok2"))
                {
                    Bok2.Text = e.PageState["Bok2"].ToString();
                }
                if (e.PageState.ContainsKey("PoleResult"))
                {
                    ObwodResult.Text = e.PageState["PoleResult"].ToString();
                }
                if (e.PageState.ContainsKey("ObwodResult"))
                {
                    PoleResult.Text = e.PageState["ObwodResult"].ToString();
                }
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
