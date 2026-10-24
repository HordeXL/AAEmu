using AAEmu.Commons.IO;
using Microsoft.Data.Sqlite;
using NLog;

namespace AAEmu.Game.Utils.DB;

public static class SQLite
{
    private static Logger Logger { get; } = LogManager.GetCurrentClassLogger();

    public static SqliteConnection CreateConnection(string directory = "Data", string sqlite = "compact.sqlite3")
    {
        var dbPath = Path.Combine(FileManager.AppPath, directory, sqlite);
        if (!File.Exists(dbPath))
        {
            Logger.Fatal("Server database does not exist: {0} !", dbPath);
            throw new FileNotFoundException("Server database does not exist: " + dbPath);
        }
        var connection = new SqliteConnection($"Data Source={dbPath}; Mode=ReadOnly; Pooling=False");
        try
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                // compact.sqlite3 is read-only reference data; spilled sorter files must stay in memory.
                // On-disk SQLite temp files fail to be created inside the game server process
                // (SQLITE_CANTOPEN 14, e.g. DoodadManager's ORDER BY full-table reads).
                command.CommandText = "PRAGMA temp_store = MEMORY";
                command.ExecuteNonQuery();
            }
        }
        catch (Exception e)
        {
            Logger.Error(e, "Error on SQLite connect: {0}", e.Message);
            throw;
        }

        return connection;
    }
}
