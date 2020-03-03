using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    interface IEstudioRepository
    {
        List<EstudioDomain> Listar();
    }
}
