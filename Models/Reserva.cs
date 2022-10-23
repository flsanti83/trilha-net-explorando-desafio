namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados) {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite.Capacidade >= hospedes.Count) {
                Hospedes = hospedes;
            }
            else {
                throw new ArgumentOutOfRangeException("Capacidade da suíte é menor que o número de hóspedes");
            }
        }

        public void CadastrarSuite(Suite suite) {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes() {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria() {
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%

            decimal valor = DiasReservados >= 10 
                                            ? (DiasReservados * Suite.ValorDiaria * 0.9M)
                                            : (DiasReservados * Suite.ValorDiaria);

            return valor;
        }
    }
}