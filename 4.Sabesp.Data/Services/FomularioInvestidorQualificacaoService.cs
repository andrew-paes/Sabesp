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
	public class FormularioInvestidorQualificacaoService
	{
		private IFormularioInvestidorQualificacaoDAL _formularioInvestidorQualificacaoDAL;

		public FormularioInvestidorQualificacaoService()
		{

		}

		public IFormularioInvestidorQualificacaoDAL FormularioInvestidorQualificacaoDAL
		{
			get
			{
				if (_formularioInvestidorQualificacaoDAL == null)
					_formularioInvestidorQualificacaoDAL = new FormularioInvestidorQualificacaoADO();

				return _formularioInvestidorQualificacaoDAL;
			}
			set
			{
				_formularioInvestidorQualificacaoDAL = value;
			}
		}

		public int TotalRegistros(FormularioInvestidorQualificacaoFH filtro)
		{
			return FormularioInvestidorQualificacaoDAL.TotalRegistros(filtro);
		}

		public IList<FormularioInvestidorQualificacao> RetornaTodos()
		{
			return FormularioInvestidorQualificacaoDAL.CarregarTodos();
		}

		public FormularioInvestidorQualificacao Carregar(FormularioInvestidorQualificacao entidade)
		{
			return FormularioInvestidorQualificacaoDAL.Carregar(entidade);
		}

		public void Inserir(FormularioInvestidorQualificacao entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioInvestidorQualificacaoDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(FormularioInvestidorQualificacao entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioInvestidorQualificacaoDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(FormularioInvestidorQualificacao entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				FormularioInvestidorQualificacaoDAL.Excluir(entidade);

				tScope.Complete();
			}
		}
	}
}