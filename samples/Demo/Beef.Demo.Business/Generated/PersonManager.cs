/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable IDE0005 // Using directive is unnecessary; are required depending on code-gen options

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Beef;
using Beef.Business;
using Beef.Entities;
using Beef.Validation;
using Beef.Demo.Common.Entities;
using Beef.Demo.Business.Validation;
using Beef.Demo.Business.DataSvc;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Business
{
    /// <summary>
    /// Provides the Person business functionality.
    /// </summary>
    public partial class PersonManager : IPersonManager
    {
        private readonly IPersonDataSvc _dataService;

        #region Extensions
        #pragma warning disable CS0649, IDE0044 // Defaults to null by design; can be overridden in constructor.

        private Func<Person, Task>? _createOnPreValidateAsync;
        private Action<MultiValidator, Person>? _createOnValidate;
        private Func<Person, Task>? _createOnBeforeAsync;
        private Func<Person, Task>? _createOnAfterAsync;

        private Func<Guid, Task>? _deleteOnPreValidateAsync;
        private Action<MultiValidator, Guid>? _deleteOnValidate;
        private Func<Guid, Task>? _deleteOnBeforeAsync;
        private Func<Guid, Task>? _deleteOnAfterAsync;

        private Func<Guid, Task>? _getOnPreValidateAsync;
        private Action<MultiValidator, Guid>? _getOnValidate;
        private Func<Guid, Task>? _getOnBeforeAsync;
        private Func<Person?, Guid, Task>? _getOnAfterAsync;

        private Func<Person, Guid, Task>? _updateOnPreValidateAsync;
        private Action<MultiValidator, Person, Guid>? _updateOnValidate;
        private Func<Person, Guid, Task>? _updateOnBeforeAsync;
        private Func<Person, Guid, Task>? _updateOnAfterAsync;

        private Func<PagingArgs?, Task>? _getAllOnBeforeAsync;
        private Func<PersonCollectionResult, PagingArgs?, Task>? _getAllOnAfterAsync;

        private Func<Task>? _getAll2OnBeforeAsync;
        private Func<PersonCollectionResult, Task>? _getAll2OnAfterAsync;

        private Func<PersonArgs?, PagingArgs?, Task>? _getByArgsOnPreValidateAsync;
        private Action<MultiValidator, PersonArgs?, PagingArgs?>? _getByArgsOnValidate;
        private Func<PersonArgs?, PagingArgs?, Task>? _getByArgsOnBeforeAsync;
        private Func<PersonCollectionResult, PersonArgs?, PagingArgs?, Task>? _getByArgsOnAfterAsync;

        private Func<PersonArgs?, PagingArgs?, Task>? _getDetailByArgsOnPreValidateAsync;
        private Action<MultiValidator, PersonArgs?, PagingArgs?>? _getDetailByArgsOnValidate;
        private Func<PersonArgs?, PagingArgs?, Task>? _getDetailByArgsOnBeforeAsync;
        private Func<PersonDetailCollectionResult, PersonArgs?, PagingArgs?, Task>? _getDetailByArgsOnAfterAsync;

        private Func<Guid, Guid, Task>? _mergeOnPreValidateAsync;
        private Action<MultiValidator, Guid, Guid>? _mergeOnValidate;
        private Func<Guid, Guid, Task>? _mergeOnBeforeAsync;
        private Func<Person, Guid, Guid, Task>? _mergeOnAfterAsync;

        private Func<Task>? _markOnBeforeAsync;
        private Func<Task>? _markOnAfterAsync;

        private Func<MapArgs?, Task>? _mapOnPreValidateAsync;
        private Action<MultiValidator, MapArgs?>? _mapOnValidate;
        private Func<MapArgs?, Task>? _mapOnBeforeAsync;
        private Func<MapCoordinates, MapArgs?, Task>? _mapOnAfterAsync;

        private Func<Task>? _getNoArgsOnBeforeAsync;
        private Func<Person?Task>? _getNoArgsOnAfterAsync;

        private Func<Guid, Task>? _getDetailOnPreValidateAsync;
        private Action<MultiValidator, Guid>? _getDetailOnValidate;
        private Func<Guid, Task>? _getDetailOnBeforeAsync;
        private Func<PersonDetail?, Guid, Task>? _getDetailOnAfterAsync;

        private Func<PersonDetail, Guid, Task>? _updateDetailOnPreValidateAsync;
        private Action<MultiValidator, PersonDetail, Guid>? _updateDetailOnValidate;
        private Func<PersonDetail, Guid, Task>? _updateDetailOnBeforeAsync;
        private Func<PersonDetail, Guid, Task>? _updateDetailOnAfterAsync;

        private Func<Task>? _dataSvcCustomOnBeforeAsync;
        private Func<int, Task>? _dataSvcCustomOnAfterAsync;

        private Func<string?, Task>? _getNullOnPreValidateAsync;
        private Action<MultiValidator, string?>? _getNullOnValidate;
        private Func<string?, Task>? _getNullOnBeforeAsync;
        private Func<Person?, string?, Task>? _getNullOnAfterAsync;

        private Func<PersonArgs?, PagingArgs?, Task>? _getByArgsWithEfOnPreValidateAsync;
        private Action<MultiValidator, PersonArgs?, PagingArgs?>? _getByArgsWithEfOnValidate;
        private Func<PersonArgs?, PagingArgs?, Task>? _getByArgsWithEfOnBeforeAsync;
        private Func<PersonCollectionResult, PersonArgs?, PagingArgs?, Task>? _getByArgsWithEfOnAfterAsync;

        private Func<Task>? _throwErrorOnBeforeAsync;
        private Func<Task>? _throwErrorOnAfterAsync;

        private Func<Guid, Task>? _getWithEfOnPreValidateAsync;
        private Action<MultiValidator, Guid>? _getWithEfOnValidate;
        private Func<Guid, Task>? _getWithEfOnBeforeAsync;
        private Func<Person?, Guid, Task>? _getWithEfOnAfterAsync;

        private Func<Person, Task>? _createWithEfOnPreValidateAsync;
        private Action<MultiValidator, Person>? _createWithEfOnValidate;
        private Func<Person, Task>? _createWithEfOnBeforeAsync;
        private Func<Person, Task>? _createWithEfOnAfterAsync;

        private Func<Person, Guid, Task>? _updateWithEfOnPreValidateAsync;
        private Action<MultiValidator, Person, Guid>? _updateWithEfOnValidate;
        private Func<Person, Guid, Task>? _updateWithEfOnBeforeAsync;
        private Func<Person, Guid, Task>? _updateWithEfOnAfterAsync;

        private Func<Guid, Task>? _deleteWithEfOnPreValidateAsync;
        private Action<MultiValidator, Guid>? _deleteWithEfOnValidate;
        private Func<Guid, Task>? _deleteWithEfOnBeforeAsync;
        private Func<Guid, Task>? _deleteWithEfOnAfterAsync;

        #pragma warning restore CS0649, IDE0044
        #endregion

        /// <summary>
        /// Parameterless constructor is explictly not supported.
        /// </summary>
        private PersonManager() => throw new NotSupportedException();

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonManager"/> class.
        /// </summary>
        /// <param name="dataService">The <see cref="IPersonDataSvc"/>.</param>
        public PersonManager(IPersonDataSvc dataService) { _dataService = Check.NotNull(dataService, nameof(dataService)); PersonManagerCtor(); }

        /// <summary>
        /// Enables additional functionality to be added to the constructor.
        /// </summary>
        partial void PersonManagerCtor();

        /// <summary>
        /// Creates the <see cref="Person"/> object.
        /// </summary>
        /// <param name="value">The <see cref="Person"/> object.</param>
        /// <returns>A refreshed <see cref="Person"/> object.</returns>
        public Task<Person> CreateAsync(Person value)
        {
            value.Validate(nameof(value)).Mandatory().Run().ThrowOnError();

            return ManagerInvoker.Current.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Create;
                Cleaner.CleanUp(value);
                if (_createOnPreValidateAsync != null) await _createOnPreValidateAsync(value).ConfigureAwait(false);

                MultiValidator.Create()
                    .Add(value.Validate(nameof(value)).Entity(PersonValidator.Default))
                    .Additional((__mv) => _createOnValidate?.Invoke(__mv, value))
                    .Run().ThrowOnError();

                if (_createOnBeforeAsync != null) await _createOnBeforeAsync(value).ConfigureAwait(false);
                var __result = await _dataService.CreateAsync(value).ConfigureAwait(false);
                if (_createOnAfterAsync != null) await _createOnAfterAsync(__result).ConfigureAwait(false);
                Cleaner.CleanUp(__result);
                return __result;
            });
        }

        /// <summary>
        /// Deletes the <see cref="Person"/> object.
        /// </summary>
        /// <param name="id">The <see cref="Person"/> identifier.</param>
        public Task DeleteAsync(Guid id)
        {
            return ManagerInvoker.Current.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Delete;
                Cleaner.CleanUp(id);
                if (_deleteOnPreValidateAsync != null) await _deleteOnPreValidateAsync(id).ConfigureAwait(false);

                MultiValidator.Create()
                    .Add(id.Validate(nameof(id)).Mandatory())
                    .Additional((__mv) => _deleteOnValidate?.Invoke(__mv, id))
                    .Run().ThrowOnError();

                if (_deleteOnBeforeAsync != null) await _deleteOnBeforeAsync(id).ConfigureAwait(false);
                await _dataService.DeleteAsync(id).ConfigureAwait(false);
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
            return ManagerInvoker.Current.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Read;
                Cleaner.CleanUp(id);
                if (_getOnPreValidateAsync != null) await _getOnPreValidateAsync(id).ConfigureAwait(false);

                MultiValidator.Create()
                    .Add(id.Validate(nameof(id)).Mandatory())
                    .Additional((__mv) => _getOnValidate?.Invoke(__mv, id))
                    .Run().ThrowOnError();

                if (_getOnBeforeAsync != null) await _getOnBeforeAsync(id).ConfigureAwait(false);
                var __result = await _dataService.GetAsync(id).ConfigureAwait(false);
                if (_getOnAfterAsync != null) await _getOnAfterAsync(__result, id).ConfigureAwait(false);
                Cleaner.CleanUp(__result);
                return __result;
            });
        }

        /// <summary>
        /// Updates the <see cref="Person"/> object.
        /// </summary>
        /// <param name="value">The <see cref="Person"/> object.</param>
        /// <param name="id">The <see cref="Person"/> identifier.</param>
        /// <returns>A refreshed <see cref="Person"/> object.</returns>
        public Task<Person> UpdateAsync(Person value, Guid id)
        {
            value.Validate(nameof(value)).Mandatory().Run().ThrowOnError();

            return ManagerInvoker.Current.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Update;
                value.Id = id;
                Cleaner.CleanUp(value);
                if (_updateOnPreValidateAsync != null) await _updateOnPreValidateAsync(value, id).ConfigureAwait(false);

                MultiValidator.Create()
                    .Add(value.Validate(nameof(value)).Entity(PersonValidator.Default))
                    .Additional((__mv) => _updateOnValidate?.Invoke(__mv, value, id))
                    .Run().ThrowOnError();

                if (_updateOnBeforeAsync != null) await _updateOnBeforeAsync(value, id).ConfigureAwait(false);
                var __result = await _dataService.UpdateAsync(value).ConfigureAwait(false);
                if (_updateOnAfterAsync != null) await _updateOnAfterAsync(__result, id).ConfigureAwait(false);
                Cleaner.CleanUp(__result);
                return __result;
            });
        }

        /// <summary>
        /// Gets the <see cref="Person"/> collection object that matches the selection criteria.
        /// </summary>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        /// <returns>A <see cref="PersonCollectionResult"/>.</returns>
        public Task<PersonCollectionResult> GetAllAsync(PagingArgs? paging)
        {
            return ManagerInvoker.Current.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Read;
                if (_getAllOnBeforeAsync != null) await _getAllOnBeforeAsync(paging).ConfigureAwait(false);
                var __result = await _dataService.GetAllAsync(paging).ConfigureAwait(false);
                if (_getAllOnAfterAsync != null) await _getAllOnAfterAsync(__result, paging).ConfigureAwait(false);
                Cleaner.CleanUp(__result);
                return __result;
            });
        }

        /// <summary>
        /// Gets the <see cref="Person"/> collection object that matches the selection criteria.
        /// </summary>
        /// <returns>A <see cref="PersonCollectionResult"/>.</returns>
        public Task<PersonCollectionResult> GetAll2Async()
        {
            return ManagerInvoker.Current.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Read;
                if (_getAll2OnBeforeAsync != null) await _getAll2OnBeforeAsync().ConfigureAwait(false);
                var __result = await _dataService.GetAll2Async().ConfigureAwait(false);
                if (_getAll2OnAfterAsync != null) await _getAll2OnAfterAsync(__result).ConfigureAwait(false);
                Cleaner.CleanUp(__result);
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
            return ManagerInvoker.Current.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Read;
                Cleaner.CleanUp(args);
                if (_getByArgsOnPreValidateAsync != null) await _getByArgsOnPreValidateAsync(args, paging).ConfigureAwait(false);

                MultiValidator.Create()
                    .Add(args.Validate(nameof(args)).Entity(PersonArgsValidator.Default))
                    .Additional((__mv) => _getByArgsOnValidate?.Invoke(__mv, args, paging))
                    .Run().ThrowOnError();

                if (_getByArgsOnBeforeAsync != null) await _getByArgsOnBeforeAsync(args, paging).ConfigureAwait(false);
                var __result = await _dataService.GetByArgsAsync(args, paging).ConfigureAwait(false);
                if (_getByArgsOnAfterAsync != null) await _getByArgsOnAfterAsync(__result, args, paging).ConfigureAwait(false);
                Cleaner.CleanUp(__result);
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
            return ManagerInvoker.Current.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Read;
                Cleaner.CleanUp(args);
                if (_getDetailByArgsOnPreValidateAsync != null) await _getDetailByArgsOnPreValidateAsync(args, paging).ConfigureAwait(false);

                MultiValidator.Create()
                    .Add(args.Validate(nameof(args)).Entity(PersonArgsValidator.Default))
                    .Additional((__mv) => _getDetailByArgsOnValidate?.Invoke(__mv, args, paging))
                    .Run().ThrowOnError();

                if (_getDetailByArgsOnBeforeAsync != null) await _getDetailByArgsOnBeforeAsync(args, paging).ConfigureAwait(false);
                var __result = await _dataService.GetDetailByArgsAsync(args, paging).ConfigureAwait(false);
                if (_getDetailByArgsOnAfterAsync != null) await _getDetailByArgsOnAfterAsync(__result, args, paging).ConfigureAwait(false);
                Cleaner.CleanUp(__result);
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
            return ManagerInvoker.Current.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Update;
                Cleaner.CleanUp(fromId, toId);
                if (_mergeOnPreValidateAsync != null) await _mergeOnPreValidateAsync(fromId, toId).ConfigureAwait(false);

                MultiValidator.Create()
                    .Add(fromId.Validate(nameof(fromId)).Mandatory())
                    .Add(toId.Validate(nameof(toId)).Mandatory().CompareValue(CompareOperator.NotEqual, fromId, nameof(fromId).ToSentenceCase()!))
                    .Additional((__mv) => _mergeOnValidate?.Invoke(__mv, fromId, toId))
                    .Run().ThrowOnError();

                if (_mergeOnBeforeAsync != null) await _mergeOnBeforeAsync(fromId, toId).ConfigureAwait(false);
                var __result = await _dataService.MergeAsync(fromId, toId).ConfigureAwait(false);
                if (_mergeOnAfterAsync != null) await _mergeOnAfterAsync(__result, fromId, toId).ConfigureAwait(false);
                Cleaner.CleanUp(__result);
                return __result;
            });
        }

        /// <summary>
        /// Mark <see cref="Person"/>.
        /// </summary>
        public Task MarkAsync()
        {
            return ManagerInvoker.Current.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Update;
                if (_markOnBeforeAsync != null) await _markOnBeforeAsync().ConfigureAwait(false);
                await _dataService.MarkAsync().ConfigureAwait(false);
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
            return ManagerInvoker.Current.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Read;
                Cleaner.CleanUp(args);
                if (_mapOnPreValidateAsync != null) await _mapOnPreValidateAsync(args).ConfigureAwait(false);

                MultiValidator.Create()
                    .Additional((__mv) => _mapOnValidate?.Invoke(__mv, args))
                    .Run().ThrowOnError();

                if (_mapOnBeforeAsync != null) await _mapOnBeforeAsync(args).ConfigureAwait(false);
                var __result = await _dataService.MapAsync(args).ConfigureAwait(false);
                if (_mapOnAfterAsync != null) await _mapOnAfterAsync(__result, args).ConfigureAwait(false);
                Cleaner.CleanUp(__result);
                return __result;
            });
        }

        /// <summary>
        /// Get no arguments.
        /// </summary>
        /// <returns>The selected <see cref="Person"/> object where found; otherwise, <c>null</c>.</returns>
        public Task<Person?> GetNoArgsAsync()
        {
            return ManagerInvoker.Current.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Read;
                if (_getNoArgsOnBeforeAsync != null) await _getNoArgsOnBeforeAsync().ConfigureAwait(false);
                var __result = await _dataService.GetNoArgsAsync().ConfigureAwait(false);
                if (_getNoArgsOnAfterAsync != null) await _getNoArgsOnAfterAsync(__result).ConfigureAwait(false);
                Cleaner.CleanUp(__result);
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
            return ManagerInvoker.Current.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Read;
                Cleaner.CleanUp(id);
                if (_getDetailOnPreValidateAsync != null) await _getDetailOnPreValidateAsync(id).ConfigureAwait(false);

                MultiValidator.Create()
                    .Add(id.Validate(nameof(id)).Mandatory())
                    .Additional((__mv) => _getDetailOnValidate?.Invoke(__mv, id))
                    .Run().ThrowOnError();

                if (_getDetailOnBeforeAsync != null) await _getDetailOnBeforeAsync(id).ConfigureAwait(false);
                var __result = await _dataService.GetDetailAsync(id).ConfigureAwait(false);
                if (_getDetailOnAfterAsync != null) await _getDetailOnAfterAsync(__result, id).ConfigureAwait(false);
                Cleaner.CleanUp(__result);
                return __result;
            });
        }

        /// <summary>
        /// Updates the <see cref="PersonDetail"/> object.
        /// </summary>
        /// <param name="value">The <see cref="PersonDetail"/> object.</param>
        /// <param name="id">The <see cref="Person"/> identifier.</param>
        /// <returns>A refreshed <see cref="PersonDetail"/> object.</returns>
        public Task<PersonDetail> UpdateDetailAsync(PersonDetail value, Guid id)
        {
            value.Validate(nameof(value)).Mandatory().Run().ThrowOnError();

            return ManagerInvoker.Current.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Update;
                value.Id = id;
                Cleaner.CleanUp(value);
                if (_updateDetailOnPreValidateAsync != null) await _updateDetailOnPreValidateAsync(value, id).ConfigureAwait(false);

                MultiValidator.Create()
                    .Add(value.Validate(nameof(value)).Entity(PersonDetailValidator.Default))
                    .Additional((__mv) => _updateDetailOnValidate?.Invoke(__mv, value, id))
                    .Run().ThrowOnError();

                if (_updateDetailOnBeforeAsync != null) await _updateDetailOnBeforeAsync(value, id).ConfigureAwait(false);
                var __result = await _dataService.UpdateDetailAsync(value).ConfigureAwait(false);
                if (_updateDetailOnAfterAsync != null) await _updateDetailOnAfterAsync(__result, id).ConfigureAwait(false);
                Cleaner.CleanUp(__result);
                return __result;
            });
        }

        /// <summary>
        /// Actually validating the FromBody parameter generation.
        /// </summary>
        /// <param name="person">The Person (see <see cref="Person"/>).</param>
        public Task AddAsync(Person? person)
        {
            return ManagerInvoker.Current.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Unspecified;
                await AddOnImplementationAsync(person).ConfigureAwait(false);
            });
        }

        /// <summary>
        /// Validate a DataSvc Custom generation.
        /// </summary>
        /// <returns>A resultant <see cref="int"/>.</returns>
        public Task<int> DataSvcCustomAsync()
        {
            return ManagerInvoker.Current.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Unspecified;
                if (_dataSvcCustomOnBeforeAsync != null) await _dataSvcCustomOnBeforeAsync().ConfigureAwait(false);
                var __result = await _dataService.DataSvcCustomAsync().ConfigureAwait(false);
                if (_dataSvcCustomOnAfterAsync != null) await _dataSvcCustomOnAfterAsync(__result).ConfigureAwait(false);
                Cleaner.CleanUp(__result);
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
            return ManagerInvoker.Current.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Unspecified;
                Cleaner.CleanUp(name);
                if (_getNullOnPreValidateAsync != null) await _getNullOnPreValidateAsync(name).ConfigureAwait(false);

                MultiValidator.Create()
                    .Additional((__mv) => _getNullOnValidate?.Invoke(__mv, name))
                    .Run().ThrowOnError();

                if (_getNullOnBeforeAsync != null) await _getNullOnBeforeAsync(name).ConfigureAwait(false);
                var __result = await _dataService.GetNullAsync(name).ConfigureAwait(false);
                if (_getNullOnAfterAsync != null) await _getNullOnAfterAsync(__result, name).ConfigureAwait(false);
                Cleaner.CleanUp(__result);
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
            return ManagerInvoker.Current.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Read;
                Cleaner.CleanUp(args);
                if (_getByArgsWithEfOnPreValidateAsync != null) await _getByArgsWithEfOnPreValidateAsync(args, paging).ConfigureAwait(false);

                MultiValidator.Create()
                    .Add(args.Validate(nameof(args)).Entity(PersonArgsValidator.Default))
                    .Additional((__mv) => _getByArgsWithEfOnValidate?.Invoke(__mv, args, paging))
                    .Run().ThrowOnError();

                if (_getByArgsWithEfOnBeforeAsync != null) await _getByArgsWithEfOnBeforeAsync(args, paging).ConfigureAwait(false);
                var __result = await _dataService.GetByArgsWithEfAsync(args, paging).ConfigureAwait(false);
                if (_getByArgsWithEfOnAfterAsync != null) await _getByArgsWithEfOnAfterAsync(__result, args, paging).ConfigureAwait(false);
                Cleaner.CleanUp(__result);
                return __result;
            });
        }

        /// <summary>
        /// Throw Error.
        /// </summary>
        public Task ThrowErrorAsync()
        {
            return ManagerInvoker.Current.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Unspecified;
                if (_throwErrorOnBeforeAsync != null) await _throwErrorOnBeforeAsync().ConfigureAwait(false);
                await _dataService.ThrowErrorAsync().ConfigureAwait(false);
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
            return ManagerInvoker.Current.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Read;
                Cleaner.CleanUp(id);
                if (_getWithEfOnPreValidateAsync != null) await _getWithEfOnPreValidateAsync(id).ConfigureAwait(false);

                MultiValidator.Create()
                    .Add(id.Validate(nameof(id)).Mandatory())
                    .Additional((__mv) => _getWithEfOnValidate?.Invoke(__mv, id))
                    .Run().ThrowOnError();

                if (_getWithEfOnBeforeAsync != null) await _getWithEfOnBeforeAsync(id).ConfigureAwait(false);
                var __result = await _dataService.GetWithEfAsync(id).ConfigureAwait(false);
                if (_getWithEfOnAfterAsync != null) await _getWithEfOnAfterAsync(__result, id).ConfigureAwait(false);
                Cleaner.CleanUp(__result);
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
            value.Validate(nameof(value)).Mandatory().Run().ThrowOnError();

            return ManagerInvoker.Current.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Create;
                Cleaner.CleanUp(value);
                if (_createWithEfOnPreValidateAsync != null) await _createWithEfOnPreValidateAsync(value).ConfigureAwait(false);

                MultiValidator.Create()
                    .Add(value.Validate(nameof(value)).Entity(PersonValidator.Default))
                    .Additional((__mv) => _createWithEfOnValidate?.Invoke(__mv, value))
                    .Run().ThrowOnError();

                if (_createWithEfOnBeforeAsync != null) await _createWithEfOnBeforeAsync(value).ConfigureAwait(false);
                var __result = await _dataService.CreateWithEfAsync(value).ConfigureAwait(false);
                if (_createWithEfOnAfterAsync != null) await _createWithEfOnAfterAsync(__result).ConfigureAwait(false);
                Cleaner.CleanUp(__result);
                return __result;
            });
        }

        /// <summary>
        /// Updates the <see cref="Person"/> object.
        /// </summary>
        /// <param name="value">The <see cref="Person"/> object.</param>
        /// <param name="id">The <see cref="Person"/> identifier.</param>
        /// <returns>A refreshed <see cref="Person"/> object.</returns>
        public Task<Person> UpdateWithEfAsync(Person value, Guid id)
        {
            value.Validate(nameof(value)).Mandatory().Run().ThrowOnError();

            return ManagerInvoker.Current.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Update;
                value.Id = id;
                Cleaner.CleanUp(value);
                if (_updateWithEfOnPreValidateAsync != null) await _updateWithEfOnPreValidateAsync(value, id).ConfigureAwait(false);

                MultiValidator.Create()
                    .Add(value.Validate(nameof(value)).Entity(PersonValidator.Default))
                    .Additional((__mv) => _updateWithEfOnValidate?.Invoke(__mv, value, id))
                    .Run().ThrowOnError();

                if (_updateWithEfOnBeforeAsync != null) await _updateWithEfOnBeforeAsync(value, id).ConfigureAwait(false);
                var __result = await _dataService.UpdateWithEfAsync(value).ConfigureAwait(false);
                if (_updateWithEfOnAfterAsync != null) await _updateWithEfOnAfterAsync(__result, id).ConfigureAwait(false);
                Cleaner.CleanUp(__result);
                return __result;
            });
        }

        /// <summary>
        /// Deletes the <see cref="Person"/> object.
        /// </summary>
        /// <param name="id">The <see cref="Person"/> identifier.</param>
        public Task DeleteWithEfAsync(Guid id)
        {
            return ManagerInvoker.Current.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Delete;
                Cleaner.CleanUp(id);
                if (_deleteWithEfOnPreValidateAsync != null) await _deleteWithEfOnPreValidateAsync(id).ConfigureAwait(false);

                MultiValidator.Create()
                    .Add(id.Validate(nameof(id)).Mandatory())
                    .Additional((__mv) => _deleteWithEfOnValidate?.Invoke(__mv, id))
                    .Run().ThrowOnError();

                if (_deleteWithEfOnBeforeAsync != null) await _deleteWithEfOnBeforeAsync(id).ConfigureAwait(false);
                await _dataService.DeleteWithEfAsync(id).ConfigureAwait(false);
                if (_deleteWithEfOnAfterAsync != null) await _deleteWithEfOnAfterAsync(id).ConfigureAwait(false);
            });
        }
    }
}

#pragma warning restore IDE0005
#nullable restore