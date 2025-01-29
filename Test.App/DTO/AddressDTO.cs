using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.App.DTO
{
    public class AddressDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public string UnitNum { get; set; }
        public string StreetNum { get; set; }
        public string StreetName { get; set; }
        public string StreetType { get; set; }
        public string Suburb { get; set; }

        public AddressDTO(string id, string name, string unitNum, string streetNum, string streetName, string streetType, string suburb) 
        { 
            Id=id;
            Name=name;
            UnitNum=unitNum;
            StreetNum=streetNum;
            StreetName=streetName;
            StreetType=streetType;
            Suburb=suburb;
        }
    }
}
