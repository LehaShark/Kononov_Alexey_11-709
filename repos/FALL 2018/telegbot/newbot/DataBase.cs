using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Telegram.Bot.Args;

namespace newbot
{
    class DataBase
    {
        private static void WriteInBd(MessageEventArgs e)
        {
            var messege = e.Message.Text;
            var infoOfStudent = messege.Split(' ');


            var connString = "Host=localhost;Port=5432;Username=postgres;Password=qwerty;Database=Student";

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO Student (name, last_name, sender_id) VALUES (@name, @last_name, @sender_id)";
                    cmd.Parameters.AddWithValue("name", infoOfStudent[0]);
                    cmd.Parameters.AddWithValue("last_name", infoOfStudent[1]);
                    cmd.Parameters.AddWithValue("sender_id", e.Message.From.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}