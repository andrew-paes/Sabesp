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
	public class FormularioCursoVazamentoService
	{
		private IFormularioCursoVazamentoDAL _formularioCursoVazamentoDAL;

		public FormularioCursoVazamentoService()
		{

		}

		public IFormularioCursoVazamentoDAL FormularioCursoVazamentoDAL
		{
			get
			{
				if (_formularioCursoVazamentoDAL == null)
					_formularioCursoVazamentoDAL = new FormularioCursoVazamentoADO();

				return _formularioCursoVazamentoDAL;
			}
			set
			{
				_formularioCursoVazamentoDAL = value;
			}
		}

		public int TotalRegistros(FormularioCursoVazamentoFH filtro)
		{
			return FormularioCursoVazamentoDAL.TotalRegistros(filtro);
		}

		public IList<FormularioCursoVazamento> RetornaTodos()
		{
			return FormularioCursoVazamentoDAL.CarregarTodos();
		}

		public IList<FormularioCursoVazamento> RetornaTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{
			return FormularioCursoVazamentoDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
		}

		public FormularioCursoVazamento Carregar(FormularioCursoVazamento entidade)
		{
			return FormularioCursoVazamentoDAL.Carregar(entidade);
		}

		public void Inserir(FormularioCursoVazamento entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioCursoVazamentoDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(FormularioCursoVazamento entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioCursoVazamentoDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(FormularioCursoVazamento entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioCursoVazamentoDAL.Excluir(entidade);

				tScope.Complete();
			}
		}
	}
}