using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6.Entities
{
    public class Alert
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public IList<AlertDefinnation> alertDefinnation { get; set; }
    }
}
