﻿using ZKWeb.Plugins.Common.CustomTranslate.src.Scaffolding;
using ZKWebStandard.Ioc;

namespace ZKWeb.Plugins.Common.CustomTranslate.src.CustomTranslators {
	/// <summary>
	/// 俄语
	/// </summary>
	[ExportMany, SingletonReuse]
	public class Russian : CustomTranslator {
		public override string Name { get { return "ru-RU"; } }
	}
}
