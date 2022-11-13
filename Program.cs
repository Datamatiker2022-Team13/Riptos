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
                MainMenu.AddItem("Luk konsol");

                switch (MainMenu.GetSelection("Vælg handling: "))
                {
                    case 0:
                        break;
                    case 1: 
                        break;
                    case 2:
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
                }
            }
        }
    }
}