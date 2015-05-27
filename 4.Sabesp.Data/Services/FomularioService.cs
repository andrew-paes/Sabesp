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
	public class FormularioService
	{
		private IFormularioDAL _formularioDAL;

		public FormularioService()
		{

		}

		public IFormularioDAL FormularioDAL
		{
			get
			{
				if (_formularioDAL == null)
					_formularioDAL = new FormularioADO();

				return _formularioDAL;
			}
			set
			{
				_formularioDAL = value;
			}
		}

		public int TotalRegistros(FormularioFH filtro)
		{
			return FormularioDAL.TotalRegistros(filtro);
		}

		public IList<Formulario> RetornaTodos()
		{
			return FormularioDAL.CarregarTodos();
		}

		public IList<Formulario> RetornaTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{
			return FormularioDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
		}

		public Formulario Carregar(Formulario entidade)
		{
			return FormularioDAL.Carregar(entidade);
		}

		public void Inserir(Formulario entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(Formulario entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(Formulario entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioDAL.Excluir(entidade);

				tScope.Complete();
			}
		}

		public int TotalRegistrosRelacionado(int contatoId, int formularioId)
		{
			return FormularioDAL.TotalRegistrosRelacionado(contatoId, formularioId);
		}

		public void InserirRelacionado(int contatoId, int formularioId)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioDAL.InserirRelacionado(contatoId, formularioId);

				tScope.Complete();
			}
		}

		public void ExcluirRelacionado(int entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioDAL.ExcluirRelacionado(entidade);

				tScope.Complete();
			}
		}
	}
}