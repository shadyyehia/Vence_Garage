using Entities;
using Entities.Model;
using Logic;
using Repository;
using System;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace GarageTests
{
    public class GarageSimulationTests
    {
        [Theory]
        [InlineData(0,0)]
        [InlineData(0, 1)]       
        public void Should_GarageLevelsAreOneOrMore(int levels, int spaces)
        {
            try
            {
                RepositoryWrapper _wrapper = new RepositoryWrapper(new RepositoryContext());
                var garage = new GarageSimulation(levels, spaces);
                _wrapper.GarageRepo.Create(garage);
                _wrapper.Save();
            }
            catch (ValidationException ex)
            {
                Assert.Equal("Please set Garage Levels in configuration file to be at least 1", ex.Message);
            }
            //var ex = Assert.Throws<ValidationException>(()=> GarageManager.StartSimulation(levels, spaces));
            //Assert.Equal("", ex.Message);
        }


        [Theory]
        [InlineData(1, 0)]
        public void Should_GarageSpacesAreOneOrMore(int levels, int spaces)
        {
            try
            {
                RepositoryWrapper _wrapper = new RepositoryWrapper(new RepositoryContext());
                var garage = new GarageSimulation(levels, spaces);
                _wrapper.GarageRepo.Create(garage);
                _wrapper.Save();
            }
            catch (ValidationException ex)
            {
                Assert.Equal("Please set Garage Spots in configuration file to be at least 1", ex.Message);
            }
            //var ex = Assert.Throws<ValidationException>(()=> GarageManager.StartSimulation(levels, spaces));
            //Assert.Equal("", ex.Message);
        }

        [Fact]
        public void Should_GarageAcceptCar()
        {

            RepositoryWrapper _wrapper = new RepositoryWrapper(new RepositoryContext());
            //1 level , 3 spots
            var garage = new GarageSimulation(1, 3);
            _wrapper.GarageRepo.Create(garage);
            _wrapper.Save();

            var vehicle = new Car("Test");
            //Save The Car in our In-Memory DB , for later usage/statistics/logging
            _wrapper.CarRepo.Create(vehicle);
            //Assign the car a free space in our Garage, or reject it
            (bool IsInside, GarageSpot spot) = _wrapper.GarageRepo.EnterVehicle(vehicle);
            Assert.True(IsInside);
            Assert.Equal("[0 - 0]", spot.SpotNumber);
            
        }

        [Fact]
        public void Should_GarageAcceptMotorBike()
        {

            RepositoryWrapper _wrapper = new RepositoryWrapper(new RepositoryContext());
            //1 level , 3 spots
            var garage = new GarageSimulation(1, 1);
            _wrapper.GarageRepo.Create(garage);
            _wrapper.Save();

            var vehicle = new Motorbike("Test");
            //Save The Car in our In-Memory DB , for later usage/statistics/logging
            _wrapper.MotorBikeRepo.Create(vehicle);
            //Assign the car a free space in our Garage, or reject it
            (bool IsInside, GarageSpot spot) = _wrapper.GarageRepo.EnterVehicle(vehicle);
            Assert.True(IsInside);
            Assert.Equal("[0 - 0]", spot.SpotNumber);

        }

        [Fact]
        public void Should_GarageRejectExtraVehicle()
        {

            RepositoryWrapper _wrapper = new RepositoryWrapper(new RepositoryContext());
            //1 level , 3 spots
            var garage = new GarageSimulation(1, 1);
            _wrapper.GarageRepo.Create(garage);
            _wrapper.Save();

            var vehicle = new Motorbike("Test");
            //Save The Car in our In-Memory DB , for later usage/statistics/logging

            //Assign the car a free space in our Garage, or reject it
            (bool IsInside, GarageSpot spot) = _wrapper.GarageRepo.EnterVehicle(vehicle);
            (bool IsInside1, GarageSpot spot1) = _wrapper.GarageRepo.EnterVehicle(new Car("extra"));
            Assert.False(IsInside1);
        }
    }
}
