﻿using System.Web;
using System.Web.Mvc;

namespace SamuraiDojo.ScoreBoard
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
