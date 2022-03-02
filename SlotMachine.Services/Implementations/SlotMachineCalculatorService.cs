using SlotMachine.Services.Contracts;
using SlotMachine.Services.Models;
using SlotMachine.Services.Models.Contracts;

namespace SlotMachine.Services.Implementations
{
    public class SlotMachineCalculatorService : ISlotMachineCalculatorService
    {
        //SUMMARY: Method that updates the balance based on the coefficient
        public decimal UpdateBalance(List<List<ISymbol>> rows, decimal stakedAmount, ref decimal balance)
        {
            decimal summedCoefficient = CalculateSpinResultCoefficient(rows);

            balance -= stakedAmount;

            decimal sumToAdd = summedCoefficient * stakedAmount;

            balance += sumToAdd;

            return sumToAdd;
        }

        //SUMMARY: Helper Method that calculates every row and adds the coefficient sum if row has won
        private decimal CalculateSpinResultCoefficient(List<List<ISymbol>> rows)
        {
            decimal summedCoefficient = 0;

            foreach (var row in rows)
            {
                Dictionary<char, List<ISymbol>> marks = new Dictionary<char, List<ISymbol>>();

                foreach (var symbol in row)
                {
                    if (marks.ContainsKey(symbol.Mark))
                    {
                        marks[symbol.Mark].Add(symbol);
                    }
                    else
                    {
                        marks[symbol.Mark] = new List<ISymbol>() { symbol };
                    }
                }

                decimal sumToAdd = 0;

                if (marks.Count == 1 || marks.Count == 2 && marks.ContainsKey('*'))
                {
                    foreach (var mark in marks)
                    {
                        sumToAdd = mark.Value.Sum(s => s.Coefficient);
                    }
                    summedCoefficient += sumToAdd;
                }
            }

            return summedCoefficient;
        }
    }
}
