using System;
using System.Text;
using System.Collections.Generic;
using Sabesp.BO;
using Sabesp.FilterHelper;
using System.Data;

namespace Sabesp.DAL
{
	public interface IBuscaConteudoDAL
    {
		List<BuscaConteudo> Carregar(Idioma idioma, string search, string search2);
    }
}
