using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;

namespace Whistleblower.MVVM.Models
{
    public class MessageRepository
    {
        #region Singleton
        private static MessageRepository _instance;
        public static MessageRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MessageRepository();
                    return _instance;
                }
                return _instance;
            }

            private set
            {
                _instance = value;
            }
        }

        private MessageRepository()
        {
            messages = new List<Message>();
            Load();
        }
        #endregion

        private string filePath = Path.GetFullPath(@"..\..\..\Data\MessageRepository.xml");

        private List<Message> messages;

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
                writer.WriteStartElement("Messages");
                foreach (Message message in messages)
                {
                    writer.WriteStartElement("Message");

                    writer.WriteElementString("Sender", message.Sender.ID.ToString());
                    writer.WriteElementString("Content", message.Content);
                    writer.WriteElementString("SendDateTime", message.SendDateTime.ToString("dd-MM-yyyy HH.mm.ss", CultureInfo.CurrentCulture));
                    writer.WriteElementString("IsAnonymous", message.IsAnonymous.ToString().ToLower());

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
                reader.ReadToFollowing("Message");
                do
                {
                    reader.ReadToFollowing("Sender");

                    Employee sender = EmployeeRepository.Instance.Retrieve(reader.ReadElementContentAsInt());
                    string content = reader.ReadElementContentAsString();
                    DateTime sendDateTime = DateTime.ParseExact(reader.ReadElementContentAsString(), "dd-MM-yyyy HH.mm.ss", CultureInfo.CurrentCulture);
                    bool isAnonymous = reader.ReadElementContentAsBoolean();

                    messages.Add(new Message(sender, content, sendDateTime, isAnonymous));
                }
                while (reader.ReadToFollowing("Message"));
            }
        }
        #endregion

        #region CRUD
        public Message Create(Employee sender, string content, DateTime sendDateTime, bool isAnonymous)
        {
            Message message = new Message(sender, content, sendDateTime, isAnonymous);

            messages.Add(message);

            Save();

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
