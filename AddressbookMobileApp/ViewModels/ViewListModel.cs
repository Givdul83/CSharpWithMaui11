
using AppLibrary.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using AppLibrary.Models;
using AppLibrary.Services;
using System.Collections.ObjectModel;

namespace AddressbookMobileApp.ViewModels;

public partial class ViewListModel : ObservableObject
{
    private ObservableCollection<IContact> _contacts;
    private IContact _contact;

    public ObservableCollection<IContact> Contacts
    {
        get { return _contacts; }
        set { SetProperty(ref _contacts, value); }
    }



    public ViewListModel()
    {
        _contacts = new ObservableCollection<IContact>();
    }

}




