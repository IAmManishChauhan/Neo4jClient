using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4jClient;
using Newtonsoft.Json;
using ConsoleApplication6.Entities;
namespace ConsoleApplication6
{
    class Program
    {
      public static  DBContext db = new DBContext();
        static void Main(string[] args)
        {
            Console.WriteLine("**** Welcome in Neo4j Graph database ******");
            Console.WriteLine("Do you want to see all details (y/n):");
            string flag = Console.ReadLine();
            if (flag == "y")
            {
                showAllAlert();
            }
            Console.WriteLine("Do you want add a new Alert (y/n):");
            string flagInsert = Console.ReadLine();
            if (flagInsert == "y")
            {
                Console.WriteLine("Title :");
                string title = Console.ReadLine();
                Console.WriteLine("Description :");
                string description = Console.ReadLine();
                InsertAlert(title, description);
                Console.WriteLine("Do you want add a new Definition (y/n):");
                string flagInsertDef = Console.ReadLine();
                if (flagInsertDef == "y")
                {
                    string yes="y";
                    for (int i = 0; i < 100; i++)
                    {
                        if (yes == "y")
                        {
                            Console.WriteLine("ListName :");
                            string listName = Console.ReadLine();
                            Console.WriteLine("ViewName :");
                            string viewName = Console.ReadLine();
                            db.InsertDef(title, listName, viewName);

                            Console.WriteLine("Do you want add more Definitions(y/n) :");
                            yes = Console.ReadLine();
                        }
                    }
                    db.GenrateRelationShip();
                }

                Console.WriteLine("All Alerts :");
                showAllAlert();
            }
             
           
            Console.ReadKey();
        }

        public void InsertAlertDef(string alertId,string listName,string viewName) {
            db.InsertDef(alertId ,listName,viewName);
        }

        static void InsertAlert(string title,string desc) {
            db.InsertAlert(title,desc);
        }

        static void showAllAlert()
        {
            IEnumerable<Alert> Alerts = db.GetAllAlerts();
            if (Alerts.Count<Alert>() == 0)
            {
                Console.WriteLine("No alerts found");
            }
            else
            {
                foreach (var alert in Alerts)
                {
                    Console.WriteLine($"{alert.Title} and {alert.Description}");
                }
            }

        }
    }
}
