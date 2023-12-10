using ROI_Staff_Contact.Pages;

namespace ROI_Staff_Contact
{
    
    public partial class MainPage : ContentPage
    {

        private DatabaseService _databaseService;

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

        private void AddStaffButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AddPage(_databaseService));
        }

        private void EditStaffButton_Clicked(object sender, EventArgs e)
        {
            var selectedStaff = (Staff)((Button)sender).BindingContext;
            Navigation.PushModalAsync(new EditPage(selectedStaff,_databaseService));
        }

        private void DeleteStaffButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RemovePage());
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
