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
	public class PodcastCategoriaIdiomaService
	{
		private IPodcastCategoriaIdiomaDAL _podcastCategoriaIdiomaDAL;

		public PodcastCategoriaIdiomaService()
		{

		}

		public IPodcastCategoriaIdiomaDAL PodcastCategoriaIdiomaDAL
		{

			get
			{
				if (_podcastCategoriaIdiomaDAL == null)
					_podcastCategoriaIdiomaDAL = new PodcastCategoriaIdiomaADO();

				return _podcastCategoriaIdiomaDAL;
			}
			set
			{
				_podcastCategoriaIdiomaDAL = value;
			}
		}

		public int TotalRegistros(PodcastCategoriaIdiomaFH filtro)
		{
			return PodcastCategoriaIdiomaDAL.TotalRegistros(filtro);
		}

		public IList<PodcastCategoriaIdioma> RetornaTodos()
		{
			return PodcastCategoriaIdiomaDAL.CarregarTodos();
		}

		public IList<PodcastCategoriaIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{
			return PodcastCategoriaIdiomaDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
		}

		public PodcastCategoriaIdioma Carregar(PodcastCategoriaIdioma entidade)
		{
			return PodcastCategoriaIdiomaDAL.Carregar(entidade);
		}

		public void Inserir(PodcastCategoriaIdioma entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				PodcastCategoriaIdiomaDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(PodcastCategoriaIdioma entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				PodcastCategoriaIdiomaDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(PodcastCategoriaIdioma entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				PodcastCategoriaIdiomaDAL.Excluir(entidade);

				tScope.Complete();
			}
		}
	}
}