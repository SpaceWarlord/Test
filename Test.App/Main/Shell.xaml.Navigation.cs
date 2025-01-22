using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml;
using Test.App.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.App.Views.Client;
using System.Diagnostics;

namespace Test.App.Main
{
    public partial class Shell
    {
        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            //SetCurrentNavigationViewItem(GetNavigationViewItems(typeof(ClientPage)).First());
            SetCurrentNavigationViewItem(GetNavigationViewItems(typeof(HomePage)).First());
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            SetCurrentNavigationViewItem(args.SelectedItemContainer as NavigationViewItem);
        }

        public List<NavigationViewItem> GetNavigationViewItems()
        {
            List<NavigationViewItem> result = new();
            var items = NavigationView.MenuItems.Select(i => (NavigationViewItem)i).ToList();
            items.AddRange(NavigationView.FooterMenuItems.Select(i => (NavigationViewItem)i));
            result.AddRange(items);

            foreach (NavigationViewItem mainItem in items)
            {
                result.AddRange(mainItem.MenuItems.Select(i => (NavigationViewItem)i));
            }

            return result;
        }

        public List<NavigationViewItem> GetNavigationViewItems(Type type)
        {
            return GetNavigationViewItems().Where(i => i.Tag.ToString() == type.FullName).ToList();
        }

        public List<NavigationViewItem> GetNavigationViewItems(Type type, string title)
        {
            return GetNavigationViewItems(type).Where(ni => ni.Content.ToString() == title).ToList();
        }

        public void SetCurrentNavigationViewItem(NavigationViewItem item)
        {
            if (item == null)
            {
                return;
            }

            if (item.Tag == null)
            {
                return;
            }
            //ContentFrame.Navigate(Type.GetType(ValueFromTag(item.Tag.ToString())), Type.GetType(ValueFromTag(item.Tag.ToString(), true)));
            ContentFrame.Navigate(Type.GetType(item.Tag.ToString()), item.Content);
            NavigationView.Header = item.Content;
            NavigationView.SelectedItem = item;
        }

        public NavigationViewItem GetCurrentNavigationViewItem()
        {
            return NavigationView.SelectedItem as NavigationViewItem;
        }

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        public string ValueFromTag(string tag, bool service=false)
        {
            Debug.WriteLine("--Value from tag--");
            Debug.WriteLine("Tag: " + tag + " service: " + service);
            if (tag.Contains("|"))
            {
                Debug.WriteLine("Contains |");
                if (service)
                {
                    Debug.WriteLine("Service found: " + tag.Split('|')[1]);
                    return tag.Split('|')[1];
                }
                Debug.WriteLine("No service found: " + tag.Split('|')[0]);
                return tag.Split('|')[0];
            }
            Debug.WriteLine("| Not found " + tag);
            return tag;            
        }
    }
}