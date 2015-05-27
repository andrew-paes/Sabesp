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
	public class FormularioImprensaService
	{
		private IFormularioImprensaDAL _formularioImprensaDAL;

		public FormularioImprensaService()
		{

		}

		public IFormularioImprensaDAL FormularioImprensaDAL
		{
			get
			{
				if (_formularioImprensaDAL == null)
					_formularioImprensaDAL = new FormularioImprensaADO();

				return _formularioImprensaDAL;
			}
			set
			{
				_formularioImprensaDAL = value;
			}
		}

		public int TotalRegistros(FormularioImprensaFH filtro)
		{
			return FormularioImprensaDAL.TotalRegistros(filtro);
		}

		public IList<FormularioImprensa> RetornaTodos()
		{
			return FormularioImprensaDAL.CarregarTodos();
		}

		public IList<FormularioImprensa> RetornaTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{
			return FormularioImprensaDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
		}

		public FormularioImprensa Carregar(FormularioImprensa entidade)
		{
			return FormularioImprensaDAL.Carregar(entidade);
		}

		public void Inserir(FormularioImprensa entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioImprensaDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(FormularioImprensa entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioImprensaDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(FormularioImprensa entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioImprensaDAL.Excluir(entidade);

				tScope.Complete();
			}
		}
	}
}