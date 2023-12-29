
namespace AppLibrary.Interfaces;

public interface IContactService
{
    /// <summary>
    /// Creates an IContact and saves it to the Contact List.
    /// Checks so that there isnt already a Contact with the same email address first
    /// </summary>
    /// <param name="contact">takes the info needed as defined by IContact</param>
    /// <returns>result if succesfull else returns false</returns>
    bool AddContactToList(IContact contact);

    /// <summary>
    /// Presents the current version of the Contact List
    /// </summary>
    /// <returns>an readable list of contacts</returns>
    IEnumerable<IContact> GetContactsFromList();
    /// <summary>
    /// Checks the List for specific Contact by using email address
    /// </summary>
    /// <param name="email">takes a email address in form of string</param>
    /// <returns>An IContact if found</returns>
    IContact GetContactFromList(string email);
    /// <summary>
    /// Removes specific Contact in List by using email address
    /// </summary>
    /// <param name="email">takes a email address in form of string</param>
    /// <returns>Result if succesful false if failed</returns>
    bool RemoveContactFromList(string email);

    bool UpdateContact(IContact contact);
}
