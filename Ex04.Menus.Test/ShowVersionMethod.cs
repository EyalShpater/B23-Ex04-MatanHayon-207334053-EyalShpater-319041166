using System;

namespace Ex04.Menus.Test
{
    internal class ShowVersionMethod : Interfaces.ILeafMethod
    {
        public void WhenSelected()
        {
            Console.WriteLine("Version: 23.2.4.9805");
        }
    }
}
