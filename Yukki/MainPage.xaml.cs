using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Devices;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Yukki.Resources.Models;

namespace Yukki
{

    public class SushiItem
    {
        public string? Nome { get; set; }
        public string? Imagem { get; set; }
        public string? Descricao { get; set; }
    }

    public partial class MainPage : ContentPage
    {

        public List<SushiItem> Comidas { get; set; }

        private double _lastScrollY = 0;

        public MainPage()
        {

            InitializeComponent();

            Comidas = new List<SushiItem>
            {
                new SushiItem { Nome = "Sushi", Imagem = "download5.jpeg", Descricao = "Arroz e peixe fresco" },
                new SushiItem { Nome = "Temaki", Imagem = "download5.jpeg", Descricao = "Cone de alga com recheio" },
                new SushiItem { Nome = "Sashimi", Imagem = "download5.jpeg", Descricao = "Fatias de peixe cru" },
                new SushiItem { Nome = "Yakissoba", Imagem = "download5.jpeg", Descricao = "Macarrão com legumes" }
            };


            BindingContext = this;

        }

        private void OnScrolled(object sender, ScrolledEventArgs e)
        {
            // Quando rolar pra baixo, some
            if (e.ScrollY > _lastScrollY )
                Shell.SetNavBarIsVisible(this, false);

            // Quando rolar pra cima, volta
            if (e.ScrollY < _lastScrollY)
                Shell.SetNavBarIsVisible(this, true);

            _lastScrollY = e.ScrollY;
        }

        // ---------- CLICK HANDLERS ADICIONADOS ----------
        // Abre/fecha o flyout se estiver usando Shell; senão mostra um ActionSheet como fallback.

        private async void OnMenuClicked(object sender, EventArgs e)
        {
            
            try
            {
                
                if (Shell.Current != null)
                {
                    
                    Shell.Current.FlyoutIsPresented = !Shell.Current.FlyoutIsPresented;
                    
                    return;
                
                }
            
            }
            catch
            {
                
                // ignore e cair no fallback
            
            }

            var action = await DisplayActionSheet("Menu", "Cancelar", null, "Perfil", "Pedidos", "Configurações");
            
            if (action == "Perfil")
                await DisplayAlert("Perfil", "Abrir Perfil (implementar)", "OK");
            
            else if (action == "Pedidos")
                await DisplayAlert("Pedidos", "Abrir Pedidos (implementar)", "OK");
            
            else if (action == "Configurações")
                await DisplayAlert("Configurações", "Abrir Configurações (implementar)", "OK");
        
        }

        // Tenta navegar para rota "cart" no Shell; senão mostra um alerta genérico.
        private async void OnCartClicked(object sender, EventArgs e)
        {
            
            try
            {
                
                if (Shell.Current != null)
                {
                    
                    // tente navegar para uma rota "cart" (registre a rota se quiser usar)
                    
                    await Shell.Current.GoToAsync("cart");
                    
                    return;
                
                }
            
            }
            catch
            {
                
                // rota não configurada ou erro - fallback
            
            }

            await DisplayAlert("Carrinho", "Abrir carrinho (implementar rota ou página)", "OK");
        
        }
    
    }

}


