using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.App.DTO;
using Test.App.Services;
using Test.Models;
using Windows.Networking;

namespace Test.App.ViewModels
{
    public partial class TestViewModel : ObservableObject
    {
        public readonly TestService TestService;
        [ObservableProperty]
        private string _id;

        /// <summary>
        /// Gets or sets the person's first name.
        /// </summary>

        [ObservableProperty]
        private string _firstName;

        /// <summary>
        /// Gets or sets the person's last name.
        /// </summary>

        [ObservableProperty]
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
        private string _nickname;        

#nullable enable        


        public TestViewModel(string id, string firstName, string lastName, string nickname)
        {
            Debug.WriteLine("-- TestViewModel Constructor--");
            TestService = new TestService();
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Nickname = nickname;
        }


        void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            Debug.WriteLine("modified collection");
            if (e.NewItems != null)
            {
                Debug.WriteLine("New items to add");
                foreach (TestModel newItem in e.NewItems)
                {
                    Debug.WriteLine("New User: Id: " + newItem.Id + " First Name " + newItem.FirstName);

                }
            }

            if (e.OldItems != null)
            {
                foreach (TestModel oldItem in e.OldItems)
                {
                    Debug.WriteLine("Deleted from db");
                }
            }
        }

        public TestDTO ToDTO()
        {
            return new TestDTO(Id, FirstName, LastName, Nickname);
        }

        public static List<TestViewModel> ToViewModelList(List<TestDTO> testDTOList)
        {
            List<TestViewModel> viewModelList = new List<TestViewModel>();
            foreach (TestDTO testDTO in testDTOList)
            {
                viewModelList.Add(new TestViewModel(testDTO.Id, testDTO.FirstName, testDTO.LastName, testDTO.Nickname));
            }
            return viewModelList;
        }
    }
}
