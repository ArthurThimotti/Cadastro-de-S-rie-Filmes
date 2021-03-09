using System;
using DIO.Series.classes;



namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio serieRepositorio = new SerieRepositorio();

        static FilmeRepositorio filmeRepositorio = new FilmeRepositorio();


        public static void Main()
        {
            Console.Clear();
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "6":
                        MenuFilmes();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();

            }
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = serieRepositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nennhuma serie cadastrada.");
                return;

            }
            else
                foreach (var serie in lista)
                {
                    var excluido = serie.retornaExcluido();
                    Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
                }

        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {

                Console.WriteLine("{0}- {1}", i, Enum.GetName(typeof(Genero), i));

            }


            Console.Write("Digite o gênero entre as opcções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: serieRepositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            serieRepositorio.Insere(novaSerie);
            Console.WriteLine();
            Console.WriteLine(" ---- Serie cadastrada com sucesso! ----");


        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genêro entre a opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: serieRepositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);


            serieRepositorio.Atualiza(indiceSerie, atualizaSerie);

            Console.WriteLine();
            Console.WriteLine("---- Serie atualizada com sucesso! ----");



        }

        public static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            serieRepositorio.Exclui(indiceSerie);
        }

        public static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = serieRepositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }


        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!");
            Console.WriteLine("Informe a opcao desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar serie");
            Console.WriteLine("4- Excluir serie");
            Console.WriteLine("5- Visualizar Série");
            Console.WriteLine("6- [NEW] Acessar menu Filmes");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;


        }

        private static void MenuFilmes()
        {
            //Adiciona o filme recomendado a lista de filmes recomendados.
            filmeRepositorio.InserirFilmeRecomendado();
            Console.WriteLine();
            Console.WriteLine("DIO Filmes a seu dispor!");
            Console.WriteLine("Informe a opcao desejada:");

            Console.WriteLine("1- Listar filmes");
            Console.WriteLine("2- Inserir novo filme");
            Console.WriteLine("3- Atualizar filme");
            Console.WriteLine("4- Excluir filme");
            Console.WriteLine("5- Visualizar filme");
            Console.WriteLine("6- [NEW] DIO Indicações");
            Console.WriteLine("0- Voltar ao MENU de Séries");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");

            string useroptionFilme = Console.ReadLine().ToUpper();
            if (useroptionFilme.ToUpper() == "X")
            {
                Environment.Exit(0);
            }

            while (useroptionFilme.ToUpper() != "X")
            {
                switch (useroptionFilme)
                {
                    case "1":
                        ListarFilmes();
                        break;
                    case "2":
                        InserirFilmes();
                        break;
                    case "3":
                        AtualizarFilmes();
                        break;
                    case "4":
                        ExcluirFilmes();
                        break;
                    case "5":
                        VisualizarFilme();
                        break;
                    case "6":
                        Recomendacoes();
                        break;
                    case "0":
                        Main();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                MenuFilmes();

            }


        }

        private static void ListarFilmes()
        {
            Console.WriteLine("Listar filmes");

            var lista = filmeRepositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nennhum filme cadastrado.");
                return;

            }
            else
                foreach (var serie in lista)
                {
                    var excluido = serie.retornaExcluido();
                    Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
                }
        }

        private static void InserirFilmes()
        {

            Console.WriteLine("Inserir novo filme");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {

                Console.WriteLine("{0}- {1}", i, Enum.GetName(typeof(Genero), i));

            }


            Console.Write("Digite o gênero entre as opcções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme novoFilme = new Filme(id: filmeRepositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            filmeRepositorio.Insere(novoFilme);
            Console.WriteLine("\n----Filme cadastrado com sucesso!----");
        }

        private static void AtualizarFilmes()
        {

            Console.WriteLine("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genêro entre a opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título do filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme atualizaFilme = new Filme(id: serieRepositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);


            filmeRepositorio.Atualiza(indiceFilme, atualizaFilme);
        }



        private static void ExcluirFilmes()
        {

            Console.Write("Digite o id do Filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            serieRepositorio.Exclui(indiceFilme);

        }

        public static void VisualizarFilme()
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = filmeRepositorio.RetornaPorId(indiceFilme);

            Console.WriteLine(filme);
        }

        public static void Recomendacoes()
        {
            Console.WriteLine("---- Recomendações Filmes DIO ----\n");

            var filme1 = filmeRepositorio.RetornaRecomendado(0);
            var filme2 = filmeRepositorio.RetornaRecomendado(1);

            Console.WriteLine(filme1);
            Console.WriteLine();
            Console.WriteLine(filme2);

            //Pergunta ao usuário se deseja adicionar algum dos filmes recomendados à sua lista.
            Console.WriteLine("\nDeseja adicionar algum filme à sua lista de filmes? (S - Sim / N - Não)");
            string opcao = Console.ReadLine();

            if (opcao.ToUpper() == "S")
            {
                Console.WriteLine("Qual filme você deseja adicionar á sua lista ?");
                Console.WriteLine("Digite 1 para adicionar " + filme1.retornaTitulo());
                Console.WriteLine("Digite 2 para adicionar " + filme2.retornaTitulo());
                Console.WriteLine("Digite 3 para adicionar todos os filmes.");
                int opcaoAdicionar = int.Parse(Console.ReadLine());

                switch (opcaoAdicionar)
                {
                    case 1:
                        filmeRepositorio.Insere(filme1);
                        Console.WriteLine("---- " + filme1.retornaTitulo() + " cadastrado com sucesso! ----");
                        break;
                    case 2:
                        filmeRepositorio.Insere(filme2);
                        Console.WriteLine("---- " + filme2.retornaTitulo() + " cadastrado com sucesso! ----");

                        break;
                    case 3:
                        filmeRepositorio.Insere(filme1);
                        filmeRepositorio.Insere(filme2);
                        Console.WriteLine("---- " + filme1.retornaTitulo() + " e " + filme2.retornaTitulo() + " cadastrados com sucesso! ----"); ;

                        break;
                }

            }
            else
                Console.WriteLine();

        }



    }
}
