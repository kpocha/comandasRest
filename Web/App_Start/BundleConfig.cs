using System.Web;
using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/Content/appCss").Include(
                "~/Content/app/css/app.css",
                "~/Content/mvc-override.css"
            ));
            bundles.Add(new ScriptBundle("~/bundles/Angle").Include(
                // App init
                "~/Scripts/app/app.init.js",
                // Modules
                "~/Scripts/app/modules/bootstrap-start.js",
                "~/Scripts/app/modules/calendar.js",
                "~/Scripts/app/modules/classyloader.js",
                "~/Scripts/app/modules/clear-storage.js",
                "~/Scripts/app/modules/constants.js",
                "~/Scripts/app/modules/demo",
                "~/Scripts/app/modules/flatdoc.js",
                "~/Scripts/app/modules/fullscreen.js",
                "~/Scripts/app/modules/gmap.js",
                "~/Scripts/app/modules/load-css.js",
                "~/Scripts/app/modules/localize.js",
                "~/Scripts/app/modules/maps-vector.js",
                "~/Scripts/app/modules/navbar-search.js",
                "~/Scripts/app/modules/notify.js",
                "~/Scripts/app/modules/now.js",
                "~/Scripts/app/modules/panel-tools.js",
                "~/Scripts/app/modules/play-animation.js",
                "~/Scripts/app/modules/porlets.js",
                "~/Scripts/app/modules/sidebar.js",
                "~/Scripts/app/modules/skycons.js",
                "~/Scripts/app/modules/slimscroll.js",
                "~/Scripts/app/modules/sparkline.js",
                "~/Scripts/app/modules/table-checkall.js",
                "~/Scripts/app/modules/toggle-state.js",
                "~/Scripts/app/modules/utils.js",
                "~/Scripts/app/modules/chart.js",
                "~/Scripts/app/modules/morris.js",
                "~/Scripts/app/modules/rickshaw.js",
                "~/Scripts/app/modules/chartist.js",
                "~/Scripts/app/modules/tour.js",
                "~/Scripts/app/modules/sweetalert.js",
                "~/Scripts/app/modules/color-picker.js",
                "~/Scripts/app/modules/imagecrop.js",
                "~/Scripts/app/modules/chart-knob.js",
                "~/Scripts/app/modules/chart-easypie.js",
                "~/Scripts/app/modules/select2.js"
            ));
            bundles.Add(new StyleBundle("~/bundles/SweetAlertCss").Include(
                 "~/Content/sweetalert.css"
             ));
            bundles.Add(new ScriptBundle("~/bundles/SweetAlert").Include(
                "~/Scripts/sweetalert.min.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/jqueryUi").Include(
         "~/Scripts/jquery-ui/ui/jquery-ui.min.js"
       ));
            bundles.Add(new StyleBundle("~/bundles/jqueryUiCss").Include(
            "~/Scripts/jquery-ui/themes/smoothness/jquery-ui.css",
            "~/Scripts/jquery-ui/themes/smoothness/theme.css"
        ));

            bundles.Add(new ScriptBundle("~/bundles/Utils").Include(
                "~/Scripts/Utils.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new StyleBundle("~/bundles/fontawesome").Include(
                "~/Content/font-awesome.min.css", new CssRewriteUrlTransform()
            ));

            bundles.Add(new StyleBundle("~/bundles/animatecss").Include(
                "~/Content/animate.min.css"
            ));
            bundles.Add(new StyleBundle("~/bundles/simpleLineIcons").Include(
                "~/Content/simple-line-icons.css", new CssRewriteUrlTransform()
            ));
            bundles.Add(new StyleBundle("~/bundles/whirl").Include(
                "~/Content/whirl.css"
            ));
            bundles.Add(new ScriptBundle("~/bundles/sliderCtrl").Include(
                "~/Scripts/bootstrap-slider.min.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/sliderCtrlCss").Include(
                "~/Content/bootstrap-slider.min.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/slimscroll").Include(
                "~/Scripts/jquery.slimscroll.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/screenfull").Include(
                "~/Scripts/screenfull.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/localize").Include(
                "~/Scripts/jquery.localize.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/storage").Include(
                "~/Scripts/jquery.storageapi.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryEasing").Include(
                "~/Scripts/jquery.easing.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/GridMvc").Include(
               "~/Scripts/app/modules/MVCGrid.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/bootstrapDatepicker").Include(
                      "~/Scripts/bootstrap-datepicker.js",
                      "~/Scripts/bootstrap-datepicker.es.min.js"
            ));
            bundles.Add(new StyleBundle("~/bundles/bootstrapDatepickerCss").Include(
              "~/Content/bootstrap-datepicker.min.css"
            ));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/Parsley").Include(
                       "~/Scripts/parsley.min.js"));
        }
    }
}
