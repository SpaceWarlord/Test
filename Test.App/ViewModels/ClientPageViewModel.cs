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
            AddressViewModel addressVM = new AddressViewModel("", "", "", "", "", "", "");
            NewClient = new ClientViewModel(new Guid().ToString(), "", "", "", "", "", "", "", "", addressVM, 0, "");
            ClientService = new ClientService();                                               
        }


        /// <summary>
        /// Gets all the clients 
        /// </summary>
        /// 
        public async Task GetAll()
        {
            List<ClientDTO> clientDTOList = await ClientService.GetAll();
            Debug.WriteLine("Total clients found: " + clientDTOList.Count);
            /*
            List<TestViewModel> tList = TestViewModel.ToViewModelList(testDTOList);
            Tests = new ObservableCollection<TestViewModel>(tList as List<TestViewModel>);
            */

            Clients.Clear();
            foreach (ClientDTO clientDTO in clientDTOList)
            {
                Debug.WriteLine("Adding: " + clientDTO.Id + " name: " + clientDTO.FirstName);
                if (clientDTO.Address != null)
                {
                    Clients.Add(new ClientViewModel(clientDTO.Id, clientDTO.FirstName, clientDTO.LastName, clientDTO.Nickname, clientDTO.Gender, clientDTO.Dob, clientDTO.Phone, clientDTO.Email,
                    clientDTO.HighlightColor, new AddressViewModel(clientDTO.Address.Id, clientDTO.Address.Name, clientDTO.Address.UnitNum, clientDTO.Address.StreetNum, clientDTO.Address.StreetName, clientDTO.Address.StreetType, clientDTO.Address.Suburb), clientDTO.RiskCategory, clientDTO.genderPreference));
                }
                else
                {
                    Clients.Add(new ClientViewModel(clientDTO.Id, clientDTO.FirstName, clientDTO.LastName, clientDTO.Nickname, clientDTO.Gender, clientDTO.Dob, clientDTO.Phone, clientDTO.Email,
                    clientDTO.HighlightColor, null, clientDTO.RiskCategory, clientDTO.genderPreference));
                }
            }            
        }        
    }
}