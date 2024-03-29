﻿using System.Web;
using System.Web.Optimization;

namespace SamuraiDojo.ScoreBoard
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(
                new ScriptBundle("~/bundles/jquery")
                .Include(
                        "~/Scripts/jquery-{version}.js")
            );

            bundles.Add(
                new ScriptBundle("~/bundles/jqueryval")
                .Include(
                        "~/Scripts/jquery.validate*")
            );

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(
                new ScriptBundle("~/bundles/modernizr")
                .Include(
                        "~/Scripts/modernizr-*")
            );

            bundles.Add(
                new ScriptBundle("~/bundles/bootstrap")
                .Include(
                      "~/Scripts/bootstrap.js")
            );

            bundles.Add(
                new StyleBundle("~/Content/css")
                .Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css")
            );

            bundles.Add(
                new ScriptBundle("~/bundles/angularjs")
                .Include(
                    "~/Scripts/angular.min.js"
                )
            );

            bundles.Add(
                new ScriptBundle("~/bundles/angularjs/controllers")
                .Include(
                    "~/Angular/app.js",
                    "~/Angular/Controllers/HomePageController.js",
                    "~/Angular/Controllers/MyProfileController.js",
                    "~/Angular/Controllers/AwardsController.js",
                    "~/Angular/Controllers/BenchmarkingController.js",
                    "~/Angular/Controllers/HistoryController.js",
                    "~/Angular/Controllers/SenseiController.js"
                )
            );

            bundles.Add(
                new ScriptBundle("~/bundles/angularjs/services")
                .Include(
                    "~/Angular/Services/ServicesApp.js"
                    , "~/Angular/Services/RequestService.js"
                    , "~/Angular/Services/DataService.js"
                )
            );

            bundles.Add(
                new ScriptBundle("~/bundles/angularjs/directives")
                .Include(
                    "~/Angular/Directives/DirectivesApp.js",
                    "~/Angular/Directives/CodeBox.js"
                )
            );
        }
    }
}
