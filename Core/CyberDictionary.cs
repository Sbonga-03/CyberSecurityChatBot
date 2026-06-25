using System;
using System.Collections.Generic;
using System.Linq;

namespace CyberSecurityChatbot
{
    internal class CyberDictionary
    {
        // Maps keywords and synonyms to their responses
        public Dictionary<string, string> Keywords { get; private set; }

        public CyberDictionary()
        {
            Keywords = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                // --- Core concepts ---
                {"cybersecurity", "Cybersecurity is the practice of protecting computers, networks, and data from attacks, damage, or unauthorized access."},
                {"Information security", "Information security focuses on protecting the confidentiality, integrity, and availability of data."},
                {"info security", "Information security focuses on protecting the confidentiality, integrity, and availability of data."},
                {"network security", "Network security protects networks and data by preventing unauthorized access, misuse, or theft."},
                {"endpoint security", "Endpoint security protects devices like laptops, smartphones, and tablets against cyber threats."},

                // --- Malware and attacks ---
                {"malware", "Malware is malicious software designed to harm devices or steal data, including viruses, worms, trojans, and ransomware."},
                {"virus", "A virus attaches to files and spreads when files are shared, often corrupting data."},
                {"trojan", "A Trojan is malware disguised as legitimate software to trick users into installing it."},
                {"trojan horse", "A Trojan is malware disguised as legitimate software to trick users into installing it."},
                {"worm", "A worm is malware that spreads automatically across networks without user interaction."},
                {"ransomware", "Ransomware locks files or systems and demands payment to regain access."},
                {"spyware", "Spyware secretly monitors user activity and collects personal data without consent."},
                {"keylogger", "A keylogger records keystrokes to steal passwords, credit card info, and sensitive data."},
                {"rootkit", "A rootkit hides malware deep in the system to avoid detection and gain unauthorized access."},
                {"adware", "Adware displays unwanted advertisements, sometimes tracking user behavior."},
                {"phishing", "Phishing involves fake emails, messages, or websites to trick users into revealing sensitive info."},
                {"social engineering", "Social engineering manipulates humans into revealing confidential information or performing unsafe actions."},
                {"man in the middle", "A MITM attack intercepts communication between two parties to steal or alter data."},
                {"mitm", "A MITM attack intercepts communication between two parties to steal or alter data."},
                {"dos", "A DoS attack overwhelms a network or system, making it unavailable to users."},
                {"denial of service", "A DoS attack overwhelms a network or system, making it unavailable to users."},
                {"ddos", "A DDoS attack uses multiple sources to flood a network or website with traffic."},
                {"sql injection", "SQL injection exploits vulnerabilities in a website's database to gain unauthorized access."},
                {"zero day", "A zero-day exploit attacks a software vulnerability before a patch is available."},

                // --- Protection measures ---
                {"firewall", "A firewall controls network traffic based on security rules to block unauthorized access."},
                {"antivirus", "Antivirus software detects, quarantines, and removes malicious programs from your system."},
                {"ids", "IDS monitors network traffic for suspicious activity and potential attacks."},
                {"intrusion detection system", "IDS monitors network traffic for suspicious activity and potential attacks."},
                {"ips", "IPS detects and prevents identified threats in real-time."},
                {"intrusion prevention system", "IPS detects and prevents identified threats in real-time."},
                {"vpn", "A VPN encrypts your internet connection, protecting data and privacy over public networks."},
                {"encryption", "Encryption converts data into a secure format that only authorized users can read."},
                {"two factor authentication", "2FA adds a second layer of security requiring a code or biometric check in addition to a password."},
                {"2fa", "2FA adds a second layer of security requiring a code or biometric check in addition to a password."},
                {"strong password", "Use complex passwords with letters, numbers, and symbols, unique for every account."},
                {"password manager", "A password manager securely stores and generates complex passwords."},
                {"secure coding", "Writing software following security best practices to prevent vulnerabilities."},

                // --- Safe practices ---
                {"safe browsing", "Use HTTPS websites, avoid suspicious downloads, and keep your browser updated."},
                {"email safety", "Never click on links or attachments from unknown senders; verify URLs before clicking."},
                {"data backup", "Regularly back up important files to prevent loss from malware or hardware failure."},
                {"updates", "Keep your OS, software, and antivirus up to date to patch vulnerabilities."},
                {"cyber hygiene", "Cyber hygiene includes safe habits like strong passwords, regular updates, and careful link clicking."},
                {"public wifi safety", "Avoid accessing sensitive information over unsecured public Wi-Fi networks without a VPN."},
                {"mobile security", "Use screen locks, app permissions carefully, and antivirus on mobile devices."},

                // --- Privacy and compliance ---
                {"privacy", "Protect personal information online, including on social media and shopping sites."},
                {"gdpr", "The General Data Protection Regulation protects personal data in the EU and affects businesses globally."},
                {"iso 27001", "ISO 27001 is an international standard for managing information security."},
                {"nist", "NIST provides cybersecurity frameworks and best practices for organizations."},
                {"hipaa", "HIPAA is a US law protecting sensitive health information."},
                {"ccpa", "The California Consumer Privacy Act gives consumers control over their personal data."},

                // --- Advanced concepts ---
                {"hashing", "Hashing is the process of converting data into a fixed-length string for security purposes."},
                {"sha256", "SHA-256 is a secure cryptographic hashing algorithm used to protect data integrity."},
                {"md5", "MD5 is an older hashing algorithm that is now considered insecure for most security uses."},
                {"ssl", "SSL is a protocol that encrypts communication between a browser and a server."},
                {"tls", "TLS is the modern version of SSL used to secure internet communications."},
                {"digital signature", "A digital signature verifies the authenticity and integrity of digital messages or documents."},
                {"public key cryptography", "Public key cryptography uses a pair of keys (public and private) to secure communication."},
                {"private key", "A private key is used to decrypt data that was encrypted with a matching public key."},
                {"zero trust", "Zero Trust is a security model that assumes no user or system is trusted by default."},

                // --- Attack types (advanced) ---
                {"brute force", "A brute force attack tries many password combinations until the correct one is found."},
                {"dictionary attack", "A dictionary attack uses common words and password lists to guess login credentials."},
                {"credential stuffing", "Credential stuffing uses stolen login details from one site to access other accounts."},
                {"cross site scripting", "Cross-site scripting (XSS) injects malicious scripts into websites viewed by other users."},
                {"xss", "Cross-site scripting (XSS) injects malicious scripts into websites viewed by other users."},
                {"spear phishing", "Spear phishing targets specific individuals with highly personalized fake messages."},
                {"whaling", "Whaling attacks target high-profile individuals like executives or managers."},
                {"botnet", "A botnet is a group of infected computers controlled by attackers."},

                // --- Identity & authentication ---
                {"biometrics", "Biometrics uses physical traits like fingerprints or facial recognition for authentication."},
                {"authentication", "Authentication verifies the identity of a user before granting access."},
                {"authorization", "Authorization determines what resources a user is allowed to access."},

                // --- Modern cybersecurity concepts ---
                {"cloud security", "Cloud security protects data and systems stored in cloud environments."},
                {"data breach", "A data breach occurs when sensitive information is accessed without permission."},
                {"vulnerability", "A vulnerability is a weakness in a system that can be exploited by attackers."},
                {"patch management", "Patch management is the process of updating software to fix security vulnerabilities."},
                {"incident response", "Incident response is how organizations detect and respond to cyberattacks."}
            };
        }

        // --- Fuzzy search to handle typos ---
        public string FindResponse(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
                return null;

            // Exact match first
            foreach (var key in Keywords.Keys)
            {
                if (userInput.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0)
                    return Keywords[key];
            }

            // Fuzzy match using Levenshtein distance (allow distance <= 2)
            string closestKey = null;
            int closestDistance = int.MaxValue;

            foreach (var key in Keywords.Keys)
            {
                int distance = LevenshteinDistance(userInput.ToLower(), key.ToLower());
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestKey = key;
                }
            }

            // Consider it a match if typo is small
            if (closestDistance <= 2)
                return Keywords[closestKey];

            // Not found
            return null;
        }

        // --- Levenshtein distance algorithm for fuzzy matching ---
        private int LevenshteinDistance(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            for (int i = 0; i <= n; i++) d[i, 0] = i;
            for (int j = 0; j <= m; j++) d[0, j] = j;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (s[i - 1] == t[j - 1]) ? 0 : 1;
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost
                    );
                }
            }

            return d[n, m];
        }
    }
}