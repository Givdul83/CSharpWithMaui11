using AddressbookMobileApp.ViewModels;
using AppLibrary.Interfaces;
using AppLibrary.Models;
using AppLibrary.Services;
using Microsoft.Maui.Controls;

namespace AddressbookMobileApp.Views;

public partial class AddPage : ContentPage
{
	private AddViewModel _viewModel;

	private IContact Contact { get; set; }

	private IContactService ContactService { get; set; }

	public AddPage(AddViewModel vievModel)
	{
		InitializeComponent();
		
		_viewModel=vievModel;
		BindingContext = _viewModel;
	}

    private void Button_AddContact_Clicked(object sender, EventArgs e)
    {
		var contact = _viewModel.Contact;
        var result = this.FindByName<Label>("Add_Result");

        contact.FirstName = Contact_FirstName.Text;
		contact.LastName = Contact_LastName.Text;
		contact.Email = Contact_Email.Text;
		contact.StreetAddress= Contact_StreetAdress.Text;
		contact.City = Contact_City.Text;
		contact.PhoneNumber = Contact_PhoneNumber.Text;
		contact.PostalCode = Contact_PostalCode.Text;



		if (contact != null)
		{
			_viewModel.AddContact();
			var added = "Contact added";
			result.Text = added;
		}

		else
		{
			var failed = "Failed to add Contact";
			result.Text = failed;
		}
    }
}