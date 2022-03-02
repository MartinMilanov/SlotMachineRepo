using SlotMachine.Services.Contracts;
using SlotMachine.Services.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine.Services.Implementations
{
    public class SlotMachineGame : ISlotMachineGame
    {
        private readonly ISlotMachineCalculatorService SlotMachineCaluclatorService;
        private readonly ISymbolService SymbolService;
        public List<ISymbol> Pool {get;set;}

        public SlotMachineGame(List<ISymbol> pool, ISlotMachineCalculatorService slotMachineCaluclatorService, ISymbolService symbolService)
        {
            Pool = pool;
            SlotMachineCaluclatorService = slotMachineCaluclatorService;
            SymbolService = symbolService;
        }
        public void Start()
        {
            Console.WriteLine("Please deposit money you would like to play with:");
            decimal balance = decimal.Parse(Console.ReadLine());

            while (balance > 0)
            {
                Console.WriteLine("Enter stake amount:");
                decimal stakedAmount = decimal.Parse(Console.ReadLine());

                //Lets the service create our symbol result
                List<List<ISymbol>> result = SymbolService.CreateSymbolResult(Pool);

                //Prints out the symbol array

                foreach (var symbolRow in result)
                {
                    Console.WriteLine(string.Join(" ", symbolRow.Select(s => s.Mark)));
                }

                //Calculate the balance based on the result of the current turn
                var stakedAmountAfterTurn = SlotMachineCaluclatorService.UpdateBalance(result, stakedAmount, ref balance);

                Console.WriteLine($"You have won: {stakedAmountAfterTurn}");
                Console.WriteLine($"Current balance is: {balance}");

                Console.ReadKey();
            }
        }
    }
}
