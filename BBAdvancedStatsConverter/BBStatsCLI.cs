using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBAdvancedStatsConverter
{
    public class BBStatsCLI
    {
        public void DisplayIntro()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@"                      =_-___");
            Console.WriteLine(@"                    o    \__ \");
            Console.WriteLine(@"                   o       __| \");
            Console.WriteLine(@"                    o      \__  \");
            Console.WriteLine(@"                      oooo    \  \");
            Console.WriteLine(@"                               \  \");
            Console.WriteLine(@" __________________             |   \");
            Console.WriteLine(@"|__________________|             \   |");
            Console.WriteLine(@" \/\/\/\/\/\/\/\/\/     _----_    |   |");
            Console.WriteLine(@"  \/\/\/\/\/\/\/\/     |      \   |   |");
            Console.WriteLine(@"   \/\/\/\/\/\/\/      |       |    |  |");
            Console.WriteLine(@"    |/\/\/\/\/\|        |       \__/    |");
            Console.WriteLine(@"    |/\/\/\/\/\|         __---          |");
            Console.WriteLine(@"    |/\/\/\/\/\|       /   \            |");
            Console.WriteLine(@"                      |     |          |");
            Console.WriteLine(@"                      |   /            |");
            Console.WriteLine(@"                      |   \            |");
            Console.WriteLine(@"                      |   | \          |");
            Console.WriteLine(@"                      |   |   \____-----\");
            Console.WriteLine(@"                      |   |    \____-----");
            Console.WriteLine(@"                       |  |    |          \");
            Console.WriteLine(@"                       |  |   |             \");
            Console.WriteLine(@"                        \  \_|_      |       |");
            Console.WriteLine(@"                         \____/  ___/ \_____/\");
            Console.WriteLine(@"                            /    /       \     \");
            Console.WriteLine(@"                          /     /          \     \");
            Console.WriteLine(@"                         /    /              \    \");
            Console.WriteLine(@"                       /    /                  \    \");
            Console.WriteLine(@"                      /   /                      \   \");
            Console.WriteLine(@"                /\   /  /                          \  |");
            Console.WriteLine(@"               |  \/ \/                              \/ \");
            Console.WriteLine(@"                \    |                             __/   |");
            Console.WriteLine(@"                  \_/                            /______/");
            Console.WriteLine("==========================================================");
            Console.WriteLine("        Welcome to the BasketBall Stats Converter");
            Console.WriteLine("==========================================================");
            Console.WriteLine("   Transform Any Boxscore Into An Analytical Instrument");
            Console.WriteLine("==========================================================\n");
            Console.ResetColor();
        }

        public void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("\nThis program will convert a player's regular stats into advanced metrics.");
            Console.WriteLine("You can enter the player's statistics from a single game, a full season, or an entire career.\n");
            Console.WriteLine("Select: (1) to begin entering player information");
            Console.WriteLine("\tOR");
            Console.WriteLine("Select: (0) to exit");
        }

        //public string getPlayerName()
        //{
        //    string message = "Please the name of the player whose statistics you would like to convert: ";
        //    return AcceptString(message);
        //}


        public int DisplayStatsSelectionMenu()
        {
            return AcceptInt("Select: (1) to see basic stats\n\tOR\nSelect: (2) for advanced metrics\n\tOR\nSelect: (0) to exit", 0, 2);

        }

        public int DisplayClosingMenu()
        {
            Console.WriteLine("Select: (1) to see definitions of the advanced stats");
            Console.WriteLine("\tOR");
            Console.WriteLine("Select: (2) to enter stats for a new player");
            Console.WriteLine("\tOR");
            Console.WriteLine("Select: (0) to exit program");
            return AcceptInt("\nPlease enter your selection: ", 0, 2);
        }
        public void DisplayStatDefinitions()
        {
            Console.WriteLine("\nDEFINITIONS");
            Console.WriteLine("TS% - True Shooting Percentage: a measure of shooting efficiency that takes into acount");
            Console.WriteLine("\tfield goals, three-point field goals, and free throws.\n");
            Console.WriteLine("eFG% - Effective Field Goal Percentage: adjusts FG% to account for extra points gained");
            Console.WriteLine("\tfrom three-point field goals.\n");
            Console.WriteLine("3PAr - Percentage of total field goal attemtps taken from three-point range.\n");
            Console.WriteLine("FTr - Free throw attempts taken per field goal attempt\n");
            Console.WriteLine("TOV% - An estimate of turnovers committed per 100 plays");

        }
       


        public string AcceptString(string message)
        {
            while (true)
            {
                Console.WriteLine($"{message}");
                string input = Console.ReadLine();
                if (input.Trim().Length > 0)
                {
                    return input;
                }
            }
        }

        public double AcceptDouble(string message, double minimum, double maximum)
        {
            while (true)
            {
                Console.Write($"{message}");
                string input = Console.ReadLine();

                //Int parsing to check for data integrity: All game data used by this program
                //should be integers >= 0
                
                //Converting to double here because they all will be invovled in caculations that
                //require Doubles as answers
                if (int.TryParse(input, out int value) && value >= minimum && value <= maximum)
                {
                    double result = (double)value;
                    return result;
                }
                PrintErrorMessage("Invalid number entered. Please double check your data try again.\n");
            }
        }


        //Using this one for menu options: max/min to limit to valid choices
        public int AcceptInt(string message, int minimum, int maximum)
        {
            while (true)
            {
                Console.Write($"{message}");
                string input = Console.ReadLine();
                                
                if (int.TryParse(input, out int value) && value >= minimum && value <= maximum)
                {
                    int result = value;
                    return result;
                }
                PrintErrorMessage("Invalid number entered. Please try again.\n");
            }
        }

        


        public void Pause(string message = null)
        {
            if (message == null)
            {
                message = "Press any key to continue\n";
            }
            Console.Write(message);
            Console.ReadKey();

        }

        public void PrintErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{message}");
            Console.ResetColor();
        }

        public void PrintSuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{message}");
            Console.ResetColor();
        }

    }

   
}
