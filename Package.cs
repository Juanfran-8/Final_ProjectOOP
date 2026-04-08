using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_ProjectOOP
{
    public class Package
    {
        private int id;
        private double weight;
        private int priorityLevel;
        private string destination;
        private string status; //pending, assigned, delivered 

        public Package(int id, double weight, int priorityLevel, string destination, string status)
        {
            this.id = id;
            this.weight = weight;
            this.priorityLevel = priorityLevel;
            this.destination = destination;
            this.status = status;
        }

        public int GetId()
        {
            return id;
        }

        public double GetWeight()
        {
            return weight;
        }

        public int GetPriorityLevel()
        {
            return priorityLevel;
        }

        public string GetDestination()
        {
            return destination;
        }

        public string GetStatus()
        {
            return status;
        }

        public double CalculatePriorityScore()
        {
            return (priorityLevel * 10) + weight; 
        }

        public void UpdateStatus(string newStatus)
        {
            if (newStatus == "pending" || newStatus == "assigned" || newStatus == "delivered")
            {
                status = newStatus;
            }
            else
            {
                Console.WriteLine("Invalid status.");
            }
        }

        public bool IsHeavy()
        {
            return weight > 20.0;
        }
    }
}