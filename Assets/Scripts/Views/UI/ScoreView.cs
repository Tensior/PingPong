using Models;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

namespace Views.UI
{
    public class ScoreView : View
    {
        [SerializeField] private Text _currentScore;
        [SerializeField] private Text _bestScore;

        private const string CURRENT_SCORE_PREFIX = "Score ";
        private const string BEST_SCORE_PREFIX = "Best Score ";

        public void SetCurrentScore(int score)
        {
            _currentScore.text = CURRENT_SCORE_PREFIX + score;
        }
        
        public void SetBestScore(int score)
        {
            _bestScore.text = BEST_SCORE_PREFIX + score;
        }
    }
}