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
	public class TipoImovelService
	{
		private ITipoImovelDAL _tipoImovelDAL;

		public TipoImovelService()
		{

		}

		public ITipoImovelDAL TipoImovelDAL
		{
			get
			{
				if (_tipoImovelDAL == null)
					_tipoImovelDAL = new TipoImovelADO();

				return _tipoImovelDAL;
			}
			set
			{
				_tipoImovelDAL = value;
			}
		}

		public int TotalRegistros(TipoImovelFH filtro)
		{
			return TipoImovelDAL.TotalRegistros(filtro);
		}

		public IList<TipoImovel> RetornaTodos()
		{
			return TipoImovelDAL.CarregarTodos();
		}

		public IList<TipoImovel> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{
			return TipoImovelDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
		}

		public TipoImovel Carregar(TipoImovel entidade)
		{
			return TipoImovelDAL.Carregar(entidade);
		}

		public void Inserir(TipoImovel entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				TipoImovelDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(TipoImovel entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				TipoImovelDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(TipoImovel entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				TipoImovelDAL.Excluir(entidade);

				tScope.Complete();
			}
		}
	}
}