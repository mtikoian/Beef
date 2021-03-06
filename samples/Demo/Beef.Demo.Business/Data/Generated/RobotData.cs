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
using Microsoft.Azure.Cosmos;
using Beef.Data.Cosmos;
using Beef.Entities;
using Beef.Mapper;
using Beef.Mapper.Converters;
using Beef.Demo.Common.Entities;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Business.Data
{
    /// <summary>
    /// Provides the Robot data access.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable", Justification = "Will not always appear static depending on code-gen options")]
    public partial class RobotData : IRobotData
    {
        private readonly ICosmosDb _cosmos;

        #region Extensions
        #pragma warning disable CS0649, IDE0044 // Defaults to null by design; can be overridden in constructor.

        private Action<ICosmosDbArgs>? _onDataArgsCreate;
        private Func<IQueryable<Model.Robot>, RobotArgs?, ICosmosDbArgs, IQueryable<Model.Robot>>? _getByArgsOnQuery;

        #pragma warning restore CS0649, IDE0044
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="RobotData"/> class.
        /// </summary>
        /// <param name="cosmos">The <see cref="ICosmosDb"/>.</param>
        public RobotData(ICosmosDb cosmos) { _cosmos = Check.NotNull(cosmos, nameof(cosmos)); RobotDataCtor(); }

        /// <summary>
        /// Enables additional functionality to be added to the constructor.
        /// </summary>
        partial void RobotDataCtor();

        /// <summary>
        /// Gets the <see cref="Robot"/> object that matches the selection criteria.
        /// </summary>
        /// <param name="id">The <see cref="Robot"/> identifier.</param>
        /// <returns>The selected <see cref="Robot"/> object where found; otherwise, <c>null</c>.</returns>
        public Task<Robot?> GetAsync(Guid id)
        {
            return DataInvoker.Current.InvokeAsync(this, async () =>
            {
                var __dataArgs = CosmosMapper.Default.CreateArgs("Items", PartitionKey.None, onCreate: _onDataArgsCreate);
                return await _cosmos.Container(__dataArgs).GetAsync(id).ConfigureAwait(false);
            });
        }

        /// <summary>
        /// Creates the <see cref="Robot"/> object.
        /// </summary>
        /// <param name="value">The <see cref="Robot"/> object.</param>
        /// <returns>A refreshed <see cref="Robot"/> object.</returns>
        public Task<Robot> CreateAsync(Robot value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return DataInvoker.Current.InvokeAsync(this, async () =>
            {
                var __dataArgs = CosmosMapper.Default.CreateArgs("Items", PartitionKey.None, onCreate: _onDataArgsCreate);
                return await _cosmos.Container(__dataArgs).CreateAsync(value).ConfigureAwait(false);
            });
        }

        /// <summary>
        /// Updates the <see cref="Robot"/> object.
        /// </summary>
        /// <param name="value">The <see cref="Robot"/> object.</param>
        /// <returns>A refreshed <see cref="Robot"/> object.</returns>
        public Task<Robot> UpdateAsync(Robot value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return DataInvoker.Current.InvokeAsync(this, async () =>
            {
                var __dataArgs = CosmosMapper.Default.CreateArgs("Items", PartitionKey.None, onCreate: _onDataArgsCreate);
                return await _cosmos.Container(__dataArgs).UpdateAsync(value).ConfigureAwait(false);
            });
        }

        /// <summary>
        /// Deletes the <see cref="Robot"/> object that matches the selection criteria.
        /// </summary>
        /// <param name="id">The <see cref="Robot"/> identifier.</param>
        public Task DeleteAsync(Guid id)
        {
            return DataInvoker.Current.InvokeAsync(this, async () =>
            {
                var __dataArgs = CosmosMapper.Default.CreateArgs("Items", PartitionKey.None, onCreate: _onDataArgsCreate);
                await _cosmos.Container(__dataArgs).DeleteAsync(id).ConfigureAwait(false);
            });
        }

        /// <summary>
        /// Gets the <see cref="Robot"/> collection object that matches the selection criteria.
        /// </summary>
        /// <param name="args">The Args (see <see cref="RobotArgs"/>).</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        /// <returns>A <see cref="RobotCollectionResult"/>.</returns>
        public Task<RobotCollectionResult> GetByArgsAsync(RobotArgs? args, PagingArgs? paging)
        {
            return DataInvoker.Current.InvokeAsync(this, async () =>
            {
                RobotCollectionResult __result = new RobotCollectionResult(paging);
                var __dataArgs = CosmosMapper.Default.CreateArgs("Items", __result.Paging!, PartitionKey.None, onCreate: _onDataArgsCreate);
                __result.Result = _cosmos.Container(__dataArgs).Query(q => _getByArgsOnQuery?.Invoke(q, args, __dataArgs) ?? q).SelectQuery<RobotCollection>();
                return await Task.FromResult(__result).ConfigureAwait(false);
            });
        }

        /// <summary>
        /// Provides the <see cref="Robot"/> entity and Cosmos <see cref="Model.Robot"/> property mapping.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "By design; as there is a direct relationship")]
        public partial class CosmosMapper : CosmosDbMapper<Robot, Model.Robot, CosmosMapper>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="CosmosMapper"/> class.
            /// </summary>
            public CosmosMapper()
            {
                Property(s => s.Id, d => d.Id).SetUniqueKey(true);
                Property(s => s.ModelNo, d => d.ModelNo);
                Property(s => s.SerialNo, d => d.SerialNo);
                Property(s => s.EyeColorSid, d => d.EyeColor);
                Property(s => s.PowerSourceSid, d => d.PowerSource);
                AddStandardProperties();
                CosmosMapperCtor();
            }
            
            /// <summary>
            /// Enables the <see cref="CosmosMapper"/> constructor to be extended.
            /// </summary>
            partial void CosmosMapperCtor();
        }
    }
}

#pragma warning restore IDE0005
#nullable restore