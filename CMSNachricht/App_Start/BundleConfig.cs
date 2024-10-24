using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WebBundleConfig.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/jquery-{version}.js", "~/Scripts/JavaScript.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            "~/Scripts/bootstrap.min.js"
            ));
            bundles.Add(new StyleBundle("~/Content/css").Include(
            "~/Content/bootstrap.min.css",
            "~/Content/Site.css"));
            bundles.Add(new StyleBundle("~/Content/viewCss").Include(
                "~/Content/Details.css",
                "~/Content/Index.css"
                ));
            bundles.Add(new StyleBundle("~/Content/MyWebCSS").Include(
                "~/assets/css/vendor.css",
                "~/assets/css/style.css",
                "~/assets/css/responsive.css"


                ));


        }
    }
}