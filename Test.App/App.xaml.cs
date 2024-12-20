using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.EntityFrameworkCore;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using Test.Repository.Sql;
using Test.App.Main;
using Test.Models;
using Test.Repository;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Test.App
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>        
        public Window MainWindow;        

        public static Window Window { get { return m_window; } }
        private static Window m_window;

        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        /// <summary>
        /// Pipeline for interacting with backend service or database.
        /// </summary>
        public static ITestRepository Repository { get; private set; }


        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Configures settings for a first time run.        
        /// </summary>
        private void CheckForFirstTimeRun()
        {
            if (localSettings.Values["IsFirstTime"] == null)
            {
                localSettings.Values["IsFirstTime"] = true;
                Debug.WriteLine("Not first time");
            }
            if ((bool)localSettings.Values["IsFirstTime"])
            {
                string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\suburbs.csv");
                Debug.WriteLine("path is " + path);

                using (var reader = new StreamReader(path))
                {
                    List<Suburb> suburbs = new List<Suburb>();                   
                }
            }
        }

        /// <summary>
        /// Configures the app to use the Sqlite data source. If no existing Sqlite database exists,         
        /// </summary>
        public static void UseSqlite()
        {
            string demoDatabasePath = Package.Current.InstalledLocation.Path + @"\Data\Roster.db";
            string databasePath = ApplicationData.Current.LocalFolder.Path + @"\Roster.db";


            if (!File.Exists(databasePath))
            {
                //File.Copy(demoDatabasePath, databasePath);
            }
            //var dbOptions = new DbContextOptionsBuilder<RosterContext>().UseSqlite("Data Source=" + databasePath);
            var dbOptions = new DbContextOptionsBuilder<TestContext>().UseSqlite("Data Source=" + "database27.db");
            Repository = new SqlTestRepository(dbOptions);
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            Application.Current.DispatcherShutdownMode = DispatcherShutdownMode.OnLastWindowClose;


            //string path = AppDomain.CurrentDomain.BaseDirectory;
            UseSqlite();
            CheckForFirstTimeRun();
            Window mainWindow = (Application.Current as App)?.MainWindow as Shell;
            mainWindow = new Shell();
            mainWindow.Activate();
        }
    }
}
