namespace CyberSecurityChatbot
{
    partial class ActivityLogForm
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();

            // ================= PANEL TOP =================
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.panelTop.Controls.Add(this.lblHeader);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 60;

            // ================= HEADER =================
            this.lblHeader.Text = "📋 Activity Log";
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.AutoSize = true;
            this.lblHeader.Location = new System.Drawing.Point(15, 13);

            // ================= COUNT LABEL =================
            this.lblCount.Text = "Total Actions: 0";
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(15, 70);

            // ================= LIST BOX =================
            this.listBoxLog.Location = new System.Drawing.Point(15, 100);
            this.listBoxLog.Size = new System.Drawing.Size(570, 350);
            this.listBoxLog.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // ================= REFRESH BUTTON =================
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(22, 160, 133);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(15, 465);
            this.btnRefresh.Size = new System.Drawing.Size(130, 38);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // ================= CLOSE BUTTON =================
            this.btnClose.Text = "< Back";
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(455, 465);
            this.btnClose.Size = new System.Drawing.Size(130, 38);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // ================= FORM =================
            this.ClientSize = new System.Drawing.Size(600, 520);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);
            this.Text = "Activity Log";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.ActivityLogForm_Load);

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
    }
}