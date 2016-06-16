﻿using ZKWeb.Plugins.Common.CustomTranslate.src.Scaffolding;
using ZKWebStandard.Ioc;

namespace ZKWeb.Plugins.Common.CustomTranslate.src.CustomTranslators {
	/// <summary>
	/// 日语
	/// </summary>
	[ExportMany, SingletonReuse]
	public class Japanese : CustomTranslator {
		public override string Name { get { return "ja-JP"; } }
	}
}
