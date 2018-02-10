using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace myMood.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
