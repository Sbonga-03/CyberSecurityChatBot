namespace CyberSecurityChatbot
{
    partial class TaskForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.chkReminder = new System.Windows.Forms.CheckBox();
            this.dtpReminder = new System.Windows.Forms.DateTimePicker();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnComplete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.listViewTasks = new System.Windows.Forms.ListView();
            this.colId = new System.Windows.Forms.ColumnHeader();
            this.colTitle = new System.Windows.Forms.ColumnHeader();
            this.colDesc = new System.Windows.Forms.ColumnHeader();
            this.colReminder = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();

            // ================= PANEL TOP =================
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(22, 160, 133);
            this.panelTop.Controls.Add(this.lblHeader);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 60;

            // ================= HEADER LABEL =================
            this.lblHeader.Text = "📋 Task Assistant";
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.AutoSize = true;
            this.lblHeader.Location = new System.Drawing.Point(15, 13);

            // ================= TITLE LABEL =================
            this.lblTitle.Text = "Task Title:";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(15, 75);
            this.lblTitle.AutoSize = true;

            // ================= TITLE TEXTBOX =================
            this.txtTitle.Location = new System.Drawing.Point(15, 95);
            this.txtTitle.Size = new System.Drawing.Size(550, 25);
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 10F);

            // ================= DESC LABEL =================
            this.lblDesc.Text = "Description:";
            this.lblDesc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDesc.Location = new System.Drawing.Point(15, 130);
            this.lblDesc.AutoSize = true;

            // ================= DESC TEXTBOX =================
            this.txtDescription.Location = new System.Drawing.Point(15, 150);
            this.txtDescription.Size = new System.Drawing.Size(550, 25);
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 10F);

            // ================= REMINDER CHECKBOX =================
            this.chkReminder.Text = "Set Reminder";
            this.chkReminder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.chkReminder.Location = new System.Drawing.Point(15, 185);
            this.chkReminder.AutoSize = true;
            this.chkReminder.CheckedChanged += new System.EventHandler(this.chkReminder_CheckedChanged);

            // ================= DATE PICKER =================
            this.dtpReminder.Location = new System.Drawing.Point(140, 183);
            this.dtpReminder.Size = new System.Drawing.Size(200, 25);
            this.dtpReminder.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpReminder.Enabled = false;
            this.dtpReminder.MinDate = System.DateTime.Today;

            // ================= ADD BUTTON =================
            this.btnAddTask.Text = "➕ Add Task";
            this.btnAddTask.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddTask.BackColor = System.Drawing.Color.FromArgb(22, 160, 133);
            this.btnAddTask.ForeColor = System.Drawing.Color.White;
            this.btnAddTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTask.Location = new System.Drawing.Point(15, 220);
            this.btnAddTask.Size = new System.Drawing.Size(130, 38);
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);

            // ================= LIST VIEW =================
            this.listViewTasks.Location = new System.Drawing.Point(15, 270);
            this.listViewTasks.Size = new System.Drawing.Size(750, 250);
            this.listViewTasks.View = System.Windows.Forms.View.Details;
            this.listViewTasks.FullRowSelect = true;
            this.listViewTasks.GridLines = true;
            this.listViewTasks.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.listViewTasks.Columns.Add(this.colId);
            this.listViewTasks.Columns.Add(this.colTitle);
            this.listViewTasks.Columns.Add(this.colDesc);
            this.listViewTasks.Columns.Add(this.colReminder);
            this.listViewTasks.Columns.Add(this.colStatus);

            // ================= COLUMNS =================
            this.colId.Text = "ID";
            this.colId.Width = 40;
            this.colTitle.Text = "Title";
            this.colTitle.Width = 180;
            this.colDesc.Text = "Description";
            this.colDesc.Width = 250;
            this.colReminder.Text = "Reminder";
            this.colReminder.Width = 120;
            this.colStatus.Text = "Status";
            this.colStatus.Width = 100;

            // ================= DELETE BUTTON =================
            this.btnDelete.Text = "🗑 Delete";
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(15, 535);
            this.btnDelete.Size = new System.Drawing.Size(130, 38);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // ================= COMPLETE BUTTON =================
            this.btnComplete.Text = "✅ Complete";
            this.btnComplete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnComplete.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnComplete.ForeColor = System.Drawing.Color.White;
            this.btnComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComplete.Location = new System.Drawing.Point(160, 535);
            this.btnComplete.Size = new System.Drawing.Size(130, 38);
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);

            // ================= CLOSE BUTTON =================
            this.btnClose.Text = "❌ Close";
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(630, 535);
            this.btnClose.Size = new System.Drawing.Size(130, 38);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // ================= FORM =================
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.chkReminder);
            this.Controls.Add(this.dtpReminder);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.listViewTasks);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.btnClose);
            this.Text = "Task Assistant";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.TaskForm_Load);

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.CheckBox chkReminder;
        private System.Windows.Forms.DateTimePicker dtpReminder;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView listViewTasks;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.ColumnHeader colTitle;
        private System.Windows.Forms.ColumnHeader colDesc;
        private System.Windows.Forms.ColumnHeader colReminder;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel panelTop;
    }
}