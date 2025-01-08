using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.App.DTO;
using Test.App.Services;

namespace Test.App.ViewModels
{
    public partial class PlayerScoreViewModel: ObservableObject
    {
        private readonly PlayerService _playerService;
        public PlayerScoreViewModel(PlayerService playerService)
        {
            _playerService = playerService;
        }

        [ObservableProperty]
        private int _id;
        [ObservableProperty]
        private string _name;
        [ObservableProperty]
        private int _score;

        private async Task<bool> Update(PlayerScoreViewModel player)
        {
            var update = new PlayerUpdateScoreDto
            {
                Id = player.Id,
                Score = player.Score
            };
            return await _playerService.Update(update);
        }

    }
}
