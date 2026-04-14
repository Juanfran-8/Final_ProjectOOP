using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_ProjectOOP
{
    public class DeliverySystem : ISortable, IFileHandler
    {
        List <Warehouse> warehouses;
        List <Package> allPackages;

        public DeliverySystem() //Inicializar en constructor
        {
            warehouses = new List <Warehouse>();
            allPackages = new List <Package>(); 
        }
        public void Save(string path)
        {
            using (StreamWriter sw = new StreamWriter(path)) 
            {
                foreach (Package p in allPackages) 
                {
                    sw.WriteLine($"PACKAGE|{p.GetId()}|{p.GetWeight()}|{p.GetPriorityLevel()}|{p.GetDestination()}|{p.GetStatus()}");
                }
                foreach (Warehouse wh in warehouses)
                {
                    foreach (Worker w in wh.GetWorkers())
                    {
                        if (w is Driver d)
                        {
                            sw.WriteLine($"WORKER | Driver|{d.GetId()}|{d.GetName()}|{d.GetExperienceYears()}|{d.GetTasksCompleted()}|{d.GetLicenseType()}");
                        }
                    
                    else if (w is Loader l)               
                    {
                        sw.WriteLine($"WORKER | Loader|{l.GetId()}|{l.GetName()}|{l.GetExperienceYears()}|{l.GetTasksCompleted()}|{l.GetMaxLiftWeight()}");
                    }
                    else if (w is Manager m)                    
                    {
                        sw.WriteLine($"WORKER | Manager|{m.GetId()}|{m.GetName()}|{m.GetExperienceYears()}|{m.GetTasksCompleted()}|{m.GetTeamSize()}");
                    }
                }
            }
        }
    }
        public void Load(string path) //
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("File not found.");
                return;
            }
            allPackages.Clear();
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts[0] == "PACKAGE")
                {
                    int id = int.Parse(parts[1]);
                    double weight = double.Parse(parts[2]);
                    int priorityLevel = int.Parse(parts[3]);    
                    string destination = parts[4];  
                    string status = parts[5];

                    Package p = new Package(id, weight, priorityLevel, destination, status);
                    p.UpdateStatus(status);
                    allPackages.Add(p); 
                }
            }
        }
        public void AddWarehouse(Warehouse w)
        {
            warehouses.Add(w);
        }
        public void AddPackage(Package p)
        {
                allPackages.Add(p);
        }
        public Package SearchPackageById(int id) //en public porque si es como privado no lo va a poder llamar
        {
            foreach (Package p in allPackages)
            {
                if (p.GetId() == id)
                {
                    return p;
                }
            }
            return null;
        }
        public void ProcessDelivery()
        {
            CustomQueue<Package> waitingSystem = new CustomQueue<Package>();
            foreach (var p in allPackages)
            {
                if (p.GetStatus() == "pending")
                {
                    waitingSystem.Enqueue(p); 
                }
            }
            Console.WriteLine("Starting the delivery");
            while(!waitingSystem.IsEmpty())
            {
                Package p = waitingSystem.Dequeue();
                bool delivered = false;
                foreach (var w in warehouses)
                {
                    Vehicle v = w.FindBestVehicle(p);
                    Worker e = w.AssignWorker();
                    if (v != null && e != null)
                    {
                        p.UpdateStatus("assigned"); 
                        v.SetIsAvailable(false);
                        e.SetIsAvailable(false);
                        v.Deliver(new List<Package> {p});
                        e.PerformTask();                       
                        if (p.GetStatus() == "delivered") //para no forzar el delivered 
                        {
                            delivered = true;
                        }
                        v.SetIsAvailable(true);
                        e.SetIsAvailable(true);
                        if (delivered)
                        {
                            break;
                        }
                        else
                        {
                            p.UpdateStatus("pending");
                        }
                    }
                }
                if (!delivered)
                {
                    Console.WriteLine($"Package:{p.GetId()} is not delivered. Not enough vehicles/workers ");
                }
            }
        }

        public void RemovePackage(int id)
        {
            for (int i = 0; i < allPackages.Count; i++)
            {
                if (allPackages[i].GetId() == id)
                {
                    allPackages.RemoveAt(i);
                    return;
                }
            }
        }

        public void SimulateDay()
        {
            Console.WriteLine("== Simulation of a day in the delivery system ==");
            Sort();
            ProcessDelivery();
            Console.WriteLine("\n==== Simulation end ====");



        }
        public void Sort()
        {
            int all = allPackages.Count;
            for (int i = 0; i < all - 1; i++)
            {
                for (int j = 0; j < all - i - 1; j++)
                {
                    if (allPackages[j].CalculatePriorityScore() < allPackages[j + 1].CalculatePriorityScore()) 
                    {
                        var temp = allPackages[j];
                        allPackages[j] = allPackages[j + 1];
                        allPackages[j + 1] = temp;
                    }
                }

            }
            Console.WriteLine("Changes made succesfully");
        }
    }
}
