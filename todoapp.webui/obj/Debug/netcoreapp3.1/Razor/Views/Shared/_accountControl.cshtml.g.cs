#pragma checksum "C:\Users\umut_\Desktop\GitHubProjects\ToDoApp-MVC\todoapp.webui\Views\Shared\_accountControl.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "53b21b543b276e7983a48b18d9b95e9e2a6985b3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__accountControl), @"mvc.1.0.view", @"/Views/Shared/_accountControl.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\umut_\Desktop\GitHubProjects\ToDoApp-MVC\todoapp.webui\Views\_ViewImports.cshtml"
using todoapp.entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\umut_\Desktop\GitHubProjects\ToDoApp-MVC\todoapp.webui\Views\_ViewImports.cshtml"
using todoapp.webui.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\umut_\Desktop\GitHubProjects\ToDoApp-MVC\todoapp.webui\Views\_ViewImports.cshtml"
using System;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\umut_\Desktop\GitHubProjects\ToDoApp-MVC\todoapp.webui\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\umut_\Desktop\GitHubProjects\ToDoApp-MVC\todoapp.webui\Views\_ViewImports.cshtml"
using todoapp.webui.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53b21b543b276e7983a48b18d9b95e9e2a6985b3", @"/Views/Shared/_accountControl.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23bf2b12ab402717629d3f7b907832f4732f0c8d", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__accountControl : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/account/login"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"  <hr>  
<!-- Pills navs -->
<div id=""alert"" class=""container alert alert-primary d-flex justify-content-center"" style=""width: 300px; ""role=""alert"">
  Have an account? Log In.
</div> 
<div class=""container d-flex justify-content-center"" style=""width: 300px;"">
  ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "53b21b543b276e7983a48b18d9b95e9e2a6985b35644", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "53b21b543b276e7983a48b18d9b95e9e2a6985b35906", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
#nullable restore
#line 8 "C:\Users\umut_\Desktop\GitHubProjects\ToDoApp-MVC\todoapp.webui\Views\Shared\_accountControl.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.All;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\Users\umut_\Desktop\GitHubProjects\ToDoApp-MVC\todoapp.webui\Views\Shared\_accountControl.cshtml"
     if (TempData["msg"]!=null){
      var message = TempData.Get<TempDataModel>("msg");

#line default
#line hidden
#nullable disable
                WriteLiteral("      <div");
                BeginWriteAttribute("class", " class=\"", 491, "\"", 528, 3);
                WriteAttributeValue("", 499, "alert", 499, 5, true);
                WriteAttributeValue(" ", 504, "alert-", 505, 7, true);
#nullable restore
#line 11 "C:\Users\umut_\Desktop\GitHubProjects\ToDoApp-MVC\todoapp.webui\Views\Shared\_accountControl.cshtml"
WriteAttributeValue("", 511, message.ClassAtr, 511, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" role=\"alert\">\r\n        ");
#nullable restore
#line 12 "C:\Users\umut_\Desktop\GitHubProjects\ToDoApp-MVC\todoapp.webui\Views\Shared\_accountControl.cshtml"
   Write(message.Message);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n      </div>\r\n");
#nullable restore
#line 14 "C:\Users\umut_\Desktop\GitHubProjects\ToDoApp-MVC\todoapp.webui\Views\Shared\_accountControl.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\umut_\Desktop\GitHubProjects\ToDoApp-MVC\todoapp.webui\Views\Shared\_accountControl.cshtml"
     if (TempData["token"] != null){

#line default
#line hidden
#nullable disable
                WriteLiteral("<div class=\"d-flex align-items-center justify-content-center\"><a");
                BeginWriteAttribute("href", " href=\'", 692, "\'", 717, 1);
#nullable restore
#line 15 "C:\Users\umut_\Desktop\GitHubProjects\ToDoApp-MVC\todoapp.webui\Views\Shared\_accountControl.cshtml"
WriteAttributeValue("", 699, TempData["token"], 699, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("class", " class=\"", 718, "\"", 726, 0);
                EndWriteAttribute();
                WriteLiteral(">Confirm</a></div>");
#nullable restore
#line 15 "C:\Users\umut_\Desktop\GitHubProjects\ToDoApp-MVC\todoapp.webui\Views\Shared\_accountControl.cshtml"
                                                                                                                                                         }

#line default
#line hidden
#nullable disable
                WriteLiteral("    <div class=\"mb-3\" style=\"width: 300px; \">\r\n      <label class=\"form-label\">Username</label>\r\n      <input data-val=\"true\" data-val-required=\"Please Fill The Username\" name=\"UserName\" class=\"form-control\">\r\n");
                WriteLiteral(@"    </div>
    <div class=""mb-3"" style=""width: 300px;"">
      <label class=""form-label"">Password</label>
      <input data-val=""true"" data-val-required=""Please Provide a Password"" name=""password"" class=""form-control"">
    </div>
    <div class=""mb-3 form-check"">
      <input  type=""checkbox"" class=""form-check-input"" id=""exampleCheck1"">
      <label class=""form-check-label"" for=""exampleCheck1"">Check me out</label>
    </div>
    <button id=""control"" type=""submit"" class=""btn btn-primary"">Login</button>
    <span>Or <a href=""#"" id=""register"">Register</a></span>
    <div>
      <a onclick=""showDonation()"" href=""#"" id=""donate"">Donate and Support Me!</a></span>
    </div>
    ");
#nullable restore
#line 34 "C:\Users\umut_\Desktop\GitHubProjects\ToDoApp-MVC\todoapp.webui\Views\Shared\_accountControl.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
                WriteLiteral("  ");
                WriteLiteral("\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>");
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
