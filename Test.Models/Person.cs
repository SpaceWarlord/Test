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
        public int Id { get; set; }
        
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

       
        /*
        
        public Person(string firstName, string lastName, string nickname, string gender)
        {            
            Debug.WriteLine("--Person Constructor 1");

            FirstName = firstName;
            LastName = lastName;
            Nickname = nickname;
            Gender = gender;
        }

        public Person(string firstName, string lastName, string nickname, string gender, string dob, string phone, string email, Color? highlightColor)
        {
            Debug.WriteLine("--Person Constructor 2");
            if (highlightColor == null) //https://stackoverflow.com/questions/4454336/can-i-specify-a-default-color-parameter-in-c-sharp-4-0
            {
                highlightColor = Color.Black;
            }
            
            //Debug.WriteLine("id is: " + Id);
            //Debug.WriteLine("first name is: '" + firstName + "'");
            FirstName = firstName;
            LastName = lastName;
            Nickname = nickname;
            Gender = gender;
            DOB = dob;
            Phone = phone;
            Email = email;
            HighlightColor = highlightColor.ToString();
            //_userId = userId;
        }
      */
    }
}