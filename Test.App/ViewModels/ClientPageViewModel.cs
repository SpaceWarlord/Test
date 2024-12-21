using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Roster.App.Helpers;
using Test.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;

namespace Test.App.ViewModels
{
    public partial class ClientPageViewModel:BaseViewModel
    {
        public ObservableCollection<ClientViewModel> Clients;

        public ClientViewModel NewClient { get; set; }
        
        public ClientPageViewModel()
        { 
            Debug.WriteLine("-- ClientPageViewModel Constructor--");
            Clients = new ObservableCollection<ClientViewModel>();
            NewClient = new ClientViewModel("", "", "", "", "", "", "", "", null, 0, "");
        }

        /// <summary>
        /// Saves user to database then clears fields 
        /// </summary>
        public async Task AddClientToDB()
        {
            Debug.WriteLine("--AddClientToDb--");
            await NewClient.SaveAsync();
            NewClient = new ClientViewModel("", "", "", "", "", "", "", "", null, 0, "");
            await GetClientsListAsync();
        }

        public async Task GetClientsListAsync()
        {
            Debug.WriteLine("-- Get Client List Async --");
            await dispatcherQueue.EnqueueAsync(() =>
            {
                IsLoading = true;
            });
            var clients = await App.Repository.Clients.GetAsync();
            if (clients == null)
            {
                Debug.WriteLine("clients was null");
                return;
            }
            Debug.WriteLine("Total users:" + clients.Count());

            await dispatcherQueue.EnqueueAsync(() =>
            {
                Clients.Clear();

                foreach (var c in clients)
                {
                    Debug.WriteLine("adding " + c.FullName);
                    ClientViewModel clientViewModel = new ClientViewModel(c.FirstName, c.LastName, c.Nickname, c.Gender, c.DOB, c.Phone, c.Email, c.HighlightColor, c.Address, c.RiskCategory, c.GenderPreference);
                    if (clientViewModel.FirstName != null)
                    {
                        Debug.WriteLine("Not null: Id" + clientViewModel.Id + " name: " + clientViewModel.FullName);
                        Clients.Add(clientViewModel);
                        //People.Add(userViewModel);
                    }
                    else
                    {
                        Debug.WriteLine("Was null");
                    }
                }
                IsLoading = false;
            });
        }        
    }
}