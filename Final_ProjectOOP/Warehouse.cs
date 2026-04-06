using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_ProjectOOP
{
    public class Warehouse
    {
        private string name;
        private List<Package> packages;
        private List<Vehicle> vehicles;
        private List<Worker> workers;

        public Warehouse(string name)
        {
            this.name = name;
            this.packages = new List<Package>();
            this.vehicles = new List<Vehicle>();
            this.workers = new List<Worker>();
        }

        public void AddPackage(Package p)
        {
            packages.Add(p);
        }

    }
}
