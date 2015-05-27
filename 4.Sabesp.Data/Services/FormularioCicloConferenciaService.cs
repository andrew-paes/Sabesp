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
	public class FormularioCicloConferenciaService
	{
		private IFormularioCicloConferenciaDAL _formularioCicloConferenciaDAL;

		public FormularioCicloConferenciaService()
		{

		}

		public IFormularioCicloConferenciaDAL FormularioCicloConferenciaDAL
		{
			get
			{
				if (_formularioCicloConferenciaDAL == null)
					_formularioCicloConferenciaDAL = new FormularioCicloConferenciaADO();

				return _formularioCicloConferenciaDAL;
			}
			set
			{
				_formularioCicloConferenciaDAL = value;
			}
		}

		public int TotalRegistros(FormularioCicloConferenciaFH filtro)
		{
			return FormularioCicloConferenciaDAL.TotalRegistros(filtro);
		}

		public IList<FormularioCicloConferencia> RetornaTodos()
		{
			return FormularioCicloConferenciaDAL.CarregarTodos();
		}

		public IList<FormularioCicloConferencia> RetornaTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{
			return FormularioCicloConferenciaDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
		}

		public FormularioCicloConferencia Carregar(FormularioCicloConferencia entidade)
		{
			return FormularioCicloConferenciaDAL.Carregar(entidade);
		}

		public void Inserir(FormularioCicloConferencia entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioCicloConferenciaDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(FormularioCicloConferencia entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioCicloConferenciaDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(FormularioCicloConferencia entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioCicloConferenciaDAL.Excluir(entidade);

				tScope.Complete();
			}
		}
	}
}