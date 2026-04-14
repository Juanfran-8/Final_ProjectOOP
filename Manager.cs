using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_ProjectOOP
{
    public class Manager : Worker
    {
        private int teamSize;
        public Manager(int id, string name, int experienceYears, int tasksCompleted, int teamSize) : base(id, name, experienceYears, tasksCompleted)
        {
            this.teamSize = teamSize;
        }

        public int getTeamSize()
        {
            return this.teamSize;
        }

        public void SetTeamSize(int teamSize)
        {
            this.teamSize = teamSize;
        }

        public int GetTeamSize()
        { 
            return this.teamSize; 
        }

        public override void PerformTask()
        {
            AddTask();
            Console.WriteLine($"{GetName()} is managing a team of {this.teamSize} workers.");
        }

        public Worker FindBestWorker(List<Worker> workers)
        {
            if (workers == null || workers.Count == 0) // haz el check con el get available workers
            {
                return null;
            }
            Worker bestWorker = workers[0];

            foreach (Worker worker in workers)
            {
                if (worker.CalculatePerformance() > bestWorker.CalculatePerformance())
                {
                    bestWorker = worker;
                }
            }

            return bestWorker;
        }

        public override void Display()
        {
            Console.WriteLine($"Manager ID: {GetId()}, Name: {GetName()}, ExperienceYears: {GetExperienceYears()}, TasksCompleted: {GetTasksCompleted()}, Team Size: {this.teamSize}, Performance: {CalculatePerformance()}");
        }
    }
}