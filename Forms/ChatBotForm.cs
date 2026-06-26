using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace CyberSecurityChatbot
{
    public partial class ChatBotForm : Form
    {
        private ChatBotEngine engine = new ChatBotEngine();
        private DatabaseHelper db = new DatabaseHelper();
        private ActivityLogger activityLogger = new ActivityLogger();

        private Image userImg;
        private Image botImg;

        private bool isWaitingForName = true;
        private bool firstBotMessageSpoken = false;

        private SpeechSynthesizer voice = new SpeechSynthesizer();
        private Label lblAscii;

        public ChatBotForm()
        {
            InitializeComponent();
        }

        // ================= LOAD =================
        private void ChatBotForm_Load(object sender, EventArgs e)
        {
            userImg = Image.FromFile("Resources/user.png");
            botImg = Image.FromFile("Resources/bot.png");

            txtUserInput.KeyDown += TxtUserInput_KeyDown;

            lblAscii = new Label
            {
                Text =
@"   ██████ ███████  █████  ██████  
██      ██      ██   ██ ██   ██ 
██      ███████ ███████ ██████  
██           ██ ██   ██ ██   ██ 
 ██████ ███████ ██   ██ ██████  
                               ",
                Font = new Font("Consolas", 6f),
                ForeColor = Color.White,
                AutoSize = true,
                BackColor = Color.Transparent
            };

            panel4.Controls.Add(lblAscii);
            lblAscii.Location = new Point(40, 10);

            // ================= TASKS BUTTON =================
            Button btnTasks = new Button
            {
                Text = "📋 Tasks",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(22, 160, 133),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(160, 45),
                Location = new Point(28, 130),
                Cursor = Cursors.Hand
            };
            btnTasks.FlatAppearance.BorderSize = 0;
            btnTasks.Click += btnTasks_Click;
            panel4.Controls.Add(btnTasks);

            // ================= QUIZ BUTTON =================
            Button btnQuiz = new Button
            {
                Text = "🎮 Quiz",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(41, 128, 185),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(160, 45),
                Location = new Point(28, 450),
                Cursor = Cursors.Hand
            };
            btnQuiz.FlatAppearance.BorderSize = 0;
            btnQuiz.Click += btnQuiz_Click;
            panel4.Controls.Add(btnQuiz);

            // ================= ACTIVITY LOG BUTTON =================
            Button btnLog = new Button
            {
                Text = "📜 Activity Log",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(44, 62, 80),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(160, 45),
                Location = new Point(28, 510),
                Cursor = Cursors.Hand
            };
            btnLog.FlatAppearance.BorderSize = 0;
            btnLog.Click += btnLog_Click;
            panel4.Controls.Add(btnLog);

            // ================= WELCOME MESSAGE =================
            AddMessage(
                "Hello! 👋 I'm your Cybersecurity Awareness Bot. What is your name?",
                false,
                DateTime.Now.ToShortTimeString(),
                true
            );
        }

        // ================= BUTTON CLICKS =================
        private void btnTasks_Click(object sender, EventArgs e)
        {
            TaskForm taskForm = new TaskForm(activityLogger);
            taskForm.ShowDialog();
        }

        private void btnQuiz_Click(object sender, EventArgs e)
        {
            QuizForm quizForm = new QuizForm(activityLogger);
            quizForm.ShowDialog();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            ActivityLogForm logForm = new ActivityLogForm(activityLogger);
            logForm.ShowDialog();
        }

        // ================= INPUT =================
        private void TxtUserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendMessage();
                e.SuppressKeyPress = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        // ================= MAIN FLOW =================
        private async void SendMessage()
        {
            string message = txtUserInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(message))
                return;

            string time = DateTime.Now.ToShortTimeString();

            if (isWaitingForName)
            {
                engine.UserName = message;
                isWaitingForName = false;

                AddMessage(message, true, time);

                await ShowTyping();

                AddMessage(
                    $"Nice to meet you, {message}! 😊 Ask me anything about cybersecurity.",
                    false,
                    DateTime.Now.ToShortTimeString()
                );

                await ShowTyping();

                // ================= QUICK ACTION BUTTONS IN BUBBLE =================
                Panel container = new Panel
                {
                    Width = flpChat.ClientSize.Width,
                    AutoSize = true,
                    Margin = new Padding(5)
                };

                PictureBox botAvatar = new PictureBox
                {
                    Size = new Size(35, 35),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Image = botImg,
                    Margin = new Padding(10, 5, 5, 5)
                };

                Panel bubble = new Panel
                {
                    Padding = new Padding(10),
                    BackColor = Color.FromArgb(235, 235, 235),
                    AutoSize = true,
                    MaximumSize = new Size(280, 0)
                };

                FlowLayoutPanel bubbleContent = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.TopDown,
                    AutoSize = true,
                    WrapContents = false,
                    Width = 250
                };

                Label msgLabel = new Label
                {
                    Text = "💡 What would you like to do?",
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    AutoSize = true,
                    MaximumSize = new Size(240, 0),
                    Margin = new Padding(0, 0, 0, 8)
                };

                bubbleContent.Controls.Add(msgLabel);

                string[] btnLabels = {
                    "📋 Manage My Tasks",
                    "🎮 Take the Quiz",
                    "📜 View Activity Log",
                    "🔐 Ask About Passwords",
                    "🛡️ Ask About Phishing",
                    "🔑 Enable 2FA"
                };

                foreach (string label in btnLabels)
                {
                    Button quickBtn = new Button
                    {
                        Text = label,
                        Font = new Font("Segoe UI", 9F),
                        ForeColor = Color.FromArgb(22, 160, 133),
                        BackColor = Color.White,
                        FlatStyle = FlatStyle.Flat,

                        Width = 240,     // Makes all buttons same width
                        Height = 35,     // Makes all buttons same height

                        Margin = new Padding(0, 3, 0, 3),
                        Cursor = Cursors.Hand,

                        TextAlign = ContentAlignment.MiddleLeft,
                        Padding = new Padding(6, 4, 6, 4)
                    };

                    quickBtn.FlatAppearance.BorderColor = Color.FromArgb(22, 160, 133);
                    quickBtn.FlatAppearance.BorderSize = 1;

                    string capturedLabel = label;
                    quickBtn.Click += (s, ev) =>
                    {
                        if (capturedLabel.Contains("Tasks"))
                        {
                            TaskForm taskForm = new TaskForm(activityLogger);
                            taskForm.ShowDialog();
                        }
                        else if (capturedLabel.Contains("Quiz"))
                        {
                            QuizForm quizForm = new QuizForm(activityLogger);
                            quizForm.ShowDialog();
                        }
                        else if (capturedLabel.Contains("Activity Log"))
                        {
                            ActivityLogForm logForm = new ActivityLogForm(activityLogger);
                            logForm.ShowDialog();
                        }
                        else if (capturedLabel.Contains("Passwords"))
                        {
                            AddMessage("Tell me about passwords", true, DateTime.Now.ToShortTimeString());
                            string resp = engine.ProcessMessage("password");
                            activityLogger.Log("Chat: User asked about passwords");
                            AddMessage(resp, false, DateTime.Now.ToShortTimeString());
                        }
                        else if (capturedLabel.Contains("Phishing"))
                        {
                            AddMessage("Tell me about phishing", true, DateTime.Now.ToShortTimeString());
                            string resp = engine.ProcessMessage("phishing");
                            activityLogger.Log("Chat: User asked about phishing");
                            AddMessage(resp, false, DateTime.Now.ToShortTimeString());
                        }
                        else if (capturedLabel.Contains("2FA"))
                        {
                            AddMessage("Enable 2FA", true, DateTime.Now.ToShortTimeString());
                            string resp = engine.ProcessMessage("enable 2FA");
                            activityLogger.Log("Chat: User asked about 2FA");
                            AddMessage(resp, false, DateTime.Now.ToShortTimeString());
                        }
                    };

                    bubbleContent.Controls.Add(quickBtn);
                }

                bubble.Controls.Add(bubbleContent);

                Label timeLabel = new Label
                {
                    Text = DateTime.Now.ToShortTimeString(),
                    Font = new Font("Segoe UI", 7),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Margin = new Padding(0, 3, 0, 0)
                };

                FlowLayoutPanel bubbleColumn = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.TopDown,
                    AutoSize = true,
                    WrapContents = false
                };

                bubbleColumn.Controls.Add(bubble);
                bubbleColumn.Controls.Add(timeLabel);

                bubble.HandleCreated += (s, e) =>
                {
                    GraphicsPath path = new GraphicsPath();
                    int r = 15;
                    path.AddArc(0, 0, r, r, 180, 90);
                    path.AddArc(bubble.Width - r, 0, r, r, 270, 90);
                    path.AddArc(bubble.Width - r, bubble.Height - r, r, r, 0, 90);
                    path.AddArc(0, bubble.Height - r, r, r, 90, 90);
                    path.CloseAllFigures();
                    bubble.Region = new Region(path);
                };

                FlowLayoutPanel row = new FlowLayoutPanel
                {
                    Width = flpChat.ClientSize.Width,
                    AutoSize = true,
                    WrapContents = false,
                    FlowDirection = FlowDirection.LeftToRight
                };

                row.Controls.Add(botAvatar);
                row.Controls.Add(bubbleColumn);

                container.Controls.Add(row);
                flpChat.Controls.Add(container);
                flpChat.ScrollControlIntoView(container);

                txtUserInput.Clear();
                return;
            }

            AddMessage(message, true, time);
            txtUserInput.Clear();

            await ShowTyping();

            string response;

            if (message.ToLower().Contains("show activity log") ||
                message.ToLower().Contains("activity log") ||
                message.ToLower().Contains("what have you done"))
            {
                ActivityLogForm logForm = new ActivityLogForm(activityLogger);
                logForm.ShowDialog();
                response = "Here's your activity log! 📜";
            }
            else
            {
                response = engine.ProcessMessage(message);
            }

            activityLogger.Log($"Chat: User asked about \"{message}\"");

            AddMessage(response, false, DateTime.Now.ToShortTimeString());

            txtUserInput.Focus();
        }

        // ================= TYPING EFFECT =================
        private async System.Threading.Tasks.Task ShowTyping()
        {
            AddMessage("Typing...", false, DateTime.Now.ToShortTimeString());
            await System.Threading.Tasks.Task.Delay(1500);

            if (flpChat.Controls.Count > 0)
                flpChat.Controls.RemoveAt(flpChat.Controls.Count - 1);
        }

        // ================= CHAT UI =================
        private void AddMessage(string message, bool isUser, string time, bool speak = false)
        {
            Panel container = new Panel
            {
                Width = flpChat.ClientSize.Width,
                AutoSize = true,
                Margin = new Padding(5)
            };

            PictureBox avatar = new PictureBox
            {
                Size = new Size(35, 35),
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = isUser ? userImg : botImg
            };

            Panel bubble = new Panel
            {
                Padding = new Padding(10),
                BackColor = isUser
                    ? Color.FromArgb(220, 255, 220)
                    : Color.FromArgb(235, 235, 235),
                AutoSize = true,
                MaximumSize = new Size(260, 0)
            };

            Label msg = new Label
            {
                Text = message,
                Font = new Font("Segoe UI", 10),
                AutoSize = true,
                MaximumSize = new Size(240, 0)
            };

            bubble.Controls.Add(msg);

            Label timeLabel = new Label
            {
                Text = time,
                Font = new Font("Segoe UI", 7),
                ForeColor = Color.Gray,
                AutoSize = true,
                Margin = new Padding(0, 3, 0, 0)
            };

            FlowLayoutPanel bubbleColumn = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                AutoSize = true,
                WrapContents = false
            };

            bubbleColumn.Controls.Add(bubble);
            bubbleColumn.Controls.Add(timeLabel);

            bubble.HandleCreated += (s, e) =>
            {
                GraphicsPath path = new GraphicsPath();
                int r = 15;
                path.AddArc(0, 0, r, r, 180, 90);
                path.AddArc(bubble.Width - r, 0, r, r, 270, 90);
                path.AddArc(bubble.Width - r, bubble.Height - r, r, r, 0, 90);
                path.AddArc(0, bubble.Height - r, r, r, 90, 90);
                path.CloseAllFigures();
                bubble.Region = new Region(path);
            };

            FlowLayoutPanel row = new FlowLayoutPanel
            {
                Width = flpChat.ClientSize.Width,
                AutoSize = true,
                WrapContents = false,
                FlowDirection = isUser
                    ? FlowDirection.RightToLeft
                    : FlowDirection.LeftToRight
            };

            avatar.Margin = isUser
                ? new Padding(5, 5, 10, 5)
                : new Padding(10, 5, 5, 5);

            row.Controls.Add(avatar);
            row.Controls.Add(bubbleColumn);

            container.Controls.Add(row);
            flpChat.Controls.Add(container);

            flpChat.ScrollControlIntoView(container);

            if (!isUser && speak && !firstBotMessageSpoken)
            {
                voice.SpeakAsync(message);
                firstBotMessageSpoken = true;
            }
        }

        // ================= DESIGNER EVENTS =================
        private void label1_Click(object sender, EventArgs e) { }

        private void txtUserInput_TextChanged(object sender, EventArgs e) { }
    }
}