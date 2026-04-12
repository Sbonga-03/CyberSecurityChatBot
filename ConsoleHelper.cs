using System;
using System.Speech.Synthesis;
using System.Threading;

namespace CyberSecurityChatbot
{
    internal static class ConsoleHelper
    {
        public static void TypeAndSpeak(string message, SpeechSynthesizer voice, int delay = 5, ConsoleColor color = ConsoleColor.Cyan, bool speak = true)
        {
            Console.ForegroundColor = color;

            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }

            Console.WriteLine();

            if (speak)
            {
                voice.Speak(message);
            }

            Console.ResetColor();
        }

        public static void Divider(char symbol = '=', int length = 60)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(new string(symbol, length));
            Console.ResetColor();
        }

        public static void Header(string title)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Divider();
            Console.WriteLine($"   {title.ToUpper()}");
            Divider();
            Console.ResetColor();
        }

        public static void TypeText(string text, int delay = 20)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }


        // LEVEL 2: typing animation (no speech, used for smoother chat feel)
        public static void TypeMessage(string message, ConsoleColor color = ConsoleColor.Cyan, int delay = 12)
        {
            Console.ForegroundColor = color;

            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }

            Console.WriteLine();
            Console.ResetColor();
        }

        public static void BotLine(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Bot: {message}");
            Console.ResetColor();
        }

        public static void UserLine(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You: {message}");
            Console.ResetColor();
        }

        public static void Goodbye(string message, SpeechSynthesizer voice)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Bot: {message}");
            voice.Speak(message);
            Console.ResetColor();
        }
    }
}