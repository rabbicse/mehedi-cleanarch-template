namespace CleanArchitecture.Application.UseCases.Customers.DTOs;

public record PhoneNumberRequest(string countryCode,
                        string number,
                        string? extension)
{
    public string CountryCode { get; private set; } = countryCode;
    public string Number { get; private set; } = number;
    public string? Extension { get; private set; } = extension;
}
