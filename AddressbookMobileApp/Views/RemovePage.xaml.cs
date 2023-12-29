using AddressbookMobileApp.ViewModels;


namespace AddressbookMobileApp.Views;

public partial class RemovePage : ContentPage
{
    private RemoveViewModel _viewModel;
    public RemovePage(RemoveViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
		BindingContext = viewModel;
	}

    private void Button_SearchToRemove_Clicked(object sender, EventArgs e)
    {
        var emailEntry = this.FindByName<Entry>("Entry_Email");
        _viewModel.SearchContacts(emailEntry.Text);

        var foundContactLabel = this.FindByName<Label>("Found_Contact");

        if (_viewModel.Contacts.Any())
        {
            var contact = _viewModel.Contacts.FirstOrDefault();
            var contactInfo = $"Found Contact: \n" +
                             $"Name: {contact.FirstName} {contact.LastName}\n" +
                             $"Email: {contact.Email}\n" +
                             $"Phone: {contact.PhoneNumber}\n" +
                             $"Address: {contact.StreetAddress}\n" +
                             $"Postal code:{contact.PostalCode}  {contact.City}";


            foundContactLabel.Text = contactInfo;
        }
        else
        {
            _viewModel.Contacts.Clear();
            var contactNotFound = "Contact not Found";
            foundContactLabel.Text = contactNotFound;
        }
    }



    private void Button_Delete_Clicked(object sender, EventArgs e)
    {
        var emailEntry = this.FindByName<Entry>("Entry_Email");
        var DeleteLabel= this.FindByName<Label>("Deleted_Contact");
        _viewModel.SearchContacts(emailEntry.Text);
        var contact = _viewModel.Contacts.FirstOrDefault();

        if(contact != null) 
        {
            _viewModel.DeleteContact(contact);
            _viewModel.Contacts.Remove(contact);
            var contactDeleted = "Contact has been Deleted";
            DeleteLabel.Text = contactDeleted;
        }
        else
        {
            var notDeleted = "No Contact deleted";
            DeleteLabel.Text = notDeleted;
            _viewModel.Contacts.Clear(); 
        }
        
    }
}