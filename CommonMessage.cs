using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Riptos
{
    public class CommonMessage
    {
        public string MessageTitle = "";//properties
        public string MessageBody = "";

        public CommonMessage(string messageTitle,string messageBody)//konstruktor returnere automatisk sig selv. 
        {
           MessageTitle = messageTitle; // et parameter er en variabel der bliver sendt fra ne metode til en anden. 
           MessageBody = messageBody;
        }

        //returnere int, string. console.readline
        
    }

}
