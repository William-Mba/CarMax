using CarMax.Domain.Cars;
using CarMax.Domain.Enums;
using NUnit.Framework;
using System.Collections.Generic;

namespace Test.Domain
{
    [TestFixture]
    public class CarTests
    {
        public Car? _car;

        [SetUp]
        public void Setup()
        {
            _car = new Car();
        }

        [Test]
        public void TestSetAndGetId()
        {
            _car!.id = GivenCar().id;

            Assert.That(_car.id, Is.EqualTo(GivenCar().id));

        }

        [Test]
        public void TestSetAndGetBrand()
        {
            _car!.Brand = GivenCar().Brand;

            Assert.That(_car.Brand, Is.EqualTo(GivenCar().Brand));
        }

        [Test]
        public void TestSetAndGetCostType()
        {
            _car!.CostType = GivenCar().CostType;

            Assert.That(_car.CostType, Is.EqualTo(GivenCar().CostType));
        }

        [Test]
        public void TestSetAndGetDescription()
        {
            _car!.Description = GivenCar().Description;

            Assert.That(_car.Description, Is.EqualTo(GivenCar().Description));
        }

        [Test]
        public void TestSetAndGetImageGallery()
        {
            _car!.ImageGallery = GivenCar().ImageGallery;

            Assert.That(_car.ImageGallery, Is.EqualTo(GivenCar().ImageGallery));
        }

        [Test]
        public void TestSetAndGetLocation()
        {
            _car!.Location = GivenCar().Location;

            Assert.That(_car.Location, Is.EqualTo(GivenCar().Location));
        }

        [Test]
        public void TestSetAndGetModel()
        {
            _car!.Model = GivenCar().Model;

            Assert.That(_car.Model, Is.EqualTo(GivenCar().Model));
        }

        [Test]
        public void TestSetAndGetRentCost()
        {
            _car!.RentCost = GivenCar().RentCost;

            Assert.That(_car.RentCost, Is.EqualTo(GivenCar().RentCost));
        }

        [Test]
        public void TestSetAndGetYear()
        {
            _car!.Year = GivenCar().Year;

            Assert.That(_car.Year, Is.EqualTo(GivenCar().Year));
        }
        public Car GivenCar()
        {
            var images = new Dictionary<string, string>() {
                { "Front", "imageUri_1" },
                { "Back", "imageUri_2" },
                { "Left", "imageUri_3" },
                { "Right", "imageUri_4" }
            };

            return new Car
            {
                id = "B03B4989-B1E7-454E-B178-7861F426753E",
                Brand = "Test_Brand",
                CostType = CostType.Daily,
                Description = "Test_Description",
                ImageGallery = images,
                Location = "Test_Location",
                Model = "Test_Model",
                RentCost = 50m,
                Year = 2020
            };
        }
    }
}
