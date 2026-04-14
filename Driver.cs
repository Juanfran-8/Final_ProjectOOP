using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_ProjectOOP
{
    internal class Driver : Worker
    {
        private string licenseType;
        public Driver(int id, string name, int experienceYears, int tasksCompleted, string licenseType) : base(id, name, experienceYears, tasksCompleted)
        {
            this.licenseType = licenseType;
        }

        public string GetLicenseType()
        {
            return this.licenseType;

        }

        public override void PerformTask()
        {
            AddTask();

            Console.WriteLine($"{GetName()} is driving a vehicle with license type {this.licenseType}.");
        }

        public override void Display()
        {
            Console.WriteLine($"Driver ID: {GetId()}, Name: {GetName()}, ExperienceYears: {GetExperienceYears()}, Tasks Completed: {GetTasksCompleted()}, License Type: {this.licenseType}, Performance: {CalculatePerformance()}");
        }
    }
}