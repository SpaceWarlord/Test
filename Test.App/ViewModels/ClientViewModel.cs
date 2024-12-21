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

namespace Test.App.ViewModels
{
    public partial class ClientViewModel: PersonViewModel
    {

        private string _testText="";
        public string TestText
        {
            get => _testText;
            set
            {
                if (value != _testText)
                {
                    _testText = value;
                    IsModified = true;
                    OnPropertyChanged();
                }
            }
        }


        /// <summary>
        /// Gets or sets the client's risk category.
        /// </summary>

        public byte RiskCategory
        {
            get => _model.RiskCategory;
            set
            {
                if (value != _model.RiskCategory)
                {
                    _model.RiskCategory = value;
                    IsModified = true;
                    OnPropertyChanged();
                }
            }
        }

#nullable enable

        /// <summary>
        /// Gets or sets the client's worker gender preference.
        /// </summary>

        public string? GenderPreference
        {
            get => _model.GenderPreference;
            set
            {
                if (value != _model.GenderPreference)
                {
                    _model.GenderPreference = value;
                    IsModified = true;
                    OnPropertyChanged();
                }
            }
        }        

        protected override Client _model => new();
        

        /// <summary>
        /// Saves client data that has been edited.
        /// </summary>
       
        public async Task SaveAsync()
        {
            Debug.WriteLine("Called Save Async. Name: " + FirstName);
            IsModified = false;
            if (IsNew)
            {
                Debug.WriteLine("its new");
                IsNew = false;                
            }
            await App.Repository.Clients.UpsertAsync(_model);            
        }         

#nullable enable
        public ClientViewModel(string firstName, string lastName, string nickname, string gender, string? dob, string? phone, string? email, string? highlightColor, Address? address, byte riskCategory, string? genderPreference) 
            : base(firstName, lastName, nickname, gender, dob, phone, email, highlightColor, address)
        {
            Debug.WriteLine("-- ClientViewModel Constructor--");
            
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
    }
}