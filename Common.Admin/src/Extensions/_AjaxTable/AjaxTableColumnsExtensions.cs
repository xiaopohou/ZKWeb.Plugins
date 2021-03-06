﻿using System.Collections.Generic;
using ZKWeb.Localize;
using ZKWeb.Plugins.Common.Admin.src.Model;
using ZKWeb.Plugins.Common.Base.src.Extensions;
using ZKWeb.Plugins.Common.Base.src.Model;

namespace ZKWeb.Plugins.Common.Admin.src.Extensions {
	/// <summary>
	/// Ajax表格列的扩展函数
	/// </summary>
	public static class AjaxTableColumnsExtensions {
		/// <summary>
		/// 添加用于编辑数据的列
		/// 点击后弹出编辑数据的模态框
		/// </summary>
		/// <param name="columns">列列表</param>
		/// <param name="nameMember">名称成员</param>
		/// <param name="idMember">Id成员</param>
		/// <param name="typeName">类型名称</param>
		/// <param name="editUrl">编辑使用的Url</param>
		/// <param name="titleTemplate">标题的模板，格式是underscore.js的格式，参数传入row</param>
		/// <param name="urlTemplate">编辑Url的模板，格式是underscore.js的格式，参数传入row</param>
		/// <param name="dialogParameters">弹出框的参数，不指定时使用默认值</param>
		/// <param name="width">宽度</param>
		/// <returns></returns>
		public static AjaxTableColumn AddEditColumn(
			this List<AjaxTableColumn> columns, string nameMember, string idMember, string typeName, string editUrl,
			string titleTemplate = null, string urlTemplate = null, object dialogParameters = null, string width = null) {
			return columns.AddRemoteModalColumn(
				nameMember,
				titleTemplate ?? string.Format(new T("Edit {0}"), new T(typeName)),
				urlTemplate ?? (editUrl + string.Format("?id=<%-row.{0}%>", idMember)),
				dialogParameters,
				width);
		}

		/// <summary>
		/// 添加用于编辑数据的列
		/// 点击后弹出编辑数据的模态框
		/// 根据增删查改页面的构建器自动生成，各个参数如不指定则使用默认值
		/// </summary>
		/// <typeparam name="TBuilder">构建器的类型</typeparam>
		public static AjaxTableColumn AddEditColumnForCrudPage<TBuilder>(
			this List<AjaxTableColumn> columns, string nameMember, string idMember,
			string titleTemplate = null, string urlTemplate = null,
			object dialogParameters = null, string width = null)
			where TBuilder : class, ICrudPageBuilder, new() {
			var app = new TBuilder();
			return columns.AddEditColumn(
				nameMember, idMember, app.DataTypeName, app.EditUrl,
				titleTemplate, urlTemplate, dialogParameters, width);
		}
	}
}
