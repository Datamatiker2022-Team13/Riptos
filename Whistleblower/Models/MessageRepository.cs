using System;
using System.Collections.Generic;
using System.IO;

namespace Whistleblower.Models
{
    public class MessageRepository
    {
        #region Singleton
        private static MessageRepository _instance;
        public static MessageRepository Instance {
            get {
                if (_instance == null) {
                    _instance = new MessageRepository();
                    return _instance;
                }
                return _instance;
            }

            private set {
                _instance = value;
            }
        }

        private MessageRepository () {
            messages = new List<Message>();
            // TODO : Load();
        }
        #endregion

        private string filePath = Path.GetFullPath(@"..\..\..\Data\MessageRepository.txt");

        private List<Message> messages;

        #region Persistance

        public void Save()
        {
            if (!File.Exists(filePath))
                File.Create(filePath).Close();

            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                foreach (Message message in messages)
                {
                    string encryptedString = EncryptionHandler.EncryptString(message.GetCSVFormat());
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
                    string decryptedString = sr.ReadLine();
                    string[] parts = decryptedString.Split(';');

                    Employee sender = EmployeeRepository.Instance.Retrieve(int.Parse(parts[0]));
                    string content = parts[1];
                    DateTime sendDateTime = DateTime.Parse(parts[2]);

                    Message message = new Message(sender, content, sendDateTime);

                    messages.Add(message);
                }
            }
        }
        #endregion

        #region CRUD
        public Message Create(Employee sender, string content, DateTime sendDateTime)
        {
            Message message = new Message(sender, content, sendDateTime);

            messages.Add(message);

            return message;
        }

        public Message Retrieve(int id)
        {
            for (int i = 0; i < messages.Count; i++)
            {
                if (messages[i].ID == id)
                {
                    return messages[i];
                }
            }

            return null;
        }

        public List<Message> RetrieveAll()
        {
            return messages;
        }

        public void Delete(Message message)
        {
            messages.Remove(message);
        }
        #endregion
    }
}
