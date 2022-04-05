using System.Web;
using System.Web.Optimization;

namespace DemoMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/Bootstrap/bootstrap.js"));

            // JavaScript file
            bundles.Add(new ScriptBundle("~/bundles/JS/CreateNewAccount").Include(
                      "~/Scripts/CreateNewAccount/CreateNewAccount.js"));

            bundles.Add(new ScriptBundle("~/bundles/jQuery").Include(
                     "~/Scripts/JQuery/jquery-3.4.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernzer").Include(
                     "~/Scripts/Modernzer/modernizr-2.8.3.js"));

            bundles.Add(new ScriptBundle("~/bundles/manager").Include(
                    "~/Scripts/manager/manager.js"));

            //bundles.Add(new ScriptBundle("~/bundles/UserRecords").Include(
            //        "~/Scripts/UserRecords/userrecord.js"));

            bundles.Add(new ScriptBundle("~/bundles/UserRecords2").Include(
                   "~/Scripts/UserRecords/userrecord.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/Bootstrap/bootstrap.css",
                      "~/Content/site/Site.css"));

            //CreateNewAccount CSS FILE
            bundles.Add(new StyleBundle("~/bundles/Content/css/CreateNewAccount.css").Include(
                      "~/Content/CreateNewAccount/CreateNewAccount.css"));


            //chart view 
            bundles.Add(new ScriptBundle("~/bundles/chart").Include(
                   "~/Scripts/chart/chart.js",
                   "~/Scripts/chart/fusioncharts.charts.js",
                   "~/Scripts/chart/fusioncharts.js",
                   "~/Scripts/Theme/fusioncharts.theme.carbon.js"));





        }
    }
}
