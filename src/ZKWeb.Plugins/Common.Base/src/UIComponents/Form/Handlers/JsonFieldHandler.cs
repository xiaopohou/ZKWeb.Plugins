﻿using Newtonsoft.Json;
using System.Collections.Generic;
using ZKWeb.Plugins.Common.Base.src.UIComponents.Form.Attributes;
using ZKWeb.Plugins.Common.Base.src.UIComponents.Form.Extensions;
using ZKWeb.Plugins.Common.Base.src.UIComponents.Form.Interfaces;
using ZKWeb.Templating;
using ZKWebStandard.Ioc;

namespace ZKWeb.Plugins.Common.Base.src.UIComponents.Form.Handlers {
	/// <summary>
	/// 经过Json序列化的隐藏字段
	/// </summary>
	[ExportMany(ContractKey = typeof(JsonFieldAttribute)), SingletonReuse]
	public class JsonFieldHandler : IFormFieldHandler {
		/// <summary>
		/// 获取表单字段的html
		/// </summary>
		public string Build(FormField field, IDictionary<string, string> htmlAttributes) {
			var templateManager = Application.Ioc.Resolve<TemplateManager>();
			var hidden = templateManager.RenderTemplate("tmpl.form.hidden.html", new {
				name = field.Attribute.Name,
				value = JsonConvert.SerializeObject(field.Value),
				attributes = htmlAttributes
			});
			return field.WrapFieldHtml(htmlAttributes, hidden);
		}

		/// <summary>
		/// 解析提交的字段的值
		/// </summary>
		public object Parse(FormField field, IList<string> values) {
			var attribute = (JsonFieldAttribute)field.Attribute;
			return JsonConvert.DeserializeObject(values[0], attribute.FieldType);
		}
	}
}
