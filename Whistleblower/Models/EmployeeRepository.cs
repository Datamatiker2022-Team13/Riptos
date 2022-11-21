using System;
using System.Collections.Generic;
using System.IO;

namespace Whistleblower.Models
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
                    sw.WriteLine(employees[0].Name + "," + employees[0].IsHR + "," + ec.EncryptString(employees[0].Username) + "," + ec.EncryptString(employees[0].Password));
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
                        
                        line = sr.ReadLine();
                        string[] tempList = line.Split(",");
                        Employee emp = new Employee(tempList[0], Convert.ToBoolean(tempList[1]), ec.DecryptString(tempList[2]), ec.DecryptString(tempList[3]));
                        strings.Add(emp);
                        //strings.Add(line = sr.ReadLine());
                        
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
