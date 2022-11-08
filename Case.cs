using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riptos
{
    public class Case
    {

        public int ID { get; private set; }
       


        public string Title { get; set; }

        public List <SubjectType> subjects { get; set; }
    public Case(string title)
    {
        
    }

    }
}
