using System;
using System.Collections.Generic;
using System.Speech.Synthesis;
using System.Threading;

namespace ChatbotApp
{
    class Program
    {
        static string userName = "";
        static string favouriteTopic = "";
        static Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();

        static List<string> phishingTips = new List<string>
        {
            "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organisations.",
            "Always check the sender's email address before clicking links.",
            "Avoid downloading attachments from unknown sources."
        };

        static void Main(string[] args)
        {
            PlayVoiceGreeting();
            DisplayAsciiLogo();

            Console.Write("What is your name? ");
            userName = Console.ReadLine();
            if (string.IsNullOrEmpty(userName))
            {
                Console.WriteLine("You didn't enter a name. Please try again.");
                return;
            }

            Console.WriteLine($"Hello, {userName}! Welcome to the Cybersecurity Awareness Bot!");
            TypeText("I am here to help you stay safe online by providing some cybersecurity tips...");

            InitialiseKeywordActions();
            ChatLoop();
        }

        static void PlayVoiceGreeting()
        {
            try
            {
                SpeechSynthesizer synth = new SpeechSynthesizer();
                Console.WriteLine("Welcome to the Cybersecurity Awareness chatbot!");
                synth.Speak("Welcome to the Cybersecurity Awareness chatbot! Ask me anything about online safety.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error playing the voice greeting: " + ex.Message);
            }
        }

        static void DisplayAsciiLogo()
        {
            Console.WriteLine(@"
ʕ•ᴥ•ʔ
");
        }

        static void TypeText(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(30);
            }
            Console.WriteLine();
        }

        static void InitialiseKeywordActions()
        {
            Random rnd = new Random();

            List<string> passwordResponses = new List<string>
            {
                "Use a mix of letters, numbers, and symbols for a strong password.",
                "Never reuse passwords across different accounts.",
                "Avoid using personal information like your birthday in your password."
            };

            keywordActions["password"] = () =>
            {
                string response = passwordResponses[rnd.Next(passwordResponses.Count)];
                Console.WriteLine(response);
            };

            List<string> scamResponses = new List<string>
            {
                "Scammers often pretend to be from trusted organizations—always double-check.",
                "If something seems too good to be true, it probably is.",
                "Never give out personal info over unsolicited emails or phone calls."
            };

            keywordActions["scam"] = () =>
            {
                string response = scamResponses[rnd.Next(scamResponses.Count)];
                Console.WriteLine(response);
            };

            List<string> privacyResponses = new List<string>
            {
                "Regularly check your social media privacy settings.",
                "Only share personal information on secure, trusted websites.",
                "Avoid oversharing sensitive details online."
            };

            keywordActions["privacy"] = () =>
            {
                string response = privacyResponses[rnd.Next(privacyResponses.Count)];
                Console.WriteLine(response);
                favouriteTopic = "privacy";
                Console.WriteLine("Great! I'll remember that you're interested in privacy.");
            };

            keywordActions["phishing"] = () =>
            {
                string tip = phishingTips[rnd.Next(phishingTips.Count)];
                Console.WriteLine(tip);
            };

            keywordActions["how are you"] = () =>
                Console.WriteLine("I'm just a bunch of code, but I'm doing great! Thanks for asking.");

            keywordActions["your purpose"] = () =>
                Console.WriteLine("My purpose is to help you stay safe online by sharing cybersecurity tips.");

            keywordActions["what can i ask"] = () =>
                Console.WriteLine("You can ask about passwords, phishing, scams, privacy, and staying safe online.");
        }

        static void ChatLoop()
        {
            Console.WriteLine("Ask me anything about cybersecurity. Type 'exit' to quit.");
            while (true)
            {
                Console.Write("> ");
                string input = Console.ReadLine()?.ToLower();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("I didn’t catch that. Can you say it again?");
                    continue;
                }

                if (input == "exit") break;

                if (DetectSentiment(input)) continue;

                bool found = false;
                foreach (var keyword in keywordActions.Keys)
                {
                    if (input.Contains(keyword))
                    {
                        keywordActions[keyword].Invoke();
                        if (!string.IsNullOrEmpty(favouriteTopic))
                        {
                            Console.WriteLine($"As someone interested in {favouriteTopic}, this is especially useful.");
                        }
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("I'm not sure I understand. Can you try rephrasing?");
                }
            }
        }

        static bool DetectSentiment(string input)
        {
            if (input.Contains("worried") || input.Contains("scared"))
            {
                Console.WriteLine("It's completely understandable to feel that way. Cyber threats can be intimidating, but I'm here to help.");
                return true;
            }
            else if (input.Contains("frustrated") || input.Contains("confused"))
            {
                Console.WriteLine("No worries! Cybersecurity can be complex. Let me explain things more simply.");
                return true;
            }
            else if (input.Contains("curious") || input.Contains("interested"))
            {
                Console.WriteLine("Curiosity is great! Let's explore some cybersecurity topics together.");
                return true;
            }
            return false;
        }
    }
}


