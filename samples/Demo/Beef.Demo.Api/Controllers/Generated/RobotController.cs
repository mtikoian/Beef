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
    /// Provides the <b>Robot</b> Web API functionality.
    /// </summary>
    [Route("api/v1/robots")]
    public partial class RobotController : ControllerBase
    {
        private readonly IRobotManager _manager;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="RobotController"/> class.
        /// </summary>
        /// <param name="manager">The <see cref="IRobotManager"/>.</param>
        public RobotController(IRobotManager manager) => _manager = Check.NotNull(manager, nameof(manager));

        /// <summary>
        /// Gets the <see cref="Robot"/> entity that matches the selection criteria.
        /// </summary>
        /// <param name="id">The <see cref="Robot"/> identifier.</param>
        /// <returns>The selected <see cref="Robot"/> entity where found.</returns>
        [HttpGet()]
        [Route("{id}")]
        [ProducesResponseType(typeof(Robot), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Get(Guid id)
        {
            return new WebApiGet<Robot?>(this, () => _manager.GetAsync(id),
                operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Creates the <see cref="Robot"/> entity.
        /// </summary>
        /// <param name="value">The <see cref="Robot"/> entity.</param>
        /// <returns>The created <see cref="Robot"/> entity.</returns>
        [HttpPost()]
        [Route("")]
        [ProducesResponseType(typeof(Robot), (int)HttpStatusCode.Created)]
        public IActionResult Create([FromBody] Robot value)
        {
            return new WebApiPost<Robot>(this, () => _manager.CreateAsync(WebApiActionBase.Value(value)),
                operationType: OperationType.Create, statusCode: HttpStatusCode.Created, alternateStatusCode: null);
        }

        /// <summary>
        /// Updates the <see cref="Robot"/> entity.
        /// </summary>
        /// <param name="value">The <see cref="Robot"/> entity.</param>
        /// <param name="id">The <see cref="Robot"/> identifier.</param>
        /// <returns>The updated <see cref="Robot"/> entity.</returns>
        [HttpPut()]
        [Route("{id}")]
        [ProducesResponseType(typeof(Robot), (int)HttpStatusCode.OK)]
        public IActionResult Update([FromBody] Robot value, Guid id)
        {
            return new WebApiPut<Robot>(this, () => _manager.UpdateAsync(WebApiActionBase.Value(value), id),
                operationType: OperationType.Update, statusCode: HttpStatusCode.OK, alternateStatusCode: null);
        }

        /// <summary>
        /// Patches the <see cref="Robot"/> entity.
        /// </summary>
        /// <param name="value">The <see cref="JToken"/> value that contains the patch content for the entity.</param>
        /// <param name="id">The <see cref="Robot"/> identifier.</param>
        /// <returns>The patched <see cref="Robot"/> entity.</returns>
        [HttpPatch()]
        [Route("{id}")]
        [ProducesResponseType(typeof(Robot), (int)HttpStatusCode.OK)]
        public IActionResult Patch([FromBody] JToken value, Guid id)
        {
            return new WebApiPatch<Robot>(this, value, () => _manager.GetAsync(id), (__value) => _manager.UpdateAsync(__value, id),
                operationType: OperationType.Update, statusCode: HttpStatusCode.OK, alternateStatusCode: null);
        }

        /// <summary>
        /// Deletes the <see cref="Robot"/> entity that matches the selection criteria.
        /// </summary>
        /// <param name="id">The <see cref="Robot"/> identifier.</param>
        [HttpDelete()]
        [Route("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult Delete(Guid id)
        {
            return new WebApiDelete(this, () => _manager.DeleteAsync(id),
                operationType: OperationType.Delete, statusCode: HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Gets the <see cref="Robot"/> collection entity that matches the selection criteria.
        /// </summary>
        /// <param name="modelNo">The Model number.</param>
        /// <param name="serialNo">The Unique serial number.</param>
        /// <param name="powerSources">The Power Sources (see <see cref="RefDataNamespace.PowerSource"/>).</param>
        /// <returns>A <see cref="RobotCollection"/>.</returns>
        [HttpGet()]
        [Route("")]
        [ProducesResponseType(typeof(RobotCollection), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult GetByArgs([FromQuery(Name = "model-no")] string? modelNo = default, [FromQuery(Name = "serial-no")] string? serialNo = default, [FromQuery(Name = "power-sources")] List<string>? powerSources = default)
        {
            var args = new RobotArgs { ModelNo = modelNo, SerialNo = serialNo, PowerSourcesSids = powerSources };
            return new WebApiGet<RobotCollectionResult, RobotCollection, Robot>(this, () => _manager.GetByArgsAsync(args, WebApiQueryString.CreatePagingArgs(this)),
                operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Raises a <see cref="Robot.PowerSource"/> change event.
        /// </summary>
        /// <param name="id">The <see cref="Robot"/> identifier.</param>
        /// <param name="powerSource">The Power Source (see <see cref="RefDataNamespace.PowerSource"/>).</param>
        [HttpPost]
        [Route("{id}/powerSource/{powerSource}")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        public IActionResult RaisePowerSourceChange(Guid id, string? powerSource)
        {
            return new WebApiPost(this, () => _manager.RaisePowerSourceChangeAsync(id, powerSource),
                operationType: OperationType.Unspecified, statusCode: HttpStatusCode.Accepted);
        }
    }
}

#pragma warning restore IDE0005
#nullable restore