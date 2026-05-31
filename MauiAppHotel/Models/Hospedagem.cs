namespace MauiAppHotel.Models
{
   public class Hospedagem
    {
        public Quarto QuartoSelecionado { get; set; }

        public int qntAdultos { get; set;  }

        public int qntCriancas {get; set;  }

        public DateTime DataCheckin { get; set; }

        public DateTime DataCheckout { get; set; }

        public int Estadia
        {

            get => DataCheckout.Subtract(DataCheckin).Days;

        }

        public double ValorTotal
        {
            get
            {
                double valor_adultos = qntAdultos * QuartoSelecionado.ValorDiariaAdulto;
                double valor_criacas = qntCriancas * QuartoSelecionado.ValorDiariaCrianca;

                double total = (valor_adultos + valor_criacas) * Estadia;

                return total;
            }
        }


    }
}
