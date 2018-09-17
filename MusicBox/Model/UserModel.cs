using Microsoft.Data.Sqlite;
using MusicBox.Entity;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace MusicBox.Model
{
    public class UserModel
    {
        private static ObservableCollection<Entity.User> listUser;

        //private static void InitUsers()
        //{
        //    listUser.Add(new Entity.User
        //    {
        //        Id = 1,
        //        Name = "Thông",
        //        Email = "thong@gmail.com",
        //        Phone = "0123456789",
        //        Address = "8 Tôn Thất Thuyết",
        //        Avatar = "",
        //    });
        //    listUser.Add(new Entity.User
        //    {
        //        Id = 1,
        //        Name = "Thông 2",
        //        Email = "thong2@gmail.com",
        //        Phone = "0123456789",
        //        Address = "8 Tôn Thất Thuyết",
        //        Avatar = "",
        //    });
        //    listUser.Add(new Entity.User
        //    {
        //        Id = 1,
        //        Name = "Thông 3",
        //        Email = "thong3@gmail.com",
        //        Phone = "0123456789",
        //        Address = "8 Tôn Thất Thuyết",
        //        Avatar = "",
        //    });
        //    listUser.Add(new Entity.User
        //    {
        //        Id = 1,
        //        Name = "Thông 4",
        //        Email = "thong4@gmail.com",
        //        Phone = "0123456789",
        //        Address = "8 Tôn Thất Thuyết",
        //        Avatar = "",
        //    });
        //}

        public static ObservableCollection<Entity.User> GetUsers()
        {
            DataAccess.InitializeDatabase();

            if (listUser == null)
            {
                listUser = new ObservableCollection<Entity.User>();

            }
            using (SqliteConnection db = new SqliteConnection("Filename=users_manager.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand();
                selectCommand.Connection = db;
                selectCommand.CommandText = "SELECT * FROM users";
                SqliteDataReader sqliteData = selectCommand.ExecuteReader();
                Entity.User user;
                while (sqliteData.Read())
                {
                    user = new Entity.User
                    {
                        Id = Convert.ToInt16(sqliteData["id"]),
                        Name = Convert.ToString(sqliteData["name"]),
                        Email = Convert.ToString(sqliteData["email"]),
                        Phone = Convert.ToString(sqliteData["phone"]),
                        Address = Convert.ToString(sqliteData["address"]),
                        Avatar = Convert.ToString(sqliteData["avatar"]),
                    };
                    listUser.Add(user);
                }
                db.Close();
            }
            if (listUser == null)
            {
                listUser = new ObservableCollection<Entity.User>();
            }
            //InitUsers();
            return listUser;
        }

        public static void SetUsers(ObservableCollection<Entity.User> users)
        {
            listUser = users;
        }

        public static void AddUser(Entity.User user)
        {
            DataAccess.InitializeDatabase();
            using (SqliteConnection db = new SqliteConnection("Filename=users_manager.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO users (name, email, phone, address, avatar) VALUES (@name, @email, @phone, @address, @avatar);";
                insertCommand.Parameters.AddWithValue("@name", user.Name);
                insertCommand.Parameters.AddWithValue("@email", user.Email);
                insertCommand.Parameters.AddWithValue("@phone", user.Phone);
                insertCommand.Parameters.AddWithValue("@address", user.Address);
                insertCommand.Parameters.AddWithValue("@avatar", user.Avatar);

                insertCommand.ExecuteReader();

                db.Close();
            }
            if (listUser == null)
            {
                listUser = new ObservableCollection<Entity.User>();
            }
            listUser.Add(user);
        }
        public static string DB_PATH = Path.Combine(Path.Combine(ApplicationData.Current.LocalFolder.Path, "UsersManager.sqlite"));
        public static void AddUserV2(User user)
        {
            using (SQLiteConnection db = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), DB_PATH))
            {
                db.Insert(user);
            } 

        }

        public static ObservableCollection<User> ReadAllUser()
        {
            using (SQLiteConnection db = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), DB_PATH))
            {
                return new ObservableCollection<User>(db.Table<User>());
            }
        }


    }
}
