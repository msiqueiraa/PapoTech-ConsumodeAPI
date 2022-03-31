using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapoTech.Interfaces
{
    public interface ApiRepository
    {
      public Task<string> GetApi(string parametro1);
    }
}
