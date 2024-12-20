using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models
{
    [Table("Address", Schema = "TPT")]
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; protected set; }
        
        public string Name { get; set; }

#nullable enable
        public string? UnitNum { get; set; }

#nullable disable
        public string StreetNum { get; set; } 
        
        public string StreetName { get; set; } 
        
        public string StreetType { get; set; }

        public int SuburbId {  get; set; }
        
        public Suburb Suburb { get; set; }
        
        public string City {  get; set; }                        
    }
}