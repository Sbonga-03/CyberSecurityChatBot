using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace CyberSecurityChatbot
{
    internal class DatabaseHelper
    {
        private string connectionString = "Server=localhost;Port=3306;Database=CyberBotDB;Uid=root;Pwd=Roots03;";

        // ================= TEST CONNECTION =================
        public bool TestConnection()
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        // ================= ADD TASK =================
        public void AddTask(string title, string description, DateTime? reminderDate)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Tasks (Title, Description, ReminderDate, IsCompleted) VALUES (@title, @desc, @reminder, false)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@desc", description);
                    cmd.Parameters.AddWithValue("@reminder", reminderDate.HasValue ? (object)reminderDate.Value : DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ================= GET ALL TASKS =================
        public List<TaskItem> GetAllTasks()
        {
            List<TaskItem> tasks = new List<TaskItem>();

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Id, Title, Description, ReminderDate, IsCompleted FROM Tasks";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var task = new TaskItem(reader.GetString("Title"))
                        {
                            Id = reader.GetInt32("Id"),
                            Description = reader.GetString("Description"),
                            ReminderDate = reader.IsDBNull(reader.GetOrdinal("ReminderDate"))
                                ? DateTime.MinValue
                                : reader.GetDateTime("ReminderDate"),
                            IsCompleted = reader.GetBoolean("IsCompleted")
                        };
                        tasks.Add(task);
                    }
                }
            }

            return tasks;
        }

        // ================= DELETE TASK =================
        public void DeleteTask(int id)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Tasks WHERE Id = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ================= MARK COMPLETE =================
        public void MarkComplete(int id)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Tasks SET IsCompleted = true WHERE Id = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}