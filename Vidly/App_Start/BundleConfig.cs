using System.Web;
using System.Web.Optimization;

namespace Vidly
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/scripts/bootbox.js",//add bootbox reference which abstract over bootstrap
                        "~/Scripts/respond.js",
                        "~/scripts/datatables/jquery.datatables.js", //add jquery.datatables reference
                        "~/scripts/datatables/datatables.bootstrap.js" , //integrate datatable with bootstrap
                        "~/scripts/typeahead.bundle.js", //see example google type ahead and add in content css typeahead
                         "~/scripts/toastr.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-Lumen.css",
                      "~/content/datatables/css/datatables.bootstrap.css", //add table style sheet CSS bundle
                       "~/content/typeahead.css",
                        "~/content/toastr.css",
                      "~/Content/site.css"));
        }
    }
}
