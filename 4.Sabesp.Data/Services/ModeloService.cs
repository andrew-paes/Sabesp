using System;
using System.Collections.Generic;
using System.Transactions;
using Sabesp.BO;
using Sabesp.DAL;
using Sabesp.DAL.ADO;
using Sabesp.FilterHelper;

namespace Sabesp.Data.Services
{
	public class ModeloService
	{
		private IModeloDAL _modeloDAL;

		public ModeloService() { }

		public IModeloDAL ModeloDAL
		{
			get
			{
				if (_modeloDAL == null)
					_modeloDAL = new ModeloADO();

				return _modeloDAL;
			}
			set
			{
				_modeloDAL = value;
			}
		}

		public int TotalRegistros(ModeloFH filtro)
		{
			return ModeloDAL.TotalRegistros(filtro);
		}

		public IList<Modelo> RetornaTodos()
		{
			return ModeloDAL.CarregarTodos();
		}

		public Modelo Carregar(Modelo entidade)
		{
			return ModeloDAL.Carregar(entidade);
		}

		public void Inserir(Modelo entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				ModeloDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(Modelo entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				ModeloDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(Modelo entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				ModeloDAL.Excluir(entidade);

				tScope.Complete();
			}
		}
	}
}