using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_ProjectOOP
{
     public abstract class Vehicle : Entity
    {
       private double speed;
       private double maxCapacity;
       private double currentLoad;
       private bool isAvailable;

        protected Vehicle(int id, string name, double speed, double maxCapacity) : base(id, name)
        {
           
           this.speed = speed;
           this.maxCapacity = maxCapacity;
            this.currentLoad = 0;
            isAvailable = true;


        }

        public double GetSpeed() { return speed; }
        public double GetMaxCapacity() { return maxCapacity; }
        public double GetCurrentLoad() { return currentLoad; }
        public bool GetIsAvailable() { return isAvailable; }
        public void SetSpeed(double speed) { this.speed = speed; }
        public void SetCapacity(double capacity)
        {
            if (capacity > 0)
            {
                Console.WriteLine("Max Capacity must be greater than zero.");
                return;
            }
            this.maxCapacity = capacity;
        }
        public void SetCurrentLoad(double currentLoad) { this.currentLoad = currentLoad; }

        public void SetIsAvailable(bool isAvailable) { this.isAvailable = isAvailable; }


        public double GetRemainingCapacity()
        {
            return maxCapacity - currentLoad;
        }

        
        public virtual double CalculateEfficiency()
        {
            if (speed <= 0)
            {
                Console.WriteLine("Speed must be greater than zero to calculate efficiency.");
                return 0;
            }
            return speed / (currentLoad + 1);
        }

        public abstract void Deliver(List<Package> packages) ; 
        

        public override void Display()
        {
            Console.WriteLine($"VEHICULE id: {GetId()} , Name:{GetName()} ,  Speed: {GetSpeed()}km/h ,  Max Capacity: {GetMaxCapacity()}kg,  Current Load: {GetCurrentLoad()} kg"); 
        }






    }
}
