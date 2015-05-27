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
	public class ProdutoTipoIdiomaService
	{
		private IProdutoTipoIdiomaDAL _produtoTipoIdiomaDAL;

		public ProdutoTipoIdiomaService()
		{

		}

		public IProdutoTipoIdiomaDAL ProdutoTipoIdiomaDAL
		{

			get
			{
				if (_produtoTipoIdiomaDAL == null)
					_produtoTipoIdiomaDAL = new ProdutoTipoIdiomaADO();

				return _produtoTipoIdiomaDAL;
			}
			set
			{
				_produtoTipoIdiomaDAL = value;
			}
		}

		public int TotalRegistros(ProdutoTipoIdiomaFH filtro)
		{
			return ProdutoTipoIdiomaDAL.TotalRegistros(filtro);
		}

		public IList<ProdutoTipoIdioma> RetornaTodos()
		{
			return ProdutoTipoIdiomaDAL.CarregarTodos();
		}

		public IList<ProdutoTipoIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
		{
			return ProdutoTipoIdiomaDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
		}

		public ProdutoTipoIdioma Carregar(ProdutoTipoIdioma entidade)
		{
			return ProdutoTipoIdiomaDAL.Carregar(entidade);
		}

		public void Inserir(ProdutoTipoIdioma entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				ProdutoTipoIdiomaDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(ProdutoTipoIdioma entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				ProdutoTipoIdiomaDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(ProdutoTipoIdioma entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				ProdutoTipoIdiomaDAL.Excluir(entidade);

				tScope.Complete();
			}
		}
	}
}
