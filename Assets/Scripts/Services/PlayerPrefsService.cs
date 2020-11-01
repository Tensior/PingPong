using Models;
using UnityEngine;

namespace Services
{
    public class PlayerPrefsService : IPlayerDataService
    {
        [Inject] public IScoreModel ScoreModel { get; set; }
        [Inject] public IBallModel BallModel { get; set; }
        
        private const string BEST_SCORE_KEY = "BestScore";
        private const string BALL_COLOR_KEY = "BallColor";
        
        public void Load()
        {
            ScoreModel.BestScore = PlayerPrefs.GetInt(BEST_SCORE_KEY);
            if (ColorUtility.TryParseHtmlString(PlayerPrefs.GetString(BALL_COLOR_KEY), out var ballColor))
            {
                BallModel.Color = ballColor;
            }
        }

        public void Save()
        {
            PlayerPrefs.SetInt(BEST_SCORE_KEY, ScoreModel.BestScore);
            PlayerPrefs.SetString(BALL_COLOR_KEY, "#" + ColorUtility.ToHtmlStringRGBA(BallModel.Color));
            PlayerPrefs.Save();
        }
    }
}