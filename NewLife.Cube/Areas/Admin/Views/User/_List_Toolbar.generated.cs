﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18444
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 1 "..\..\Areas\Admin\Views\User\_List_Toolbar.cshtml"
    using NewLife;
    
    #line default
    #line hidden
    using NewLife.Cube;
    using NewLife.Reflection;
    
    #line 2 "..\..\Areas\Admin\Views\User\_List_Toolbar.cshtml"
    using NewLife.Web;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Areas\Admin\Views\User\_List_Toolbar.cshtml"
    using XCode;
    
    #line default
    #line hidden
    using XCode.Membership;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Admin/Views/User/_List_Toolbar.cshtml")]
    public partial class _Areas_Admin_Views_User__List_Toolbar_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_Admin_Views_User__List_Toolbar_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Areas\Admin\Views\User\_List_Toolbar.cshtml"
  
    var fact = ViewBag.Factory as IEntityOperate;
    var page = ViewBag.Page as Pager;

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"tableTools-container\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"form-inline\"");

WriteLiteral(">\r\n");

            
            #line 10 "..\..\Areas\Admin\Views\User\_List_Toolbar.cshtml"
        
            
            #line default
            #line hidden
            
            #line 10 "..\..\Areas\Admin\Views\User\_List_Toolbar.cshtml"
         if (ManageProvider.User.Has(PermissionFlags.Insert))
        {
            
            
            #line default
            #line hidden
            
            #line 12 "..\..\Areas\Admin\Views\User\_List_Toolbar.cshtml"
       Write(Html.ActionLink("添加" + ViewContext.Controller.GetType().GetDisplayName(), "Add", null, new { @class = "btn btn-success btn-sm" }));

            
            #line default
            #line hidden
            
            #line 12 "..\..\Areas\Admin\Views\User\_List_Toolbar.cshtml"
                                                                                                                                              
        }

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <label");

WriteLiteral(" for=\"ddlCategory\"");

WriteLiteral(" class=\"control-label\"");

WriteLiteral(">类别：</label>\r\n            <select");

WriteLiteral(" name=\"ddlCategory\"");

WriteLiteral(" id=\"ddlCategory\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" onchange=\"$(\':submit\').click();\"");

WriteLiteral(">\r\n                <option");

WriteLiteral(" value=\"\"");

WriteLiteral(">全部</option>\r\n            </select>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <label");

WriteLiteral(" class=\"control-label\"");

WriteLiteral(" for=\"ddlAdmin\"");

WriteLiteral(">管理员：</label>\r\n            <select");

WriteLiteral(" name=\"ddlAdminID\"");

WriteLiteral(" id=\"ddlAdminID\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" onchange=\"$(\':submit\').click();\"");

WriteLiteral(">\r\n                <option");

WriteLiteral(" value=\"\"");

WriteLiteral(">全部</option>\r\n            </select>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <label");

WriteLiteral(" for=\"dtStart\"");

WriteLiteral(" class=\"control-label\"");

WriteLiteral(">时间：</label>\r\n            <input");

WriteLiteral(" name=\"dtStart\"");

WriteLiteral(" type=\"date\"");

WriteLiteral(" id=\"dtStart\"");

WriteLiteral(" dateformat=\"yyyy-MM-dd\"");

WriteLiteral(" class=\"form-control form_datetime\"");

WriteLiteral(" />\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <label");

WriteLiteral(" for=\"dtEnd\"");

WriteLiteral(" class=\"control-label\"");

WriteLiteral(">至</label>\r\n            <input");

WriteLiteral(" name=\"dtEnd\"");

WriteLiteral(" type=\"date\"");

WriteLiteral(" id=\"dtEnd\"");

WriteLiteral(" dateformat=\"yyyy-MM-dd\"");

WriteLiteral(" class=\"form-control form_datetime\"");

WriteLiteral(" />\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"pull-right form-group\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(">\r\n                <span");

WriteLiteral(" class=\"input-group-addon\"");

WriteLiteral(">\r\n                    <i");

WriteLiteral(" class=\"ace-icon fa fa-check\"");

WriteLiteral("></i>\r\n                </span>\r\n                <input");

WriteLiteral(" name=\"q\"");

WriteLiteral(" type=\"search\"");

WriteLiteral(" id=\"q\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1789), Tuple.Create("\"", 1810)
            
            #line 39 "..\..\Areas\Admin\Views\User\_List_Toolbar.cshtml"
, Tuple.Create(Tuple.Create("", 1797), Tuple.Create<System.Object, System.Int32>(Request["q"]
            
            #line default
            #line hidden
, 1797), false)
);

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"搜索关键字\"");

WriteLiteral(" />\r\n                <span");

WriteLiteral(" class=\"input-group-btn\"");

WriteLiteral(">\r\n                    <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-purple btn-sm\"");

WriteLiteral(">\r\n                        <span");

WriteLiteral(" class=\"ace-icon fa fa-search icon-on-right bigger-110\"");

WriteLiteral("></span>\r\n                        查询\r\n                    </button>\r\n            " +
"    </span>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
