using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapoTech.Interfaces
{
    public interface IRepositoryApiTempo
        {
            public Task<string> GetApi(string Cidade, string Estado, string Pais);
        }
    
}
