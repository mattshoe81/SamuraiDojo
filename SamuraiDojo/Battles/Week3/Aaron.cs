using System;
using System.Collections.Generic;
using System.Linq;
using SamuraiDojo.Attributes;

namespace SamuraiDojo.Battles.Week3
{
    [WrittenBy(Samurai.Aaron)]
    public class Aaron : CensusMaximus
    {
        public override int MostPopulousYear(List<Person> people)
        {
            int mostPopulousYear = 0;
            Dictionary<int, int> MaxCitizensInAYear = new Dictionary<int, int>();
            // TODO: Implement algorithm
            for (int i = 1900; i <= 2000; i++)
            {
                var key = people.Count(x => x.Born < i && x.Deceased > i); //Not sure that I agree with this. You are alive in the year you are born.
                if (!MaxCitizensInAYear.ContainsKey(key)) {
                    MaxCitizensInAYear.Add(key, i);
                }
            }
            mostPopulousYear = MaxCitizensInAYear[MaxCitizensInAYear.Keys.Max()];
            return mostPopulousYear;
        }
    }
}
