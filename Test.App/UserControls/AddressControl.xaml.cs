using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Test.App.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Test.App.UserControls
{
    public sealed partial class AddressControl : UserControl
    {
        public static readonly DependencyProperty StreetNumProperty =
        DependencyProperty.Register(nameof(StreetNum), typeof(string), typeof(AddressControl), new PropertyMetadata(null));

        public static readonly DependencyProperty ViewModelProperty =
        DependencyProperty.Register(nameof(StreetNum), typeof(AddressViewModel), typeof(AddressControl), new PropertyMetadata(null));

        public string StreetNum
        {
            get { return (string)GetValue(StreetNumProperty); }
            set { SetValue(StreetNumProperty, value); }
        }

        public AddressViewModel ViewModel
        {
            get { return (AddressViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        //public AddressViewModel AddressVM { get; set; }
        //public ClientViewModel ClientViewModel { get; set; }
        public AddressControl()
        {
            this.InitializeComponent();
            //ClientViewModel = new ClientViewModel("", "", "", "", "", "", "", "", "", null, 0,"");
            //AddressVM = new AddressViewModel("","","","","","","");
        }
    }
}
