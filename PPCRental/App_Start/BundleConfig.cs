using System.Web;
using System.Web.Optimization;

namespace PPCRental
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                      "~/Scripts/jquery.min.js","~/Scripts/jquery.migrate.js","~/Scripts/bootstrap.min.js","~/Scripts/jquery.slicknav.min.js","~/Scripts/slick.min.js","~/Scripts/jquery-ui.min.js","~/Scripts/tweetie.js","~/Scripts/jquery.form.min.js","~/Scripts/jquery.validate.min.js","~/Scripts/modernizr.custom.js","~/Scripts/wow.min.js","~/Scripts/zoom.js","~/Scripts/mixitup.min.js","~/Scripts/WhatsNearby.js","~/Scripts/theme.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.min.css", "~/Content/style.css","~/Content/slick.css"
                      , "~/Content/slicknav.css", "~/Content/animate.css", "~/Content/theme.css"));
        }
    }
}
