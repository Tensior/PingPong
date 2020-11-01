namespace Services
{
    public readonly struct PlayerData
    {
        public readonly int BestScore;

        public PlayerData(int bestScore)
        {
            BestScore = bestScore;
        }
    }
}