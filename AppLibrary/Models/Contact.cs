

using AppLibrary.Interfaces;

namespace AppLibrary.Models
{
    /// <summary>
    /// A class representig basic info of a Contact
    /// </summary>
    public class Contact :IContact
    { 
        /// <summary>
        /// properties and methods
        /// </summary>
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string StreetAddress { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
