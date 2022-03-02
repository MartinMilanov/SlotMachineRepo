using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine.Services.Models
{
    public class Wildcard : Symbol
    {
        public Wildcard() : base('*', 0.00m, 5)
        {
        }
    }
}
