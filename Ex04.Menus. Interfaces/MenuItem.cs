using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private const int k_ReturnButton = 0;
        private const char k_TitlesChar = '*';
        protected List<MenuItem> m_SubMenus;
        protected List<ILeafMethod> m_LeafMethods;
        protected string m_Title;

        public MenuItem(string i_Title)
        {
            Title = i_Title;
        }

        public string Title
        {
            get
            {
                return m_Title;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    m_Title = value;
                }
                else
                {
                    throw new FormatException("Title cannot be empty!");
                }
            }
        }

        public void AddSubMenu(MenuItem i_MenuItem)
        {
            if (m_SubMenus == null)
            {
                m_SubMenus = new List<MenuItem>();
            }

            m_SubMenus.Add(i_MenuItem);
        }

        protected void RunMenu()
        {
            if (m_SubMenus != null)
            {
                bool quit = false;

                while (!quit)
                {
                    PrintMenu();
                    int choice = GetUserChoice();
                    if (choice == k_ReturnButton)
                    {
                        quit = true;
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        m_SubMenus[choice - 1].WhenSelected();
                    }
                }
            }
            else
            {
                throw new FormatException("Cannot run an empty menu!");
            }
        }

        protected void WhenSelected()
        {
            if (m_SubMenus != null)
            {
                RunMenu();
            }
            else if (m_LeafMethods != null)
            {
                RunLeafMethods();
            }
        }

        protected int GetUserChoice()
        {
            int userChoice;
            int maxValue = m_SubMenus.Count;
            string input;

            Console.WriteLine("Please enter your choice:");
            input = Console.ReadLine();
            while (!int.TryParse(input, out userChoice) || userChoice < 0 || userChoice > maxValue)
            {
                Console.WriteLine("Invalid choice. Please try again:");
                input = Console.ReadLine();
            }

            return userChoice;
        }

        protected void PrintMenu()
        {
            printAsTitle(m_Title);
            for (int i = 0; i < m_SubMenus.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {m_SubMenus[i].Title}");
            }

            Console.WriteLine("{0}. {1}", k_ReturnButton, GetReturnButton());
        }

        protected virtual string GetReturnButton()
        {
            return "Back";
        }

        private static void printAsTitle(string i_FunctionName)
        {
            printLineOfSameChars(k_TitlesChar, i_FunctionName.Length);
            Console.WriteLine(i_FunctionName);
            printLineOfSameChars(k_TitlesChar, i_FunctionName.Length);
        }

        private static void printLineOfSameChars(char i_WantedChar, int i_NumOfPrintsInLine)
        {
            for (int i = 0; i < i_NumOfPrintsInLine; i++)
            {
                Console.Write(i_WantedChar);
            }

            Console.WriteLine();
        }

        public void AddLeafMethod(ILeafMethod i_LeafMenu)
        {
            if (m_LeafMethods == null)
            {
                m_LeafMethods = new List<ILeafMethod>();
            }

            m_LeafMethods.Add(i_LeafMenu);
        }

        public void RemoveLeafMethod(ILeafMethod i_LeafMenu)
        {
            m_LeafMethods?.Remove(i_LeafMenu);
        }

        public void RunLeafMethods()
        {
            foreach (ILeafMethod method in m_LeafMethods)
            {
                method.WhenSelected();
            }
        }
    }
}