using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Final_ProjectOOP
{
    public abstract class Entity
    {
        private int id;
        private string name;
        private int Datetime;
        private int createdDate;

        public int GetId() { return id; }
        public string GetName() { return name; }
        public int GetDatetime() { return Datetime; }

        public int GetCreatedDate() { return createdDate; }


        public void SetId(int id) { this.id = id; }
        public void SetName(string name) { this.name = name; }

        public void SetDatetime(int date) { this.Datetime = date; }

        public void SetCreatedDate(int date) { this.createdDate = date; }




        public virtual bool Validate()
        {
            if (Datetime <= 0)
            {
                Console.WriteLine("Datetime must be a valid timestamp.");
                return false;
            }
            if (createdDate <= 0)
            {
                Console.WriteLine("Created Date must be a valid timestamp.");
                return false;
            }
            return true;
        }


        public abstract void Display();
      
        






    }
}
