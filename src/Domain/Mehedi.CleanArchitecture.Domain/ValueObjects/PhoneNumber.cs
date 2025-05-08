using Mehedi.Core.SharedKernel;

namespace Mehedi.CleanArchitecture.Domain.ValueObjects;

public class PhoneNumber(string countryCode, 
                        string number, 
                        string? extension) : ValueObject
{
    public string CountryCode { get; private set; } = countryCode;
    public string Number { get; private set; } = number;
    public string? Extension { get; private set; } = extension;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return CountryCode;
        yield return Number;
        yield return Extension ?? string.Empty;
    }
}
