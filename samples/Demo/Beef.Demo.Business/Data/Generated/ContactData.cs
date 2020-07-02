/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable IDE0005 // Using directive is unnecessary; are required depending on code-gen options

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beef;
using Beef.Business;
using Beef.Data.EntityFrameworkCore;
using Beef.Entities;
using Beef.Mapper;
using Beef.Mapper.Converters;
using Beef.Demo.Common.Entities;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Business.Data
{
    /// <summary>
    /// Provides the Contact data access.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable", Justification = "Will not always appear static depending on code-gen options")]
    public partial class ContactData : IContactData
    {
        #region Private
        #pragma warning disable CS0649 // Defaults to null by design; can be overridden in constructor.

        private readonly Func<IQueryable<EfModel.Contact>, IEfDbArgs, IQueryable<EfModel.Contact>>? _getAllOnQuery;
        private readonly Func<IEfDbArgs, Task>? _getAllOnBeforeAsync;
        private readonly Func<ContactCollectionResult, Task>? _getAllOnAfterAsync;
        private readonly Action<Exception>? _getAllOnException;

        private readonly Func<Guid, IEfDbArgs, Task>? _getOnBeforeAsync;
        private readonly Func<Contact?, Guid, Task>? _getOnAfterAsync;
        private readonly Action<Exception>? _getOnException;

        private readonly Func<Contact, IEfDbArgs, Task>? _createOnBeforeAsync;
        private readonly Func<Contact, Task>? _createOnAfterAsync;
        private readonly Action<Exception>? _createOnException;

        private readonly Func<Contact, IEfDbArgs, Task>? _updateOnBeforeAsync;
        private readonly Func<Contact, Task>? _updateOnAfterAsync;
        private readonly Action<Exception>? _updateOnException;

        private readonly Func<Guid, IEfDbArgs, Task>? _deleteOnBeforeAsync;
        private readonly Func<Guid, Task>? _deleteOnAfterAsync;
        private readonly Action<Exception>? _deleteOnException;

        #pragma warning restore CS0649
        #endregion

        /// <summary>
        /// Gets the <see cref="Contact"/> collection object that matches the selection criteria.
        /// </summary>
        /// <returns>A <see cref="ContactCollectionResult"/>.</returns>
        public Task<ContactCollectionResult> GetAllAsync()
        {
            return DataInvoker.Default.InvokeAsync(this, async () =>
            {
                ContactCollectionResult __result = new ContactCollectionResult();
                var __dataArgs = EfMapper.Default.CreateArgs();
                if (_getAllOnBeforeAsync != null) await _getAllOnBeforeAsync(__dataArgs).ConfigureAwait(false);
                __result.Result = EfDb.Default.Query(__dataArgs, q => _getAllOnQuery == null ? q : _getAllOnQuery(q, __dataArgs)).SelectQuery<ContactCollection>();
                if (_getAllOnAfterAsync != null) await _getAllOnAfterAsync(__result).ConfigureAwait(false);
                return __result;
            }, new BusinessInvokerArgs { ExceptionHandler = _getAllOnException });
        }

        /// <summary>
        /// Gets the <see cref="Contact"/> object that matches the selection criteria.
        /// </summary>
        /// <param name="id">The <see cref="Contact"/> identifier.</param>
        /// <returns>The selected <see cref="Contact"/> object where found; otherwise, <c>null</c>.</returns>
        public Task<Contact?> GetAsync(Guid id)
        {
            return DataInvoker.Default.InvokeAsync(this, async () =>
            {
                Contact? __result;
                var __dataArgs = EfMapper.Default.CreateArgs();
                if (_getOnBeforeAsync != null) await _getOnBeforeAsync(id, __dataArgs).ConfigureAwait(false);
                __result = await EfDb.Default.GetAsync(__dataArgs, id).ConfigureAwait(false);
                if (_getOnAfterAsync != null) await _getOnAfterAsync(__result, id).ConfigureAwait(false);
                return __result;
            }, new BusinessInvokerArgs { ExceptionHandler = _getOnException });
        }

        /// <summary>
        /// Creates the <see cref="Contact"/> object.
        /// </summary>
        /// <param name="value">The <see cref="Contact"/> object.</param>
        /// <returns>A refreshed <see cref="Contact"/> object.</returns>
        public Task<Contact> CreateAsync(Contact value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return DataInvoker.Default.InvokeAsync(this, async () =>
            {
                Contact __result;
                var __dataArgs = EfMapper.Default.CreateArgs();
                if (_createOnBeforeAsync != null) await _createOnBeforeAsync(value, __dataArgs).ConfigureAwait(false);
                __result = await EfDb.Default.CreateAsync(__dataArgs, value).ConfigureAwait(false);
                if (_createOnAfterAsync != null) await _createOnAfterAsync(__result).ConfigureAwait(false);
                return __result;
            }, new BusinessInvokerArgs { ExceptionHandler = _createOnException });
        }

        /// <summary>
        /// Updates the <see cref="Contact"/> object.
        /// </summary>
        /// <param name="value">The <see cref="Contact"/> object.</param>
        /// <returns>A refreshed <see cref="Contact"/> object.</returns>
        public Task<Contact> UpdateAsync(Contact value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return DataInvoker.Default.InvokeAsync(this, async () =>
            {
                Contact __result;
                var __dataArgs = EfMapper.Default.CreateArgs();
                if (_updateOnBeforeAsync != null) await _updateOnBeforeAsync(value, __dataArgs).ConfigureAwait(false);
                __result = await EfDb.Default.UpdateAsync(__dataArgs, value).ConfigureAwait(false);
                if (_updateOnAfterAsync != null) await _updateOnAfterAsync(__result).ConfigureAwait(false);
                return __result;
            }, new BusinessInvokerArgs { ExceptionHandler = _updateOnException });
        }

        /// <summary>
        /// Deletes the <see cref="Contact"/> object that matches the selection criteria.
        /// </summary>
        /// <param name="id">The <see cref="Contact"/> identifier.</param>
        public Task DeleteAsync(Guid id)
        {
            return DataInvoker.Default.InvokeAsync(this, async () =>
            {
                var __dataArgs = EfMapper.Default.CreateArgs();
                if (_deleteOnBeforeAsync != null) await _deleteOnBeforeAsync(id, __dataArgs).ConfigureAwait(false);
                await EfDb.Default.DeleteAsync(__dataArgs, id).ConfigureAwait(false);
                if (_deleteOnAfterAsync != null) await _deleteOnAfterAsync(id).ConfigureAwait(false);
            }, new BusinessInvokerArgs { ExceptionHandler = _deleteOnException });
        }

        /// <summary>
        /// Provides the <see cref="Contact"/> entity and Entity Framework <see cref="EfModel.Contact"/> property mapping.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "By design; as there is a direct relationship")]
        public partial class EfMapper : EfDbMapper<Contact, EfModel.Contact, EfMapper>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="EfMapper"/> class.
            /// </summary>
            public EfMapper()
            {
                Property(s => s.Id, d => d.ContactId).SetUniqueKey(true);
                Property(s => s.FirstName, d => d.FirstName);
                Property(s => s.LastName, d => d.LastName);
                AddStandardProperties();
                EfMapperCtor();
            }
            
            /// <summary>
            /// Enables the <see cref="EfMapper"/> constructor to be extended.
            /// </summary>
            partial void EfMapperCtor();
        }
    }
}

#pragma warning restore IDE0005
#nullable restore