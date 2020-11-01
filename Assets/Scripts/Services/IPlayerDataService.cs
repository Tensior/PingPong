namespace Services
{
    public interface IPlayerDataService
    {
        PlayerData Load();
        void Save(PlayerData playerData);
    }
}