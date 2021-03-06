﻿using System;
using ZKWeb.Database;
using ZKWebStandard.Ioc;

namespace ZKWeb.Plugins.Common.GenericTag.src.Database {
	/// <summary>
	/// 通用标签
	/// </summary>
	[ExportMany]
	public class GenericTag : IEntity<long>, IEntityMappingProvider<GenericTag> {
		/// <summary>
		/// 标签Id
		/// </summary>
		public virtual long Id { get; set; }
		/// <summary>
		/// 标签类型
		/// </summary>
		public virtual string Type { get; set; }
		/// <summary>
		/// 标签名称
		/// </summary>
		public virtual string Name { get; set; }
		/// <summary>
		/// 创建时间
		/// </summary>
		public virtual DateTime CreateTime { get; set; }
		/// <summary>
		/// 显示顺序，从小到大
		/// </summary>
		public virtual long DisplayOrder { get; set; }
		/// <summary>
		/// 备注
		/// </summary>
		public virtual string Remark { get; set; }
		/// <summary>
		/// 是否已删除
		/// </summary>
		public virtual bool Deleted { get; set; }

		/// <summary>
		/// 初始化
		/// </summary>
		public GenericTag() {
			DisplayOrder = 10000;
		}

		/// <summary>
		/// 显示名称
		/// </summary>
		/// <returns></returns>
		public override string ToString() {
			return Name;
		}

		/// <summary>
		/// 配置数据库结构
		/// </summary>
		public virtual void Configure(IEntityMappingBuilder<GenericTag> builder) {
			builder.Id(t => t.Id);
			builder.Map(t => t.Type, new EntityMappingOptions() { Index = "Idx_Type" });
			builder.Map(t => t.Name);
			builder.Map(t => t.CreateTime);
			builder.Map(t => t.DisplayOrder);
			builder.Map(t => t.Remark);
			builder.Map(t => t.Deleted);
		}
	}
}
