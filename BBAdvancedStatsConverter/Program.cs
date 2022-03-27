using System;

namespace BBAdvancedStatsConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BBStatsCLI display = new BBStatsCLI();
            StatCalculators stats = new StatCalculators();

            display.DisplayIntro();
            display.Pause();
            
            
            stats.Run();
            
        }
    }
}
