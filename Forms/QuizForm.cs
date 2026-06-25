using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CyberSecurityChatbot
{
    public partial class QuizForm : Form
    {
        private ActivityLogger logger;
        private List<QuizQuestion> questions = new List<QuizQuestion>();
        private int currentIndex = 0;
        private int score = 0;

        public QuizForm(ActivityLogger sharedLogger)
        {
            InitializeComponent();
            logger = sharedLogger;
            LoadQuestions();
        }

        // ================= LOAD QUESTIONS =================
        private void LoadQuestions()
        {
            questions.Add(new QuizQuestion(
                "What should you do if you receive an email asking for your password?",
                new string[] { "A) Reply with your password", "B) Delete the email", "C) Report it as phishing", "D) Ignore it" },
                "C",
                "Reporting phishing emails helps prevent scams and protects others."
            ));

            questions.Add(new QuizQuestion(
                "What does 2FA stand for?",
                new string[] { "A) Two Factor Authentication", "B) Two File Access", "C) Total Firewall Access", "D) Two Frequency Alerts" },
                "A",
                "2FA adds a second layer of security beyond just a password."
            ));

            questions.Add(new QuizQuestion(
                "True or False: Using the same password for multiple accounts is safe.",
                new string[] { "A) True", "B) False" },
                "B",
                "Using the same password everywhere means one breach exposes all your accounts."
            ));

            questions.Add(new QuizQuestion(
                "What is ransomware?",
                new string[] { "A) Software that speeds up your PC", "B) Malware that locks files and demands payment", "C) A type of firewall", "D) An antivirus program" },
                "B",
                "Ransomware encrypts your files and demands payment to restore access."
            ));

            questions.Add(new QuizQuestion(
                "What does a VPN do?",
                new string[] { "A) Speeds up your internet", "B) Blocks all ads", "C) Encrypts your internet connection", "D) Removes viruses" },
                "C",
                "A VPN encrypts your connection, protecting your data and privacy."
            ));

            questions.Add(new QuizQuestion(
                "True or False: Public Wi-Fi is always safe to use for banking.",
                new string[] { "A) True", "B) False" },
                "B",
                "Public Wi-Fi is unsecured and can be monitored by attackers."
            ));

            questions.Add(new QuizQuestion(
                "What is phishing?",
                new string[] { "A) A type of firewall", "B) Fake emails or websites to steal information", "C) A strong password technique", "D) A VPN protocol" },
                "B",
                "Phishing tricks users into revealing sensitive information through fake communications."
            ));

            questions.Add(new QuizQuestion(
                "Which of these is the strongest password?",
                new string[] { "A) password123", "B) john1990", "C) P@ssw0rd!2024", "D) 123456" },
                "C",
                "Strong passwords use a mix of uppercase, lowercase, numbers and symbols."
            ));

            questions.Add(new QuizQuestion(
                "True or False: Antivirus software alone is enough to stay safe online.",
                new string[] { "A) True", "B) False" },
                "B",
                "You also need safe browsing habits, strong passwords, and regular updates."
            ));

            questions.Add(new QuizQuestion(
                "What is social engineering?",
                new string[] { "A) Building social media apps", "B) Manipulating people to reveal confidential info", "C) A type of encryption", "D) Network monitoring" },
                "B",
                "Social engineering exploits human psychology rather than technical vulnerabilities."
            ));

            questions.Add(new QuizQuestion(
                "What should you do before clicking a link in an email?",
                new string[] { "A) Click it immediately", "B) Forward it to friends", "C) Hover over it to check the URL", "D) Reply to the sender" },
                "C",
                "Always verify URLs before clicking to avoid phishing and malware."
            ));

            questions.Add(new QuizQuestion(
                "True or False: Software updates should be installed as soon as possible.",
                new string[] { "A) True", "B) False" },
                "A",
                "Updates patch security vulnerabilities that attackers could exploit."
            ));
        }

        // ================= SHOW QUESTION =================
        private void ShowQuestion()
        {
            if (currentIndex >= questions.Count)
            {
                ShowResults();
                return;
            }

            QuizQuestion q = questions[currentIndex];

            lblQuestion.Text = $"Q{currentIndex + 1} of {questions.Count}: {q.Question}";
            lblFeedback.Text = "";
            lblFeedback.ForeColor = Color.Black;

            flowOptions.Controls.Clear();

            foreach (string option in q.Options)
            {
                Button btn = new Button
                {
                    Text = option,
                    Width = 500,
                    Height = 45,
                    Font = new Font("Segoe UI", 10F),
                    BackColor = Color.FromArgb(44, 62, 80),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    Margin = new Padding(5)
                };
                btn.FlatAppearance.BorderSize = 0;
                btn.Click += OptionButton_Click;
                flowOptions.Controls.Add(btn);
            }

            progressBar.Value = currentIndex;
            lblScore.Text = $"Score: {score}/{questions.Count}";
        }

        // ================= ANSWER CLICK =================
        private void OptionButton_Click(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            string selected = clicked.Text.Substring(0, 1);
            QuizQuestion q = questions[currentIndex];

            foreach (Control c in flowOptions.Controls)
                ((Button)c).Enabled = false;

            if (selected == q.CorrectAnswer)
            {
                score++;
                clicked.BackColor = Color.FromArgb(39, 174, 96);
                lblFeedback.Text = "✅ Correct! " + q.Explanation;
                lblFeedback.ForeColor = Color.FromArgb(39, 174, 96);
                logger.Log($"Quiz: Answered Q{currentIndex + 1} correctly");
            }
            else
            {
                clicked.BackColor = Color.FromArgb(192, 57, 43);
                lblFeedback.Text = $"❌ Incorrect! The answer was {q.CorrectAnswer}. {q.Explanation}";
                lblFeedback.ForeColor = Color.FromArgb(192, 57, 43);
                logger.Log($"Quiz: Answered Q{currentIndex + 1} incorrectly");
            }

            lblScore.Text = $"Score: {score}/{questions.Count}";
            btnNext.Visible = true;
        }

        // ================= NEXT BUTTON =================
        private void btnNext_Click(object sender, EventArgs e)
        {
            currentIndex++;
            btnNext.Visible = false;
            ShowQuestion();
        }

        // ================= SHOW RESULTS =================
        private void ShowResults()
        {
            flowOptions.Controls.Clear();
            btnNext.Visible = false;

            string feedback;
            if (score >= 10)
                feedback = "🏆 Outstanding! You're a cybersecurity pro!";
            else if (score >= 7)
                feedback = "👍 Great job! You know your cybersecurity!";
            else if (score >= 5)
                feedback = "📚 Not bad! Keep learning to stay safe online!";
            else
                feedback = "⚠️ Keep studying! Cybersecurity knowledge is important!";

            lblQuestion.Text = $"Quiz Complete!\n\nYour Score: {score} out of {questions.Count}\n\n{feedback}";
            lblFeedback.Text = "";
            progressBar.Value = questions.Count;

            logger.Log($"Quiz completed — Score: {score}/{questions.Count}");

            Button btnRestart = new Button
            {
                Text = "🔄 Restart Quiz",
                Width = 200,
                Height = 45,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                BackColor = Color.FromArgb(22, 160, 133),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Margin = new Padding(5)
            };
            btnRestart.FlatAppearance.BorderSize = 0;
            btnRestart.Click += (s, ev) =>
            {
                currentIndex = 0;
                score = 0;
                ShowQuestion();
            };

            flowOptions.Controls.Add(btnRestart);
        }

        private void QuizForm_Load(object sender, EventArgs e)
        {
            progressBar.Maximum = questions.Count;
            progressBar.Value = 0;
            ShowQuestion();
            logger.Log("Quiz started");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    // ================= QUIZ QUESTION CLASS =================
    public class QuizQuestion
    {
        public string Question { get; set; }
        public string[] Options { get; set; }
        public string CorrectAnswer { get; set; }
        public string Explanation { get; set; }

        public QuizQuestion(string question, string[] options, string correctAnswer, string explanation)
        {
            Question = question;
            Options = options;
            CorrectAnswer = correctAnswer;
            Explanation = explanation;
        }
    }
}