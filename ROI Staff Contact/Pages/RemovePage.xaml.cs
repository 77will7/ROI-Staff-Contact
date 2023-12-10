namespace ROI_Staff_Contact.Pages;

public partial class RemovePage : ContentPage
{

    private DatabaseService _databaseService;
    private Staff _selectedStaff;

    private List<Staff> _staff;
    protected override void OnAppearing()
    {
        base.OnAppearing();

        LoadStaffAsync();
    }
    public RemovePage(DatabaseService databaseService)
	{
		InitializeComponent();

        _databaseService = new DatabaseService();
    }

    private void ListButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void StaffButton_Clicked(object sender, EventArgs e)
    {
        _selectedStaff = (Staff)((Button)sender).BindingContext;
        
    }

    public async void LoadStaffAsync()
    {
        try
        {
            _staff = await _databaseService.GetStaffAsync();
            StaffListView.ItemsSource = _staff;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex}");
        }
    }

    private async void DeleteStaffButton_Clicked(object sender, EventArgs e)
    {
        await _databaseService.DeleteStaffAsync(_selectedStaff);
        LoadStaffAsync();
    }
}