/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable IDE0005, IDE0044 // Using directive is unnecessary; are required depending on code-gen options

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Beef;
using Beef.Business;
using Beef.Caching;
using Beef.Entities;
using Beef.Events;
using Beef.Demo.Business.Data;
using Beef.Demo.Common.Entities;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Business.DataSvc
{
    /// <summary>
    /// Provides the Person data repository services.
    /// </summary>
    public partial class PersonDataSvc : IPersonDataSvc
    {
        private readonly IPersonData _data;
        private readonly IEventPublisher _evtPub;
        private readonly IRequestCache _cache;

        #region Extensions
        #pragma warning disable CS0649 // Defaults to null by design; can be overridden in constructor.

        private Func<Person, Task>? _createOnAfterAsync;
        private Func<Guid, Task>? _deleteOnAfterAsync;
        private Func<Person?, Guid, Task>? _getOnAfterAsync;
        private Func<Person, Task>? _updateOnAfterAsync;
        private Func<PersonCollectionResult, PagingArgs?, Task>? _getAllOnAfterAsync;
        private Func<PersonCollectionResult, Task>? _getAll2OnAfterAsync;
        private Func<PersonCollectionResult, PersonArgs?, PagingArgs?, Task>? _getByArgsOnAfterAsync;
        private Func<PersonDetailCollectionResult, PersonArgs?, PagingArgs?, Task>? _getDetailByArgsOnAfterAsync;
        private Func<Person, Guid, Guid, Task>? _mergeOnAfterAsync;
        private Func<Task>? _markOnAfterAsync;
        private Func<MapCoordinates, MapArgs?, Task>? _mapOnAfterAsync;
        private Func<PersonDetail?, Guid, Task>? _getDetailOnAfterAsync;
        private Func<PersonDetail, Task>? _updateDetailOnAfterAsync;
        private Func<Person?, string?, Task>? _getNullOnAfterAsync;
        private Func<PersonCollectionResult, PersonArgs?, PagingArgs?, Task>? _getByArgsWithEfOnAfterAsync;
        private Func<Task>? _throwErrorOnAfterAsync;
        private Func<Person?, Guid, Task>? _getWithEfOnAfterAsync;
        private Func<Person, Task>? _createWithEfOnAfterAsync;
        private Func<Person, Task>? _updateWithEfOnAfterAsync;
        private Func<Guid, Task>? _deleteWithEfOnAfterAsync;

        #pragma warning restore CS0649
        #endregion

        /// <summary>
        /// Parameterless constructor is explictly not supported.
        /// </summary>
        private PersonDataSvc() => throw new NotSupportedException();

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonDataSvc"/> class.
        /// </summary>
        /// <param name="data">The <see cref="IPersonData"/>.</param>
        /// <param name="evtPub">The <see cref="IEventPublisher"/>.</param>
        /// <param name="cache">The <see cref="IRequestCache"/>.</param>
        public PersonDataSvc(IPersonData data, IEventPublisher evtPub, IRequestCache cache)
            { _data = Check.NotNull(data, nameof(data)); _evtPub = Check.NotNull(evtPub, nameof(evtPub)); _cache = Check.NotNull(cache, nameof(cache)); PersonDataSvcCtor(); }

        /// <summary>
        /// Enables additional functionality to be added to the constructor.
        /// </summary>
        partial void PersonDataSvcCtor();

        /// <summary>
        /// Creates the <see cref="Person"/> object.
        /// </summary>
        /// <param name="value">The <see cref="Person"/> object.</param>
        /// <returns>A refreshed <see cref="Person"/> object.</returns>
        public Task<Person> CreateAsync(Person value)
        {
            return DataSvcInvoker.Current.InvokeAsync(typeof(PersonDataSvc), async () => 
            {
                var __result = await _data.CreateAsync(Check.NotNull(value, nameof(value))).ConfigureAwait(false);
                await _evtPub.PublishValueAsync(__result, $"Demo.Person.{__result.Id}", "Create").ConfigureAwait(false);
                _cache.SetValue(__result.UniqueKey, __result);
                if (_createOnAfterAsync != null) await _createOnAfterAsync(__result).ConfigureAwait(false);
                return __result;
            });
        }

        /// <summary>
        /// Deletes the <see cref="Person"/> object.
        /// </summary>
        /// <param name="id">The <see cref="Person"/> identifier.</param>
        public Task DeleteAsync(Guid id)
        {
            return DataSvcInvoker.Current.InvokeAsync(typeof(PersonDataSvc), async () => 
            {
                await _data.DeleteAsync(id).ConfigureAwait(false);
                await _evtPub.PublishAsync($"Demo.Person.{id}", "Delete", id).ConfigureAwait(false);
                _cache.Remove<Person>(new UniqueKey(id));
                if (_deleteOnAfterAsync != null) await _deleteOnAfterAsync(id).ConfigureAwait(false);
            });
        }

        /// <summary>
        /// Gets the <see cref="Person"/> object that matches the selection criteria.
        /// </summary>
        /// <param name="id">The <see cref="Person"/> identifier.</param>
        /// <returns>The selected <see cref="Person"/> object where found; otherwise, <c>null</c>.</returns>
        public Task<Person?> GetAsync(Guid id)
        {
            return DataSvcInvoker.Current.InvokeAsync(typeof(PersonDataSvc), async () => 
            {
                var __key = new UniqueKey(id);
                if (_cache.TryGetValue(__key, out Person __val))
                    return __val;

                var __result = await _data.GetAsync(id).ConfigureAwait(false);
                _cache.SetValue(__key, __result!);
                if (_getOnAfterAsync != null) await _getOnAfterAsync(__result, id).ConfigureAwait(false);
                return __result;
            });
        }

        /// <summary>
        /// Updates the <see cref="Person"/> object.
        /// </summary>
        /// <param name="value">The <see cref="Person"/> object.</param>
        /// <returns>A refreshed <see cref="Person"/> object.</returns>
        public Task<Person> UpdateAsync(Person value)
        {
            return DataSvcInvoker.Current.InvokeAsync(typeof(PersonDataSvc), async () => 
            {
                var __result = await _data.UpdateAsync(Check.NotNull(value, nameof(value))).ConfigureAwait(false);
                await _evtPub.PublishValueAsync(__result, $"Demo.Person.{__result.Id}", "Update").ConfigureAwait(false);
                _cache.SetValue(__result.UniqueKey, __result);
                if (_updateOnAfterAsync != null) await _updateOnAfterAsync(__result).ConfigureAwait(false);
                return __result;
            }, new BusinessInvokerArgs { IncludeTransactionScope = true });
        }

        /// <summary>
        /// Gets the <see cref="Person"/> collection object that matches the selection criteria.
        /// </summary>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        /// <returns>A <see cref="PersonCollectionResult"/>.</returns>
        public Task<PersonCollectionResult> GetAllAsync(PagingArgs? paging)
        {
            return DataSvcInvoker.Current.InvokeAsync(typeof(PersonDataSvc), async () => 
            {
                var __result = await _data.GetAllAsync(paging).ConfigureAwait(false);
                if (_getAllOnAfterAsync != null) await _getAllOnAfterAsync(__result, paging).ConfigureAwait(false);
                return __result;
            });
        }

        /// <summary>
        /// Gets the <see cref="Person"/> collection object that matches the selection criteria.
        /// </summary>
        /// <returns>A <see cref="PersonCollectionResult"/>.</returns>
        public Task<PersonCollectionResult> GetAll2Async()
        {
            return DataSvcInvoker.Current.InvokeAsync(typeof(PersonDataSvc), async () => 
            {
                var __result = await _data.GetAll2Async().ConfigureAwait(false);
                if (_getAll2OnAfterAsync != null) await _getAll2OnAfterAsync(__result).ConfigureAwait(false);
                return __result;
            });
        }

        /// <summary>
        /// Gets the <see cref="Person"/> collection object that matches the selection criteria.
        /// </summary>
        /// <param name="args">The Args (see <see cref="PersonArgs"/>).</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        /// <returns>A <see cref="PersonCollectionResult"/>.</returns>
        public Task<PersonCollectionResult> GetByArgsAsync(PersonArgs? args, PagingArgs? paging)
        {
            return DataSvcInvoker.Current.InvokeAsync(typeof(PersonDataSvc), async () => 
            {
                var __result = await _data.GetByArgsAsync(args, paging).ConfigureAwait(false);
                if (_getByArgsOnAfterAsync != null) await _getByArgsOnAfterAsync(__result, args, paging).ConfigureAwait(false);
                return __result;
            });
        }

        /// <summary>
        /// Gets the <see cref="PersonDetail"/> collection object that matches the selection criteria.
        /// </summary>
        /// <param name="args">The Args (see <see cref="PersonArgs"/>).</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        /// <returns>A <see cref="PersonDetailCollectionResult"/>.</returns>
        public Task<PersonDetailCollectionResult> GetDetailByArgsAsync(PersonArgs? args, PagingArgs? paging)
        {
            return DataSvcInvoker.Current.InvokeAsync(typeof(PersonDataSvc), async () => 
            {
                var __result = await _data.GetDetailByArgsAsync(args, paging).ConfigureAwait(false);
                if (_getDetailByArgsOnAfterAsync != null) await _getDetailByArgsOnAfterAsync(__result, args, paging).ConfigureAwait(false);
                return __result;
            });
        }

        /// <summary>
        /// Merge first <see cref="Person"/> into second.
        /// </summary>
        /// <param name="fromId">The from <see cref="Person"/> identifier.</param>
        /// <param name="toId">The to <see cref="Person"/> identifier.</param>
        /// <returns>A resultant <see cref="Person"/>.</returns>
        public Task<Person> MergeAsync(Guid fromId, Guid toId)
        {
            return DataSvcInvoker.Current.InvokeAsync(typeof(PersonDataSvc), async () => 
            {
                var __result = await _data.MergeAsync(fromId, toId).ConfigureAwait(false);
                await _evtPub.PublishAsync(
                    _evtPub.CreateValueEvent(__result, $"Demo.Person.{fromId}", "Merge", fromId, toId)).ConfigureAwait(false);
                _cache.SetValue(__result.UniqueKey, __result);
                if (_mergeOnAfterAsync != null) await _mergeOnAfterAsync(__result, fromId, toId).ConfigureAwait(false);
                return __result;
            });
        }

        /// <summary>
        /// Mark <see cref="Person"/>.
        /// </summary>
        public Task MarkAsync()
        {
            return DataSvcInvoker.Current.InvokeAsync(typeof(PersonDataSvc), async () => 
            {
                await _data.MarkAsync().ConfigureAwait(false);
                if (_markOnAfterAsync != null) await _markOnAfterAsync().ConfigureAwait(false);
            });
        }

        /// <summary>
        /// Get <see cref="Person"/> at specified <see cref="MapCoordinates"/>.
        /// </summary>
        /// <param name="args">The Args (see <see cref="MapArgs"/>).</param>
        /// <returns>A resultant <see cref="MapCoordinates"/>.</returns>
        public Task<MapCoordinates> MapAsync(MapArgs? args)
        {
            return DataSvcInvoker.Current.InvokeAsync(typeof(PersonDataSvc), async () => 
            {
                var __result = await _data.MapAsync(args).ConfigureAwait(false);
                if (_mapOnAfterAsync != null) await _mapOnAfterAsync(__result, args).ConfigureAwait(false);
                return __result;
            });
        }

        /// <summary>
        /// Gets the <see cref="PersonDetail"/> object that matches the selection criteria.
        /// </summary>
        /// <param name="id">The <see cref="Person"/> identifier.</param>
        /// <returns>The selected <see cref="PersonDetail"/> object where found; otherwise, <c>null</c>.</returns>
        public Task<PersonDetail?> GetDetailAsync(Guid id)
        {
            return DataSvcInvoker.Current.InvokeAsync(typeof(PersonDataSvc), async () => 
            {
                var __key = new UniqueKey(id);
                if (_cache.TryGetValue(__key, out PersonDetail __val))
                    return __val;

                var __result = await _data.GetDetailAsync(id).ConfigureAwait(false);
                _cache.SetValue(__key, __result!);
                if (_getDetailOnAfterAsync != null) await _getDetailOnAfterAsync(__result, id).ConfigureAwait(false);
                return __result;
            });
        }

        /// <summary>
        /// Updates the <see cref="PersonDetail"/> object.
        /// </summary>
        /// <param name="value">The <see cref="PersonDetail"/> object.</param>
        /// <returns>A refreshed <see cref="PersonDetail"/> object.</returns>
        public Task<PersonDetail> UpdateDetailAsync(PersonDetail value)
        {
            return DataSvcInvoker.Current.InvokeAsync(typeof(PersonDataSvc), async () => 
            {
                var __result = await _data.UpdateDetailAsync(Check.NotNull(value, nameof(value))).ConfigureAwait(false);
                await _evtPub.PublishValueAsync(__result, $"Demo.Person.{__result.Id}", "Update").ConfigureAwait(false);
                _cache.SetValue(__result.UniqueKey, __result);
                if (_updateDetailOnAfterAsync != null) await _updateDetailOnAfterAsync(__result).ConfigureAwait(false);
                return __result;
            });
        }

        /// <summary>
        /// Validate a DataSvc Custom generation.
        /// </summary>
        /// <returns>A resultant <see cref="int"/>.</returns>
        public Task<int> DataSvcCustomAsync()
        {
            return DataSvcInvoker.Current.InvokeAsync(typeof(PersonDataSvc), async () => 
            {
                var __result = await DataSvcCustomOnImplementationAsync().ConfigureAwait(false);
                return __result;
            });
        }

        /// <summary>
        /// Get Null.
        /// </summary>
        /// <param name="name">The Name.</param>
        /// <returns>A resultant <see cref="Person?"/>.</returns>
        public Task<Person?> GetNullAsync(string? name)
        {
            return DataSvcInvoker.Current.InvokeAsync(typeof(PersonDataSvc), async () => 
            {
                var __result = await _data.GetNullAsync(name).ConfigureAwait(false);
                _cache.SetValue(__result?.UniqueKey ?? UniqueKey.Empty, __result);
                if (_getNullOnAfterAsync != null) await _getNullOnAfterAsync(__result, name).ConfigureAwait(false);
                return __result;
            });
        }

        /// <summary>
        /// Gets the <see cref="Person"/> collection object that matches the selection criteria.
        /// </summary>
        /// <param name="args">The Args (see <see cref="PersonArgs"/>).</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        /// <returns>A <see cref="PersonCollectionResult"/>.</returns>
        public Task<PersonCollectionResult> GetByArgsWithEfAsync(PersonArgs? args, PagingArgs? paging)
        {
            return DataSvcInvoker.Current.InvokeAsync(typeof(PersonDataSvc), async () => 
            {
                var __result = await _data.GetByArgsWithEfAsync(args, paging).ConfigureAwait(false);
                if (_getByArgsWithEfOnAfterAsync != null) await _getByArgsWithEfOnAfterAsync(__result, args, paging).ConfigureAwait(false);
                return __result;
            });
        }

        /// <summary>
        /// Throw Error.
        /// </summary>
        public Task ThrowErrorAsync()
        {
            return DataSvcInvoker.Current.InvokeAsync(typeof(PersonDataSvc), async () => 
            {
                await _data.ThrowErrorAsync().ConfigureAwait(false);
                if (_throwErrorOnAfterAsync != null) await _throwErrorOnAfterAsync().ConfigureAwait(false);
            });
        }

        /// <summary>
        /// Gets the <see cref="Person"/> object that matches the selection criteria.
        /// </summary>
        /// <param name="id">The <see cref="Person"/> identifier.</param>
        /// <returns>The selected <see cref="Person"/> object where found; otherwise, <c>null</c>.</returns>
        public Task<Person?> GetWithEfAsync(Guid id)
        {
            return DataSvcInvoker.Current.InvokeAsync(typeof(PersonDataSvc), async () => 
            {
                var __key = new UniqueKey(id);
                if (_cache.TryGetValue(__key, out Person __val))
                    return __val;

                var __result = await _data.GetWithEfAsync(id).ConfigureAwait(false);
                _cache.SetValue(__key, __result!);
                if (_getWithEfOnAfterAsync != null) await _getWithEfOnAfterAsync(__result, id).ConfigureAwait(false);
                return __result;
            });
        }

        /// <summary>
        /// Creates the <see cref="Person"/> object.
        /// </summary>
        /// <param name="value">The <see cref="Person"/> object.</param>
        /// <returns>A refreshed <see cref="Person"/> object.</returns>
        public Task<Person> CreateWithEfAsync(Person value)
        {
            return DataSvcInvoker.Current.InvokeAsync(typeof(PersonDataSvc), async () => 
            {
                var __result = await _data.CreateWithEfAsync(Check.NotNull(value, nameof(value))).ConfigureAwait(false);
                await _evtPub.PublishValueAsync(__result, $"Demo.Person.{__result.Id}", "Create").ConfigureAwait(false);
                _cache.SetValue(__result.UniqueKey, __result);
                if (_createWithEfOnAfterAsync != null) await _createWithEfOnAfterAsync(__result).ConfigureAwait(false);
                return __result;
            });
        }

        /// <summary>
        /// Updates the <see cref="Person"/> object.
        /// </summary>
        /// <param name="value">The <see cref="Person"/> object.</param>
        /// <returns>A refreshed <see cref="Person"/> object.</returns>
        public Task<Person> UpdateWithEfAsync(Person value)
        {
            return DataSvcInvoker.Current.InvokeAsync(typeof(PersonDataSvc), async () => 
            {
                var __result = await _data.UpdateWithEfAsync(Check.NotNull(value, nameof(value))).ConfigureAwait(false);
                await _evtPub.PublishValueAsync(__result, $"Demo.Person.{__result.Id}", "Update").ConfigureAwait(false);
                _cache.SetValue(__result.UniqueKey, __result);
                if (_updateWithEfOnAfterAsync != null) await _updateWithEfOnAfterAsync(__result).ConfigureAwait(false);
                return __result;
            });
        }

        /// <summary>
        /// Deletes the <see cref="Person"/> object.
        /// </summary>
        /// <param name="id">The <see cref="Person"/> identifier.</param>
        public Task DeleteWithEfAsync(Guid id)
        {
            return DataSvcInvoker.Current.InvokeAsync(typeof(PersonDataSvc), async () => 
            {
                await _data.DeleteWithEfAsync(id).ConfigureAwait(false);
                await _evtPub.PublishAsync(
                    _evtPub.CreateEvent($"Demo.Person.{id}", "Delete", id)).ConfigureAwait(false);
                _cache.Remove<Person>(new UniqueKey(id));
                if (_deleteWithEfOnAfterAsync != null) await _deleteWithEfOnAfterAsync(id).ConfigureAwait(false);
            });
        }
    }
}

#pragma warning restore IDE0005, IDE0044
#nullable restore