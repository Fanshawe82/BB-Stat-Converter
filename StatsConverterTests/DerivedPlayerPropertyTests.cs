using Microsoft.VisualStudio.TestTools.UnitTesting;
using BBAdvancedStatsConverter;

namespace StatsConverterTests
{
    [TestClass]
    public class DerivedPlayerPropertyTests
    {
        Player testPlayer;

        [TestInitialize]
        public void createPlayer()
        {
            testPlayer = new Player();
            
        }  

        [TestMethod]
        public void CalulatePointsTest()
        {
            //Arrange
            double expectedPoints = 35;

            //Act
            testPlayer.FieldGoalsMade = 10;
            testPlayer.ThreePointersMade = 5;
            testPlayer.FreeThrowsMade = 10;

            //Assert
            Assert.AreEqual(expectedPoints, testPlayer.Points);

        }
        [TestMethod]
        public void CalculateZeroPointsTest()
        {
            //Arrange
            double expectedPoints = 0;

            //Act
            testPlayer.FieldGoalsMade = 0;
            testPlayer.ThreePointersMade = 0;
            testPlayer.FreeThrowsMade = 0;

            //Assert
            Assert.AreEqual(expectedPoints, testPlayer.Points);
        }
        [TestMethod]
        public void TrueShootPercentTest()
        {
            //Arrange
            testPlayer.FieldGoalsMade = 7;
            testPlayer.FieldGoalsAttempted = 15;
            testPlayer.ThreePointersMade = 4;
            testPlayer.ThreePointersAttempted = 9;
            testPlayer.FreeThrowsMade = 11;
            testPlayer.FreeThrowsAttempted = 11;
            string expectedString = "0.731";

            Assert.AreEqual(expectedString, testPlayer.TrueShootPercent);

        }
        [TestMethod]
        public void TrueShootNaNTest()
        {
            //This should be caught by my input validations, but just in case
            //Arrange
            testPlayer.FieldGoalsMade = 1;
            testPlayer.FieldGoalsAttempted = 0;
            testPlayer.FreeThrowsAttempted = 0;
            string expectedString = " --- ";

            //Asert
            Assert.AreEqual(expectedString, testPlayer.TrueShootPercent);

        }
        [TestMethod]
        public void EffectiveFGTest()
        {
            testPlayer.FieldGoalsMade = 4;
            testPlayer.FieldGoalsAttempted = 11;
            testPlayer.ThreePointersMade = 2;
            testPlayer.ThreePointersAttempted = 3;

            string expectedString = "0.455";

            Assert.AreEqual(expectedString, testPlayer.EffectiveFG);
        }
        [TestMethod]
        public void ThreePointAttemptRateTest()
        {
            testPlayer.FieldGoalsAttempted = 19;
            testPlayer.ThreePointersAttempted = 3;

            string expectedString = "0.158";

            Assert.AreEqual(expectedString, testPlayer.ThreePointRate);
        }
        [TestMethod]
        public void FreeThrowAttemptRateTest()
        {
            testPlayer.FieldGoalsAttempted = 6;
            testPlayer.FreeThrowsAttempted = 2;

            string expectedString = "0.333";

            Assert.AreEqual(expectedString, testPlayer.FreeThrowRate);
                
        }
        [TestMethod]
        public void FreeThrowRateUndefinedTest()
        {
            testPlayer.FieldGoalsAttempted = 0;
            testPlayer.FreeThrowsAttempted = 2;

            string expectedString = " --- ";

            Assert.AreEqual(expectedString, testPlayer.FreeThrowRate);
        }
        [TestMethod]
        public void TurnoverRateTest()
        {
            testPlayer.Turnovers = 4;
            testPlayer.FieldGoalsAttempted = 13;
            testPlayer.FreeThrowsAttempted = 3;

            string expectedString = "21.8";

            Assert.AreEqual(expectedString, testPlayer.TurnOverRate);
        }
    }
}
