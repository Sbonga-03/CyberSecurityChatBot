using System.Collections.Generic;
using System.Text;

namespace CyberSecurityChatbot
{
    internal class TaskManager
    {
        private DatabaseHelper db = new DatabaseHelper();

        public void AddTask(string taskName)
        {
            db.AddTask(taskName, "Added via chat", null);
        }

        public string ViewTasks()
        {
            List<TaskItem> tasks = db.GetAllTasks();

            if (tasks.Count == 0)
                return "No tasks found.";

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < tasks.Count; i++)
            {
                sb.AppendLine($"{i + 1}. {tasks[i]}");
            }

            return sb.ToString();
        }

        public bool CompleteTask(int id)
        {
            db.MarkComplete(id);
            return true;
        }

        public int Count()
        {
            List<TaskItem> tasks = db.GetAllTasks();
            return tasks.Count;
        }
    }
}