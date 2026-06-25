using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CyberSecurityChatbot
{
    public partial class ActivityLogForm : Form
    {
        private ActivityLogger logger;

        public ActivityLogForm(ActivityLogger sharedLogger)
        {
            InitializeComponent();
            logger = sharedLogger;
        }

        private void ActivityLogForm_Load(object sender, EventArgs e)
        {
            LoadLogs();
        }

        private void LoadLogs()
        {
            listBoxLog.Items.Clear();

            List<string> logs = logger.GetLogs();

            if (logs.Count == 0)
            {
                listBoxLog.Items.Add("No activity recorded yet.");
                return;
            }

            // Show most recent first
            for (int i = logs.Count - 1; i >= 0; i--)
            {
                listBoxLog.Items.Add(logs[i]);
            }

            lblCount.Text = $"Total Actions: {logs.Count}";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLogs();
        }
    }
}