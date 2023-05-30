using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        string m_Title;
        List<MenuItem> m_SubMenus;
        MenuItem m_Parent;

        public event Action<MenuItem> Method;


        public MenuItem(string i_Title, MenuItem i_Parent)
        {
            Title = i_Title;
            Parent = i_Parent;
        }

        public MenuItem(string i_Title, MenuItem i_Parent, Action<MenuItem> i_Method)
        {
            Title = i_Title;
            Parent = i_Parent;
            Method += i_Method;
        }

        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        public MenuItem Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; }
        }

        public MenuItem PreviousMenu
        {
            get { return m_Parent; }
        }

        public void ItemIsChosen()
        {
            OnItemClicked();
        }

        public void AddSubMenu(MenuItem i_Parent)
        {
            MenuItem newMenuItem = new MenuItem(i_MenuTitle, this);
            m_SubMenus.Add(newMenuItem);
        }

        protected virtual void OnItemClicked()
        {
            if (Method != null)
            {
                Method.Invoke(this);
            }
            else
            {
                printSubMenusAndGetUserChoice();
            }
        }

        private void printSubMenusAndGetUserChoice()
        {
            int userChoice;

            Console.WriteLine(m_Title);
            printMenus();
            userChoice = getUserChoice();
            m_SubMenus[userChoice - 1].ItemIsChosen();
        }

        private void printMenus()
        {
            Console.WriteLine(m_Title);
            for(int i = 0; i < m_SubMenus.Count; i++)
            {
                Console.WriteLine($"{i}. {m_SubMenus[i].Title}");
            }

            Console.WriteLine("0. {0}", Parent == null ? "Exit" : "Back");
        }

        private int getUserChoice()
        {
            Console.WriteLine("Please enter your choice");
            string input = Console.ReadLine();
            
            return int.Parse(input);
        }
    }
}





/*
 * 
 * 
 * 
 * MenuItem item;
 * 
 * item.ItemClicked += function;
 * 
 * 
 * 
 * void function()
 * {
}
*/