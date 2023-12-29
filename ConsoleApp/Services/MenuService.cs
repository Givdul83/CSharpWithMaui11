
using AppLibrary.Interfaces;
using AppLibrary.Models;
using AppLibrary.Services;
using System;

namespace ConsoleApp.Services;

public class MenuService
{
    private readonly IContactService _contactService;

    public MenuService(IContactService contactService)
    {
        _contactService = contactService;
    }

    public void MainMenu()
    {


        while (true)
        {
            Console.Clear();
            Console.WriteLine("**** ContactsBook ****");
            Console.WriteLine();
            Console.WriteLine("### Main Menu ###");
            Console.WriteLine();
            Console.WriteLine("1. Show all contacts");
            Console.WriteLine();
            Console.WriteLine("2. Search for specific contact");
            Console.WriteLine();
            Console.WriteLine("3. Add a new contact");
            Console.WriteLine();
            Console.WriteLine("4. Remove a specific contact");
            Console.WriteLine();
            Console.WriteLine("5. Quit program");
            Console.WriteLine();
            Console.WriteLine("--------------------------------");
            Console.WriteLine();
            Console.Write("Please select one of options above :");
            var answer = Console.ReadLine();

            switch (answer)
            {
                case "1":
                    
                    ShowList();
                    break;

                case "2":
                    SearchContact();
                    break;
                    
                case "3":
                    AddContact(); 
                    break;
                case "4":
                    RemoveContact(); 
                    break;

                case "5":
                    QuitMenu();
                    break;

                default:
                    Console.WriteLine("invalid option, try again");
                    break;

            }



        }
    }
    private void ShowList()
    {
        Console.Clear();

            Console.WriteLine("#### All Contacts ####");
            Console.WriteLine("--------------------------------------------------");
            int index = 1;
        foreach (IContact contact in _contactService.GetContactsFromList())
        {
            Console.WriteLine($"{index}.");
            Console.WriteLine($"Name:  {contact.FirstName} {contact.LastName}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Phone: {contact.PhoneNumber}");
            Console.WriteLine($"Adress: {contact.StreetAddress} ");
            Console.WriteLine($"Postal Code: {contact.PostalCode}   {contact.City}");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("\n");

            index++;
        }
        

            

        Console.WriteLine("Press any key to return to main menu");
        Console.ReadKey();
        
        

    }

    private void SearchContact()
    {
        Console.Clear();
        Console.Write("Please enter email of person you are searching for: ");
        string searchedEmail = Console.ReadLine()?.ToLower()?.Trim() ?? "";
        Console.WriteLine();
        IContact foundPerson = _contactService.GetContactFromList(searchedEmail);

        if (foundPerson != null)
        {
            Console.WriteLine($"Name:  {foundPerson.FirstName} {foundPerson.LastName}");
            Console.WriteLine();
            Console.WriteLine($"Email: {foundPerson.Email}");
            Console.WriteLine();
            Console.WriteLine($"Phone: {foundPerson.PhoneNumber}");
            Console.WriteLine();
            Console.WriteLine($"Adress: {foundPerson.StreetAddress}");
            Console.WriteLine();
            Console.WriteLine($"Postal Code: {foundPerson.PostalCode} {foundPerson.City}");
            Console.WriteLine();
            Console.WriteLine($"City: {foundPerson.City}");
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Press any key to return to main menu");
            Console.ReadKey();
            
        }
        else
        {
            Console.WriteLine("Person not Found, press any key to return to main menu");
            Console.ReadKey();
        }
    }

    private void AddContact()

    {
        Console.Clear();
        var newContact = new Contact();
        Console.WriteLine("Please enter the following info");
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
        Console.Write("First Name:");
        newContact.FirstName = Console.ReadLine() ?? "";
        Console.Write("Last Name:");
        newContact.LastName = Console.ReadLine() ?? "";
        Console.Write("Email Address:");
        newContact.Email = Console.ReadLine()?.ToLower()?.Trim() ?? "";
        Console.Write("Streetname and Number:");
        newContact.StreetAddress = Console.ReadLine() ?? "";
        Console.Write("Postal Code:");
        newContact.PostalCode = Console.ReadLine() ?? "";
        Console.Write("City:");
        newContact.City = Console.ReadLine() ?? "";
        Console.Write("Phonenumber:");
        newContact.PhoneNumber = Console.ReadLine() ?? "";

        _contactService.AddContactToList(newContact);
        Console.WriteLine("Press any key to return to main menu");
        Console.ReadKey();
    }

    private void RemoveContact()
    {
        Console.Clear();
        Console.Write("Please enter email of person you want to remove: ");
        string deleteEmail = Console.ReadLine()?.ToLower()?.Trim() ?? "";
        Console.WriteLine();
        IContact deletePerson = _contactService.GetContactFromList(deleteEmail);

        if (deletePerson != null)
        {
            Console.WriteLine($"A person with email : {deleteEmail} was found.");
            Console.Write("Are you sure want to delete this person from the list? (y/n) : ");
            var delete = Console.ReadLine()?.ToLower();

            switch (delete)
            {
                case "y":
                    _contactService.RemoveContactFromList(deleteEmail);
                    Console.WriteLine($"{deletePerson.FirstName} {deletePerson.LastName} has been removed");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to main menu");
                    Console.ReadKey();
                    break;

                case "n":
                    Console.Clear();
                    Console.WriteLine("Press any key to return to main menu");
                    Console.ReadKey();
                    break;

                default:
                    Console.WriteLine("Invalid option press any key to try again");
                    Console.ReadKey();
                    break;
            }
           
        }
        else
        {
            Console.WriteLine($"Couldn´t find a person with Email : {deleteEmail} in list ");
            Console.WriteLine("Press any key to return to main menu");
            Console.ReadKey();
        }
    }
    private void QuitMenu()
    {
        Console.Clear();
        Console.Write("Are you sure you want to quit? (Y/N)");
        var quit = Console.ReadLine();

        switch (quit)
        {
            case "y":
                Console.WriteLine("Press any key to exit program");
                Console.ReadKey();
                Environment.Exit(0);
                break;

            case "n":
                Console.WriteLine("Press any key to return to Main Menu");
                Console.ReadKey();
                break;

            default:
                Console.WriteLine("invalid option, press any key to try again");
                Console.ReadKey();
                QuitMenu();
                break;

        }

    }
}

