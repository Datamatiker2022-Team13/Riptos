using System.Collections.Generic;
using System.IO;

namespace Whistleblower.Models
{
    public class EmployeeRepository
    {
        string filePath = Path.GetFullPath(@"..\..\..\Data\EmployeeRepository.txt");

        EncryptionHandler encryptor;

        List<Employee> employees;

        public EmployeeRepository () {
            encryptor = new EncryptionHandler();

            employees = new List<Employee>();
            Load();
        }

        public void Save () {
            if (!File.Exists(filePath))
                File.Create(filePath).Close();

            using (StreamWriter sw = new StreamWriter(filePath, false)) {
                foreach (Employee employee in employees) {
                    string encryptedEmployee = encryptor.EncryptString(employee.GetCSVFormat());
                    sw.WriteLine(encryptedEmployee);
                }
            }
        }

        public void Load () {
            using (StreamReader sr = new StreamReader(filePath)) {
                while (!sr.EndOfStream) {
                    //string decryptedEmployee = encryptor.DecryptString(sr.ReadLine());
                    string decryptedString = sr.ReadLine();
                    string[] splitLine = decryptedString.Split(';');

                    Employee employee = new Employee(
                        splitLine[0],
                        bool.Parse(splitLine[1]),
                        splitLine[2],
                        splitLine[3]);

                    employees.Add(employee);
                }
            }
        }

        public Employee AddEmployee (string name, bool isHR, string username, string password) {
            Employee employee = new Employee(name, isHR, username, password);

            employees.Add(employee);

            return employee;
        }

        public Employee GetEmployee (int id) {
            for (int i = 0; i < employees.Count; i++) {
                if (employees[i].ID == id) {
                    return employees[i];
                }
            }

            return null;
        }

        public void UpdateUsername (int id, string username) {
            for (int i = 0; i < employees.Count; i++) {
                if (id == employees[i].ID) {
                    employees[i].Username = username;
                }
            }
        }

        public void UpdatePassword (int id, string password) {
            for (int i = 0; i < employees.Count; i++) {
                if (id == employees[i].ID) {
                    employees[i].Password = password;
                }
            }
        }

        public void DeleteEmployee (Employee employee) {
            employees.Remove(employee);
        }

        public List<Employee> GetAll () {
            return employees;
        }
    }
}
