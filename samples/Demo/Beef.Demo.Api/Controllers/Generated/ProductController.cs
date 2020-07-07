/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable IDE0005 // Using directive is unnecessary; are required depending on code-gen options

using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Beef;
using Beef.AspNetCore.WebApi;
using Beef.Entities;
using Beef.Demo.Business;
using Beef.Demo.Common.Entities;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Api.Controllers
{
    /// <summary>
    /// Provides the <b>Product</b> Web API functionality.
    /// </summary>
    [Route("api/v1/products")]
    public partial class ProductController : ControllerBase
    {
        private readonly IProductManager _manager;
        
        /// <summary>
        /// Parameterless constructor is explictly not supported.
        /// </summary>
        private ProductController() => throw new NotSupportedException();

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="manager">The <see cref="IProductManager"/>.</param>
        public ProductController(IProductManager manager) => _manager = manager ?? throw new ArgumentNullException(nameof(manager));

        /// <summary>
        /// Gets the <see cref="Product"/> entity that matches the selection criteria.
        /// </summary>
        /// <param name="id">The <see cref="Product"/> identifier.</param>
        /// <returns>The selected <see cref="Product"/> entity where found.</returns>
        [HttpGet()]
        [Route("{id}")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Get(int id)
        {
            return new WebApiGet<Product?>(this, () => _manager.GetAsync(id),
                operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Gets the <see cref="Product"/> collection entity that matches the selection criteria.
        /// </summary>
        /// <param name="name">The Name.</param>
        /// <param name="description">The Description.</param>
        /// <returns>A <see cref="ProductCollection"/>.</returns>
        [HttpGet()]
        [Route("")]
        [ProducesResponseType(typeof(ProductCollection), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult GetByArgs(string? name = default, string? description = default)
        {
            var args = new ProductArgs { Name = name, Description = description };
            return new WebApiGet<ProductCollectionResult, ProductCollection, Product>(this, () => _manager.GetByArgsAsync(args, WebApiQueryString.CreatePagingArgs(this)),
                operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NoContent);
        }
    }
}

#pragma warning restore IDE0005
#nullable restore