namespace Riptos
{
    internal class Program
    {
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
    } 
}