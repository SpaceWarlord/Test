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

namespace Test.App.ViewModels
{
    public partial class TestPageViewModel:BaseViewModel
    {
        public ObservableCollection<TestViewModel> Tests = new();

        public TestViewModel NewTest { get; set; }
        public TestService TestService { get; set; }
        
        public TestPageViewModel()
        { 
            Debug.WriteLine("-- ClientPageViewModel Constructor--");            
            NewTest = new TestViewModel(Guid.NewGuid().ToString(), "", "", "");
            TestService = new TestService();                                               
        }

        public async Task GetAll()
        {
            //Debug.WriteLine("total test in list at start:" + Tests.Count);
            List<TestDTO> testDTOList = await TestService.GetAll();
            Debug.WriteLine("total tests found " + testDTOList.Count);
            /*
            List<TestViewModel> tList = TestViewModel.ToViewModelList(testDTOList);
            Tests = new ObservableCollection<TestViewModel>(tList as List<TestViewModel>);
            */

            Tests.Clear();
            foreach(TestDTO testDTO in testDTOList)
            {
                Debug.WriteLine("Adding: " + testDTO.Id + " name: " + testDTO.FirstName);
                Tests.Add(new TestViewModel(testDTO.Id, testDTO.FirstName, testDTO.LastName, testDTO.Nickname));
            }
            Debug.WriteLine("total test in list after:" + Tests.Count);            
        }        
    }
}