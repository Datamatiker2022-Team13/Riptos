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
        private List<MenuItem> menuItems;
        public Menu(string title)
        {
            Title = title;
            menuItems = new List<MenuItem>();
        }
        public void Show()
        {
            Console.WriteLine(Title + "\n");
            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine((i + 1) + ": " + menuItems[i].title);
            }
        }
        public void AddItem(string menuTitle)
        {
            MenuItem mi = new MenuItem(menuTitle);
            menuItems.Add(mi);  
        }
        public int GetSelection(string promtMsg)
        {
            int selection;
            while (true)
            {
                Show();
                Console.WriteLine("\n" + promtMsg);
                string input = Console.ReadLine();
                bool Input1 = int.TryParse(input, out selection);
                if (Input1 == true)
                {
                    if (selection >= 1 && selection <= menuItems.Count)
                    {
                        return selection - 1;
                    }
                }
                Console.WriteLine();
            }
        }
        internal class MenuItem
        {
            public string title;
            public MenuItem(string ItemTitle)
            {
                title = ItemTitle;

            }
        }
    }
}
