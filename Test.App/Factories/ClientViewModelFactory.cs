using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.App.Services;
using Test.App.ViewModels;
using Test.Models;
using Windows.Services.Maps;

namespace Test.App.Factories
{
    public class ClientViewModelFactory
    {
        private readonly ClientService _clientService;        
        public ClientViewModelFactory(ClientService clientService)
        {
            _clientService = clientService;  
        }

        /*
        public ClientViewModel Create(string id, string firstName, string lastName, string nickname, string gender, string? dob, string? phone, string? email, string? highlightColor, Address? address, byte riskCategory, string? genderPreference)
        {
            return new ClientViewModel(_clientService, id, firstName, lastName, nickname, gender, dob, phone, email, highlightColor, address, riskCategory, genderPreference);
        }

        public ClientViewModel Create()
        {
            return new ClientViewModel(_clientService, new Guid().ToString(), "", "", "", "", "", "", "", "", null, 0, "");
        }
        */
    }
}
