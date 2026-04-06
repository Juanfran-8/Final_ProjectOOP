using System;
using System.Collections.Generic;
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

        public string GetStatus() => status;
        public int GetId() => id;

        public string GetDestination() => destination;







        public Package(int id, double weight, int priorityLevel, string destination, string status)
        {
            this.id = id;
            this.weight = weight;
            this.priorityLevel = priorityLevel;
            this.destination = destination;
            this.status = "pending";
        }

        public double CalculatePriorityScore()
        {
            return (priorityLevel * 10) + weight; 
        }

        public void UpdateStatus(string newStatus)
        {

            this.status = newStatus;
        }

        public bool IsHeavy()
        {
            return weight > 20.0;
        }


    }
}
