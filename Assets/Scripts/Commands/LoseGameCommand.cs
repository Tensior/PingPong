using Models;
using Services;
using Signals;
using strange.extensions.command.impl;
using UnityEngine;

namespace Commands
{
    public class LoseGameCommand : Command
    {
        [Inject] public IScoreModel ScoreModel { get; set; }
        [Inject] public IPlayerDataService PlayerDataService { get; set; }
        [Inject] public RestartGameSignal RestartGameSignal { get; set; }
        public override void Execute()
        {
            Debug.Log("LoseGameCommand");
            var playerData = new PlayerData(ScoreModel.BestScore);
            PlayerDataService.Save(playerData);
            RestartGameSignal.Dispatch();
        }
    }
}