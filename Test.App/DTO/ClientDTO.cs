using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.App.DTO
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public required string Nickname { get; set; }
        public string Gender {  get; set; }

        //[SetsRequiredMembers]
        public ClientDTO(int id, string firstName, string lastName, string gender)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;           
            Gender = gender;
        }

        /*
        public ClientDTO(int id, string firstName, string lastName, string nickname, string gender)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Nickname = nickname;
            Gender = gender;
        }
        */
    }
}
