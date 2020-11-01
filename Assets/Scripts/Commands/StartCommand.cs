using Models;
using Services;
using Signals;
using strange.extensions.command.impl;
using UnityEngine;

namespace Commands
{
    /// <summary>
    /// Главная комманда, запускающая игру
    /// </summary>
    public class StartCommand : Command
    {
        [Inject] public IScoreModel ScoreModel { get; set; }
        [Inject] public IPlayerDataService PlayerDataService { get; set; }
        [Inject] public StartGameSignal StartGameSignal { get; set; }
        
        public override void Execute()
        {
            Debug.Log("StartCommand");
            var playerData = PlayerDataService.Load();
            ScoreModel.BestScore = playerData.BestScore;
            StartGameSignal.Dispatch();
        }
    }
}