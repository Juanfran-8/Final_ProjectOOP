using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_ProjectOOP
{
    public class DeliverySystem : ISortable
    {
        List <Warehouse> warehouses;
        List <Package> allPackages;

        public void AddWarehouse(Warehouse w)
        {
            warehouses.Add(w);
        }

        public void AddPackage(Package p)
        {
                allPackages.Add(p);
        }

        Package SearchPackageById(int id)
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
                        v.Deliver(new List<Package> {p});
                        e.PerformTask();
                        p.UpdateStatus("delivered");
                        v.SetIsAvailable(false);
                        e.SetIsAvailable(false);
                        delivered = true;
                        break;
                    }

                }
                if (!delivered)
                {
                    Console.WriteLine($"Package: {p.GetId()} is not delivered. Not enough vehicles/workers ");
                }
            }

        }



        public void SimulateDay()
        {
            Console.WriteLine("== Simulation of a day in the delivery system ==");
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
                    if (allPackages[j].CalculatePriorityScore() > allPackages[j + 1].CalculatePriorityScore())
                    {
                        var temp = allPackages[j];
                        allPackages[j] = allPackages[j + 1];
                        allPackages[j + 1] = temp;
                    }
                }

            }
            throw new InvalidDataException("system sorted");
        }
    }
}
