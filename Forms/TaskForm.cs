using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CyberSecurityChatbot
{
    public partial class TaskForm : Form
    {
        private DatabaseHelper db = new DatabaseHelper();
        private ActivityLogger logger;

        public TaskForm(ActivityLogger sharedLogger)
        {
            InitializeComponent();
            logger = sharedLogger;
        }

        // ================= LOAD =================
        private void TaskForm_Load(object sender, EventArgs e)
        {
            LoadTasks();
        }

        // ================= LOAD TASKS FROM DB =================
        private void LoadTasks()
        {
            listViewTasks.Items.Clear();

            List<TaskItem> tasks = db.GetAllTasks();

            foreach (TaskItem task in tasks)
            {
                ListViewItem item = new ListViewItem(task.Id.ToString());
                item.SubItems.Add(task.TaskName);
                item.SubItems.Add(task.Description ?? "");
                item.SubItems.Add(task.ReminderDate != DateTime.MinValue
                    ? task.ReminderDate.ToShortDateString()
                    : "No reminder");
                item.SubItems.Add(task.IsCompleted ? "✅ Done" : "⏳ Pending");
                item.Tag = task.Id;

                if (task.IsCompleted)
                    item.ForeColor = Color.Gray;

                listViewTasks.Items.Add(item);
            }
        }

        // ================= ADD TASK =================
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string description = txtDescription.Text.Trim();
            DateTime? reminder = chkReminder.Checked ? (DateTime?)dtpReminder.Value.Date : null;

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Please enter a task title.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(description))
                description = "No description provided.";

            db.AddTask(title, description, reminder);
            logger.Log($"Task added: {title}" + (reminder.HasValue ? $" (Reminder: {reminder.Value.ToShortDateString()})" : ""));

            txtTitle.Clear();
            txtDescription.Clear();
            chkReminder.Checked = false;

            LoadTasks();

            MessageBox.Show("✅ Task added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ================= DELETE TASK =================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewTasks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a task to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = (int)listViewTasks.SelectedItems[0].Tag;
            string title = listViewTasks.SelectedItems[0].SubItems[1].Text;

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to delete: {title}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                db.DeleteTask(id);
                logger.Log($"Task deleted: {title}");
                LoadTasks();
            }
        }

        // ================= MARK COMPLETE =================
        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (listViewTasks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a task to mark complete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = (int)listViewTasks.SelectedItems[0].Tag;
            string title = listViewTasks.SelectedItems[0].SubItems[1].Text;

            db.MarkComplete(id);
            logger.Log($"Task completed: {title}");
            LoadTasks();

            MessageBox.Show("✅ Task marked as completed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ================= REMINDER CHECKBOX =================
        private void chkReminder_CheckedChanged(object sender, EventArgs e)
        {
            dtpReminder.Enabled = chkReminder.Checked;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}