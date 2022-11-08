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
        public Menu(string title, int size)
        {
            Title = title;
            menuItems = new List<MenuItem>();
        }
        public void Show()
        {
            Console.WriteLine(Title + "\n");
            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine((i + 1) + "TEKST: " + menuItems[i].title);
            }
        }
        public void AddItem(string menuTitle)
        {
            MenuItem mi = new MenuItem(menuTitle);
            menuItems.Add(mi);  
        }
    }
}
