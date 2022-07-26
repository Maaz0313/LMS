using System.Web;
using System.Web.Optimization;

namespace Edubin
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/Content/js").Include(
                      "~/Content/js/ajax-contact.js",
                      "~/Content/js/bootstrap.min.js",
                      "~/Content/js/jquery.countdown.min.js",
                      "~/Content/js/jquery.counterup.min.js",
                      "~/Content/js/jquery.magnific-popup.min.js",
                      "~/Content/js/jquery.nice-number.min.js",
                      "~/Content/js/jquery.nice-select.js",
                      "~/Content/js/main.js",
                      "~/Content/js/map-script.js",
                      "~/Content/js/slick.min.js",
                      "~/Content/js/validator.min.js",
                      "~/Content/js/waypoints.min.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/animate.css",
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/default.css",
                      "~/Content/css/font-awesome.min.css",
                      "~/Content/css/jquery.nice-number.min.css",
                      "~/Content/css/magnific-popup.css",
                      "~/Content/css/nice-select.css",
                      "~/Content/css/responsive.css",
                      "~/Content/css/slick.css",
                      "~/Content/css/style.css",
                      "~/Content/site.css"));
        }
    }
}
