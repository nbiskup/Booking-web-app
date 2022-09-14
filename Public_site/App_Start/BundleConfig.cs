using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Public_site.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {      
            bundles.Add(new StyleBundle("~/Content").Include(
                 "~/Content/bootstrap.min.css"
            ));

            //bundles.Add(new StyleBundle("~/Scripts").Include(
            //     "~/Scripts/jquery-3.6.0.min.js",
            //     "~/Scripts/bootstrap.min.js"
            //));


            bundles.Add(new ScriptBundle("~/Scripts").Include(
                "~/Scripts/jquery-3.6.0.js",
                "~/Scripts/bootstrap.js"
            ));

        }
    }
}