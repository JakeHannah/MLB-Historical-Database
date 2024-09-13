using MLBHistoricalDatabase.Data;

namespace MLBHistoricalDatabase.Repositories
{
    public interface IGameRepository
    {
        Task<List<Game>> GetAllGamesDetailedAsync(int Season);
        Task<List<Game>> GetAllGamesByPitcherIdAsync(int pitcherId);
        Task<List<Game>> GetGamesBySeasonAndTeamIdAsync(int Season, int TeamId);
    }
}
