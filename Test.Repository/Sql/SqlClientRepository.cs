using Microsoft.EntityFrameworkCore;
using Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Repository.Sql
{
    /// <summary>
    /// Contains methods for interacting with the users backend using 
    /// SQL via Entity Framework Core 2.0.
    /// </summary>
    public class SqlClientRepository : IClientRepository
    {
        private readonly TestContext _db;

        public SqlClientRepository(TestContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Client>> GetAsync()
        {
            return await _db.Clients
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Client> GetAsync(int id)
        {
            return await _db.Clients
                .AsNoTracking()
                .FirstOrDefaultAsync(client => client.Id == id);
        }

        public async Task<IEnumerable<Client>> GetAsync(string value)
        {
            string[] parameters = value.Split(' ');
            return await _db.Clients
                .Where(client =>
                    parameters.Any(parameter =>
                        client.FirstName.StartsWith(parameter) ||
                        client.LastName.StartsWith(parameter)))
                .OrderByDescending(client =>
                    parameters.Count(parameter =>
                        client.FirstName.StartsWith(parameter) ||
                        client.LastName.StartsWith(parameter)))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Client> UpsertAsync(Client client)
        {
            var current = await _db.Clients.FirstOrDefaultAsync(_client => _client.Id == client.Id);
            if (null == current)
            {
                _db.Clients.Add(client);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(client);
            }
            await _db.SaveChangesAsync();
            return client;
        }

        public async Task DeleteAsync(int id)
        {
            var client = await _db.Clients.FirstOrDefaultAsync(_client => _client.Id == id);
            if (null != client)
            {
                /*
                var orders = await _db.Orders.Where(order => order.UserId == id).ToListAsync();
                _db.Orders.RemoveRange(orders);
                */
                _db.Clients.Remove(client);
                await _db.SaveChangesAsync();
            }
        }
    }
}
