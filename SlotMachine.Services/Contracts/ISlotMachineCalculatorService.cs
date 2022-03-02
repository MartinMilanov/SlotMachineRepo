using SlotMachine.Services.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine.Services.Contracts
{
    public interface ISlotMachineCalculatorService
    {
        public decimal UpdateBalance(List<List<ISymbol>> rows, decimal stakedAmount, ref decimal balance);
    }
}
