

namespace PapoTech.Interfaces
{
    public interface IRepositoryApi
    {
      public Task<string> GetApi(string QueryString);
    }
}
