namespace ROI_Staff_Contact
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            Window window = base.CreateWindow(activationState);

            const int newWidth = 360;
            const int newHeight = 800;

            window.Width = newWidth;
            window.Height = newHeight;

            return window;
        }
    }
}
