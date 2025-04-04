using System;
using System.Collections.Generic;
using System.Media;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using NAudio.SoundFont;
using System.Speech.Synthesis;
using System.Net.Http.Headers;
namespace ChatbotApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Play the voice greeting
            PlayVoiceGreeting();

            // Display ASCII art (Cybersecurity Awareness Bot logo)
            DisplayAsciiLogo();

            // Greet the user and ask for their name
            Console.Write("What is your name? ");
            string userName = Console.ReadLine();
            if (string.IsNullOrEmpty(userName))
            {
                Console.WriteLine("You didn't enter a name. Please try again.");
                return;
            }
            Console.WriteLine($"Hello, {userName}! Welcome to the Cybersecurity Awareness Bot!");

            // Simulate typing effect and ask user about how they need help
            TypeText("I am here to help you stay safe online by providing some cybersecurity tips...");

            // Respond to basic user queries
            RespondToQueries();

            // Example input validation handling
            InputValidation();
        }

        // Method to play the voice greeting when the chatbot starts
        static void PlayVoiceGreeting()
        {
            try
            {
                SpeechSynthesizer synth = new SpeechSynthesizer();
                Console.WriteLine("Welcome to the Cybersecurity Awareness chatbot!");
                synth.Speak("Welcome to the Cybersecurity Awareness chatbot!, Ask me anything about online safety.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error playing the voice greeting: " + ex.Message);
            }
        }

        // Method to display the ASCII logo or art of the chatbot
        static void DisplayAsciiLogo()
        {
            Console.WriteLine(@"
ʕ•ᴥ•ʔ
");
        }

        // Method to simulate typing effect
        static void TypeText(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(50); // Simulate typing delay
            }
            Console.WriteLine();
        }

        // Method to respond to user queries about the chatbot's purpose
        static void RespondToQueries()
        {
            Console.WriteLine("Ask me anything about cybersecurity. Type 'exit' to quit.");
            string input;
            while ((input = Console.ReadLine().ToLower()) != "exit")
            {
                if (input == "how are you?")
                {
                    Console.WriteLine("I'm doing well, thank you for asking!");
                }
                else if (input == "what's your purpose?")
                {
                    Console.WriteLine("My purpose is to help you stay safe online by providing cybersecurity tips and answering your questions.");
                }
                else if (input == "what can I ask you about?")
                {
                    Console.WriteLine("You can ask me about topics like password safety, phishing, and safe browsing.");
                }
                else if (input == "what is phishing?")
                {
                    Console.WriteLine("Phishing is a kind of internet fraud in which criminals pose as trustworthy organizations in order to fool victims into divulging private information, such as credit card numbers or passwords.");
                }
                else if (input == "how can I create a strong password?")
                {
                    Console.WriteLine("A combination of capital and lowercase letters, digits, and special characters should be included in a strong password.  Don't use information that can be guessed, such as names or dates of birth.");
                }
                else if (input == "what is two-factor authentication?")
                {
                    Console.WriteLine("An additional layer of protection known as two-factor authentication (2FA) requires you to confirm your identity using two distinct means, typically a password and a code that you know (such as a phone number or email address).");
                }
                else if (input == "how do I stay safe on social media?")
                {
                    Console.WriteLine("To stay safe on social media, avoid sharing personal information, be cautious about friend requests, and regularly update your privacy settings to control who sees your posts.");
                }
                else if (input == "what should I do if I receive a suspicious email?")
                {
                    Console.WriteLine("If you receive a suspicious email, don't click on any links or open attachments. Verify the sender's email address and contact the organization directly to confirm the email's legitimacy.");
                }
                else
                {
                    Console.WriteLine("I didn't quite understand that. Could you rephrase?");
                }
            }
        }


        // Method to handle input validation and guide the user if no valid input is entered
        static void InputValidation()
        {
            Console.Write("Please type a question: ");
            string userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("You didn't enter anything. Please type a valid question.");
            }
            else
            {
                Console.WriteLine("Thank you for your input! Now, how else can I help you?");
            }
        }
    }
}
