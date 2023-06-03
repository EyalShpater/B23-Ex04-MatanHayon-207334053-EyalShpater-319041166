using System;

namespace Ex04.Menus.Test
{
    internal class ShowTimeMethod : Interfaces.ILeafMethod
    {
        public void WhenSelected()
        {
            DateTime currentTime = DateTime.Now;
            Console.WriteLine("Current Time: " + currentTime.ToString("HH:mm:ss"));
        }
    }
}
