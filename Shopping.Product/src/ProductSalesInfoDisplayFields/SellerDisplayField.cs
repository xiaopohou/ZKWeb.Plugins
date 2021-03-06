﻿using ZKWeb.Plugins.Shopping.Product.src.Model;
using ZKWeb.Database;
using ZKWebStandard.Ioc;
using ZKWebStandard.Utils;

namespace ZKWeb.Plugins.Shopping.Product.src.ProductSalesInfoDisplayFields {
	/// <summary>
	/// 卖家
	/// </summary>
	[ExportMany]
	public class SellerDisplayField : IProductSalesInfoDisplayField {
		/// <summary>
		/// 名称
		/// </summary>
		public string Name { get { return "Seller"; } }

		/// <summary>
		/// 获取显示的Html
		/// </summary>
		public string GetDisplayHtml(IDatabaseContext context, Database.Product product) {
			var seller = product.Seller;
			return seller == null ? null : HttpUtils.HtmlEncode(seller.Username);
		}
	}
}
