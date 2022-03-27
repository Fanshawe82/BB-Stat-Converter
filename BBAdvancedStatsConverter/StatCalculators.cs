using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBAdvancedStatsConverter
{
    public class StatCalculators
    {
        private readonly BBStatsCLI display = new BBStatsCLI();


        public void Run()
        {
            bool calculateStats = true;
            Player activePlayer = new Player();
            while (calculateStats == true)  
            {
                display.DisplayMainMenu();
                int input = display.AcceptInt("\nPlease make your selection: ", 0, 1); 
                if (input == 0)
                {
                    return;
                }

                else
                {
                    activePlayer = CreatePlayer();
                    display.Pause();
                }                                                    
                                
                StatOutput(activePlayer);
                                
                int displayInput = display.DisplayClosingMenu();
                if (displayInput == 0)
                {
                    Console.WriteLine("\nThank you for using the Advanced Basketball Stats Calculator!");
                    calculateStats = false;
                }
                
                else if (displayInput == 1)
                {
                    display.DisplayStatDefinitions();
                    int userInput = display.AcceptInt("\n\nSelect (1) to begin again or (0) to exit", 0, 1);
                    if (userInput == 0)
                    {
                        calculateStats = false;
                    }
                    else if (userInput == 1)
                    {
                        calculateStats = true;
                    }
                }
                
                else if (displayInput == 2)
                {
                    calculateStats = true; 
                }
                
                    
                              
            }
        }           
        public Player CreatePlayer()
        {
            Console.Clear();
            
            Player activePlayer = new Player();
            
            activePlayer.Name = display.AcceptString("Please Enter the Player's Name: ");
            activePlayer.FieldGoalsMade = display.AcceptDouble("Enter Player's Total Field Goals Made: ", 0, Double.PositiveInfinity);
            activePlayer.FieldGoalsAttempted = display.AcceptDouble("Enter Player's Total Field Goal Attempts: ", activePlayer.FieldGoalsMade, Double.PositiveInfinity);
            activePlayer.ThreePointersMade = display.AcceptDouble("Enter Player's Three Point Shots Made: ", 0, activePlayer.FieldGoalsMade);
            activePlayer.ThreePointersAttempted = display.AcceptDouble("Enter Player's Three Point Shot Attempts: ", activePlayer.ThreePointersMade, activePlayer.FieldGoalsAttempted);
            activePlayer.FreeThrowsMade = display.AcceptDouble("Enter Player's Free Throws Made: ", 0, Double.PositiveInfinity);
            activePlayer.FreeThrowsAttempted = display.AcceptDouble("Enter Player's Free Throw Attempts: ", activePlayer.FreeThrowsMade, Double.PositiveInfinity);
            activePlayer.Turnovers = display.AcceptDouble("Enter Player's Number Of Turnovers: ", 0, Double.PositiveInfinity);
            Console.WriteLine("\nThank You! Calculating Advanced Stats...\n");
            return activePlayer;
        }

        public void StatOutput(Player player)
        {
            Console.Clear();
            Console.WriteLine("\n");
            Console.WriteLine($"{player.Name.ToUpper()}: Basic");
            Console.WriteLine("===========================================");
            Console.WriteLine($"   FG/FGA  |  3PM/3PA  |  FTM/FTA  |  TO");
            Console.WriteLine("===========================================");
            Console.WriteLine($"   {player.FieldGoalsMade}/{player.FieldGoalsAttempted}       {player.ThreePointersMade}/{player.ThreePointersAttempted}         {player.FreeThrowsMade}/{player.FreeThrowsAttempted}        {player.Turnovers}");
            Console.WriteLine("===========================================");
            Console.WriteLine("\n");
            Console.WriteLine($"{player.Name.ToUpper()}: Advanced");
            Console.WriteLine("===========================================");
            Console.WriteLine($"   TS%  |  eFG%  |  3PAr  |  FTr  |  TOV%");
            Console.WriteLine("===========================================");
            Console.WriteLine($"  {player.TrueShootPercent}   {player.EffectiveFG}    {player.ThreePointRate}    {player.FreeThrowRate}    {player.TurnOverRate}");
            Console.WriteLine("\n");
        }

       


    }
}

   
