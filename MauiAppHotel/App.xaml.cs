using Microsoft.Extensions.DependencyInjection;

namespace MauiAppHotel
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new bios.ContratacaoHospedagem()); 
        }

   
        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

           
            window.Width = 500;  
            window.Height = 700; 

            return window;
        }
    }
}