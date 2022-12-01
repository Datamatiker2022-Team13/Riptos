using System;
using System.Collections.Generic;
using System.IO;

namespace Whistleblower.Models
{
    public class InquiryRepository
    {
        #region Singleton
        private static InquiryRepository? _instance;
        /// <summary>
        /// NOT THREAD SAFE
        /// </summary>
        public static InquiryRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InquiryRepository();
                    return _instance;
                }
                return _instance;
            }

            private set
            {
                _instance = value;
            }
        }

        private InquiryRepository()
        {
            inquiries = new List<Inquiry>();
            Load();
        }
        #endregion

        private string filePath = Path.GetFullPath(@"..\..\..\Data\InquiryRepository.txt");

        private List<Inquiry> inquiries;

        #region Persistance
        public void Save()
        {
            if (!File.Exists(filePath))
                File.Create(filePath).Close();

            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                foreach (Inquiry inquiry in inquiries)
                {
                    string encryptedString = EncryptionHandler.EncryptString(inquiry.GetCSVFormat());
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
                    //string decryptedString = encryptor.DecryptString(sr.ReadLine());
                    string decryptedString = sr.ReadLine();
                    string[] parts = decryptedString.Split(';');

                    Employee sender = EmployeeRepository.Instance.Retrieve(int.Parse(parts[0]));
                    Employee receiver = EmployeeRepository.Instance.Retrieve(int.Parse(parts[1]));
                    string title = parts[2];
                    SubjectType subject = (SubjectType) Enum.Parse(typeof(SubjectType), parts[3]);
                    Message conversation = MessageRepository.Instance.Retrieve(int.Parse(parts[4]));
                    bool isAnonymous = bool.Parse(parts[5]);

                    Inquiry inquiry = new Inquiry(sender, receiver, title, subject, conversation, isAnonymous);

                    inquiries.Add(inquiry);
                }
            }
        }
        #endregion

        #region CRUD
        public Inquiry Create(Employee sender, Employee receiver, string title, SubjectType subject, Message message, bool isAnonymous)
        {
            Inquiry inquiry = new Inquiry(sender, receiver, title, subject, message, isAnonymous);

            inquiries.Add(inquiry);

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(inquiry.GetCSVFormat());
            }

            return inquiry;
        }

        public Inquiry Retrieve(int id)
        {
            for (int i = 0; i < inquiries.Count; i++)
            {
                if (inquiries[i].ID == id)
                {
                    return inquiries[i];
                }
            }

            return null;
        }

        public List<Inquiry> RetrieveAll()
        {
            return inquiries;
        }

        public void Delete(Inquiry inquiry)
        {
            inquiries.Remove(inquiry);
        }
        #endregion
    }
}
