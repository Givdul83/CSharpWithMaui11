
namespace AppLibrary.Interfaces;

public interface IContact
{
    /// <summary>
    /// Sets the different info the program wants to create a Contact
    /// </summary>    
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }
    string PhoneNumber { get; set; }
    string StreetAddress { get; set; }
    string City { get; set; }
    string PostalCode { get; set; }
    Guid Id { get; set; }
}
