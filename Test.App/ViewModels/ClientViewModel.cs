using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Test.Models;
using System.Collections.Specialized;
using System.Drawing;
using System.Xml.Linq;
using Windows.Networking;
using Windows.Media.Audio;
using Microsoft.Extensions.Logging.Abstractions;
using Test.App.Services;
using Test.App.DTO;

namespace Test.App.ViewModels
{
    public partial class ClientViewModel: PersonViewModel
    {
        public readonly ClientService ClientService;       

        /// <summary>
        /// Gets or sets the client's risk category.
        /// </summary>

        [ObservableProperty]
        private byte _riskCategory;

#nullable enable

        /// <summary>
        /// Gets or sets the client's gender preference.
        /// </summary>

        [ObservableProperty]
        private string? _genderPreference;
        

#nullable enable       
        
        public ClientViewModel(string id, string firstName, string lastName, string nickname, string gender, string? dob, string? phone, string? email, string? highlightColor, Address? address, byte riskCategory, string? genderPreference) 
            : base(id, firstName, lastName, nickname, gender, dob, phone, email, highlightColor, address)
        {
            Debug.WriteLine("-- ClientViewModel Constructor--");
            ClientService = new ClientService();
            
        }        


        void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            Debug.WriteLine("modified collection");            
            if (e.NewItems != null)
            {
                Debug.WriteLine("New items to add");
                foreach (Client newItem in e.NewItems)
                {
                    Debug.WriteLine("New User: Id: " + newItem.Id + " First Name " + newItem.FirstName);
                    
                }                
            }

            if (e.OldItems != null)
            {
                foreach (Client oldItem in e.OldItems)
                {                                      
                    Debug.WriteLine("Deleted from db");                   
                }
            }            
        }     
        
        public ClientDTO ToDTO()
        {
            return new ClientDTO(Id, FirstName, LastName, Nickname, Gender, Dob, Phone, Email, HighlightColor, Address, RiskCategory, GenderPreference);
        }

        public static List<ClientViewModel> ToViewModelList(List<ClientDTO> clientDTOList)
        {
            List<ClientViewModel> viewModelList = new List<ClientViewModel>();
            foreach(ClientDTO clientDTO in clientDTOList)
            {
                viewModelList.Add(new ClientViewModel(clientDTO.Id, clientDTO.FirstName, clientDTO.LastName, clientDTO.Nickname, clientDTO.Gender, clientDTO.Dob, clientDTO.Phone, clientDTO.Email, 
                    clientDTO.HighlightColor, clientDTO.Address, clientDTO.RiskCategory, clientDTO.genderPreference));
            }
            return viewModelList;
        }
    }
}