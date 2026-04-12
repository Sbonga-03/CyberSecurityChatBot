using System;
using System.Speech.Synthesis;
using static System.Console;

namespace CyberSecurityChatbot
{
    internal class StartupManager
    {
        // ===== UI HELPERS =====
        private void Divider(char symbol = '=', int length = 80)
        {
            ForegroundColor = ConsoleColor.DarkCyan;
            WriteLine(new string(symbol, length));
            ResetColor();
        }

        private void Header(string title)
        {
            ForegroundColor = ConsoleColor.Cyan;
            Divider();
            WriteLine($"   {title.ToUpper()}");
            Divider();
            ResetColor();
        }

        // ===== RESPONSE PERSONALITY =====
        private string AddPersonality(string reply)
        {
            string[] starters =
            {
                "Good question! ",
                "That’s a great topic — ",
                "Here’s something important: ",
                "Let me explain that simply: "
            };

            return starters[new Random().Next(starters.Length)] + reply;
        }

        // ===== NO / NOTHING HANDLER =====
        private bool HandleNoIntent(string input, SpeechSynthesizer voice)
        {
            string lower = input.ToLower().Trim();

            string[] noInputs =
            {
                "no", "nope", "nah", "nothing", "none",
                "not really", "im good", "i'm good", "i am good",
                "all good", "im fine", "i'm fine", "i am fine",
                "no thanks", "nothing else", "thats all", "that's all",
                "im done", "i'm done", "i am done",
                "no more", "no questions"
            };

            foreach (string phrase in noInputs)
            {
                if (lower.Contains(phrase))
                {
                    string[] responses =
                    {
                        "Alright! If you think of anything else, feel free to ask.",
                        "No problem, I'm here whenever you're ready.",
                        "Got it. Just ask if you need anything else.",
                        "Okay, let me know if something comes up.",
                        "All good! Stay safe online."
                    };

                    string reply = responses[new Random().Next(responses.Length)];

                    ConsoleHelper.TypeAndSpeak(reply, voice, color: ConsoleColor.Cyan);

                    // ⭐ NEW ENGAGEMENT LINE (THIS FIXES YOUR ISSUE)
                    ConsoleHelper.TypeAndSpeak(
                        "You can type another question or type 'exit' to leave.",
                        voice,
                        color: ConsoleColor.DarkCyan
                    );

                    Divider();
                    return true;
                }
            }

            return false;
        }

        public void Start()
        {
            SpeechSynthesizer voice = new SpeechSynthesizer();

         

            // ===== ASCII =====
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("   █████████             █████                        ███████████            █████   \r\n  ███░░░░░███           ░░███                        ░░███░░░░░███          ░░███    \r\n ███     ░░░  █████ ████ ░███████   ██████  ████████  ░███    ░███  ██████  ███████  \r\n░███         ░░███ ░███  ░███░░███ ███░░███░░███░░███ ░██████████  ███░░███░░░███░   \r\n░███          ░███ ░███  ░███ ░███░███████  ░███ ░░░  ░███░░░░░███░███ ░███  ░███    \r\n░░███     ███ ░███ ░███  ░███ ░███░███░░░   ░███      ░███    ░███░███ ░███  ░███ ███\r\n ░░█████████  ░░███████  ████████ ░░██████  █████     ███████████ ░░██████   ░░█████ \r\n  ░░░░░░░░░    ░░░░░███ ░░░░░░░░   ░░░░░░  ░░░░░     ░░░░░░░░░░░   ░░░░░░     ░░░░░  \r\n               ███ ░███                                                              \r\n              ░░██████                                                               \r\n               ░░░░░░                                                                ");
            ResetColor();

            Divider();

            ConsoleHelper.TypeAndSpeak("Welcome to the Cybersecurity Awareness Bot", voice, color: ConsoleColor.Cyan);
            Divider();

            ConsoleHelper.TypeAndSpeak("What is your name?", voice, color: ConsoleColor.Green);
            string name = ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                ConsoleHelper.TypeAndSpeak("Please enter a valid name.", voice, color: ConsoleColor.Red);
                name = ReadLine();
            }

            WriteLine(new string('-', 80));

            ConsoleHelper.TypeAndSpeak($"Hello {name}, I'm here to help you stay safe online.", voice, color: ConsoleColor.Cyan);

            Divider();

            CyberDictionary cyberDict = new CyberDictionary();
            bool firstQuestion = true;

            // ⭐ FIX ADDED: prevents instant re-prompt after "no/nothing"
            bool skipNextPrompt = false;

            while (true)
            {
                // ===== PROMPT CONTROL FIX =====
                if (skipNextPrompt)
                {
                    skipNextPrompt = false;
                }
                else if (firstQuestion)
                {
                    ConsoleHelper.TypeAndSpeak($"{name}, ask me anything about cybersecurity or type 'exit' to leave:", voice, color: ConsoleColor.Green);
                }
                else
                {
                    ConsoleHelper.TypeAndSpeak($"{name}, what would you like to know next?", voice, color: ConsoleColor.Green);
                }

                string userInput = ReadLine();
                WriteLine();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    ConsoleHelper.TypeAndSpeak("I didn’t quite understand that. Please rephrase.", voice, color: ConsoleColor.Yellow);
                    continue;
                }

                if (userInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    ConsoleHelper.Goodbye("Goodbye! Stay safe online.", voice);
                    break;
                }

                // ⭐ FIXED FLOW HANDLING
                if (HandleNoIntent(userInput, voice))
                {
                    firstQuestion = false;
                    skipNextPrompt = true;
                    continue;
                }

                firstQuestion = false;

                string reply = cyberDict.FindResponse(userInput);

                if (!string.IsNullOrEmpty(reply))
                {
                    string finalReply = AddPersonality(reply);
                    ConsoleHelper.TypeAndSpeak(finalReply, voice, color: ConsoleColor.Cyan);
                }
                else
                {
                    ConsoleHelper.TypeAndSpeak(
                        "I didn’t quite understand that. Try asking about phishing, passwords, malware, or safe browsing.",
                        voice,
                        color: ConsoleColor.Yellow
                    );
                }

                Divider();
            }
        }
    }
}