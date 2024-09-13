using MLBHistoricalDatabase.Data;
using MLBHistoricalDatabase.Repositories;
using System.Data;
using System.Data.SqlClient;

public class TeamRepository : ITeamRepository
{
    private readonly string _connectionString;

    public TeamRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<List<Team>> GetAllTeamsAsync()
    {
        var teams = new List<Team>();

        using (var conn = new SqlConnection(_connectionString))
        {
            using (var cmd = new SqlCommand("GetAllTeams", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var team = new Team
                        {
                            TeamId = (int)reader["TeamId"],
                            Name = reader["Name"].ToString(),
                            FullName = reader["FullName"].ToString(),
                            RatingPost = reader["RatingPost"] is DBNull ? 0 : (float)(double)reader["RatingPost"],
                            RatingPre = reader["RatingPre"] is DBNull ? 0 : (float)(double)reader["RatingPre"],
                            RatingProb = reader["RatingProb"] is DBNull ? 0 : (float)(double)reader["RatingProb"]
                        };
                        teams.Add(team);
                    }
                }
            }
        }

        return teams;
    }

    public async Task<List<int>> GetTeamActiveSeasonsAsync(int teamId)
    {
        var seasons = new List<int>();
        using (var conn = new SqlConnection(_connectionString))
        {
            using (var cmd = new SqlCommand("GetActiveSeasonsByTeamId", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TeamId", teamId));
                conn.Open();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        seasons.Add((int)reader["Season"]);
                    }
                }
            }
        }
        return seasons;
    }
}