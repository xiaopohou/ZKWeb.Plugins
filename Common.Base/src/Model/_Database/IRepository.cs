﻿using ZKWeb.Database;

namespace ZKWeb.Plugins.Common.Base.src.Model {
	/// <summary>
	/// 数据仓储的接口
	/// </summary>
	public interface IRepository {
		/// <summary>
		/// 当前使用的数据库上下文
		/// </summary>
		IDatabaseContext Context { get; set; }
	}
}
