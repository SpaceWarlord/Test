using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.App.DTO;
using Test.Models;
using System.Diagnostics;

namespace Test.App.Services
{
    public class ClientService
    {
        private readonly TestDBContext _db;        
        public ClientService()
        {
            _db = new TestDBContext();
        }
        public async Task<List<ClientDTO>> GetAll()
        {
            return await _db.Clients.Select(c => new ClientDTO(c.Id, c.FirstName, c.LastName, c.Nickname, c.Gender, c.DOB, c.Phone, c.Email, c.HighlightColor, 
                new AddressDTO(c.Address.Id, c.Address.Name, c.Address.UnitNum, c.Address.StreetNum, c.Address.StreetName, c.Address.StreetType, c.Address.SuburbId), c.RiskCategory, c.GenderPreference)).ToListAsync();            
        }

        public async Task<bool> Update(ClientDTO client)
        {
            var found = await _db.Clients.FirstOrDefaultAsync(x => x.Id == client.Id);
            if (found is null) return false;
            found.FirstName = client.FirstName;
            found.LastName = client.LastName;
            found.Gender = client.Gender;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Add(ClientDTO client)
        {
            var found = await _db.Clients.FirstOrDefaultAsync(x => x.Id == client.Id);
            if (found is not null)
            {
                Debug.WriteLine("Error: Client already exists with Id: " + client.Id);
                return false;
            }
            var a = new Address()
            {
                Id = client.Address.Id,
                UnitNum = client.Address.UnitNum,
                StreetNum = client.Address.StreetNum,
                StreetName = client.Address.StreetName,
                StreetType = client.Address.StreetType,
                SuburbId = client.Address.Suburb
            };
            var c = new Client()
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Nickname = client.Nickname,
                Gender = client.Gender,
                DOB = client.Dob,
                Phone = client.Phone,
                Email = client.Email,
                HighlightColor = client.HighlightColor,
                Address = a,
                RiskCategory = client.RiskCategory,
                GenderPreference = client.genderPreference
            };
            _db.Clients.Add(c);

            //if more then 0 something was added to database
            //https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext.savechangesasync?view=efcore-9.0
            return (await _db.SaveChangesAsync()) > 0;                        
        }       
    }
}