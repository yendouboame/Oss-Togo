#pragma checksum "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Report\PensionReportGroupByPriest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3b508a728a9fa4d6e9396163fc78d8f8cb877b84"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_PensionReportGroupByPriest), @"mvc.1.0.view", @"/Views/Report/PensionReportGroupByPriest.cshtml")]
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
#line 3 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\_ViewImports.cshtml"
using SolidarityFund;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\_ViewImports.cshtml"
using SolidarityFund.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\_ViewImports.cshtml"
using SolidarityFund.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\_ViewImports.cshtml"
using SolidarityFund.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\_ViewImports.cshtml"
using SolidarityFund.Models.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\_ViewImports.cshtml"
using static SolidarityFund.Helpers.Constants.Permissions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\_ViewImports.cshtml"
using static SolidarityFund.Helpers.Constants.Enumerations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\_ViewImports.cshtml"
using static SolidarityFund.Helpers.Functions.StringHelpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b508a728a9fa4d6e9396163fc78d8f8cb877b84", @"/Views/Report/PensionReportGroupByPriest.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b52c7e4a02ddeecc3e4dd82729f5e427a2ed09a", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_PensionReportGroupByPriest : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<IGrouping<Priest, Pension>>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Report\PensionReportGroupByPriest.cshtml"
  
    ViewData["Title"] = "Etat des allocations groupés par prêtre";
    Layout = "_ReportLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2 class=\"text-center mb-4 border-bottom\"><strong>");
#nullable restore
#line 8 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Report\PensionReportGroupByPriest.cshtml"
                                              Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></h2>\r\n\r\n<table class=\"table table-bordered text-center\">\r\n");
#nullable restore
#line 11 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Report\PensionReportGroupByPriest.cshtml"
     if (Model.Count() > 0)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Report\PensionReportGroupByPriest.cshtml"
         foreach (var group in Model)
        {
            int i = 1;


#line default
#line hidden
#nullable disable
            WriteLiteral("            <thead class=\"thead-dark\">\r\n                <tr>\r\n                    <th colspan=\"4\">");
#nullable restore
#line 19 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Report\PensionReportGroupByPriest.cshtml"
                               Write(group.Key?.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</th>
                </tr>
            </thead>
            <thead class=""thead-light"">
                <tr>
                    <th>#</th>
                    <th>Date de l'allocation</th>
                    <th>Nom et prénom(s) du prêtre</th>
                    <th>Montant de l'allocation</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 31 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Report\PensionReportGroupByPriest.cshtml"
                 foreach (var pension in group)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 34 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Report\PensionReportGroupByPriest.cshtml"
                        Write(i++);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 35 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Report\PensionReportGroupByPriest.cshtml"
                       Write(pension.Date.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 36 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Report\PensionReportGroupByPriest.cshtml"
                       Write(pension.Priest?.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 37 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Report\PensionReportGroupByPriest.cshtml"
                       Write(FormatNumberWithSpaces(pension.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral(" XOF</td>\r\n                    </tr>\r\n");
#nullable restore
#line 39 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Report\PensionReportGroupByPriest.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td colspan=\"3\"><strong>TOTAL</strong></td>\r\n                    <td>");
#nullable restore
#line 42 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Report\PensionReportGroupByPriest.cshtml"
                   Write(FormatNumberWithSpaces(group.Sum(m => m.Amount)));

#line default
#line hidden
#nullable disable
            WriteLiteral(" XOF</td>\r\n                </tr>\r\n            </tbody>\r\n");
#nullable restore
#line 45 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Report\PensionReportGroupByPriest.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Report\PensionReportGroupByPriest.cshtml"
         
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <thead>
            <tr>
                <th>Date de l'allocation</th>
                <th>Nom et prénom(s) du prêtre</th>
                <th>Montant de l'allocation</th>
            </tr>
        </thead>
        <tbody>
            <tr role=""group"" class=""bg-light text-center"">
                <td colspan=""3"">Aucune entrée correspondante trouvée</td>
            </tr>
        </tbody>
");
#nullable restore
#line 61 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Report\PensionReportGroupByPriest.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IAuthorizationService AuthorizationService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<IGrouping<Priest, Pension>>> Html { get; private set; }
    }
}
#pragma warning restore 1591
