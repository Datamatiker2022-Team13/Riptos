using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riptos
{
    public class Inquiry
    {
        public int ID { get; private set; }

        public string Title { get; set; }

        public List<SubjectType> subjects { get; set; }

        public string Conversation { get; set; }

        public bool IsAnonymous { get; set; }

        public Inquiry(string title, bool isAnonymous)
        {

        }
             
    }
}
