using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;

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

        private string filePath = Path.GetFullPath(@"..\..\..\Data\InquiryRepository.xml");

        private List<Inquiry> inquiries;

        #region Persistance
        public void Save()
        {
            if (!File.Exists(filePath))
                File.Create(filePath).Close();

            XmlWriterSettings writerSettings = new XmlWriterSettings();
            writerSettings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create(filePath, writerSettings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Inquiries");
                foreach (Inquiry inquiry in inquiries)
                {
                    writer.WriteStartElement("Inquiry");

                    writer.WriteElementString("Sender", inquiry.Sender.ID.ToString());
                    writer.WriteElementString("Receiver", inquiry.Receiver.ID.ToString());
                    writer.WriteElementString("Title", inquiry.Title);

                    writer.WriteStartElement("Subjects");
                    foreach (SubjectType subject in inquiry.Subjects)
                    {
                        writer.WriteElementString("Subject", subject.ToString());
                    }
                    writer.WriteEndElement();

                    writer.WriteStartElement("Conversation");
                    foreach (Message message in inquiry.Conversation)
                    {
                        writer.WriteElementString("Message", message.ID.ToString());
                    }
                    writer.WriteEndElement();

                    writer.WriteElementString("IsAnonymous", inquiry.IsAnonymous.ToString().ToLower());

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
            settings.IgnoreComments = true; // most likely unnecessary
            
            using (XmlReader reader = XmlReader.Create(filePath, settings))
            {
                reader.ReadToFollowing("Inquiry");
                do
                {
                    reader.ReadToFollowing("Sender");

                    Employee sender = EmployeeRepository.Instance.Retrieve(reader.ReadElementContentAsInt());
                    Employee receiver = EmployeeRepository.Instance.Retrieve(reader.ReadElementContentAsInt());
                    string title = reader.ReadElementContentAsString();

                    List<SubjectType> subjects = new List<SubjectType>();
                    XmlReader subtreeReader = reader.ReadSubtree();

                    subtreeReader.ReadToFollowing("Subject");
                    do
                    {
                        try
                        {
                            subjects.Add((SubjectType) Enum.Parse(typeof(SubjectType), subtreeReader.ReadElementContentAsString()));
                        }
                        catch (InvalidOperationException ex) // catch this cranky-ass exception
                        {
                            subtreeReader.Close();
                        }
                    } while (!subtreeReader.EOF);

                    reader.ReadToFollowing("Conversation");

                    List<Message> conversation = new List<Message>();
                    subtreeReader = reader.ReadSubtree();

                    subtreeReader.ReadToFollowing("Message");
                    do
                    {
                        try
                        {
                            conversation.Add(MessageRepository.Instance.Retrieve(subtreeReader.ReadElementContentAsInt()));
                        }
                        catch (InvalidOperationException ex)
                        {
                            subtreeReader.Close();
                        }
                    } while (!subtreeReader.EOF);

                    reader.ReadToFollowing("IsAnonymous");

                    bool isAnonymous = reader.ReadElementContentAsBoolean();

                    inquiries.Add(new Inquiry(sender, receiver, title, subjects, conversation, isAnonymous));
                }
                while (reader.ReadToFollowing("Inquiry"));

                Trace.WriteLine("Phew");
            }
        }
        #endregion

        #region CRUD
        public Inquiry Create(Employee sender, Employee receiver, string title, List<SubjectType> subjects, Message message, bool isAnonymous)
        {
            Inquiry inquiry = new Inquiry(sender, receiver, title, subjects, message, isAnonymous);

            inquiries.Add(inquiry);
            
            // save the entire repository again, to ensure the newly created inquiry is also saved.
            // TODO: make it so the Save method is only called on window close...
            Save();

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
