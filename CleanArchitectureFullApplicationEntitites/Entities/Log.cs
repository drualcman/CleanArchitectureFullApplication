using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Main.Entities
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public Log(DateTime createdDate, string description) =>
            (CreatedDate, Description) = (createdDate, description);
        public Log(string description) : this(DateTime.Now, description) { }
    }
}
