namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
          
         if (Suite != null && hospedes.Count <= Suite.Capacidade)
        {
            Hospedes = hospedes;
        }
        else
        {
            throw new ArgumentException("Número de hóspedes excede a capacidade da suíte.");
        }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
             return Hospedes != null ? Hospedes.Count : 0;
        }

        public decimal CalcularValorDiaria()
        {
          if (Suite == null)
            throw new InvalidOperationException("A suíte deve estar cadastrada antes de calcular o valor da diária.");

           decimal valor = DiasReservados * Suite.ValorDiaria;

           if (DiasReservados >= 10)
           {
               valor *= 0.9M; // Desconto de 10%
           }

          return valor;
        }
    }
}