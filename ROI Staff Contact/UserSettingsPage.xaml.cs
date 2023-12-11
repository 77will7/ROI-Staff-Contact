using SQLite;
using System.ComponentModel.Design;

namespace ROI_Staff_Contact;

public partial class UserSettingsPage : ContentPage
{
    private SQLiteAsyncConnection _database;

    public UserSettingsPage()
    {
        InitializeComponent();

        // Initialize the SQLite database connection
        var databasePath = Path.Combine(FileSystem.AppDataDirectory, "settings.db");
        _database = new SQLiteAsyncConnection(databasePath);
        _database.CreateTableAsync<UserSet>().Wait();

        // Load the user settings
        LoadUserSettings();
    }
    private async void LoadUserSettings()
    {
        // Check if the user settings already exist in the database
        var existingSettings = await _database.Table<UserSet>().FirstOrDefaultAsync();
        if (existingSettings != null)
        {
            NameEntry.Text = existingSettings.Name;
            AgeEntry.Text = existingSettings.Age.ToString();
            FontSlider.Value = existingSettings.FontSize;

            if (existingSettings.lightOrDark)
            {
                togTheme.IsToggled = true;
            }
            else
            {
                togTheme.IsToggled = false;
            }
            if (existingSettings.grayOrRed)
            {
                togBackground.IsToggled = true;
            }
            else
            {
                togBackground.IsToggled = false;
            }

            var currentTheme = existingSettings.lightOrDark;
            if (currentTheme)
                Application.Current.UserAppTheme = AppTheme.Dark;
            else
                Application.Current.UserAppTheme = AppTheme.Light;
        }
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        var name = NameEntry.Text;
        int age = 0;
        int.TryParse(AgeEntry.Text, out age);
        bool theme = togTheme.IsToggled;
        bool background = togBackground.IsToggled;
        int fontSize = (int)FontSlider.Value;

        var userSettings = new UserSet
        {
            Name = name,
            Age = age,
            lightOrDark = theme,
            grayOrRed = background,
            FontSize = fontSize
            
        };

        await _database.InsertOrReplaceAsync(userSettings);

        // Show a confirmation message
        await DisplayAlert("Success", "User settings saved", "OK");
    }

    //PREFERENCES
    //SWITCH: https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/switch
    private void OnThemeSwitchToggled(object sender, ToggledEventArgs e)
    {
        bool isDarkTheme = e.Value;
        Preferences.Set("DarkThemeOn", isDarkTheme ? "Dark" : "Light");

        
        if (isDarkTheme)
            Application.Current.UserAppTheme = AppTheme.Dark;
        else
            Application.Current.UserAppTheme = AppTheme.Light;
    }

    private void togBackground_Toggled(object sender, ToggledEventArgs e)
    {
        bool isGrayBackground = e.Value;
        Preferences.Set("BackgroundRed", isGrayBackground ? "Red" : "Gray");

        // Apply the theme
        if (isGrayBackground)
            MainBackImg.Source = "roi_red_background.png";
        else
            MainBackImg.Source = "roi_gray_background.png";

    }

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        Slider sldr = sender as Slider;
        int newValue = (int)sldr.Value;
        FontSize.Text = String.Concat("Font Size: ",newValue);
        SettingsButton.FontSize = newValue;
        FontSize.FontSize = (newValue - 5);
        ChangeThemeText.FontSize = (newValue - 5);
        ChangeBackText.FontSize = (newValue - 5);
        ChangeFontText.FontSize = (newValue - 5);

    }
}