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
            // crear lista 
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
                            
                            Console.WriteLine("Successfully added entities."); 
                            break;

                        case 2:
                            Console.WriteLine("Assigned deliveries successfully.");
                            break;

                        case 3:
                            
                            break;

                        case 4:
                            
                            break;

                        case 5:
                            
                            break;

                        case 6:
                            
                            Console.WriteLine("Undo done!");
                            break;
                        case 7:
                            Console.WriteLine("Save and Loaded successfully.");
                            break;

                        case 0:
                            running = false;
                            
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
