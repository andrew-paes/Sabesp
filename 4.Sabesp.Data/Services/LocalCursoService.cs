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
	public class LocalCursoService
	{
		private ILocalCursoDAL _localCursoDAL;

		public LocalCursoService()
		{

		}

		public ILocalCursoDAL LocalCursoDAL
		{
			get
			{
				if (_localCursoDAL == null)
					_localCursoDAL = new LocalCursoADO();

				return _localCursoDAL;
			}
			set
			{
				_localCursoDAL = value;
			}
		}

		public int TotalRegistros(LocalCursoFH filtro)
		{
			return LocalCursoDAL.TotalRegistros(filtro);
		}

		public IList<LocalCurso> RetornaTodos()
		{
			return LocalCursoDAL.CarregarTodos();
		}

		public IList<LocalCurso> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{
			return LocalCursoDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
		}

		public LocalCurso Carregar(LocalCurso entidade)
		{
			return LocalCursoDAL.Carregar(entidade);
		}

		public void Inserir(LocalCurso entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				LocalCursoDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(LocalCurso entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				LocalCursoDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(LocalCurso entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				LocalCursoDAL.Excluir(entidade);

				tScope.Complete();
			}
		}
	}
}