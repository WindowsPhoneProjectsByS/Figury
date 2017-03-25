using Figury.Common;
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
        private NavigationHelper navigationHelper;

        public TrojkatPage()
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
                if (e.PageState.ContainsKey("Bok3"))
                {
                    e.PageState.Remove("Bok3");
                }
                if (e.PageState.ContainsKey("Basis"))
                {
                    e.PageState.Remove("Basis");
                }
                if (e.PageState.ContainsKey("HeightB"))
                {
                    e.PageState.Remove("HeightB");
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
                e.PageState.Add("Bok3", Bok3.Text);
                e.PageState.Add("Basis", Basis.Text);
                e.PageState.Add("HeightB", HeightB.Text);
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
                if (e.PageState.ContainsKey("Bok3"))
                {
                    Bok3.Text = e.PageState["Bok3"].ToString();
                }
                if (e.PageState.ContainsKey("Basis"))
                {
                    Basis.Text = e.PageState["Basis"].ToString();
                }
                if (e.PageState.ContainsKey("HeightB"))
                {
                    HeightB.Text = e.PageState["HeightB"].ToString();
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
