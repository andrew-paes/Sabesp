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
	public class PodcastCategoriaService
	{
		private IPodcastCategoriaDAL _podcastCategoriaDAL;

		public PodcastCategoriaService()
		{

		}

		public IPodcastCategoriaDAL PodcastCategoriaDAL
		{

			get
			{
				if (_podcastCategoriaDAL == null)
					_podcastCategoriaDAL = new PodcastCategoriaADO();

				return _podcastCategoriaDAL;
			}
			set
			{
				_podcastCategoriaDAL = value;
			}
		}

		public void Inserir(PodcastCategoria entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				PodcastCategoriaDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(PodcastCategoria entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				PodcastCategoriaDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(PodcastCategoria entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				PodcastCategoriaDAL.Excluir(entidade);

				tScope.Complete();
			}
		}

		public int TotalRegistros(PodcastCategoriaFH filtro)
		{
			return PodcastCategoriaDAL.TotalRegistros(filtro);
		}

		public IList<PodcastCategoria> RetornaTodos()
		{
			return PodcastCategoriaDAL.CarregarTodos();
		}
	}
}