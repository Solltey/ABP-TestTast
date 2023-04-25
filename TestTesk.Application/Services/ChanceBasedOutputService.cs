using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTesk.Application.Interfaces;

namespace TestTesk.Application.Services
{
    public class ChanceBasedOutputService : IChanceBasedOutputService
    {
        public string GetRandomValue(Dictionary<string, double> pairs)
        {
            double totalProbability = pairs.Values.Sum();

            if (totalProbability > 1)
                throw new InvalidOperationException("The sum of probabilities can't be more then 1");

            double randomNumber = new Random().NextDouble() * totalProbability;

            double cumulativeProbability = 0;
            foreach (KeyValuePair<string, double> entry in pairs)
            {
                cumulativeProbability += entry.Value;
                if (randomNumber <= cumulativeProbability)
                {
                    return entry.Key;
                }
            }

            throw new InvalidOperationException("The dictionary is empty or the probabilities are incorrect.");
        }
    }
}
