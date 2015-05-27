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
	public class FormularioVideoteca1Service
	{
		private IFormularioVideoteca1DAL _formularioVideoteca1DAL;

		public FormularioVideoteca1Service()
		{

		}

		public IFormularioVideoteca1DAL FormularioVideoteca1DAL
		{
			get
			{
				if (_formularioVideoteca1DAL == null)
					_formularioVideoteca1DAL = new FormularioVideoteca1ADO();

				return _formularioVideoteca1DAL;
			}
			set
			{
				_formularioVideoteca1DAL = value;
			}
		}

		public int TotalRegistros(FormularioVideoteca1FH filtro)
		{
			return FormularioVideoteca1DAL.TotalRegistros(filtro);
		}

		public IList<FormularioVideoteca1> RetornaTodos()
		{
			return FormularioVideoteca1DAL.CarregarTodos();
		}

		public FormularioVideoteca1 Carregar(FormularioVideoteca1 entidade)
		{
			return FormularioVideoteca1DAL.Carregar(entidade);
		}

		public void Inserir(FormularioVideoteca1 entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioVideoteca1DAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(FormularioVideoteca1 entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioVideoteca1DAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(FormularioVideoteca1 entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioVideoteca1DAL.Excluir(entidade);

				tScope.Complete();
			}
		}
	}
}