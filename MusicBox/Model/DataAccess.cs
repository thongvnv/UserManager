using Microsoft.Data.Sqlite;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace MusicBox.Model
{
    public class DataAccess
    {
        public static void InitializeDatabase()
        {
            using (SqliteConnection db =
                new SqliteConnection("Filename=users_manager.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS users (id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "name NVARCHAR(50) NOT NULL, " +
                    "email NVARCHAR(255), " +
                    "phone NVARCHAR(50), " +
                    "address NVARCHAR(50), " +
                    "avatar NVARCHAR(255)" +
                    ") ";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }

        public static string DB_PATH = Path.Combine(Path.Combine(ApplicationData.Current.LocalFolder.Path, "UsersManager.sqlite"));
        public static void CreateDatabase()
        {

            using (var db = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), DB_PATH))
            {
                db.CreateTable<Entity.User>();

            }
        }

    }
}