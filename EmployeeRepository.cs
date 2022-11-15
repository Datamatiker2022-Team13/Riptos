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

        public void save(string pass)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, true))
                {
                    sw.WriteLine(pass);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public List<string> load()
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    List<string> strings = new List<string>();
                    while (!sr.EndOfStream)
                    {
                        strings.Add(line = sr.ReadLine());
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
