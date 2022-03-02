using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine.Services.Models.Contracts
{
    public interface ISymbol
    {
        public char Mark { get; set; }
        public decimal Coefficient { get; set; }
        public double Probability { get; set; }
    }
}
