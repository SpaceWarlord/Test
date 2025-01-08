using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Test.Models
{

    [Table("Client", Schema = "TPT")]
    public class Client : Person
    {                              
        public byte RiskCategory { get; set; }

#nullable enable
        public string? GenderPreference { get; set; }

        
#nullable disable
        
    }
}