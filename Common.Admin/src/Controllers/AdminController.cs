﻿using DryIoc;
using DryIocAttributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZKWeb;
using ZKWeb.Core;
using ZKWeb.Model;
using ZKWeb.Model.ActionResults;
using ZKWeb.Plugins.Common.Admin.src;
using ZKWeb.Plugins.Common.Admin.src.Forms;
using ZKWeb.Plugins.Common.Base.src.Database;

namespace ZKWeb.Plugins.Common.Base.src.Controllers {
	/// <summary>
	/// 后台的控制器
	/// </summary>
	[ExportMany]
	public class AdminController : IController {
		/// <summary>
		/// 后台首页
		/// </summary>
		/// <returns></returns>
		[Action("admin")]
		public IActionResult Admin() {
			return new TemplateResult("common.admin/admin_index.html");
		}

		/// <summary>
		/// 后台登陆页
		/// </summary>
		/// <returns></returns>
		[Action("admin/login")]
		[Action("admin/login", HttpMethods.POST)]
		public IActionResult Login() {
			var form = new AdminLoginForm();
			if (HttpContext.Current.Request.HttpMethod == HttpMethods.POST) {
				return new JsonResult(form.Submit());
			} else {
				form.Bind();
				var adminManager = Application.Ioc.Resolve<AdminManager>();
				var warning = adminManager.GetLoginWarning();
				return new TemplateResult("common.admin/admin_login.html", new { form, warning });
			}
		}

		/// <summary>
		/// 退出后台登陆
		/// </summary>
		/// <returns></returns>
		[Action("admin/logout", HttpMethods.POST)]
		public IActionResult Logout() {
			var userManager = Application.Ioc.Resolve<UserManager>();
			userManager.Logout();
			return new RedirectResult("/admin/login");
		}
	}
}
