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
	public class EstadoService
	{
		private IEstadoDAL _estadoDAL;

		public EstadoService()
		{

		}

		public IEstadoDAL EstadoDAL
		{
			get
			{
				if (_estadoDAL == null)
					_estadoDAL = new EstadoADO();

				return _estadoDAL;
			}
			set
			{
				_estadoDAL = value;
			}
		}

		public int TotalRegistros(EstadoFH filtro)
		{
			return EstadoDAL.TotalRegistros(filtro);
		}

		public IList<Estado> RetornaTodos()
		{
			return EstadoDAL.CarregarTodos();
		}

		public IList<Estado> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{
			return EstadoDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
		}

		public Estado Carregar(Estado entidade)
		{
			return EstadoDAL.Carregar(entidade);
		}

		public void Inserir(Estado entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				EstadoDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(Estado entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				EstadoDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(Estado entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				EstadoDAL.Excluir(entidade);

				tScope.Complete();
			}
		}
	}
}