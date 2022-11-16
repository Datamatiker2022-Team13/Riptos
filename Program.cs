using System.Runtime.CompilerServices;

namespace Riptos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartProgram(); //kalder metoden start program
           
        }
        private static void StartProgram()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Riptos startet");
            Console.WriteLine("enter pasword");
            string? input = Console.ReadLine();
            if (input != null && input.Equals("123"))
            {
                ShowMenu();// lav exception handling
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Adgangskode forkert. Prøv igen");
                StartProgram();
            }
        }

        private static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Du er nu logget ind i Bruger menuen");
            Console.WriteLine("1: Almindelig henvendelse \n2: Anonym henvendelse ");
            string? inputMenu = Console.ReadLine();
            if (inputMenu != null)
            {
                var selectedMenu = InputHandler.GetUserInputInt(inputMenu); //sender inputmenu til inputhandler, modtager en Int fra Inputhandler som kaldet selectedMenu
                switch (selectedMenu)
                {
                    case 1:
                        CommonMessage(); //her kaldes en metode CommonMessage()
                        break;
                    case 2:
                        AnonMessage();
                        break;
                    default:
                        ErrorMessage();
                        ShowMenu();
                        break;
                }

            }
        }
        private static void AnonMessage()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Du har valgt en Anonym Henvendelse");
            Console.WriteLine("Overskrift: \n");
            string? inputTitle = Console.ReadLine();
            if (inputTitle != null)
            {
                inputTitle = InputHandler.GetUserInputString(inputTitle);
                Console.WriteLine("Besked: \n");
                string? inputBody = Console.ReadLine();
                if (inputBody != null)
                {
                    inputBody = InputHandler.GetUserInputString(inputBody);
                }

            }
        }
        private static void CommonMessage()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Du har valgt en almindelig Henvendelse");
            Console.WriteLine("Overskrift: \n");
            string? inputTitle = Console.ReadLine();
            if (inputTitle != null) 
            { 
                inputTitle = InputHandler.GetUserInputString(inputTitle);
                Console.WriteLine("Besked: \n");
                string? inputBody = Console.ReadLine();
                if (inputBody != null)
                {
                    inputBody = InputHandler.GetUserInputString(inputBody);
                }
            }
                

        }
        private static void ErrorMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Du har valgt forkert. Prøv igen");

        }
    }
}// lave titel, body og tjek om besked er korrekt