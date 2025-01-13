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
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        //public required string Nickname { get; set; }
        public required string Gender {  get; set; }

        [SetsRequiredMembers]
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
