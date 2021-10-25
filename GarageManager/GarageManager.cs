using Entities;
using Entities.Model;

using Repository;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;

namespace Logic
{
    public class GarageManager
    {

        public static void StartSimulation(int levelCount, int spotCountPerLevel)
        {
            try
            {
                RepositoryWrapper _wrapper = new RepositoryWrapper(new RepositoryContext());

                //Initiate The Garage with 2 levels , each with 3 spots
                var garage = new GarageSimulation(levelCount, spotCountPerLevel);
                _wrapper.GarageRepo.Create(garage);
                _wrapper.Save();

                var stillAvailable = true;
                while (stillAvailable) // While(true) is not recommended , but for the sake of simulation
                {

                    //Car with  license plate of 6 random strings
                    var vehicle = new Car(Utility.RandomString(6));
                    //Save The Car in our In-Memory DB , for later usage/statistics/logging
                    _wrapper.CarRepo.Create(vehicle);
                    //Assign the car a free space in our Garage, or reject it
                    (bool IsInside,GarageSpot spot ) = _wrapper.GarageRepo.EnterVehicle(vehicle);
                    if (IsInside)
                    {
                        Console.WriteLine("A Vehicle with License Plate " + vehicle.LicensePlate + " has entered " + spot.SpotNumber + " spot");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine("The Garage rejected the Vehicle with License Plate " + vehicle.LicensePlate);
                        stillAvailable = false;
                    }

                    _wrapper.Save();

                }
                Console.Write("Please press any Key to exit");
                Console.ReadLine();
            }
            catch (ValidationException ex)
            {
                Console.WriteLine(ex.Message);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                
            }
           
        }
     


    }
}
