using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.App.Services;

namespace Test.App.ViewModels
{
    public class ScoresViewModel: ObservableObject
    {
        private readonly PlayerService _playerService;
        public ScoresViewModel(PlayerService playerService)
        {
            _playerService = playerService;
        }

        public ObservableCollection<PlayerScoreViewModel> Scores { get; set; } = [];

        public async Task OnLoad()
        {
            var data = await _playerService.GetAll();
            Scores = new ObservableCollection<PlayerScoreViewModel>(data.Select(x => x.ToPlayerScoreViewModel()));
        }

    }
}
