using System.Collections.Generic;
using System.IO;

namespace Whistleblower.Models
{
    public class EmployeeRepository
    {
        #region Singleton
        private static EmployeeRepository _instance;
        public static EmployeeRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EmployeeRepository();
                    return _instance;
                }
                return _instance;
            }

            private set
            {
                _instance = value;
            }
        }

        private EmployeeRepository()
        {
            employees = new List<Employee>();
            Load();
        }
        #endregion

        private string filePath = Path.GetFullPath(@"..\..\..\Data\EmployeeRepository.txt");

        private List<Employee> employees;

        #region Persistance
        public void Save()
        {
            if (!File.Exists(filePath))
                File.Create(filePath).Close();

            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                foreach (Employee employee in employees)
                {
                    string encryptedString = EncryptionHandler.EncryptString(employee.GetCSVFormat());
                    sw.WriteLine(encryptedString);
                }
            }
        }

        public void Load()
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    //string decryptedEmployee = encryptor.DecryptString(sr.ReadLine());
                    string decryptedString = sr.ReadLine();
                    string[] parts = decryptedString.Split(';');

                    string name = parts[0];
                    bool isHR = bool.Parse(parts[1]);
                    string username = parts[2];
                    string password = parts[3];

                    Employee employee = new Employee(name, isHR, username, password);

                    employees.Add(employee);
                }
            }
        }
        #endregion

        #region CRUD
        public Employee Create(string name, bool isHR, string username, string password)
        {
            Employee employee = new Employee(name, isHR, username, password);

            employees.Add(employee);

            return employee;
        }

        public Employee Retrieve(int id)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].ID == id)
                {
                    return employees[i];
                }
            }

            return null;
        }

        public List<Employee> RetrieveAll()
        {
            return employees;
        }

        public void UpdateUsername(int id, string username)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if (id == employees[i].ID)
                {
                    employees[i].Username = username;
                }
            }
        }

        public void UpdatePassword(int id, string password)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if (id == employees[i].ID)
                {
                    employees[i].Password = password;
                }
            }
        }

        public void Delete(Employee employee)
        {
            employees.Remove(employee);
        }
        #endregion
    }
}
