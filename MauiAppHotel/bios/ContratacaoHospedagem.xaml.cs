

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
		dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

		dtpck_checkOut.MinimumDate = dtpck_checkin.Date.Value.AddDays(1);
        dtpck_checkOut.MaximumDate = dtpck_checkin.Date.Value.AddMonths(6);





    }

    private void Button_Clicked(object sender, EventArgs e)
    {

		try
		{
			Navigation.PushAsync(new HospedagemContratada());


		} catch (Exception ex)
		{

			DisplayAlert("Ops", ex.Message, "OK");

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