namespace CyberSecurityChatbot
{
    partial class QuizForm
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
            this.lblScore = new System.Windows.Forms.Label();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.flowOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.lblFeedback = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();

            // ================= PANEL TOP =================
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(22, 160, 133);
            this.panelTop.Controls.Add(this.lblHeader);
            this.panelTop.Controls.Add(this.lblScore);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 60;

            // ================= HEADER =================
            this.lblHeader.Text = "🎮 Cybersecurity Quiz";
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.AutoSize = true;
            this.lblHeader.Location = new System.Drawing.Point(15, 13);

            // ================= SCORE =================
            this.lblScore.Text = "Score: 0";
            this.lblScore.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblScore.ForeColor = System.Drawing.Color.White;
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(450, 18);

            // ================= PROGRESS BAR =================
            this.progressBar.Location = new System.Drawing.Point(15, 70);
            this.progressBar.Size = new System.Drawing.Size(570, 15);
            this.progressBar.ForeColor = System.Drawing.Color.FromArgb(22, 160, 133);

            // ================= QUESTION LABEL =================
            this.lblQuestion.Text = "";
            this.lblQuestion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblQuestion.Location = new System.Drawing.Point(15, 95);
            this.lblQuestion.Size = new System.Drawing.Size(570, 80);
            this.lblQuestion.AutoSize = false;

            // ================= FLOW OPTIONS =================
            this.flowOptions.Location = new System.Drawing.Point(15, 185);
            this.flowOptions.Size = new System.Drawing.Size(570, 220);
            this.flowOptions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowOptions.WrapContents = false;
            this.flowOptions.AutoScroll = true;

            // ================= FEEDBACK LABEL =================
            this.lblFeedback.Text = "";
            this.lblFeedback.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFeedback.Location = new System.Drawing.Point(15, 415);
            this.lblFeedback.Size = new System.Drawing.Size(570, 60);
            this.lblFeedback.AutoSize = false;

            // ================= NEXT BUTTON =================
            this.btnNext.Text = "Next ➡";
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(22, 160, 133);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(15, 485);
            this.btnNext.Size = new System.Drawing.Size(130, 38);
            this.btnNext.Visible = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);

            // ================= CLOSE BUTTON =================
            this.btnClose.Text = "❌ Close";
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(455, 485);
            this.btnClose.Size = new System.Drawing.Size(130, 38);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // ================= FORM =================
            this.ClientSize = new System.Drawing.Size(620, 540);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.flowOptions);
            this.Controls.Add(this.lblFeedback);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnClose);
            this.Text = "Cybersecurity Quiz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.QuizForm_Load);

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.FlowLayoutPanel flowOptions;
        private System.Windows.Forms.Label lblFeedback;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}