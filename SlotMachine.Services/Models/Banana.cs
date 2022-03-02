using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine.Services.Models
{
    public class Banana : Symbol
    {
        public Banana() : base('B', 0.6m, 35)
        {
        }
    }
}
