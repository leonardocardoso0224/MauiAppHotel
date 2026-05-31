

using MauiAppHotel.Models;

namespace MauiAppHotel.bios;

public partial class ContratacaoHospedagem : ContentPage
{

	App propriedadesApp;


	public ContratacaoHospedagem()
	{
		InitializeComponent();

		propriedadesApp = (App)Application.Current;

		pck_quarto.ItemsSource = propriedadesApp.lista_quatos;

		dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = DateTime.Now.AddMonths(1);

        dtpck_checkOut.MinimumDate = dtpck_checkin.Date.Value.AddDays(1);
        dtpck_checkOut.MaximumDate = dtpck_checkin.Date.Value.AddMonths(6);





    }

    private async void Button_Clicked(object sender, EventArgs e)
    {

		try
		{

			Hospedagem h = new Hospedagem()
			{
				QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
				qntAdultos = Convert.ToInt32(stp_adultos.Value),
                qntCriancas = Convert.ToInt32(stp_criancas.Value),
				DataCheckin = (DateTime)dtpck_checkin.Date,
				DataCheckout = (DateTime)dtpck_checkOut.Date,

			};


			await Navigation.PushAsync(new HospedagemContratada()
			{
				BindingContext = h

			});


		} catch (Exception ex)
		{

			await DisplayAlert("Ops", ex.Message, "OK");

			}

    }

	private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
	{
		DatePicker elemento = sender as DatePicker;
		DateTime data_selecionada_checkin = (DateTime)elemento.Date;

		dtpck_checkOut.MinimumDate = data_selecionada_checkin.AddDays(1);
		dtpck_checkOut.MaximumDate = data_selecionada_checkin.AddMonths(6);
	}



}