using NUnit.Framework;

namespace Robots.Tests
{
    using System;
    [TestFixture]
    public class RobotsTests
    {
        private Robot robot;
        private Robot robotTwo;
        private Robot robotThree;
        private RobotManager robotManager;

        [SetUp]
        public void RobotInit()
        {
           robot = new Robot("C3P0", 100);
           robotTwo = new Robot("K2SO", 200);
           robotThree = new Robot("BB8", 50);
           robotManager = new RobotManager(10);
        }

        [Test]
        public void Robot_CtorMustInitializeProperValues()
        {
            Assert.That(robot.Name == "C3P0");
            Assert.That(robot.Battery == 100);
            Assert.That(robot.MaximumBattery == 100);
            Assert.AreEqual(robot.Battery, robot.MaximumBattery);
        }

        [Test]
        public void RobotManager_CtorMustInitializeProperValues()
        {
            Assert.That(robotManager.Capacity == 10);
            Assert.That(robotManager.Count == 0);
        }
        [Test]
        public void RobotManager_SettingCapacityBelowZeroShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => robotManager = new RobotManager(-1), "Invalid capacity!");
        }

        [Test]
        public void RobotManager_AddRobotShouldAddItSuccessfully()
        {
            robotManager.Add(robotTwo);
            Assert.That(robotManager.Count == 1);
        }
        [Test]
        public void RobotManager_AddRobotShouldThrowExceptionIfNameIsNotUnique()
        {
            robotManager.Add(robot);
            robotManager.Add(robotTwo);
            robotThree = new Robot("C3P0", 100);
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robotThree), $"There is already a robot with name {robotThree.Name}!");
        }

        [Test]
        public void RobotManager_AddingRobotShouldThrowExceptionIfManagerIsAtCapacity()
        {
            robotManager = new RobotManager(2);
            robotManager.Add(robot);
            robotManager.Add(robotTwo);
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robotThree), "Not enough capacity!");
        }

        [Test]
        public void RobotManager_RemovingRobotShouldThrowExceptionIfNameDoesNotExist()
        {
            robotManager.Add(robot);
            robotManager.Add(robotTwo);
            Assert.Throws<InvalidOperationException>(() => robotManager.Remove("BeepBoop"));
        }
        [Test]
        public void RobotManager_RemovingRobotShouldSuccessfullyRemoveRobotByName()
        {
            robotManager.Add(robot);
            Assert.That(robotManager.Count == 1);
            robotManager.Remove("C3P0");
            Assert.That(robotManager.Count == 0);
        }
        [Test]
        public void RobotManager_WorkShouldThrowExceptionIfRobotNameDoesNotExist()
        {
            robotManager.Add(robotThree);
            robotManager.Add(robotTwo);
            Assert.Throws<InvalidOperationException>(() => robotManager.Work("C3P0", "Mine Bitcoin", 30), $"Robot with the name C3P0 doesn't exist!");
        }
        [Test]
        public void RobotManager_WorkShouldThrowExceptionIfRobotBatteryIsLessThanBatteryUsage()
        {
            robotManager.Add(robotTwo);
            Assert.Throws<InvalidOperationException>(() => robotManager.Work("K2SO", "Mine Bitcoin", 201), $"K2SO doesn't have enough battery!");
        }
        [Test]
        public void RobotManager_WorkShouldReduceRobotBattery()
        {
            robotManager.Add(robotTwo); 
            robotManager.Work("K2SO", "Mine Bitcoin", 200);
            Assert.AreEqual(robotTwo.Battery, 0);
        }
        [Test]
        public void RobotManager_ChargeShouldThrowExceptionIfRobotNameDoesNotExist()
        {
            robotManager.Add(robot);
            robotManager.Add(robotTwo);
            Assert.Throws<InvalidOperationException>(() => robotManager.Charge("BeepBoop"), $"Robot with the name BeepBoop doesn't exist!");
        }
        [Test]
        public void RobotManager_ChargeShouldSuccessfullyChargeRobot()
        {
            robotManager.Add(robot);
            robotManager.Work("C3P0", "Work", 50);
            Assert.That(robot.Battery == 50);
            robotManager.Charge("C3P0");
            Assert.That(robot.Battery == 100);
        }
    }
}
