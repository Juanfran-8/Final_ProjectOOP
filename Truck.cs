using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_ProjectOOP
{
    public class Truck : Vehicle
    {
        double fuelConsumption;

        public Truck(int id, string name, double speed, double maxCapacity, double fuelConsumption) : base(id, name, speed, maxCapacity)
        {
            this.fuelConsumption = fuelConsumption;
        }



        // void override deliver 
        public override double CalculateEfficiency()
        {
            
            return base.CalculateEfficiency() / (fuelConsumption + 0.1);
        }

        public override void Deliver(List<Package> packages)
        {
           Console.WriteLine($" {GetName()} is processing heavy deliveries");

            foreach (var package in packages)
            {
                if (package.IsHeavy() && package.GetStatus() == "pending")
                {
                    package.UpdateStatus("delivered");
                    Console.WriteLine($"Truck Delivered package H ID: {package.GetId()} to {package.GetDestination()}");
                }
                
            }
        }
         public override void Display()
        {
            Console.WriteLine($"Truck ID: {GetId()}, Name: {GetName()}, Speed: {GetSpeed()} km/h, Max Capacity: {GetMaxCapacity()} kg, Current Load: {GetCurrentLoad()} kg, Fuel Consumption: {fuelConsumption} L/100km");
        }
    }
}
