namespace Whistleblower.Models
{
    public class ViewHandler
    {
        private Controller controller;
        static int sleeper = 1000;
        public Menu LoginMenu { get; set; }
        public Menu EmployeeMainMenu { get; set; }
        public Menu HRMainMenu { get; set; }
        public Menu SubjectMenu { get; set; }
        public Menu HREmployeeMenu { get; set; }
        public ViewHandler(Menu loginMenu, Menu employeeMainMenu, Menu hrMainMenu, Menu subjectMenu, Menu hrEmployeeMenu)
        {
            LoginMenu = loginMenu;
            EmployeeMainMenu = employeeMainMenu;
            HRMainMenu = hrMainMenu;
            SubjectMenu = subjectMenu;
            HREmployeeMenu = hrEmployeeMenu;
        }
        public void ShowLoginView()
        {
            switch (LoginMenu.GetSelection("Vælg handling: "))
            {
                case 0:
                    Console.WriteLine("Login side");

                    string username = InputHandler.GetUserInputString("Indtast brugernavn: ");
                    string password = InputHandler.GetUserInputString("Indtast kodeord: ");

                    if (controller.TryLogin(username, password))
                        Console.WriteLine("Succes!");
                    else
                        Console.WriteLine("Fejl!");

                    break;

                case 1:
                    Console.WriteLine("Register ny bruger");
                    Console.Read();
                    break;
            }
        }
        public void ShowMainView(Employee employee)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Velkommen til " + employee.Username);
                if (employee.IsHR == true)
                {
                    HRMainMenu.Show();
                    switch (HRMainMenu.GetSelection("Vælg Handling: "))
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
                    EmployeeMainMenu.Show();
                    switch (EmployeeMainMenu.GetSelection("Vælg handling: "))
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
        public void ShowInquiriesView(List<Inquiry> inquiries)
        {
            Menu inquiryMenu = new Menu("");

            foreach (Inquiry inquiry in inquiries)
            {
                inquiryMenu.AddItem(inquiry.Title);
            }
            
            inquiryMenu.Show();
            ShowInquiry(inquiries[inquiryMenu.GetSelection("")]);
        }
        public void ShowInquiry(Inquiry inquiry)
        {
            throw new NotImplementedException();
        }
        public void ShowSendInquiryView(Employee employee)
        {

            string title = InputHandler.GetUserInputString("Titel: ");

            // TODOOOOO
            SubjectMenu.Show();
            int selection = SubjectMenu.GetSelection("Emne: ");
            SubjectType subject = (SubjectType)selection;

            List<SubjectType> subjects = new List<SubjectType>();
            subjects.Add(subject);

            string message = InputHandler.GetUserInputString("Besked: ");

            bool isAnonymous = InputHandler.GetUserInputBool("Skal beskeden være anonym?: ");

            HREmployeeMenu.Show();
            int receiverSelection = HREmployeeMenu.GetSelection("Hvilke HR-Præsentant skal modtage henvendelsen?");

            controller.SendInquiry(receiverSelection, title, subjects, message, isAnonymous);
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
