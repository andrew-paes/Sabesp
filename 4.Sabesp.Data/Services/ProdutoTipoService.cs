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
	public class ProdutoTipoService
	{
		private IProdutoTipoDAL _produtoTipoDAL;

		public ProdutoTipoService()
		{

		}

		public IProdutoTipoDAL ProdutoTipoDAL
		{

			get
			{
				if (_produtoTipoDAL == null)
					_produtoTipoDAL = new ProdutoTipoADO();

				return _produtoTipoDAL;
			}
			set
			{
				_produtoTipoDAL = value;
			}
		}

		public int TotalRegistros(ProdutoTipoFH filtro)
		{
			return ProdutoTipoDAL.TotalRegistros(filtro);
		}

		public IList<ProdutoTipo> RetornaTodos()
		{
			return ProdutoTipoDAL.CarregarTodos();
		}

		public IList<ProdutoTipo> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
		{
			return ProdutoTipoDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
		}

		public ProdutoTipo Carregar(ProdutoTipo entidade)
		{
			return ProdutoTipoDAL.Carregar(entidade);
		}

		public void Inserir(ProdutoTipo entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				ProdutoTipoDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(ProdutoTipo entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				ProdutoTipoDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(ProdutoTipo entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				ProdutoTipoDAL.Excluir(entidade);

				tScope.Complete();
			}
		}

	}
}
