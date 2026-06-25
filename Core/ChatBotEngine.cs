using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CyberSecurityChatbot
{
    internal class ChatBotEngine
    {
        // ================= USER PROFILE =================
        public string UserName { get; set; }
        private string favouriteTopic = "";

        // ================= CONVERSATION STATE =================
        private bool awaitingEndDecision = false;

        // ================= MEMORY =================
        private List<string> memory = new List<string>();
        private Random rand = new Random();
        private CyberDictionary dictionary = new CyberDictionary();
        private TaskManager taskManager = new TaskManager();

        // ================= SMALL TALK RESPONSES =================
        private string[] ackResponses =
        {
            "No problem 👍",
            "Got it 👍",
            "Alright 👍",
            "Cool 😄",
            "Okay 👍"
        };

        private string[] thanksResponses =
        {
            "You're welcome 😊",
            "No problem at all 👍",
            "Anytime!",
            "Glad I could help 😊"
        };

        // ================= FALLBACK =================
        private string[] fallbackResponses =
        {
            "I'm not fully sure, but I can help with cybersecurity topics.",
            "Try asking about passwords, phishing, or online safety.",
            "Could you rephrase that for me?",
            "I'm still learning — but I can guide you on cybersecurity."
        };

        // ================= MAIN ENGINE =================
        public string ProcessMessage(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "Please type something so I can help you.";

            string clean = input.ToLower().Trim();
            SaveMemory(clean);

            // ================= NLP: TASK INTENT =================
            if (clean.Contains("add task") ||
                clean.Contains("add a task") ||
                clean.Contains("create task") ||
                clean.Contains("create a task") ||
                clean.Contains("new task"))
            {
                string taskName = ExtractTaskName(input);
                if (!string.IsNullOrWhiteSpace(taskName))
                {
                    taskManager.AddTask(taskName);
                    return $"✅ Task added: \"{taskName}\". Would you like to set a reminder? Click the 📋 Tasks button to manage it.";
                }
                return "Please use the 📋 Tasks button in the sidebar to add a task with full details.";
            }

            // ================= NLP: REMINDER INTENT =================
            if (clean.Contains("remind me") ||
                clean.Contains("set a reminder") ||
                clean.Contains("set reminder") ||
                clean.Contains("don't let me forget") ||
                clean.Contains("remember to"))
            {
                string taskName = ExtractReminderTask(input);
                if (!string.IsNullOrWhiteSpace(taskName))
                {
                    taskManager.AddTask(taskName);
                    return $"⏰ Reminder noted: \"{taskName}\". Click the 📋 Tasks button to set a specific date for your reminder.";
                }
                return "Click the 📋 Tasks button to set a reminder with a specific date.";
            }

            // ================= NLP: VIEW TASKS INTENT =================
            if (clean.Contains("show tasks") ||
                clean.Contains("view tasks") ||
                clean.Contains("my tasks") ||
                clean.Contains("list tasks") ||
                clean.Contains("what are my tasks"))
            {
                string tasks = taskManager.ViewTasks();
                return "📋 Your current tasks:\n" + tasks + "\nClick the Tasks button to manage them.";
            }

            // ================= NLP: QUIZ INTENT =================
            if (clean.Contains("start quiz") ||
                clean.Contains("play quiz") ||
                clean.Contains("take quiz") ||
                clean.Contains("begin quiz") ||
                clean.Contains("test my knowledge") ||
                clean.Contains("quiz me"))
            {
                return "🎮 Click the Quiz button in the sidebar to start the Cybersecurity Quiz!";
            }

            // ================= NLP: ACTIVITY LOG INTENT =================
            if (clean.Contains("activity log") ||
                clean.Contains("show log") ||
                clean.Contains("what have you done") ||
                clean.Contains("recent actions") ||
                clean.Contains("show history") ||
                clean.Contains("what did you do"))
            {
                return "📜 Click the Activity Log button in the sidebar to see all recent actions!";
            }

            // ================= NLP: PASSWORD INTENT =================
            if (clean.Contains("my password") ||
                clean.Contains("update password") ||
                clean.Contains("change password") ||
                clean.Contains("reset password"))
            {
                taskManager.AddTask("Update my password");
                return "🔐 Good thinking! I've added 'Update my password' to your tasks. Use a strong password with letters, numbers and symbols!";
            }

            // ================= NLP: 2FA INTENT =================
            if (clean.Contains("enable 2fa") ||
                clean.Contains("set up 2fa") ||
                clean.Contains("two factor") ||
                clean.Contains("two-factor"))
            {
                taskManager.AddTask("Enable two-factor authentication");
                return "🔑 Great idea! I've added 'Enable two-factor authentication' to your tasks. 2FA adds a second layer of security to your accounts!";
            }

            // ================= SMALL TALK =================
            if (IsThanks(clean))
                return thanksResponses[rand.Next(thanksResponses.Length)];

            if (IsAcknowledgement(clean))
                return ackResponses[rand.Next(ackResponses.Length)];

            // ================= YES / NO FLOW =================
            if (awaitingEndDecision)
            {
                if (IsYes(clean))
                {
                    awaitingEndDecision = false;
                    return GetGoodbyeMessage();
                }
                if (IsNo(clean))
                {
                    awaitingEndDecision = false;
                    return "No problem 👍 What would you like to know next about cybersecurity?";
                }
            }

            string intent = DetectIntent(clean);
            string sentiment = DetectSentiment(clean);

            // ================= NAME =================
            if (intent == "ask_name")
            {
                return string.IsNullOrEmpty(UserName)
                    ? "I don't know your name yet — tell me by saying 'my name is ...'"
                    : $"Your name is {UserName}.";
            }

            // ================= STORE NAME =================
            if (clean.StartsWith("my name is"))
            {
                UserName = input.Substring(11).Trim();
                return $"Nice to meet you, {UserName}! I'll remember your name.";
            }

            // ================= INTEREST =================
            if (clean.Contains("interested in") || clean.Contains("i like"))
            {
                favouriteTopic = ExtractInterest(input);
                return $"Got it! I'll remember that you're interested in {favouriteTopic}.";
            }

            // ================= MEMORY =================
            if (clean.Contains("what do you remember") || clean.Contains("remember me"))
            {
                return BuildMemorySummary();
            }

            // ================= FOLLOW UPS =================
            if (IsFollowUp(clean))
                return HandleFollowUp();

            // ================= KNOWLEDGE BASE =================
            string response = dictionary.FindResponse(clean);

            if (string.IsNullOrEmpty(response))
                response = fallbackResponses[rand.Next(fallbackResponses.Length)];

            response = ApplyContext(response);
            response = ApplySentiment(sentiment, response);
            response = AddPersonality(response);

            // ================= END QUESTION =================
            if (!awaitingEndDecision)
            {
                awaitingEndDecision = true;
                response += "\n\nIs that all you would like to know? (yes/no)";
            }

            return response;
        }

        // ================= NLP HELPERS =================
        private string ExtractTaskName(string input)
        {
            string lower = input.ToLower();
            string[] triggers = { "add task", "add a task", "create task", "create a task", "new task" };

            foreach (string trigger in triggers)
            {
                int idx = lower.IndexOf(trigger);
                if (idx >= 0)
                {
                    string after = input.Substring(idx + trigger.Length).Trim();
                    after = Regex.Replace(after, @"^(to|for|:)\s*", "", RegexOptions.IgnoreCase).Trim();
                    if (!string.IsNullOrWhiteSpace(after))
                        return after;
                }
            }
            return "";
        }

        private string ExtractReminderTask(string input)
        {
            string lower = input.ToLower();
            string[] triggers = { "remind me to", "remind me about", "set a reminder to", "remember to", "don't let me forget to" };

            foreach (string trigger in triggers)
            {
                int idx = lower.IndexOf(trigger);
                if (idx >= 0)
                {
                    string after = input.Substring(idx + trigger.Length).Trim();
                    // Remove time references like "tomorrow", "in 3 days"
                    after = Regex.Replace(after, @"\b(tomorrow|tonight|today|in \d+ days?|next week)\b", "", RegexOptions.IgnoreCase).Trim();
                    if (!string.IsNullOrWhiteSpace(after))
                        return after;
                }
            }
            return "";
        }

        // ================= SMALL TALK CHECKS =================
        private bool IsThanks(string input)
        {
            return input.Contains("thanks") ||
                   input.Contains("thank you") ||
                   input.Contains("thx");
        }

        private bool IsAcknowledgement(string input)
        {
            return input == "ok" || input == "okay" || input == "k" ||
                   input == "cool" || input == "alright" ||
                   input == "got it" || input == "okey";
        }

        // ================= YES / NO =================
        private bool IsYes(string input)
        {
            return input == "yes" || input == "y" || input == "yeah" ||
                   input == "yep" || input == "sure" || input == "correct";
        }

        private bool IsNo(string input)
        {
            return input == "no" || input == "n" || input == "nope" ||
                   input == "nah" || input == "not yet";
        }

        private string GetGoodbyeMessage()
        {
            string[] tips =
            {
                "Always use strong passwords 🔐",
                "Never click suspicious links ⚠️",
                "Enable two-factor authentication 🔑",
                "Keep your software updated 🛡️"
            };
            return "Goodbye 👋 Stay safe online!\nTip: " + tips[rand.Next(tips.Length)];
        }

        // ================= INTENT =================
        private string DetectIntent(string input)
        {
            if (input.Contains("what is my name") || input.Contains("do you know my name"))
                return "ask_name";
            return "general";
        }

        // ================= MEMORY =================
        private void SaveMemory(string input)
        {
            memory.Add(input);
            if (memory.Count > 30)
                memory.RemoveAt(0);
        }

        private string BuildMemorySummary()
        {
            return $"Name: {UserName ?? "not set"}\nInterest: {favouriteTopic ?? "not set"}\nMessages: {memory.Count}";
        }

        // ================= CONTEXT =================
        private string ApplyContext(string response)
        {
            if (!string.IsNullOrEmpty(UserName))
                response = $"Hey {UserName}, {response}";
            return response;
        }

        // ================= SENTIMENT =================
        private string DetectSentiment(string input)
        {
            if (input.Contains("worried") || input.Contains("scared"))
                return "worried";
            if (input.Contains("frustrated") || input.Contains("angry"))
                return "frustrated";
            if (input.Contains("how") || input.Contains("why"))
                return "curious";
            return "neutral";
        }

        private string ApplySentiment(string sentiment, string response)
        {
            if (sentiment == "worried")
                return "I understand — cybersecurity can feel overwhelming. " + response;
            if (sentiment == "frustrated")
                return "I get why that's frustrating. " + response;
            if (sentiment == "curious")
                return "Great question! " + response;
            return response;
        }

        // ================= FOLLOW UPS =================
        private bool IsFollowUp(string input)
        {
            return input.Contains("tell me more") ||
                   input.Contains("another tip") ||
                   input.Contains("more info");
        }

        private string HandleFollowUp()
        {
            string[] tips =
            {
                "Use strong passwords.",
                "Enable 2FA.",
                "Avoid unknown links.",
                "Keep software updated."
            };
            return tips[rand.Next(tips.Length)];
        }

        // ================= PERSONALITY =================
        private string AddPersonality(string response)
        {
            string[] starters =
            {
                "Quick tip: ",
                "Here's something useful: ",
                "Let me explain: ",
                "Good question! "
            };
            return starters[rand.Next(starters.Length)] + response;
        }

        private string ExtractInterest(string input)
        {
            int index = input.ToLower().IndexOf("interested in");
            if (index >= 0)
                return input.Substring(index + 14).Trim();
            return input;
        }
    }
}