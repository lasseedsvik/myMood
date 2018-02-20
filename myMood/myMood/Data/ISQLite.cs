using SQLite;

namespace myMood.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
