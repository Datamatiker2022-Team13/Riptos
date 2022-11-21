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
            set { username = value; }
        } 
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Name
        {
            get { return name; }
        }
        public bool IsHR
        {
            get { return isHR; }
        }
        public Employee (string name, bool isHR, string UserVal, string PassVal)
        {
            this.name = name;
            this.isHR = isHR;
            this.username = UserVal;
            this.password = PassVal;
        }
        //public void SetUserCredentials(string UserVal, string PassVal)
        //{
        //    this.username = UserVal;
        //    this.password = PassVal;
        //}
    }
}
