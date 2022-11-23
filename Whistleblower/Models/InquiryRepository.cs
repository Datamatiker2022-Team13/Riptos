using System;
using System.Collections.Generic;
using System.IO;

namespace Whistleblower.Models
{
    public class InquiryRepository
    {
        private EmployeeRepository employeeRepo;
        private MessageRepository messageRepo;

        private string filePath = Path.GetFullPath(@"..\..\..\Data\InquiryRepository.txt");

        private EncryptionHandler encryptor;

        private List<Inquiry> inquiries;
        
        public InquiryRepository (EmployeeRepository employeeRepo, MessageRepository messageRepo) {
            this.employeeRepo = employeeRepo;
            this.messageRepo = messageRepo;

            encryptor = new EncryptionHandler();

            inquiries = new List<Inquiry>();
            Load();
        }

        public void Save(string message)
        {
            if (!File.Exists(filePath))
                File.Create(filePath).Close();

            using (StreamWriter sw = new StreamWriter(filePath, false)) {
                foreach (Inquiry inquiry in inquiries) {
                    string encryptedInquiry = encryptor.EncryptString(inquiry.GetCSVFormat());
                    sw.WriteLine(encryptedInquiry);
                }
            }
        }
        public void Load ()
        {
            using (StreamReader sr = new StreamReader(filePath)) {
                while (!sr.EndOfStream) {
                    //string decryptedString = encryptor.DecryptString(sr.ReadLine());
                    string decryptedString = sr.ReadLine();
                    string[] splitLine = decryptedString.Split(';');

                    Employee sender = employeeRepo.GetEmployee(int.Parse(splitLine[0]));
                    Employee receiver = employeeRepo.GetEmployee(int.Parse(splitLine[1]));
                    string title = splitLine[2];
                    SubjectType subject = (SubjectType)Enum.Parse(typeof(SubjectType), splitLine[3]);
                    Message conversation = messageRepo.Retrieve(int.Parse(splitLine[4]));
                    bool isAnonymous = bool.Parse(splitLine[5]);

                    Inquiry inquiry = new Inquiry(sender, receiver, title, subject, conversation, isAnonymous);

                    inquiries.Add(inquiry);
                }
            }
        }

        public Inquiry AddInquiry(Employee sender, Employee receiver, string title, SubjectType subject, Message message, bool isAnonymous)
        {
            Inquiry inquiry = new Inquiry(sender, receiver, title, subject, message, isAnonymous);

            inquiries.Add(inquiry);

            return inquiry;
        }


        public Inquiry GetInquiry(int id) {
            for (int i = 0; i < inquiries.Count; i++) {
                if (inquiries[i].ID == id) {
                    return inquiries[i];
                }
            }

            return null;
        }

        public List<Inquiry> GetAllInquiries () {
            return inquiries;
        }

        public void RemoveInquiry(Inquiry inquiry)
        {
            inquiries.Remove(inquiry);
        }
    }
}
