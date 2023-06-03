using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MainMenu : MenuItem
    {
        private const string k_MainTitle = "Main Menu";

        public MainMenu() : base(k_MainTitle)
        {
        }   

        public void Show()
        {
            RunMenu();
        }

        public void AddComponent(MenuItem i_MenuItem)
        {
            AddSubMenu(i_MenuItem);
        }

        protected override string GetReturnButton()
        {
            return "Exit";
        }
    }
}
