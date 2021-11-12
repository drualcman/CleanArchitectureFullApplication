using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Main.Exceptions
{
    public class UpdateExceptions : Exception
    {
        public IReadOnlyList<string> Entries { get; set; }

        public UpdateExceptions() { }
        public UpdateExceptions(string message) : base(message) { }
        public UpdateExceptions(string message, Exception innerException) :
            base(message, innerException) { }
        public UpdateExceptions(string message, IReadOnlyList<string> entries) : base(message)
            => Entries = entries;
        
    }
}
