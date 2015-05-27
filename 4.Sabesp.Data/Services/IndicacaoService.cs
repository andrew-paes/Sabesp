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
	public class IndicacaoService
	{
		private IIndicacaoDAL _indicacaoDAL;

		public IndicacaoService()
		{

		}

		public IIndicacaoDAL IndicacaoDAL
		{
			get
			{
				if (_indicacaoDAL == null)
					_indicacaoDAL = new IndicacaoADO();

				return _indicacaoDAL;
			}
			set
			{
				_indicacaoDAL = value;
			}
		}

		public int TotalRegistros(IndicacaoFH filtro)
		{
			return IndicacaoDAL.TotalRegistros(filtro);
		}

		public IList<Indicacao> RetornaTodos()
		{
			return IndicacaoDAL.CarregarTodos();
		}

		public IList<Indicacao> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{
			return IndicacaoDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
		}

		public Indicacao Carregar(Indicacao entidade)
		{
			return IndicacaoDAL.Carregar(entidade);
		}

		public void Inserir(Indicacao entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				IndicacaoDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(Indicacao entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				IndicacaoDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(Indicacao entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				IndicacaoDAL.Excluir(entidade);

				tScope.Complete();
			}
		}
	}
}