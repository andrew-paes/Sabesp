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
	public class FormularioApoioInstitucionalService
	{
		private IFormularioApoioInstitucionalDAL _formularioApoioInstitucionalDAL;

		public FormularioApoioInstitucionalService()
		{

		}

		public IFormularioApoioInstitucionalDAL FormularioApoioInstitucionalDAL
		{
			get
			{
				if (_formularioApoioInstitucionalDAL == null)
					_formularioApoioInstitucionalDAL = new FormularioApoioInstitucionalADO();

				return _formularioApoioInstitucionalDAL;
			}
			set
			{
				_formularioApoioInstitucionalDAL = value;
			}
		}

		public int TotalRegistros(FormularioApoioInstitucionalFH filtro)
		{
			return FormularioApoioInstitucionalDAL.TotalRegistros(filtro);
		}

		public IList<FormularioApoioInstitucional> RetornaTodos()
		{
			return FormularioApoioInstitucionalDAL.CarregarTodos();
		}

		public IList<FormularioApoioInstitucional> RetornaTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{
			return FormularioApoioInstitucionalDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
		}

		public FormularioApoioInstitucional Carregar(FormularioApoioInstitucional entidade)
		{
			return FormularioApoioInstitucionalDAL.Carregar(entidade);
		}

		public void Inserir(FormularioApoioInstitucional entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioApoioInstitucionalDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(FormularioApoioInstitucional entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioApoioInstitucionalDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(FormularioApoioInstitucional entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioApoioInstitucionalDAL.Excluir(entidade);

				tScope.Complete();
			}
		}
	}
}