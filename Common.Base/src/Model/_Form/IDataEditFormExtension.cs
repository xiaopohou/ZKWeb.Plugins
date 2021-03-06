﻿using ZKWeb.Database;

namespace ZKWeb.Plugins.Common.Base.src.Model {
	/// <summary>
	/// 扩展指定的数据编辑表单使用的接口
	/// </summary>
	/// <typeparam name="TData">编辑的数据类型</typeparam>
	/// <typeparam name="TForm">指定表单的类型</typeparam>
	public interface IDataEditFormExtension<TData, TForm>
		where TData : class, new() {
		/// <summary>
		/// 表单创建时的处理
		/// </summary>
		/// <param name="form">表单</param>
		void OnCreated(TForm form);

		/// <summary>
		/// 绑定数据到表单的处理，这个函数会在原表单绑定后调用
		/// </summary>
		/// <param name="form">表单</param>
		/// <param name="context">数据库上下文</param>
		/// <param name="bindFrom">来源的数据</param>
		void OnBind(TForm form, IDatabaseContext context, TData bindFrom);

		/// <summary>
		/// 保存表单到数据，这个函数会在原表单保存后调用
		/// </summary>
		/// <param name="form">表单</param>
		/// <param name="context">数据库上下文</param>
		/// <param name="saveTo">保存到的数据</param>
		void OnSubmit(TForm form, IDatabaseContext context, TData saveTo);

		/// <summary>
		/// 数据保存后的处理，用于添加关联数据等
		/// </summary>
		/// <param name="form">表单</param>
		/// <param name="context">数据库上下文</param>
		/// <param name="saved">已保存的数据，Id已分配</param>
		void OnSubmitSaved(TForm form, IDatabaseContext context, TData saved);
	}
}
