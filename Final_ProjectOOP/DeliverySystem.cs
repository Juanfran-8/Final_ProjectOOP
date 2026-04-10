using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_ProjectOOP
{
    public class DeliverySystem
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

public void SortPackages(List <Package> list)
{
    for (int i = 0; i < list.Count - 1; i++)
    {
        for (int j = 0; j < list.Count - i - 1; j++)
        {
            if (list[j].CalculatePriorityScore() > list[j + 1].CalculatePriorityScore())
            {
                var temp = list[j];
                list[j] = list[j + 1];
                list[j + 1] = temp;
            }
        }

    }

}
public void ProcessDelivery() // finalizar este método para processar el envio 
{
    foreach (var w  in warehouses)
    {
        
    }

}

public void SimulateDay()
{
    Console.WriteLine("== Simulation of a day in the delivery system ==");
    ProcessDelivery();
    Console.WriteLine("\n==== Simulation end ====");



}
    }
}
