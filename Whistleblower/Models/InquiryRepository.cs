using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Whistleblower.Models
{
    public class InquiryRepository
    {
        string fileName = "test.txt";
        List<Inquiry> inquiries = new List<Inquiry>();
        EncryptionHandler ec = new EncryptionHandler(); 
        
        public void StorageStart(string filename)
        {
            try
            {
                if (!File.Exists(fileName))
                {
                    using (FileStream fs = File.Create(filename)) ;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Save(string message)
        {
            try
            {
                StorageStart(fileName);
                using (StreamWriter sw = new StreamWriter(fileName, true))

                {
                    for (int i = 0; i < inquiries.Count; i++)
                    {
                        if (inquiries[i].IsAnonymous == true)
                        {
                            sw.WriteLine(inquiries[i].Title + "^" + inquiries[i].Subjects + "^" + ec.EncryptString(Convert.ToString(inquiries[i].Conversation)) + "^" + inquiries[i].IsAnonymous + "^" + ec.EncryptString(Convert.ToString(inquiries[i].Sender)) + "^" + inquiries[i].Receiver);
                        }
                        else
                        {
                            sw.WriteLine(inquiries[i].Title + "^" + inquiries[i].Subjects + "^" + inquiries[i].Conversation + "^" + inquiries[i].IsAnonymous + "^" + inquiries[i].Sender + "^" + inquiries[i].Receiver);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public List<Inquiry> Load()
        {
            try
            {
                StorageStart(fileName);
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    List<Inquiry> strings = new List<Inquiry>();
                    while (!sr.EndOfStream)
                    {
                        int i = 0;
                        if (inquiries[i].IsAnonymous == true)//TODO Fix this if statement, u cant use the list here, cause the list will be reset every time the program starts.
                        {
                            line = sr.ReadLine();
                            string[] tempList1 = line.Split("^");
                            Inquiry inq = new Inquiry(tempList1[i], (SubjectType)Enum.Parse(typeof(SubjectType), tempList1[i + 1]), new Message(null, ec.DecryptString(tempList1[i + 2]), DateTime.Now), Convert.ToBoolean(tempList1[i + 3]), new Employee(ec.DecryptString(tempList1[i + 4]), false, null, null), new Employee(ec.DecryptString(tempList1[i + 5]), false, null, null));
                            strings.Add(inq);

                        }
                        else
                        {
                            line = sr.ReadLine();
                            string[] tempList1 = line.Split("^");
                            Inquiry inq = new Inquiry(tempList1[i], (SubjectType)Enum.Parse(typeof(SubjectType), tempList1[i + 1]), new Message(null, tempList1[i + 2], DateTime.Now), Convert.ToBoolean(tempList1[i + 3]), new Employee(tempList1[i + 4], false, null, null), new Employee(tempList1[i + 5], false, null, null));
                            strings.Add(inq);
                        }

                        i += 1;
                    }
                    return strings;

                }
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public void AddInquiry(Inquiry inquiry)
        {
            for (int i = 0; i < inquiries.Count; i++)
            {
                if (inquiry.Title == inquiries[i].Title)
                {
                    Console.WriteLine("Denne henvendelse er i forvejen oprettet");
                }
                else
                {
                    inquiries.Add(inquiry);
                }

            }
        }


        public Inquiry GetInquiry(string title)
        {
            for (int i = 0; i < inquiries.Count; i++)
            {
                if (inquiries[i].Title == title)
                {
                    return inquiries[i];
                }
            }

            return null;
        }

    public void RemoveInquiry(Inquiry inquiry)

        {
            inquiries.Remove(inquiry);
        }
    }
}
