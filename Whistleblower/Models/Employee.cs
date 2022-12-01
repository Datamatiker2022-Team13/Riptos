namespace Whistleblower.Models
{
    public class Employee
    {
        /// <summary>
        /// Internal ID counter.
        /// </summary>
        private static int iDCount = 0;

        public int ID { get; private set; }

        public string Name { get; set; }
        public bool IsHR { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public Employee (string name, bool isHR, string username, string password)
        {
            ID = iDCount++;

            Name = name;
            IsHR = isHR;

            Username = username;
            Password = password;
        }

        public string GetCSVFormat () {
            return string.Format($"{Name};{IsHR};{Username};{Password}");
        }
    }
}
