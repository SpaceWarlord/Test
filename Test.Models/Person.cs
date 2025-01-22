using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;

namespace Test.Models
{
    [Index(nameof(Nickname), IsUnique = true)]
    public class Person: IEquatable<Person>
    {
        public string Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Nickname { get; set; }

#nullable enable
        [NotMapped]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
            set { }
        }


        public string Gender { get; set; }
        
        public string? DOB { get; set; }

        #nullable enable
        public string? Phone { get; set; }
        
        public string? Email { get; set; }

        #nullable disable

        [ForeignKey("AddressId")] // for a shadow property to the Address ID FK
        public virtual Address Address { get; set; }

#nullable enable
        public string? HighlightColor { get; set; }

#nullable disable

        /// <summary>
        /// Returns the person's name.
        /// </summary>
        public override string ToString() => $"{FirstName} {LastName}";

        public bool Equals(Person other) =>
            FirstName == other.FirstName &&
            LastName == other.LastName &&
            Nickname == other.Nickname &&
            Gender == other.Gender &&
            DOB == other.DOB &&            
            Phone == other.Phone &&
            Email == other.Email &&
            Address == other.Address;             
    }
}