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
	public class EscolaridadeService
	{
		private IEscolaridadeDAL _escolaridadeDAL;

		public EscolaridadeService()
		{

		}

		public IEscolaridadeDAL EscolaridadeDAL
		{
			get
			{
				if (_escolaridadeDAL == null)
					_escolaridadeDAL = new EscolaridadeADO();

				return _escolaridadeDAL;
			}
			set
			{
				_escolaridadeDAL = value;
			}
		}

		public int TotalRegistros(EscolaridadeFH filtro)
		{
			return EscolaridadeDAL.TotalRegistros(filtro);
		}

		public IList<Escolaridade> RetornaTodos()
		{
			return EscolaridadeDAL.CarregarTodos();
		}

		public IList<Escolaridade> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{
			return EscolaridadeDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
		}

		public Escolaridade Carregar(Escolaridade entidade)
		{
			return EscolaridadeDAL.Carregar(entidade);
		}

		public void Inserir(Escolaridade entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				EscolaridadeDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(Escolaridade entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				EscolaridadeDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(Escolaridade entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				EscolaridadeDAL.Excluir(entidade);

				tScope.Complete();
			}
		}
	}
}