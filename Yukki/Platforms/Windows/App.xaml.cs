using Microsoft.UI.Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Yukki.WinUI
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : MauiWinUIApplication
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            base.OnLaunched(args);

            var window = Application.Windows[0].Handler.PlatformView as Microsoft.UI.Xaml.Window;

            if (window != null)
            {
                window.ExtendsContentIntoTitleBar = true;
                window.SetTitleBar(null); // Remove a barra padrão
            }
        }

    }

}
