using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_ProjectOOP
{
    public class Loader : Worker
    {
        private double maxLiftWeight;

        public Loader(int id, string name, int experienceYears, int tasksCompleted, double maxLiftWeight) : base(id, name, experienceYears, tasksCompleted)
        {
            this.maxLiftWeight = maxLiftWeight;
        }

        public double GetMaxLiftWeight()
        {
            return maxLiftWeight;
        }

        public void SetMaxLiftWeight(double weight)
        {
            maxLiftWeight = weight;
        }

        public override void PerformTask()
        {
            AddTask();
            Console.WriteLine($"{GetName()} is loading and unloading packages, with a maximum lift weight of {maxLiftWeight} kg.");
        }

        public override void Display()
        {
            Console.WriteLine($"Loader ID: {GetId()}, Name: {GetName()}, Max Lift Weight: {maxLiftWeight} kg, Performance: {CalculatePerformance()}");
        }
    }
}
