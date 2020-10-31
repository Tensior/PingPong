namespace Models
{
    public interface IScoreModel
    {
        int CurrentScore { get; set; }
        int BestScore { get; set; }
    }
}