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
	public class InfograficoIdiomaService
	{
		private IInfograficoIdiomaDAL _infograficoIdiomaDAL;

		public InfograficoIdiomaService()
		{

		}

		public IInfograficoIdiomaDAL InfograficoIdiomaDAL
		{

			get
			{
				if (_infograficoIdiomaDAL == null)
					_infograficoIdiomaDAL = new InfograficoIdiomaADO();

				return _infograficoIdiomaDAL;
			}
			set
			{
				_infograficoIdiomaDAL = value;
			}
		}

		public int TotalRegistros(InfograficoIdiomaFH filtro)
		{
			return InfograficoIdiomaDAL.TotalRegistros(filtro);
		}

		public IList<InfograficoIdioma> RetornaTodos()
		{
			return InfograficoIdiomaDAL.CarregarTodos();
		}

		public InfograficoIdioma Carregar(InfograficoIdioma entidade)
		{
			return InfograficoIdiomaDAL.Carregar(entidade);
		}

		public void Inserir(InfograficoIdioma entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				InfograficoIdiomaDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(InfograficoIdioma entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				InfograficoIdiomaDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(InfograficoIdioma entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				InfograficoIdiomaDAL.Excluir(entidade);

				tScope.Complete();
			}
		}
	}
}
