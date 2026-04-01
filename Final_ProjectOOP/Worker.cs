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





      


        public abstract void PerformTask();

    }
}
