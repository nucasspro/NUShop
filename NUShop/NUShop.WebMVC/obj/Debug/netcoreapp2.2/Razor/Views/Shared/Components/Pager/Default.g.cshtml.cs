#pragma checksum "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Pager\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "baa9b313e8aad88d77c9e8a78180bc969fccc11d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Pager_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Pager/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/Pager/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_Pager_Default))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\_ViewImports.cshtml"
using NUShop.WebMVC;

#line default
#line hidden
#line 2 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\_ViewImports.cshtml"
using NUShop.WebMVC.Models;

#line default
#line hidden
#line 3 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\_ViewImports.cshtml"
using NUShop.Data.Entities;

#line default
#line hidden
#line 4 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\_ViewImports.cshtml"
using NUShop.ViewModel.ViewModels.AccountViewModels;

#line default
#line hidden
#line 5 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 6 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\_ViewImports.cshtml"
using System.Linq;

#line default
#line hidden
#line 1 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Pager\Default.cshtml"
using NUShop.Utilities.DTOs;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"baa9b313e8aad88d77c9e8a78180bc969fccc11d", @"/Views/Shared/Components/Pager/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28ce93ebee90d3556cc0d908300095368032538a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Pager_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedResultBase>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Pager\Default.cshtml"
  
    var urlTemplate = Url.Action() + "?pageIndex={0}";
    var request = ViewContext.HttpContext.Request;
    foreach (var key in request.Query.Keys)
    {
        if (key == "pageIndex")
        {
            continue;
        }

        urlTemplate += "&" + key + "=" + request.Query[key];
    }

    var startIndex = Math.Max(Model.CurrentPage - 5, 1);
    var finishIndex = Math.Min(Model.CurrentPage + 5, Model.PageCount);

#line default
#line hidden
            BeginContext(503, 88, true);
            WriteLiteral("<div class=\"toolbar\">\r\n    <div class=\"row\">\r\n        <div class=\"col-sm-6 text-left\">\r\n");
            EndContext();
#line 22 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Pager\Default.cshtml"
             if (Model.PageCount > 1)
            {

#line default
#line hidden
            BeginContext(645, 41, true);
            WriteLiteral("                <ul class=\"pagination\">\r\n");
            EndContext();
#line 25 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Pager\Default.cshtml"
                     if (Model.CurrentPage != startIndex)
                    {

#line default
#line hidden
            BeginContext(768, 60, true);
            WriteLiteral("                        <li>\r\n                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 828, "\"", 890, 1);
#line 28 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 835, urlTemplate.Replace("{0}", Model.PageCount.ToString()), 835, 55, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(891, 134, true);
            WriteLiteral(">\r\n                                <i class=\"fa fa-angle-left\"></i>\r\n                            </a>\r\n                        </li>\r\n");
            EndContext();
#line 32 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Pager\Default.cshtml"
                    }

#line default
#line hidden
            BeginContext(1048, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 34 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Pager\Default.cshtml"
                     for (int i = startIndex; i < finishIndex; i++)
                    {
                        if (i == Model.CurrentPage)
                        {

#line default
#line hidden
            BeginContext(1222, 53, true);
            WriteLiteral("                            <li class=\"active\"><span>");
            EndContext();
            BeginContext(1277, 1, false);
#line 38 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Pager\Default.cshtml"
                                                 Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(1279, 14, true);
            WriteLiteral("</span></li>\r\n");
            EndContext();
#line 39 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Pager\Default.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(1377, 34, true);
            WriteLiteral("                            <li><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1411, "\"", 1459, 1);
#line 42 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 1418, urlTemplate.Replace("{0}", i.ToString()), 1418, 41, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1460, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1463, 1, false);
#line 42 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Pager\Default.cshtml"
                                                                                Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(1465, 11, true);
            WriteLiteral("</a></li>\r\n");
            EndContext();
#line 43 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Pager\Default.cshtml"
                        }
                    }

#line default
#line hidden
            BeginContext(1526, 20, true);
            WriteLiteral("                    ");
            EndContext();
#line 45 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Pager\Default.cshtml"
                     if (Model.CurrentPage != finishIndex)
                    {

#line default
#line hidden
            BeginContext(1609, 68, true);
            WriteLiteral("                            <li>\r\n                                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1677, "\"", 1739, 1);
#line 48 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 1684, urlTemplate.Replace("{0}", Model.PageCount.ToString()), 1684, 55, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1740, 147, true);
            WriteLiteral(">\r\n                                    <i class=\"fa fa-angle-right\"></i>\r\n                                </a>\r\n                            </li>\r\n");
            EndContext();
#line 52 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Pager\Default.cshtml"
                    }

#line default
#line hidden
            BeginContext(1910, 44, true);
            WriteLiteral("                   \r\n                </ul>\r\n");
            EndContext();
#line 55 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Pager\Default.cshtml"
            }

#line default
#line hidden
            BeginContext(1969, 65, true);
            WriteLiteral("        </div>\r\n        <div class=\"col-sm-6 text-right\">Showing ");
            EndContext();
            BeginContext(2036, 20, false);
#line 57 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Pager\Default.cshtml"
                                             Write(Model.FirstRowOnPage);

#line default
#line hidden
            EndContext();
            BeginContext(2057, 4, true);
            WriteLiteral(" to ");
            EndContext();
            BeginContext(2063, 19, false);
#line 57 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Pager\Default.cshtml"
                                                                        Write(Model.LastRowOnPage);

#line default
#line hidden
            EndContext();
            BeginContext(2083, 4, true);
            WriteLiteral(" of ");
            EndContext();
            BeginContext(2089, 14, false);
#line 57 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Pager\Default.cshtml"
                                                                                                  Write(Model.RowCount);

#line default
#line hidden
            EndContext();
            BeginContext(2104, 2, true);
            WriteLiteral(" (");
            EndContext();
            BeginContext(2108, 15, false);
#line 57 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Pager\Default.cshtml"
                                                                                                                     Write(Model.PageCount);

#line default
#line hidden
            EndContext();
            BeginContext(2124, 33, true);
            WriteLiteral(" Pages)</div>\r\n    </div>\r\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedResultBase> Html { get; private set; }
    }
}
#pragma warning restore 1591