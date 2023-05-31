using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class MenuItem : MainMenu
    {
        private Action m_Action;

        public MenuItem(string i_MenuName, Action i_Action) : base(i_MenuName)
        {
            m_Action = i_Action;
        }

        public void AddSubMenu(MenuItem i_MenuItem)
        {
            m_MenuItems.Add(i_MenuItem);
        }


        public void ItemIsChosen()
        {
            if (m_Action != null)
            {
                m_Action.Invoke();
            }
            else
            {
                RunMenu();
            }
        }
    }
}
