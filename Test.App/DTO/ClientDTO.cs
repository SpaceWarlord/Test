using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models;

namespace Test.App.DTO
{
    public class ClientDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Gender {  get; set; }
        public string? Dob { get; set; }        
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? HighlightColor { get; set; }
        public AddressDTO? Address { get; set; }        
        public byte RiskCategory {  get; set; }
        public string? genderPreference {  get; set; }


        //[SetsRequiredMembers]
        public ClientDTO(string id, string firstName, string lastName, string nickname, string gender, string? dob, string? phone, string? email, string? highlightColor, AddressDTO? address, byte riskCategory, string? genderPreference)
        {
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
            RiskCategory = riskCategory;
        }        
    }
}
