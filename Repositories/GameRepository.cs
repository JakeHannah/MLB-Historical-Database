using MLBHistoricalDatabase.Data;
using MLBHistoricalDatabase.Repositories;
using System.Data;
using System.Data.SqlClient;


public class GameRepository : IGameRepository
{
    private readonly string _connectionString;

    public GameRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<List<Game>> GetAllGamesDetailedAsync(int season)
    {
        var games = new List<Game>();
        var gameStatsCache = new Dictionary<int, Game>();

        using (var conn = new SqlConnection(_connectionString))
        {
            using (var cmd = new SqlCommand("GetGamesBySeasonDetailed", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Season", season));
                conn.Open();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        int gameId = (int)reader["GameId"];
                        if (!gameStatsCache.TryGetValue(gameId, out Game game))
                        {
                            game = new Game
                            {
                                GameId = gameId,
                                Neutral = (int)reader["Neutral"],
                                Season = (int)reader["Season"],
                                Date = (DateTime)reader["Date"],
                                Playoff = reader["Playoff"] as string,
                                TeamGameStats = new List<TeamGameStats>()
                            };
                            gameStatsCache.Add(gameId, game);
                            games.Add(game);
                        }

                        var teamStat = new TeamGameStats
                        {
                            GameId = gameId,
                            TeamId = (int)reader["TeamId"],
                            IsHome = (bool)reader["IsHome"],
                            Score = (int)reader["Score"],
                            PitcherId = (int)reader["PitcherId"],
                            Team = new Team
                            {
                                TeamId = (int)reader["TeamId"],
                                Name = reader["TeamName"].ToString(),
                                RatingPost = reader["RatingPost"] is DBNull ? 0 : (float)(double)reader["RatingPost"],
                                RatingProb = reader["RatingProb"] is DBNull ? 0 : (float)(double)reader["RatingProb"],
                                RatingPre = reader["RatingPre"] is DBNull ? 0 : (float)(double)reader["RatingPre"]
                            },
                            Pitcher = new Pitcher
                            {
                                PitcherId = (int)reader["PitcherId"],
                                Name = reader["PitcherName"].ToString(),
                                PitcherRgs = reader["PitcherRgs"] is DBNull ? 0 : (float)(double)reader["PitcherRgs"],
                                PitcherAdj = reader["PitcherAdj"] is DBNull ? 0 : (float)(double)reader["PitcherAdj"]
                            }
                        };
                        game.TeamGameStats.Add(teamStat);
                    }
                }
            }
        }
        return games;
    }

    public async Task<List<Game>> GetAllGamesByPitcherIdAsync(int pitcherId)
    {
        var games = new List<Game>();
        var gameStatsCache = new Dictionary<int, Game>();

        using (var conn = new SqlConnection(_connectionString))
        {
            using (var cmd = new SqlCommand("GetAllGamesByPitcherId", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@PitcherId", pitcherId));
                conn.Open();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        int gameId = (int)reader["GameId"];
                        if (!gameStatsCache.TryGetValue(gameId, out Game game))
                        {
                            game = new Game
                            {
                                GameId = gameId,
                                Neutral = (int)reader["Neutral"],
                                Season = (int)reader["Season"],
                                Date = (DateTime)reader["Date"],
                                Playoff = reader["Playoff"] as string,
                                TeamGameStats = new List<TeamGameStats>()
                            };
                            gameStatsCache.Add(gameId, game);
                            games.Add(game);
                        }

                        var teamStat = new TeamGameStats
                        {
                            GameId = gameId,
                            TeamId = (int)reader["TeamId"],
                            IsHome = (bool)reader["IsHome"],
                            Score = (int)reader["Score"],
                            PitcherId = (int)reader["PitcherId"],
                            Team = new Team
                            {
                                TeamId = (int)reader["TeamId"],
                                Name = reader["TeamName"].ToString(),
                                RatingPost = reader["RatingPost"] is DBNull ? 0 : (float)(double)reader["RatingPost"],
                                RatingProb = reader["RatingProb"] is DBNull ? 0 : (float)(double)reader["RatingProb"],
                                RatingPre = reader["RatingPre"] is DBNull ? 0 : (float)(double)reader["RatingPre"]
                            },
                            Pitcher = new Pitcher
                            {
                                PitcherId = (int)reader["PitcherId"],
                                Name = reader["PitcherName"].ToString(),
                                PitcherRgs = reader["PitcherRgs"] is DBNull ? 0 : (float)(double)reader["PitcherRgs"],
                                PitcherAdj = reader["PitcherAdj"] is DBNull ? 0 : (float)(double)reader["PitcherAdj"]
                            }
                        };
                        game.TeamGameStats.Add(teamStat);
                    }
                }
            }
        }
        return games;
    }

    public async Task<List<Game>> GetGamesBySeasonAndTeamIdAsync(int season, int teamId)
    {
        var games = new List<Game>();
        var gameStatsCache = new Dictionary<int, Game>();

        using (var conn = new SqlConnection(_connectionString))
        {
            using (var cmd = new SqlCommand("GetGamesBySeasonAndTeamId", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Season", season));
                cmd.Parameters.Add(new SqlParameter("@TeamId", teamId));
                conn.Open();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        int gameId = (int)reader["GameId"];
                        if (!gameStatsCache.TryGetValue(gameId, out Game game))
                        {
                            game = new Game
                            {
                                GameId = gameId,
                                Neutral = (int)reader["Neutral"],
                                Season = (int)reader["Season"],
                                Date = (DateTime)reader["Date"],
                                Playoff = reader["Playoff"] as string,
                                TeamGameStats = new List<TeamGameStats>()
                            };
                            gameStatsCache.Add(gameId, game);
                            games.Add(game);
                        }

                        var teamStat = new TeamGameStats
                        {
                            GameId = gameId,
                            TeamId = (int)reader["TeamId"],
                            IsHome = (bool)reader["IsHome"],
                            Score = (int)reader["Score"],
                            PitcherId = (int)reader["PitcherId"],
                            Team = new Team
                            {
                                TeamId = (int)reader["TeamId"],
                                Name = reader["TeamName"].ToString(),
                                FullName= reader["FullName"].ToString(),
                                RatingPost = reader["RatingPost"] is DBNull ? 0 : (float)(double)reader["RatingPost"],
                                RatingProb = reader["RatingProb"] is DBNull ? 0 : (float)(double)reader["RatingProb"],
                                RatingPre = reader["RatingPre"] is DBNull ? 0 : (float)(double)reader["RatingPre"]
                            },
                            Pitcher = new Pitcher
                            {
                                PitcherId = (int)reader["PitcherId"],
                                Name = reader["PitcherName"].ToString(),
                                PitcherRgs = reader["PitcherRgs"] is DBNull ? 0 : (float)(double)reader["PitcherRgs"],
                                PitcherAdj = reader["PitcherAdj"] is DBNull ? 0 : (float)(double)reader["PitcherAdj"]
                            }
                        };
                        game.TeamGameStats.Add(teamStat);
                    }
                }
            }
        }
        return games;
    }

}
