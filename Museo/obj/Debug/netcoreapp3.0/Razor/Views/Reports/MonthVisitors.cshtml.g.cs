#pragma checksum "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Reports\MonthVisitors.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "663c54a248c155ca769691bd5ecf31e300564cf4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reports_MonthVisitors), @"mvc.1.0.view", @"/Views/Reports/MonthVisitors.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"663c54a248c155ca769691bd5ecf31e300564cf4", @"/Views/Reports/MonthVisitors.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c9bb0757771c05052f5070f7d77679ef6787767", @"/Views/_ViewImports.cshtml")]
    public class Views_Reports_MonthVisitors : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MonthVisitorsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MonthVisitors", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Reports", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 3 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Reports\MonthVisitors.cshtml"
  
    ViewData["Title"] = "Visitantes Mensuales";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            DefineSection("Breadcrumb", async() => {
                WriteLiteral("\r\n    <li class=\"breadcrumb-item\"><a class=\"breadcrumb-link\">Visitantes</a></li>\r\n    <li class=\"breadcrumb-item active\" aria-current=\"page\">Mensual</li>\r\n");
            }
            );
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n<div class=\"col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12\">\r\n    <div class=\"card\">\r\n        <div class=\"card-header d-flex\">\r\n            <h2 class=\"mb-0\">Visitantes Anuales ");
#nullable restore
#line 19 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Reports\MonthVisitors.cshtml"
                                           Write(Model.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral(".    Total: ");
#nullable restore
#line 19 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Reports\MonthVisitors.cshtml"
                                                                  Write(Model.Total);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n            <div class=\"dropdown ml-auto\">\r\n                <div class=\"input-group mb-3\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "663c54a248c155ca769691bd5ecf31e300564cf47296", async() => {
                WriteLiteral("\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "663c54a248c155ca769691bd5ecf31e300564cf47578", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 23 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Reports\MonthVisitors.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Year);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "663c54a248c155ca769691bd5ecf31e300564cf49305", async() => {
                    WriteLiteral("<i class=\"fas fa-search\"></i>");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
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
        <div class=""card-body"">
            <div class=""card"">
                <h5 class=""card-header"">Visitantes Totales</h5>
                <div class=""card-body"">
                    <div id=""morris_totalbar""></div>
                </div>
            </div>
        </div>

    </div>
</div>

<div class=""row"">
    <div class=""col-xl-6 col-lg-6 col-md-6 col-sm-12 col-12"">
        <div class=""card"">
            <h5 class=""card-header"">Adultos Extranjeros</h5>
            <div class=""card-body"">
                <div id=""morris_bar_AdultExt""></div>
            </div>
        </div>
    </div>
    <div class=""col-xl-6 col-lg-6 col-md-6 col-sm-12 col-12"">
        <div class=""card"">
            <h5 class=""card-header"">Adultos Nacionales </h5>
            <div class=""card-body"">
                <div id=""morris_bar_AdultNac""></div>
            </div>
        </div>
    </div>
</div>
<div class=""row"">
    <div class=""col-xl-");
            WriteLiteral(@"6 col-lg-6 col-md-6 col-sm-12 col-12"">
        <div class=""card"">
            <h5 class=""card-header"">Niños Solos</h5>
            <div class=""card-body"">
                <div id=""morris_bar_ChildAlone""></div>
            </div>
        </div>
    </div>
    <div class=""col-xl-6 col-lg-6 col-md-6 col-sm-12 col-12"">
        <div class=""card"">
            <h5 class=""card-header"">Niños Acompañados</h5>
            <div class=""card-body"">
                <div id=""morris_bar_ChildCom""></div>
            </div>
        </div>
    </div>
</div>
<div class=""row"">
    <div class=""col-xl-6 col-lg-6 col-md-6 col-sm-12 col-12"">
        <div class=""card"">
            <h5 class=""card-header"">Niños Extranjeros</h5>
            <div class=""card-body"">
                <div id=""morris_bar_ChildExt""></div>
            </div>
        </div>
    </div>
    <div class=""col-xl-6 col-lg-6 col-md-6 col-sm-12 col-12"">
        <div class=""card"">
            <h5 class=""card-header"">Residentes</h5>
          ");
            WriteLiteral("  <div class=\"card-body\">\r\n                <div id=\"morris_bar_Residents\"></div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script>
    var meses = [""Enero"", ""Febrero"", ""Marzo"", ""Abril"", ""Mayo"", ""Junio"", ""Julio"", ""Agosto"", ""Septiembre"", ""Octubre"", ""Noviembre"", ""Diciembre""]
   

    var $arrColors = ['#5969ff','#ff0000','#ffdd00','#a809f4','#2eec9c','#dfb327','#5969ff','#ff0000','#ffdd00','#a809f4','#2eec9c','#dfb327']
        var config = {
            xkey: 'label',
            ykeys: ['y'],
            labels: ['Total'],
            barColors: function (row, series, type) {
                return $arrColors[row.x];
            },
            resize: true,
            gridTextSize: '10px',
            hideHover: true
        };
        var result = ");
#nullable restore
#line 117 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Reports\MonthVisitors.cshtml"
                Write(Html.Raw(Model.TotalVisitors));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
        var datapoints = [];
        for (var i = 0; i < result.length; i++) {
            datapoints.push({ label: meses[i], y: result[i].y });
        }
        config.element = 'morris_totalbar';
        config.data = datapoints;
        new Morris.Bar(config);

        var result = ");
#nullable restore
#line 126 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Reports\MonthVisitors.cshtml"
                Write(Html.Raw(Model.AdultExt));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
        var datapoints = [];
        for (var i = 0; i < result.length; i++) {
            datapoints.push({ label: meses[i], y: result[i].y });
        }
        config.element = 'morris_bar_AdultExt';
        config.data = datapoints;
        new Morris.Bar(config);

        var result = ");
#nullable restore
#line 135 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Reports\MonthVisitors.cshtml"
                Write(Html.Raw(Model.AdultNac));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
        var datapoints = [];
        for (var i = 0; i < result.length; i++) {
            datapoints.push({ label: meses[i], y: result[i].y });
        }

        config.element = 'morris_bar_AdultNac';
        config.data = datapoints;
        new Morris.Bar(config);

        var result = ");
#nullable restore
#line 145 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Reports\MonthVisitors.cshtml"
                Write(Html.Raw(Model.ChildAlone));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
        var datapoints = [];
        for (var i = 0; i < result.length; i++) {
            datapoints.push({ label: meses[i], y: result[i].y });
        }

        config.element = 'morris_bar_ChildAlone';
        config.data = datapoints;
        new Morris.Bar(config);

        var result = ");
#nullable restore
#line 155 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Reports\MonthVisitors.cshtml"
                Write(Html.Raw(Model.ChildComp));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
        var datapoints = [];
        for (var i = 0; i < result.length; i++) {
            datapoints.push({ label: meses[i], y: result[i].y });
        }

        config.element = 'morris_bar_ChildCom';
        config.data = datapoints;
        new Morris.Bar(config);

        var result = ");
#nullable restore
#line 165 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Reports\MonthVisitors.cshtml"
                Write(Html.Raw(Model.ChildExt));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
        var datapoints = [];
        for (var i = 0; i < result.length; i++) {
            datapoints.push({ label: meses[i], y: result[i].y });
        }

        config.element = 'morris_bar_ChildExt';
        config.data = datapoints;
        new Morris.Bar(config);

        var result = ");
#nullable restore
#line 175 "E:\3er Año\SBD\MuseoHistoria\MuseoHistoria\Museo\Views\Reports\MonthVisitors.cshtml"
                Write(Html.Raw(Model.Resident));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
        var datapoints = [];
        for (var i = 0; i < result.length; i++) {
            datapoints.push({ label: meses[i], y: result[i].y });
        }

        config.element = 'morris_bar_Residents';
        config.data = datapoints;
        new Morris.Bar(config);

    </script>

    <script>
   

    var $arrColors = ['#5969ff','#ff0000','#ffdd00','#a809f4','#2eec9c','#dfb327','#5969ff','#ff0000','#ffdd00','#a809f4','#2eec9c','#dfb327']
        var config = {
            xkey: 'label',
            ykeys: ['a','b','c','d','e','f'],
            labels: ['Adultos Extranjeros', 'Adultos Nacionales', 'Niños Solos', 'Niños Acompañados', 'Niños Extranjeros', 'Residentes'],
            resize: true,
            gridTextSize: '10px',
            hideHover: true,
            stacked: true,
        };

        config.element = 'morris_stackedbar';
    config.data = datapoints;
    config.barColors = ['#191970','#0000cd','#4169e1','#6495ed','#00bfff','#b0e0e6']
    new Morris.Bar(con");
                WriteLiteral("fig);\r\n\r\n    </script>\r\n");
            }
            );
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MonthVisitorsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
