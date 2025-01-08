using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Test.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Test.App.Views.Client
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ClientPage : Page
    {
        public ClientPageViewModel ViewModel { get; set; }
        public ClientPage()
        {
            this.InitializeComponent();
            ViewModel = new ClientPageViewModel();            
        }

        private async void ShowDialog_Click(object sender, RoutedEventArgs e)
        {
            AddClientDialog dialog = new AddClientDialog(ViewModel);
            // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
            dialog.XamlRoot = this.XamlRoot;
            dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
            dialog.Title = "Add Client";
            dialog.PrimaryButtonText = "Add";            
            dialog.CloseButtonText = "Cancel";
            dialog.DefaultButton = ContentDialogButton.Primary;
            
            dialog.Width = 2000;
            dialog.MinWidth = 2000;
            dialog.Height = 1000;            

            var result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                Debug.WriteLine("Primary clicked");
               
                if(ViewModel.NewClient!=null)
                {
                    Debug.WriteLine("zzName: " + ViewModel.NewClient.FirstName);
                    Debug.WriteLine("Selected gender: " + ViewModel.NewClient.Gender);                    
                }
            }
            else if (result == ContentDialogResult.Secondary)
            {
                //DialogResult.Text = "User did not save their work";
            }
            else
            {
                //DialogResult.Text = "User cancelled the dialog";
            }
        }
    }
}