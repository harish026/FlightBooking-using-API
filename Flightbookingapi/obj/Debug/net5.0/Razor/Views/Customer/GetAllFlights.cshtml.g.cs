#pragma checksum "C:\Users\h.a.cme5\Desktop\new\Flightbookingapi\Views\Customer\GetAllFlights.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8fea1f1ba2166345a14f6820ed0891702cc5d328"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_GetAllFlights), @"mvc.1.0.view", @"/Views/Customer/GetAllFlights.cshtml")]
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
#line 1 "C:\Users\h.a.cme5\Desktop\new\Flightbookingapi\Views\_ViewImports.cshtml"
using Flightbookingapi;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\h.a.cme5\Desktop\new\Flightbookingapi\Views\_ViewImports.cshtml"
using Flightbookingapi.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8fea1f1ba2166345a14f6820ed0891702cc5d328", @"/Views/Customer/GetAllFlights.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"655d9244d3d5140d69bc48a24e81021b0e6451f9", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_GetAllFlights : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Flightbookingapi.Models.Flight>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\h.a.cme5\Desktop\new\Flightbookingapi\Views\Customer\GetAllFlights.cshtml"
  
    Layout="/Views/Shared/_CustomerLayout.cshtml";
    ViewData["Title"] = "GetAllFlights";

#line default
#line hidden
#nullable disable
            WriteLiteral("<style>\r\n    body{\r\n        background-color: aliceblue;\r\n        font-family: sans-serif;\r\n        text-align: center;\r\n    }\r\n    table{\r\n    width: 100%;\r\n    border: skyblue 2px solid;\r\n    }\r\n</style>\r\n\r\n<h1>hello ");
#nullable restore
#line 19 "C:\Users\h.a.cme5\Desktop\new\Flightbookingapi\Views\Customer\GetAllFlights.cshtml"
     Write(ViewBag.cname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<h1>Available Flights</h1>\r\n\r\n<table class=\"table table-hover\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 27 "C:\Users\h.a.cme5\Desktop\new\Flightbookingapi\Views\Customer\GetAllFlights.cshtml"
           Write(Html.DisplayNameFor(model => model.Fid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 30 "C:\Users\h.a.cme5\Desktop\new\Flightbookingapi\Views\Customer\GetAllFlights.cshtml"
           Write(Html.DisplayNameFor(model => model.Fname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 33 "C:\Users\h.a.cme5\Desktop\new\Flightbookingapi\Views\Customer\GetAllFlights.cshtml"
           Write(Html.DisplayNameFor(model => model.Source));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 36 "C:\Users\h.a.cme5\Desktop\new\Flightbookingapi\Views\Customer\GetAllFlights.cshtml"
           Write(Html.DisplayNameFor(model => model.Dest));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 39 "C:\Users\h.a.cme5\Desktop\new\Flightbookingapi\Views\Customer\GetAllFlights.cshtml"
           Write(Html.DisplayNameFor(model => model.Dtime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 42 "C:\Users\h.a.cme5\Desktop\new\Flightbookingapi\Views\Customer\GetAllFlights.cshtml"
           Write(Html.DisplayNameFor(model => model.Atime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 45 "C:\Users\h.a.cme5\Desktop\new\Flightbookingapi\Views\Customer\GetAllFlights.cshtml"
           Write(Html.DisplayNameFor(model => model.Seat));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 48 "C:\Users\h.a.cme5\Desktop\new\Flightbookingapi\Views\Customer\GetAllFlights.cshtml"
           Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 54 "C:\Users\h.a.cme5\Desktop\new\Flightbookingapi\Views\Customer\GetAllFlights.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 57 "C:\Users\h.a.cme5\Desktop\new\Flightbookingapi\Views\Customer\GetAllFlights.cshtml"
           Write(Html.DisplayFor(modelItem => item.Fid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 60 "C:\Users\h.a.cme5\Desktop\new\Flightbookingapi\Views\Customer\GetAllFlights.cshtml"
           Write(Html.DisplayFor(modelItem => item.Fname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 63 "C:\Users\h.a.cme5\Desktop\new\Flightbookingapi\Views\Customer\GetAllFlights.cshtml"
           Write(Html.DisplayFor(modelItem => item.Source));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 66 "C:\Users\h.a.cme5\Desktop\new\Flightbookingapi\Views\Customer\GetAllFlights.cshtml"
           Write(Html.DisplayFor(modelItem => item.Dest));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 69 "C:\Users\h.a.cme5\Desktop\new\Flightbookingapi\Views\Customer\GetAllFlights.cshtml"
           Write(Html.DisplayFor(modelItem => item.Dtime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 72 "C:\Users\h.a.cme5\Desktop\new\Flightbookingapi\Views\Customer\GetAllFlights.cshtml"
           Write(Html.DisplayFor(modelItem => item.Atime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 75 "C:\Users\h.a.cme5\Desktop\new\Flightbookingapi\Views\Customer\GetAllFlights.cshtml"
           Write(Html.DisplayFor(modelItem => item.Seat));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 78 "C:\Users\h.a.cme5\Desktop\new\Flightbookingapi\Views\Customer\GetAllFlights.cshtml"
           Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 81 "C:\Users\h.a.cme5\Desktop\new\Flightbookingapi\Views\Customer\GetAllFlights.cshtml"
           Write(Html.ActionLink("Book", "Book", new { id=item.Fid }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n");
            WriteLiteral("            </td>\r\n        </tr>\r\n");
#nullable restore
#line 86 "C:\Users\h.a.cme5\Desktop\new\Flightbookingapi\Views\Customer\GetAllFlights.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Flightbookingapi.Models.Flight>> Html { get; private set; }
    }
}
#pragma warning restore 1591