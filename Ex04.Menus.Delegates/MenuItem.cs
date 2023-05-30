using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    internal class MenuItem
    {
        string m_Title;
        List<MenuItem> m_SubMenus;
        MenuItem m_PreviousMenu;

        public event Action<MenuItem> WasChosen;

        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        public MenuItem PreviousMenu
        {
            get { return m_PreviousMenu; }
        }

        private void OnWasChosen(MenuItem i_Item)
        {
            if (WasChosen == null)
            {
                WasChosen.Invoke(this);
            }
        }
    }
}
