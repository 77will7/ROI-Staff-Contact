using ROI_Staff_Contact.Pages;

namespace ROI_Staff_Contact
{
    
    public partial class MainPage : ContentPage
    {

        private DatabaseService _databaseService;
        private Staff _selectedStaff;

        private List<Staff> _staff;

        public MainPage()
        {
            InitializeComponent();

            _databaseService = new DatabaseService();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            LoadStaffAsync();
        }
        private void StaffButton_Clicked(object sender, EventArgs e)
        {
            _selectedStaff = (Staff)((Button)sender).BindingContext;
        }

        private void AddStaffButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AddPage(_databaseService));
        }

        private void EditStaffButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new EditPage(_selectedStaff,_databaseService));
        }

        private void DeleteStaffButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RemovePage(_databaseService));
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

        
    }

}
