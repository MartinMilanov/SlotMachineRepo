using SlotMachine.Services.Contracts;
using SlotMachine.Services.Implementations;
using SlotMachine.Services.Models;
using SlotMachine.Services.Models.Contracts;
public class Program
{
    public static void Main(string[] args)
    {
        ISymbolService symbolService = new SymbolService();
        ISlotMachineCalculatorService slotMachineCaluclatorService = new SlotMachineCalculatorService();

        List<ISymbol> pool = new List<ISymbol>()
        {
            new Apple(),
            new Banana(),
            new Pineapple(),
            new Wildcard()
        };

        ISlotMachineGame game = new SlotMachineGame(pool, slotMachineCaluclatorService, symbolService);

        game.Start();
    }
}
