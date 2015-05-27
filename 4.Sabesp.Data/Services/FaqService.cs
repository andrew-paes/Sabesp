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
	public class FaqItemService
	{
		private IFaqItemDAL _faqItemDAL;

		public FaqItemService()
		{

		}

		public IFaqItemDAL FaqItemDAL
		{

			get
			{
				if (_faqItemDAL == null)
					_faqItemDAL = new FaqItemADO();

				return _faqItemDAL;
			}
			set
			{
				_faqItemDAL = value;
			}
		}

		public int TotalRegistros(FaqItemFH filtro)
		{
			return FaqItemDAL.TotalRegistros(filtro);
		}

		public IList<FaqItem> RetornaTodos()
		{
			return FaqItemDAL.CarregarTodos();
		}

		public IList<FaqItem> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
		{
			return FaqItemDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
		}

		public FaqItem Carregar(FaqItem entidade)
		{
			return FaqItemDAL.Carregar(entidade);
		}

		public void Inserir(FaqItem entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FaqItemDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(FaqItem entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FaqItemDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(FaqItem entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FaqItemDAL.Excluir(entidade);

				tScope.Complete();
			}
		}
	}
}
