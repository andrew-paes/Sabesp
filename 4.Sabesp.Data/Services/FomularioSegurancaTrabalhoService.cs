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
	public class FormularioSegurancaTrabalhoService
	{
		private IFormularioSegurancaTrabalhoDAL _formularioSegurancaTrabalhoDAL;

		public FormularioSegurancaTrabalhoService()
		{

		}

		public IFormularioSegurancaTrabalhoDAL FormularioSegurancaTrabalhoDAL
		{
			get
			{
				if (_formularioSegurancaTrabalhoDAL == null)
					_formularioSegurancaTrabalhoDAL = new FormularioSegurancaTrabalhoADO();

				return _formularioSegurancaTrabalhoDAL;
			}
			set
			{
				_formularioSegurancaTrabalhoDAL = value;
			}
		}

		public int TotalRegistros(FormularioSegurancaTrabalhoFH filtro)
		{
			return FormularioSegurancaTrabalhoDAL.TotalRegistros(filtro);
		}

		public IList<FormularioSegurancaTrabalho> RetornaTodos()
		{
			return FormularioSegurancaTrabalhoDAL.CarregarTodos();
		}

		public FormularioSegurancaTrabalho Carregar(FormularioSegurancaTrabalho entidade)
		{
			return FormularioSegurancaTrabalhoDAL.Carregar(entidade);
		}

		public void Inserir(FormularioSegurancaTrabalho entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioSegurancaTrabalhoDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(FormularioSegurancaTrabalho entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioSegurancaTrabalhoDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(FormularioSegurancaTrabalho entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioSegurancaTrabalhoDAL.Excluir(entidade);

				tScope.Complete();
			}
		}
	}
}