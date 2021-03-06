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
using Beef.Data.OData;
using Soc = Simple.OData.Client;
using Beef.Entities;
using Beef.Mapper;
using Beef.Mapper.Converters;
using Beef.Demo.Common.Entities;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Business.Data
{
    /// <summary>
    /// Provides the Product data access.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable", Justification = "Will not always appear static depending on code-gen options")]
    public partial class ProductData : IProductData
    {
        private readonly ITestOData _odata;

        #region Extensions
        #pragma warning disable CS0649, IDE0044 // Defaults to null by design; can be overridden in constructor.

        private Func<Soc.IBoundClient<Model.Product>, ProductArgs?, IODataArgs, Soc.IBoundClient<Model.Product>>? _getByArgsOnQuery;

        #pragma warning restore CS0649, IDE0044
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductData"/> class.
        /// </summary>
        /// <param name="odata">The <see cref="ITestOData"/>.</param>
        public ProductData(ITestOData odata) { _odata = Check.NotNull(odata, nameof(odata)); ProductDataCtor(); }

        /// <summary>
        /// Enables additional functionality to be added to the constructor.
        /// </summary>
        partial void ProductDataCtor();

        /// <summary>
        /// Gets the <see cref="Product"/> object that matches the selection criteria.
        /// </summary>
        /// <param name="id">The <see cref="Product"/> identifier.</param>
        /// <returns>The selected <see cref="Product"/> object where found; otherwise, <c>null</c>.</returns>
        public Task<Product?> GetAsync(int id)
        {
            return DataInvoker.Current.InvokeAsync(this, async () =>
            {
                var __dataArgs = ODataMapper.Default.CreateArgs();
                return await _odata.GetAsync(__dataArgs, id).ConfigureAwait(false);
            });
        }

        /// <summary>
        /// Gets the <see cref="Product"/> collection object that matches the selection criteria.
        /// </summary>
        /// <param name="args">The Args (see <see cref="ProductArgs"/>).</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        /// <returns>A <see cref="ProductCollectionResult"/>.</returns>
        public Task<ProductCollectionResult> GetByArgsAsync(ProductArgs? args, PagingArgs? paging)
        {
            return DataInvoker.Current.InvokeAsync(this, async () =>
            {
                ProductCollectionResult __result = new ProductCollectionResult(paging);
                var __dataArgs = ODataMapper.Default.CreateArgs(__result.Paging!);
                __result.Result = _odata.Query(__dataArgs, q => _getByArgsOnQuery?.Invoke(q, args, __dataArgs) ?? q).SelectQuery<ProductCollection>();
                return await Task.FromResult(__result).ConfigureAwait(false);
            });
        }

        /// <summary>
        /// Provides the <see cref="Product"/> entity and OData property mapping.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "By design; as there is a direct relationship")]
        public partial class ODataMapper : ODataMapper<Product, Model.Product, ODataMapper>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ODataMapper"/> class.
            /// </summary>
            public ODataMapper()
            {
                Property(s => s.Id, d => d.ID).SetUniqueKey(false);
                Property(s => s.Name, d => d.Name);
                Property(s => s.Description, d => d.Description);
                ODataMapperCtor();
            }
            
            /// <summary>
            /// Enables the <see cref="ODataMapper"/> constructor to be extended.
            /// </summary>
            partial void ODataMapperCtor();
        }
    }
}

#pragma warning restore IDE0005
#nullable restore