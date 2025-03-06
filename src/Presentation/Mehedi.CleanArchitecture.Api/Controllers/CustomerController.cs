// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Application.UseCases.Customers.Commands;
using MediatR;
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
        await _mediator.Send(command);
        return Ok("Customer Command Request Accepted");
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
