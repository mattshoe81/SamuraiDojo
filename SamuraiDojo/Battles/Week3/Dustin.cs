using System.Collections.Generic;
using SamuraiDojo.Attributes;
using SamuraiDojo.Attributes.Bonus;

namespace SamuraiDojo.Battles.Week3
{
    [MostEfficient]
    [GoldfishAward]
    [WrittenBy(Samurai.DUSTIN)]
    public class Dustin : CensusMaximus
    {
        public override int MostPopulousYear(List<Person> people)
        {
            int mostPopulousYear = 0;
            int mostPopulousYearPopulation = 0;
            int peopleAliveCheck = 0;

            for (int i = 1900; i <= 2000; i++)
            {
                foreach (Person p in people)
                {
                    if (i >= p.Born && i <= p.Deceased)
                    {
                        peopleAliveCheck++;
                    }
                }

                if (peopleAliveCheck > mostPopulousYearPopulation)
                {
                    mostPopulousYearPopulation = peopleAliveCheck;
                    mostPopulousYear = i;
                }

                peopleAliveCheck = 0;

            }

            return mostPopulousYear;
        }
    }
}
