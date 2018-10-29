using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4jClient;
using ConsoleApplication6.Entities;

namespace ConsoleApplication6
{
    public class DBContext
    {
        public GraphClient client;
        public DBContext()
        {
            client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "test");
            client.Connect();
        }

        public IEnumerable<Alert> GetAllAlerts()
        {
            var results = client.Cypher
                   .Match("(category:Alert)")
                   .Return(category => category.As<Alert>())
                   .Results;
            return results;
        }


        public void InsertAlert(string title, string desciption)
        {
            Alert alert = new Alert { Title = title, Description = desciption, Status = true };
            client.Cypher
            .Create("(alert:Alert {alert})")
            .WithParam("alert", alert)
            .ExecuteWithoutResultsAsync()
            .Wait();
        }
        public void InsertDef(string alertName, string listName, string viewName)
        {
            AlertDefinnation alertDefinnation = new AlertDefinnation { AlertName= alertName, ListName = listName, ViewName = viewName };
            client.Cypher
            .Create("(alertDef:AlertDefinnation {alertDefinnation})")
            .WithParam("alertDefinnation", alertDefinnation)
            .ExecuteWithoutResultsAsync()
            .Wait();
        }

        public void GenrateRelationShip() {
            client.Cypher.Match("(alert:Alert),(alertDef:AlertDefinnation)").
                Where((Alert alert, AlertDefinnation alertDef) => alert.Title == alertDef.AlertName).
                Create("(alertDef)-[:PART_OF]->(alert)")
                .ExecuteWithoutResultsAsync()
                .Wait(); ;
        }
    }
}
