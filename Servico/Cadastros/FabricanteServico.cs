﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL.Cadastros;
using Modelo.Cadastros;

namespace Servico.Cadastros
{
    public class FabricanteServico
    {
        private FabricanteDAL fabricanteDAL = new FabricanteDAL();

        public IQueryable<Fabricante> ObterFabricanteClassificadosPorNome()
        {
            return fabricanteDAL.ObterFabricantesClassificadosPorNome();
        }
    }
}
