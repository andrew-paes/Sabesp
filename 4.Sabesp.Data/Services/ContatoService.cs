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
	public class ContatoService
	{
		private IContatoDAL _contatoDAL;

		public ContatoService()
		{

		}

		public IContatoDAL ContatoDAL
		{
			get
			{
				if (_contatoDAL == null)
					_contatoDAL = new ContatoADO();

				return _contatoDAL;
			}
			set
			{
				_contatoDAL = value;
			}
		}

		public int TotalRegistros(ContatoFH filtro)
		{
			return ContatoDAL.TotalRegistros(filtro);
		}

		public IList<Contato> RetornaTodos()
		{
			return ContatoDAL.CarregarTodos();
		}

		public IList<Contato> RetornaTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{
			return ContatoDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
		}

		public Contato Carregar(Contato entidade)
		{
			return ContatoDAL.Carregar(entidade);
		}

		public void Inserir(Contato entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				ContatoDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(Contato entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				ContatoDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(Contato entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				ContatoDAL.Excluir(entidade);

				tScope.Complete();
			}
		}

		public List<Contato> Carregar(Formulario entidade)
		{
			return ContatoDAL.Carregar(entidade);
		}
	}
}