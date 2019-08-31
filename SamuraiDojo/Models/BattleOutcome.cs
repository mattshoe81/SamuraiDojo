using System;
using System.Collections.Generic;
using System.Linq;
using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;

namespace SamuraiDojo.Models
{
    /// <summary>
    /// The total results of a battle for every player.
    /// </summary>
    internal class BattleOutcome : IBattleOutcome
    {
        public IBattleAttribute Battle { get; set; }

        public ISenseiAttribute Sensei { get; set; }

        public List<IPlayerBattleResult> Results { get; set; }

        public BattleOutcome()
        {
            Results = new List<IPlayerBattleResult>();
        }

        public void Add(IPlayerBattleResult result, ISenseiAttribute sensei)
        {
            Results.Add(result);
            Sensei = sensei;
        }

        public void AddPoint(IWrittenByAttribute writtenBy, int points = 1)
        {
            IPlayerBattleResult playerResult = Results.Where((result) => result.Player.Name == writtenBy.Name)?.FirstOrDefault();
            if (playerResult == null)
            {
                IPlayerBattleResult result = Factory.Get<IPlayerBattleResult>();
                result.Player = writtenBy;
                result.Points = points;
                Results.Add(result);
            }
            else
            {
                int index = Results.FindIndex(item => item.Player.Equals(writtenBy));
                Results[index].Points += points;
            }
        }

        public void AddAward(IWrittenByAttribute player, IBonusPointsAttribute award)
        {
            IPlayerBattleResult result = Get(player.Name);

            if (result != null)
                result.Awards.Add(award);
            else
            {
                result = Factory.Get<IPlayerBattleResult>();
                result.Player = player;
                result.Points = 0;
                result.Awards = new List<IBonusPointsAttribute>();
                Results.Add(result);
            }
        }

        public IPlayerBattleResult Get(string player)
        {
            IPlayerBattleResult result = Results.Where((battleResult) => battleResult.Player.Name == player).FirstOrDefault();
            return result;
        }

        public List<IPlayerBattleResult> All()
        {
            Results.Sort();
            return Results;
        }

        public int CompareTo(IBattleOutcome other)
        {
            DateTime thisDeadline = Battle.Deadline;
            DateTime otherDeadline = other.Battle.Deadline;

            int result = 0;
            if (thisDeadline > otherDeadline)
                result = -1;
            else if (thisDeadline < otherDeadline)
                result = 1;

            return result;
        }
    }
}
