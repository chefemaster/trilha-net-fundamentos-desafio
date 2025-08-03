using DesafioFundamentos.Utils;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            Console.WriteLine("Deixe em branco para voltar.");
            string placa = Input.ReadVehiclePlate("Digite a placa do veículo para estacionar (ABC0000|ABC0A00):");
            if (string.IsNullOrEmpty(placa))
            {
                Console.WriteLine("Operação cancelada.");
                return;
            }
            if(veiculos.Exists(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Desculpe, esse veículo já está estacionado aqui.");
                return;
            }
            veiculos.Add(placa);
        }

        public void RemoverVeiculo()
        {        
            Console.WriteLine("Deixe em branco para voltar.");
            string placa = Input.ReadVehiclePlate("Digite a placa do veículo para remover  (ABC0000|ABC0A00):");
            if (string.IsNullOrEmpty(placa))
            {
                Console.WriteLine("Operação cancelada.");
                return;
            }

            // Verifica se o veículo existe
            var veiculo = veiculos.FirstOrDefault(x => x.ToUpper() == placa.ToUpper());
            
            if (!String.IsNullOrEmpty(veiculo))
            {
                // *IMPLEMENTE AQUI*
                int horas = Input.ReadInt("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                decimal valorTotal = precoInicial + precoPorHora * horas;

                // *IMPLEMENTE AQUI*
                veiculos.Remove(veiculo);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são: ");
                veiculos.ForEach(veiculo => Console.WriteLine($"- Placa: {veiculo}"));            
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
