#pragma checksum "C:\Users\CLGS\Documents\Casadeshow\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "292d5a1f7b6ccb769af887378afd3560a5623b93"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"292d5a1f7b6ccb769af887378afd3560a5623b93", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f12c2e4141b4cccd1dd3bda2f18524311ba2af14", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Casadeshow.Models.Evento>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\CLGS\Documents\Casadeshow\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div style=\"text-align:center;border:3px solid green\">\r\n    <h1>Bem Vindos</h1>\r\n</div>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n\r\n        <tbody>\r\n            <br>\r\n");
#nullable restore
#line 15 "C:\Users\CLGS\Documents\Casadeshow\Views\Home\Index.cshtml"
 foreach (var item in Model) 
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""contaner row"" style=""border:3px solid blue"">

        <div class=""col-sm-4 text-center"">
            xxxxx
        </div>

        <div class=""col-sm-4 text-center"">
            <br>
                    <h5>
                        ");
#nullable restore
#line 26 "C:\Users\CLGS\Documents\Casadeshow\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </h5>\r\n                <br>\r\n                    ");
#nullable restore
#line 29 "C:\Users\CLGS\Documents\Casadeshow\Views\Home\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Capacidade));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <br>\r\n                    ");
#nullable restore
#line 31 "C:\Users\CLGS\Documents\Casadeshow\Views\Home\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.PrecoIngresso));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <br>\r\n                    ");
#nullable restore
#line 33 "C:\Users\CLGS\Documents\Casadeshow\Views\Home\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Data));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <br>\r\n                    ");
#nullable restore
#line 35 "C:\Users\CLGS\Documents\Casadeshow\Views\Home\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.QtdIngresso));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <br>\r\n                    ");
#nullable restore
#line 37 "C:\Users\CLGS\Documents\Casadeshow\Views\Home\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.CasaDeShow.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <br>\r\n                    ");
#nullable restore
#line 39 "C:\Users\CLGS\Documents\Casadeshow\Views\Home\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Genero.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <br>\r\n                <br>\r\n            </div>\r\n\r\n                <div class=\"col-sm-4 text-center\">\r\n                    <p></p>\r\n                </div>\r\n\r\n            </div>\r\n            <br>\r\n");
#nullable restore
#line 50 "C:\Users\CLGS\Documents\Casadeshow\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n        \r\n    </thead>\r\n</table>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Casadeshow.Models.Evento>> Html { get; private set; }
    }
}
#pragma warning restore 1591