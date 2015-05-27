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
	public class FormularioInvestidorService
	{
		private IFormularioInvestidorDAL _formularioInvestidorDAL;

		public FormularioInvestidorService()
		{

		}

		public IFormularioInvestidorDAL FormularioInvestidorDAL
		{
			get
			{
				if (_formularioInvestidorDAL == null)
					_formularioInvestidorDAL = new FormularioInvestidorADO();

				return _formularioInvestidorDAL;
			}
			set
			{
				_formularioInvestidorDAL = value;
			}
		}

		public int TotalRegistros(FormularioInvestidorFH filtro)
		{
			return FormularioInvestidorDAL.TotalRegistros(filtro);
		}

		public IList<FormularioInvestidor> RetornaTodos()
		{
			return FormularioInvestidorDAL.CarregarTodos();
		}

		public FormularioInvestidor Carregar(FormularioInvestidor entidade)
		{
			return FormularioInvestidorDAL.Carregar(entidade);
		}

		public void Inserir(FormularioInvestidor entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioInvestidorDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(FormularioInvestidor entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioInvestidorDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(FormularioInvestidor entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioInvestidorDAL.Excluir(entidade);

				tScope.Complete();
			}
		}
	}
}