#pragma checksum "D:\Fetch Training\DotnetProject\NUShop\NUShop\NUShop.WebMVC\Areas\Admin\Views\Category\_ActionsPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1585264869460855b1b80d0598d08c0ef365c16d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Category__ActionsPartial), @"mvc.1.0.view", @"/Areas/Admin/Views/Category/_ActionsPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Category/_ActionsPartial.cshtml", typeof(AspNetCore.Areas_Admin_Views_Category__ActionsPartial))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1585264869460855b1b80d0598d08c0ef365c16d", @"/Areas/Admin/Views/Category/_ActionsPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"160094fa2bf87d246bff18cf647fda8e1e362c43", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Category__ActionsPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            BeginContext(0, 611, true);
            WriteLiteral(@"<!-- Modal -->
<div class=""modal fade"" id=""category-modal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLongTitle"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
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
            BeginContext(611, 6018, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1585264869460855b1b80d0598d08c0ef365c16d5603", async() => {
                BeginContext(676, 460, true);
                WriteLiteral(@"

                    <div class=""form-group"">
                        <input type=""hidden"" id=""hidden-id"" value=""0"" />
                        <label for=""txt-name"" class=""col-sm-2 control-label no-padding-right"">Name</label>
                        <div class=""col-sm-10"">
                            <input type=""text"" name=""txt-name"" class=""form-control"" id=""txt-name"" placeholder=""Name"">
                        </div>
                    </div>
");
                EndContext();
                BeginContext(1505, 277, true);
                WriteLiteral(@"                    <div class=""form-group"">
                        <label class=""col-sm-2 control-label no-padding-right"">Parent</label>
                        <div class=""col-sm-10"">
                            <select class=""form-control"" id=""select-parent""></select>
");
                EndContext();
                BeginContext(1901, 4721, true);
                WriteLiteral(@"                        </div>
                    </div>
                    <div class=""form-group"">
                        <label for=""txt-alias"" class=""col-sm-2 control-label no-padding-right"">Alias</label>
                        <div class=""col-sm-10"">
                            <input type=""text"" name=""txt-alias"" class=""form-control"" id=""txt-alias"">
                        </div>
                    </div>
                    <div class=""form-group"">
                        <label for=""txt-des"" class=""col-sm-2 control-label no-padding-right"">Description</label>
                        <div class=""col-sm-10"">
                            <textarea rows=""3"" name=""txt-des"" class=""form-control"" id=""txt-des""></textarea>
                        </div>
                    </div>
                    <div class=""form-group"">
                        <label for=""txt-sort-order"" class=""col-sm-2 control-label no-padding-right"">Sort Order</label>
                        <div class=""col-sm-10"">
    ");
                WriteLiteral(@"                        <input type=""number"" name=""txt-sort-order"" class=""form-control"" id=""txt-sort-order"">
                        </div>
                    </div>
                    <div class=""form-group"">
                        <label for=""txt-home-order"" class=""col-sm-2 control-label no-padding-right"">Home Order</label>
                        <div class=""col-sm-10"">
                            <input type=""number"" name=""txt-home-order"" class=""form-control"" id=""txt-home-order"">
                        </div>
                    </div>
                    <div class=""form-group"">
                        <label for=""txt-image"" class=""col-sm-2 control-label no-padding-right"">Images</label>
                        <div class=""col-sm-6"">
                            <div class=""input-group"">
                                <input type=""text"" name=""txt-image"" class=""form-control"" id=""txt-image"" />
                                <input type=""file"" id=""file-input-image"" style=""display:none"" />");
                WriteLiteral(@"
                                <span class=""input-group-btn"">
                                    <input type=""button"" id=""btn-select-image"" class=""btn btn-default"" value=""Browser"" />
                                </span>
                            </div><!-- /input-group -->

                        </div>

                    </div>
                    <div class=""form-group"">
                        <label for=""txt-seo-title"" class=""col-sm-2 control-label no-padding-right"">SEO Title</label>
                        <div class=""col-sm-10"">
                            <input type=""text"" name=""txt-seo-title"" class=""form-control"" id=""txt-seo-title"">
                        </div>
                    </div>
                    <div class=""form-group"">
                        <label for=""txt-seo-alias"" class=""col-sm-2 control-label no-padding-right"">URL SEO</label>
                        <div class=""col-sm-10"">
                            <input type=""text"" name=""txt-seo-alias"" class=""form-");
                WriteLiteral(@"control"" id=""txt-seo-alias"">
                        </div>
                    </div>
                    <div class=""form-group"">
                        <label for=""txt-seo-keyword"" class=""col-sm-2 control-label no-padding-right"">SEO Keyword</label>
                        <div class=""col-sm-10"">
                            <input type=""text"" name=""txt-seo-keyword"" class=""form-control"" id=""txt-seo-keyword"">
                        </div>
                    </div>
                    <div class=""form-group"">
                        <label for=""txt-seo-des"" class=""col-sm-2 control-label no-padding-right"">SEO Description</label>
                        <div class=""col-sm-10"">
                            <textarea rows=""3"" name=""txt-seo-des"" class=""form-control"" id=""txt-seo-des""></textarea>
                        </div>
                    </div>
                    <div class=""form-group"">
                        <div class=""col-sm-offset-2 col-sm-10"">
                            <div class");
                WriteLiteral(@"=""checkbox"">
                                <label>
                                    <input type=""checkbox"" checked=""checked"" id=""checkbox-status"">
                                    <span class=""text"">Active.</span>
                                </label>
                                <label>
                                    <input type=""checkbox"" id=""checkbox-show-home"">
                                    <span class=""text"">Show on home.</span>
                                </label>
                            </div>
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
            BeginContext(6629, 349, true);
            WriteLiteral(@"
            </div>
            <div class=""modal-footer"" id=""menu-context"">
                <button type=""button"" id=""btn-close"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                <button type=""button"" id=""btn-save"" class=""btn btn-primary"">Save changes</button>
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
