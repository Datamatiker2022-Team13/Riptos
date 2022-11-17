using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riptos
{
    public class EmployeeRepository
    {
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

        public void save(string name, bool isHR, string user, string pass)
        {
            try
            {
                StorageStart(fileName);
                using (StreamWriter sw = new StreamWriter(fileName, true))
                {
                    sw.WriteLine(name + "," + isHR + "," + user + "," + pass);
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
                        Employee emp = new Employee(tempList[0], Convert.ToBoolean(tempList[1]), tempList[2], tempList[3]);
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
    }
}
