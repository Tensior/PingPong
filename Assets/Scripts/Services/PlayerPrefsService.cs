using UnityEngine;

namespace Services
{
    public class PlayerPrefsService : IPlayerDataService
    {
        private const string BEST_SCORE_KEY = "BestScore";
        
        public PlayerData Load()
        {
            return new PlayerData(PlayerPrefs.GetInt(BEST_SCORE_KEY));
        }

        public void Save(PlayerData playerData)
        {
            PlayerPrefs.SetInt(BEST_SCORE_KEY, playerData.BestScore);
            PlayerPrefs.Save();
        }
    }
}