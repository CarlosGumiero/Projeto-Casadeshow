#pragma checksum "C:\Users\CLGS\Documents\Casadeshow\Views\Compra\HistCompra.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "311d9687b50ce0e24d39bad9f16d865de5b6b36b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Compra_HistCompra), @"mvc.1.0.view", @"/Views/Compra/HistCompra.cshtml")]
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
#line 1 "C:\Users\CLGS\Documents\Casadeshow\Views\_ViewImports.cshtml"
using Casadeshow;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\CLGS\Documents\Casadeshow\Views\_ViewImports.cshtml"
using Casadeshow.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"311d9687b50ce0e24d39bad9f16d865de5b6b36b", @"/Views/Compra/HistCompra.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f12c2e4141b4cccd1dd3bda2f18524311ba2af14", @"/Views/_ViewImports.cshtml")]
    public class Views_Compra_HistCompra : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Casadeshow.Models.Compra>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\CLGS\Documents\Casadeshow\Views\Compra\HistCompra.cshtml"
      
    ViewData["Title"] = "Eventos";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div style=\"text-align:center;border:3px solid green\">\r\n    <h1>Bem Vindo</h1>\r\n</div>\r\n\r\n    <table class=\"table\">\r\n    <thead>\r\n        <tbody>\r\n            <br>\r\n");
#nullable restore
#line 15 "C:\Users\CLGS\Documents\Casadeshow\Views\Compra\HistCompra.cshtml"
             foreach (var item in Model) 
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"contaner row\" style=\"border:3px solid blue\">\r\n\r\n                    <div class=\"col-sm-3  centralizar\">\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 481, "\"", 556, 1);
#nullable restore
#line 20 "C:\Users\CLGS\Documents\Casadeshow\Views\Compra\HistCompra.cshtml"
WriteAttributeValue("", 487, Url.Action("PegarImagem", "Evento", new {id = item.Evento.EventoId}), 487, 69, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"200px\" height=\"200px\" />\r\n                    </div>\r\n\r\n                    <div class=\"col-sm-7 text-center \">\r\n                        <br><br>\r\n                                <h5>\r\n                                    ");
#nullable restore
#line 26 "C:\Users\CLGS\Documents\Casadeshow\Views\Compra\HistCompra.cshtml"
                               Write(Html.DisplayFor(modelItem => item.CompraId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </h5>\r\n                            <br>\r\n                                R$ ");
#nullable restore
#line 29 "C:\Users\CLGS\Documents\Casadeshow\Views\Compra\HistCompra.cshtml"
                              Write(Html.DisplayFor(modelItem => item.Evento.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral(" taokeis\r\n                            <br>\r\n                                Data: ");
#nullable restore
#line 31 "C:\Users\CLGS\Documents\Casadeshow\Views\Compra\HistCompra.cshtml"
                                 Write(Html.DisplayFor(modelItem => item.Data));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <br>\r\n                    </div>\r\n\r\n                    <div class=\"col-sm-2 centralizar\" >\r\n                    </div>\r\n\r\n                </div>\r\n                <br>\r\n");
#nullable restore
#line 40 "C:\Users\CLGS\Documents\Casadeshow\Views\Compra\HistCompra.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n        \r\n    </thead>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Casadeshow.Models.Compra>> Html { get; private set; }
    }
}
#pragma warning restore 1591
