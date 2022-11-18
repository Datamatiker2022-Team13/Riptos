namespace Riptos
{
    internal class Program
    {
        public Employee ActiveEmployee { get; set; }
        static private EmployeeRepository employeeRepo;
        static private ViewHandler viewHandler;

        static void Main (string[] args) {
            employeeRepo = new EmployeeRepository();

            InitializeViewHandler();

            #region Cappers stuff
            Console.WriteLine("");
            EmployeeRepository ep = new EmployeeRepository();

            EncryptionHandler encrypt = new EncryptionHandler();



            Employee eps = new Employee("alex", false, "hej", "pis");


            ep.AddEmployee(eps);

            ep.save();

            //string yeet = ep.load()[1].Password;
            //Console.WriteLine(yeet);
            #endregion

            viewHandler.ShowLoginView();
        }
        static public void InitializeViewHandler()
        {
            Menu loginMenu = new Menu("Velkommen til Login siden");

            loginMenu.AddItem("Login");
            loginMenu.AddItem("Register ny bruger");

            Menu hrMenu = new Menu("");

            hrMenu.AddItem("Vis kalender");
            hrMenu.AddItem("Send henvendelse");
            hrMenu.AddItem("Vis henvendelse");
            hrMenu.AddItem("Opret sag");
            hrMenu.AddItem("Vis sager");
            hrMenu.AddItem("Log ud");

            Menu employeeMenu = new Menu("");

            employeeMenu.AddItem("Vis kalender");
            employeeMenu.AddItem("Send henvendelse");
            employeeMenu.AddItem("Vis henvendelse");
            employeeMenu.AddItem("Log ud");

            Menu subjectMenu = new Menu("Vælg emne: ");

            subjectMenu.AddItem("bullying");
            subjectMenu.AddItem("dicrimination");
            subjectMenu.AddItem("harassment");

            Menu hrEmployeeMenu = new Menu("");

            foreach (Employee employee in employeeRepo.GetAll())
            {
                if (employee.IsHR == true)
                    hrEmployeeMenu.AddItem(employee.Username);
            }

            viewHandler = new ViewHandler(loginMenu, employeeMenu, hrMenu, subjectMenu, hrEmployeeMenu);
        }
    } 
}