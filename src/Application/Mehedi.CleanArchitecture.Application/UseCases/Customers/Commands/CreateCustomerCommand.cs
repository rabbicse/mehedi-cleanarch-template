using System.ComponentModel.DataAnnotations;
using CleanArchitecture.Application.UseCases.Customers.DTOs;
using MediatR;
using Mehedi.Application.SharedKernel.Responses;

namespace CleanArchitecture.Application.UseCases.Customers.Commands;

public class CreateCustomerCommand: IRequest<Result<CreatedCustomerResponse>>
{
    [Required]
    [MaxLength(100)]
    [DataType(DataType.Text)]
    public string? Name { get; set; }

    public PhoneNumberRequest? Phone { get; set; }
}
