using Models;
using Services;
using Signals;
using strange.extensions.command.impl;
using UnityEngine;

namespace Commands
{
    public class StopGameCommand : Command
    {
        [Inject] public IScoreModel ScoreModel { get; set; }
        [Inject] public IPlayerDataService PlayerDataService { get; set; }
        [Inject] public RestartGameSignal RestartGameSignal { get; set; }
        public override void Execute()
        {
            Debug.Log("StopGameCommand");
            var playerData = new PlayerData(ScoreModel.BestScore);
            PlayerDataService.Save(playerData);
            RestartGameSignal.Dispatch();
        }
    }
}