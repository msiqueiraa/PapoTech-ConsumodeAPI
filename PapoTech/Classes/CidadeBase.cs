

namespace PapoTech
{
    internal class CidadeBase : EntityBase
    {
        private string Cidade { get; set; }
        private string Estado { get; set; }
        private string Pais { get; set; }
        private bool Excluido { get; set; }

        public CidadeBase(int id, string cidade, string estado, string pais)
        {
            this.Id = id;
            this.Cidade = cidade;
            this.Estado = estado;
            this.Pais = pais;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Cidade: " + this.Cidade + Environment.NewLine;
            retorno += "Estado: " + this.Estado + Environment.NewLine;
            retorno += "pais: " + this.Pais + Environment.NewLine;  
            return retorno;
        }
        public int RetornaId()
        {
            return this.Id;
        }
        public string RetornaCidade()
        {
            return this.Cidade;
        }
        public string RetornaEstado()
        {
            return this.Estado;
        }
        public string RetornaPais()
        {
            return this.Pais;
        }
        public bool RetornaExcluido()
        {
            return this.Excluido;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}
