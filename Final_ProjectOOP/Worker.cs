using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_ProjectOOP
{
    public abstract class Worker : Entity
    {
        
        private int experienceYears;
        private int tasksCompleted;
        private bool isAvailable;

        
        protected Worker(int id, string name, int experienceYears, int tasksCompleted) : base(id, name)
        {
            this.experienceYears = experienceYears;
            this.tasksCompleted = tasksCompleted;
            this.isAvailable = true;
            
        }


        public void AddTask()
        {
            tasksCompleted++;
        }

        public virtual double CalculatePerformance()
        {
            return (experienceYears * 1.5 ) + tasksCompleted;
        }
        public abstract void PerformTask();


    }
}
