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
using Test.App.Services;
using Test.App.DTO;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Test.App.Views.TestView
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TestPage : Page
    {
        public TestPageViewModel ViewModel { get; set; }

        /*
        private readonly ClientService _service;
        public ClientPage(ClientService Service)
        {
            this.InitializeComponent();
            ViewModel = new ClientPageViewModel();            
            _service = Service;
        }
        */

        public TestPage()
        {
            this.InitializeComponent();
            ViewModel = new TestPageViewModel();            
        }
        
        private async void ShowDialog_Click(object sender, RoutedEventArgs e)
        {
            AddTestDialog dialog = new AddTestDialog(ViewModel);
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
               
                if(ViewModel.NewTest!=null)
                {
                    Debug.WriteLine("zzFirstName: " + ViewModel.NewTest.FirstName);                                       
                    ViewModel.NewTest.Id= Guid.NewGuid().ToString();
                    //ClientDTO clientDTO = new ClientDTO(new Guid().ToString(), ViewModel.NewClient.FirstName, ViewModel.NewClient.LastName, ViewModel.NewClient.Nickname, ViewModel.NewClient.Gender);
                    bool dbResult =await ViewModel.NewTest.TestService.Add(ViewModel.NewTest.ToDTO());
                    Debug.WriteLine("Test added true/false: " + dbResult);
                    await ViewModel.GetAll();
                    //ViewModel.NewClient.Service.Add("stuff");
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

        //public async Task GetAll()
        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.GetAll();            
        }
    }
}