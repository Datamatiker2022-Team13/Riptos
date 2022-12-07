using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Whistleblower.MVVM.Models
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

        private string filePath = Path.GetFullPath(@"..\..\..\Data\EmployeeRepository.xml");

        private List<Employee> employees;

        #region Persistance
        public void Save()
        {
            if (!File.Exists(filePath))
                File.Create(filePath).Close();

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create(filePath, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Employees");
                foreach (Employee employee in employees)
                {
                    writer.WriteStartElement("Employee");

                    writer.WriteElementString("Name", employee.Name);
                    writer.WriteElementString("IsHR", employee.IsHR.ToString().ToLower());
                    writer.WriteElementString("Username", employee.Username);
                    writer.WriteElementString("Password", employee.Password);

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        public void Load()
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;

            using (XmlReader reader = XmlReader.Create(filePath, settings))
            {
                reader.ReadToFollowing("Employee");
                do
                {
                    reader.ReadToFollowing("Name");

                    string name = reader.ReadElementContentAsString();
                    bool isHR = reader.ReadElementContentAsBoolean();
                    string username = reader.ReadElementContentAsString();
                    string password = reader.ReadElementContentAsString();

                    employees.Add(new Employee(name, isHR, username, password));
                }
                while (reader.ReadToFollowing("Employee"));
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

        public void Delete(int id)
        {
            employees.Remove(Retrieve(id));
        }
        #endregion
    }
}
