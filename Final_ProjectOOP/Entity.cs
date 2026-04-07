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
        private DateTime createdDate;

        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }

        public int GetId() { return id; }
        public string GetName() { return name; }

        public void SetId(int id) { this.id = id; }
        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Name cannot be empty.");
            }
            this.name = name;
        }

        protected Entity(int id, string name)
        {
            SetId(id);
            SetName(name);
            this.createdDate= DateTime.Now;

        }


        public virtual bool Validate() //check
        {
            return id > 0 && !string.IsNullOrEmpty(name);
        }


        public abstract void Display();
    }
}
