using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Yukki.Resources.Models;
using Microsoft.Maui.Devices;

namespace Yukki
{
    public partial class MainPage : ContentPage
    {

        // Dados de exemplo (você pode substituir por chamada API)
        
        public ObservableCollection<Produto> Ofertas { get; set; }
        
        public ObservableCollection<Produto> Rodizio { get; set; }

        public MainPage()
        {
            
            InitializeComponent();

            Ofertas = new ObservableCollection<Produto>
    {
        new Produto { Nome="Yakissoba", Descricao="Massa saborosa", Imagem="foto.png" },
        new Produto { Nome="Hot Roll", Descricao="Crocrante", Imagem="foto.png" },
        new Produto { Nome="Sashimi", Descricao="Fresco", Imagem="foto.png" }
    };

            Rodizio = new ObservableCollection<Produto>
    {
        new Produto { Nome="Combo Sushi", Descricao="Peças selecionadas", Imagem="foto.png" },
        new Produto { Nome="Combo Premium", Descricao="Especial da casa", Imagem="foto.png" },
        new Produto { Nome="Temaki", Descricao="Cone recheado", Imagem="foto.png" }
    };

            BindingContext = this;

            double widht = this.Width;
            double height = this.Height * 2;

            this.SizeChanged += (s, e) =>
            {
                widht = this.Width;
                height = this.Height * 2;
                Body.WidthRequest = widht;
                Body.HeightRequest = height;
            };
        
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


