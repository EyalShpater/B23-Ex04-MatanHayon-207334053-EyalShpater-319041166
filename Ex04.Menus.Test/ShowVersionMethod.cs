using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
