﻿// Copyright (c) Avanade. Licensed under the MIT License. See https://github.com/Avanade/Beef

using Beef.Data.Database;
using Beef.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beef.Data.EntityFrameworkCore
{
    /// <summary>
    /// Represents the base class for encapsulating the database access layer using an entity framework <see cref="Microsoft.EntityFrameworkCore.DbContext"/>.
    /// </summary>
    /// <typeparam name="TDbContext">The <see cref="DbContext"/> <see cref="Type"/>.</typeparam>
    public abstract class EfDbBase<TDbContext> : IEfDb<TDbContext> where TDbContext : DbContext
    {
#pragma warning disable CA1000 // Do not declare static members on generic types; by-design, is ok.
        /// <summary>
        /// Transforms and throws the <see cref="IBusinessException"/> equivalent for a <see cref="SqlException"/>.
        /// </summary>
        /// <param name="sex">The <see cref="SqlException"/>.</param>
        public static void ThrowTransformedSqlException(SqlException sex)
        {
            if (sex == null)
                throw new ArgumentNullException(nameof(sex));

            var msg = sex.Message?.TrimEnd();
            switch (sex.Number)
            {
                case 56001: throw new ValidationException(msg, sex);
                case 56002: throw new BusinessException(msg, sex);
                case 56003: throw new AuthorizationException(msg, sex);
                case 56004: throw new ConcurrencyException(msg, sex);
                case 56005: throw new NotFoundException(msg, sex);
                case 56006: throw new ConflictException(msg, sex);
                case 56007: throw new DuplicateException(msg, sex);

                default:
                    if (AlwaysCheckSqlDuplicateErrorNumbers && SqlDuplicateErrorNumbers.Contains(sex.Number))
                        throw new DuplicateException(null, sex);

                    break;
            }
        }

        /// <summary>
        /// Indicates whether to always check the <see cref="SqlDuplicateErrorNumbers"/> when executing the <see cref="ThrowTransformedSqlException(SqlException)"/> method.
        /// </summary>
        public static bool AlwaysCheckSqlDuplicateErrorNumbers { get; set; } = true;

        /// <summary>
        /// Gets or sets the list of known <see cref="SqlException.Number"/> values for the <see cref="ThrowTransformedSqlException(SqlException)"/> method.
        /// </summary>
        public static List<int> SqlDuplicateErrorNumbers { get; } = new List<int>(new int[] { 2601, 2627 });
#pragma warning restore CA1000

        /// <summary>
        /// Initializes a new instance of the <see cref="EfDbBase{TDbContext}"/> class.
        /// </summary>
        /// <param name="dbContext">The <see cref="Microsoft.EntityFrameworkCore.DbContext"/>.</param>
        /// <param name="invoker">Enables the <see cref="Invoker"/> to be overridden; defaults to <see cref="EfDbInvoker{TDbContext}"/>.</param>
        public EfDbBase(TDbContext dbContext, EfDbInvoker<TDbContext>? invoker = null)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            Invoker = invoker ?? new EfDbInvoker<TDbContext>();
        }

        /// <summary>
        /// Gets the underlying <typeparamref name="TDbContext"/> instance.
        /// </summary>
        /// <returns>The <typeparamref name="TDbContext"/> instance.</returns>
        public TDbContext DbContext { get; private set; }

        /// <summary>
        /// Gets the <see cref="EfDbInvoker{TDbContext}"/>.
        /// </summary>
        public EfDbInvoker<TDbContext> Invoker { get; private set; }

        /// <summary>
        /// Indicates whether a pre-read is performed on an <see cref="UpdateAsync{T, TModel}(EfDbArgs{T, TModel}, T)"/> to confirm existence and throw a corresponding
        /// <see cref="NotFoundException"/> where not found. Otherwise, where not found a <see cref="ConcurrencyException"/> will be thrown. The pre-read requires an additional
        /// database keyed-read and therefore has a minor performance impact as a result.
        /// </summary>
        public bool OnUpdatePreReadForNotFound { get; set; } = false;

        /// <summary>
        /// Gets or sets the <see cref="DatabaseWildcard"/> to enable wildcard replacement.
        /// </summary>
        public DatabaseWildcard Wildcard { get; set; } = new DatabaseWildcard();

        /// <summary>
        /// Gets or sets the <see cref="SqlException"/> handler (by default set up to execute <see cref="ThrowTransformedSqlException(SqlException)"/>).
        /// </summary>
        public Action<SqlException> ExceptionHandler { get; set; } = (sex) => ThrowTransformedSqlException(sex);

        /// <summary>
        /// Invokes the <paramref name="action"/> whilst <see cref="DatabaseWildcard.Replace(string)">replacing</see> the <b>wildcard</b> characters when the <paramref name="with"/> is not <c>null</c>.
        /// </summary>
        /// <param name="with">The value with which to verify.</param>
        /// <param name="action">The <see cref="Action"/> to invoke when there is a valid <paramref name="with"/> value; passed the database specific wildcard value.</param>
        public void WithWildcard(string? with, Action<string> action)
        {
            if (with != null)
            {
                with = Wildcard.Replace(with);
                if (with != null)
                    action?.Invoke(with);
            }
        }

        /// <summary>
        /// Invokes the <paramref name="action"/> when the <paramref name="with"/> is not the default value for the <see cref="Type"/>.
        /// </summary>
        /// <typeparam name="T">The with value <see cref="Type"/>.</typeparam>
        /// <param name="with">The value with which to verify.</param>
        /// <param name="action">The <see cref="Action"/> to invoke when there is a valid <paramref name="with"/> value.</param>
        public void With<T>(T with, Action action)
        {
            if (Comparer<T>.Default.Compare(with, default) != 0 && Comparer<T>.Default.Compare(with, default) != 0)
            {
                if (!(with is string) && with is System.Collections.IEnumerable ie && !ie.GetEnumerator().MoveNext())
                    return;

                action?.Invoke();
            }
        }

        /// <summary>
        /// Creates an <see cref="EfDbQuery{T, TModel, TDbContext}"/> to enable select-like capabilities.
        /// </summary>
        /// <typeparam name="T">The resultant <see cref="Type"/>.</typeparam>
        /// <typeparam name="TModel">The entity framework model <see cref="Type"/>.</typeparam>
        /// <param name="queryArgs">The <see cref="EfDbArgs{T, TModel}"/>.</param>
        /// <param name="query">The function to further define the query.</param>
        /// <returns>A <see cref="EfDbQuery{T, TModel, TDbContext}"/>.</returns>
        public IEfDbQuery<T, TModel> Query<T, TModel>(EfDbArgs<T, TModel> queryArgs, Func<IQueryable<TModel>, IQueryable<TModel>>? query = null) where T : class, new() where TModel : class, new()
        {
            return new EfDbQuery<T, TModel, TDbContext>(this, queryArgs, query);
        }

        /// <summary>
        /// Gets the entity for the specified <paramref name="keys"/> mapping from <typeparamref name="TModel"/> to <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The resultant <see cref="Type"/>.</typeparam>
        /// <typeparam name="TModel">The entity framework model <see cref="Type"/>.</typeparam>
        /// <param name="getArgs">The <see cref="EfDbArgs{T, TModel}"/>.</param>
        /// <param name="keys">The key values.</param>
        /// <returns>The entity value where found; otherwise, <c>null</c>.</returns>
        public async Task<T?> GetAsync<T, TModel>(EfDbArgs<T, TModel> getArgs, params IComparable[] keys) where T : class, new() where TModel : class, new()
        {
            if (getArgs == null)
                throw new ArgumentNullException(nameof(getArgs));

            CheckKeys(getArgs, keys);
            var efKeys = new object[keys.Length];
            for (int i = 0; i < getArgs.Mapper.UniqueKey.Count; i++)
            {
                efKeys[i] = getArgs.Mapper.UniqueKey[i].ConvertToDestValue(keys[i], Mapper.OperationTypes.Unspecified)!;
            }

            return await Invoker.InvokeAsync(this, async () =>
            {
                return await FindAsync(getArgs, efKeys).ConfigureAwait(false);
            }, this).ConfigureAwait(false);
        }

        /// <summary>
        /// Performs a create for the value (reselects and/or automatically saves changes where specified).
        /// </summary>
        /// <typeparam name="T">The resultant <see cref="Type"/>.</typeparam>
        /// <typeparam name="TModel">The entity framework model <see cref="Type"/>.</typeparam>
        /// <param name="saveArgs">The <see cref="EfDbArgs{T, TModel}"/>.</param>
        /// <param name="value">The value to insert.</param>
        /// <returns>The value (refreshed where specified).</returns>
        public async Task<T> CreateAsync<T, TModel>(EfDbArgs<T, TModel> saveArgs, T value) where T : class, new() where TModel : class, new()
        {
            CheckSaveArgs(saveArgs);

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (value is IChangeLog cl)
            {
                if (cl.ChangeLog == null)
                    cl.ChangeLog = new ChangeLog();

                cl.ChangeLog.CreatedBy = ExecutionContext.HasCurrent ? ExecutionContext.Current.Username : ExecutionContext.EnvironmentUsername;
                cl.ChangeLog.CreatedDate = ExecutionContext.HasCurrent ? ExecutionContext.Current.Timestamp : Cleaner.Clean(DateTime.Now);
            }

            return await Invoker.InvokeAsync(this, async () =>
            {
                var model = saveArgs.Mapper.MapToDest(value, Mapper.OperationTypes.Create) ?? throw new InvalidOperationException("Mapping to the EF entity must not result in a null value.");
                DbContext.Add(model);

                if (saveArgs.SaveChanges)
                    await DbContext.SaveChangesAsync(true).ConfigureAwait(false);

                return (saveArgs.Refresh) ? saveArgs.Mapper.MapToSrce(model, Mapper.OperationTypes.Get)! : value;
            }, this).ConfigureAwait(false);
        }

        /// <summary>
        /// Performs an update for the value (reselects and/or automatically saves changes where specified).
        /// </summary>
        /// <typeparam name="T">The resultant <see cref="Type"/>.</typeparam>
        /// <typeparam name="TModel">The entity framework model <see cref="Type"/>.</typeparam>
        /// <param name="saveArgs">The <see cref="EfDbArgs{T, TModel}"/>.</param>
        /// <param name="value">The value to insert.</param>
        /// <returns>The value (refreshed where specified).</returns>
        public async Task<T> UpdateAsync<T, TModel>(EfDbArgs<T, TModel> saveArgs, T value) where T : class, new() where TModel : class, new()
        {
            CheckSaveArgs(saveArgs);

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (value is IChangeLog cl)
            {
                if (cl.ChangeLog == null)
                    cl.ChangeLog = new ChangeLog();

                cl.ChangeLog.UpdatedBy = ExecutionContext.HasCurrent ? ExecutionContext.Current.Username : ExecutionContext.EnvironmentUsername;
                cl.ChangeLog.UpdatedDate = ExecutionContext.HasCurrent ? ExecutionContext.Current.Timestamp : Cleaner.Clean(DateTime.Now);
            }

            return await Invoker.InvokeAsync(this, async () =>
            {
                if (OnUpdatePreReadForNotFound)
                {
                    // Check (find) if the entity exists.
                    var efKeys = new object[saveArgs.Mapper.UniqueKey.Count];
                    for (int i = 0; i < saveArgs.Mapper.UniqueKey.Count; i++)
                    {
                        var v = saveArgs.Mapper.UniqueKey[i].GetSrceValue(value, Mapper.OperationTypes.Unspecified);
                        efKeys[i] = saveArgs.Mapper.UniqueKey[i].ConvertToDestValue(v, Mapper.OperationTypes.Unspecified)!;
                    }

                    var em = (TModel)await DbContext.FindAsync(typeof(TModel), efKeys).ConfigureAwait(false);
                    if (em == null)
                        throw new NotFoundException();

                    // Remove the entity from the tracker before we attempt to update; otherwise, will use existing rowversion and concurrency will not work as expected.
                    DbContext.Remove(em);
                    DbContext.ChangeTracker.AcceptAllChanges();
                }

                var model = saveArgs.Mapper.MapToDest(value, Mapper.OperationTypes.Update) ?? throw new InvalidOperationException("Mapping to the EF entity must not result in a null value.");
                DbContext.Update(model);

                if (saveArgs.SaveChanges)
                    await DbContext.SaveChangesAsync(true).ConfigureAwait(false);

                return (saveArgs.Refresh) ? saveArgs.Mapper.MapToSrce(model, Mapper.OperationTypes.Get)! : value;
            }, this).ConfigureAwait(false);
        }

        /// <summary>
        /// Performs a delete for the specified <paramref name="keys"/>.
        /// </summary>
        /// <typeparam name="T">The resultant <see cref="Type"/>.</typeparam>
        /// <typeparam name="TModel">The entity framework model <see cref="Type"/>.</typeparam>
        /// <param name="saveArgs">The <see cref="EfDbArgs{T, TModel}"/>.</param>
        /// <param name="keys">The key values.</param>
        public async Task DeleteAsync<T, TModel>(EfDbArgs<T, TModel> saveArgs, params IComparable[] keys) where T : class, new() where TModel : class, new()
        {
            CheckSaveArgs(saveArgs);
            CheckKeys(saveArgs, keys);
            var efKeys = new object[keys.Length];
            for (int i = 0; i < saveArgs.Mapper.UniqueKey.Count; i++)
            {
                efKeys[i] = saveArgs.Mapper.UniqueKey[i].ConvertToDestValue(keys[i], Mapper.OperationTypes.Unspecified)!;
            }

            await Invoker.InvokeAsync(this, async () =>
            {
                // A pre-read is required to get the row version for concurrency.
                var em = (TModel)await DbContext.FindAsync(typeof(TModel), efKeys).ConfigureAwait(false);
                if (em == null)
                    return;

                DbContext.Remove(em);

                if (saveArgs.SaveChanges)
                    await DbContext.SaveChangesAsync(true).ConfigureAwait(false);
            }, this).ConfigureAwait(false);
        }

        /// <summary>
        /// Checks keys provided and match against defined.
        /// </summary>
        private static void CheckKeys<T, TModel>(EfDbArgs<T, TModel> args, IComparable[] keys) where T : class, new() where TModel : class, new()
        {
            if (keys == null || keys.Length == 0)
                throw new ArgumentNullException(nameof(keys));

            if (keys.Length != args.Mapper.UniqueKey.Count)
                throw new ArgumentException($"The specified keys count '{keys.Length}' does not match the Mapper UniqueKey count '{args.Mapper.UniqueKey.Count}'.", nameof(keys));
        }

        /// <summary>
        /// Check the consistency of the save arguments.
        /// </summary>
        private static void CheckSaveArgs<T, TModel>(EfDbArgs<T, TModel> saveArgs) where T : class, new() where TModel : class, new()
        {
            if (saveArgs == null)
                throw new ArgumentNullException(nameof(saveArgs));

            if (saveArgs.Refresh && !saveArgs.SaveChanges)
                throw new ArgumentException("The Refresh property cannot be set to true without the SaveChanges also being set to true (given the save will occur after this method call).", nameof(saveArgs));
        }

        /// <summary>
        /// Performs the EF select single (find).
        /// </summary>
        private async Task<T> FindAsync<T, TModel>(EfDbArgs<T, TModel> args, object[] keys) where T : class, new() where TModel : class, new()
        {
            var model = await DbContext.FindAsync<TModel>(keys).ConfigureAwait(false);
            if (model == default)
                return default!;
            else
                return args.Mapper.MapToSrce(model, Mapper.OperationTypes.Get) ?? throw new InvalidOperationException("Mapping from the EF entity must not result in a null value.");
        }
    }
}