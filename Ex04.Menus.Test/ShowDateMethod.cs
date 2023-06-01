using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Test
{
    internal class ShowDateMethod : Interfaces.ILeafMethod
    {
        public void WhenSelected()
        {
            DateTime currentDate = DateTime.Today;
            Console.WriteLine("Current Date: " + currentDate.ToString("dd-MM-yyyy"));
        }
    }
}
