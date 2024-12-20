using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Repository.Sql
{
    /// <summary>
    /// Contains methods for interacting with the app backend using 
    /// SQL via Entity Framework Core 6.0. 
    /// </summary>
    public class SqlTestRepository : ITestRepository
    {
        private readonly DbContextOptions<TestContext> _dbOptions;

        public SqlTestRepository(DbContextOptionsBuilder<TestContext>
            dbOptionsBuilder)
        {
            _dbOptions = dbOptionsBuilder.Options;
            using (var db = new TestContext(_dbOptions))
            {
                db.Database.EnsureCreated();
            }
        }       
        
        public IClientRepository Clients => new SqlClientRepository(
            new TestContext(_dbOptions));
        
    }
}
