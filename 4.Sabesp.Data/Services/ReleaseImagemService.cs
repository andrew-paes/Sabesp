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
	public class ReleaseImagemService
	{
		private IReleaseImagemDAL _releaseImagemDAL;

		public ReleaseImagemService()
		{

		}

		public IReleaseImagemDAL ReleaseImagemDAL
		{

			get
			{
				if (_releaseImagemDAL == null)
					_releaseImagemDAL = new ReleaseImagemADO();

				return _releaseImagemDAL;
			}
			set
			{
				_releaseImagemDAL = value;
			}
		}

		public int TotalRegistros(ReleaseImagemFH filtro)
		{
			return ReleaseImagemDAL.TotalRegistros(filtro);
		}

		public IList<ReleaseImagem> RetornaTodos(int registrosPorPagina, int numeroPagina, string[] ordem, string[] orientacao, ReleaseImagemFH filtro)
		{
			return ReleaseImagemDAL.CarregarTodos(registrosPorPagina, numeroPagina, ordem, orientacao, filtro);
		}

		public ReleaseImagem Carregar(ReleaseImagem entidade)
		{
			return ReleaseImagemDAL.Carregar(entidade);
		}

		public void Inserir(ReleaseImagem entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				ReleaseImagemDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(ReleaseImagem entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				ReleaseImagemDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(ReleaseImagem entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				ReleaseImagemDAL.Excluir(entidade);

				tScope.Complete();
			}
		}

		public void ExcluirRelacionado(Release entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				ReleaseImagemDAL.ExcluirRelacionado(entidade);

				tScope.Complete();
			}
		}
	}
}