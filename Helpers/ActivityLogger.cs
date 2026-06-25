using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityChatbot
{
    public class ActivityLogger
    {
        private List<string> activities = new List<string>();

        public void Log(string action)
        {
            activities.Add(action);
        }

        public List<string> GetLogs()
        {
            return activities;
        }
    }
}
