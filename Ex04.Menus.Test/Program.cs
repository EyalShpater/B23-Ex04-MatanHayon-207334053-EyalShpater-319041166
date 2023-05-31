using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
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
            try
            {


                Delegates.MainMenu mainMenu = new Delegates.MainMenu();

                Delegates.MenuItem showDateMenu = new Delegates.MenuItem("Show Date");
                showDateMenu.Selected += DisplayCurrentDate;

                Delegates.MenuItem showTimeMenu = new Delegates.MenuItem("Show Time");
                showTimeMenu.Selected += DisplayCurrentTime;

                Delegates.MenuItem dateTimeMenu = new Delegates.MenuItem("Show Date/Time");
                dateTimeMenu.AddSubMenu(showDateMenu);
                dateTimeMenu.AddSubMenu(showTimeMenu);
                mainMenu.AddComponent(dateTimeMenu);

                Delegates.MenuItem countSpaces = new Delegates.MenuItem("Count Spaces");
                countSpaces.Selected += DisplayNumOfSpacesInSentence;

                Delegates.MenuItem showVersion = new Delegates.MenuItem("Show Version");
                showVersion.Selected += ShowVersion;

                Delegates.MenuItem versionsAndCapitalsMenu = new Delegates.MenuItem("Versions and Spaces");
                versionsAndCapitalsMenu.AddSubMenu(showVersion);
                versionsAndCapitalsMenu.AddSubMenu(countSpaces);

                mainMenu.AddComponent(versionsAndCapitalsMenu);
                mainMenu.Show();
            }

            catch (Exception i_Exception)
            {
                Console.WriteLine(i_Exception.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }
        }

        public static void DisplayCurrentDate()
        {
            DateTime currentDate = DateTime.Today;
            Console.WriteLine("Current Date: " + currentDate.ToString("yyyy-MM-dd"));
        }

        public static void DisplayCurrentTime()
        {
            DateTime currentTime = DateTime.Now;
            Console.WriteLine("Current Time: " + currentTime.ToString("HH:mm:ss"));
        }

        public static void  DisplayNumOfSpacesInSentence()
        {
            string input;

            Console.WriteLine("Please write a sentence");
            input = Console.ReadLine();
            Console.WriteLine("There are {0} spaces in your sentence.", countNumOfSpacesInSentence(input));
        }

        private static int countNumOfSpacesInSentence(string i_Sentence)
        {
            int count = 0;

            for (int i = 0; i < i_Sentence.Length; i++)
            {
                if (i_Sentence.ElementAt(i) == ' ')
                {
                    count++;
                }
            }

            return count;
        }

        public static void ShowVersion()
        {
            Console.WriteLine("Version: 23.2.4.9805");
        }
    }
}
