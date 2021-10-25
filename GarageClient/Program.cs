using Entities;
using Entities.Model;
using Logic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository;
using System;
using System.Configuration;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string garage_Levels= ConfigurationManager.AppSettings["Garage_Levels"];
            string garage_Spots_Per_Level = ConfigurationManager.AppSettings["Garage_Spots_Per_Level"];
            int.TryParse(garage_Levels, out int _levelCount);
            int.TryParse(garage_Spots_Per_Level , out int _spotCountPerLevel);

            GarageManager.StartSimulation(_levelCount, _spotCountPerLevel);
        }
      
    }
}
