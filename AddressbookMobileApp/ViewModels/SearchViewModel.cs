

using AppLibrary.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using AppLibrary.Models;
using AppLibrary.Services;
using System.Collections.ObjectModel;

namespace AddressbookMobileApp.ViewModels;

public partial class SearchViewModel : ObservableObject
{
    private ObservableCollection<IContact> _contacts;

    public ObservableCollection<IContact> Contacts
    {
        get { return _contacts; }
        set { SetProperty (ref _contacts, value); }
    }

    private readonly IContactService _contactService;


    public SearchViewModel(IContactService contactService)
    {
        _contacts = new ObservableCollection<IContact>();
        _contactService = contactService;
    }

    public void SearchContacts(string Email_Entry)
    {
        var contact = _contactService.GetContactFromList(Email_Entry);

        if(contact!=null) 
        {
            Contacts= new ObservableCollection<IContact> { contact };
        }
        else
        {
            
            Contacts.Clear();
        }
    }
}
