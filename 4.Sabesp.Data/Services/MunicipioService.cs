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
	public class MunicipioService
	{
		private IMunicipioDAL _municipioDAL;

		public MunicipioService()
		{

		}

		public IMunicipioDAL MunicipioDAL
		{

			get
			{
				if (_municipioDAL == null)
					_municipioDAL = new MunicipioADO();

				return _municipioDAL;
			}
			set
			{
				_municipioDAL = value;
			}
		}

		public int TotalRegistros(MunicipioFH filtro)
		{
			return MunicipioDAL.TotalRegistros(filtro);
		}

		public IList<Municipio> RetornaTodos()
		{
			return MunicipioDAL.CarregarTodos();
		}

		public IList<Municipio> RetornaTodos(int registrosPorPagina, int numeroPagina, string[] ordem, string[] orientacao, MunicipioFH filtro)
		{
			return MunicipioDAL.CarregarTodos(registrosPorPagina, numeroPagina, ordem, orientacao, filtro);
		}

		public int BuscarMunicipioId(string nomeMunicipio)
		{
			return MunicipioDAL.BuscarMunicipioId(nomeMunicipio);
		}

		public IList<Municipio> CarregarDifExiste()
		{
			return MunicipioDAL.CarregarDifExiste();
		}

		public IList<Municipio> CarregarDifExisteRegiao(int regiaoId)
		{
			return MunicipioDAL.CarregarDifExisteRegiao(regiaoId);
		}

		public Municipio Carregar(Municipio entidade)
		{
			return MunicipioDAL.Carregar(entidade);
		}

		public void Inserir(Municipio entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				MunicipioDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(Municipio entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				MunicipioDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(Municipio entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				MunicipioDAL.Excluir(entidade);

				tScope.Complete();
			}
		}

		public void ExcluirRelacionados(Municipio entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				MunicipioDAL.ExcluirRelacionados(entidade);

				tScope.Complete();
			}
		}
	}
}