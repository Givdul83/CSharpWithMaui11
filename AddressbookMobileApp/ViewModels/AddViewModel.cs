
using AppLibrary.Models;
using AppLibrary.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AddressbookMobileApp.ViewModels;

    public partial class AddViewModel :ObservableObject
{
    
    public IContact Contact
    {
        get { return _contact; }
        set { SetProperty(ref _contact, value); }
    }
    private readonly IContactService _contactService;
    private IContact _contact;


    public AddViewModel(IContactService contactservice)
    {
        _contact = new AppLibrary.Models.Contact();
        _contactService = contactservice;

    }

    public void AddContact()
    {
       
        

        if (_contact!=null)
        {
            _contactService.AddContactToList(_contact);
        }
        
    }
}

