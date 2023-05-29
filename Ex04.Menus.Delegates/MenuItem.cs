using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    internal class MenuItem
    {
        string m_Name;
        List<MenuItem> m_SubMenus;
        Action MenuMethod;
        MenuItem m_PreviousMenu;



    }
}
