#pragma checksum "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Document\All.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c41340e44c3ae948977bd9c6550e26bd21326fe2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Document_All), @"mvc.1.0.view", @"/Views/Document/All.cshtml")]
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
#line 1 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\_ViewImports.cshtml"
using Museo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\_ViewImports.cshtml"
using Museo.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\_ViewImports.cshtml"
using Museo.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c41340e44c3ae948977bd9c6550e26bd21326fe2", @"/Views/Document/All.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c9bb0757771c05052f5070f7d77679ef6787767", @"/Views/_ViewImports.cshtml")]
    public class Views_Document_All : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Dictionary<Document, string>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("toolbar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Document", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Add", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("padding-left:20px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-brand"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Update", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            DefineSection("Breadcrumb", async() => {
                WriteLiteral("\r\n    <li class=\"breadcrumb-item active\">Documentos</li>\r\n");
            }
            );
            WriteLiteral("\r\n\r\n\r\n<div class=\"card\">\r\n    <div class=\"card-header d-flex\">\r\n        <h4 class=\"mb-0\">Documentos</h4>\r\n        <div class=\"dropdown ml-auto\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c41340e44c3ae948977bd9c6550e26bd21326fe27336", async() => {
                WriteLiteral(" <i class=\"fa fa-angle-double-right\"></i> Insertar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"card-body bg-light\">\r\n");
#nullable restore
#line 17 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Document\All.cshtml"
          
            int count = 0;
            foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div>
                    <div class=""col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12"">
                        <div class=""card"">
                            <div class=""card-header d-flex"">
                                <h4 class=""card-header-title "">");
#nullable restore
#line 25 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Document\All.cshtml"
                                                          Write(item.Key.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>
                                <div class=""toolbar card-toolbar-tabs  ml-auto"">
                                    <ul class=""nav nav-pills"" id=""pills-tab"" role=""tablist"">
                                        <li class=""nav-item"">
                                            <a class=""nav-link active"" id=""pills-home-tab"" data-toggle=""pill""");
            BeginWriteAttribute("href", " href=\"", 1215, "\"", 1240, 2);
            WriteAttributeValue("", 1222, "#pills-home-", 1222, 12, true);
#nullable restore
#line 29 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Document\All.cshtml"
WriteAttributeValue("", 1234, count, 1234, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" role=""tab"" aria-controls=""pills-home"" aria-selected=""true"">Descripción</a>
                                        </li>
                                        <li class=""nav-item"">
                                            <a class=""nav-link"" id=""pills-profile-tab"" data-toggle=""pill""");
            BeginWriteAttribute("href", " href=\"", 1533, "\"", 1561, 2);
            WriteAttributeValue("", 1540, "#pills-profile-", 1540, 15, true);
#nullable restore
#line 32 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Document\All.cshtml"
WriteAttributeValue("", 1555, count, 1555, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" role=""tab"" aria-controls=""pills-profile"" aria-selected=""false"">Autor</a>
                                        </li>
                                        <li class=""nav-item"">
                                            <a class=""nav-link"" id=""pills-contact-tab"" data-toggle=""pill""");
            BeginWriteAttribute("href", " href=\"", 1852, "\"", 1880, 2);
            WriteAttributeValue("", 1859, "#pills-contact-", 1859, 15, true);
#nullable restore
#line 35 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Document\All.cshtml"
WriteAttributeValue("", 1874, count, 1874, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" role=""tab"" aria-controls=""pills-contact"" aria-selected=""false"">Publicación</a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div class=""card-body"">
                                <div class=""tab-content mb-3"" id=""pills-tabContent"">
                                    <div class=""tab-pane fade show active""");
            BeginWriteAttribute("id", " id=\"", 2341, "\"", 2363, 2);
            WriteAttributeValue("", 2346, "pills-home-", 2346, 11, true);
#nullable restore
#line 42 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Document\All.cshtml"
WriteAttributeValue("", 2357, count, 2357, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" role=\"tabpanel\" aria-labelledby=\"pills-home-tab\">\r\n                                        <h5>Descripción</h5>\r\n                                        <p>");
#nullable restore
#line 44 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Document\All.cshtml"
                                      Write(item.Key.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    </div>\r\n                                    <div class=\"tab-pane fade\"");
            BeginWriteAttribute("id", " id=\"", 2654, "\"", 2679, 2);
            WriteAttributeValue("", 2659, "pills-profile-", 2659, 14, true);
#nullable restore
#line 46 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Document\All.cshtml"
WriteAttributeValue("", 2673, count, 2673, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" role=\"tabpanel\" aria-labelledby=\"pills-profile-tab\">\r\n                                        <h5>Autor:</h5><p>");
#nullable restore
#line 47 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Document\All.cshtml"
                                                     Write(item.Key.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                        <h5>Publicado:</h5><p>");
#nullable restore
#line 48 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Document\All.cshtml"
                                                         Write(item.Key.PublicationDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    </div>\r\n                                    <div class=\"tab-pane fade\"");
            BeginWriteAttribute("id", " id=\"", 3014, "\"", 3039, 2);
            WriteAttributeValue("", 3019, "pills-contact-", 3019, 14, true);
#nullable restore
#line 50 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Document\All.cshtml"
WriteAttributeValue("", 3033, count, 3033, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" role=\"tabpanel\" aria-labelledby=\"pills-contact-tab\">\r\n                                        <h5>Fecha de subida:</h5><p> ");
#nullable restore
#line 51 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Document\All.cshtml"
                                                                Write(item.Key.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                        <h5>Categoría: ");
#nullable restore
#line 52 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Document\All.cshtml"
                                                  Write(item.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h5><p></p>\r\n                                    </div>\r\n                                </div>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c41340e44c3ae948977bd9c6550e26bd21326fe216084", async() => {
                WriteLiteral("Ver");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3390, "~/documents/", 3390, 12, true);
#nullable restore
#line 55 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Document\All.cshtml"
AddHtmlAttributeValue("", 3402, item.Key.Manager, 3402, 17, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c41340e44c3ae948977bd9c6550e26bd21326fe217727", async() => {
                WriteLiteral("Eliminar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 56 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Document\All.cshtml"
                                                                                                                                             WriteLiteral(item.Key.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c41340e44c3ae948977bd9c6550e26bd21326fe220384", async() => {
                WriteLiteral("Cambiar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 57 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Document\All.cshtml"
                                                                                                                                            WriteLiteral(item.Key.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 62 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Document\All.cshtml"
                count = count + 1;
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Dictionary<Document, string>> Html { get; private set; }
    }
}
#pragma warning restore 1591
