#pragma checksum "D:\Project\DotNetCore\WebTest\WebTest\Pages\Employee_Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3fe0be0caa95ca5790c38ac70ddf13e3aa3919e8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebTest.Pages.Pages_Employee_Details), @"mvc.1.0.razor-page", @"/Pages/Employee_Details.cshtml")]
namespace WebTest.Pages
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
#line 1 "D:\Project\DotNetCore\WebTest\WebTest\Pages\_ViewImports.cshtml"
using WebTest;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3fe0be0caa95ca5790c38ac70ddf13e3aa3919e8", @"/Pages/Employee_Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c88b295d316cec874966132c0b8ea65b9f96da12", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Employee_Details : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Project\DotNetCore\WebTest\WebTest\Pages\Employee_Details.cshtml"
  
    ViewData["Title"] = "Employee Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2 class=\"text-center\">");
#nullable restore
#line 7 "D:\Project\DotNetCore\WebTest\WebTest\Pages\Employee_Details.cshtml"
                   Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3fe0be0caa95ca5790c38ac70ddf13e3aa3919e83779", async() => {
                WriteLiteral(@"
    <div class=""container"">
        <div class=""form-row"">
            <div class=""col-2"">
                <label for=""txtEmpName"">Employee ID:</label>
            </div>
            <div class=""col-5"">
                <input id=""txtEmpID"" name=""txtEmpID""");
                BeginWriteAttribute("value", " value=\"", 439, "\"", 472, 1);
#nullable restore
#line 16 "D:\Project\DotNetCore\WebTest\WebTest\Pages\Employee_Details.cshtml"
WriteAttributeValue("", 447, Model.employeeData.empId, 447, 25, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control"" readonly />
            </div>
        </div>
        <br />
        <div class=""form-row"">
            <div class=""col-2"">
                <label for=""txtEmpName"">Employee Name:</label>
            </div>
            <div class=""col-5"">
                <input id=""txtEmpName"" name=""txtEmpName""");
                BeginWriteAttribute("value", " value=\"", 798, "\"", 833, 1);
#nullable restore
#line 25 "D:\Project\DotNetCore\WebTest\WebTest\Pages\Employee_Details.cshtml"
WriteAttributeValue("", 806, Model.employeeData.empName, 806, 27, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control"" readonly />
            </div>
        </div>
        <br />
        <div class=""form-row"">
            <div class=""col-2"">
                <label for=""txtMobileNo"">Mobile No:</label>
            </div>
            <div class=""col-3"">
                <input type=""text"" id=""txtMobileNo"" name=""txtMobileNo""");
                BeginWriteAttribute("value", " value=\"", 1170, "\"", 1206, 1);
#nullable restore
#line 34 "D:\Project\DotNetCore\WebTest\WebTest\Pages\Employee_Details.cshtml"
WriteAttributeValue("", 1178, Model.employeeData.MobileNo, 1178, 28, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control"" readonly />
            </div>
        </div>
        <br />
        <div class=""form-row"">
            <div class=""col-2"">
                <label for=""txtEmail"">Email:</label>
            </div>
            <div class=""col-lg-3"">
                <input type=""text"" id=""txtEmail"" name=""txtEmail""");
                BeginWriteAttribute("value", " value=\"", 1533, "\"", 1566, 1);
#nullable restore
#line 43 "D:\Project\DotNetCore\WebTest\WebTest\Pages\Employee_Details.cshtml"
WriteAttributeValue("", 1541, Model.employeeData.email, 1541, 25, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control"" readonly />
            </div>
        </div>
        <br />
        <div class=""form-row"">
            <div class=""col-2"">
                <button name=""btnEdit"" class=""btn btn-success"" style=""width: 120px;"">Edit</button>
            </div>
        </div>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<script type=\"text/javascript\">\r\n\r\n    //function EditEmployees() {\r\n    //    var empID = document.getElementById(\"txtEmpID\").value;\r\n    //    window.location.assign(\"Employee_Edit?EmpID=\" + empID);\r\n    //}\r\n\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebTest.Pages.Employee_DetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebTest.Pages.Employee_DetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebTest.Pages.Employee_DetailsModel>)PageContext?.ViewData;
        public WebTest.Pages.Employee_DetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591