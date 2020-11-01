using Models;
using strange.extensions.command.impl;

namespace Commands
{
    public class IncreaseScoreCommand : Command
    {
        [Inject] public IScoreModel ScoreModel {get; set; }
        
        public override void Execute()
        {
            ScoreModel.CurrentScore++;
        }
    }
}