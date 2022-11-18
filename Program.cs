namespace Riptos
{
    internal class Program
    {
        public Employee ActiveEmployee { get; set; }
        private EmployeeRepository employeeRepo;
        static void Main (string[] args) {
            Console.WriteLine("");
            EmployeeRepository ep = new EmployeeRepository();

            EncryptionHandler encrypt = new EncryptionHandler();



            Employee eps = new Employee("alex", false, "hej", "pis");


            ep.AddEmployee(eps);

            ep.save();

            //string yeet = ep.load()[1].Password;
            //Console.WriteLine(yeet);
        }
        public void InitializeViewHandler()
        {
            Menu LoginMenu = new Menu("Velkommen til Login siden");

            LoginMenu.AddItem("Login");
            LoginMenu.AddItem("Register ny bruger");

            Menu HRMenu = new Menu("");

            HRMenu.AddItem("Vis kalender");
            HRMenu.AddItem("Send henvendelse");
            HRMenu.AddItem("Vis henvendelse");
            HRMenu.AddItem("Opret sag");
            HRMenu.AddItem("Vis sager");
            HRMenu.AddItem("Log ud");

            Menu EmployeeMenu = new Menu("");

            EmployeeMenu.AddItem("Vis kalender");
            EmployeeMenu.AddItem("Send henvendelse");
            EmployeeMenu.AddItem("Vis henvendelse");
            EmployeeMenu.AddItem("Log ud");

            Menu SubjectMenu = new Menu("Vælg emne: ");

            SubjectMenu.AddItem("bullying");
            SubjectMenu.AddItem("dicrimination");
            SubjectMenu.AddItem("harassment");

            Menu HREmployeeMenu = new Menu("");

            foreach (Employee employee in employeeRepo.GetAll())
            {
                if (employee.IsHR == true)
                    HREmployeeMenu.AddItem(employee.Username);
            }
        }
    } 
}