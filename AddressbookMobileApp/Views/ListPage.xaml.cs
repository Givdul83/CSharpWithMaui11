using AddressbookMobileApp.ViewModels;
using Microsoft.Maui.Controls;
using AppLibrary.Services;
using System.Collections.ObjectModel;
using AppLibrary.Interfaces;
using AppLibrary.Models;
using System.Diagnostics;

namespace AddressbookMobileApp.Views;



public partial class ListPage : ContentPage

{
    private ViewListModel _viewModel;
	

	public ListPage(ViewListModel viewModel, IContactService contactService)
	{
        InitializeComponent();
        _viewModel= viewModel;
		_viewModel.Contacts= new ObservableCollection<IContact>(contactService.GetContactsFromList());
        BindingContext = _viewModel;

       
	}
 
}