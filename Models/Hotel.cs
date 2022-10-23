using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace DesafioProjetoHospedagem.Models
{
    public class Hotel
    {
        private List<Reserva> reservas = new List<Reserva>();
        
        public void CadastrarReserva() {

            string incluirReserva = "S";

            while (incluirReserva != "N") {

                bool repetir = true;

// Cria a suíte
//Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);
                Suite suite = new Suite();
                Console.Write("informe o tipo de suíte selecionada: ");
                suite.TipoSuite = Console.ReadLine();

                while (repetir) {
                    Console.Write("informe a capacidade da suíte: ");
                    Int32.TryParse(Console.ReadLine(), out int capacidade);

                    if (capacidade == 0) {
                        Console.WriteLine("Quantidade informada inválida!");
                    } else {
                        suite.Capacidade = capacidade;
                        repetir = false;
                    }
                }

                Console.Write("informe o valor da diária: ");
                decimal.TryParse(Console.ReadLine(), out decimal valor);
                suite.ValorDiaria = valor;
                Console.WriteLine("Suíte incluída com sucesso");
                Console.WriteLine("");

                repetir = true;
                int quantidadeDias = 0;
                while (repetir){
                    Console.Write("Informe a quantidade de dias da reserva: ");
                    Int32.TryParse(Console.ReadLine(), out quantidadeDias);

                    if (quantidadeDias == 0) {
                        Console.WriteLine("Valor informado é inválido");
                    } else {
                        repetir = false;
                        Console.WriteLine("");
                    }
                }

                List<Pessoa> hospedes = new List<Pessoa>();
                string incluirHospedes = "S";

                while (incluirHospedes != "N") {
                    Console.Write("Informe o nome do hóspede: ");
                    string nome = Console.ReadLine();
                    if (nome == String.Empty || nome.Length < 4) {
                        Console.WriteLine("Nome informado é inválido");
                    } else {
                        Pessoa pessoa = new Pessoa(nome);
                        hospedes.Add(pessoa);

                        Console.WriteLine("Hóspede incluído com sucesso");

                        if (hospedes.Count == suite.Capacidade) {
                            Console.WriteLine("Capacidade da suíte atingida");
                            incluirHospedes = "N";
                        } else {
                            Console.Write("Deseja incluir outro hóspede? (S/N) ");
                            incluirHospedes = Console.ReadLine().ToUpper();
                        }
                    }
                }

                Console.WriteLine("");

                // Cria uma nova reserva, passando a suíte e os hóspedes
                Reserva reserva = new Reserva();
                reserva.DiasReservados = quantidadeDias;
                reserva.CadastrarSuite(suite);
                reserva.CadastrarHospedes(hospedes);
                reservas.Add(reserva);

                Console.WriteLine("Reserva incluída com sucesso");
                Console.Write("Deseja incluir outra reserva? (S/N) ");
                incluirReserva = Console.ReadLine().ToUpper();
            }
        }

        public void RemoverReserva(){
            if (reservas.Count == 0) {
                Console.WriteLine("Nenhuma reserva cadastrada");
            } else {
                Console.Write("Digite o número da reserva que deseja cancelar: ");
                Int32.TryParse(Console.ReadLine(), out int numeroReserva);

                if (numeroReserva > 0 && reservas[numeroReserva - 1] != null){
                    reservas.Remove(reservas[numeroReserva - 1]);
                    Console.WriteLine("Reserva cancelada com sucesso!");
                } else {
                    Console.WriteLine("Número da reserva inválido");
                }
            }
        }

        public void ListarReservas(){
            if (reservas.Any()) {
                int contador = 1;
                Console.WriteLine("As reservas realizadas são as seguintes:");

                foreach (Reserva reserva in reservas) {
                    Console.WriteLine($"Reserva número {contador} de uma suíte {reserva.Suite.TipoSuite} para {reserva.Hospedes.Count} hóspedes no valor de {reserva.CalcularValorDiaria().ToString("C2", CultureInfo.CurrentCulture)}");
                    contador += 1;
                }
            } else {
                Console.WriteLine("Não existem reservas registradas");
            }
        }
    }
}