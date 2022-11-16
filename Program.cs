namespace Riptos
{
    internal class Program
    {
        static void Main (string[] args) {
            Console.WriteLine("");
            EmployeeRepository ep = new EmployeeRepository();
            ep.save("Banja",false,"Lort","SutterDiller");
            string yeet = ep.load()[1].Name;
            Console.WriteLine(yeet);
        }
    } 
}