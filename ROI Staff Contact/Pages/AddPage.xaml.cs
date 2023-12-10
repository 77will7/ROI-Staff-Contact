namespace ROI_Staff_Contact.Pages;

public partial class AddPage : ContentPage
{
    private DatabaseService _databaseService;

    public AddPage(DatabaseService databaseService)
	{
		InitializeComponent();

        _databaseService = databaseService;
    }

    private void ListButton_Clicked(object sender, EventArgs e)
    {
		Navigation.PushModalAsync(new MainPage());
    }
    private async void AddStaff_Clicked(object sender, EventArgs e)
    {
        var newStaff = new Staff
        {
            ID = Int32.Parse(StaffID.Text),
            FullName = Name.Text,
            Phone = Phone.Text,
            Department = Int32.Parse(DepID.Text),
            Street = Street.Text,
            City = City.Text,
            State = State.Text,
            ZIP = Zip.Text,
            Country = Country.Text,
        };

        await _databaseService.AddStaffAsync(newStaff);

        StaffID.Text = Name.Text = Phone.Text = DepID.Text = Street.Text= City.Text = State.Text = Zip.Text = Country.Text= string.Empty;
    }
}