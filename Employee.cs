namespace Riptos
{
    public class Employee
    {
       private string username;
       private string password;
       private string name;
       private bool isHR;

       public string Username
        {
            get { return username; }
        } 
        public string Password
        {
            get { return password; }
        }
        public string Name
        {
            get { return name; }
        }
        public bool IsHR
        {
            get { return isHR; }
        }
        public Employee (string name, bool isHR)
        {
            this.username = name;
            this.isHR = isHR;
        }
        public void SetUserCredentials(string UserVal, string PassVal)
        {
            this.username = UserVal;
            this.password = PassVal;
        }
    }
}
