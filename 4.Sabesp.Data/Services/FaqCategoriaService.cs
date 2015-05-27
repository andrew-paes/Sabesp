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
	public class FaqCategoriaService
	{
		private IFaqCategoriaDAL _faqCategoriaDAL;

		public FaqCategoriaService()
		{

		}

		public IFaqCategoriaDAL FaqCategoriaDAL
		{

			get
			{
				if (_faqCategoriaDAL == null)
					_faqCategoriaDAL = new FaqCategoriaADO();

				return _faqCategoriaDAL;
			}
			set
			{
				_faqCategoriaDAL = value;
			}
		}

		public int TotalRegistros(FaqCategoriaFH filtro)
		{
			return FaqCategoriaDAL.TotalRegistros(filtro);
		}

		public IList<FaqCategoria> RetornaTodos()
		{
			return FaqCategoriaDAL.CarregarTodos();
		}

		public IList<FaqCategoria> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
		{
			return FaqCategoriaDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
		}

		public FaqCategoria Carregar(FaqCategoria entidade)
		{
			return FaqCategoriaDAL.Carregar(entidade);
		}

		public void Inserir(FaqCategoria entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FaqCategoriaDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(FaqCategoria entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FaqCategoriaDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(FaqCategoria entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FaqCategoriaDAL.Excluir(entidade);

				tScope.Complete();
			}
		}
	}
}
