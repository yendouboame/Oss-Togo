#pragma checksum "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Pension\EligiblePriests.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9dd3338b7437443a63aeed4305ddcc09222acd7c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pension_EligiblePriests), @"mvc.1.0.view", @"/Views/Pension/EligiblePriests.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9dd3338b7437443a63aeed4305ddcc09222acd7c", @"/Views/Pension/EligiblePriests.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b52c7e4a02ddeecc3e4dd82729f5e427a2ed09a", @"/Views/_ViewImports.cshtml")]
    public class Views_Pension_EligiblePriests : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Priest>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_StatusMessage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "New", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Pension\EligiblePriests.cshtml"
  
    ViewData["Title"] = "Liste de tous les prêtres bénéficiaires d'une allocation";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-12 my-4\">\r\n\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9dd3338b7437443a63aeed4305ddcc09222acd7c6969", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 10 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Pension\EligiblePriests.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = TempData["StatusMessage"];

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n        <div class=\"card shadow\">\r\n            <div class=\"card-body\">\r\n                <h5 class=\"card-title\"><strong>");
#nullable restore
#line 14 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Pension\EligiblePriests.cshtml"
                                          Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</strong></h5>
                <hr />

                <table id=""customDataTable"" class=""table table-bordered table-hover text-center mt-4"">
                    <thead class=""thead-dark"">
                        <tr>
                            <th>");
#nullable restore
#line 20 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Pension\EligiblePriests.cshtml"
                           Write(Html.DisplayNameFor(model => model.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th>");
#nullable restore
#line 21 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Pension\EligiblePriests.cshtml"
                           Write(Html.DisplayNameFor(model => model.DateOfBirth));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th>");
#nullable restore
#line 22 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Pension\EligiblePriests.cshtml"
                           Write(Html.DisplayNameFor(model => model.Age));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th>Date du dernier versement</th>\r\n                            <th></th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 28 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Pension\EligiblePriests.cshtml"
                         foreach (var priest in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 31 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Pension\EligiblePriests.cshtml"
                               Write(priest.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 32 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Pension\EligiblePriests.cshtml"
                               Write(priest.DateOfBirth.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 33 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Pension\EligiblePriests.cshtml"
                               Write(priest.Age);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ans</td>\r\n                                <td>");
#nullable restore
#line 34 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Pension\EligiblePriests.cshtml"
                               Write(priest.Pensions.FirstOrDefault()?.Date.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                <td class=""text-right"">
                                    <div class=""dropdown"">
                                        <button class=""btn btn-sm dropdown-toggle"" type=""button"" id=""actions"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                            <span class=""text-muted sr-only"">Action</span>
                                        </button>
                                        <div class=""dropdown-menu dropdown-menu-right"" aria-labelledby=""actions"">
");
#nullable restore
#line 41 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Pension\EligiblePriests.cshtml"
                                             if ((AuthorizationService.AuthorizeAsync(User, Pensions.Add)).Result.Succeeded)
                                            { 

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <a class=\"dropdown-item btn-deposit\" href=\"#\" data-toggle=\"modal\" data-target=\"#confirm-deposit\" data-priest-id=\"");
#nullable restore
#line 43 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Pension\EligiblePriests.cshtml"
                                                                                                                                                            Write(priest.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-priest-name=\"");
#nullable restore
#line 43 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Pension\EligiblePriests.cshtml"
                                                                                                                                                                                          Write(priest.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Nouveau versement</a>\r\n");
#nullable restore
#line 44 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Pension\EligiblePriests.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </div>\r\n                                    </div>\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 49 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Pension\EligiblePriests.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>

<div class=""modal fade"" id=""confirm-deposit"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title""><strong>Nouveau versement</strong></h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9dd3338b7437443a63aeed4305ddcc09222acd7c16120", async() => {
                WriteLiteral(@"
                    <div class=""form-group"">
                        <label class=""required"">Nom et prénom(s) du prêtre</label>
                        <input name=""priestName"" id=""priestName"" class=""form-control"" disabled />
                        <input type=""hidden"" id=""priestId"" name=""PriestId"" />
                    </div>
                    <div class=""form-group"">
                        <label class=""required"">Date de l'allocation</label>
                        <input type=""date"" name=""Date""");
                BeginWriteAttribute("value", " value=\"", 3938, "\"", 3982, 1);
#nullable restore
#line 75 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Pension\EligiblePriests.cshtml"
WriteAttributeValue("", 3946, DateTime.Now.ToString("yyyy-MM-dd"), 3946, 36, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control"" />
                    </div>
                    <div class=""form-group"">
                        <label class=""required"">Montant de l'allocation</label>
                        <div class=""input-group mb-3"">
                            <input class=""form-control"" name=""Ammount""");
                BeginWriteAttribute("value", " value=\"", 4290, "\"", 4319, 1);
#nullable restore
#line 80 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Pension\EligiblePriests.cshtml"
WriteAttributeValue("", 4298, ViewBag.PensionCosts, 4298, 21, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" readonly>
                            <div class=""input-group-append"">
                                <span class=""input-group-text"">XOF</span>
                            </div>
                        </div>
                    </div>
                    <div class=""text-right mt-3"">
                        <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Fermer</button>
                        <button type=""submit"" class=""btn btn-success"">Enregistrer</button>
                    </div>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $('#customDataTable tbody').on('click', '.btn-deposit', function () {
            var priestId = $(this).data('priest-id');
            var priestName = $(this).data('priest-name');
            $(""#confirm-deposit"").find("".modal-body #priestName"").val(priestName);
            $(""#confirm-deposit"").find("".modal-body #priestId"").val(priestId);
        });
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Priest>> Html { get; private set; }
    }
}
#pragma warning restore 1591
