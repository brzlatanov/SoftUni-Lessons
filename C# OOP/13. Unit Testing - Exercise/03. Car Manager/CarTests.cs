using System;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Tests
{
    public class CarTests
    {
        private Car testCar;
        [SetUp]
        public void Setup()
        {
            testCar = new Car("Chevrolet", "Aveo", 8, 60);
        }

        [Test] // CTOR
        public void Ctor_IsInitializedWithTheCorrectValues()
        {
            Assert.IsTrue(testCar.Make == "Chevrolet");
            Assert.IsTrue(testCar.Model == "Aveo");
            Assert.IsTrue(testCar.FuelConsumption == 8);
            Assert.IsTrue(testCar.FuelCapacity == 60);
            Assert.IsTrue(testCar.FuelAmount == 0);
        }
        [Test] // SETTERS 
        [TestCase("")]
        [TestCase(null)]
        public void Car_MakeFieldSetterThrowsExceptionWhenPassedEmptyOrNullValue(string make)
        {
            // if null or empty
            Assert.Throws<ArgumentException>(() => testCar = new Car(make, "Aveo", 8, 60));

        }
      
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Car_ModelFieldSetterThrowsExceptionWhenPassedEmptyOrNullValue(string model)
        {
            // if null or empty
            Assert.Throws<ArgumentException>(() => testCar = new Car("Chevrolet", model, 8, 60));

        }
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(null)]
        public void Car_FuelConsumptionFieldSetterThrowsExceptionWhenPassedEmptyOrNullValue(double fuelConsumption)
        {
            // if null or empty
            Assert.Throws<ArgumentException>(() => testCar = new Car("Chevrolet", "Aveo", fuelConsumption, 60));

        }
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(null)]
        public void Car_FuelCapacityFieldSetterThrowsExceptionWhenPassedEmptyOrNullValue(double fuelCapacity)
        {
            // if null or empty
            Assert.Throws<ArgumentException>(() => testCar = new Car("Chevrolet", "Aveo", 8, fuelCapacity));

        }
        [Test]
        public void Car_FuelAmountFieldSetterThrowsExceptionWhenPassedEmptyOrNullValue()
        {
            // always initializes with 0 by default
            Assert.IsTrue(testCar.FuelAmount == 0);
        }

        [Test] // REFUEL
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(null)]
        public void Car_RefuelShouldThrowExceptionWhenPassedNullOrEmptyValue(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>(() => testCar.Refuel(fuelToRefuel));
        }
        [Test]
        public void Car_RefuelShouldIncreaseFuelAmountWhenArgumentIsLessThanCapacity()
        {
            testCar.Refuel(50.5);
            Assert.That(testCar.FuelAmount == 50.5);
        }
        [Test]
        public void Car_RefuelShouldEqualMaxCapacityWhenArgumentIsMoreThanCapacity()
        {
            testCar.Refuel(70.5);
            Assert.That(testCar.FuelAmount == 60);
        }
        [Test]
        public void Car_DriveShouldThrowExceptionIfDistanceIsTooBig()
        {
            testCar = new Car("Chevrolet", "Aveo", 10, 10);
            testCar.Refuel(10);
            Assert.Throws<InvalidOperationException>(() => testCar.Drive(101));
        }
        [Test]
        public void Car_DriveShouldExecuteSuccessfullyIfDistanceIsSmallerAndFuelIsProperlyReduced()
        {
            testCar = new Car("Chevrolet", "Aveo", 10, 10);
            testCar.Refuel(10);
            testCar.Drive(100);
            Assert.That(testCar.FuelAmount == 0);
        }
    }
}