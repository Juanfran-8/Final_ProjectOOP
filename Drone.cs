using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_ProjectOOP
{
    public class Drone : Vehicle
    {
        double maxDistance;
        public Drone(int id, string name, double speed, double maxCapacity, double maxDistance) : base(id, name, speed, maxCapacity)
        {
            this.maxDistance = maxDistance;
        }
        public override void Deliver(List<Package> packages)
        {
            Console.WriteLine($" {GetName()} is processing light deliveries");
            foreach (var package in packages)
            {
                if (!package.IsHeavy() && package.GetStatus() == "pending")
                {
                    package.UpdateStatus("delivered");
                    Console.WriteLine($"Drone delivered package S ID: {package.GetId()} to {package.GetDestination()}");
                }
            }
        }

        public override double CalculateEfficiency()
        {
            return (GetSpeed() * maxDistance / 100);
        }
    }
}