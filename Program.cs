using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using static System.Console;

namespace CyberSecurityChatbot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartupManager startup = new StartupManager();
            startup.Start(); // Calls all the chatbot logic
        }
    }
}
