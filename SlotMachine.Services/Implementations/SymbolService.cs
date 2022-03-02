using SlotMachine.Services.Contracts;
using SlotMachine.Services.Models.Contracts;

namespace SlotMachine.Services.Implementations
{
    public class SymbolService : ISymbolService
    {
        private readonly Random Random;

        public SymbolService()
        {
            Random = new Random();
        }
        // SUMMARY: Method that creates a 4x3 list of results
        public List<List<ISymbol>> CreateSymbolResult(IEnumerable<ISymbol> pool)
        {
            List<List<ISymbol>> result = new List<List<ISymbol>>();

            //Creates rows based on the probabillity of the symbols
            for (int i = 0; i < 4; i++)
            {
                result.Add(CreateSymbolRow(pool));
            }

            return result;
        }
        //SUMMARY: Helper Method that uses a random symbol generator to create a row
        private List<ISymbol> CreateSymbolRow(IEnumerable<ISymbol> pool)
        {
            List<ISymbol> symbols = new List<ISymbol>();

            for (int i = 0; i < 3; i++)
            {
                symbols.Add(GetRandomSymbol(pool));
            }

            return symbols;
        }
        //SUMMARY: Helper Method that generates a random symbol based on the probabillity of every single one
        private ISymbol GetRandomSymbol(IEnumerable<ISymbol> pool)
        {
            // get universal probability 
            double u = pool.Sum(p => p.Probability);

            // pick a random number between 0 and u
            double r = Random.NextDouble() * u;

            double sum = 0;
            foreach (ISymbol n in pool)
            {
                // loop until the random number is less than our cumulative probability
                if (r <= (sum = sum + n.Probability))
                {
                    return n;
                }
            }
            // should never get here
            return null;
        }
    }
}
