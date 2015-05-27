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
	public class ConteudoService
	{
		private IConteudoDAL _conteudoDAL;

		public ConteudoService()
		{

		}

		public IConteudoDAL ConteudoDAL
		{

			get
			{
				if (_conteudoDAL == null)
					_conteudoDAL = new ConteudoADO();

				return _conteudoDAL;
			}
			set
			{
				_conteudoDAL = value;
			}
		}

		public int TotalRegistros(ConteudoFH filtro)
		{
			return ConteudoDAL.TotalRegistros(filtro);
		}

		public IList<Conteudo> RetornaTodos()
		{
			return ConteudoDAL.CarregarTodos();
		}

		public Conteudo Carregar(Conteudo entidade)
		{
			return ConteudoDAL.Carregar(entidade);
		}

		public void Inserir(Conteudo entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				ConteudoDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void InserirRelacionado(Conteudo entidade, int regiaoId)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				ConteudoDAL.InserirRelacionado(entidade, regiaoId);

				tScope.Complete();
			}
		}

		public void Atualizar(Conteudo entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				ConteudoDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(Conteudo entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				ConteudoDAL.Excluir(entidade);

				tScope.Complete();
			}
		}

		public void ExcluirRelacionado(Conteudo entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				ConteudoDAL.ExcluirRelacionado(entidade);

				tScope.Complete();
			}
		}

		/// <summary>
		/// Return all related content
		/// </summary>
		/// <param name="conteudoIdPai"></param>
		/// <returns></returns>
		public DataTable RetornaConteudoRelacionado(int conteudoIdPai)
		{
			return this.ConteudoDAL.RetornaConteudoRelacionado(conteudoIdPai);

		}

	}
}