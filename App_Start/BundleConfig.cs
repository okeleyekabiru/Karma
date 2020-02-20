﻿using System.Web;
using System.Web.Optimization;

namespace Shopy
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));
            bundles.Add(new StyleBundle("~/Content/css/bootstrap").Include("~/Content/bootstrap.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/availability-calender.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/ion.rangeSlider.css",
                      "~/Content/ion.rangeSlider.skinFlat.css",
                      "~/Content/jquerysctipttop.css",
                      "~/Content/linearicons.css",
                      "~/Content/magnific-popup.css",
                      "~/Content/main.css",
                      "~/Content/nice-select.css",
                      "~/Content/nouislider.min.css",
                      "~/Content/owl.carousel.css",
                      "~/Content/themify-icons.css"
                      ));
           
        }
    }
}
