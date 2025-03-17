// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MediatR;
using Mehedi.CleanArchitecture.Application.UseCases.Customers.Commands.Create;
using Mehedi.CleanArchitecture.Application.UseCases.Customers.Commands.Delete;
using Mehedi.CleanArchitecture.Application.UseCases.Customers.Commands.Update;
using Mehedi.CleanArchitecture.Application.UseCases.Customers.Queries;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

namespace Mehedi.CleanArchitecture.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    /// <summary>
    /// Register a new customer.
    /// </summary>
    /// <response code="200">Returns the Id of the new client.</response>
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> Create([FromBody][Required] CreateCustomerCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    /// <summary>
    /// Delete customer data
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> Update([FromBody][Required] UpdateCustomerCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    /// <summary>
    /// Update customer data
    /// </summary>
    /// <returns></returns>
    [HttpDelete]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> Delete([FromBody][Required] DeleteCustomerCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    /// <summary>
    /// Get all customer data
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllCustomerQuery());

        return Ok(result);
    }
}
