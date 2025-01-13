using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.App.DTO;
using Test.Repository.Sql;
using Test.Models;

namespace Test.App.Services
{
    public class ClientService
    {
        //private readonly SqlTestRepository _db;
        private readonly TestDBContext _db;
        public ClientService(TestDBContext db)
        {
            _db = db;
        }

        
        public async Task<List<ClientDTO>> GetAll()
        {
            //return await _db.Clients.Select(x => x.ToClientDTO()).ToListAsync();
            return await _db.Clients.Select(c => new ClientDTO(c.Id, c.FirstName, c.LastName, c.Gender)).ToListAsync();
            //List<Client> clientList = await _db.Clients.ToListAsync();
            //return await clientList.ToClientDTO();
        }

        public async Task<bool> Update(ClientDTO client)
        {
            var found = _db.Clients.FirstOrDefaultAsync(x => x.Id == client.Id);
            if (found.Result is null)
            {
                return false;
            }
            else
            {
                Client c = found.Result as Client;                
                c.FirstName = client.FirstName;
                c.LastName = client.LastName;                
                _db.SaveChanges();
                return true;
            }            
        }
    }
}