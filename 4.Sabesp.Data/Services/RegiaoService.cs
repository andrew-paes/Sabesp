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
	public class RegiaoService
	{
		private IRegiaoDAL _regiaoDAL;

		public RegiaoService()
		{

		}

		public IRegiaoDAL RegiaoDAL
		{

			get
			{
				if (_regiaoDAL == null)
					_regiaoDAL = new RegiaoADO();

				return _regiaoDAL;
			}
			set
			{
				_regiaoDAL = value;
			}
		}

		public int TotalRegistros(RegiaoFH filtro)
		{
			return RegiaoDAL.TotalRegistros(filtro);
		}

		public int TotalRegistrosRelacionado(int regiaoId, int municipioId)
		{
			return RegiaoDAL.TotalRegistrosRelacionado(regiaoId, municipioId);
		}

		public int TotalRegistrosRelacionadoConteudo(int regiaoId, int conteudoId)
		{
			return RegiaoDAL.TotalRegistrosRelacionadoConteudo(regiaoId, conteudoId);
		}

		public IList<Regiao> RetornaTodos()
		{
			return RegiaoDAL.CarregarTodos();
		}

		public Regiao Carregar(Regiao entidade)
		{
			return RegiaoDAL.Carregar(entidade);
		}

		public void Inserir(Regiao entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				RegiaoDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void InserirRelacionado(Regiao entidade, int idMunicipio)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				RegiaoDAL.InserirRelacionado(entidade, idMunicipio);

				tScope.Complete();
			}
		}

		public void Atualizar(Regiao entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				RegiaoDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(Regiao entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				RegiaoDAL.Excluir(entidade);

				tScope.Complete();
			}
		}

		public void ExcluirRelacionado(int entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				RegiaoDAL.ExcluirRelacionado(entidade);

				tScope.Complete();
			}
		}

		public void ExcluirRelacionados(Regiao entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				RegiaoDAL.ExcluirRelacionados(entidade);

				tScope.Complete();
			}
		}

		public void ExcluirConteudoRelacionado(Regiao entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				RegiaoDAL.ExcluirConteudoRelacionado(entidade);

				tScope.Complete();
			}
		}

		public List<Regiao> CarregarPorMunicipio(int municipioId)
		{
			return RegiaoDAL.CarregarPorMunicipio(municipioId);
		}

		public List<Municipio> GetMunicipios(int regiaoId)
		{
			return RegiaoDAL.GetMunicipios(regiaoId);
		}
	}
}