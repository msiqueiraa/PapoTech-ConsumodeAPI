using PapoTech.Interfaces;

namespace PapoTech
{
    internal class CidadeController : IRepository<CidadeBase>
    {
        private readonly List<CidadeBase> listaCidade = new();
        public void Atualiza(int id, CidadeBase entity)
        {
            listaCidade[id]=entity;
        }
        public void Exclui(int id)
        {
            listaCidade[id].Excluir();
        }
        public void Insere(CidadeBase entity)
        {
            listaCidade.Add(entity);
        }
        public List<CidadeBase> Lista()
        {
            return listaCidade;
        }
        public int ProximoId()
        {
            return listaCidade.Count;
        }
        public CidadeBase RetornaPorId(int id)
        {
            try
            {
                return listaCidade[id];
            }
            catch
            {
                return null;
            }
        }
    }
}
