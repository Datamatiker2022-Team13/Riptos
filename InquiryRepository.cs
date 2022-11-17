using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Riptos
{
    public class InquiryRepository
    {
        string fileName = "";
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

        public void save(string message)
        {
            try
            {
                StorageStart(fileName);
                using (StreamWriter sw = new StreamWriter(fileName, true))

                { 
                    sw.WriteLine(ec.EncryptString(message));
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public List<Inquiry> load()
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

                        line = sr.ReadLine();
                        string[] tempList = line.Split("");
                        Inquiry inq = new Inquiry(ec.DecryptString(tempList[0]),Convert.ToBoolean(tempList[1]));
                        strings.Add(inq);

                        // fix kryptering - lige nu krypteres hele beskeden, der er en overflødig anonymisering af beskeden. omskriv

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
