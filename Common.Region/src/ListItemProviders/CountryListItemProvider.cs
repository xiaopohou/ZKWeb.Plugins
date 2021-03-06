﻿using System.Collections.Generic;
using ZKWeb.Localize;
using ZKWeb.Plugins.Common.Base.src.Model;
using ZKWeb.Plugins.Common.Region.src.Model;

namespace ZKWeb.Plugins.Common.Region.src.ListItemProviders {
	/// <summary>
	/// 国家/行政区列表
	/// </summary>
	public class CountryListItemProvider : IListItemProvider {
		/// <summary>
		/// 获取选项列表
		/// </summary>
		/// <returns></returns>
		public IEnumerable<ListItem> GetItems() {
			foreach (var country in Application.Ioc.ResolveMany<Country>()) {
				yield return new ListItem(new T(country.Name), country.Name);
			}
		}
	}
}
