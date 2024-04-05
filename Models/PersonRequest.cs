using SiliconValve.Demo.Redaction;

namespace SiliconValve.Demo.Models;

/// <summary>
/// Represents a person.
/// 
/// Note: this is just a sample to show you how to use the redaction library.
/// </summary>
/// <param name="FirstName">First name</param>
/// <param name="LastName">Last name</param>
/// <param name="Email">Email address</param>
/// <param name="PhoneNumber">Phone number</param>
/// <param name="Address">Postal address</param>
/// <param name="City">Postal address city</param>
/// <param name="DateOfBirth">Date of birth</param>
public record PersonRecordRequest(
    string FirstName, 
    string LastName,
    [SensitiveData] 
    string Email,
    [SensitiveData] 
    string PhoneNumber,
    [SensitiveData] 
    string Address,
    [SensitiveData] 
    string City, 
    [SensitiveData]
    DateOnly DateOfBirth
);