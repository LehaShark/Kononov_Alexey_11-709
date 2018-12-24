//using Npgsql;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using Telegram.Bot.Args;
//using NewBot;

//namespace NewBot
//{
//    class DataBase<T> : IDataService<T> where T : User, new()
//    {
//        const string connString = "Host=localhost;Port=5432;Username=postgres;Password=Z1478963z;Database=TelegramBot";
//        private string ConnectionString { get; set;
//        }

//        IEnumerable<T> IDataService<T>.GetAll()
//        {
//            throw new NotImplementedException();
//        }

//        private void Save(T user)
//        {
//            using (var conn = new NpgsqlConnection(connString))
//            {
//                conn.Open();
//                using (var cmd = new NpgsqlCommand())
//                {
//                    cmd.Connection = conn;
//                    cmd.CommandText = "INSERT INTO user (step, answer) VALUES (@step, @answer)";
//                    cmd.Parameters.AddWithValue("step", user.step);
//                    cmd.Parameters.AddWithValue("answer", user.answer);
//                    cmd.ExecuteNonQuery();
//                }
//            }
//        }

//        void IDataService<T>.Save(T user)
//        {
//            using (var conn = new NpgsqlConnection(connString))
//            {
//                conn.Open();
//                using (var cmd = new NpgsqlCommand())
//                {
//                    cmd.Connection = conn;
//                    cmd.CommandText = "INSERT INTO user (step, answer) VALUES (@step, @answer)";
//                    cmd.Parameters.AddWithValue("step", user.step);
//                    cmd.Parameters.AddWithValue("answer", user.answer);
//                    cmd.ExecuteNonQuery();
//                }
//            }
//        }
//    }
//}