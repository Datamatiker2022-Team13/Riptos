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
            employees.Add(employee);
        }
        public void GetEmployee(string username)
        {
            for (int i = 0; i < load().Count; i++)
            {
                if (load()[i].Username == username)
                {

                    return;
                }

            }

        }

        public void UpdateUsername()
        {

        }
        public void UpdatePassword()
        {

        }
        public void DeleteEmployee()
        {

        }


        






    }
}
