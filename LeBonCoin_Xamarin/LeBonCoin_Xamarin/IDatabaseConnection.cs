using System;
using System.Collections.Generic;
using System.Text;

namespace LeBonCoin_Xamarin
{
    public interface IDatabaseConnection
        {
            SQLite.SQLiteConnection DbConnection();
        }
}
