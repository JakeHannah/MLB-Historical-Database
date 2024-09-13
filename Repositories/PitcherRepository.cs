using MLBHistoricalDatabase.Data;
using MLBHistoricalDatabase.Repositories;
using System.Data;
using System.Data.SqlClient;

public class PitcherRepository : IPitcherRepository
{
    private readonly string _connectionString;

    public PitcherRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<List<Pitcher>> ExecuteProcedureAsync(string procedureName)
    {
        var pitchers = new List<Pitcher>();

        using (var conn = new SqlConnection(_connectionString))
        {
            using (var cmd = new SqlCommand(procedureName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                // Add parameters if needed
                conn.Open();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var pitcher = new Pitcher
                        {
                            PitcherId = (int)reader["PitcherId"],
                            Name = reader["Name"].ToString(),
                            PitcherRgs = reader["PitcherRgs"] is DBNull ? 0 : (float)(double)reader["PitcherRgs"],
                            PitcherAdj = reader["PitcherAdj"] is DBNull ? 0 : (float)(double)reader["PitcherAdj"]
                        };
                        pitchers.Add(pitcher);
                    }
                }
            }
        }

        return pitchers;
    }


    public async Task<Pitcher> GetPitcherByIdAsync(int pitcherId)
    {
        Pitcher pitcher = null;

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            using (SqlCommand cmd = new SqlCommand("GetPitcherDetailsById", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PitcherId", pitcherId);
                conn.Open();
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    if (reader.Read())
                    {
                        pitcher = new Pitcher
                        {
                            PitcherId = (int)reader["PitcherId"],
                            Name = reader["Name"].ToString(),
                            PitcherRgs = reader["PitcherRgs"] is DBNull ? 0 : (float)(double)reader["PitcherRgs"],
                            PitcherAdj = reader["PitcherAdj"] is DBNull ? 0 : (float)(double)reader["PitcherAdj"]
                        };
                    }
                }
            }
        }

        return pitcher;
    }

    public async Task<List<Pitcher>> GetAllPitchersAsync()
    {
        var pitchers = new List<Pitcher>();

        using (var conn = new SqlConnection(_connectionString))
        {
            using (var cmd = new SqlCommand("GetAllPitchers", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var pitcher = new Pitcher
                        {
                            PitcherId = (int)reader["PitcherId"],
                            Name = reader["Name"].ToString(),
                            PitcherRgs = reader["PitcherRgs"] is DBNull ? 0 : (float)(double)reader["PitcherRgs"],
                            PitcherAdj = reader["PitcherAdj"] is DBNull ? 0 : (float)(double)reader["PitcherAdj"]
                        };
                        pitchers.Add(pitcher);
                    }
                }
            }
        }

        return pitchers;
    }

    public async Task<List<Pitcher>> GetPitchersByRgsAsync(float pitcherRgs)
    {
        var pitchers = new List<Pitcher>();

        using (var conn = new SqlConnection(_connectionString))
        {
            using (var cmd = new SqlCommand("GetPitchersByRgs", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PitcherRgs", pitcherRgs);
                conn.Open();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var pitcher = new Pitcher
                        {
                            PitcherId = (int)reader["PitcherId"],
                            Name = reader["Name"].ToString(),
                            PitcherRgs = reader["PitcherRgs"] is DBNull ? 0 : (float)(double)reader["PitcherRgs"],
                            PitcherAdj = reader["PitcherAdj"] is DBNull ? 0 : (float)(double)reader["PitcherAdj"]
                        };
                        pitchers.Add(pitcher);
                    }
                }
            }
        }

        return pitchers;
    }
}

