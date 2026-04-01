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


        //falata un metodo para calcular lo que queda de capacidad
        public double GetSpeed() { return speed; }
        public double GetMaxCapacity() { return maxCapacity; }
        public double GetCurrentLoad() { return currentLoad; }
        public bool GetIsAvailable() { return isAvailable; }
        public void SetSpeed(double speed) { this.speed = speed; }
        public void SetMaxCapacity(double maxCapacity)
        {
            if (maxCapacity <= 0)
            {
                Console.WriteLine("Max Capacity must be greater than zero.");
                return;
            }
            this.maxCapacity = maxCapacity;
        }
        public void SetCurrentLoad(double currentLoad) { this.currentLoad = currentLoad; }

        public void SetIsAvailable(bool isAvailable) { this.isAvailable = isAvailable; }

        // Tenemos que calcular la efivciencia de un vehiculo, basado en velocidad y carga 
        public virtual double CalculateEfficiency()
        {
            if (speed <= 0)
            {
                Console.WriteLine("Speed must be greater than zero to calculate efficiency.");
                return 0;
            }
            return speed / maxCapacity;
        }
       
        //ublic abstract void Deliver(List<Package> packages); Terminar este metodo 




    }
}
