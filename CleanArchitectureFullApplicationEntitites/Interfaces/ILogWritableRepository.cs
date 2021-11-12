using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Main.Interfaces
{
    public interface ILogWritableRepository
    {
        void Add(Log log);
        void Add(string description);
    }
}
