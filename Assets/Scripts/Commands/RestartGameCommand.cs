using Models;
using Signals;
using strange.extensions.command.impl;

namespace Commands
{
    public class RestartGameCommand : Command
    {
        [Inject] public StartGameSignal StartGameSignal { get; set; }
        [Inject] public IScoreModel ScoreModel { get; set; }
        public override void Execute()
        {
            ScoreModel.CurrentScore = 0;
            StartGameSignal.Dispatch();
        }
    }
}