using System;
using System.Collections.Generic;

namespace CyberSecurityChatbot.Core
{
    internal class QuizManager
    {
        public int Score { get; private set; } = 0;
        public int TotalQuestions { get; private set; } = 0;

        public void RecordAnswer(bool isCorrect)
        {
            TotalQuestions++;
            if (isCorrect)
                Score++;
        }

        public void Reset()
        {
            Score = 0;
            TotalQuestions = 0;
        }

        public string GetFeedback()
        {
            if (TotalQuestions == 0)
                return "No quiz taken yet.";

            double percentage = (double)Score / TotalQuestions * 100;

            if (percentage >= 80)
                return "🏆 Outstanding! You're a cybersecurity pro!";
            else if (percentage >= 60)
                return "👍 Great job! You know your cybersecurity!";
            else if (percentage >= 40)
                return "📚 Not bad! Keep learning to stay safe online!";
            else
                return "⚠️ Keep studying! Cybersecurity knowledge is important!";
        }
    }
}