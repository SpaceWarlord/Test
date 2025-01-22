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
using Test.App.Services;
using Test.App.Factories;
using Test.App.DTO;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;

namespace Test.App.ViewModels
{
    public partial class ClientPageViewModel:BaseViewModel
    {
        public ObservableCollection<ClientViewModel> Clients = new();

        public ClientViewModel NewClient { get; set; }
        public ClientService ClientService { get; set; }
        
        public ClientPageViewModel()
        { 
            Debug.WriteLine("-- ClientPageViewModel Constructor--");
            //Clients = new ObservableCollection<ClientViewModel>();
            NewClient = new ClientViewModel(new Guid().ToString(), "", "", "", "", "", "", "", "", null, 0, "");
            ClientService = new ClientService();
            
            

            /*
            ClientViewModelFactory clientFactory = new ClientViewModelFactory(new ClientService());
            NewClient = clientFactory.Create();            
            */
            
        }

        public async Task GetAll()
        {
            List<ClientDTO> clientDTOList = await ClientService.GetAll();
            Debug.WriteLine("total clients found " + clientDTOList.Count);
            /*
            List<TestViewModel> tList = TestViewModel.ToViewModelList(testDTOList);
            Tests = new ObservableCollection<TestViewModel>(tList as List<TestViewModel>);
            */

            Clients.Clear();
            foreach (ClientDTO clientDTO in clientDTOList)
            {
                Debug.WriteLine("Adding: " + clientDTO.Id + " name: " + clientDTO.FirstName);
                Clients.Add(new ClientViewModel(clientDTO.Id, clientDTO.FirstName, clientDTO.LastName, clientDTO.Nickname, clientDTO.Gender, clientDTO.Dob, clientDTO.Phone, clientDTO.Email, 
                    clientDTO.HighlightColor, clientDTO.Address, clientDTO.RiskCategory, clientDTO.genderPreference));
            }
            Debug.WriteLine("total clients in list after:" + Clients.Count);
        }

        /// <summary>
        /// Saves user to database then clears fields 
        /// </summary>
        /// 
        /*
        public async Task AddClientToDB()
        {
            Debug.WriteLine("--AddClientToDb--");
            await NewClient.SaveAsync();
            //NewClient = new ClientViewModel("", "", "", "", "", "", "", "", null, 0, "");
            ClientViewModelFactory clientFactory = new ClientViewModelFactory(new ClientService());
            NewClient = clientFactory.Create();
            await GetClientsListAsync();
        }
        */

        /*
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
                ClientViewModelFactory clientFactory = new ClientViewModelFactory(new ClientService());
                foreach (var c in clients)
                {
                    Debug.WriteLine("adding " + c.FullName);                    
                    ClientViewModel clientViewModel = clientFactory.Create(c.Id, c.FirstName, c.LastName, c.Nickname, c.Gender, c.DOB, c.Phone, c.Email, c.HighlightColor, c.Address, c.RiskCategory, c.GenderPreference);
                    //ClientViewModel clientViewModel = new ClientViewModel(c.FirstName, c.LastName, c.Nickname, c.Gender, c.DOB, c.Phone, c.Email, c.HighlightColor, c.Address, c.RiskCategory, c.GenderPreference);
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
        */
    }
}