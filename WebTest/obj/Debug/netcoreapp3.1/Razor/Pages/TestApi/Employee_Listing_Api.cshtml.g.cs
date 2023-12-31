#pragma checksum "D:\Project\DotNetCore\WebTest\WebTest\Pages\TestApi\Employee_Listing_Api.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7085df4ff26433c16751cf586276c1867d72385f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebTest.Pages.TestApi.Pages_TestApi_Employee_Listing_Api), @"mvc.1.0.razor-page", @"/Pages/TestApi/Employee_Listing_Api.cshtml")]
namespace WebTest.Pages.TestApi
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7085df4ff26433c16751cf586276c1867d72385f", @"/Pages/TestApi/Employee_Listing_Api.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c88b295d316cec874966132c0b8ea65b9f96da12", @"/Pages/_ViewImports.cshtml")]
    public class Pages_TestApi_Employee_Listing_Api : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Project\DotNetCore\WebTest\WebTest\Pages\TestApi\Employee_Listing_Api.cshtml"
  
    ViewData["Title"] = "Employee Listing With API";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 7 "D:\Project\DotNetCore\WebTest\WebTest\Pages\TestApi\Employee_Listing_Api.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>
<div class=""table-responsive mt-3"">
    <table class=""table table-bordered"">
        <thead class=""bg-dark text-light"">
            <tr>
                <th style=""width:12%"">Employee ID</th>
                <th>Employee Name</th>
                <th>Email</th>
                <th>Mobile No</th>
                <th></th>
            </tr>
        </thead>
        <tbody id=""getrec"">
        </tbody>
    </table>
</div>

<script type=""text/javascript"">

    const uri = 'http://localhost:81/WebAPI/api/EmployeeDetails';
    let records = [];

    getEmployee();

    function getEmployee() {
        fetch(uri)
            .then(response => response.json())
            .then(data => _displayEmployees(data))
            .catch(error => console.error('Unable to get items.', error));
    }

    function _displayEmployees(data) {
        const tBody = document.getElementById('getrec');
        //tBody.innerHTML = '';

        //_displayCount(data.length);

        const butto");
            WriteLiteral(@"n = document.createElement('button');

        data.forEach(item => {
            let editButton = button.cloneNode(false);
            editButton.innerText = 'Edit';
            editButton.setAttribute('class', 'btn btn-success')
            editButton.setAttribute('onclick', `window.location.assign(""/TestApi/Employee_Edit_Api?EmpID="" + ${item.empID})`);

            let tr = tBody.insertRow();

            let td1 = tr.insertCell(0);
            let textEmpID = document.createTextNode(item.empID);
            td1.appendChild(textEmpID);

            let td2 = tr.insertCell(1);
            let textEmpName = document.createTextNode(item.empName);
            td2.appendChild(textEmpName);

            let td3 = tr.insertCell(2);
            let textEmail = document.createTextNode(item.email);
            td3.appendChild(textEmail);

            let td4 = tr.insertCell(3);
            let textMobile = document.createTextNode(item.mobileNo);
            td4.appendChild(textMobile);

   ");
            WriteLiteral("         let td5 = tr.insertCell(4);\r\n            td5.setAttribute(\"class\", \"text-center\")\r\n            td5.appendChild(editButton);\r\n        });\r\n\r\n        records = data;\r\n    }\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebTest.Pages.TestApi.Employee_Listing_ApiModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebTest.Pages.TestApi.Employee_Listing_ApiModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebTest.Pages.TestApi.Employee_Listing_ApiModel>)PageContext?.ViewData;
        public WebTest.Pages.TestApi.Employee_Listing_ApiModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
