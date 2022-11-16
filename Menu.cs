using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Riptos
{
    public class Menu
    {
        public string Title { get; set; }
        private List<string> menuItems;
        public Menu(string title, int size)
        {
            Title = title;
            menuItems = new List<string>();
        }
        public void Show() //returnre ikke noget en anden classe kan bruge. 
        {
            Console.WriteLine(Title + "\n");
            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine((i + 1) + ":" + menuItems[i]);
            }
        }
        public void AddItem(string menuTitle)
        {
            string mi = menuTitle;
            menuItems.Add(mi);  
        }
        public int GetSelection(string prompt)
        {
            return InputHandler.GetUserInputInt(prompt, 1, menuItems.Count); 


            //int selection;
            //while (true)
            //{
            //    Show();
            //    Console.WriteLine("\n" + message);
            //    string input = Console.ReadLine();
            //    bool Input1 = int.TryParse(input, out selection);
            //    if (Input1 == true)
            //    {
            //        if (selection >= 1 && selection <= menuItems.Count)
            //        {
            //            return selection - 1;
            //        }
            //    }
            //    Console.WriteLine("Error - wrong input" + message + "Invalid Input");
            //    Console.WriteLine("Press any key to try again");
            //    Console.ReadKey();
            //    Console.Clear();
            //}
        }
        
    }
}
