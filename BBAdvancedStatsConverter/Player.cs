using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBAdvancedStatsConverter
{
    public class Player
    {
        public string Name { get; set; }
        
        public double FieldGoalsMade { get; set; } = 0;
        public double FieldGoalsAttempted { get; set; } = 0;
        public double ThreePointersMade { get; set; } = 0;
        public double ThreePointersAttempted { get; set; } = 0;
        public double FreeThrowsMade { get; set; } = 0;
        public double FreeThrowsAttempted { get; set; } = 0;
        public double Turnovers { get; set; } = 0;

        public double Points
        {
            get
            {
                return FieldGoalsMade * 2 + ThreePointersMade + FreeThrowsMade;
            }
        }

        public string EffectiveFG
        {
            get
            {
                return CaclulateEffectiveFG();
            }
        }
        public string TrueShootPercent
        {
            get
            {
                return CalculateTrueShooting();
            }
        }
        public string ThreePointRate
        {
            get
            {
                return CalculateThreePointAttemptRate();
            }
        }
        public string FreeThrowRate
        {
            get
            {
                return CalculateFreeThrowRate();
            }
        }
        public string TurnOverRate
        {
            get
            {
               return CaluclateTOPercent();
            }
        } 
        //result.toString(F3)
        private string CalculateTrueShooting()
        {
            double trueSPercent = (Points / (2 * (FieldGoalsAttempted + (0.44 * FreeThrowsAttempted))));
            if (Double.IsNaN(trueSPercent) || trueSPercent == Double.PositiveInfinity)
            {
                return " --- ";
            }
            else
            {
                return trueSPercent.ToString("F3");
            }
        }

        private string CalculateThreePointAttemptRate()
        {
            
            double threePointAttemptPercent = ThreePointersAttempted / FieldGoalsAttempted;
            if (Double.IsNaN(threePointAttemptPercent) || threePointAttemptPercent == Double.PositiveInfinity)
            {
                return " --- ";
            }
            else
            {
                return threePointAttemptPercent.ToString("F3");
            }
        }

        private string CalculateFreeThrowRate()
        {
            double ftRate = FreeThrowsAttempted / FieldGoalsAttempted;
            if (Double.IsNaN(ftRate) || ftRate == Double.PositiveInfinity)
            {
                return " --- ";
            }
            else
            {
                return ftRate.ToString("F3");
            }
        }

        private string CaclulateEffectiveFG()
        {
            double effectiveFG = ((FieldGoalsMade + (ThreePointersMade / 2)) / FieldGoalsAttempted);
            if (Double.IsNaN(effectiveFG) || effectiveFG == Double.PositiveInfinity)
            {
                return " --- ";
            }
            else
            {
                
                return effectiveFG.ToString("F3");
            }
        }

        private string CaluclateTOPercent()
        {
            double tovPercent = (Turnovers / (FieldGoalsAttempted + (0.44 * FreeThrowsAttempted) + Turnovers));
            if (Double.IsNaN(tovPercent) || tovPercent == Double.PositiveInfinity)
            {
                return "---";
            }
            else
            {
                return (100.0 * tovPercent).ToString("F1");
            }
        }

    }
}
