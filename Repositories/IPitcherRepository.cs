using MLBHistoricalDatabase.Data;

namespace MLBHistoricalDatabase.Repositories
{
    public interface IPitcherRepository
    {
        Task<List<Pitcher>> ExecuteProcedureAsync(string procedureName);
        Task<List<Pitcher>> GetAllPitchersAsync();
        Task<Pitcher> GetPitcherByIdAsync(int pitcherId);
        Task<List<Pitcher>> GetPitchersByRgsAsync(float pitcherRgs);
    }
}
