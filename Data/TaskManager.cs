using System.Collections.Generic;
using System.Text;

namespace CyberSecurityChatbot
{
    internal class TaskManager
    {
        private List<TaskItem> tasks = new List<TaskItem>();

        public void AddTask(string taskName)
        {
            tasks.Add(new TaskItem(taskName));
        }

        public string ViewTasks()
        {
            if (tasks.Count == 0)
                return "No tasks found.";

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < tasks.Count; i++)
            {
                sb.AppendLine($"{i + 1}. {tasks[i]}");
            }

            return sb.ToString();
        }

        public bool CompleteTask(int index)
        {
            if (index >= 0 && index < tasks.Count)
            {
                tasks[index].IsCompleted = true;
                return true;
            }

            return false;
        }

        public int Count()
        {
            return tasks.Count;
        }
    }
}