using System;
using DIO.Series;

namespace DIO.Series
{
    class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {   
            bool opcaoValida = true;
        
            string opcaoUsuario = ObterOpcaoUsuario(ref opcaoValida );
            
            while (opcaoUsuario.ToUpper() != "X") 
            {
               if (opcaoValida){
               
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
                            
                        case "C":
                            Console.Clear();
                            break;

                        default:
                            Console.WriteLine("Não existe a opção Informada"); 
                            break;
                    }
               }else{

                   opcaoValida = true;

               }
                
               opcaoUsuario = ObterOpcaoUsuario(ref opcaoValida);

            } 

            Console.WriteLine("Obrigado por usar nossos Serviços");
            Console.ReadLine();
            
        }
 

          private static void ListarSeries(){
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0 ){ 
                Console.WriteLine("Nenhuma série encontrada");
                return;

            }
            foreach (var item in lista)
            {
                var texto = @$" Id - {item.retornaId()} / título - {item.retornaTitulo()}  / Ativo - {item.retornaSituacao()} ";
                Console.WriteLine(texto);    
            }

        }


        private static void InserirSerie(){
            Console.WriteLine("Insira uma série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine(@$" {i} - {Enum.GetName(typeof(Genero),i)}");
            }
            
            Console.WriteLine("Digite um dos gêneros acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da série:");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de início da série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série:");
            string entradaDescricao = Console.ReadLine();


            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo : entradaTitulo,
                                        ano: entradaAno,
                                        descricao:entradaDescricao);

            repositorio.Insere(novaSerie); 
        }

     private static void AtualizarSerie(){
            
            Console.WriteLine("Digite o id para atualizar uma série");
            int indiceSerie = int.Parse(Console.ReadLine());


            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine(@$" {i} - {Enum.GetName(typeof(Genero),i)}");
            }
            
            Console.WriteLine("Digite um dos gêneros acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da série:");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de início da série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série:");
            string entradaDescricao = Console.ReadLine();


            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo : entradaTitulo,
                                        ano: entradaAno,
                                        descricao:entradaDescricao);


            repositorio.Atualizar(indiceSerie, atualizaSerie); 


        }


        
        private static void ExcluirSerie(){
            
            Console.WriteLine("Digite o id para excluir a série");
            int indiceSerie = int.Parse(Console.ReadLine());
            
            repositorio.Excluir(indiceSerie); 


        }

        private static void VisualizarSerie(){
            
            Console.WriteLine("Digite o id da série");
            int indiceSerie = int.Parse(Console.ReadLine());
            
            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine (serie);
             


        }


        private static string  ObterOpcaoUsuario(ref bool opcaoValida)
        {
            Console.WriteLine();
            Console.WriteLine("Dio Séries - Hugo Arruda - 2022!!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar Tela ");
            Console.WriteLine("X - Sair");

            String opcaoUsuario = Console.ReadLine().ToUpper();
            var mensagemErro =  validarOpcaoDigitada(ref opcaoValida, opcaoUsuario);
            var aRetornoTamanho = mensagemErro.Split("/");
            if (aRetornoTamanho[0] == "99"){
                Console.WriteLine();
                Console.WriteLine(aRetornoTamanho[1]);
            }

            Console.WriteLine();
            return opcaoUsuario;

        }
        /**
            Retorno: String 
                        00 -> reotno OK  
                        99 -> retorno com erro
        */
        private static string validarOpcaoDigitada(ref bool Op, string opcaoDigitada){
            
            String texto ="00/OK";
                       
            if(opcaoDigitada.Length > 1 )
            {                
                texto = "99/Por gentileza informe apenas um caracter!!";
                Op = false;
            }

            return texto;
        }



      

    }
}
