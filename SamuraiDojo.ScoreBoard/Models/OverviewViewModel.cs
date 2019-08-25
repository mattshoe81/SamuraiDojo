using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SamuraiDojo.ScoreBoard.Metrics;

namespace SamuraiDojo.ScoreBoard.Models
{
    public class OverviewViewModel
    {
        public int Visitors { get; set; }

        public HashSet<PageMetrics> PageLoads { get; set; }

        public SessionCollection Sessions { get; set; }

        public OverviewViewModel()
        {
            PageLoads = new HashSet<PageMetrics>();
            Sessions = new SessionCollection();
        }
    }
}