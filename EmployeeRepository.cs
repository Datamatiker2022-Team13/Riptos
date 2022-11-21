using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riptos
{
    public class EmployeeRepository
    {
        List<Employee> employees = new List<Employee>();

        string fileName = @"C:\Users\cappe\Desktop\Getting-Real\Riptos\LoginData.txt";

        public void StorageStart(string filename)
        {
            try
            {
                if (!File.Exists(fileName))
                {
                    using (FileStream fs = File.Create(filename));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        EncryptionHandler ec = new EncryptionHandler();
        
        public void save()
        {
            //Hvis man gemmer listen igen, vil alle ting i listen blive gemt, dog hvis dette,
            //allerede har været gjort tidligere vil den gemme de samme ting igen.
            //Dette skal ændres da det er lort.
            try
            {
                StorageStart(fileName);
                using (StreamWriter sw = new StreamWriter(fileName, true))
                {
                    for (int i = 0; i < employees.Count; i++)
                    {
                        sw.WriteLine(employees[i].Name + "," + employees[i].IsHR + "," + ec.EncryptString(employees[i].Username) + "," + ec.EncryptString(employees[i].Password));

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public List<Employee> load()
        {
            try
            {
                StorageStart(fileName);
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    List<Employee> strings = new List<Employee>();
                    while (!sr.EndOfStream)
                    {
                        for (int i = 0; i < employees.Count; i++)
                        {
                            line = sr.ReadLine();
                            string[] tempList = line.Split(",");
                            Employee emp = new Employee(tempList[i], Convert.ToBoolean(tempList[i+1]), ec.DecryptString(tempList[i+2]), ec.DecryptString(tempList[i+3]));
                            strings.Add(emp);
                            //strings.Add(line = sr.ReadLine());

                        }
                        
                    }
                    return strings;
                }
            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public void AddEmployee(Employee employee)
        {
            for (int i = 0;i < employees.Count; i++)
            {
                if (employee.Username == employees[i].Username)
                {
                    Console.WriteLine("Dit navn er taget din klump");
                }
                else
                {
                    employees.Add(employee);
                }
            }
            
        }
        public Employee GetEmployee(string username)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Username == username)
                {

                    return employees[i];
                }
            }
            return null;

        }

        public void UpdateUsername(Employee employee, string username)
        {
            for (int i =0; i < employees.Count; i++)
            {
                if (employee.Username == employees[i].Username && employee.Password == employees[i].Password)
                {
                    employees[i].Username = username;
                }
            }
            
        }
        public void UpdatePassword(Employee employee, string password)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if (employee.Username == employees[i].Username && employee.Password == employees[i].Password)
                {
                    employees[i].Password = password;
                }
            }

        }
        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }


        public List<Employee> GetAll()
        {
            return employees;
        }






    }
}
