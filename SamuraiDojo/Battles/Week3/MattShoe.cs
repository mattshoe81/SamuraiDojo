using System.Collections.Generic;
using SamuraiDojo.Attributes;

namespace SamuraiDojo.Battles.Week3
{
    [WrittenBy(Samurai.MATT_SHOE)]
    public class MattShoe : CensusMaximus
    {
        public override int MostPopulousYear(List<Person> people)
        {
            /*
             * Use array for key-value store, where:
             *      Index = offset from 1900 (1900 + index)
             *      Value = population in that year
             */
            int[] populationsByYear = new int[101];

            /*
             * Iterate eacch person's living years, tracking the year with most population
             */
            int maxPopulation = 0;
            foreach (Person person in people)
            {
                for (int i = person.Born; i <= person.Deceased; i++)
                {
                    int populationForYear = ++populationsByYear[i - 1900];

                    if (populationForYear > maxPopulation)
                        maxPopulation = populationForYear;

                    populationsByYear[i - 1900] = populationForYear;
                }
            }

            // Get the first year with the max population
            int mostPopulousYear = 0;
            for (int i = 0; i < populationsByYear.Length; i++)
            {
                if (populationsByYear[i] == maxPopulation)
                {
                    mostPopulousYear = 1900 + i;
                    break;
                }
            }

            return mostPopulousYear;
        }
    }
}
