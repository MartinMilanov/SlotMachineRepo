using SlotMachine.Services.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine.Services.Models
{
    public class Symbol : ISymbol
    {
        public char Mark { get; set; }
        public decimal Coefficient { get; set; }
        public double Probability { get; set; }

        public Symbol(char mark,decimal coefficient, double probability)
        {
            Mark = mark;
            Coefficient = coefficient;
            Probability = probability;
        }
    }
}
