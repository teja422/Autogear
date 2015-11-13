using System.Web.Optimization;

namespace AutogearWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
           /* bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            */
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"));
            bundles.Add(new StyleBundle("~/Content/AceCss").Include(
                      "~/assets/css/font-awesome.css",
                      "~/assets/css/jquery-ui.css",
                      "~/assets/css/bootstrap-datepicker3.css",
                      "~/assets/css/ui.jqgrid.css" ,
                      "~/assets/css/ace-fonts.css",
                      "~/assets/css/ace.css"
                      ));

            // Project specific scripts and style sheets
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.js",
                        "~/assets/js/bootstrap.js",
                        "~/assets/js/date-time/bootstrap-datepicker.js",
                        "~/assets/js/jqGrid/jquery.jqGrid.js",
                        "~/assets/js/jqGrid/i18n/grid.locale-en.js",
                        "~/Scripts/jquery-ui.js",
                        "~/Scripts/jquery-ui.custom.js",
                          "~/assets/js/jquery-ui.custom.js",
    "~/assets/js/jquery.ui.touch-punch.js",
    "~/assets/js/jquery.easypiechart.js",
    "~/assets/js/jquery.sparkline.js"
  ));

            // Theme js
            bundles.Add(new ScriptBundle("~/bundles/ace").Include(
                        "~/assets/js/ace/*",
                        "~/assets/autogear/js/*"));
           

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
