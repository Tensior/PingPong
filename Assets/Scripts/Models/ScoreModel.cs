using Signals;

namespace Models
{
    class ScoreModel : IScoreModel
    {
        [Inject] public CurrentScoreChangedSignal CurrentScoreChangedSignal { get; set; }

        public int BestScore { get; set; }

        public int CurrentScore
        {
            get => _currentScore;
            set
            {
                _currentScore = value;
                if (_currentScore > BestScore)
                {
                    BestScore = _currentScore;
                }
                CurrentScoreChangedSignal.Dispatch(_currentScore);
            }
        }

        private int _currentScore;
    }
}