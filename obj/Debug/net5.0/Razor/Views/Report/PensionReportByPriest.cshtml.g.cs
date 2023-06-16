#pragma checksum "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Report\PensionReportByPriest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c6482e26f0de2133527219aa86900a1ca696bb75"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_PensionReportByPriest), @"mvc.1.0.view", @"/Views/Report/PensionReportByPriest.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\_ViewImports.cshtml"
using SolidarityFund;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\_ViewImports.cshtml"
using SolidarityFund.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\_ViewImports.cshtml"
using SolidarityFund.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\_ViewImports.cshtml"
using SolidarityFund.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\_ViewImports.cshtml"
using SolidarityFund.Models.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c6482e26f0de2133527219aa86900a1ca696bb75", @"/Views/Report/PensionReportByPriest.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb69d6d8baa61fb6d2c40532a56aaba51be488ac", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_PensionReportByPriest : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Pension>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Report\PensionReportByPriest.cshtml"
  
    ViewData["Title"] = "Etat des allocations par prêtre";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-12 my-4\">\r\n        <div class=\"card shadow\">\r\n            <div class=\"card-body\">\r\n                <h5 class=\"card-title\"><strong>");
#nullable restore
#line 11 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Report\PensionReportByPriest.cshtml"
                                          Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</strong></h5>
                <hr />

                <table id=""customDataTable"" class=""table table-sm table-bordered table-hover text-center"">
                    <thead class=""thead-dark"">
                        <tr>
                            <th>");
#nullable restore
#line 17 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Report\PensionReportByPriest.cshtml"
                           Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th>");
#nullable restore
#line 18 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Report\PensionReportByPriest.cshtml"
                           Write(Html.DisplayNameFor(model => model.Priest));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th>");
#nullable restore
#line 19 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Report\PensionReportByPriest.cshtml"
                           Write(Html.DisplayNameFor(model => model.Ammount));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 23 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Report\PensionReportByPriest.cshtml"
                         foreach (var pension in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 26 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Report\PensionReportByPriest.cshtml"
                               Write(pension.Date.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 27 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Report\PensionReportByPriest.cshtml"
                               Write(pension.Priest?.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 28 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Report\PensionReportByPriest.cshtml"
                               Write(pension.Ammount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 30 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Report\PensionReportByPriest.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Pension>> Html { get; private set; }
    }
}
#pragma warning restore 1591
