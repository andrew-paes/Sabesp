using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sabesp.DAL;
using Sabesp.DAL.ADO;
using System.Transactions;
using Sabesp.FilterHelper;
using Sabesp.BO;

namespace Sabesp.Data.Services
{
	public class BuscaConteudoService
	{
		private IBuscaConteudoDAL _buscaConteudoDAL;

		public BuscaConteudoService()
		{

		}

		public IBuscaConteudoDAL BuscaConteudoDAL
		{
			get
			{
				if (_buscaConteudoDAL == null)
					_buscaConteudoDAL = new BuscaConteudoADO();

				return _buscaConteudoDAL;
			}
			set
			{
				_buscaConteudoDAL = value;
			}
		}

		public List<BuscaConteudo> Carregar(Idioma idioma, string search, string search2)
		{
			return BuscaConteudoDAL.Carregar(idioma, search, search2);
		}
	}
}