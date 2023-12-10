using Microsoft.Maui.Controls;
using static Microsoft.Maui.ApplicationModel.Permissions;
using System.Diagnostics.Metrics;
using System.IO;
using System.Xml.Linq;

namespace ROI_Staff_Contact.Pages;

public partial class EditPage : ContentPage
{
    private Staff _selectedStaff;
    private DatabaseService _databaseService;
    public EditPage(Staff selectedStaff, DatabaseService databaseService)
	{
		InitializeComponent();

        _selectedStaff = selectedStaff;

        _databaseService = databaseService;

        ID.Text = _selectedStaff.ID.ToString();
        Name.Text = _selectedStaff.FullName;
        Phone.Text = _selectedStaff.Phone;
        DepID.Text = _selectedStaff.Department.ToString();
        Street.Text = _selectedStaff.Street;
        City.Text = _selectedStaff.City;
        State.Text = _selectedStaff.State;
        ZIP.Text = _selectedStaff.ZIP;
        Country.Text = _selectedStaff.Country;

	}

    private void ListButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private async void EditStaffButton_Clicked(object sender, EventArgs e)
    {
        _selectedStaff.ID = Int32.Parse(ID.Text);
        _selectedStaff.FullName = Name.Text;
        _selectedStaff.Phone = Phone.Text;
        _selectedStaff.Department = Int32.Parse(DepID.Text);
        _selectedStaff.Street = Street.Text;
        _selectedStaff.City = City.Text;
        _selectedStaff.State = State.Text;
        _selectedStaff.ZIP = ZIP.Text;
        _selectedStaff.Country = Country.Text;

        await _databaseService.UpdateStaffAsync(_selectedStaff);

        await Navigation.PopModalAsync();
    }
}