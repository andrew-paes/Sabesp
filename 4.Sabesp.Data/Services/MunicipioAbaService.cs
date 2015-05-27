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
	public class MunicipioAbaService
	{
		private IMunicipioAbaDAL _municipioAbaDAL;

		public MunicipioAbaService()
		{

		}

		public IMunicipioAbaDAL MunicipioAbaDAL
		{

			get
			{
				if (_municipioAbaDAL == null)
					_municipioAbaDAL = new MunicipioAbaADO();

				return _municipioAbaDAL;
			}
			set
			{
				_municipioAbaDAL = value;
			}
		}

		public int TotalRegistros(MunicipioAbaFH filtro)
		{
			return MunicipioAbaDAL.TotalRegistros(filtro);
		}

		public IList<MunicipioAba> RetornaTodos()
		{
			return MunicipioAbaDAL.CarregarTodos();
		}

		public IList<MunicipioAba> RetornaTodos(int registrosPorPagina, int numeroPagina, string ordem, string orientacao, MunicipioAbaFH filtro)
		{
			return MunicipioAbaDAL.CarregarTodos(registrosPorPagina, numeroPagina, ordem, orientacao, filtro);
		}

		public MunicipioAba Carregar(MunicipioAba entidade)
		{
			return MunicipioAbaDAL.Carregar(entidade);
		}

		public void Inserir(MunicipioAba entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				MunicipioAbaDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(MunicipioAba entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				MunicipioAbaDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(MunicipioAba entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				MunicipioAbaDAL.Excluir(entidade);

				tScope.Complete();
			}
		}

		public void ExcluirRelacionados(Municipio entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				MunicipioAbaDAL.ExcluirRelacionados(entidade);

				tScope.Complete();
			}
		}
	}
}