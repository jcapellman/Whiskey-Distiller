namespace WhiskeyDistiller.Mobile.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            LoadApplication(new WhiskeyDistiller.library.App());
        }
    }
}