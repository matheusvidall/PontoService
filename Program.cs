using System;
using System.Collections.Generic;
using System.IO;

namespace PontoService
{
    class RegistraHora
    {
        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraTermino { get; set; }
        public string Descricao { get; set; }

        public override string ToString()
        {
            return $"{Data.ToShortDateString()} | {HoraInicio} - {HoraTermino} | {Descricao}";
        }
    }

    class GerenciadorRegistroHora
    {
        private List<RegistraHora> registros = new List<RegistraHora>();

        public void AdicionarRegistro(RegistraHora registro)
        {
            registros.Add(registro);
        }

        public void VisualizarRegistros()
        {
            foreach (var registro in registros)
            {
                Console.WriteLine(registro);
            }
        }

        public void SalvarRegistros(string caminhoArquivo)
        {
            using (StreamWriter writer = new StreamWriter(caminhoArquivo))
            {
                foreach (var registro in registros)
                {
                    writer.WriteLine($"{registro.Data},{registro.HoraInicio},{registro.HoraTermino},{registro.Descricao}");
                }
            }
        }
    }
    class Program
    {
        static void Main()
        {
            GerenciadorRegistroHora gerenciador = new GerenciadorRegistroHora();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("1. Adicionar Registro");
                Console.WriteLine("2. Visualizar Registro");
                Console.WriteLine("3. Salvar Registros");
                Console.WriteLine("4. Sair");
                Console.WriteLine("Escolha uma opção: ");

                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        RegistraHora novoRegistro = new RegistraHora();
                        novoRegistro.Data = DateTime.Now.Date; // Data atual do sistema
                        novoRegistro.HoraInicio = DateTime.Now.TimeOfDay; // Hora de início atual do sistema

                        Console.WriteLine("Trabalhando... Pressione Enter quando terminar.");
                        Console.ReadLine();

                        novoRegistro.HoraTermino = DateTime.Now.TimeOfDay; // Hora de término atual do sistema

                        Console.Write("Descrição: ");
                        novoRegistro.Descricao = Console.ReadLine();

                        gerenciador.AdicionarRegistro(novoRegistro);
                        break;

                    case "2":
                        gerenciador.VisualizarRegistros();
                        break;

                    case "3":
                        Console.Write("Digite o caminho do arquivo para salvar os registros: ");
                        string caminhoArquivo = Console.ReadLine();
                        gerenciador.SalvarRegistros(caminhoArquivo);
                        break;

    case "4":
    continuar = false;
                        break;
 default:
Console.WriteLine("Opção inválida, tente novamente.");
                        break;

                }
            }
        }
    }
}
//Dedicated To Bianca!!(:
