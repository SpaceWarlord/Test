using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.App.DTO;
using Test.App.Helpers;
using Test.Models;

namespace Test.App.Services
{
    public class PlayerService
    {
        private readonly TestDBContext _db;
        public PlayerService(TestDBContext db)
        {
            _db = db;
        }

        public async Task<List<PlayerScoreDto>> GetAll()
        {
            //return await _db.Players.Select(x => x.ToPlayerScoreDto()).ToListAsync();
            return null;
        }

        public async Task<bool> Update(PlayerUpdateScoreDto player)
        {
            var found = _db.Players.FirstOrDefaultAsync(x => x.Id == player.Id);
            if (found is null) return false;

            //found.Score = player.Score;
            _db.SaveChanges();
            return true;
        }
    }
}
