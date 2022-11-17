namespace Riptos
{
    public class ViewHandler
    {
        //private Controller controller;
        static int sleeper = 1000;
        public Menu LoginMenu { get; set; }
        public Menu EmployeeMenu { get; set; }
        public Menu HRMenu { get; set; }

        public ViewHandler()
        {
            

            LoginMenu = new Menu("Velkommen til Login siden");

            LoginMenu.AddItem("Login");
            LoginMenu.AddItem("Register ny bruger");

            HRMenu = new Menu("");

            HRMenu.AddItem("Vis kalender");
            HRMenu.AddItem("Send henvendelse");
            HRMenu.AddItem("Vis henvendelse");
            HRMenu.AddItem("Opret sag");
            HRMenu.AddItem("Vis sager");
            HRMenu.AddItem("Log ud");

            EmployeeMenu = new Menu("");


            EmployeeMenu.AddItem("Vis kalender");
            EmployeeMenu.AddItem("Send henvendelse");
            EmployeeMenu.AddItem("Vis henvendelse");
            EmployeeMenu.AddItem("Log ud");
        }
        public void ShowLoginView()
        {
            LoginMenu.Show();
            switch (LoginMenu.GetSelection("Vælg handling: "))
            {
                case 0:
                    Console.WriteLine("Login side");
                    break;

                case 1:
                    Console.WriteLine("Register ny bruger");
                    break;
            }
        }
        public void ShowMainView(Employee employee)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Velkommen til " + employee.username );
                if (employee.IsHR == true)
                {
                    HRMenu.Show();
                    switch (HRMenu.GetSelection("Vælg Handling: "))
                    {
                        case 0:
                            Console.WriteLine("Vis kalender side");
                            break;
                        case 1:
                            Console.WriteLine("Send henvendelse side");
                            break;
                        case 2:
                            Console.WriteLine("Vis henvenedelse side");
                            break;
                        
                        case 3:
                            Console.WriteLine("Opret sag side");
                            break;
                        case 4:
                            Console.WriteLine("Vis sager side");
                            break;
                        case 5:
                            CloseConsole();
                            running = false;
                            break;
                    }
                }
                else
                {
                    EmployeeMenu.Show();
                    switch (EmployeeMenu.GetSelection("Vælg handling: "))
                    {
                        case 0:
                            Console.WriteLine("Vis kalender side");
                            break;
                        case 1:
                            Console.WriteLine("Send henvendelse side");
                            break;
                        case 2:
                            Console.WriteLine("Vis henvendelse side");
                            break;
                        case 3:
                            CloseConsole();
                            running = false;
                            break;
                    }
                }
            }


        }
        static public void ShowInquiriesView(List<Inquiry> inquiries)
        {
            Console.WriteLine("Ulæste beskeder: " + "{AMOUNT}");
            Console.WriteLine("Læste beskeder: " + "{AMOUNT}");
        }
        static public void ShowSendInquiryView(Employee employee)
        {
            Console.WriteLine("Title: ");
            Console.WriteLine("Emne: "); // LIST SUBJECTTYPE
            Console.WriteLine("Besked: ");
            Console.WriteLine("Skal beskeden være anonym?: "); // BOOL

            Console.WriteLine("Hvilke HR-Præsentant skal modtage henvendelsen?"); // LIST EMPLOYEE
        }

        public void CloseConsole()
        {
            Console.Clear();
            Console.WriteLine("Konsolen lukker om.. ");
            Thread.Sleep(sleeper);
            Console.WriteLine("3...");
            Thread.Sleep(sleeper);
            Console.WriteLine("2...");
            Thread.Sleep(sleeper);
            Console.WriteLine("1...");
        }
    }
}
