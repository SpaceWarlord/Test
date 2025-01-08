using System;
using System.Collections.Generic;
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
        public required string Gender {  get; set; }
    }
}
