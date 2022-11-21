namespace Whistleblower.Models
{
    public class Employee
    {
       private string _username;
       private string _password;
       private string _name;
       private bool _isHR;

       public string Username
        {
            get { return _username; }
            set { _username = value; }
        } 
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string Name
        {
            get { return _name; }
        }
        public bool IsHR
        {
            get { return _isHR; }
        }
        public Employee (string name, bool isHR, string username, string password)
        {
            _name = name;
            _isHR = isHR;
            _username = username;
            _password = password;
        }
        //public void SetUserCredentials(string UserVal, string PassVal)
        //{
        //    this.username = UserVal;
        //    this.password = PassVal;
        //}
    }
}
