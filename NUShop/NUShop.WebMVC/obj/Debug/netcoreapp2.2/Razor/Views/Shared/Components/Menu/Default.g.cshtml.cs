#pragma checksum "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7fe651d4a3d9636ae7fc5eefb53f4e25f83c6a62"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Menu_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Menu/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/Menu/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_Menu_Default))]
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
#line 1 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
using NUShop.ViewModel.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7fe651d4a3d9636ae7fc5eefb53f4e25f83c6a62", @"/Views/Shared/Components/Menu/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"498dadb98ab44da8f22dd3bbfc4141cfe3943b8d", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Menu_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CategoryViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(68, 463, true);
            WriteLiteral(@"

<nav class="""">
    <div class=""container"">
        <div class=""nav-inner"">
            <div class=""mm-toggle-wrap hidden-sm hidden-md hidden-lg"">
                <div class=""mm-toggle""><i class=""fa fa-align-justify""></i><span class=""mm-label"">Categories</span> </div>
            </div>
            <!-- BEGIN NAV -->
            <ul id=""nav"" class=""hidden-xs"">
                <li> <a href=""/"" class=""level-top active""><span>Home</span></a> </li>

");
            EndContext();
#line 15 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
                 foreach (var item in Model.Where(x => x.ParentId == null))
                {

#line default
#line hidden
            BeginContext(627, 70, true);
            WriteLiteral("                    <li class=\"drop-menu\">\r\n                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 697, "\"", 737, 5);
            WriteAttributeValue("", 704, "/", 704, 1, true);
#line 18 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
WriteAttributeValue("", 705, item.SeoAlias, 705, 16, false);

#line default
#line hidden
            WriteAttributeValue("", 721, "-", 721, 1, true);
#line 18 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
WriteAttributeValue("", 722, item.Id, 722, 10, false);

#line default
#line hidden
            WriteAttributeValue("", 732, ".html", 732, 5, true);
            EndWriteAttribute();
            BeginContext(738, 8, true);
            WriteLiteral("> <span>");
            EndContext();
            BeginContext(748, 9, false);
#line 18 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
                                                                       Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(758, 46, true);
            WriteLiteral("</span> </a>\r\n                        <ul>\r\n\r\n");
            EndContext();
#line 21 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
                             foreach (var subItem in Model.Where(y => y.ParentId == item.Id))
                            {

#line default
#line hidden
            BeginContext(930, 92, true);
            WriteLiteral("                                <li class=\"sub-cat\">\r\n                                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1022, "\"", 1068, 5);
            WriteAttributeValue("", 1029, "/", 1029, 1, true);
#line 24 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
WriteAttributeValue("", 1030, subItem.SeoAlias, 1030, 19, false);

#line default
#line hidden
            WriteAttributeValue("", 1049, "-", 1049, 1, true);
#line 24 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
WriteAttributeValue("", 1050, subItem.Id, 1050, 13, false);

#line default
#line hidden
            WriteAttributeValue("", 1063, ".html", 1063, 5, true);
            EndWriteAttribute();
            BeginContext(1069, 7, true);
            WriteLiteral("><span>");
            EndContext();
            BeginContext(1078, 12, false);
#line 24 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
                                                                                        Write(subItem.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1091, 55, true);
            WriteLiteral("</span></a>\r\n                                    <ul>\r\n");
            EndContext();
#line 26 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
                                         foreach (var subSubItem in Model.Where(z => z.ParentId == subItem.Id))
                                        {

#line default
#line hidden
            BeginContext(1302, 51, true);
            WriteLiteral("                                            <li> <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1353, "\"", 1405, 5);
            WriteAttributeValue("", 1360, "/", 1360, 1, true);
#line 28 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
WriteAttributeValue("", 1361, subSubItem.SeoAlias, 1361, 22, false);

#line default
#line hidden
            WriteAttributeValue("", 1383, "-", 1383, 1, true);
#line 28 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
WriteAttributeValue("", 1384, subSubItem.Id, 1384, 16, false);

#line default
#line hidden
            WriteAttributeValue("", 1400, ".html", 1400, 5, true);
            EndWriteAttribute();
            BeginContext(1406, 8, true);
            WriteLiteral("> <span>");
            EndContext();
            BeginContext(1416, 15, false);
#line 28 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
                                                                                                            Write(subSubItem.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1432, 20, true);
            WriteLiteral("</span> </a> </li>\r\n");
            EndContext();
#line 29 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
                                        }

#line default
#line hidden
            BeginContext(1495, 84, true);
            WriteLiteral("\r\n                                    </ul>\r\n                                </li>\r\n");
            EndContext();
#line 33 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
                            }

#line default
#line hidden
            BeginContext(1610, 58, true);
            WriteLiteral("                        </ul>\r\n                    </li>\r\n");
            EndContext();
#line 36 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
                }

#line default
#line hidden
            BeginContext(1687, 161, true);
            WriteLiteral("\r\n                <li class=\"mega-menu\"> <a class=\"level-top\" href=\"blog.html\"><span>Blog</span></a> </li>\r\n            </ul>\r\n        </div>\r\n    </div>\r\n</nav>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CategoryViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591