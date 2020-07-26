/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable IDE0005 // Using directive is unnecessary; are required depending on code-gen options

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beef;
using Beef.RefData;
using Cdr.Banking.Business.DataSvc;
using Cdr.Banking.Common.Entities;
using RefDataNamespace = Cdr.Banking.Common.Entities;

namespace Cdr.Banking.Business
{
    /// <summary>
    /// Provides the <see cref="ReferenceData"/> implementation using the corresponding data services.
    /// </summary>
    public class ReferenceDataProvider : RefDataNamespace.ReferenceData
    {
        private readonly IReferenceDataDataSvc _dataService;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceDataProvider"/> class.
        /// </summary>
        /// <param name="dataService">The <see cref="IReferenceDataDataSvc"/>.</param>
        public ReferenceDataProvider(IReferenceDataDataSvc dataService) => _dataService = Check.NotNull(dataService, nameof(dataService));
    
        #region Collections

        /// <summary> 
        /// Gets the <see cref="RefDataNamespace.OpenStatusCollection"/>.
        /// </summary>
        public override RefDataNamespace.OpenStatusCollection OpenStatus => (RefDataNamespace.OpenStatusCollection)this[typeof(RefDataNamespace.OpenStatus)];

        /// <summary> 
        /// Gets the <see cref="RefDataNamespace.ProductCategoryCollection"/>.
        /// </summary>
        public override RefDataNamespace.ProductCategoryCollection ProductCategory => (RefDataNamespace.ProductCategoryCollection)this[typeof(RefDataNamespace.ProductCategory)];

        /// <summary> 
        /// Gets the <see cref="RefDataNamespace.AccountUTypeCollection"/>.
        /// </summary>
        public override RefDataNamespace.AccountUTypeCollection AccountUType => (RefDataNamespace.AccountUTypeCollection)this[typeof(RefDataNamespace.AccountUType)];

        /// <summary> 
        /// Gets the <see cref="RefDataNamespace.MaturityInstructionsCollection"/>.
        /// </summary>
        public override RefDataNamespace.MaturityInstructionsCollection MaturityInstructions => (RefDataNamespace.MaturityInstructionsCollection)this[typeof(RefDataNamespace.MaturityInstructions)];

        /// <summary> 
        /// Gets the <see cref="RefDataNamespace.TransactionTypeCollection"/>.
        /// </summary>
        public override RefDataNamespace.TransactionTypeCollection TransactionType => (RefDataNamespace.TransactionTypeCollection)this[typeof(RefDataNamespace.TransactionType)];

        /// <summary> 
        /// Gets the <see cref="RefDataNamespace.TransactionStatusCollection"/>.
        /// </summary>
        public override RefDataNamespace.TransactionStatusCollection TransactionStatus => (RefDataNamespace.TransactionStatusCollection)this[typeof(RefDataNamespace.TransactionStatus)];

        #endregion
  
        /// <summary>
        /// Gets the <see cref="IReferenceDataCollection"/> for the associated <see cref="ReferenceDataBase"/> <see cref="Type"/>.
        /// </summary>
        /// <param name="type">The <see cref="ReferenceDataBase"/> <see cref="Type"/>.</param>
        /// <returns>A <see cref="IReferenceDataCollection"/>.</returns>
        public override IReferenceDataCollection this[Type type] => _dataService.GetCollection(type);
        
        /// <summary>
        /// Prefetches all, or the list of <see cref="ReferenceDataBase"/> objects, where not already cached or expired.
        /// </summary>
        /// <param name="names">The list of <see cref="ReferenceDataBase"/> names; otherwise, <c>null</c> for all.</param>
        public override Task PrefetchAsync(params string[] names)
        {
            var types = new List<Type>();
            if (names == null)
            {
                types.AddRange(GetAllTypes());
            }
            else
            {
                foreach (string name in names.Distinct())
                {
                    switch (name)
                    {
                        case var n when string.Compare(n, nameof(RefDataNamespace.OpenStatus), StringComparison.InvariantCultureIgnoreCase) == 0: types.Add(typeof(RefDataNamespace.OpenStatus)); break;
                        case var n when string.Compare(n, nameof(RefDataNamespace.ProductCategory), StringComparison.InvariantCultureIgnoreCase) == 0: types.Add(typeof(RefDataNamespace.ProductCategory)); break;
                        case var n when string.Compare(n, nameof(RefDataNamespace.AccountUType), StringComparison.InvariantCultureIgnoreCase) == 0: types.Add(typeof(RefDataNamespace.AccountUType)); break;
                        case var n when string.Compare(n, nameof(RefDataNamespace.MaturityInstructions), StringComparison.InvariantCultureIgnoreCase) == 0: types.Add(typeof(RefDataNamespace.MaturityInstructions)); break;
                        case var n when string.Compare(n, nameof(RefDataNamespace.TransactionType), StringComparison.InvariantCultureIgnoreCase) == 0: types.Add(typeof(RefDataNamespace.TransactionType)); break;
                        case var n when string.Compare(n, nameof(RefDataNamespace.TransactionStatus), StringComparison.InvariantCultureIgnoreCase) == 0: types.Add(typeof(RefDataNamespace.TransactionStatus)); break;
                    }
                }
            }

            Parallel.ForEach(types, (type, _) => { var __ = this[type]; });
            return Task.CompletedTask;
        }
    }
}

#pragma warning restore IDE0005
#nullable restore