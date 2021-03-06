﻿using ZKWeb.Localize;
using ZKWeb.Plugins.Common.Admin.src.Managers;
using ZKWeb.Plugins.Common.Base.src.Scaffolding;
using ZKWeb.Plugins.Common.Base.src.Managers;
using ZKWeb.Plugins.Common.Base.src.Model;
using ZKWeb.Plugins.Common.UserPanel.src.Scaffolding;
using ZKWebStandard.Ioc;
using ZKWebStandard.Web;

namespace ZKWeb.Plugins.Common.UserPanel.src.UserPanelPages {
	/// <summary>
	/// 修改自身头像的表单
	/// </summary>
	[ExportMany]
	public class ChangeAvatarForm : UserPanelFormPageBuilder {
		public override string Group { get { return "Account Manage"; } }
		public override string GroupIconClass { get { return "fa fa-user"; } }
		public override string Name { get { return "Change Avatar"; } }
		public override string IconClass { get { return "fa fa-smile-o"; } }
		public override string Url { get { return "/home/change_avatar"; } }
		protected override IModelFormBuilder GetForm() { return new Form(); }

		/// <summary>
		/// 表单
		/// </summary>
		public class Form : ModelFormBuilder {
			/// <summary>
			/// 头像
			/// </summary>
			[FileUploaderField("Avatar")]
			public IHttpPostedFile Avatar { get; set; }
			/// <summary>
			/// 删除头像
			/// </summary>
			[CheckBoxField("DeleteAvatar")]
			public bool DeleteAvatar { get; set; }

			/// <summary>
			/// 绑定表单
			/// </summary>
			protected override void OnBind() { }

			/// <summary>
			/// 提交表单
			/// </summary>
			/// <returns></returns>
			protected override object OnSubmit() {
				var sessionManager = Application.Ioc.Resolve<SessionManager>();
				var session = sessionManager.GetSession();
				var userManager = Application.Ioc.Resolve<UserManager>();
				if (Avatar != null) {
					userManager.SaveAvatar(session.ReleatedId, Avatar.OpenReadStream());
				} else if (DeleteAvatar) {
					userManager.DeleteAvatar(session.ReleatedId);
				}
				return new {
					message = new T("Saved Successfully"),
					script = ScriptStrings.RefreshAfter(1500)
				};
			}
		}
	}
}
