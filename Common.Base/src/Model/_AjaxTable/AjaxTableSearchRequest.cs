﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ZKWeb.Plugins.Common.Base.src.Model {
	/// <summary>
	/// Ajax表格数据的搜索请求
	/// </summary>
	public class AjaxTableSearchRequest : BaseTableSearchRequest {
		/// <summary>
		/// 从json反序列化到搜索请求
		/// </summary>
		/// <param name="json">json文本</param>
		/// <returns></returns>
		public static AjaxTableSearchRequest FromJson(string json) {
			var request = JsonConvert.DeserializeObject<AjaxTableSearchRequest>(json);
			request.PageNo = Math.Max(request.PageNo, 0);
			request.PageSize = Math.Min(Math.Max(request.PageSize, 1), MaxPageSize);
			request.Conditions = request.Conditions ?? new Dictionary<string, object>();
			return request;
		}
	}
}
