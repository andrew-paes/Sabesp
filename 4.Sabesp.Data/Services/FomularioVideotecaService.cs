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
	public class FormularioVideotecaService
	{
		private IFormularioVideotecaDAL _formularioVideotecaDAL;

		public FormularioVideotecaService()
		{

		}

		public IFormularioVideotecaDAL FormularioVideotecaDAL
		{
			get
			{
				if (_formularioVideotecaDAL == null)
					_formularioVideotecaDAL = new FormularioVideotecaADO();

				return _formularioVideotecaDAL;
			}
			set
			{
				_formularioVideotecaDAL = value;
			}
		}

		public int TotalRegistros(FormularioVideotecaFH filtro)
		{
			return FormularioVideotecaDAL.TotalRegistros(filtro);
		}

		public IList<FormularioVideoteca> RetornaTodos()
		{
			return FormularioVideotecaDAL.CarregarTodos();
		}

		public FormularioVideoteca Carregar(FormularioVideoteca entidade)
		{
			return FormularioVideotecaDAL.Carregar(entidade);
		}

		public void Inserir(FormularioVideoteca entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioVideotecaDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(FormularioVideoteca entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioVideotecaDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(FormularioVideoteca entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioVideotecaDAL.Excluir(entidade);

				tScope.Complete();
			}
		}
	}
}