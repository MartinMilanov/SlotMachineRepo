using SlotMachine.Services.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine.Services.Contracts
{
    public interface ISymbolService
    {
        public List<List<ISymbol>> CreateSymbolResult(IEnumerable<ISymbol> pool);
    }
}
