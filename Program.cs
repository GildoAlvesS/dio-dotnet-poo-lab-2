using System;

namespace DIO.Musicas
{
    class Program
    {
        static MusicaRepositorio repositorio = new MusicaRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1";
                        ListarMusicas();
                        break;
                    case "2";
                        InserirMusicas();
                        break;
                    case "3";
                        AtualizarMusicas();
                        break;
                    case "4";
                        ExcluirMusicas();
                        break;
                    case "5";
                        VisualizarMusicas();
                        break;
                    case "C";
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ExcluirMusicas()
		{
			Console.Write("Digite o id da música: ");
			int indiceMusicas = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceMusicas);
		}

        private static void VisualizarMusicas()
		{
			Console.Write("Digite o id da música: ");
			int indiceMusicas = int.Parse(Console.ReadLine());

			var Musicas = repositorio.RetornaPorId(indiceMusicas);

			Console.WriteLine(Musicas);
		}

        private static void AtualizarMusicas()
		{
			Console.Write("Digite o id da música: ");
			int indiceMusicas = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-5.0
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-5.0
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Música: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Música: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Música: ");
			string entradaDescricao = Console.ReadLine();

			Musicas AtualizarMusicas = new Musicas(id: indiceMusicas,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceMusicas, AtualizarMusicas);
		}
        private static void ListarMusicas()
		{
			Console.WriteLine("Listar Músicas");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma música cadastrada.");
				return;
			}

			foreach (var Musicas in lista)
			{
                var excluido = Musicas.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", Musicas.retornaId(), Musicas.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirMusicas()
		{
			Console.WriteLine("Inserir nova música");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Música: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Música: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Música: ");
			string entradaDescricao = Console.ReadLine();

			Musicas novaMusica = new Musicas(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaMusica);
		}

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Gildo Músicas a seu dispor!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar Músicas");
            Console.WriteLine("2 - Inserir Nova Música");
            Console.WriteLine("3 - Atualizar Música");
            Console.WriteLine("4 - Excluir Música");
            Console.WriteLine("5 - Visualizar Música");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
