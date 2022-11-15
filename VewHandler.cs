namespace Riptos
{
    public class VewHandler
    {
        //private Controller controller;

        public Menu LoginMenu { get; set; }
        public Menu EmployeeMenu { get; set; }
        public Menu HRMenu { get; set; }

        static void ShowLoginView()
        {
            Menu Login = new Menu("Velkommen til Login siden");

            Login.AddItem("Login");
            Login.AddItem("Register ny bruger");

            switch (Login.GetSelection("Vælg handling: "))
            {
                case 0:
                    Console.WriteLine("Login side");
                    break;

                case 1:
                    Console.WriteLine("Register ny bruger");
                    break;
            }
        }
        static void ShowMainView(Employee employee)
        {
 
        }
        static void ShowInquiriesView(List<Inquiry> inquiries)
        {

        }
        public void ShowSendInquiryView(Employee employee)
        {

        }
    }
}
