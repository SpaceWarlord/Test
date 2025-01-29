using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Test.App.DTO;
using Test.Models;
using Windows.Networking;

namespace Test.App.ViewModels
{
    public partial class AddressViewModel:BaseViewModel
    {

        //public readonly AddressService AddressService; 

        public string Id;

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _unitNum;

        [ObservableProperty]
        private string _streetNum;

        [ObservableProperty]
        private string _streetName;

        [ObservableProperty]
        private string _streetType;

        [ObservableProperty]
        private string _suburb;

        public AddressViewModel(string id, string name, string unitNum, string streetNum, string streetName, string streetType, string suburb)
        {
            Id = id;
            _name = name;
            _unitNum = unitNum;
            _streetNum = streetNum;
            _streetName = streetName;
            _streetType = streetType;
            _suburb = suburb;
        }

        public AddressDTO ToDTO()
        {
            return new AddressDTO(Id, Name, UnitNum, StreetNum, StreetName, StreetType, Suburb);
        }
    }
}
