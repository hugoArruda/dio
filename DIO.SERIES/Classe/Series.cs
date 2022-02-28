using System.Text;


namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
      
        private Genero Genero { get; set; }

        private string Titulo { get; set; }

        private string Descricao { get; set; }

        private int Ano { get; set; }

        private bool Ativo {get; set;}



        public Serie(int id, Genero genero, string titulo, string descricao, int ano):base()
        {   this.Id= id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Ativo = true;

        }


        public override string ToString()
        {
            StringBuilder Texto = new StringBuilder();  

            Texto.Append($" Gênero {this.Genero} ");
            Texto.Append($" Título {this.Titulo} ");
            Texto.Append($" Descrição {this.Descricao} ");
            Texto.Append($" Ano de Inicio {this.Ano} ");
            Texto.Append($" Ativo - {this.Ativo}");

            return Texto.ToString();
            
        }
        
        public string retornaTitulo () {
            
            return  this.Titulo;

        }
        
        public int retornaId(){
             return this.Id;
        }

        public bool retornaSituacao(){
             return this.Ativo;   
        }

        public void Excluir (){

            this.Ativo = false;
        }

    }
}