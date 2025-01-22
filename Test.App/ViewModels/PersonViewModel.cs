using CommunityToolkit.Mvvm.ComponentModel;
using Test.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;
using System.Drawing;
using System.Reflection;

namespace Test.App.ViewModels
{
    public abstract partial class PersonViewModel: BaseViewModel
    {
        /// <summary>
        /// Gets or sets the person's ID.
        /// </summary>


        [ObservableProperty]                
        private string _id;

        /// <summary>
        /// Gets or sets the person's first name.
        /// </summary>

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "First Name is Required")]
        private string _firstName;

        /// <summary>
        /// Gets or sets the person's last name.
        /// </summary>

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Last Name is Required")]
        private string _lastName;

#nullable enable

        /// <summary>
        /// Gets or sets the person's full name.
        /// </summary>

        [NotMapped]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
            set { }
        }



        /// <summary>
        /// Gets or sets the person's nickname.
        /// </summary>

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Nickname is Required")]
        private string _nickname;


        /// <summary>
        /// Gets or sets the person's gender.
        /// </summary>

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Gender is Required")]
        private string _gender;

        /// <summary>
        /// Gets or sets the person's date of birth.
        /// </summary>

        [ObservableProperty]
        private string? _dob;


        /// <summary>
        /// Gets or sets the person's phone.
        /// </summary>

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Phone]
        private string? _phone;

        /// <summary>
        /// Gets or sets the person's email.
        /// </summary>

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [EmailAddress]
        private string? _email;

        /// <summary>
        /// Gets or sets the person's highlight color.
        /// </summary>

        [ObservableProperty]
        private string? _highlightColor;

        /// <summary>
        /// Gets or sets the person's address.
        /// </summary>


        [ObservableProperty]
        private Address? _address;

        public PersonViewModel() : base()
        {
            Debug.WriteLine("-- PersonViewModel Constructor Blank--");
            FirstName = "";
            LastName = "";
            Nickname = "";
            Gender = "M";
            Dob = "";
        }

        public PersonViewModel(PersonViewModel person) : base()
        {
            Debug.WriteLine("-- PersonViewModel Constructor with param--");
            if (person != null)
            {
                Id = person.Id;
                FirstName = person.FirstName;
                LastName = person.LastName;
                Nickname = person.Nickname;
                Gender = person.Gender;
                Dob = person.Dob;
            }
            else
            {
                Id = new Guid().ToString();
                FirstName = "";
                LastName = "";
                Nickname = "";
                Gender = "M";
                Dob = "";
            }
        }

        public PersonViewModel(string id, string firstName, string lastName, string nickname, string gender, string? dob, string? phone, string? email, string? highlightColor, Address? address) : base()
        {
            Debug.WriteLine("--PersonViewModel Constructor 1--");
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Nickname = nickname;
            Gender = gender;
            Dob = dob;
            Phone = phone;
            Email = email;
            HighlightColor = highlightColor;
            Address = address;
        }

        public PersonViewModel(string id, string firstName, string lastName, string nickname, string gender, string dob, string phone, string email, Color? highlightColor)
        {
            Debug.WriteLine("--PersonViewModel Constructor 2--");
            if (highlightColor == null) //https://stackoverflow.com/questions/4454336/can-i-specify-a-default-color-parameter-in-c-sharp-4-0
            {
                highlightColor = Color.Black;
            }
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Nickname = nickname;
            Gender = gender;
            Dob = dob;
            Phone = phone;
            Email = email;
            HighlightColor = highlightColor.ToString();
            //_userId = userId;
        }
    }
}
