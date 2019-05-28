using NewBot;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBot
{
    public class UserService<T> : IDataService<T> where T : User, new()
    {
        
        const string connString = "Host=localhost;Port=5432;Username=postgres;Password=Z1478963z;Database=sem";
        private string ConnectionString { get; set; }

        public void Save(T user)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO users(step, answer) VALUES (@step, @answer)";
                    cmd.Parameters.AddWithValue("@step", user.step);
                    foreach (string e in user.answer)
                    {
                        cmd.Parameters.AddWithValue("@answer", e);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<T> GetAll()
        {
            var result = new List<T>();
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT sender_id, name,lastname,date_current FROM users";
                    var reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        T user = new T();
                        user.step = int.Parse(reader[0].ToString());
                        //user.answer = reader[1].ToString();
                        result.Add(user);
                    }
                }
                return result;
            }
        }
    }
}
