using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.App.DTO;
using Test.App.ViewModels;
using Test.Models;

namespace Test.App.Helpers
{
    public static class Extensions
    {
        public static List<ClientDTO> ToClientDTO(this List<Client> source)
        {
            return [.. source.Select(x => new ClientDTO
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Gender = x.Gender,
        })];
        }
        public static List<PlayerScoreDto> ToPlayerScoreDto(this List<Player> source)
        {
            return [.. source.Select(x => new PlayerScoreDto
        {
            Id = x.Id,
            Name = x.Name,
            Score = x.Score
        })];
        }

        public static List<PlayerScoreViewModel> ToPlayerScoreViewModel(this List<PlayerScoreDto> source)
        {
            return [.. source.Select(x => new PlayerScoreViewModel(null)
            {
                Id = x.Id,
                Name = x.Name,
                Score = x.Score
            })];
        }

    }
}
