using Yukki.Views;

namespace Yukki
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Order_page), typeof(Order_page));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(Offers_of_the_week), typeof(Offers_of_the_week));
            Routing.RegisterRoute(nameof(settings_page), typeof(settings_page));
            Routing.RegisterRoute(nameof(Cart_Page), typeof(Cart_Page));

        }
    }
}
