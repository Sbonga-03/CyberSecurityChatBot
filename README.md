# CyberSecurity Awareness Chatbot 🛡️

## 📌 Overview
This project is a C# Windows Forms GUI-based chatbot designed to educate users about important cybersecurity topics such as phishing, malware, password safety, and safe browsing practices.

The chatbot provides an interactive and user-friendly experience using a modern chat interface, voice, clickable buttons, a task assistant, a quiz game, and an activity log to simulate a real conversation and help users stay safe online.

---

## 🎯 Objectives
- Promote cybersecurity awareness
- Provide quick and simple explanations of key cybersecurity concepts
- Create an engaging and interactive GUI application
- Help users manage cybersecurity tasks with reminders
- Test users' cybersecurity knowledge through a quiz
- Demonstrate clean code structure and programming concepts

---

## 🚀 Features

### 🔊 Voice Greeting
- Uses `SpeechSynthesizer` to greet the user when the application starts

### 🎨 ASCII Art Logo
- Displays a cybersecurity-themed ASCII banner in the sidebar

### 👤 Personalized Interaction
- Asks for the user's name on startup
- Responds using the user's name throughout the conversation
- Remembers user interests and previous messages

### 💬 Chatbot Response System
- Answers questions about:
  - Malware, Phishing, Ransomware
  - Password safety and management
  - Firewalls, VPNs, Encryption
  - Safe browsing and email safety
  - Two-factor authentication (2FA)
  - Social engineering and more
- Uses keyword matching and fuzzy search (Levenshtein distance)
- Detects user sentiment (worried, frustrated, curious)
- NLP simulation recognises varied phrasings

### 🧠 NLP Simulation
- Recognises different ways users phrase requests:
  - "add a task to enable 2FA" → adds task automatically
  - "remind me to update my password" → creates reminder task
  - "quiz me" → directs user to quiz
  - "show activity log" → opens activity log
  - "enable 2FA" → auto-creates task and explains 2FA

### 📋 Task Assistant
- Add cybersecurity tasks with title, description and reminder date
- View all tasks in a structured list
- Mark tasks as completed
- Delete tasks
- All tasks stored persistently in a **MySQL database**

### 🎮 Cybersecurity Quiz
- 12 cybersecurity questions (multiple choice and true/false)
- Topics: phishing, passwords, safe browsing, social engineering, malware
- Shows one question at a time
- Provides correct/incorrect feedback with explanation after each answer
- Tracks score and shows final result with personalized feedback
- Restart quiz option at the end

### 📜 Activity Log
- Records all chatbot actions with timestamps
- Logs: tasks added, tasks completed, tasks deleted, quiz started/completed, chat interactions
- View log via sidebar button or by typing "show activity log" in chat
- Shows most recent actions first

### 💡 Quick Action Buttons
- After entering name, chat shows WhatsApp-style clickable buttons:
  - 📋 Manage My Tasks
  - 🎮 Take the Quiz
  - 📜 View Activity Log
  - 🔐 Ask About Passwords
  - 🛡️ Ask About Phishing
  - 🔑 Enable 2FA

### ⚠️ Input Validation
- Handles empty input
- Unknown questions trigger helpful fallback messages
- Sentiment-aware responses

---

## 🗄️ Database Setup (MySQL)

1. Install **MySQL Community Server** from https://dev.mysql.com/downloads/installer/
2. Open **MySQL Workbench** and connect to your local instance
3. Run the following SQL:

```sql
CREATE DATABASE CyberBotDB;
USE CyberBotDB;
CREATE TABLE Tasks (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    Description TEXT,
    ReminderDate DATE,
    IsCompleted BOOLEAN DEFAULT FALSE
);
```

4. In `DatabaseHelper.cs` update the connection string with your MySQL password:
```csharp
private string connectionString = "Server=localhost;Port=3306;Database=CyberBotDB;Uid=root;Pwd=YOUR_PASSWORD_HERE;";
```

---

## 🧱 Code Structure                                                                              
---

## 🛠️ Technologies Used
- C# (.NET Framework)
- Windows Forms (WinForms)
- MySQL with `MySql.Data` NuGet package
- `System.Speech.Synthesis` for voice
- `System.Text.RegularExpressions` for NLP
- Levenshtein Distance Algorithm for fuzzy keyword matching

---

## ▶️ How to Run

1. Install **MySQL Community Server** and set up the database (see Database Setup above)
2. Install **MySql.Data** NuGet package in Visual Studio
3. Open the project in **Visual Studio**
4. Update your MySQL password in `DatabaseHelper.cs`
5. Build the solution (**Ctrl+Shift+B**)
6. Run the program (**F5**)
7. Enter your name and start chatting!

---

## 🧑‍💻 Author
**Sbongokuhle Mpungose**
ST10482847
Rosebank College

---

## 📄 License
This project is for educational purposes and Rosebank College use only.
