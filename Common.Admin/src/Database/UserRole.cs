﻿using System;
using System.Collections.Generic;
using ZKWeb.Database;
using ZKWebStandard.Ioc;

namespace ZKWeb.Plugins.Common.Admin.src.Database {
	/// <summary>
	/// 用户角色
	/// </summary>
	[ExportMany]
	public class UserRole : IEntity<long>, IEntityMappingProvider<UserRole> {
		/// <summary>
		/// 角色Id
		/// </summary>
		public virtual long Id { get; set; }
		/// <summary>
		/// 角色名称
		/// </summary>
		public virtual string Name { get; set; }
		/// <summary>
		/// 权限列表
		/// </summary>
		public virtual HashSet<string> Privileges { get; set; }
		/// <summary>
		/// 创建时间
		/// </summary>
		public virtual DateTime CreateTime { get; set; }
		/// <summary>
		/// 更新时间
		/// </summary>
		public virtual DateTime LastUpdated { get; set; }
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
		public UserRole() {
			Privileges = new HashSet<string>();
		}

		/// <summary>
		/// 显示角色名称
		/// </summary>
		/// <returns></returns>
		public override string ToString() {
			return Name;
		}

		/// <summary>
		/// 配置数据库结构
		/// </summary>
		public virtual void Configure(IEntityMappingBuilder<UserRole> builder) {
			builder.Id(r => r.Id);
			builder.Map(r => r.Name);
			builder.Map(r => r.Privileges, new EntityMappingOptions() { WithSerialization = true });
			builder.Map(r => r.CreateTime);
			builder.Map(r => r.LastUpdated);
			builder.Map(r => r.Remark);
			builder.Map(r => r.Deleted);
		}
	}
}
