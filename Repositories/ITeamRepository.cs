using MLBHistoricalDatabase.Data;

namespace MLBHistoricalDatabase.Repositories
{
    public interface ITeamRepository
    {
        Task<List<Team>> GetAllTeamsAsync();
        Task<List<int>> GetTeamActiveSeasonsAsync(int teamId);
    }
}
