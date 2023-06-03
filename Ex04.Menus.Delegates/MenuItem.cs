using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class MenuItem 
    {
        private const int k_ReturnButton = 0;
        private const char k_TitlesChar = '=';
        protected List<MenuItem> m_SubMenus;
        protected string m_Title;

        public event Action Selected;

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
                    printMenu();
                    int choice = getUserChoice();
                    if (choice == k_ReturnButton)
                    {
                        quit = true;
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        m_SubMenus[choice - 1].OnSelected();
                    }
                }
            }
            else
            {
                throw new FormatException("Cannot run an empty menu!");
            }
        }

        protected virtual string GetReturnButton()
        {
            return "Back";
        }

        protected virtual void OnSelected()
        {
            if (m_SubMenus != null)
            {
                RunMenu();
            }
            else if (Selected != null)
            {
                Selected.Invoke();
            }
        }

        private int getUserChoice()
        {
            int userChoice;
            int numOfOptions = m_SubMenus.Count;
            string input;

            Console.WriteLine("Please enter your choice:");
            input = Console.ReadLine();
            while (!int.TryParse(input, out userChoice) || userChoice < 0 || userChoice > numOfOptions)
            {
                Console.WriteLine("Invalid choice. Please try again:");
                input = Console.ReadLine();
            }

            return userChoice;
        }

        private void printMenu()
        {
            printAsTitle(m_Title);
            for (int i = 0; i < m_SubMenus.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {m_SubMenus[i].Title}");
            }

            Console.WriteLine("{0}. {1}", k_ReturnButton, GetReturnButton());
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
    }
}
