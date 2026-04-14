using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Final_ProjectOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Conectar warehouse, sistema principal y stack para el undo
            DeliverySystem system = new DeliverySystem();
            Warehouse mainWarehouse = new Warehouse("Main Warehouse");
            system.AddWarehouse(mainWarehouse);
            CustomStack<Package> undoStack = new CustomStack<Package>();    
            
            //TESTING CODE (PARA CHECAR QUE SI COMPILA) 
            /*Truck truck1 = new Truck(5001, "Truck A", 80, 100, 12);
            Van van1 = new Van(6001, "Van A", 40, 50, true);
            Driver driver1 = new Driver(7001, "Carlos Tijero", 5, 0, "Class A");
            Loader loader1 = new Loader(8001, "John Smith", 3, 0, 30); 
            mainWarehouse.AddVehicle(truck1);
            mainWarehouse.AddVehicle(van1);
            mainWarehouse.AddWorkers(driver1);
            mainWarehouse.AddWorkers(loader1);*/

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n1. Add Entities");
                Console.WriteLine("2. Assign deliveries");
                Console.WriteLine("3. Sort ");
                Console.WriteLine("4. Search");
                Console.WriteLine("5. Run Simulation");
                Console.WriteLine("6. Undo");
                Console.WriteLine("7. Save and Load");
                Console.WriteLine("0. Exit");

                Console.Write("Choice: ");
                int choice = int.Parse(Console.ReadLine());
                //terminar de implementar funcxion en cada case 
                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("1. add package");
                            Console.WriteLine("2. add vehicle");
                            Console.WriteLine("3. add worker");
                            int entityChoice = int.Parse(Console.ReadLine());

                            if (entityChoice == 1)
                            {
                                Console.WriteLine("Package id: ");
                                int id = int.Parse(Console.ReadLine());
                                Console.WriteLine("Weight (kg): ");
                                double weight = double.Parse(Console.ReadLine());
                                Console.Write("Priority Level (1 to 5): ");
                                int priority = int.Parse(Console.ReadLine());
                                Console.WriteLine("Destination: ");
                                string destination = Console.ReadLine();
                                Package p = new Package(id, weight, priority, destination, "pending");
                                system.AddPackage(p);
                                mainWarehouse.AddPackage(p);
                                undoStack.Push(p);
                                Console.WriteLine("Package successfully added");
                            }
                            else if (entityChoice == 2)
                            {
                                Console.WriteLine("1 Truck");
                                Console.WriteLine("2 Van");
                                Console.WriteLine("3 Drone");
                                int vehicleChoice = int.Parse(Console.ReadLine());
                                Console.Write("Vehicle id: ");
                                int vehicleId = int.Parse(Console.ReadLine());
                                Console.Write("vehicle name: ");
                                string vehicleName = Console.ReadLine();
                                Console.Write("vehicle speed (km/h): ");
                                double vehicleSpeed = double.Parse(Console.ReadLine());
                                Console.Write("vehicle capacity (kg): ");
                                double vehicleCapacity = double.Parse(Console.ReadLine());

                                if (vehicleChoice == 1)
                                {
                                    Console.WriteLine("Fuel consumption: ");
                                    double fuelConsumption = double.Parse(Console.ReadLine());
                                    Truck t = new Truck(vehicleId, vehicleName, vehicleSpeed, vehicleCapacity, fuelConsumption);
                                    mainWarehouse.AddVehicle(t);
                                    Console.WriteLine("Truck added successfully");
                                }
                                else if (vehicleChoice == 2)
                                {
                                    Console.WriteLine("Is the van electric? (true or false): ");
                                    bool isElectric = bool.Parse(Console.ReadLine());
                                    Van v = new Van(vehicleId, vehicleName, vehicleSpeed, vehicleCapacity, isElectric);
                                    mainWarehouse.AddVehicle(v);
                                    Console.WriteLine("Van added successfully");
                                }

                                else if (vehicleChoice == 3)
                                {
                                    Console.WriteLine("Max distance: ");
                                    double maxDistance = double.Parse(Console.ReadLine());
                                    Drone d = new Drone(vehicleId, vehicleName, vehicleSpeed, vehicleCapacity, maxDistance);
                                    mainWarehouse.AddVehicle(d);
                                    Console.WriteLine("Drone added successfully");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid choice");
                                }
                            }

                            else if (entityChoice == 3)
                            {
                                Console.WriteLine("1 Driver");
                                Console.WriteLine("2 Manager");
                                Console.WriteLine("3 Loader");
                                int workerChoice = int.Parse(Console.ReadLine());
                                Console.Write("Worker id: ");
                                int workerId = int.Parse(Console.ReadLine());
                                Console.Write("Worker name: ");
                                string workerName = Console.ReadLine();
                                Console.Write("Experience years: ");
                                int experienceYears = int.Parse(Console.ReadLine());
                                Console.Write("Task completed: ");
                                int tasksCompleted = int.Parse(Console.ReadLine());

                                if (workerChoice == 1)
                                {
                                    Console.Write("License type: ");
                                    string licenseType = Console.ReadLine();
                                    Driver d = new Driver(workerId, workerName, experienceYears, tasksCompleted, licenseType);
                                    mainWarehouse.AddWorkers(d);
                                    Console.WriteLine("Driver added successfully");
                                }
                                else if (workerChoice == 2)
                                {
                                    Console.Write("Team size: ");
                                    int teamSize = int.Parse(Console.ReadLine());
                                    Manager m = new Manager(workerId, workerName, experienceYears, tasksCompleted, teamSize);
                                    mainWarehouse.AddWorkers(m);
                                    Console.WriteLine("Manager added successfully");
                                }
                                else if (workerChoice == 3)
                                {
                                    Console.Write("Max lifting capacity: ");
                                    double maxLiftingCapacity = double.Parse(Console.ReadLine());
                                    Loader l = new Loader(workerId, workerName, experienceYears, tasksCompleted, maxLiftingCapacity);
                                    mainWarehouse.AddWorkers(l);
                                    Console.WriteLine("Loader added successfully");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid choice");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice");
                            }
                            break;
                                 
                        case 2:
                                    system.ProcessDelivery();
                                    Console.WriteLine("Deliveries successfully.");
                                    break;

                                case 3:
                                    system.Sort();
                                    Console.WriteLine("Packages sorted with success");
                                    break;

                                case 4:
                                    Console.WriteLine("Enter package id to search: ");
                                    int searchId = int.Parse(Console.ReadLine());
                                    Package found = system.SearchPackageById(searchId);

                                    if (found != null)
                                    {
                                        Console.WriteLine($"package id found  {found.GetId()} to {found.GetDestination()} with status of {found.GetStatus()}");
                                    }

                                    else
                                    {
                                        Console.WriteLine("Could not find package");
                                    }

                                    break;
                                case 5:
                                    system.SimulateDay();
                                    break;

                                case 6:
                                    Package lastPackage = undoStack.Pop();
                                    system.RemovePackage(lastPackage.GetId());
                                    mainWarehouse.RemovePackage(lastPackage.GetId());
                                    Console.WriteLine($"Undo done! Package {lastPackage.GetId()} has been removed");
                                    break;

                                case 7:
                                    Console.WriteLine("1 to Save");
                                    Console.WriteLine("2 to Load");
                                    int fileChoice = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter your file path: ");
                                    string path = Console.ReadLine();
                                    if (fileChoice == 1)
                                    {
                                        system.Save(path);
                                        Console.WriteLine("Saved succcessfully!");
                                    }
                                    else if (fileChoice == 2)
                                    {
                                        system.Load(path);
                                        Console.WriteLine("Loaded successfully!");
                                    }
                                    break;

                                case 0:
                                    running = false;
                                    break;

                                default:
                                    Console.WriteLine("Invalid choice");
                                    break;
                                }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }
    
}
