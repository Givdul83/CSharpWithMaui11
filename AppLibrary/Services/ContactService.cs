using AppLibrary.Interfaces;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Collections;

namespace AppLibrary.Services;


public class ContactService : IContactService

{
    private readonly IFileService _fileService;

    public ContactService(IFileService fileService)
    {
        _fileService = fileService;
    }

    private List<IContact> _contacts = [];

    /// <summary>
    /// defines filepath to save and fetch contact list
    /// </summary>
    private readonly string _filePath = @"c:\examcsharp\consoleapp\contacts.json";


    /// <summary>
    /// Adds Contact to the List in form of json object 
    /// Checks via the registered email adress so contact dosent already exist.
    ///  Then the list is saved to file via SaveContent()
    /// </summary>
    /// <param name="contact">Takes the user input from menus in form of an IContact</param>
    /// <returns>Returns bool of result if succesfull in saving, otherwise returns false</returns>
    public bool AddContactToList(IContact contact)
    {
        try
        {
            _contacts = GetContactsFromList().ToList();

            if (!_contacts.Any(x => x.Email == contact.Email))
            {
                _contacts.Add(contact);

                string json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

                var result = _fileService.SaveContent(_filePath, json);


                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ContactService- AddContactToList" + ex.Message); }
        return false;
    }

    /// <summary>
    /// Checks the list for a specific Contact by using email adress
    /// </summary>
    /// <param name="email">Enter the Contacts email adress as a string to check for matches in list</param>
    /// <returns>Returns Contact in form of an IContact if found in list else returns null</returns>
    public IContact GetContactFromList(string email)
    {
        try
        {
            _contacts = GetContactsFromList().ToList();

            var contact = _contacts.FirstOrDefault(x => x.Email == email);
            return contact ??= null!;


        }
        catch (Exception ex) { Debug.WriteLine("ContactService- GetContactFromList" + ex.Message); }
        return null!;
    }


    /// <summary>
    /// Presents the list in its current form, first formatting it from json list/objects
    /// </summary>
    /// <returns>returns a readable list of IContacts if succesfull, otherwise returns null</returns>
    public IEnumerable<IContact> GetContactsFromList()
    {
        try
        {
            var content = _fileService.GetContent(_filePath);
            _contacts.Clear();

            if (!string.IsNullOrEmpty(content))
            {
                
                _contacts = JsonConvert.DeserializeObject<List<IContact>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;
                Console.WriteLine($"Contacts loaded: {_contacts.Count}");

               
                return _contacts;
            }


        }
        catch (Exception ex) { Debug.WriteLine("ContactService- GetContactsFromList" + ex.Message); }
        return Enumerable.Empty<IContact>();
    }

    /// <summary>
    /// Removes Contact to the List 
    /// Checks via the registered email adress if Contact exist.
    /// If Contact is found its removed from the list.
    /// Then the list is saved to file via SaveContent()
    /// </summary>
    /// <param name="email">Takes email adress in string format to check for Contact</param>
    /// <returns>returns rsult bool if succesful otherwise returns false </returns>
    public bool RemoveContactFromList(string email)
    {
        try
        {
            _contacts = GetContactsFromList().ToList();
            var contact = _contacts.FirstOrDefault(x => x.Email == email);

            if (contact != null)
            {
                _contacts.Remove(contact);
                string json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

                var result = _fileService.SaveContent(_filePath, json);


                return result;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ContactService- RemoveContactToList" + ex.Message); }
        return false;
    }

    public bool UpdateContact(IContact contact)
    {
        try
        {

            return true;
        }
        catch (Exception ex) { Debug.WriteLine("ContactService- UpdateContact" + ex.Message); }
        return false;
    }
}