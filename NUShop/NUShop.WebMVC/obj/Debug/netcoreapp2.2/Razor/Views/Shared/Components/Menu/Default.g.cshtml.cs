#pragma checksum "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bbf8e45357b89e7d81f0365a89d4ccc1a42fddce"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Menu_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Menu/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/Menu/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_Menu_Default))]
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
#line 1 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
using NUShop.ViewModel.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bbf8e45357b89e7d81f0365a89d4ccc1a42fddce", @"/Views/Shared/Components/Menu/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28ce93ebee90d3556cc0d908300095368032538a", @"/Views/_ViewImports.cshtml")]
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
            BeginWriteAttribute("href", " href=\"", 697, "\"", 739, 5);
            WriteAttributeValue("", 704, "/", 704, 1, true);
#line 18 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
WriteAttributeValue("", 705, item.SeoAlias, 705, 16, false);

#line default
#line hidden
            WriteAttributeValue("", 721, "-c.", 721, 3, true);
#line 18 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
WriteAttributeValue("", 724, item.Id, 724, 10, false);

#line default
#line hidden
            WriteAttributeValue("", 734, ".html", 734, 5, true);
            EndWriteAttribute();
            BeginContext(740, 8, true);
            WriteLiteral("> <span>");
            EndContext();
            BeginContext(750, 9, false);
#line 18 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
                                                                         Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(760, 46, true);
            WriteLiteral("</span> </a>\r\n                        <ul>\r\n\r\n");
            EndContext();
#line 21 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
                             foreach (var subItem in Model.Where(y => y.ParentId == item.Id))
                            {

#line default
#line hidden
            BeginContext(932, 92, true);
            WriteLiteral("                                <li class=\"sub-cat\">\r\n                                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1024, "\"", 1072, 5);
            WriteAttributeValue("", 1031, "/", 1031, 1, true);
#line 24 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
WriteAttributeValue("", 1032, subItem.SeoAlias, 1032, 19, false);

#line default
#line hidden
            WriteAttributeValue("", 1051, "-c.", 1051, 3, true);
#line 24 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
WriteAttributeValue("", 1054, subItem.Id, 1054, 13, false);

#line default
#line hidden
            WriteAttributeValue("", 1067, ".html", 1067, 5, true);
            EndWriteAttribute();
            BeginContext(1073, 7, true);
            WriteLiteral("><span>");
            EndContext();
            BeginContext(1082, 12, false);
#line 24 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
                                                                                          Write(subItem.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1095, 55, true);
            WriteLiteral("</span></a>\r\n                                    <ul>\r\n");
            EndContext();
#line 26 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
                                         foreach (var subSubItem in Model.Where(z => z.ParentId == subItem.Id))
                                        {

#line default
#line hidden
            BeginContext(1306, 51, true);
            WriteLiteral("                                            <li> <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1357, "\"", 1411, 5);
            WriteAttributeValue("", 1364, "/", 1364, 1, true);
#line 28 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
WriteAttributeValue("", 1365, subSubItem.SeoAlias, 1365, 22, false);

#line default
#line hidden
            WriteAttributeValue("", 1387, "-c.", 1387, 3, true);
#line 28 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
WriteAttributeValue("", 1390, subSubItem.Id, 1390, 16, false);

#line default
#line hidden
            WriteAttributeValue("", 1406, ".html", 1406, 5, true);
            EndWriteAttribute();
            BeginContext(1412, 8, true);
            WriteLiteral("> <span>");
            EndContext();
            BeginContext(1422, 15, false);
#line 28 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
                                                                                                              Write(subSubItem.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1438, 20, true);
            WriteLiteral("</span> </a> </li>\r\n");
            EndContext();
#line 29 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
                                        }

#line default
#line hidden
            BeginContext(1501, 84, true);
            WriteLiteral("\r\n                                    </ul>\r\n                                </li>\r\n");
            EndContext();
#line 33 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
                            }

#line default
#line hidden
            BeginContext(1616, 58, true);
            WriteLiteral("                        </ul>\r\n                    </li>\r\n");
            EndContext();
#line 36 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Views\Shared\Components\Menu\Default.cshtml"
                }

#line default
#line hidden
            BeginContext(1693, 161, true);
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
