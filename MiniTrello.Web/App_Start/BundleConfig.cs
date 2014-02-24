// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="">
//   Copyright � 2014 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace App.MiniTrello.Web
{
    using System.Web;
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/content/css/app").Include("~/content/app.css"));

            bundles.Add(new ScriptBundle("~/js/jquery").Include("~/scripts/vendor/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/js/app").Include(
                "~/scripts/vendor/angular-ui-router.js",
                "~/scripts/filters.js",
                "~/scripts/services.js",
                "~/scripts/directives.js",
                "~/scripts/Controllers/AboutControllers.js",
                "~/scripts/Controllers/AccountControllers.js",
                "~/scripts/Controllers/ErrorControllers.js",
                "~/scripts/Controllers/HomeControllers.js",
                "~/scripts/app.js"));
        }
    }
}
