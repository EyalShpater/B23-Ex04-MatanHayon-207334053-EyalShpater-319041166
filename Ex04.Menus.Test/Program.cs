using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex04.Menus;

namespace Ex04.Menus.Test
{
    internal class Program
    {
        public static void Main()
        {
            buildAndRunMenu();
        }

        private static void buildAndRunMenu()
        {
            Delegates.MainMenu mainMenu = new Delegates.MainMenu("Main Menu");
            
            Delegates.MenuItem showDateMenu = new Delegates.MenuItem("Show Date", displayCurrentDate);
            Delegates.MenuItem showTimeMenu= new Delegates.MenuItem("Show Time",displayCurrentTime);
            Delegates.MenuItem dateTimeMenu = new Delegates.MenuItem("Show Date/Time",null);
            dateTimeMenu.AddComponent(showDateMenu);
            dateTimeMenu.AddComponent(showTimeMenu);
            mainMenu.AddComponent(dateTimeMenu);
            
            Delegates.MenuItem versionsAndCapitalsMenu = new Delegates.MenuItem("Versions and capitals",null);
            mainMenu.AddComponent(versionsAndCapitalsMenu);
        
            mainMenu.Show();
        }

        public static void displayCurrentDate()
        {
            DateTime currentDate = DateTime.Today;
            Console.WriteLine("Current Date: " + currentDate.ToString("yyyy-MM-dd"));
        }

        public static void displayCurrentTime()
        {
            DateTime currentTime = DateTime.Now;
            Console.WriteLine("Current Time: " + currentTime.ToString("HH:mm:ss"));
        }

    }
}
