using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.App.DTO;
using Test.Models;

namespace Test.App.Services
{
    public class TestService
    {
        private readonly TestDBContext _db;        
        public TestService()
        {
            _db = new TestDBContext();
        }
        public async Task<List<TestDTO>> GetAll()
        {
            return await _db.Tests.Select(c => new TestDTO(c.Id, c.FirstName, c.LastName, c.Nickname)).ToListAsync();
        }

        public async Task<bool> Update(TestDTO test)
        {
            var found = await _db.Tests.FirstOrDefaultAsync(x => x.Id == test.Id);
            if (found is null) return false;
            found.FirstName = test.FirstName;
            found.LastName = test.LastName;
            found.Nickname = test.Nickname;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Add(TestDTO test)
        {
            var found = await _db.Tests.FirstOrDefaultAsync(x => x.Id == test.Id);
            if (found is not null)
            {
                Debug.WriteLine("Test already exists with Id: " + test.Id);
                return false;
            }
            var t = new TestModel()
            {
                Id = test.Id,
                FirstName = test.FirstName,
                LastName = test.LastName,
                Nickname = test.Nickname,                
            };
            _db.Tests.Add(t);

            //if more then 0 something was added to database
            //https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext.savechangesasync?view=efcore-9.0
            return (await _db.SaveChangesAsync()) > 0;
        }
    }
}
