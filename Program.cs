namespace Riptos
{
    internal class Program
    {
        static void Main (string[] args) {
            bool running = true;

            while (running)
            {
                Menu MainMenu = new Menu("Velkommen til Whistleblower appen");
                MainMenu.AddItem("Login");
                MainMenu.AddItem("Glemt password?");
                MainMenu.AddItem("Register ny bruger");
                MainMenu.AddItem("Luk konsol\n");

                MainMenu.AddItem("[TEMP] Vis medarbejder menu");
                MainMenu.AddItem("[TEMP] Vis HR-Medarbejder menu");


                switch (MainMenu.GetSelection("Vælg handling: "))
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Login");
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Glemt password");
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Register ny bruger");
                        break;
                    case 3:
                        Console.Clear();

                        Console.WriteLine("Lukker konsolen om..");
                        Thread.Sleep(1000);
                        Console.WriteLine("3..");

                        Thread.Sleep(1000);
                        Console.WriteLine("2...");

                        Thread.Sleep(1000);
                        Console.WriteLine("1...");
                        Thread.Sleep(1000);

                        running = false;
                        break;

                    case 4:
                        EmployeeMenu();
                        break;
                    case 5:
                        HRMenu();
                        break;
                }
            }
        }
        static void EmployeeMenu()
        {
            Console.Clear();

            Menu Menu = new Menu("Velkommen til medarbejder siden");

            Menu.AddItem("Vis kalender");
            Menu.AddItem("Send henvendelse");
            Menu.AddItem("Vis henvendelse");
            Menu.AddItem("log ud");

            switch (Menu.GetSelection("Vælg handling: "))
            {
                case 0:
                    Console.WriteLine("Vis kalender");
                    break;

                case 1:
                    Console.WriteLine("Send hendvendelse");
                    break;

                case 2:
                    Console.WriteLine("Vis henvendelse");
                    break;

                case 3:
                    Console.WriteLine("Log ud");
                    break;
            }
        }
        static void HRMenu()
        {
            Console.Clear();

            Menu Menu = new Menu("Velkommen til medarbejder siden");

            Menu.AddItem("Vis kalender");
            Menu.AddItem("Send henvendelse");
            Menu.AddItem("Vis henvendelse");
            Menu.AddItem("Opret sag");
            Menu.AddItem("Vis sager");
            Menu.AddItem("log ud");

            switch (Menu.GetSelection("[HR] Vælg handling: "))
            {
                case 0:
                    Console.WriteLine("[HR] Vis kalender");
                    break;

                case 1:
                    Console.WriteLine("[HR] Send hendvendelse");

                    break;

                case 2:
                    Console.WriteLine("[HR] Vis henvendelse");
                    break;

                case 3:
                    Console.WriteLine("[HR] Opret sag");
                    break;

                case 4:
                    Console.WriteLine("[HR] Vis sager");
                    break;

                case 5:
                    Console.WriteLine("[HR] Log ud");
                    break;
            }
        }
    }
}