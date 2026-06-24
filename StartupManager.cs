using System;
using System.Speech.Synthesis;
using static System.Console;

namespace CyberSecurityChatbot
{
    internal class StartupManager
    {
        // ===== UI =====
        private void Divider(char symbol = '=', int length = 80)
        {
            ForegroundColor = ConsoleColor.DarkCyan;
            WriteLine(new string(symbol, length));
            ResetColor();
        }

        public void Start()
        {
            SpeechSynthesizer voice = new SpeechSynthesizer();
            ChatBotEngine engine = new ChatBotEngine();

            Divider();

            ConsoleHelper.TypeAndSpeak(
                "Welcome to the Cybersecurity Awareness Bot",
                voice,
                color: ConsoleColor.Cyan
            );

            Divider();

            ConsoleHelper.TypeAndSpeak(
                "What is your name?",
                voice,
                color: ConsoleColor.Green
            );

            string name = ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                ConsoleHelper.TypeAndSpeak(
                    "Please enter a valid name.",
                    voice,
                    color: ConsoleColor.Red
                );
                name = ReadLine();
            }

            engine.UserName = name;

            Divider();

            ConsoleHelper.TypeAndSpeak(
                $"Hello {name}, I'm here to help you stay safe online.",
                voice,
                color: ConsoleColor.Cyan
            );

            Divider();

            bool firstQuestion = true;

            while (true)
            {
                if (firstQuestion)
                {
                    ConsoleHelper.TypeAndSpeak(
                        $"{name}, ask me anything about cybersecurity or type 'exit' to leave:",
                        voice,
                        color: ConsoleColor.Green
                    );
                }
                else
                {
                    ConsoleHelper.TypeAndSpeak(
                        $"{name}, what would you like to know next?",
                        voice,
                        color: ConsoleColor.Green
                    );
                }

                string userInput = ReadLine();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    ConsoleHelper.TypeAndSpeak(
                        "I didn’t quite understand that. Please rephrase.",
                        voice,
                        color: ConsoleColor.Yellow
                    );
                    continue;
                }

                if (userInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    ConsoleHelper.Goodbye("Goodbye! Stay safe online.", voice);
                    break;
                }

                // 🚀 EVERYTHING now handled by engine
                string response = engine.ProcessMessage(userInput);

                ConsoleHelper.TypeAndSpeak(
                    response,
                    voice,
                    color: ConsoleColor.Cyan
                );

                Divider();

                firstQuestion = false;
            }
        }
    }
}