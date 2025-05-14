using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Threading;

namespace ChatbotApp

{
    class Program

    {

        static string userName = "";
        static string favouriteTopic = ""
        static Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();
        static List<string> phishingTips = new List<string>

        {
            "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organisations.",
            "Always check the sender's email address before clicking links.",
            "Avoid downloading attachments from unknown sources."
        };


        static void Main(string[] args)
        {
            // Play the voice greeting 
            PlayVoiceGreeting();


            // Display ASCII art 
            DisplayAsciiLogo();


            // Ask for user's name 
            Console.Write("What is your name? ");
            userName = Console.ReadLine();
            if (string.IsNullOrEmpty(userName))
            {
                Console.WriteLine("You didn't enter a name. Please try again.");
                return;
            }

            Console.WriteLine($"Hello, {userName}! Welcome to the Cybersecurity Awareness Bot!");


            TypeText("I am here to help you stay safe online by providing some cybersecurity tips...");

            // Initialize keyword actions 
            InitialiseKeywordActions();


            // Start chat 
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
            keywordActions["password"] = () =>
                Console.WriteLine("Make sure to use strong, unique passwords for each account. Avoid using personal details in your passwords.");


            keywordActions["scam"] = () =>
                Console.WriteLine("Watch out for online scams. Always verify the source before clicking any links or providing personal info.");


            keywordActions["privacy"] = () =>
            {
                Console.WriteLine("Protect your privacy by limiting the personal info you share online and reviewing your account settings.");
                favouriteTopic = "privacy";
                Console.WriteLine("Great! I'll remember that you're interested in privacy.");
            };


            keywordActions["phishing"] = () =>
            {
                Random rnd = new Random();
                string tip = phishingTips[rnd.Next(phishingTips.Count)];
                Console.WriteLine(tip);
            };
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
                    HandleDefaultQueries(input);
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



        static void HandleDefaultQueries(string input)

        {
            if (input.Contains("how are you"))

            {
                Console.WriteLine("I'm just a bunch of code, but I'm doing well! Thanks for asking.");
            }

            else if (input.Contains("your purpose"))
            {
                Console.WriteLine("My purpose is to help you stay safe online by sharing cybersecurity tips.");
            }

            else if (input.Contains("what can i ask"))

            {
                Console.WriteLine("You can ask about passwords, phishing, scams, privacy, and staying safe online.");
            }

            else

            {
                Console.WriteLine("I'm not sure I understand. Can you try rephrasing?");
            }
        }
    }
}

