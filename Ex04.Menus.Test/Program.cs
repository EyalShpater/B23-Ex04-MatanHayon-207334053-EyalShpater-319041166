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
            BuildAndRunDelegatesMenu();
            BuildAndRunInterfaceMenu();
        }

        public static void BuildAndRunDelegatesMenu()
        {
            try
            {
                Delegates.MainMenu mainMenu = new Delegates.MainMenu();

                Delegates.MenuItem showDateMenu = new Delegates.MenuItem("Show Date");
                showDateMenu.Selected += showDateMenu_Selected;

                Delegates.MenuItem showTimeMenu = new Delegates.MenuItem("Show Time");
                showTimeMenu.Selected += showTimeMenu_Selected;

                Delegates.MenuItem dateTimeMenu = new Delegates.MenuItem("Show Date/Time");
                dateTimeMenu.AddSubMenu(showDateMenu);
                dateTimeMenu.AddSubMenu(showTimeMenu);

                Delegates.MenuItem countSpaces = new Delegates.MenuItem("Count Spaces");
                countSpaces.Selected += countSpaces_Selected;

                Delegates.MenuItem showVersion = new Delegates.MenuItem("Show Version");
                showVersion.Selected += showVersion_Selected;

                Delegates.MenuItem versionsAndCapitalsMenu = new Delegates.MenuItem("Versions and Spaces");
                versionsAndCapitalsMenu.AddSubMenu(showVersion);
                versionsAndCapitalsMenu.AddSubMenu(countSpaces);

                mainMenu.AddComponent(dateTimeMenu);
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

        public static void BuildAndRunInterfaceMenu()
        {
            Interfaces.MainMenu mainMenu = new Interfaces.MainMenu();

            Interfaces.MenuItem showDateMenu = new Interfaces.MenuItem("Show Date");
            showDateMenu.AddLeafMethod(new ShowDateMethod());

            Interfaces.MenuItem showTimeMenu = new Interfaces.MenuItem("Show Time");


            
            mainMenu.Show();


        }

        private static void showDateMenu_Selected()
        {
            DateTime currentDate = DateTime.Today;
            Console.WriteLine("Current Date: " + currentDate.ToString("dd-MM-yyyy"));
        }

        private static void showTimeMenu_Selected()
        {
            DateTime currentTime = DateTime.Now;
            Console.WriteLine("Current Time: " + currentTime.ToString("HH:mm:ss"));
        }

        private static void  countSpaces_Selected()
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

        private static void showVersion_Selected()
        {
            Console.WriteLine("Version: 23.2.4.9805");
        }
    }
}
