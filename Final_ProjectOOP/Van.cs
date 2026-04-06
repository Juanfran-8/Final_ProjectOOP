using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_ProjectOOP
{
    public class Van : Vehicle
    {
        private bool electric;

        public Van(int id, string name, double speed, double maxCapacity, bool electric) : base(id, name, speed, maxCapacity)
        {
            this.electric = electric;
        }

        public override void Deliver(List<Package> packages)
        {
            Console.WriteLine($" {GetName()} is processing heavy deliveries");

            foreach (var package in packages)
            {
                if (!package.IsHeavy() && package.GetStatus() == "pending")
                {
                    package.UpdateStatus("delivered");
                    Console.WriteLine($"Van delivered package M ID: {package.GetId()} to {package.GetDestination()}");
                }

            }
        }

    }
}
