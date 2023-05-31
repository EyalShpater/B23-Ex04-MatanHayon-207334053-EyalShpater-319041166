using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        protected List<MenuItem> m_MenuItems;
        protected string m_MenuName;

        public MainMenu(string i_MenuName)
        {
            m_MenuItems = new List<MenuItem>();
            m_MenuName = i_MenuName;
        }

        public List<MenuItem> MenuItems
        {
            get { return m_MenuItems; }
       //     set { m_MenuItems = value; } do we need?
        }

        public string MenuName
        {
            get { return m_MenuName; }
            set { m_MenuName = value; }
        }

        public void Show()
        {
            RunMenu();
        }

        public void AddComponent(MenuItem i_MenuItem)
        {
            m_MenuItems.Add(i_MenuItem);
        }

        protected void RunMenu()
        {
            bool quit = false;

            while (!quit)
            {
                printMenu();
                int choice = getUserChoice();
                if (choice == 0)
                {
                    quit = true;
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    m_MenuItems[choice - 1].ItemIsChosen();
                }
            }
        }

        private void printMenu()
        {
            Console.WriteLine(m_MenuName);
            for (int i = 0; i < m_MenuItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {m_MenuItems[i].MenuName}");
            }

            Console.WriteLine("0. Exit");
        }

        private int getUserChoice()
        {
            int userChoice;
            int i_MaxValue = m_MenuItems.Count();
            string input;

            Console.WriteLine("Please enter your choice:");
            input = Console.ReadLine();
            while (!int.TryParse(input, out userChoice) || userChoice < 0 || userChoice > i_MaxValue)
            {
                Console.WriteLine("Invalid choice. Please try again:");
                input = Console.ReadLine();
            }

            return userChoice;
        }
    }
}
