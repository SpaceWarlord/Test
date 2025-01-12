using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.App.DTO;
using Test.Repository.Sql;
using Test.App.DTO;

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
            return await _db.Clients.Select(x => x.ToClientDTO()).ToListAsync();            
        }
        
    }
}
