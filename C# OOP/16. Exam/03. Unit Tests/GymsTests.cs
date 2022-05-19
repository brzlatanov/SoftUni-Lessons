using System;
using NUnit.Framework;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        // Implement unit tests here
        private Gym gym;
        [SetUp]
        public void Init()
        {
            gym = new Gym("Flais", 100);
        }
        [Test]
        public void Gym_CtorShouldInitializeAllFields()
        {
            Assert.That(gym.Name == "Flais");
            Assert.That(gym.Capacity == 100);
            Assert.That(gym.Count == 0);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Gym_CtorShouldThrowExceptionIfNameIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() => gym = new Gym(name, 15), "Invalid gym name.");
            //throw new ArgumentNullException(nameof(value), "Invalid gym name.");
        }
        [Test]
        public void Gym_CtorShouldThrowExceptionIfCapacityIsUnderZero()
        {
            Assert.Throws<ArgumentException>(() => gym = new Gym("Flais", -1), "Invalid gym capacity.");
            Assert.Throws<ArgumentException>(() => gym = new Gym("Flais", -2), "Invalid gym capacity.");
            //throw new ArgumentException("Invalid gym capacity.");
        }
        [Test]
        public void Gym_AddAthleteShouldIncreaseCount()
        {
            gym.AddAthlete(new Athlete("Ivan Ivanov"));
            gym.AddAthlete(new Athlete("Boyan Zlatanov"));
            Assert.That(gym.Count == 2);
        }
        [Test]
        public void Gym_AddAthleteShouldAddAthleteSuccessfully()
        {
            gym.AddAthlete(new Athlete("Boyan Zlatanov"));
            Assert.That(gym.Count == 1);
            gym.RemoveAthlete("Boyan Zlatanov");
            Assert.That(gym.Count == 0);
        }
        [Test]
        public void Gym_AddAthleteShouldThrowExceptionIfGymIsAtCapacity()
        {
            gym = new Gym("Flais", 1);
            gym.AddAthlete(new Athlete("Boyan Zlatanov"));
            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(new Athlete("Ivan Ivanov")), "The gym is full.");
            //throw new InvalidOperationException("The gym is full.");
        }

        [Test]
        public void Gym_RemoveAthleteShouldThrowExceptionIfAthleteDoesNotExist()
        {
            gym.AddAthlete(new Athlete("Boyan Zlatanov"));
            gym.AddAthlete(new Athlete("Ivan Ivanov"));
            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Petar Petrov"), "The athlete Petar Petrov doesn't exist.");
            //throw new InvalidOperationException($"The athlete {fullName} doesn't exist.");
        }

        [Test]
        public void Gym_InjureAthleteShouldChangeIsInjuredToTrue()
        {
            Athlete athlete = new Athlete("Boyan Zlatanov");
            gym.AddAthlete(athlete);
            gym.InjureAthlete("Boyan Zlatanov");
            Assert.That(athlete.IsInjured);
        }

        [Test]
        public void Gym_InjureAthleteShouldReturnTheAthlete()
        {
            Athlete athlete = new Athlete("Boyan Zlatanov");
            gym.AddAthlete(athlete);
            var result = gym.InjureAthlete("Boyan Zlatanov");
            Assert.AreEqual(result, athlete);
        }

        [Test]
        public void Gym_InjureAthleteShouldThrowExceptionIfAthleteDoesNotExist()
        {
            gym.AddAthlete(new Athlete("Boyan Zlatanov"));
            gym.AddAthlete(new Athlete("Ivan Ivanov"));
            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Petar Petrov"), "The athlete Petar Petrov doesn't exist.");
            //throw new InvalidOperationException($"The athlete {fullName} doesn't exist.");
        }

        [Test]
        public void Gym_ReportShouldReturnTheCorrectString()
        {
            gym.AddAthlete(new Athlete("Boyan Zlatanov"));
            gym.AddAthlete(new Athlete("Ivan Ivanov"));
            gym.AddAthlete(new Athlete("Petar Petrov"));

            string expectedResult = "Active athletes at Flais: Boyan Zlatanov, Ivan Ivanov, Petar Petrov";
            string actualResult = gym.Report();
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void Gym_ReportShouldExcludeInjuredAthletesFromTheString()
        {
            gym.AddAthlete(new Athlete("Boyan Zlatanov"));
            gym.AddAthlete(new Athlete("Ivan Ivanov"));
            gym.AddAthlete(new Athlete("Petar Petrov"));
            gym.InjureAthlete("Boyan Zlatanov");

            string expectedResult = "Active athletes at Flais: Ivan Ivanov, Petar Petrov";
            string actualResult = gym.Report();
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void Gym_ReportShouldReturnBlankIfNoAthletesAreInGym()
        {
            string expectedResult = "Active athletes at Flais: ";
            string actualResult = gym.Report();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
