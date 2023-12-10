namespace ROI_Staff_Contact.Pages;

public partial class RemovePage : ContentPage
{
	public RemovePage()
	{
		InitializeComponent();
	}

    private void ListButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new MainPage());
    }
}