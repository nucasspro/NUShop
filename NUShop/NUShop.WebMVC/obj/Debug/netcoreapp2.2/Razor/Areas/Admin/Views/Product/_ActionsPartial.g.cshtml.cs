#pragma checksum "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Areas\Admin\Views\Product\_ActionsPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c43c3d6d024569aa3f35f6dfde530aba69e41980"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Product__ActionsPartial), @"mvc.1.0.view", @"/Areas/Admin/Views/Product/_ActionsPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Product/_ActionsPartial.cshtml", typeof(AspNetCore.Areas_Admin_Views_Product__ActionsPartial))]
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
#line 1 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Areas\Admin\Views\_ViewImports.cshtml"
using NUShop.WebMVC;

#line default
#line hidden
#line 2 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Areas\Admin\Views\_ViewImports.cshtml"
using NUShop.WebMVC.Models;

#line default
#line hidden
#line 3 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Areas\Admin\Views\_ViewImports.cshtml"
using NUShop.Data.Entities;

#line default
#line hidden
#line 4 "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Areas\Admin\Views\_ViewImports.cshtml"
using NUShop.ViewModel.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c43c3d6d024569aa3f35f6dfde530aba69e41980", @"/Areas/Admin/Views/Product/_ActionsPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"160094fa2bf87d246bff18cf647fda8e1e362c43", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Product__ActionsPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("form-maintainance"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 605, true);
            WriteLiteral(@"<!-- Modal -->
<div class=""modal fade"" id=""product-modal"" role=""dialog"" aria-labelledby=""exampleModalLongTitle"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLongTitle"">Actions</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
            EndContext();
            BeginContext(605, 8579, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c43c3d6d024569aa3f35f6dfde530aba69e419805588", async() => {
                BeginContext(670, 4, true);
                WriteLiteral("\r\n\r\n");
                EndContext();
                BeginContext(704, 462, true);
                WriteLiteral(@"                    <div class=""form-group"">
                        <input type=""hidden"" id=""txt-hidden-id"" value=""0"" />
                        <label for=""txt-name"" class=""col-sm-2 control-label no-padding-right"">Name</label>
                        <div class=""col-sm-12"">
                            <input type=""text"" name=""txt-name"" class=""form-control"" id=""txt-name"" placeholder=""Name"">
                        </div>
                    </div>

");
                EndContext();
                BeginContext(1200, 343, true);
                WriteLiteral(@"                    <div class=""form-group"">
                        <label class=""col-sm-2 control-label no-padding-right"">Category</label>
                        <div class=""col-sm-12"">
                            <select class=""form-control"" id=""select-category""></select>
                        </div>
                    </div>

");
                EndContext();
                BeginContext(1574, 793, true);
                WriteLiteral(@"                    <div class=""form-group"">
                        <label for=""txt-image"" class=""col-sm-2 control-label no-padding-right"">Images</label>
                        <div class=""col-sm-12"">
                            <div class=""input-group"">
                                <input type=""text"" name=""txt-image"" class=""form-control"" id=""txt-image"" />
                                <input type=""file"" id=""file-input-image"" style=""display:none"" />
                                <span class=""input-group-btn"">
                                    <input type=""button"" id=""btn-select-image"" class=""btn btn-default"" value=""Browser"" />
                                </span>
                            </div>
                        </div>
                    </div>

");
                EndContext();
                BeginContext(2398, 1591, true);
                WriteLiteral(@"                    <div class=""form-group"" style=""display: flex;"">

                        <div class=""col-sm-4"" style=""margin-right:0px"">
                            <label for=""txt-price"" class=""col-sm-12 control-label no-padding-right"" style=""padding-left: 0;"">Price</label>
                            <div class=""col-sm-12"" style="" padding-left: 0;"">
                                <input type=""number"" name=""txt-price"" class=""form-control"" id=""txt-price"">
                            </div>
                        </div>

                        <div class=""col-sm-4"" style=""margin-right:0px"">
                            <label for=""txt-promotion-price"" class=""col-sm-12 control-label no-padding-right"" style=""padding-left: 0;"">Promotion Price</label>
                            <div class=""col-sm-12"" style="" padding-left: 0;"">
                                <input type=""number"" name=""txt-promotion-price"" class=""form-control"" id=""txt-promotion-price"" />
                            </div>
     ");
                WriteLiteral(@"                   </div>

                        <div class=""col-sm-4"" style=""margin-right:0px"">
                            <label for=""txt-original-price"" class=""col-sm-12 control-label no-padding-right"" style=""padding-left: 0;"">Original Price</label>
                            <div class=""col-sm-12"" style="" padding-left: 0;"">
                                <input type=""number"" name=""txt-original-price"" class=""form-control"" id=""txt-original-price"" />
                            </div>
                        </div>

                    </div>

");
                EndContext();
                BeginContext(4019, 364, true);
                WriteLiteral(@"                    <div class=""form-group"">
                        <label for=""txt-unit"" class=""col-sm-2 control-label no-padding-right"">Unit</label>
                        <div class=""col-sm-5"">
                            <input type=""text"" name=""txt-unit"" class=""form-control"" id=""txt-unit"">
                        </div>
                    </div>

");
                EndContext();
                BeginContext(4412, 385, true);
                WriteLiteral(@"                    <div class=""form-group"">
                        <label for=""txt-tags"" class=""col-sm-2 control-label no-padding-right"">Tag (separated by comma)</label>
                        <div class=""col-sm-10"">
                            <input type=""text"" name=""txt-tags"" class=""form-control"" id=""txt-tags"">
                        </div>
                    </div>

");
                EndContext();
                BeginContext(4834, 401, true);
                WriteLiteral(@"                    <div class=""form-group"">
                        <label for=""txtDescription"" class=""col-sm-2 control-label no-padding-right"">Description</label>
                        <div class=""col-sm-12"">
                            <textarea rows=""3"" name=""txtDescription"" class=""form-control"" id=""txtDescription""></textarea>
                        </div>
                    </div>

");
                EndContext();
                BeginContext(5268, 385, true);
                WriteLiteral(@"                    <div class=""form-group"">
                        <label for=""txtContent"" class=""col-sm-2 control-label no-padding-right"">Content</label>
                        <div class=""col-sm-12"">
                            <textarea rows=""3"" name=""txtContent"" class=""form-control"" id=""txtContent""></textarea>
                        </div>
                    </div>

");
                EndContext();
                BeginContext(5707, 1020, true);
                WriteLiteral(@"                    <div class=""form-group"">
                        <div class=""col-sm-offset-2 col-sm-12"">
                            <div class=""checkbox"">
                                <label>
                                    <input type=""checkbox"" checked=""checked"" id=""checkbox-status"" />
                                    <span class=""text"">Active.</span>
                                </label>
                                <label>
                                    <input type=""checkbox"" id=""checkbox-homeflag"" />
                                    <span class=""text"">Show on home.</span>
                                </label>
                                <label>
                                    <input type=""checkbox"" checked="""" id=""checkbox-hotflag"" />
                                    <span class=""text"">Hot product.</span>
                                </label>
                            </div>
                        </div>
                    </div>


");
                EndContext();
                BeginContext(6762, 584, true);
                WriteLiteral(@"                    <div class=""form-group"" style=""display: flex;"">
                        <div class=""col-sm-6"" style=""margin-right:0px"">
                            <label for=""txt-view-count"" class=""col-sm-6 control-label no-padding-right"" style=""padding-left: 0;"">ViewCount</label>
                            <div class=""col-sm-6"" style="" padding-left: 0;"">
                                <input type=""number"" name=""txt-view-count"" class=""form-control"" id=""txt-view-count"">
                            </div>
                        </div>
                    </div>

");
                EndContext();
                BeginContext(7405, 4, true);
                WriteLiteral("\r\n\r\n");
                EndContext();
                BeginContext(7447, 407, true);
                WriteLiteral(@"                    <div class=""form-group"">
                        <label for=""txt-seo-page-title"" class=""col-sm-2 control-label no-padding-right"">SEO Page Title</label>
                        <div class=""col-sm-12"">
                            <input type=""text"" name=""txt-seo-page-title"" class=""form-control"" id=""txt-seo-page-title"" />
                        </div>
                    </div>

");
                EndContext();
                BeginContext(7887, 385, true);
                WriteLiteral(@"                    <div class=""form-group"">
                        <label for=""txt-seo-alias"" class=""col-sm-2 control-label no-padding-right"">SEO URL</label>
                        <div class=""col-sm-12"">
                            <input type=""text"" name=""txt-seo-alias"" class=""form-control"" id=""txt-seo-alias"" />
                        </div>
                    </div>

");
                EndContext();
                BeginContext(8309, 395, true);
                WriteLiteral(@"                    <div class=""form-group"">
                        <label for=""txt-seo-keyword"" class=""col-sm-2 control-label no-padding-right"">SEO Keyword</label>
                        <div class=""col-sm-12"">
                            <input type=""text"" name=""txt-seo-keyword"" class=""form-control"" id=""txt-seo-keyword"" />
                        </div>
                    </div>

");
                EndContext();
                BeginContext(8743, 434, true);
                WriteLiteral(@"                    <div class=""form-group"">
                        <label for=""txt-seo-description"" class=""col-sm-4 control-label no-padding-right"">SEO Description</label>
                        <div class=""col-sm-12"">
                            <textarea rows=""3"" name=""txt-seo-description"" class=""form-control"" id=""txt-seo-description""></textarea>
                        </div>
                    </div>
                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(9184, 469, true);
            WriteLiteral(@"
            </div>
            <div class=""modal-footer"" id=""menu-context"">
                <button type=""button"" id=""btn-close"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                <button type=""button"" id=""btn-save"" class=""btn btn-primary"">Save changes</button>
                <button type=""button"" id=""btn-add"" class=""btn btn-primary"" style=""margin-right: 1rem;"">Create</button>
            </div>
        </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591