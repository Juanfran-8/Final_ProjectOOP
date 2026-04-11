using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

        //el save para el Ifile
        public string GetName()
        { 
            return name; 
        }

        public List<Package> GetPackages()
        { 
            return packages; 
        }

        public List<Vehicle> GetVehicles()
        {
            return packages;
        }

        public List<Worker> GetWorkers()
        {
            return workers;
        }

        public void AddVehicle(Vehicle v)
        {
            vehicles.Add(v);
        }

        public void AddWorkers(Worker w)
        {
            workers.Add(w);
        }

        public void AddPackage(Package p)
        {
            packages.Add(p);
        }
        public void RemovePackage(int packageid)
        {
            for (int i = 0; i < packages.Count; i++)
            {
                packages.RemoveAt(i);
                Console.WriteLine($"This package: {packageid} removed from warehouse.");
            }
            Console.WriteLine($"This package: {packageid} was not found in the warehouse. ");


        }

        public Vehicle FindBestVehicle(Package p)
        {
            Vehicle bestVehicle = null;
            double bestEfficiency = -1.0;
            foreach (var v in vehicles)
            {
                if (v.GetIsAvailable() && v.GetRemainingCapacity() >= p.GetWeight())
                {
                    double effiency = v.CalculateEfficiency();
                    if (effiency > bestEfficiency)
                    {
                        bestEfficiency = effiency;
                        bestVehicle = v;
                    }
                }

            } 
            return bestVehicle;
        }

        public Worker AssignWorker()
        {
            for (int i = 0; i < workers.Count; i++)
            {
                if (workers[i].GetIsAvailable())
                {
                    return workers[i];
                }

            }
            return null;
        }

        public List<Package> GetPendingPackages()
        {
            List<Package> pendingPackagesList = new List<Package>();
            for (int i = 0; i < this.packages.Count; i++)
            {
                if (this.packages[i].GetStatus() == "pending")
                {
                    pendingPackagesList.Add(this.packages[i]);
                }
            }
            return pendingPackagesList;
        }

    }
}