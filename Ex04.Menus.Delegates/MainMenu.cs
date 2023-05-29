using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    internal class MainMenu
    {
        MenuItem m_MainMenu = new MenuItem();

        public void stam()
        {
            m_MainMenu.MenuMethod += firstMenuFunc();
        }

        public void fisrtMenuFunc()
        {

        }
    }
}
