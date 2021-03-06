﻿using System;
using ZKWeb.Database;
using ZKWeb.Plugins.Common.Base.src.Model;

namespace ZKWeb.Plugins.Common.Base.src.Repositories {
	/// <summary>
	/// 开启事务处理多个数据仓储的查询或改动
	/// </summary>
	public static class UnitOfWork {
		/// <summary>
		/// 执行读取数据使用的工作
		/// </summary>
		/// <param name="func">工作内容</param>
		public static void Read(Action<IDatabaseContext> func) {
			var databaseManager = Application.Ioc.Resolve<DatabaseManager>();
			using (var context = databaseManager.CreateContext()) {
				func(context);
			}
		}

		/// <summary>
		/// 执行读取数据使用的工作
		/// 返回执行结果
		/// </summary>
		/// <param name="func">工作内容</param>
		public static TResult Read<TResult>(Func<IDatabaseContext, TResult> func) {
			var databaseManager = Application.Ioc.Resolve<DatabaseManager>();
			using (var context = databaseManager.CreateContext()) {
				return func(context);
			}
		}

		/// <summary>
		/// 执行修改数据使用的工作
		/// </summary>
		/// <param name="func">工作内容</param>
		public static void Write(Action<IDatabaseContext> func) {
			var databaseManager = Application.Ioc.Resolve<DatabaseManager>();
			using (var context = databaseManager.CreateContext()) {
				func(context);
			}
		}

		/// <summary>
		/// 执行修改数据使用的工作
		/// 返回执行结果
		/// </summary>
		/// <param name="func">工作内容</param>
		public static TResult Write<TResult>(Func<IDatabaseContext, TResult> func) {
			var databaseManager = Application.Ioc.Resolve<DatabaseManager>();
			using (var context = databaseManager.CreateContext()) {
				var result = func(context);
				return result;
			}
		}

		/// <summary>
		/// 执行读取数据使用的工作
		/// 使用通用的仓储
		/// </summary>
		/// <typeparam name="TData">数据类型</typeparam>
		/// <param name="func">工作内容</param>
		public static void ReadData<TData>(Action<GenericRepository<TData>> func)
			where TData : class, IEntity {
			Read(context => {
				var repository = RepositoryResolver.Resolve<TData>(context);
				func(repository);
			});
		}

		/// <summary>
		/// 执行读取数据使用的工作
		/// 使用通用的仓储，并返回处理结果
		/// </summary>
		/// <typeparam name="TData">数据类型</typeparam>
		/// <typeparam name="TResult">结果类型</typeparam>
		/// <param name="func">工作内容</param>
		public static TResult ReadData<TData, TResult>(Func<GenericRepository<TData>, TResult> func)
			where TData : class, IEntity {
			return Read(context => {
				var repository = RepositoryResolver.Resolve<TData>(context);
				return func(repository);
			});
		}

		/// <summary>
		/// 执行修改数据使用的工作
		/// 使用通用的仓储
		/// </summary>
		/// <typeparam name="TData">数据仓储类型</typeparam>
		/// <param name="func">工作内容</param>
		public static void WriteData<TData>(Action<GenericRepository<TData>> func)
			where TData : class, IEntity {
			Write(context => {
				var repository = RepositoryResolver.Resolve<TData>(context);
				func(repository);
			});
		}

		/// <summary>
		/// 执行修改数据使用的工作
		/// 使用通用的仓储，并返回处理结果
		/// </summary>
		/// <typeparam name="TData">数据类型</typeparam>
		/// <typeparam name="TResult">结果类型</typeparam>
		/// <param name="func">工作内容</param>
		public static TResult WriteData<TData, TResult>(Func<GenericRepository<TData>, TResult> func)
			where TData : class, IEntity {
			return Write(context => {
				var repository = RepositoryResolver.Resolve<TData>(context);
				return func(repository);
			});
		}

		/// <summary>
		/// 执行读取数据使用的工作
		/// 使用指定的仓储
		/// </summary>
		/// <typeparam name="TRepository">仓储类型</typeparam>
		/// <param name="func">工作内容</param>
		public static void ReadRepository<TRepository>(Action<TRepository> func)
			where TRepository : IRepository {
			Read(context => {
				var repository = RepositoryResolver.ResolveRepository<TRepository>(context);
				func(repository);
			});
		}

		/// <summary>
		/// 执行读取数据使用的工作
		/// 使用指定的仓储，并返回处理结果
		/// </summary>
		/// <typeparam name="TRepository">仓储类型</typeparam>
		/// <typeparam name="TResult">结果类型</typeparam>
		/// <param name="func">工作内容</param>
		public static TResult ReadRepository<TRepository, TResult>(Func<TRepository, TResult> func)
			where TRepository : IRepository {
			return Read(context => {
				var repository = RepositoryResolver.ResolveRepository<TRepository>(context);
				return func(repository);
			});
		}

		/// <summary>
		/// 执行修改数据使用的工作
		/// 使用指定的仓储
		/// </summary>
		/// <typeparam name="TRepository">仓储类型</typeparam>
		/// <param name="func">工作内容</param>
		public static void WriteRepository<TRepository>(Action<TRepository> func)
			where TRepository : IRepository {
			Write(context => {
				var repository = RepositoryResolver.ResolveRepository<TRepository>(context);
				func(repository);
			});
		}

		/// <summary>
		/// 执行修改数据使用的工作
		/// 使用指定的仓储，并返回处理结果
		/// </summary>
		/// <typeparam name="TRepository">仓储类型</typeparam>
		/// <typeparam name="TResult">结果类型</typeparam>
		/// <param name="func">工作内容</param>
		public static TResult WriteRepository<TRepository, TResult>(Func<TRepository, TResult> func)
			where TRepository : IRepository {
			return Write(context => {
				var repository = RepositoryResolver.ResolveRepository<TRepository>(context);
				return func(repository);
			});
		}
	}
}
