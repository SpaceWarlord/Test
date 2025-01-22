using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models;

namespace Test.App.DTO
{
    public class TestDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }

        public TestDTO(string id, string firstName, string lastName, string nickname)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Nickname = nickname;            
        }
    }
}
