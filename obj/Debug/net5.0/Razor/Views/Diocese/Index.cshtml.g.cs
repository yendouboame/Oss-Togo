#pragma checksum "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Diocese\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5477278f3ffe0ad303777183251f5e6fab706dfc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Diocese_Index), @"mvc.1.0.view", @"/Views/Diocese/Index.cshtml")]
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
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\_ViewImports.cshtml"
using SolidarityFund.Models.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5477278f3ffe0ad303777183251f5e6fab706dfc", @"/Views/Diocese/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"afbdbb7707263e8061502f98fa24012629f4a7a1", @"/Views/_ViewImports.cshtml")]
    public class Views_Diocese_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Diocese>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_StatusMessage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Diocese", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-light btn-outline-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Actualiser"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_CreatePartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Diocese\Index.cshtml"
  
    ViewData["Title"] = "Liste de tous les diocèses";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5477278f3ffe0ad303777183251f5e6fab706dfc8405", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 7 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Diocese\Index.cshtml"
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
            WriteLiteral("\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-12 my-4\">\r\n        <div class=\"card shadow\">\r\n            <div class=\"card-body\">\r\n                <h5 class=\"card-title\"><strong>");
#nullable restore
#line 13 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Diocese\Index.cshtml"
                                          Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</strong></h5>
                <hr />
                <div class=""toolbar mb-4"">
                    <div class=""row"">
                        <div class=""col-auto mr-auto"">
                            <a href=""#"" data-toggle=""modal"" data-target=""#create"" class=""btn btn-sm btn-success"">
                                <i class=""fa fa-plus-circle"" aria-hidden=""true""></i> Nouveau
                            </a>
                        </div>
                        <div class=""col-auto"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5477278f3ffe0ad303777183251f5e6fab706dfc11103", async() => {
                WriteLiteral("\r\n                                <i class=\"fa fa-refresh\" aria-hidden=\"true\"></i>\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
                <table id=""customDataTable"" class=""table table-sm table-bordered table-hover text-center"">
                    <thead class=""thead-dark"">
                        <tr>
                            <th>");
#nullable restore
#line 32 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Diocese\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th class=\"text-right\">Nombre de prêtres</th>\r\n                            <th></th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 38 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Diocese\Index.cshtml"
                         foreach (var diocese in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 41 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Diocese\Index.cshtml"
                               Write(diocese.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"text-right\">");
#nullable restore
#line 42 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Diocese\Index.cshtml"
                                                  Write(diocese.Priests.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                <td class=""text-right"">
                                    <div class=""dropdown"">
                                        <button class=""btn btn-sm dropdown-toggle"" type=""button"" id=""actions"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                            <span class=""text-muted sr-only"">Action</span>
                                        </button>
                                        <div class=""dropdown-menu dropdown-menu-right"" aria-labelledby=""actions"" style=""line-height: 2;"">
                                            <a class=""dropdown-item btn-edit"" href=""#"" data-diocese-id=""");
#nullable restore
#line 49 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Diocese\Index.cshtml"
                                                                                                   Write(diocese.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Modifier</a>\r\n                                            <a class=\"dropdown-item btn-delete\" href=\"#\" data-toggle=\"modal\" data-target=\"#confirm-delete\" data-diocese-id=\"");
#nullable restore
#line 50 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Diocese\Index.cshtml"
                                                                                                                                                       Write(diocese.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Supprimer</a>\r\n                                        </div>\r\n                                    </div>\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 55 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Diocese\Index.cshtml"
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

<div class=""modal fade"" id=""create"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title""><strong>Nouveau diocèse</strong></h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5477278f3ffe0ad303777183251f5e6fab706dfc17455", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
#nullable restore
#line 71 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Diocese\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = new Diocese();

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
        </div>
    </div>
</div>

<div class=""modal fade"" id=""edit"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myModalLabel"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title""><strong>Modifier le diocèse</strong></h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5477278f3ffe0ad303777183251f5e6fab706dfc19732", async() => {
                WriteLiteral(@"
                    <input type=""hidden"" name=""Id"" id=""Id"" />
                    <div class=""form-group"">
                        <label class=""required"">Nom du diocèse</label>
                        <input id=""Name"" name=""Name"" class=""form-control"" required>
                    </div>
                    <button type=""submit"" class=""btn btn-primary"">Modifier</button>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
        </div>
    </div>
</div>

<div class=""modal fade"" id=""confirm-delete"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-body pb-2"">
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Fermer"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
                <h5 class=""modal-title"">Confirmation de suppression</h5>
                <hr class=""mt-2"" />
                Êtes-vous sûr(e) de vouloir supprimer ces informations ?
                <hr class=""mb-2"" />
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5477278f3ffe0ad303777183251f5e6fab706dfc22549", async() => {
                WriteLiteral(@"
                    <input type=""hidden"" id=""dioceseId"" name=""dioceseId"" />
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Non</button>
                    <button type=""submit"" class=""btn btn-danger"">Oui</button>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        $(document).ready(function () {\r\n            $(\'.btn-edit\').click(function (e) {\r\n\r\n                var dioceseId = $(this).data(\'diocese-id\');\r\n\r\n                $.ajax({\r\n                    url: \"");
#nullable restore
#line 130 "C:\Users\COECEPT-SIG\Desktop\Repositories\FreeLance\Caisse de Solidarité Eglise Catholique\SolidarityFund\Views\Diocese\Index.cshtml"
                     Write(Url.Action("Details", "Diocese"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""",
                    type: 'GET',
                    data: { ""dioceseId"" : dioceseId },
                    success: function (result) {
                        $('#edit #Id').val(result.id);
                        $('#edit #Name').val(result.name);
                        $('#edit').modal('show');
                    },
                    error: function (error) {
                        alert(error);
                    }
                });
            });

            $('#customDataTable tbody').on('click', '.btn-delete', function () {
                var dioceseId = $(this).data('diocese-id');
                $(""#confirm-delete"").find("".modal-body #dioceseId"").val(dioceseId);
            });
        });
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Diocese>> Html { get; private set; }
    }
}
#pragma warning restore 1591
