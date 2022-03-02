using SlotMachine.Services.Models.Contracts;

namespace SlotMachine.Services.Contracts
{
    public interface ISlotMachineGame
    {
        List<ISymbol> Pool { get; set; }
        void Start();
    }
}
