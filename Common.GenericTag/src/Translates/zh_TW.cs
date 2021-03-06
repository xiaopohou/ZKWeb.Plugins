﻿using System.Collections.Generic;
using ZKWeb.Localize;
using ZKWebStandard.Extensions;
using ZKWebStandard.Ioc;

namespace ZKWeb.Plugins.Common.GenericTag.src.Translates {
	/// <summary>
	/// 繁体中文翻译
	/// </summary>
	[ExportMany, SingletonReuse]
	public class zh_TW : ITranslateProvider {
		private static HashSet<string> Codes = new HashSet<string>() { "zh-TW" };
		private static Dictionary<string, string> Translates = new Dictionary<string, string>()
		{
			{ "Generic Tag", "通用標簽" },
			{ "Generic tag management", "通用標簽的管理" },
			{ "TagManage", "標簽管理" },
			{ "DefaultTag", "默認標簽" },
			{ "Try to access tag that type not matched", "嘗試操作類型不匹配的標簽" },
			{ "DisplayOrder", "顯示順序" },
			{ "Order from small to large", "從小到大排列" },
			{ "Tag", "標簽" },
			{ "Tags", "標簽" },
		};

		public bool CanTranslate(string code) {
			return Codes.Contains(code);
		}

		public string Translate(string text) {
			return Translates.GetOrDefault(text);
		}
	}
}
