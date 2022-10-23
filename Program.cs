using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

Hotel reservasHotel = new Hotel();

string opcao = string.Empty;
bool exibirMenu = true;

while (exibirMenu) {
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar reserva");
    Console.WriteLine("2 - Remover reserva");
    Console.WriteLine("3 - Listar reservas");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            reservasHotel.CadastrarReserva();
            break;

        case "2":
            reservasHotel.RemoverReserva();
            break;

        case "3":
            reservasHotel.ListarReservas();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("");
Console.WriteLine("Programa encerrado");
Console.WriteLine("");