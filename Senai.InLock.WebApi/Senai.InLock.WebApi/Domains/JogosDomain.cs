using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    public class JogosDomain
    {
        public int IdJogos { get; set; }

        public string NomeJogos { get; set; }

        public string Descricao { get; set; }

        public DateTime DataLancamento { get; set; }

        public string Valor { get; set; }

        public EstudioDomain Estudio { get; set; }
    }
}
