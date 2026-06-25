using System;

namespace CyberSecurityChatbot
{
    internal class TaskItem
    {
        public string TaskName { get; set; }

        public DateTime ReminderDate { get; set; }

        public bool IsCompleted { get; set; }

        public int Id { get; set; }
        public string Description { get; set; }

        public TaskItem(string taskName)
        {
            TaskName = taskName;
            ReminderDate = DateTime.MinValue;
            IsCompleted = false;
        }

        public override string ToString()
        {
            string status = IsCompleted ? "Completed" : "Pending";

            if (ReminderDate != DateTime.MinValue)
            {
                return $"{TaskName} | Reminder: {ReminderDate.ToShortDateString()} | {status}";
            }

            return $"{TaskName} | {status}";
        }
    }
}