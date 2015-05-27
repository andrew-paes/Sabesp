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
	/// <summary>
	/// 
	/// </summary>
	public class ComunicadoService
	{
		private IComunicadoDAL _comunicadoDAL;

		public ComunicadoService()
		{

		}

		public IComunicadoDAL ComunicadoDAL
		{

			get
			{
				if (_comunicadoDAL == null)
					_comunicadoDAL = new ComunicadoADO();

				return _comunicadoDAL;
			}
			set
			{
				_comunicadoDAL = value;
			}
		}

		public int TotalRegistros(ComunicadoFH filtro)
		{
			return ComunicadoDAL.TotalRegistros(filtro);
		}

		public IList<Comunicado> RetornaTodos()
		{
			return ComunicadoDAL.CarregarTodos();
		}

		public IList<Comunicado> RetornaTodos(int registrosPorPagina, int numeroPagina, string ordemColunas, string ordemSentidos, ComunicadoFH filtro)
		{
			return ComunicadoDAL.CarregarTodos(registrosPorPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
		}

		public IList<Comunicado> RetornaTodosSite(int quantidadeRegistros, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, ComunicadoFH filtro)
		{
			return ComunicadoDAL.CarregarTodosSite(quantidadeRegistros, ordemColunas, ordemSentidos, filtro);
		}

		public Comunicado Carregar(Comunicado entidade)
		{
			return ComunicadoDAL.Carregar(entidade);
		}

		public Comunicado CarregarToSite(int comunicadoId)
		{
			return ComunicadoDAL.CarregarToSite(comunicadoId);
		}
        public IList<Comunicado> CarregarTagged(int tagId)
        {
            return ComunicadoDAL.CarregarTagged(tagId);
        }
		public void Inserir(Comunicado entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				ComunicadoDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(Comunicado entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				ComunicadoDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(Comunicado entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				ComunicadoDAL.Excluir(entidade);

				tScope.Complete();
			}
		}

		public List<Comunicado> CarregarPorRegiao(int qtdComunicados, int regiaoId)
		{
			return ComunicadoDAL.CarregarPorRegiao(qtdComunicados, regiaoId);
		}
	}
}